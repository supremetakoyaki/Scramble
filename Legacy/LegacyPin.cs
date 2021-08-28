using FinalRemixDb;

namespace Scramble.Legacy
{
    public class LegacyPin
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
    }
}
