using Scramble.GameData;
using System.Collections.Generic;

namespace Scramble.Classes
{
    public class PartyMember
    {
        public int Id
        {
            get;
            private set;
        }

        public byte CharacterId
        {
            get;
            private set;
        }

        public string CharacterName
        {
            get
            {
                return CharacterTable.GetCharacterName(CharacterId);
            }
        }

        public Dictionary<byte, int> EquippedPinIndexes
        {
            get;
            private set;
        }

        public List<int> EquippedClothingIndexes
        {
            get;
            private set;
        }

        public PartyMember(int Id, byte CharacterId, Dictionary<byte, int> EquippedPinIndexes, List<int>EquippedClothingIndexes)
        {
            this.Id = Id;
            this.CharacterId = CharacterId;
            this.EquippedPinIndexes = EquippedPinIndexes;
            this.EquippedClothingIndexes = EquippedClothingIndexes;
        }
    }
}
