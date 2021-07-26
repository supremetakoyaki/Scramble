namespace Scramble.GameData
{
    public class Offsets
    {
        public const int Experience = 14661; // 32-bit
        public const int CurrentLevel = 14665; // 16-bit ?
        public const int Money = 14673; // 32-bit
        public const int Difficulty = 296836; // 8-bit
        public const int Fp = 15056; // 16-bit

        public const int RecordInv_First = 3344; // byte & byte

        public const int PinInv_Count = 15208; // int32
        public const int PinInv_CountOfIndexes = 15212; // int32, basically count minus one.
        public const int PinInv_First = 15216; // int16, int16, int16, int16.
        public const int PinInv_VeryLast = 292415;

        public const int ClothingInv_Count = 292416; // int 32
        public const int ClothingInv_First = 292420; // just an int16.
        public const int ClothingInv_Last = 296608;

        // Party member data. For the next 6 party members we just add +36.
        public const int PartyMember1_CharacterId = 296620; //Rindo. int32
        public const int PartyMember1_EquippedPinIndex_Deck1 = 296624; //int32
        public const int PartyMember1_EquippedPinIndex_Deck2 = 296628; //int32
        public const int PartyMember1_EquippedPinIndex_Deck3 = 296632; //int32
        public const int PartyMember1_EquippedHeadwearIndex = 296636; //int32
        public const int PartyMember1_EquippedTopIndex = 296640; //int32
        public const int PartyMember1_EquippedBottomIndex = 296644; // int32
        public const int PartyMember1_EquippedShoesIndex = 296648; //int32
        public const int PartyMember1_EquippedAccessoryIndex = 296652; //int32
    }
}