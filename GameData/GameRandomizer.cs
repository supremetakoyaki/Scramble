﻿using System;
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

        public string GetWaitingMessage()
        {
            int RandomNumber = GenerateRandomNumber(1, 7);

            switch (RandomNumber)
            {
                case 1:
                default:
                    return "Life is like a box of chocolates, chasing after another, you can't get enough of it~";

                case 2:
                    return "The rhythm's gonna set me free, hey baby, move your body, shake it on this battleground~";

                case 3:
                    return "Break the silence, regain yourself! We're losing you! We're losing you!";

                case 4:
                    return "Oh, take a look at me. I know I'm not the perfect boy you want me to be~";

                case 5:
                    return "Here we are at the busiest city in the world. What would you do to make yourself stand out?~";

                case 6:
                    return "When things feel black and white, maybe we can do some coloring~";

                case 7:
                    return "Who's the enemy?! Who's the enemy?! Who's the enemy?! Plug me innnnnnnn~";
            }
        }

        public void RandomizeMoney(RandomizerChaos LevelOfChaos)
        {
            // Function also randomizes FP and difficulty.

            int MoneyToSet;
            int FpToSet;
            int DifficultyToSet;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    DifficultyToSet = GenerateRandomNumber(0, 2);
                    MoneyToSet = GenerateRandomNumber(0, 99999);
                    FpToSet = GenerateRandomNumber(0, 8);
                    break;

                case RandomizerChaos.Moderate:
                default:
                    DifficultyToSet = GenerateRandomNumber(0, 3);
                    MoneyToSet = GenerateRandomNumber(0, 999999);
                    FpToSet = GenerateRandomNumber(0, 30);
                    break;

                case RandomizerChaos.Heavy:
                    DifficultyToSet = GenerateRandomNumber(0, 3);
                    MoneyToSet = GenerateRandomNumber(0, 9999999);
                    FpToSet = GenerateRandomNumber(0, 100);
                    break;
            }

            Sukuranburu.SetMoney(MoneyToSet);
            Sukuranburu.SetFp(FpToSet);
            Sukuranburu.SetDifficulty(DifficultyToSet);
        }

        public void RandomizeExperience(RandomizerChaos LevelOfChaos)
        {
            int ExperienceToSet;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    ExperienceToSet = GenerateRandomNumber(0, 32000);
                    break;

                case RandomizerChaos.Moderate:
                default:
                    ExperienceToSet = GenerateRandomNumber(0, 287500);
                    break;

                case RandomizerChaos.Heavy:
                    ExperienceToSet = GenerateRandomNumber(0, 961500);
                    break;
            }

            Sukuranburu.SetExperience(ExperienceToSet);
        }

        public void RandomizeDay(RandomizerChaos LevelOfChaos)
        {
            int FurthestDayToSet;
            int CurrentDayToSet = SelectedSlot.CurrentDay;

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
            int PinsToAdd;
            bool IncludeUberPins;
            bool UnlimitedAttack;
            bool RepeatEquippedInputButton;
            bool RandomPinExpAndLevel;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    PinsToAdd = GenerateRandomNumber(3, 50);
                    IncludeUberPins = false;
                    UnlimitedAttack = false;
                    RepeatEquippedInputButton = false;
                    RandomPinExpAndLevel = false;
                    break;

                case RandomizerChaos.Moderate:
                default:
                    PinsToAdd = GenerateRandomNumber(5, 300);
                    IncludeUberPins = true;
                    UnlimitedAttack = false;
                    RepeatEquippedInputButton = false;
                    RandomPinExpAndLevel = false;
                    break;

                case RandomizerChaos.Heavy:
                    PinsToAdd = GenerateRandomNumber(7, 1500);
                    IncludeUberPins = true;
                    UnlimitedAttack = true;
                    RepeatEquippedInputButton = true;
                    RandomPinExpAndLevel = true;
                    break;
            }

            // TODO: set active deck to 1.

            // Clear everyone's pins
            int i;
            for (i = 0; i < 6; i++)
            {
                int OffsetSum = 36 * i;
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck1 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck2 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck3 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            }

            // Generate the dictionary of pins we'll add based on save index. 
            Dictionary<int, PinItem> Pins = new Dictionary<int, PinItem>();
            var TotalEquippablePins = Sukuranburu.GetItemManager().GetItems().Values.OfType<PinItem>().Where(p => p.LevelUpType != 6);
            var AllPins = Sukuranburu.GetItemManager().GetItems().Values.OfType<PinItem>();

            if (!IncludeUberPins)
            {
                TotalEquippablePins = TotalEquippablePins.Where(p => p.PinClass != 5);
                AllPins = AllPins.Where(p => p.PinClass != 5);
            }

            if (!UnlimitedAttack)
            {
                TotalEquippablePins = TotalEquippablePins.Where(p => p.AtkBoost < 751);
                AllPins = AllPins.Where(p => p.AtkBoost < 751);
            }

            // Assign a random battle pin to every party member first. This way, the game won't crash.
            int CurrentPointer = Offsets.PinInv_First;
            for (i = 0; i < SelectedSlot.GetPartyMembers().Count; i++)
            {
                PinItem NextPinItem = TotalEquippablePins.ElementAt(GenerateRandomNumber(0, TotalEquippablePins.Count() - 1));
                bool ValidInputKey = RepeatEquippedInputButton ? true : (NextPinItem != null && Pins.Values.FirstOrDefault(p => p.InputKey == NextPinItem.InputKey) == null);

                while (NextPinItem == null || !ValidInputKey)
                {
                    NextPinItem = TotalEquippablePins.ElementAt(GenerateRandomNumber(0, TotalEquippablePins.Count() - 1));
                    ValidInputKey = RepeatEquippedInputButton ? true : (NextPinItem != null && Pins.Values.FirstOrDefault(p => p.InputKey == NextPinItem.InputKey) == null);
                }

                Pins.Add(i, NextPinItem);

                int OffsetSum = 36 * (SelectedSlot.GetPartyMembers().Values.ToList()[i].Id - 1);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck1 + OffsetSum, i);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck2 + OffsetSum, i);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck3 + OffsetSum, i);

                SelectedSlot.UpdateOffset_UInt16(CurrentPointer, NextPinItem.ParticularId);

                if (RandomPinExpAndLevel)
                {
                    uint RandomExperienceAmount = GenerateRandomPinExperience(NextPinItem);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, Sukuranburu.GetItemManager().GetPinLevelWithPinIdAndExperience(NextPinItem.ParticularId, RandomExperienceAmount));
                    SelectedSlot.UpdateOffset_UInt32(CurrentPointer + 4, RandomExperienceAmount);
                }
                else
                {
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, 1);
                    SelectedSlot.UpdateOffset_UInt32(CurrentPointer + 4, 0);
                }

                CurrentPointer += 8;
            }

            // Now, fill in the rest.
            for (int Index = i; Index < PinsToAdd; Index++)
            {
                PinItem NextPinItem = AllPins.ElementAt(GenerateRandomNumber(0, AllPins.Count() - 1));
                while (NextPinItem == null)
                {
                    NextPinItem = AllPins.ElementAt(GenerateRandomNumber(0, AllPins.Count() - 1));
                }

                Pins.Add(Index, NextPinItem);

                SelectedSlot.UpdateOffset_UInt16(CurrentPointer, NextPinItem.ParticularId);

                if (RandomPinExpAndLevel)
                {
                    uint RandomExperienceAmount = GenerateRandomPinExperience(NextPinItem);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, Sukuranburu.GetItemManager().GetPinLevelWithPinIdAndExperience(NextPinItem.ParticularId, RandomExperienceAmount));
                    SelectedSlot.UpdateOffset_UInt32(CurrentPointer + 4, RandomExperienceAmount);
                }
                else
                {
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, 1);
                    SelectedSlot.UpdateOffset_UInt32(CurrentPointer + 4, 0);
                }

                CurrentPointer += 8;
            }

            // Update counts
            SelectedSlot.UpdateOffset_Int32(Offsets.PinInv_Count, PinsToAdd);
            SelectedSlot.UpdateOffset_Int32(Offsets.PinInv_CountOfIndexes, PinsToAdd - 1);

            // Fill in the blanks
            for (i = CurrentPointer; i < Offsets.PinInv_VeryLast; i += 8)
            {
                SelectedSlot.UpdateOffset_UInt16(i, PinInventoryEditor.EMPTY_PIN_ID);
                SelectedSlot.UpdateOffset_UInt16(i + 2, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 4, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 6, 0);
            }
        }

        public uint GenerateRandomPinExperience(PinItem Pin)
        {
            uint MaxExperience = Sukuranburu.GetItemManager().GetPinExperienceWithPinIdAndLevel(Pin.ParticularId, Pin.MaxLevel);

            return (uint)GenerateRandomNumber(0, (int)MaxExperience);
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
