﻿using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class CollectionEditor : Form
    {
        public SaveData SelectedSlot
        {
            get
            {
                return Program.Sukuranburu.SelectedSlot;
            }
        }

        public ScrambleForm Sukuranburu
        {
            get
            {
                return Program.Sukuranburu;
            }
        }

        public CollectionEditor()
        {
            InitializeComponent();
            this.RecordInvListView.SmallImageList = Sukuranburu.Get32x32AllCollectionIconsImageList();

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

                ListViewItem ItemToAdd = new ListViewItem(new string[] { Name, SaveId.ToString(), ItemId.ToString(), TypeStr, Unlocked ? "yes" : "no", Flag ? "yes" : "no" });
                ItemToAdd.ImageKey = ItemTable.GetSpriteForGlobalItem(ItemId) + ".png";
                if (ItemToAdd.ImageKey == ".png")
                {
                    MessageBox.Show(ItemId + " - " + Name + " - " + ItemToAdd.ImageKey);
                }
                RecordInvListView.Items.Add(ItemToAdd);
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
            byte Change = RecordInvListView.Items[0].SubItems[5].Text == "yes" ? (byte)0 : (byte)1;

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
            bool Flag = false;
            if (RecordInvListView.SelectedItems.Count > 0)
            {
                Flag = RecordInvListView.SelectedItems[0].SubItems[4].Text == "yes";
            }

            foreach (ListViewItem SelectedValue in RecordInvListView.SelectedItems)
            {
                int SaveId = Convert.ToInt32(SelectedValue.SubItems[1].Text);
                int Offset = Offsets.RecordInv_First + (SaveId * 2);

                if (Flag)
                {
                    SelectedValue.SubItems[4].Text = "no";
                    SelectedSlot.UpdateOffset_Byte(Offset, 0);
                }
                else
                {
                    SelectedValue.SubItems[4].Text = "yes";
                    SelectedSlot.UpdateOffset_Byte(Offset, 1);
                }
            }
        }

        private void ChangeSeeStatusButton_Click(object sender, EventArgs e)
        {
            bool Flag = false;
            if (RecordInvListView.SelectedItems.Count > 0)
            {
                Flag = RecordInvListView.SelectedItems[0].SubItems[5].Text == "yes";
            }

            foreach (ListViewItem SelectedValue in RecordInvListView.SelectedItems)
            {
                int SaveId = Convert.ToInt32(SelectedValue.SubItems[1].Text);
                int Offset = Offsets.RecordInv_First + (SaveId * 2);

                if (Flag)
                {
                    SelectedValue.SubItems[5].Text = "no";
                    SelectedSlot.UpdateOffset_Byte(Offset + 1, 0);
                }
                else
                {
                    SelectedValue.SubItems[5].Text = "yes";
                    SelectedSlot.UpdateOffset_Byte(Offset + 1, 1);
                }
            }
        }
    }
}