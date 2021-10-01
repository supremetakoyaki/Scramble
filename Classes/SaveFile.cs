using System;
using System.Collections.Generic;
using System.IO;

namespace Scramble.Classes
{
    public class SaveFile
    {
        public string FilePath;
        private readonly Dictionary<int, SaveData> SaveSlots;
        private readonly GlobalData GlobalData;

        private const int PC_KEY_LENGTH = 32;
        private const int GLOBAL_DATA_LENGTH = 619;

        private const int INIT_OFFSET = 619;
        private const int SLOT_LENGTH = 319989;

        private const int SAVE_LENGTH = 3200512;
        private const int PC_SAVE_LENGTH = 3201572;

        public bool IsPcVersion = false;

        public SaveFile(string FilePath, byte[] File, out byte Result)
        {
            if (File.Length == PC_SAVE_LENGTH)
            {
                //IsPcVersion = true;
                Result = 3;
                return;
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
                Result = 1;
            }
            else
            {
                byte[] FirstData = new byte[GLOBAL_DATA_LENGTH];
                Array.Copy(File, 0, FirstData, 0, GLOBAL_DATA_LENGTH);
                GlobalData = new GlobalData(FirstData);

                SaveSlots = new Dictionary<int, SaveData>();

                int CurrentPointer = INIT_OFFSET;
                for (int i = 0; i < 10; i++)
                {
                    byte[] SlotData = new byte[SLOT_LENGTH];
                    Array.Copy(File, CurrentPointer, SlotData, 0, SLOT_LENGTH);

                    SaveSlots.Add(i, new SaveData(i, SlotData));

                    CurrentPointer += SLOT_LENGTH;
                }

                Result = 1;
            }
        }

        public SaveData GetSaveSlot(int Id)
        {
            return SaveSlots[Id];
        }

        public GlobalData GetGlobalData()
        {
            return GlobalData;
        }

        public byte[] ToBytes()
        {
            MemoryStream Stream = new MemoryStream();

            Stream.Write(GlobalData.ToBytes(), 0, GLOBAL_DATA_LENGTH);

            int CurrentPointer = INIT_OFFSET;
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
