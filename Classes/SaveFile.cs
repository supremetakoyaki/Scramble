using Scramble.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Scramble.Classes
{
    public class SaveFile
    {
        public string FilePath;
        private readonly Dictionary<int, SaveSlot> SaveSlots;
        private readonly GlobalData GlobalData;

        private const int GLOBAL_DATA_LENGTH_PS4SW = 619;
        private const int GLOBAL_DATA_LENGTH_PC = 1115;

        private const int INIT_OFFSET_PS4SW = 619;
        private const int INIT_OFFSET_PC = 1115;

        private const int SLOT_LENGTH = 319989;

        private const int SAVE_LENGTH = 3200512;
        private const int PC_SAVE_LENGTH = 3201072;
        private const int PC_UNKNOWN_END_LENGTH = 35;

        public bool IsPcVersion = false;
        private readonly byte[] PcMagic;
        private readonly byte[] PcEnd;
        private Rijndael SaveRijndael;
        public static byte[] RijndaelKey = new byte[] { 0x46, 0x5C, 0x42, 0x2B, 0x65, 0x50, 0x34, 0x3A, 0x38, 0x32, 0x28, 0x70, 0x4D, 0x76, 0x2B, 0x49 };
        public static byte[] RijndaelIv = new byte[] { 0xF3, 0xF4, 0x5F, 0x18, 0xD6, 0xC2, 0xB6, 0xE6, 0xFA, 0xEE, 0x88, 0xAE, 0x57, 0xE5, 0x8E, 0x1A };

        public SaveFile(string FilePath, byte[] File, out byte Result)
        {
            if (File.Length == PC_SAVE_LENGTH)
            {
                IsPcVersion = true;
            }
            else if (File.Length != SAVE_LENGTH)
            {
                Result = 0;
                return;
            }

            this.FilePath = FilePath;

            if (IsPcVersion)
            {
                // PC version uses encryption.
                
                SaveRijndael = new Rijndael(RijndaelKey, RijndaelIv);

                byte[] Magic = new byte[32];
                byte[] EncryptedData = new byte[PC_SAVE_LENGTH - 32];

                Array.Copy(File, 0, Magic, 0, 32);
                Array.Copy(File, 32, EncryptedData, 0, PC_SAVE_LENGTH - 32);
                PcMagic = Magic;

                byte[] DecryptedData = SaveRijndael.Decrypt(EncryptedData);
                byte[] GlobalDataPc = new byte[GLOBAL_DATA_LENGTH_PC];
                Array.Copy(DecryptedData, 0, GlobalDataPc, 0, GLOBAL_DATA_LENGTH_PC);

                GlobalData = new GlobalData(GlobalDataPc, true);

                SaveSlots = new Dictionary<int, SaveSlot>();

                int CurrentPointer = INIT_OFFSET_PC;
                for (int i = 0; i < 10; i++)
                {
                    byte[] SlotData = new byte[SLOT_LENGTH];
                    Array.Copy(DecryptedData, CurrentPointer, SlotData, 0, SLOT_LENGTH);

                    SaveSlots.Add(i, new SaveSlot(i, SlotData));

                    CurrentPointer += SLOT_LENGTH;
                }

                byte[] UnknownEnd = new byte[PC_UNKNOWN_END_LENGTH];
                Array.Copy(DecryptedData, CurrentPointer, UnknownEnd, 0, PC_UNKNOWN_END_LENGTH);
                PcEnd = UnknownEnd;

                Result = 1;
            }
            else
            {
                byte[] FirstData = new byte[GLOBAL_DATA_LENGTH_PS4SW];
                Array.Copy(File, 0, FirstData, 0, GLOBAL_DATA_LENGTH_PS4SW);
                GlobalData = new GlobalData(FirstData, false);

                SaveSlots = new Dictionary<int, SaveSlot>();

                int CurrentPointer = INIT_OFFSET_PS4SW;
                for (int i = 0; i < 10; i++)
                {
                    byte[] SlotData = new byte[SLOT_LENGTH];
                    Array.Copy(File, CurrentPointer, SlotData, 0, SLOT_LENGTH);

                    SaveSlots.Add(i, new SaveSlot(i, SlotData));

                    CurrentPointer += SLOT_LENGTH;
                }

                Result = 1;
            }
        }

        public SaveSlot GetSaveSlot(int Id)
        {
            return SaveSlots[Id];
        }

        public GlobalData GetGlobalData()
        {
            return GlobalData;
        }

        public byte[] ToBytes()
        {
            if (IsPcVersion)
            {
                using (MemoryStream DataStream = new MemoryStream())
                {
                    DataStream.Write(GlobalData.ToBytes(), 0, GLOBAL_DATA_LENGTH_PC);
                    int CurrentPointer = INIT_OFFSET_PC;
                    for (int i = 0; i < 10; i++)
                    {
                        GetSaveSlot(i).WriteToStream(DataStream, ref CurrentPointer);
                    }

                    DataStream.Write(PcEnd, 0, PC_UNKNOWN_END_LENGTH);
                    byte[] DecryptedData = DataStream.ToArray();

                    if (SaveRijndael == null)
                    {
                        SaveRijndael = new Rijndael(RijndaelKey, RijndaelIv);
                    }

                    byte[] EncryptedData = SaveRijndael.Encrypt(DecryptedData);
                    using (MemoryStream EncryptedStream = new MemoryStream())
                    {
                        EncryptedStream.Write(PcMagic, 0, 32);
                        EncryptedStream.Write(EncryptedData, 0, EncryptedData.Length);

                        return EncryptedStream.ToArray();
                    }
                }
            }
            else
            {
                using (MemoryStream Stream = new MemoryStream())
                {
                    Stream.Write(GlobalData.ToBytes(), 0, GLOBAL_DATA_LENGTH_PS4SW);

                    int CurrentPointer = INIT_OFFSET_PS4SW;
                    for (int i = 0; i < 10; i++)
                    {
                        GetSaveSlot(i).WriteToStream(Stream, ref CurrentPointer);
                    }

                    Stream.WriteByte(0);
                    Stream.WriteByte(0);
                    Stream.WriteByte(0);

                    return Stream.ToArray();
                }
            }
        }
    }
}
