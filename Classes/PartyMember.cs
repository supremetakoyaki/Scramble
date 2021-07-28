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
                return Program.Sukuranburu.GetCharacterManager().GetCharacterName(CharacterId);
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

        public bool IsEquippingPin(int PinIndex, out List<byte> DecksWithPin)
        {
            DecksWithPin = null;

            if (PinIndex == -1)
            {
                return false;
            }

            bool ListMade = false;

            for (byte Deck = 1; Deck < 4; Deck++)
            {
                if (EquippedPinIndexes[Deck] == PinIndex)
                {
                    if (ListMade == false)
                    {
                        DecksWithPin = new List<byte>();
                        ListMade = true;
                    }

                    DecksWithPin.Add(Deck);
                }
            }

            return ListMade;
        }
    }
}
