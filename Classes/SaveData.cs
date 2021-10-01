using Scramble.GameData;
using Scramble.Util;
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

        //Unused: public const int HASH_OFFSET = 5;
        public const int HASH_LENGTH = 32;

        public const int DATA_OFFSET = 37;
        public const int DATA_LENGTH = 319952;

        public const int NOT_ASSIGNED_DATA = -1;

        private Dictionary<int, PartyMember> PartyMembers;

        public byte CurrentDay
        {
            get;
            private set;
        }

        public byte FurthestDay
        {
            get;
            private set;
        }

        public byte IsValid;

        public bool IsValid_Boolean => IsValid != 0;

        public byte[] UnixTimestamp
        {
            get;
            private set;
        }

        public byte[] Data
        {
            get;
            private set;
        }

        public int UnixTimestamp_Integer => BitConverter.ToInt32(UnixTimestamp, 0);

        public byte[] Checksum => TwewyChecksum.CalculateChecksum(Data, 0);

        public SaveData(int Id, byte[] FullData)
        {
            this.Id = Id;

            UnixTimestamp = new byte[UNIX_LENGTH];
            Data = new byte[DATA_LENGTH];

            IsValid = FullData[VALID_OFFSET];
            Array.Copy(FullData, UNIX_OFFSET, UnixTimestamp, 0, UNIX_LENGTH);
            Array.Copy(FullData, DATA_OFFSET, Data, 0, DATA_LENGTH);

            LoadPartyMembers();
            RetrieveDayData();
        }

        #region Party Member methods
        public void LoadPartyMembers()
        {
            PartyMembers = new Dictionary<int, PartyMember>();

            for (int i = 0; i < 6; i++)
            {
                int OffsetSum = 36 * i;

                int MemberId = i + 1;
                int CharacterId = RetrieveOffset_Int32(GameOffsets.EquipPlayerID + OffsetSum);

                if (CharacterId != NOT_ASSIGNED_DATA)
                {
                    Dictionary<byte, int> EquippedPinIndexes = new Dictionary<byte, int>
                    {
                        { 1, RetrieveOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + OffsetSum) },
                        { 2, RetrieveOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + OffsetSum) },
                        { 3, RetrieveOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + OffsetSum) }
                    };

                    List<int> EquippedClothing = new List<int>
                    {
                        RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Head + OffsetSum),
                        RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Top + OffsetSum),
                        RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Bottom + OffsetSum),
                        RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Foot + OffsetSum),
                        RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Accessory + OffsetSum)
                    };

                    PartyMembers.Add(MemberId, new PartyMember(MemberId, (byte)CharacterId, i, EquippedPinIndexes, EquippedClothing));
                }
            }
        }

        public Dictionary<int, PartyMember> GetPartyMembers()
        {
            return PartyMembers;
        }

        public PartyMember GetPartyMemberByNameValue(string NameValue)
        {
            string NameKey = Program.Sukuranburu.GetReverseString(NameValue);

            foreach (PartyMember Member in PartyMembers.Values)
            {
                if (Member.CharacterName == NameKey)
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
        public string GetPartyMemberNameWithMemberId(int MemberId)
        {
            foreach (PartyMember Member in PartyMembers.Values)
            {
                if (Member.Id == MemberId)
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

        public PartyMember GetPartyMemberWithCharacterId(byte CharacterId)
        {
            foreach (PartyMember Member in PartyMembers.Values)
            {
                if (Member.CharacterId == CharacterId)
                {
                    return Member;
                }
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

                        if (!CollectedData.ContainsKey(DeckId))
                        {
                            CollectedData.Add(DeckId, (byte)Member.Id);
                        }
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

        public void UpdateOffset_Int16(int Offset, short Value)
        {
            byte[] UpdatedInt16 = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedInt16[0];
            Data[Offset + 1] = UpdatedInt16[1];
        }

        public void UpdateOffset_UInt16(int Offset, ushort Value)
        {
            byte[] UpdatedUInt16 = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedUInt16[0];
            Data[Offset + 1] = UpdatedUInt16[1];
        }

        public void UpdateOffset_Int32(int Offset, int Value)
        {
            byte[] UpdatedInt32 = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedInt32[0];
            Data[Offset + 1] = UpdatedInt32[1];
            Data[Offset + 2] = UpdatedInt32[2];
            Data[Offset + 3] = UpdatedInt32[3];
        }

        public void UpdateOffset_UInt32(int Offset, uint Value)
        {
            byte[] UpdatedUInt32 = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedUInt32[0];
            Data[Offset + 1] = UpdatedUInt32[1];
            Data[Offset + 2] = UpdatedUInt32[2];
            Data[Offset + 3] = UpdatedUInt32[3];
        }

        public void UpdateOffset_Float(int Offset, float Value)
        {
            byte[] UpdatedFloat = BitConverter.GetBytes(Value);
            Data[Offset] = UpdatedFloat[0];
            Data[Offset + 1] = UpdatedFloat[1];
            Data[Offset + 2] = UpdatedFloat[2];
            Data[Offset + 3] = UpdatedFloat[3];
        }

        public void FillOffset_Int32(int Offset, int Length, byte Value)
        {
            for (int i = 0; i < Length; i++)
            {
                Data[Offset + i] = Value;
            }
        }

        public byte RetrieveOffset_Byte(int Offset)
        {
            return Data[Offset];
        }

        public ushort RetrieveOffset_UInt16(int Offset)
        {
            return BitConverter.ToUInt16(Data, Offset);
        }

        public short RetrieveOffset_Int16(int Offset)
        {
            return BitConverter.ToInt16(Data, Offset);
        }

        public uint RetrieveOffset_UInt32(int Offset)
        {
            return BitConverter.ToUInt32(Data, Offset);
        }

        public int RetrieveOffset_Int32(int Offset)
        {
            return BitConverter.ToInt32(Data, Offset);
        }

        public float RetrieveOffset_Float(int Offset)
        {
            return BitConverter.ToSingle(Data, Offset);
        }

        public void WriteToStream(MemoryStream Stream, ref int CurrentPointer)
        {
            Stream.WriteByte(IsValid);
            CurrentPointer += VALID_LENGTH;

            Stream.Write(UnixTimestamp, 0, UNIX_LENGTH);
            CurrentPointer += UNIX_LENGTH;

            Stream.Write(Checksum, 0, HASH_LENGTH);
            CurrentPointer += HASH_LENGTH;

            Stream.Write(Data, 0, DATA_LENGTH);
            CurrentPointer += DATA_LENGTH;
        }

        public void RetrieveDayData()
        {
            CurrentDay = (byte)RetrieveOffset_Int32(GameOffsets.CurrentPlayDateDay);
            FurthestDay = (byte)RetrieveOffset_Int32(GameOffsets.ScenarioNewestDateDay);
        }

        public void DumpData(string FilePath)
        {
            File.WriteAllBytes(FilePath, Data);
        }

        public void ImportData(byte[] Import)
        {
            Data = Import;

            LoadPartyMembers();
            RetrieveDayData();
        }
    }
}
