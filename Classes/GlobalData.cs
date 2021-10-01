using Scramble.Util;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Scramble.Classes
{
    public class GlobalData
    {
        private const int MAGIC_LENGTH = 32;

        private const int HASH_LENGTH = 32;

        private const int GLOBAL_OFFSET_PS4SW = 64;
        private const int GLOBAL_OFFSET_PC = 32;
        private const int GLOBAL_LENGTH_PS4SW = 555;
        private const int GLOBAL_LENGTH_PC = 1083;

        private readonly byte[] Magic;
        private readonly byte[] PcHash;
        public readonly bool IsPcVersion;

        private byte[] Checksum
        {
            get
            {
                if (IsPcVersion)
                {
                    return PcHash;
                }
                else
                {
                   return TwewyChecksum.CalculateChecksum(Data, 0);
                }
            }
        }

        private byte[] Data
        {
            get;
            set;
        }

        public GlobalData(byte[] FirstData, bool IsPcVer)
        {
            IsPcVersion = IsPcVer;

            if (IsPcVersion)
            {
                Data = new byte[GLOBAL_LENGTH_PC];
                PcHash = new byte[32];
                Array.Copy(FirstData, 0, PcHash, 0, 32);
                Array.Copy(FirstData, GLOBAL_OFFSET_PC, Data, 0, GLOBAL_LENGTH_PC);
            }
            else
            {
                Magic = new byte[MAGIC_LENGTH];
                Data = new byte[GLOBAL_LENGTH_PS4SW];
                Array.Copy(FirstData, 0, Magic, 0, MAGIC_LENGTH);
                Array.Copy(FirstData, GLOBAL_OFFSET_PS4SW, Data, 0, GLOBAL_LENGTH_PS4SW);
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

            if (IsPcVersion)
            {
                Stream.Write(Checksum, 0, HASH_LENGTH);
                Stream.Write(Data, 0, GLOBAL_LENGTH_PC);
            }
            else
            {
                Stream.Write(Magic, 0, MAGIC_LENGTH);
                Stream.Write(Checksum, 0, HASH_LENGTH);
                Stream.Write(Data, 0, GLOBAL_LENGTH_PS4SW);
            }
            return Stream.ToArray();
        }
    }
}


