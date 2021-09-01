using NTwewyDb;
using System;

namespace Scramble.Classes
{
    public class InventoryFashion : IEquatable<InventoryFashion>
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

        public ClothingItem BaseClothing => Program.Sukuranburu.GetItemManager().GetClothingItem(Id);

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
            return Equals(obj as InventoryFashion);
        }

        public bool Equals(InventoryFashion other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
