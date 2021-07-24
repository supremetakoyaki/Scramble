using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class RecordsEditor : Form
    {
        public SaveData SelectedSlot
        {
            get
            {
                return Program.Sukuranburu.SelectedSlot;
            }
        }

        public RecordsEditor()
        {
            InitializeComponent();
            Serialize();
        }

        public void Serialize(bool Clear = false)
        { 
            if (Clear)
            {
                RecordInvListView.Clear();
            }

            var RecordDic = ItemTable.GetRecordDictionary();
            
            int CurrentPointer = Offsets.RecordInv_First;
            foreach (int Key in RecordDic.Keys)
            {
                int SaveId = Key;
                int ItemId = RecordDic[Key];
                string Name = ItemTable.GetItemName(ItemId);
                bool Unlocked = SelectedSlot.RetrieveOffset_Byte(CurrentPointer) == 1;
                bool Flag = SelectedSlot.RetrieveOffset_Byte(CurrentPointer + 1) == 1;

                RecordInvListView.Items.Add(new ListViewItem(new string[] { SaveId.ToString(), ItemId.ToString(), Name, Unlocked ? "✅" : "❎", Flag ? "✅" : "❎" }));
                CurrentPointer += 2;
            }
        }

        private void UnlockAllButton_Click(object sender, EventArgs e)
        {
            int CurrentPointer = Offsets.RecordInv_First;

            for (int i = 0; i < ItemTable.GetRecordDictionary().Count; i++)
            {
                SelectedSlot.UpdateOffset_Byte(CurrentPointer, 1);
                SelectedSlot.UpdateOffset_Byte(CurrentPointer + 1, 1);

                CurrentPointer += 2;
            }

            Serialize(true);
        }
    }
}
