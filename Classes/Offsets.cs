namespace Scramble.Classes
{
    public class SystemOffsets
    {
        //SaveDataOption
        public const int BGMVolume = 0; // float
        public const int SEVolume = 4; // float
        public const int VoiceVolume = 8; // float
        public const int SoundMode = 12; // int                             it seems to be always 5 on Switch
        public const int VaLanguage = 16; // int
        public const int IsControllerVibration = 20; // boolean
        public const int IsAutoMessage = 21; // boolean.
        public const int IsShowSubTitle = 23; // boolean

        public const int ScreenResolution_Width_PS4SW = 24; // int
        public const int ScreenResolution_Height_PS4SW = 28; // int
        public const int DLCFlags_PS4SW = 299; // byte
        public const int DLCFlags_PC = 859; // byte
    }

    public class GameOffsets
    {
        // SaveDataRecord
        // NoiseRecord. +13 for every other noise.
        public const int NoiseRecord_DefeatLevel = 16; // int                0xFFFF if not unlocked
        public const int NoiseRecord_DefeatNum = 20; // int                  0xFFFF if not unlocked
        public const int NoiseRecord_DropGetFlag_Easy = 24; //boolean
        public const int NoiseRecord_DropGetFlag_Normal = 25; //boolean
        public const int NoiseRecord_DropGetFlag_Hard = 26; //boolean
        public const int NoiseRecord_DropGetFlag_Ultimate = 27; //boolean
        public const int NoiseRecord_IsNew = 28; //boolean

        // CollectionRecord
        public const int CollectionRecord = 3344; // boolean & boolean      IsGet & IsNew

        // TrophyRecord
        public const int TrophyRecord_IsGet = 5392; // boolean
        public const int TrophyRecord_IsGetDialog = 5393; // boolean
        public const int TrophyRecord_IsNew = 5394; // boolean
        public const int TrophyRecord_PutPosition_X = 5395; // short
        public const int TrophyRecord_PutPosition_Y = 5397; // short
        public const int TrophyRecord_PutPosition_Z = 5399; // short        This is 0xFFFF when undeployed, otherwise it means layer with 0 being topmost.
        public const int TrophyRecord_PutScale = 5401; // float             In-game it is possible to set scale between 1/3 and 1, with 2/3 being default.
        public const int TrophyRecord_PutRotation = 5405; // short

        // TrophyParamCount
        public const int TrophyParamCount_BadgeMasterIds = 6352; // int     There is space for 400.

        // SaveDataStruggle
        public const int StrugglePoint_w2d3 = 8168; // int
        public const int StrugglePoint = 9899; // int

        // SaveDataClearStruggle
        public const int StruggleClearIsReward = 14017; // byte
        public const int StruggleHighScore = 14018; // int

        // SaveDataField
        public const int CurrentPlayDateDay = 11434; // int
        public const int ScenarioNewestDateDay = 11438; // int

        //SaveDataField
        // SaveDataScenarioDone
        public const int ThinkingBoardNewFlagSize = 12386;  // BitArray, size = 2048
        public const int ScenarioDoneFlag = 12654;          // BitArray, size = 6144

        // SaveDataDefeatNoise
        public const int DayDefeatNoiseFlag = 13994; // BitArray ,size = 16 (2 bytes)
        public const int PigDefeatNoiseFlag = 14000; // BitArray, size = 64 (8 bytes)

        public const int MenuMusic = 14013; // int

        // SaveDataEventLog
        public const int EventLog = 14057; // int                           You can have up to 100 chatlogs. IDs are from IdDic.json

        // SaveDataPlayerTeam
        public const int PlayerTeam_Exp = 14661; // int
        public const int PlayerTeam_NowLevel = 14665; // int
        public const int PlayerTeam_MaxLevel = 14669; // int
        public const int PlayerTeam_Money = 14673; // int
        public const int PlayerTeam_Satiety = 14677; // int
        public const int PlayerTeam_IsSatietyPenalty = 14681; // bool
        public const int PlayerTeam_PartyMember = 14686; // int
        public const int PlayerData_PlayerId = 14710; // int
        public const int PlayerData_FoodHp = 14714; // int                  base value is in BattleCharacter.txt
        public const int PlayerData_FoodAtk = 14718; // int                 base value is in BattleCharacter.txt
        public const int PlayerData_FoodDef = 14722; // int                 base value is in BattleCharacter.txt
        public const int PlayerData_FoodSense = 14726; // int               base value is in BattlePlayer.txt
        public const int PlayerData_FoodDropRate = 14728; // int

        // SaveDataSkill
        public const int SkillPoint = 15056; // int
        public const int SkillTreeFlags = 15060; // byte                    There is space for 128
                                                 // 0x00    Icon doesn't show (unknown/never met)
                                                 // 0x80	   No glowing (can't interact)
                                                 // 0xC0	   Glowing (can buy the skill if you "connected" the character)
        public const int SkillFlag = 15192;                                 // There is space for 128

        // SaveDataBadge
        public const int BadgeEmptyIndex = 15208; // int
        public const int BadgeLastUseIndex = 15212; // int
        public const int MyBadgeList = 15216;                               // There is space for 34650
        public const int MyBadgeList_Last = 292415;

        // SaveDataCostume
        public const int MyCostumeCount = 292416; // int
        public const int MyCostumeList = 292420;
        public const int MyCostumeList_Last = 296619;

        // SaveDataEquip
        public const int EquipPlayerID = 296620; // int                     For the next 5 party members we just add +36.
        public const int BadgeEquipPlayerIndex_Deck1 = 296624; // int
        public const int BadgeEquipPlayerIndex_Deck2 = 296628; // int
        public const int BadgeEquipPlayerIndex_Deck3 = 296632; // int
        public const int EquipCosIndex_Head = 296636; // int
        public const int EquipCosIndex_Top = 296640; // int
        public const int EquipCosIndex_Bottom = 296644; // int
        public const int EquipCosIndex_Foot = 296648; // int
        public const int EquipCosIndex_Accessory = 296652; // int

        public const int DifficultyLevel = 296836; // 8-bit

        // SaveDataShop
        public const int ShopLastFoods = 301904;                            // There is space for 16 character IDs... what? +68 for every shop
        public const int ShopNumTimesUsed = 301968; // int
        public const int ShopGoods_PurchaseNum = 310608; // int             // There is space for 1024 shop goods.
        public const int ShopGoods_ExchangeNum = 310612; // int
        public const int ShopGoods_IsNew = 310616; //boolean
        public const int BrandPoint = 319824; //int                         // There is space for 32 brands.
    }
}