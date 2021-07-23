using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scramble.Classes
{
    public class SaveData
    {
        public int Id; // 0 = autosave

        private const int UNIX_OFFSET = 0;
        private const int UNIX_LENGTH = 4;

        private const int HASH_OFFSET = 4;
        private const int HASH_LENGTH = 32;

        private const int DATA_OFFSET = 36;
        private const int DATA_LENGTH = 319952;

        private const int UNKNOWN_FLAG_OFFSET = 319953;

        private byte[] UnixTimestamp;

        public byte[] Hash
        {
            get;
            private set;
        }

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

            Array.Copy(FullData, UNIX_OFFSET, UnixTimestamp, 0, UNIX_LENGTH);
            Array.Copy(FullData, HASH_OFFSET, Hash, 0, HASH_LENGTH);
            Array.Copy(FullData, DATA_OFFSET, Data, 0, DATA_LENGTH);

            UnknownFlag = BitConverter.ToBoolean(FullData, UNKNOWN_FLAG_OFFSET);

            File.WriteAllBytes("slot" + Id + ".txt", Data);
        }

        public bool ChecksumValid()
        {
            return Hash == Hash_Valid;
        }

        public void FixHash()
        {
            Hash = Hash_Valid;
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
    }
}
