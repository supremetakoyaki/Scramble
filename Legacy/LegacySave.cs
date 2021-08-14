using System;
using System.IO;
using System.Security.Cryptography;

namespace Scramble.Legacy
{
    public class LegacySave
    {
        public const int SAVE_SIZE = 51252;

        public const int MAGIC_OFFSET = 0;
        public const int MAGIC_SIZE = 32;

        public const int HASH_OFFSET = 32;
        public const int HASH_SIZE = 32;

        public const int DATA_OFFSET = 64;
        public const int DATA_SIZE = 51188;

        public string FilePath { get; set; }
        public byte[] Magic { get; set; }
        public byte[] Checksum => CalculateNewChecksum();
        public byte[] Data { get; set; }

        public LegacySave(byte[] SaveData, string File, out byte Result)
        {
            if (SaveData.Length != SAVE_SIZE)
            {
                Result = 0;
                return;
            }

            FilePath = File;

            Magic = new byte[MAGIC_SIZE];
            Data = new byte[DATA_SIZE];

            Array.Copy(SaveData, 0, Magic, 0, MAGIC_SIZE);
            Array.Copy(SaveData, DATA_OFFSET, Data, 0, DATA_SIZE);
            Result = 1;
        }

        private byte[] CalculateNewChecksum()
        {
            using (SHA256 _SHA256 = SHA256.Create())
            {
                byte[] NewHash = _SHA256.ComputeHash(Data, 0, DATA_SIZE);
                byte[] FlippedHash = new byte[32];

                for (int i = 0; i < HASH_SIZE; i++)
                {
                    FlippedHash[i] = (byte)(NewHash[31 - i] ^ 255);
                }

                return FlippedHash;
            }
        }

        public void UpdateOffset_Byte(int Offset, byte Value)
        {
            Data[Offset] = Value;
        }

        public void UpdateOffset_UInt16(int Offset, ushort Value)
        {
            byte[] UpdatedInt16 = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedInt16[0];
            Data[Offset + 1] = UpdatedInt16[1];
        }

        public void UpdateOffset_Int32(int Offset, int Value)
        {
            byte[] UpdatedInt32 = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedInt32[0];
            Data[Offset + 1] = UpdatedInt32[1];
            Data[Offset + 2] = UpdatedInt32[2];
            Data[Offset + 3] = UpdatedInt32[3];
        }

        public byte RetrieveOffset_Byte(int Offset)
        {
            return Data[Offset];
        }

        public ushort RetrieveOffset_UInt16(int Offset)
        {
            return BitConverter.ToUInt16(Data, Offset);
        }

        public int RetrieveOffset_Int32(int Offset)
        {
            return BitConverter.ToInt32(Data, Offset);
        }

        public float RetrieveOffset_Float(int Offset)
        {
            return BitConverter.ToSingle(Data, Offset);
        }

        public void DumpData(string FilePath)
        {
            File.WriteAllBytes(FilePath, Data);
        }

        public void ImportData(byte[] Import)
        {
            Data = Import;
        }

        public byte[] ToBytes()
        {
            using (MemoryStream Stream = new MemoryStream())
            {
                Stream.Write(Magic, 0, MAGIC_SIZE);
                Stream.Write(Checksum, 0, HASH_SIZE);
                Stream.Write(Data, 0, DATA_SIZE);
                return Stream.ToArray();
            }
        }
    }
}
