namespace Scramble.Legacy
{
    public class LegacyOffsets
    {
        public const int Hp = 2; // int16
        public const int CurLevel = 4; //int16
        public const int MaxLevel = 6; //int16
        public const int Experience = 8;//int32
        public const int Money = 12;//int32

        public const int Neku_Attack = 16; //int16
        public const int Neku_Defense = 18;//int16
        public const int Neku_DropRate = 20;//int16
        public const int Neku_Bravery = 22;//int16

        public const int Difficulty = 28;//byte?

        public const int Neku_Food = 41; // int16
        public const int Neku_Bytes = 43; //int16
        public const int Neku_IndexOfUnavailableBytes = 45;//int16

        public const int Shiki_Attack = 59;//int16
        public const int Shiki_Defense = 61;//int16
        public const int Shiki_Sync = 63;//int16
        public const int Shiki_Bravery = 65; //int16

        public const int Shiki_Food = 67; //int16
        public const int Shiki_Bytes = 69; //int16
        public const int Shiki_IndexOfUnavailableBytes = 71;//int16

        public const int Joshua_Attack = 85;//int16
        public const int Joshua_Defense = 87;//int16
        public const int Joshua_Sync = 89;//int16
        public const int Joshua_Bravery = 91;//int16

        public const int Joshua_Food = 93;//int16
        public const int Joshua_Bytes = 95;//int16
        public const int Joshua_IndexOfUnavailableBytes = 97;//int16

        public const int Beat_Attack = 111;//int16
        public const int Beat_Defense = 113;//int16
        public const int Beat_Sync = 115;//int16
        public const int Beat_Bravery = 117;//int16

        public const int Beat_Food = 119;//int16
        public const int Beat_Bytes = 121;//int16
        public const int Beat_IndexOfUnavailableBytes = 123;//int16

        public const int ItemInventory_Id_First = 15543;//int16
        public const int ItemInventory_Amount_First = 15545;//int16
        public const int ItemInventory_UnkFlag_First = 15547;//byte
    }
}
