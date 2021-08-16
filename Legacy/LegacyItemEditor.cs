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
    }
}
