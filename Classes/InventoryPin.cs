using System;
using System.Collections.Generic;

namespace Scramble.Classes
{
    public class InventoryPin
    {
        public ushort PinId
        {
            get;
            set;
        }

        public ushort Level
        {
            get;
            set;
        }

        public ushort Experience
        {
            get;
            set;
        }

        public ushort Amount
        {
            get;
            set;
        }

        public Dictionary<byte, byte> DecksWithThisPin //deckId, partyMemberId
        {
            get;
            set;
        }

        public InventoryPin(ushort PinId, ushort Level, ushort Experience)
        {
            this.PinId = PinId;
            this.Level = Level;
            this.Experience = Experience;
            this.Amount = 1;
        }

        public void IntersectEquippingData(Dictionary<byte, byte> EquippingData)
        {
            if (EquippingData == null)
            {
                return;
            }
            else if (DecksWithThisPin == null)
            {
                DecksWithThisPin = EquippingData;
                return;
            }

            foreach (byte DeckId in EquippingData.Keys)
            {
                DecksWithThisPin.Add(DeckId, EquippingData[DeckId]);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is InventoryPin pin &&
                   PinId == pin.PinId &&
                   Level == pin.Level &&
                   Experience == pin.Experience;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PinId, Level, Experience);
        }
    }
}
