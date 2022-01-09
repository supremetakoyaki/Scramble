using System;
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

        private static readonly byte[] _primes = new byte[9] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

        public Rijndael(byte[] key, byte[] iV, PaddingMode paddingMode = PaddingMode.None, CipherMode cipherMode = CipherMode.CBC)
        {
            GenerateNeoTwewyKey(key);
            GenerateNeoTwewyIV(iV);

            Key = key;
            IV = iV;
            PaddingMode = paddingMode;
            CipherMode = cipherMode;

            KeySize = Key.Length * 8;
            BlockSize = IV.Length * 8;
        }

        private void GenerateNeoTwewyKey(byte[] key)
        {
            key[0] = (byte)(key[0] - (_primes[0] * _primes[1]));
            key[1] = (byte)(key[1] - (_primes[4] - _primes[0]));
            key[2] = (byte)(key[2] - (_primes[4] * _primes[2] - _primes[2]));
            key[3] = (byte)(key[3] - (_primes[6] * _primes[0]));
            key[5] = (byte)(key[5] + (_primes[8] * _primes[0] + _primes[0]));
            key[6] = (byte)(key[6] - _primes[7]);
            key[7] = (byte)(key[7] - (_primes[6] * _primes[1] + _primes[0]));
            key[8] = (byte)(key[8] + (_primes[4] * _primes[0] + _primes[0]));
            key[9] = (byte)(key[9] - (_primes[3] * _primes[1]));
            key[10] = (byte)(key[10] - (_primes[8] * _primes[1] + _primes[2]));
            key[11] = (byte)(key[11] + (_primes[1] * _primes[2]));
            key[12] = (byte)(key[12] - (_primes[7] * _primes[0] + _primes[1]));
            key[13] = (byte)(key[11] + _primes[2] + 1);
            key[14] = (byte)(key[14] - (_primes[8] * _primes[1] + _primes[0] + _primes[0]));
            key[15] = (byte)(key[15] - (_primes[8] * _primes[0] + _primes[0]));

            System.Windows.Forms.MessageBox.Show(BitConverter.ToString(key).Replace("-", " "));
        }

        private void GenerateNeoTwewyIV(byte[] iv)
        {
            Array.Reverse(iv);
            iv[0] = (byte)(iv[0] + 140);
            iv[1] = (byte)(iv[1] + 134);
            iv[2] = (byte)(iv[2] - (_primes[2] * _primes[0]));
            iv[3] = (byte)(iv[3] - 84);
            iv[4] = (byte)(iv[4] + 106);
            iv[5] = (byte)(iv[5] + 97);
            iv[6] = (byte)(iv[6] + 115);
            iv[7] = (byte)(iv[7] + 115);
            iv[8] = (byte)(iv[8] + 177);
            iv[9] = (byte)(iv[9] + 137);
            iv[10] = (byte)(iv[10] + (_primes[0] * _primes[5]));
            iv[11] = (byte)(iv[11] + (_primes[3] * _primes[1] * _primes[1]));
            iv[12] = (byte)(iv[12] - (_primes[3] * _primes[0]));
            iv[13] = (byte)(iv[13] + 120);
            iv[14] = (byte)(iv[14] + (_primes[0] * _primes[6] - _primes[1]));
            iv[15] = (byte)(iv[15] - 57);

            System.Windows.Forms.MessageBox.Show(BitConverter.ToString(iv).Replace("-", " "));
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
                using (CryptoStream csEncrypt = GetEncryptionStream(memStream))
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
