using FinalRemixDb;
using System;

namespace Scramble.Legacy
{
    public class LegacyPin : IEquatable<LegacyPin>
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

        public LegacyPin(ushort id, ushort saveIndex, ushort level, ushort amount, int experience, bool mastered)
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
            return Equals(obj as LegacyPin);
        }

        public bool Equals(LegacyPin other)
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
