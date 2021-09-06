namespace Scramble.GameData
{
    public class Offsets
    {
        // GlobalData offsets below.
        public const int VolumeMusic = 0; // FLOAT
        public const int VolumeSfx = 4; // FLOAT
        public const int VolumeVa = 8; // FLOAT
        public const int VaLanguage = 16; // byte? jp=0 eng=1
        public const int Vibration = 20; // boolean
        public const int DialogueAutoplay = 21; // boolean.
        public const int Subtitles = 23; // boolean
        public const int Dlc = 299; // byte. bit-based indexes.

        // SaveData offsets below.

        // Noisepedia + 13 for each noise.
        public const int Noisepedia_Id0_RecordLevel = 16; //int32. 0xFFFF if not unlocked
        public const int Noisepedia_Id0_Erased = 20; //int32. 0xFFFF if not unlocked
        public const int Noisepedia_Id0_EasyPinUnlocked = 24; //boolean.
        public const int Noisepedia_Id0_NormalPinUnlocked = 25; //boolean.
        public const int Noisepedia_Id0_HardPinUnlocked = 26; //boolean.
        public const int Noisepedia_Id0_UltimatePinUnlocked = 27; //boolean.
        public const int Noisepedia_Id0_NotEncounteredYet = 28; //boolean. im not 100% sure if it means this.

        // Collection record.
        public const int RecordInv_First = 3344; // byte & byte
        public const int MasteredPins_First = 6352; //int32
        public const int MasteredPins_Last = 7951;

        // Trophies
        public const int Trophies_Unlocked_First = 5392; // boolean.
        public const int Trophies_Unseen_First = 5393; // boolean
        public const int Trophies_ShowAsNew_First = 5394; // boolean
        public const int Trophies_XPos_First = 5395; // signed int16.
        public const int Trophies_YPos_First = 5397; // signed int16.
        public const int Trophies_ZPos_First = 5399; // signed int16. This is always 0 when deployed and 0xFFFF when undeployed.
        public const int Trophies_Scale_First = 5401; // float
        public const int Trophies_RotationAngle_First = 5405; // int16. 0 to 360?

        // Turf war
        public const int TurfWar_CurrentPoints_W2D3 = 8168; // int32
        public const int TurfWar_CurrentPoints = 9899; // int32
        public const int TurfWar_Placement_First = 14017; //byte
        public const int TurfWar_HighScore_First = 14018; //int32

        // Hmm?
        public const int UnkDayFlag = 11432; // could be byte or int16. it's "1" if you beat the game... but I have my doubts.
        public const int CurrentDay = 11434; // int32
        public const int MaxDay = 11438; //int32
        public const int Chatlogs_Start = 14057; //int32. You can have up to 100 chatlogs. IDs are from IdDic.json

        // Basic stats.
        public const int Experience = 14661; // 32-bit
        public const int CurrentLevel = 14665; // 16-bit ?
        public const int Money = 14673; // 32-bit
        public const int Calories = 14677; // 32-bit
        public const int Overate = 14681; // boolean

        // Character stat data.
        public const int Character1_Id = 14710; // int32
        public const int Character1_Hp = 14714; // int 32, base value is in BattleCharacter.txt
        public const int Character1_Atk = 14718; // int 32, base value is in BattleCharacter.txt
        public const int Character1_Def = 14722; // int 32, base value is in BattleCharacter.txt
        public const int Character1_Style = 14726; // int 16, base value is in BattlePlayer.txt
        public const int Character1_DropRateBonus = 14728; // int 16

        // Social tree
        public const int Fp = 15056; // actually an int32.
        public const int Social_ConnectionStatus_First = 15060; // byte.
                                                                // 0x00    Icon doesn't show (unknown/never met)
                                                                // 0x80	No glowing (can't interact)
                                                                // 0xC0	Glowing (can buy the skill if you "connected" the character)

        // Skills data. 8 slots per byte (every bit is changed)
        public const int Skills_First = 15192;

        public const int PinInv_Count = 15208; // int32
        public const int PinInv_CountOfIndexes = 15212; // int32, basically count minus one.
        public const int PinInv_First = 15216; // int16, int16, int16, int16.
        public const int PinInv_VeryLast = 292415;

        public const int ClothingInv_Count = 292416; // int 32
        public const int ClothingInv_First = 292420; // just an int16.
        public const int ClothingInv_Last = 296619;

        // Party member data. For the next 5 party members we just add +36.
        public const int PartyMember1_CharacterId = 296620; //Rindo. int32
        public const int PartyMember1_EquippedPinIndex_Deck1 = 296624; //int32
        public const int PartyMember1_EquippedPinIndex_Deck2 = 296628; //int32
        public const int PartyMember1_EquippedPinIndex_Deck3 = 296632; //int32
        public const int PartyMember1_EquippedHeadwearIndex = 296636; //int32
        public const int PartyMember1_EquippedTopIndex = 296640; //int32
        public const int PartyMember1_EquippedBottomIndex = 296644; // int32
        public const int PartyMember1_EquippedShoesIndex = 296648; //int32
        public const int PartyMember1_EquippedAccessoryIndex = 296652; //int32

        public const int Difficulty = 296836; // 8-bit

        // Shop data. +68 for each shop
        public const int Shop0_unk1 = 301904; // int32
        public const int Shop0_Food_LastOrder_Character1 = 301908; // int32
        public const int Shop0_Food_LastOrder_Character2 = 301912; // int32
        public const int Shop0_Food_LastOrder_Character3 = 301916; // int32
        public const int Shop0_Food_LastOrder_Character4 = 301920; // int32
        public const int Shop0_Food_LastOrder_Character5 = 301924; // int32
        public const int Shop0_Food_LastOrder_Character6 = 301928; // int32
        public const int Shop0_Food_LastOrder_Character7 = 301932; // int32
        public const int Shop0_Food_LastOrder_Character8 = 301936; // int32
        public const int Shop0_Food_LastOrder_Character9 = 301940; // int32
        public const int Shop0_Food_LastOrder_Character10 = 301944; // int32
        public const int Shop0_unk2 = 301904; // int32
        public const int Shop0_unk3 = 301904; // int32
        public const int Shop0_unk4 = 301904; // int32
        public const int Shop0_Food_TimesOrdered = 301904; // int32

    }
}