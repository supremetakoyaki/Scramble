using System.IO;
using System.Security.Cryptography;

namespace Scramble.Util
{
    public class Rijndael
    {
        private readonly int KeySize;
        private readonly int BlockSize;
        private readonly PaddingMode PaddingMode;
        private readonly CipherMode CipherMode;

        private readonly byte[] Key;
        private readonly byte[] IV;

        public Rijndael(byte[] key, byte[] iV, PaddingMode paddingMode = PaddingMode.None, CipherMode cipherMode = CipherMode.CBC)
        {
            Key = key;
            IV = iV;
            PaddingMode = paddingMode;
            CipherMode = cipherMode;

            KeySize = Key.Length * 8;
            BlockSize = IV.Length * 8;
        }

        private RijndaelManaged GetAlgorithmObject()
        {
            RijndaelManaged algorithm = new RijndaelManaged()
            {
                KeySize = KeySize,
                BlockSize = BlockSize,
                Padding = PaddingMode,
                Mode = CipherMode
            };

            return algorithm;
        }

        private CryptoStream GetDecryptionStream(Stream data)
        {
            using (RijndaelManaged rijndael = GetAlgorithmObject())
            {
                rijndael.KeySize = KeySize;
                rijndael.Key = Key;
                rijndael.IV = IV;

                ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
                CryptoStream csDecrypt = new CryptoStream(data, decryptor, CryptoStreamMode.Read);

                return csDecrypt;
            }
        }

        private CryptoStream GetEncryptionStream(Stream data)
        {
            using (RijndaelManaged rijndael = GetAlgorithmObject())
            {
                rijndael.Key = Key;
                rijndael.IV = IV;

                ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                CryptoStream csEncrypt = new CryptoStream(data, encryptor, CryptoStreamMode.Write);

                return csEncrypt;
            }
        }

        public byte[] Decrypt(byte[] encryptedData)
        {
            byte[] decrypted = null;

            using (MemoryStream memStream = new MemoryStream(encryptedData))
            {
                using (CryptoStream csDecrypt = GetDecryptionStream(memStream))
                {
                    using (MemoryStream output = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];

                        int read = csDecrypt.Read(buffer, 0, buffer.Length);

                        while (read > 0)
                        {
                            output.Write(buffer, 0, read);

                            read = csDecrypt.Read(buffer, 0, buffer.Length);
                        }

                        csDecrypt.Flush();

                        decrypted = output.ToArray();
                    }
                }
            }

            return decrypted;
        }

        public byte[] Encrypt(byte[] data)
        {
            byte[] encrypted = null;

            using (MemoryStream memStream = new MemoryStream())
            {
                using (var csEncrypt = GetEncryptionStream(memStream))
                {
                    csEncrypt.Write(data, 0, data.Length);
                    csEncrypt.FlushFinalBlock();

                    memStream.Position = 0;
                    encrypted = memStream.ToArray();
                }
            }

            return encrypted;
        }
    }
}
