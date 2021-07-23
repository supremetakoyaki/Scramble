using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Scramble.Classes
{
    public class SaveFile
    {
        public string FilePath;
        private Dictionary<int, SaveData> SaveSlots;

        private const int INIT_OFFSET = 620;
        private const int SLOT_LENGTH = 319989;

        private const int SAVE_LENGTH = 3200512;

        public SaveFile(string FilePath, byte[] File, out byte Result)
        {
            if (File.Length != SAVE_LENGTH)
            {
                Result = 0;
                return;
            }

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

        public SaveData GetSaveSlot(int Id)
        {
            return SaveSlots[Id];
        }
    }
}
