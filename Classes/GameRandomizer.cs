using NTwewyDb;
using Scramble.Classes;
using Scramble.Forms;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Scramble.Classes
{
    public class GameRandomizer
    {
        public SaveSlot SelectedSlot => Program.Sukuranburu.SelectedSlot;
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private readonly RNGCryptoServiceProvider RngProvider;
        private readonly byte[] RngBuffer;

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

            SelectedSlot.UpdateOffset_Int32(GameOffsets.CurrentPlayDateDay, CurrentDayToSet);
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ScenarioNewestDateDay, FurthestDayToSet);
        }

        public void RandomizeStats(RandomizerChaos LevelOfChaos)
        {
            int MinNum;
            int MaxNum;
            ushort DropRateMax;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    MinNum = GenerateRandomNumber(0, 25);
                    MaxNum = GenerateRandomNumber(MinNum, 100);
                    DropRateMax = (ushort)GenerateRandomNumber(0, 4);
                    break;

                case RandomizerChaos.Moderate:
                default:
                    MinNum = GenerateRandomNumber(0, 100);
                    MaxNum = GenerateRandomNumber(MinNum, 300);
                    DropRateMax = (ushort)GenerateRandomNumber(0, 9);
                    break;

                case RandomizerChaos.Heavy:
                    MinNum = GenerateRandomNumber(0, 500);
                    MaxNum = GenerateRandomNumber(MinNum, 999);
                    DropRateMax = (ushort)GenerateRandomNumber(0, 19);
                    break;
            }

            for (int i = 0; i < 6; i++)
            {
                int OffsetSum = i * 20;

                SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerData_FoodHp + OffsetSum, GenerateRandomNumber(MinNum, MaxNum));
                SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerData_FoodAtk + OffsetSum, GenerateRandomNumber(MinNum, MaxNum));
                SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerData_FoodDef + OffsetSum, GenerateRandomNumber(MinNum, MaxNum));
                SelectedSlot.UpdateOffset_UInt16(GameOffsets.PlayerData_FoodSense + OffsetSum, (ushort)GenerateRandomNumber(MinNum, MaxNum));
                SelectedSlot.UpdateOffset_UInt16(GameOffsets.PlayerData_FoodDropRate + OffsetSum, (ushort)GenerateRandomNumber(0, DropRateMax));
            }
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
                    SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
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

                    SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + OffsetSum, CharacterId);
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
                SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
            }

            // Generate the dictionary of pins we'll add based on save index. 
            Dictionary<int, PinItem> Pins = new Dictionary<int, PinItem>();
            IEnumerable<PinItem> TotalEquippablePins = Sukuranburu.GetItemManager().GetItems().Values.OfType<PinItem>().Where(p => p.LevelUpType != 6);
            IEnumerable<PinItem> AllPins = Sukuranburu.GetItemManager().GetItems().Values.OfType<PinItem>();

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
            int CurrentPointer = GameOffsets.MyBadgeList;
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

                int OffsetSum = 36 * (SelectedSlot.GetPartyMembers().Values.ToList()[i].SaveIndex);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + OffsetSum, i);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + OffsetSum, i);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + OffsetSum, i);

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
            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEmptyIndex, PinsToAdd);
            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeLastUseIndex, PinsToAdd - 1);

            // Fill in the blanks
            for (i = CurrentPointer; i < GameOffsets.MyBadgeList_Last; i += 8)
            {
                SelectedSlot.UpdateOffset_UInt16(i, PinInventoryEditor.EMPTY_PIN_ID);
                SelectedSlot.UpdateOffset_UInt16(i + 2, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 4, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 6, 0);
            }

            SelectedSlot.LoadPartyMembers();
            Sukuranburu.SerializePartyMembers();
        }

        public void RandomizeClothing(RandomizerChaos LevelOfChaos)
        {
            int ClothingToAdd;
            bool UnlimitedAttack;
            bool TryAvoidDuplicates;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    ClothingToAdd = GenerateRandomNumber(0, 40);
                    UnlimitedAttack = false;
                    TryAvoidDuplicates = true;
                    break;

                case RandomizerChaos.Moderate:
                default:
                    ClothingToAdd = GenerateRandomNumber(0, 350);
                    UnlimitedAttack = false;
                    TryAvoidDuplicates = true;
                    break;

                case RandomizerChaos.Heavy:
                    ClothingToAdd = GenerateRandomNumber(0, 1000);
                    UnlimitedAttack = false;
                    TryAvoidDuplicates = false;
                    break;
            }

            // Clear all clothing data.
            for (int i = 0; i < 6; i++)
            {
                int OffsetSum = 36 * i;
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Head + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Top + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Bottom + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Foot + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Accessory + OffsetSum, SaveSlot.NOT_ASSIGNED_DATA);
            }

            for (int i = GameOffsets.MyCostumeList; i < GameOffsets.MyCostumeList_Last; i += 2)
            {
                SelectedSlot.UpdateOffset_UInt16(ClothingInventoryEditor.EMPTY_CLOTHING_ID, 0);
            }

            foreach (PartyMember Member in SelectedSlot.GetPartyMembers().Values)
            {
                for (int i = 0; i < 5; i++)
                {
                    Member.EquippedClothingIndexes[i] = -1;
                }
            }

            // Generate the clothing enumerable we'll use
            IEnumerable<ClothingItem> EquippableClothing = Sukuranburu.GetItemManager().GetItems().Values.OfType<ClothingItem>();
            if (!UnlimitedAttack)
            {
                EquippableClothing = EquippableClothing.Where(c => c.AtkBoost < 36);
            }

            // Add clothing
            Dictionary<int, ClothingItem> Clothing = new Dictionary<int, ClothingItem>();

            for (int i = 0; i < ClothingToAdd; i++)
            {
                ClothingItem NextClothingItem = null; //
                bool Valid = false;

                while (NextClothingItem == null || !Valid)
                {
                    NextClothingItem = EquippableClothing.ElementAt(GenerateRandomNumber(0, EquippableClothing.Count() - 1));
                    Valid = TryAvoidDuplicates ? Clothing.Values.Where(c => c == NextClothingItem).Count() < 4 : Clothing.Values.Where(c => c == NextClothingItem).Count() < 9;
                }

                Clothing.Add(i, NextClothingItem);
            }

            int CurrentPointer = GameOffsets.MyCostumeList;
            for (int i = 0; i < Clothing.Count; i++)
            {
                SelectedSlot.UpdateOffset_UInt16(CurrentPointer, (ushort)(Clothing[i].ParticularId + 1));
                CurrentPointer += 2;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.MyCostumeCount, Clothing.Count);
        }

        public void RandomizeSkills(RandomizerChaos LevelOfChaos)
        {
            bool LateGameSkills;
            int ChunkMin;
            int ChunkMax;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    ChunkMin = 0;
                    ChunkMax = 4;
                    LateGameSkills = false;
                    break;

                case RandomizerChaos.Moderate:
                default:
                    ChunkMin = 0;
                    ChunkMax = 7;
                    LateGameSkills = true;
                    break;

                case RandomizerChaos.Heavy:
                    ChunkMin = 0;
                    ChunkMax = 8;
                    LateGameSkills = true;
                    break;
            }

            ushort SkillId = 0;
            for (int i = 0; i < 16; i++)
            {
                byte Entry = 0;
                byte BitPosition = 0;
                byte CurrentFulfilledBits = 0;
                byte FulfillThisAmount = (byte)GenerateRandomNumber(ChunkMin, ChunkMax);

                for (ushort j = SkillId; j < SkillId + 8; j++)
                {
                    Skill NextSkill = Sukuranburu.GetSocialNetworkManager().GetSkill(j);
                    byte BitToSet = 0;

                    if (NextSkill != null && CurrentFulfilledBits < FulfillThisAmount)
                    {
                        BitToSet = (byte)GenerateRandomNumber(0, 1);

                        if (!LateGameSkills)
                        {
                            SkillTree TreeEntry = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItems().Values.FirstOrDefault(s => s.SkillId == j);
                            if (TreeEntry == null || TreeEntry.ConnectDay > 14)
                            {
                                BitToSet = 0;
                            }
                        }

                        CurrentFulfilledBits += BitToSet;
                    }

                    Entry = ByteUtil.SetBit(Entry, BitPosition, Convert.ToBoolean(BitToSet));
                    BitPosition += 1;
                }

                SelectedSlot.UpdateOffset_Byte(GameOffsets.SkillFlag + i, Entry);
                SkillId += 8;
            }
        }

        public void RandomizeSocialTree(RandomizerChaos LevelOfChaos)
        {
            int SocialTreesToAdd;
            bool LateGameConnections;
            bool AbsoluteMess;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    SocialTreesToAdd = GenerateRandomNumber(0, 25);
                    LateGameConnections = false;
                    AbsoluteMess = false;
                    break;

                case RandomizerChaos.Moderate:
                default:
                    SocialTreesToAdd = GenerateRandomNumber(0, 52);
                    LateGameConnections = true;
                    AbsoluteMess = false;
                    break;

                case RandomizerChaos.Heavy:
                    SocialTreesToAdd = GenerateRandomNumber(0, 98);
                    LateGameConnections = true;
                    AbsoluteMess = true;
                    break;
            }

            // Clear everything first
            for (int i = 0; i < 128; i++)
            {
                SelectedSlot.UpdateOffset_Byte(GameOffsets.SkillTreeFlags + i, 0);
            }

            IEnumerable<SkillTree> SocialTrees = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItems().Values.Where(p => p.SkillId > 0);

            if (!LateGameConnections)
            {
                SocialTrees = SocialTrees.Where(p => p.ConnectDay < 18);
            }

            List<int> SaveIndexes = new List<int>();
            SkillTree SocialTree = null;
            int Iterator = 0;
            while (Iterator < SocialTreesToAdd)
            {
                SocialTree = SocialTrees.ElementAt(GenerateRandomNumber(0, SocialTrees.Count() - 1));
                if (!SaveIndexes.Contains(SocialTree.SaveIndex))
                {
                    SaveIndexes.Add(SocialTree.SaveIndex);
                    Iterator += 1;
                }
            }

            foreach (int SaveIndex in SaveIndexes)
            {
                int Offset = GameOffsets.SkillTreeFlags + SaveIndex;
                byte ValueToSet = 0x80;

                if (GenerateRandomNumber(0, 188) > 25)
                {
                    ValueToSet = 0xC0;
                }
                else if (AbsoluteMess)
                {
                    ValueToSet = 0x40;
                }

                SelectedSlot.UpdateOffset_Byte(Offset, ValueToSet);
            }
        }

        public void RandomizeTrophies(RandomizerChaos LevelOfChaos)
        {
            int TrophiesToAdd;
            bool RotateAndScaleRandomly;
            bool UndeploySome;

            switch (LevelOfChaos)
            {
                case RandomizerChaos.Mild:
                    TrophiesToAdd = GenerateRandomNumber(0, 26);
                    RotateAndScaleRandomly = false;
                    UndeploySome = false;
                    break;

                case RandomizerChaos.Moderate:
                default:
                    TrophiesToAdd = GenerateRandomNumber(0, 39);
                    RotateAndScaleRandomly = true;
                    UndeploySome = false;
                    break;

                case RandomizerChaos.Heavy:
                    TrophiesToAdd = GenerateRandomNumber(0, 51);
                    RotateAndScaleRandomly = true;
                    UndeploySome = true;
                    break;
            }


            List<Trophy> AddedTrophies = new List<Trophy>();
            Dictionary<byte, Trophy>.ValueCollection Trophies = Sukuranburu.GetItemManager().GetTrophies().Values;

            // Clear everything first.
            foreach (Trophy TrophyItem in Trophies)
            {
                int OffsetSum = 15 * TrophyItem.Id;
                SelectedSlot.UpdateOffset_Byte(GameOffsets.TrophyRecord_IsGet + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Byte(GameOffsets.TrophyRecord_IsNew + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Byte(GameOffsets.TrophyRecord_IsGetDialog + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutPosition_X + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutPosition_Y + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutPosition_Z + OffsetSum, -1);
                SelectedSlot.UpdateOffset_Float(GameOffsets.TrophyRecord_PutScale + OffsetSum, 0.6666667f);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutRotation + OffsetSum, 0);
            }

            // Add trophies randomly.
            while (AddedTrophies.Count < TrophiesToAdd)
            {
                Trophy NextTrophy = Trophies.ElementAt(GenerateRandomNumber(0, Trophies.Count - 1));
                if (!AddedTrophies.Contains(NextTrophy))
                {
                    AddedTrophies.Add(NextTrophy);
                }
            }

            // Let's add some spice.
            if (GenerateRandomNumber(0, 2) == 1)
            {
                AddedTrophies.Reverse();
            }

            short NextLayer = 0;
            foreach (Trophy TrophyToAdd in AddedTrophies)
            {
                float Scale = 0.6666667F;
                short Rotation = 0;
                short Xpos = 0;
                short Ypos = 0;
                short Layer = -1;

                if (RotateAndScaleRandomly)
                {
                    Scale = (float)GenerateRandomNumber(340000, 1000000) / 1000000;
                    Rotation = (short)GenerateRandomNumber(0, 360);
                }

                if (!UndeploySome || GenerateRandomNumber(0, 10) < 8)
                {
                    Xpos = (short)GenerateRandomNumber(-2000, 2000);
                    Ypos = (short)GenerateRandomNumber(-340, 340);
                    Layer = NextLayer++;
                }

                int OffsetSum = 15 * TrophyToAdd.Id;
                SelectedSlot.UpdateOffset_Byte(GameOffsets.TrophyRecord_IsGet + OffsetSum, 1);
                SelectedSlot.UpdateOffset_Byte(GameOffsets.TrophyRecord_IsNew + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Byte(GameOffsets.TrophyRecord_IsGetDialog + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutPosition_X + OffsetSum, Xpos);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutPosition_Y + OffsetSum, Ypos);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutPosition_Z + OffsetSum, Layer);
                SelectedSlot.UpdateOffset_Float(GameOffsets.TrophyRecord_PutScale + OffsetSum, Scale);
                SelectedSlot.UpdateOffset_Int16(GameOffsets.TrophyRecord_PutRotation + OffsetSum, Rotation);
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
            {
                throw new ArgumentOutOfRangeException("MinValue");
            }

            if (MinValue == MaxValue)
            {
                return MinValue;
            }

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
