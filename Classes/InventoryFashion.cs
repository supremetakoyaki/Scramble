using NTwewyDb;
using System;

namespace Scramble.Classes
{
    public class InventoryFashion
    {
        public ushort Id
        {
            get;
            set;
        }

        public ushort Amount
        {
            get;
            set;
        }

        public byte EquipperId // Party Member ID
        {
            get;
            set;
        }

        public ClothingItem BaseClothing
        {
            get
            {
                return Program.Sukuranburu.GetItemManager().GetClothingItem(Id);
            }
        }

        public InventoryFashion(ushort Id)
        {
            this.Id = Id;
        }

        public byte WhosEquippingThis(int Index)
        {
            foreach (PartyMember Member in Program.Sukuranburu.SelectedSlot.GetPartyMembers().Values)
            {
                if (Member.EquippedClothingIndexes.Contains(Index))
                {
                    return (byte)Member.Id;
                }
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            return obj is InventoryFashion fashion &&
                   Id == fashion.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
