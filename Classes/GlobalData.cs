using System;
using System.IO;
using System.Security.Cryptography;

namespace Scramble.Classes
{
    public class GlobalData
    {
        private const int MAGIC_OFFSET = 0;
        private const int MAGIC_LENGTH = 32;

        private const int HASH_LENGTH = 32;

        private const int GLOBAL_OFFSET = 64;
        private const int GLOBAL_LENGTH = 555;

        private readonly byte[] Magic;

        private byte[] Hash_Valid => CalculateNewChecksum();

        private byte[] Data
        {
            get;
            set;
        }

        public GlobalData(byte[] FirstData)
        {
            Magic = new byte[MAGIC_LENGTH];
            Data = new byte[GLOBAL_LENGTH];

            Array.Copy(FirstData, 0, Magic, 0, MAGIC_LENGTH);
            Array.Copy(FirstData, GLOBAL_OFFSET, Data, 0, GLOBAL_LENGTH);
        }

        private byte[] CalculateNewChecksum()
        {
            using (SHA256 _SHA256 = SHA256.Create())
            {
                byte[] NewHash = _SHA256.ComputeHash(Data, 0, GLOBAL_LENGTH);
                byte[] FlippedHash = new byte[32];

                for (int i = 0; i < HASH_LENGTH; i++)
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

        public void UpdateOffset_Float(int Offset, float Value)
        {
            byte[] UpdatedFloat = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedFloat[0];
            Data[Offset + 1] = UpdatedFloat[1];
            Data[Offset + 2] = UpdatedFloat[2];
            Data[Offset + 3] = UpdatedFloat[3];
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

        public byte[] ToBytes()
        {
            MemoryStream Stream = new MemoryStream();
            Stream.Write(Magic, 0, MAGIC_LENGTH);
            Stream.Write(Hash_Valid, 0, HASH_LENGTH);
            Stream.Write(Data, 0, GLOBAL_LENGTH);
            return Stream.ToArray();
        }
    }
}


