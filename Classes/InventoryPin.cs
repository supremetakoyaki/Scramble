﻿using NTwewyDb;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        public uint Experience
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

        public PinItem BasePin => Program.Sukuranburu.GetItemManager().GetPinItem(PinId);

        public InventoryPin(ushort PinId, ushort Level, uint Experience)
        {
            this.PinId = PinId;
            this.Level = Level;
            this.Experience = Experience;
            Amount = 1;
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
                if (DecksWithThisPin.ContainsKey(DeckId))
                {
                    MessageBox.Show(string.Format("There's a duplicate of pin #{0} in Deck {1}. While this is valid in-game, the editor does not support it at the moment. Equip a different pin to this character in the editor: {2}", PinId, DeckId, EquippingData[DeckId]), "Developer's note");
                }
                else
                {
                    DecksWithThisPin.Add(DeckId, EquippingData[DeckId]);
                }
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
