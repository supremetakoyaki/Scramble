using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace Scramble.Classes
{
    public class SaveData
    {
        public int Id;

        public const int VALID_OFFSET = 0;
        public const int VALID_LENGTH = 1;

        public const int UNIX_OFFSET = 1;
        public const int UNIX_LENGTH = 4;

        public const int HASH_OFFSET = 5;
        public const int HASH_LENGTH = 32;

        public const int DATA_OFFSET = 37;
        public const int DATA_LENGTH = 319952;

        public byte IsValid;

        public bool IsValid_Boolean
        {
            get
            {
                return IsValid >= (byte)1;
            }
        }

        public byte[] UnixTimestamp
        {
            get;
            private set;
        }

        private byte[] Hash;

        public byte[] Data
        {
            get;
            private set;
        }

        public int UnixTimestamp_Integer
        {
            get
            {
                return BitConverter.ToInt32(UnixTimestamp);
            }
        }

        public byte[] Hash_Valid
        {
            get
            {
                return CalculateNewChecksum();
            }
        }

        public bool UnknownFlag
        {
            get;
            private set;
        }

        public SaveData(int Id, byte[] FullData)
        {
            this.Id = Id;

            UnixTimestamp = new byte[UNIX_LENGTH];
            Hash = new byte[HASH_LENGTH];
            Data = new byte[DATA_LENGTH];

            IsValid = FullData[VALID_OFFSET];
            Array.Copy(FullData, UNIX_OFFSET, UnixTimestamp, 0, UNIX_LENGTH);
            Array.Copy(FullData, HASH_OFFSET, Hash, 0, HASH_LENGTH);
            Array.Copy(FullData, DATA_OFFSET, Data, 0, DATA_LENGTH);
        }
        public void UpdateUnix(DateTime Date)
        {
            int Timestamp = Convert.ToInt32(((DateTimeOffset)Date).ToUnixTimeSeconds());
            UnixTimestamp = BitConverter.GetBytes(Timestamp);
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

        public void WriteToStream(MemoryStream Stream, ref int CurrentPointer)
        {
            Stream.WriteByte(IsValid);
            CurrentPointer += VALID_LENGTH;

            Stream.Write(UnixTimestamp, 0, UNIX_LENGTH);
            CurrentPointer += UNIX_LENGTH;

            Stream.Write(Hash_Valid, 0, HASH_LENGTH);
            CurrentPointer += HASH_LENGTH;

            Stream.Write(Data, 0, DATA_LENGTH);
            CurrentPointer += DATA_LENGTH;
        }

        private byte[] CalculateNewChecksum()
        {
            using (SHA256 _SHA256 = SHA256.Create())
            {
                byte[] NewHash = _SHA256.ComputeHash(Data, 0, DATA_LENGTH);
                byte[] FlippedHash = new byte[32];

                for (int i = 0; i < HASH_LENGTH; i++)
                {
                    FlippedHash[i] = (byte)(NewHash[31 - i] ^ (byte)255);
                }

                return FlippedHash;
            }
        }
        public void DumpData(string FilePath)
        {
            File.WriteAllBytes(FilePath, Data);
        }
        public void ImportData(byte[] Import)
        {
            this.Data = Import; // the fact that it's so straight-forward seems a bit suspicious.
        }
    }
}
