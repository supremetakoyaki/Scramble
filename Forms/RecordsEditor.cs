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
            
            foreach (int Key in RecordDic.Keys)
            {
                int SaveId = Key;
                int ItemId = RecordDic[Key];
                string Name = ItemTable.GetItemName(ItemId);
                string TypeStr = ItemTable.GetItemType(ItemId).ToString();

                int CurrentPointer = Offsets.RecordInv_First + (SaveId * 2);

                bool Unlocked = SelectedSlot.RetrieveOffset_Byte(CurrentPointer) == 1;
                bool Flag = SelectedSlot.RetrieveOffset_Byte(CurrentPointer + 1) == 1;

                RecordInvListView.Items.Add(new ListViewItem(new string[] { SaveId.ToString(), ItemId.ToString(), TypeStr, Name, Unlocked ? "yes" : "no", Flag ? "yes" : "no" }));
            }

            
        }

        private void UnlockAllButton_Click(object sender, EventArgs e)
        {
            byte Change = RecordInvListView.Items[0].SubItems[4].Text == "yes" ? (byte)0 : (byte)1;

            foreach (ListViewItem Item in RecordInvListView.Items)
            {
                int CurrentPointer = Offsets.RecordInv_First + (Convert.ToInt32(Item.Text) * 2);

                SelectedSlot.UpdateOffset_Byte(CurrentPointer, Change);
            }

            RecordInvListView.Items.Clear();

            Serialize();
        }

        private void UnseeAllButton_Click(object sender, EventArgs e)
        {
            byte Change = RecordInvListView.Items[0].SubItems[4].Text == "yes" ? (byte)0 : (byte)1;

            foreach (ListViewItem Item in RecordInvListView.Items)
            {
                int CurrentPointer = Offsets.RecordInv_First + (Convert.ToInt32(Item.Text) * 2);

                SelectedSlot.UpdateOffset_Byte(CurrentPointer + 1, Change);
            }

            RecordInvListView.Items.Clear();
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
