using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Windows.Forms;

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

        #region Party Member methods
        public void LoadPartyMembers()
        {
            this.PartyMembers = new Dictionary<int, PartyMember>();

            for (int i = 0; i < 6; i++)
            {
                int OffsetSum = 36 * i;

                int MemberId = i + 1;
                int CharacterId = RetrieveOffset_Int32(Offsets.PartyMember1_CharacterId + OffsetSum);

                if (CharacterId != NOT_ASSIGNED_DATA)
                {
                    Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>();
                    EquippedPinIndexes.Add(1, RetrieveOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck1 + OffsetSum));
                    EquippedPinIndexes.Add(2, RetrieveOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck2 + OffsetSum));
                    EquippedPinIndexes.Add(3, RetrieveOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck3 + OffsetSum));

                    List<int> EquippedClothing = new List<int>();
                    EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedHeadwearIndex + OffsetSum));
                    EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedTopIndex + OffsetSum));
                    EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedBottomIndex + OffsetSum));
                    EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedShoesIndex + OffsetSum));
                    EquippedClothing.Add(RetrieveOffset_Int32(Offsets.PartyMember1_EquippedAccessoryIndex + OffsetSum));

                    PartyMembers.Add(MemberId, new PartyMember(MemberId, (byte)CharacterId, EquippedPinIndexes, EquippedClothing));
                }
            }
        }

        public Dictionary<int, PartyMember> GetPartyMembers()
        {
            return this.PartyMembers;
        }

        public PartyMember GetPartyMemberByName(string Name)
        {
            foreach (PartyMember Member in PartyMembers.Values)
            {
                if (Member.CharacterName == Name)
                {
                    return Member;
                }
            }

            return null;
        }

        /// <summary>
        /// NOT character id!
        /// </summary>
        /// <param name="Id">Member ID</param>
        /// <returns></returns>
        public string GetPartyMemberNameWithMemberId(int Id)
        {
            foreach (PartyMember Member in PartyMembers.Values)
            {
                if (Member.Id == Id)
                {
                    return Member.CharacterName;
                }
            }

            return "Unknown"; // ?
        }

        public PartyMember GetPartyMemberWithId(int Id)
        {
            if (PartyMembers.ContainsKey(Id))
            {
                return PartyMembers[Id];
            }

            return null;
        }

        public Dictionary<byte, byte> WhosEquippingThisPin(int PinIndex)
        {
            Dictionary<byte, byte> CollectedData = null;
            bool DicMade = false;

            foreach (PartyMember Member in PartyMembers.Values)
            {
                for (byte DeckId = 1; DeckId < 4; DeckId++)
                {
                    int PinInThisDeck = Member.EquippedPinIndexes[DeckId];

                    if (PinInThisDeck != NOT_ASSIGNED_DATA && PinInThisDeck == PinIndex)
                    {
                        if (!DicMade)
                        {
                            CollectedData = new Dictionary<byte, byte>();
                            DicMade = true;
                        }

                        CollectedData.Add(DeckId, (byte)Member.Id);
                    }
                }
            }

            return CollectedData;
        }
        #endregion

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
