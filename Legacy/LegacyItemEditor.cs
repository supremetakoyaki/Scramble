using FinalRemixDb;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Legacy
{
    public partial class LegacyItemEditor : Form
    {
        public LegacySave SaveFile => Program.Legacy.OpenedSaveFile;
        public LegacyForm Legacy => Program.Legacy;

        private bool ReadyForUserInput = false;

        public LegacyItemEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            if (Legacy.RequiresRescaling)
            {
                ItemList_ListView.AutoSize = true;
            }

            PopulateItemListView();
            if (ItemList_ListView.Items.Count > 0)
            {
                ItemList_ListView.Items[0].Selected = true;
                ItemList_ListView.Select();
            }

            DisplaySelectedItem();
            ReadyForUserInput = true;
        }

        private void PopulateItemListView()
        {
            foreach (TwewyItem Item in Legacy.GetTwewyManager().GetItems().Values)
            {
                ListViewItem ItemToAdd = new ListViewItem(new string[] { Item.Id.ToString(), Item.GetName(Legacy.LanguageId) });
                ItemToAdd.Tag = Item.Id;

                ItemList_ListView.Items.Add(ItemToAdd);
            }
        }

        private void DisplaySelectedItem()
        {
            if (ItemList_ListView.SelectedItems.Count != 1)
            {
                return;
            }

            ListViewItem SelectedItem = ItemList_ListView.SelectedItems[0];
            TwewyItem GameItem = Legacy.GetTwewyManager().GetItem((ushort)SelectedItem.Tag);

            if (GameItem == null)
            {
                throw new NullReferenceException();
            }

            Item_PictureBox.Image = ImageMethodsFr.DrawImage(GameItem.Sprite, 64, 64, DeviceDpi);
            Legacy.GetTwewyTextProcessor().SetTaggedText(GameItem.GetName(Legacy.LanguageId), ItemName_RichTextBox);
            Legacy.GetTwewyTextProcessor().SetTaggedText(GameItem.GetDescription(Legacy.LanguageId), ItemDescription_RichTextBox);

            switch (GameItem.Type)
            {
                default:
                    ItemType_Value_Label.Text = "—";
                    break;

                case 1:
                    ItemType_Value_Label.Text = "Thread";
                    break;

                case 2:
                    ItemType_Value_Label.Text = "Food";
                    break;

                case 3:
                    ItemType_Value_Label.Text = "Swag";
                    break;
            }

            int SaveIndex = Legacy.GetTwewyManager().GetSaveIndex(GameItem);
            int OffsetSum = (SaveIndex * 5);

            ushort Id = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.ItemInventory_Id_First + OffsetSum);
            ushort Amount = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.ItemInventory_Amount_First + OffsetSum);

            if (Amount < 1 || Amount == 0xFFFF || Id == 0xFFFF)
            {
                Amount_NUpDown.Value = 0;
            }
            else if (Amount > 9)
            {
                Amount_NUpDown.Value = 9;
            }
            else
            {
                Amount_NUpDown.Value = Amount;
            }
        }

        private void UpdateAmount(TwewyItem GameItem, ushort Amount)
        {
            if (GameItem == null)
            {
                return;
            }

            int SaveIndex = Legacy.GetTwewyManager().GetSaveIndex(GameItem);
            int OffsetSum = (SaveIndex * 5);

            if (Amount == 0)
            {
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.ItemInventory_Amount_First + OffsetSum, Amount);
            }
            else
            {
                ushort Id = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.ItemInventory_Id_First + OffsetSum);
                if (Id == 0xFFFF) // in the future: make an "unlock" option?
                {
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.ItemInventory_Id_First + OffsetSum, GameItem.Id);
                }

                SaveFile.UpdateOffset_UInt16(LegacyOffsets.ItemInventory_Amount_First + OffsetSum, Amount);
            }
        }

        private void ItemList_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            DisplaySelectedItem();
            ReadyForUserInput = true;
        }

        private void Amount_NUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || ItemList_ListView.SelectedItems.Count != 1)
            {
                return;
            }

            ReadyForUserInput = false;

            ListViewItem SelectedItem = ItemList_ListView.SelectedItems[0];
            TwewyItem GameItem = Legacy.GetTwewyManager().GetItem((ushort)SelectedItem.Tag);

            if (GameItem == null)
            {
                ReadyForUserInput = true;
                throw new NullReferenceException();
            }

            UpdateAmount(GameItem, (ushort)Amount_NUpDown.Value);

            ReadyForUserInput = true;
        }

        private void SetAllMax_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            foreach (TwewyItem GameItem in Legacy.GetTwewyManager().GetItems().Values)
            {
                UpdateAmount(GameItem, 9);
            }

            if (ItemList_ListView.SelectedItems.Count == 1)
            {
                Amount_NUpDown.Value = 9;
            }

            ReadyForUserInput = true;
        }

        private void SetAllToMin_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            foreach (TwewyItem GameItem in Legacy.GetTwewyManager().GetItems().Values)
            {
                UpdateAmount(GameItem, 0);
            }

            if (ItemList_ListView.SelectedItems.Count == 1)
            {
                Amount_NUpDown.Value = 0;
            }

            ReadyForUserInput = true;
        }
    }
}
