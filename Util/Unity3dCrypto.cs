using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Scramble.Util
{
    public static class Unity3dCrypto
    {
        public static byte[] Unity3dMagic = new byte[] { 0xC4, 0x88, 0x6E, 0x25, 0xCB, 0xD4, 0x86, 0x1D, 0x2D, 0xE1, 0x04, 0x63, 0x18, 0xBE, 0x23, 0xCE, 0x7F, 0x29, 0x36, 0x18, 0xF5, 0x7A, 0x65, 0xA2, 0xB7, 0x87, 0x4F, 0x2A, 0x9D, 0xC6, 0xF4, 0xCD };

        public static byte[] UnityFs = new byte[] { 0x55, 0x6E, 0x69, 0x74, 0x79, 0x46, 0x53 };

        public static byte[] Unity3dKey = new byte[] { 0x6D, 0x6B, 0x3A, 0x39, 0x74, 0x7A, 0x78, 0x57, 0x52, 0x46, 0x7D, 0x4A, 0x70, 0x7A, 0x77, 0x32 };

        public static byte[] Unity3dIv = new byte[] { 0x4E, 0x46, 0x58, 0x6A, 0x65, 0x71, 0x28, 0x6E, 0x3A, 0x33, 0x67, 0x27, 0x38, 0x26, 0x3D, 0x3B };

        public static Dictionary<string, byte[]> ProcessFiles(string[] FileNames, out List<string> ErrorFiles)
        {
            ErrorFiles = new List<string>();
            Dictionary<string, byte[]> Output = new Dictionary<string, byte[]>();
            Rijndael RjindaelCrypto = new Rijndael(Unity3dKey, Unity3dIv);

            foreach (string FileName in FileNames)
            {
                using (BinaryReader Stream = new BinaryReader(File.OpenRead(FileName)))
                {
                    byte[] Header = Stream.ReadBytes(7);
                    byte[] Magic = Stream.ReadBytes(25);

                    if (CompareHeader(Header))
                    {
                        long Length = Stream.BaseStream.Length - 32;
                        byte[] DecryptedData = CombineByteArrays(Header, Magic, Stream.ReadBytes((int)Length));
                        byte[] EncryptedData = RjindaelCrypto.Encrypt(DecryptedData);

                        string NewFileName = string.Format("{0}_ENCRYPTED.unity3d", Path.GetFileNameWithoutExtension(FileName));
                        Output.Add(NewFileName, EncryptedData);
                    }
                    else if (CompareMagic(CombineByteArrays(Header, Magic)))
                    {
                        long Length = Stream.BaseStream.Length - 32;
                        byte[] EncryptedData = Stream.ReadBytes((int)Length);
                        byte[] DecryptedData = RjindaelCrypto.Decrypt(CombineByteArrays(Header, Magic, EncryptedData));

                        string NewFileName = string.Format("{0}_DECRYPTED.unity3d", Path.GetFileNameWithoutExtension(FileName));
                        Output.Add(NewFileName, DecryptedData);
                    }
                    else
                    {
                        ErrorFiles.Add(FileName);
                    }

                    Stream.Close();
                }
            }

            return Output;
        }

        private static bool CompareHeader(byte[] FileHeader)
        {
            if (UnityFs.Length != FileHeader.Length)
            {
                return false;
            }

            for (int i = 0; i < UnityFs.Length; i++)
            {
                if (UnityFs[i] != FileHeader[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CompareMagic(byte[] FileMagic)
        {
            if (Unity3dMagic.Length != FileMagic.Length)
            {
                return false;
            }

            for (int i = 0; i < Unity3dMagic.Length; i++)
            {
                if (Unity3dMagic[i] != FileMagic[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static byte[] CombineByteArrays(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }
    }
}
