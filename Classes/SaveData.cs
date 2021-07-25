using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

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

        public const int NOT_ASSIGNED_DATA = -1;

        private Dictionary<int, PartyMember> PartyMembers;


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

            LoadPartyMembers();
        }
        public void LoadPartyMembers()
        {
            this.PartyMembers = new Dictionary<int, PartyMember>();

            #region This looks so hardcoded but in reality it isn't (or maybe it is). But I want to think it's just ugly.
            
            int PartyMember1_CharacterId = RetrieveOffset_Int32(Offsets.PartyMember1_CharacterId);
            int PartyMember2_CharacterId = RetrieveOffset_Int32(Offsets.PartyMember2_CharacterId);
            int PartyMember3_CharacterId = RetrieveOffset_Int32(Offsets.PartyMember3_CharacterId);
            int PartyMember4_CharacterId = RetrieveOffset_Int32(Offsets.PartyMember4_CharacterId);
            int PartyMember5_CharacterId = RetrieveOffset_Int32(Offsets.PartyMember5_CharacterId);
            int PartyMember6_CharacterId = RetrieveOffset_Int32(Offsets.PartyMember6_CharacterId);

            if (PartyMember1_CharacterId != NOT_ASSIGNED_DATA)
            {
                Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>();
                EquippedPinIndexes.Add(1, RetrieveOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck1));
                EquippedPinIndexes.Add(2, RetrieveOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck2));
                EquippedPinIndexes.Add(3, RetrieveOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck3));

                List<int> EquippedClothing = new List<int>();
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedHeadwearIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedTopIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedBottomIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedShoesIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedAccessoryIndex));

                PartyMembers.Add(1, new PartyMember(1, (byte)PartyMember1_CharacterId, EquippedPinIndexes, EquippedClothing));
            }

            if (PartyMember2_CharacterId != NOT_ASSIGNED_DATA)
            {
                Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>();
                EquippedPinIndexes.Add(1, RetrieveOffset_Int32(Offsets.PartyMember2_EquippedPinIndex_Deck1));
                EquippedPinIndexes.Add(2, RetrieveOffset_Int32(Offsets.PartyMember2_EquippedPinIndex_Deck2));
                EquippedPinIndexes.Add(3, RetrieveOffset_Int32(Offsets.PartyMember2_EquippedPinIndex_Deck3));

                List<int> EquippedClothing = new List<int>();
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember2_EquippedHeadwearIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember2_EquippedTopIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember2_EquippedBottomIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember2_EquippedShoesIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember2_EquippedAccessoryIndex));

                PartyMembers.Add(2, new PartyMember(2, (byte)PartyMember2_CharacterId, EquippedPinIndexes, EquippedClothing));
            }

            if (PartyMember3_CharacterId != NOT_ASSIGNED_DATA)
            {
                Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>();
                EquippedPinIndexes.Add(1, RetrieveOffset_Int32(Offsets.PartyMember3_EquippedPinIndex_Deck1));
                EquippedPinIndexes.Add(2, RetrieveOffset_Int32(Offsets.PartyMember3_EquippedPinIndex_Deck2));
                EquippedPinIndexes.Add(3, RetrieveOffset_Int32(Offsets.PartyMember3_EquippedPinIndex_Deck3));

                List<int> EquippedClothing = new List<int>();
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember3_EquippedHeadwearIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember3_EquippedTopIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember3_EquippedBottomIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember3_EquippedShoesIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember3_EquippedAccessoryIndex));

                PartyMembers.Add(3, new PartyMember(3, (byte)PartyMember3_CharacterId, EquippedPinIndexes, EquippedClothing));
            }

            if (PartyMember4_CharacterId != NOT_ASSIGNED_DATA)
            {
                Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>();
                EquippedPinIndexes.Add(1, RetrieveOffset_Int32(Offsets.PartyMember4_EquippedPinIndex_Deck1));
                EquippedPinIndexes.Add(2, RetrieveOffset_Int32(Offsets.PartyMember4_EquippedPinIndex_Deck2));
                EquippedPinIndexes.Add(3, RetrieveOffset_Int32(Offsets.PartyMember4_EquippedPinIndex_Deck3));

                List<int> EquippedClothing = new List<int>();
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember4_EquippedHeadwearIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember4_EquippedTopIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember4_EquippedBottomIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember4_EquippedShoesIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember4_EquippedAccessoryIndex));

                PartyMembers.Add(4, new PartyMember(4, (byte)PartyMember4_CharacterId, EquippedPinIndexes, EquippedClothing));
            }

            if (PartyMember5_CharacterId != NOT_ASSIGNED_DATA)
            {
                Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>();
                EquippedPinIndexes.Add(1, RetrieveOffset_Int32(Offsets.PartyMember5_EquippedPinIndex_Deck1));
                EquippedPinIndexes.Add(2, RetrieveOffset_Int32(Offsets.PartyMember5_EquippedPinIndex_Deck2));
                EquippedPinIndexes.Add(3, RetrieveOffset_Int32(Offsets.PartyMember5_EquippedPinIndex_Deck3));

                List<int> EquippedClothing = new List<int>();
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember5_EquippedHeadwearIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember5_EquippedTopIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember5_EquippedBottomIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember5_EquippedShoesIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember5_EquippedAccessoryIndex));

                PartyMembers.Add(5, new PartyMember(5, (byte)PartyMember5_CharacterId, EquippedPinIndexes, EquippedClothing));
            }

            if (PartyMember6_CharacterId != NOT_ASSIGNED_DATA)
            {
                Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>();
                EquippedPinIndexes.Add(1, RetrieveOffset_Int32(Offsets.PartyMember6_EquippedPinIndex_Deck1));
                EquippedPinIndexes.Add(2, RetrieveOffset_Int32(Offsets.PartyMember6_EquippedPinIndex_Deck2));
                EquippedPinIndexes.Add(3, RetrieveOffset_Int32(Offsets.PartyMember6_EquippedPinIndex_Deck3));

                List<int> EquippedClothing = new List<int>();
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember6_EquippedHeadwearIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember6_EquippedTopIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember6_EquippedBottomIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember6_EquippedShoesIndex));
                EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember6_EquippedAccessoryIndex));

                PartyMembers.Add(6, new PartyMember(6, (byte)PartyMember6_CharacterId, EquippedPinIndexes, EquippedClothing));
            }
            #endregion
        }
        public Dictionary<int, PartyMember> GetPartyMembers()
        {
            return this.PartyMembers;
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
