using System;
using System.IO;
using System.Security.Cryptography;

namespace Scramble.Util
{
    public static class TwewySaveConverter
    {
        public const int SOLOREMIX_MAGIC_OFFSET = 0;
        public const int SOLOREMIX_MAGIC_LENGTH = 26;
        public const int SOLOREMIX_HASH_OFFSET = 26;
        public const int SOLOREMIX_DATA_OFFSET = 58;
        public const int SOLOREMIX_DATA_LENGTH = 29130;
        public const int SOLOREMIX_SAVE_SIZE = 29188;

        public const int FINALREMIX_MAGIC_OFFSET = 0;
        public const int FINALREMIX_MAGIC_LENGTH = 32;
        public const int FINALREMIX_DATA_OFFSET = 64;
        public const int FINALREMIX_DATA_LENGTH = 51188;
        public const int FINALREMIX_SAVE_SIZE = 51252;

        public static byte[] SoloRemixMagic = new byte[SOLOREMIX_MAGIC_LENGTH] { 0x19, 0x53, 0x75, 0x62, 0x61, 0x72, 0x41, 0x73, 0x69, 0x6B, 0x69, 0x4B, 0x6F, 0x6E, 0x6F, 0x73, 0x45, 0x6B, 0x61, 0x69, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };

        public static byte[] FinalRemixMagic = new byte[FINALREMIX_MAGIC_LENGTH] { 0x4D, 0x68, 0x37, 0x7C, 0x56, 0x4F, 0x3C, 0x6D, 0x35, 0x68, 0x5C, 0x5B, 0x3C, 0x3F, 0x36, 0x3D, 0x72, 0x33, 0x69, 0x2B, 0x62, 0x4F, 0x51, 0x7E, 0x40, 0x00, 0x01, 0x00, 0xF4, 0xC7, 0x00, 0x00 };

        public static bool IsValidSoloRemixSaveFile(byte[] SaveFile)
        {
            if (SaveFile.Length != SOLOREMIX_SAVE_SIZE)
            {
                return false;
            }

            for (int i = 0; i < SOLOREMIX_MAGIC_LENGTH; i++)
            {
                if (SoloRemixMagic[i] != SaveFile[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static byte[] FromSoloRemix(byte[] SaveFile)
        {
            // This is done extremely dirty. When I have more time, I will probably clean it.
            // For now, it works fine.

            // Create the streams
            MemoryStream Save_Stream = new MemoryStream(FINALREMIX_SAVE_SIZE); // global, which will include Data at the end.
            MemoryStream Data_Stream = new MemoryStream(FINALREMIX_DATA_LENGTH);

            // Write the magic to the beginning of the general save stream.
            Save_Stream.Write(FinalRemixMagic, 0, 32);

            // Copy the solo remix data to a byte array.
            byte[] SoloRemixData = new byte[SOLOREMIX_DATA_LENGTH];
            Array.Copy(SaveFile, SOLOREMIX_DATA_OFFSET, SoloRemixData, 0, SOLOREMIX_DATA_LENGTH);

            // Copy from offset 0 to offset 7607. 
            Data_Stream.Write(SoloRemixData, 0, 7607);

            // mastered pin inventory has nearly double the capacity in Final Remix.
            // let's fill.

            byte[] MasteredPin_Empty = new byte[11] { 0xFF, 0xFF, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            for (int i = 0; i < 680; i++)
            {
                Data_Stream.Write(MasteredPin_Empty, 0, 11);
            }

            // continue copying, this is the same...
            Data_Stream.Write(SoloRemixData, 7607, 456);

            // we reached the inventory, which is larger in final remix.
            // we would copy, but we need to replace 0F27 (9999) with FFFF (65535) first

            int InventoryOffset_SoloRemix_byte1 = 8063;
            int InventoryOffset_SoloRemix_byte2 = 8064;

            for (int i = 0; i < 498; i++)
            {
                if (SoloRemixData[InventoryOffset_SoloRemix_byte1 + (i * 5)] == 0x0F && SoloRemixData[InventoryOffset_SoloRemix_byte2 + (i * 5)] == 0x27)
                {
                    SoloRemixData[InventoryOffset_SoloRemix_byte1 + (i * 5)] = 0xFF;
                    SoloRemixData[InventoryOffset_SoloRemix_byte2 + (i * 5)] = 0xFF;
                }
            }

            // and now we copy.
            Data_Stream.Write(SoloRemixData, 8063, 2490);

            // we now must fill the rest of the inventory with empty data.
            byte[] ItemInventory_Empty = new byte[5] { 0xFF, 0xFF, 0x00, 0x00, 0x00 };

            for (int i = 0; i < 2502; i++)
            {
                Data_Stream.Write(ItemInventory_Empty, 0, 5);
            }

            // copy again... (this seems to be flags data)
            Data_Stream.Write(SoloRemixData, 10553, 560);

            // and fill with empty chunk
            for (int i = 0; i < 1440; i++)
            {
                Data_Stream.WriteByte(0);
            }

            //copy.
            Data_Stream.Write(SoloRemixData, 11113, 1638);

            //copy.
            Data_Stream.Write(SoloRemixData, 12751, 320);
            // fill chonk...
            Data_Stream.WriteByte(0);
            Data_Stream.WriteByte(0);

            // we are now at finalremix #34519 or soloremix #13071.
            // this is the last played date offset.
            //copy
            Data_Stream.Write(SoloRemixData, 13071, 295);

            //
            Data_Stream.WriteByte(6);
            Data_Stream.WriteByte(0);
            Data_Stream.WriteByte(0);
            Data_Stream.WriteByte(0);
            Data_Stream.WriteByte(0);
            Data_Stream.WriteByte(0);

            // finalremix 34804
            byte[] chunk_unk = new byte[6] { 0x01, 0x00, 0x0F, 0x00, 0x0F, 0x27 };
            for (int i = 0; i < 105; i++)
            {
                Data_Stream.Write(chunk_unk, 0, 6);
            }

            for (int i = 0; i < 1548; i++)
            {
                Data_Stream.WriteByte(0);
            }

            // final remix 36982, soloremix 14928
            Data_Stream.Write(SoloRemixData, 14928, 14202);


            //ending
            Data_Stream.WriteByte(50);
            Data_Stream.WriteByte(0);
            Data_Stream.WriteByte(1);
            Data_Stream.WriteByte(1);

            // finale
            byte[] FinalRemix_Data = Data_Stream.ToArray();

            // fix some discrepancies and other stuff I found.
            FinalRemix_Data[34485] = 0x69;
            FinalRemix_Data[34502] = 0x69;
            FinalRemix_Data[34506] = FinalRemix_Data[34507];
            FinalRemix_Data[34507] = 0x00;
            FinalRemix_Data[34531] = 0x15;
            FinalRemix_Data[34535] = 0x01;
            FinalRemix_Data[34539] = 0x35;
            FinalRemix_Data[34544] = 0x00;
            FinalRemix_Data[34784] = 0x02;
            FinalRemix_Data[34798] = 0x06;
            FinalRemix_Data[36960] = 0x01;
            FinalRemix_Data[36968] = 0x01;
            FinalRemix_Data[37099] = 0x00;
            FinalRemix_Data[41890] = 0xB6;
            FinalRemix_Data[41898] = 0x10;
            FinalRemix_Data[41902] = 0x0A;
            FinalRemix_Data[41904] = 0x00;

            Save_Stream.Write(TwewyChecksum.CalculateChecksum(FinalRemix_Data, 0, FINALREMIX_DATA_LENGTH), 0, 32);
            Save_Stream.Write(FinalRemix_Data, 0, FINALREMIX_DATA_LENGTH);

            return Save_Stream.ToArray();
        }
    }
}
