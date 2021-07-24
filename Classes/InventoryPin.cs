using System;

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

        public InventoryPin(ushort PinId, ushort Level, ushort Experience)
        {
            this.PinId = PinId;
            this.Level = Level;
            this.Experience = Experience;
            this.Amount = 1;
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
