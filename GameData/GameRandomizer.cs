using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
using NTwewyDb;
using Scramble.Forms;
using Scramble.Classes;
using System.Windows.Forms;

namespace Scramble.GameData
{
    public class GameRandomizer
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private RNGCryptoServiceProvider RngProvider;
        private byte[] RngBuffer;

        public GameRandomizer()
        {
            RngProvider = new RNGCryptoServiceProvider();
            RngBuffer = new byte[4];
        }

        public void RandomizeDay(RandomizerChaos LevelOfChaos)
        {
            int CurrentDayToSet = SelectedSlot.CurrentDay;
            int FurthestDayToSet = SelectedSlot.FurthestDay;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    FurthestDayToSet = GenerateRandomNumber(CurrentDayToSet, 24);
                    break;

                case RandomizerChaos.Moderate:
                default:
                    FurthestDayToSet = GenerateRandomNumber(0, 24);
                    CurrentDayToSet = FurthestDayToSet;
                    break;

                case RandomizerChaos.Heavy:
                    FurthestDayToSet = GenerateRandomNumber(0, 24);
                    CurrentDayToSet = GenerateRandomNumber(0, 24);
                    break;
            }

            SelectedSlot.UpdateOffset_Int32(Offsets.CurrentDay, CurrentDayToSet);
            SelectedSlot.UpdateOffset_Int32(Offsets.MaxDay, FurthestDayToSet);
        }

        public void RandomizeParty(RandomizerChaos LevelOfChaos)
        {
            int PartyMemberCount;
            bool ForceRindo;
            bool IncludeLateGameCharacters;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    PartyMemberCount = GenerateRandomNumber(1, 3);
                    ForceRindo = true;
                    IncludeLateGameCharacters = false;
                    break;

                case RandomizerChaos.Moderate:
                default:
                    PartyMemberCount = GenerateRandomNumber(1, 5);
                    ForceRindo = true;
                    IncludeLateGameCharacters = true;
                    break;

                case RandomizerChaos.Heavy:
                    PartyMemberCount = GenerateRandomNumber(1, 6);
                    ForceRindo = false;
                    IncludeLateGameCharacters = true;
                    break;
            }

            // In this generator, IDs will be different than in-game for convenience. They will later be adjusted.
            // 1 = Rindo
            // 2 = Fret
            // 3 = Minamimoto
            // 4 = Nagi
            // 5 = Beat
            // 6 = Shoka
            // 7 = Neku

            List<int> PartyMembers = new List<int>();
            if (ForceRindo)
            {
                PartyMembers.Add(1);
            }

            for (int i = 0; i < PartyMemberCount; i++)
            {
                int NextPartyMember = IncludeLateGameCharacters ? GenerateRandomNumber(1, 7) : GenerateRandomNumber(1, 5);

                while (PartyMembers.Contains(NextPartyMember))
                {
                    NextPartyMember = IncludeLateGameCharacters ? GenerateRandomNumber(1, 7) : GenerateRandomNumber(1, 5);
                }

                PartyMembers.Add(NextPartyMember);
            }

            for (int i = 0; i < 6; i++)
            {
                int OffsetSum = 36 * i;

                if (PartyMembers.Count < i + 1)
                {
                    SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_CharacterId + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                }
                else
                {
                    int CharacterId = PartyMembers[i];
                    if (CharacterId == 2)
                    {
                        CharacterId = 3; // Fret
                    }
                    else if (CharacterId == 3)
                    {
                        CharacterId = 7; // Minamimoto
                    }
                    else if (CharacterId == 6)
                    {
                        CharacterId = 2; // Shoka
                    }
                    else if (CharacterId == 7)
                    {
                        CharacterId = 6; // Neku
                    }

                    SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_CharacterId + OffsetSum, CharacterId);
                }                
            }

            /*SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck1 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck2 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck3 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedHeadwearIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedTopIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedBottomIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedShoesIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedAccessoryIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);*/

            SelectedSlot.LoadPartyMembers();
            Sukuranburu.SerializePartyMembers();
        }

        public void RandomizePins(RandomizerChaos LevelOfChaos)
        {

        }

        public int GenerateRandomNumber(int MinValue, int MaxValue)
        {
            MaxValue += 1;

            if (MinValue > MaxValue)
                throw new ArgumentOutOfRangeException("MinValue");

            if (MinValue == MaxValue) return MinValue;

            long Difference = MaxValue - MinValue;
            while (true)
            {
                RngProvider.GetBytes(RngBuffer);
                uint Rand = BitConverter.ToUInt32(RngBuffer, 0);

                long Max = (1 + (long)uint.MaxValue);
                long Remainder = Max % Difference;
                if (Rand < Max - Remainder)
                {
                    return (int)(MinValue + (Rand % Difference));
                }
            }
        }

    }
}
