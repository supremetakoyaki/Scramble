using FinalRemixDb;
using System;

namespace Scramble.Legacy
{
    public class LegacyInventoryPin : IEquatable<LegacyInventoryPin>
    {
        public ushort Id
        {
            get;
            set;
        }

        public ushort SaveIndex
        {
            get;
            set;
        }

        public ushort Level
        {
            get;
            set;
        }

        public ushort Amount //??
        {
            get;
            set;
        }

        public int Experience
        {
            get;
            set;
        }

        public bool Mastered
        {
            get;
            set;
        }

        public TwewyPin BasePin => Program.Legacy.GetTwewyManager().GetPin(Id);

        public LegacyInventoryPin(ushort id, ushort saveIndex, ushort level, ushort amount, int experience, bool mastered)
        {
            Id = id;
            SaveIndex = saveIndex;
            Level = level;
            Amount = amount;
            Experience = experience;
            Mastered = mastered;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LegacyInventoryPin);
        }

        public bool Equals(LegacyInventoryPin other)
        {
            return other != null &&
                   Id == other.Id &&
                   SaveIndex == other.SaveIndex;
        }

        public override int GetHashCode()
        {
            int hashCode = 504641284;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + SaveIndex.GetHashCode();
            return hashCode;
        }
    }
}
