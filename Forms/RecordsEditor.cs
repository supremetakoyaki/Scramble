using Scramble.Classes;
using Scramble.GameData;
using System;
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

        public void Serialize()
        {
            var RecordDic = ItemTable.GetRecordDictionary();
            
            int CurrentPointer = Offsets.RecordInv_First;
            foreach (int Key in RecordDic.Keys)
            {
                int SaveId = Key;
                int ItemId = RecordDic[Key];
                string Name = ItemTable.GetItemName(ItemId);
                string TypeStr = ItemTable.GetItemType(ItemId).ToString();
                bool Unlocked = SelectedSlot.RetrieveOffset_Byte(CurrentPointer) == 1;
                bool Flag = SelectedSlot.RetrieveOffset_Byte(CurrentPointer + 1) == 1;

                RecordInvListView.Items.Add(new ListViewItem(new string[] { SaveId.ToString(), ItemId.ToString(), TypeStr, Name, Unlocked ? "yes" : "no", Flag ? "yes" : "no" }));
                CurrentPointer += 2;
            }

            
        }

        private void UnlockAllButton_Click(object sender, EventArgs e)
        {
            byte Change = RecordInvListView.Items[0].SubItems[4].Text == "yes" ? (byte)0 : (byte)1;

            RecordInvListView.Items.Clear();

            int CurrentPointer = Offsets.RecordInv_First;

            for (int i = 0; i < ItemTable.GetRecordDictionary().Count; i++)
            {
                SelectedSlot.UpdateOffset_Byte(CurrentPointer, Change);

                CurrentPointer += 2;
            }

            Serialize();
        }

        private void UnseeAllButton_Click(object sender, EventArgs e)
        {
            byte Change = RecordInvListView.Items[0].SubItems[5].Text == "yes" ? (byte)0 : (byte)1;

            RecordInvListView.Items.Clear();

            int CurrentPointer = Offsets.RecordInv_First;

            for (int i = 0; i < ItemTable.GetRecordDictionary().Count; i++)
            {
                SelectedSlot.UpdateOffset_Byte(CurrentPointer + 1, Change);

                CurrentPointer += 2;
            }

            Serialize();
        }

        private void ChangeLockStatusButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem SelectedValue in RecordInvListView.SelectedItems)
            {
                int SaveId = Convert.ToInt32(SelectedValue.Text);
                int Offset = Offsets.RecordInv_First + (SaveId * 2);

                if (SelectedValue.SubItems[4].Text == "yes")
                {
                    SelectedValue.SubItems[4].Text = "no";
                    SelectedSlot.UpdateOffset_Byte(Offset, 0);
                }
                else if (SelectedValue.SubItems[4].Text == "no")
                {
                    SelectedValue.SubItems[4].Text = "yes";
                    SelectedSlot.UpdateOffset_Byte(Offset, 1);
                }
            }
        }

        private void ChangeSeeStatusButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem SelectedValue in RecordInvListView.SelectedItems)
            {
                int SaveId = Convert.ToInt32(SelectedValue.Text);
                int Offset = Offsets.RecordInv_First + (SaveId * 2);

                if (SelectedValue.SubItems[5].Text == "yes")
                {
                    SelectedValue.SubItems[5].Text = "no";
                    SelectedSlot.UpdateOffset_Byte(Offset + 1, 0);
                }
                else if (SelectedValue.SubItems[5].Text == "no")
                {
                    SelectedValue.SubItems[5].Text = "yes";
                    SelectedSlot.UpdateOffset_Byte(Offset + 1, 1);
                }
            }
        }
    }
}
