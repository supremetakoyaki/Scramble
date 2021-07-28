using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Drawing;
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
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.RecordInvListView.SmallImageList = Sukuranburu.Get32x32AllCollectionIconsImageList();

            Serialize();
        }

        public void Serialize()
        {
            var RecordDictionary = Sukuranburu.GetItemManager().GetSaveIndexes();
            
            foreach (int SaveId in RecordDictionary.Keys)
            {
                ushort GlobalId = RecordDictionary[SaveId];
                IGameItem Item = Sukuranburu.GetItemManager().GetItem(GlobalId);

                string Name = Sukuranburu.GetGameString(Item.Name);
                string TypeStr = Item.Type.ToString();

                int CurrentPointer = Offsets.RecordInv_First + (SaveId * 2);

                bool Unlocked = SelectedSlot.RetrieveOffset_Byte(CurrentPointer) == 1;
                bool Flag = SelectedSlot.RetrieveOffset_Byte(CurrentPointer + 1) == 1;

                ListViewItem ItemToAdd = new ListViewItem(new string[] { Name, SaveId.ToString(), GlobalId.ToString(), TypeStr, Unlocked ? Sukuranburu.GetString("{YesLowercase}") : Sukuranburu.GetString("{NoLowercase}"), Flag ? Sukuranburu.GetString("{YesLowercase}") : Sukuranburu.GetString("{NoLowercase}") });
                ItemToAdd.ImageKey = string.Format("{0}.png", Item.Sprite);

                RecordInvListView.Items.Add(ItemToAdd);
            }


            DisplayLanguageStrings();
        }

        private void DisplayLanguageStrings()
        {
            this.Text = Sukuranburu.GetString("{CollectionEditor}");
            this.groupBox1.Text = Sukuranburu.GetString("{Items}");
            this.SaveIDHeader.Text = Sukuranburu.GetString("{SaveId}");
            this.ItemNameHeader.Text = Sukuranburu.GetString("{Name}");
            this.ItemIDHeader.Text = Sukuranburu.GetString("{ItemId}");
            this.TypeHeader.Text = Sukuranburu.GetString("{Type}");
            this.UnlockedHeader.Text = Sukuranburu.GetString("{Unlocked}");
            this.FlagHeader.Text = Sukuranburu.GetString("{Unseen}");
            this.UnlockAllButton.Text = Sukuranburu.GetString("{UnlockAll}");
            this.UnseeAllButton.Text = Sukuranburu.GetString("{UnseeAll}");
            this.ChangeLockStatusButton.Text = Sukuranburu.GetString("{UnlockSelected}");
            this.ChangeSeeStatusButton.Text = Sukuranburu.GetString("{UnseeSelected}");
        }

        private void UnlockAllButton_Click(object sender, EventArgs e)
        {
            byte Change = RecordInvListView.Items[0].SubItems[4].Text == Sukuranburu.GetString("{YesLowercase}") ? (byte)0 : (byte)1;

            foreach (ListViewItem Item in RecordInvListView.Items)
            {
                int CurrentPointer = Offsets.RecordInv_First + (Convert.ToInt32(Item.SubItems[1].Text) * 2);

                SelectedSlot.UpdateOffset_Byte(CurrentPointer, Change);
            }

            RecordInvListView.Items.Clear();

            Serialize();
        }

        private void UnseeAllButton_Click(object sender, EventArgs e)
        {
            byte Change = RecordInvListView.Items[0].SubItems[5].Text == Sukuranburu.GetString("{YesLowercase}") ? (byte)0 : (byte)1;

            foreach (ListViewItem Item in RecordInvListView.Items)
            {
                int CurrentPointer = Offsets.RecordInv_First + (Convert.ToInt32(Item.SubItems[1].Text) * 2);

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
                Flag = RecordInvListView.SelectedItems[0].SubItems[4].Text == Sukuranburu.GetString("{YesLowercase}");
            }

            foreach (ListViewItem SelectedValue in RecordInvListView.SelectedItems)
            {
                int SaveId = Convert.ToInt32(SelectedValue.SubItems[1].Text);
                int Offset = Offsets.RecordInv_First + (SaveId * 2);

                if (Flag)
                {
                    SelectedValue.SubItems[4].Text = Sukuranburu.GetString("{NoLowercase}");
                    SelectedSlot.UpdateOffset_Byte(Offset, 0);
                }
                else
                {
                    SelectedValue.SubItems[4].Text = Sukuranburu.GetString("{YesLowercase}");
                    SelectedSlot.UpdateOffset_Byte(Offset, 1);
                }
            }
        }

        private void ChangeSeeStatusButton_Click(object sender, EventArgs e)
        {
            bool Flag = false;
            if (RecordInvListView.SelectedItems.Count > 0)
            {
                Flag = RecordInvListView.SelectedItems[0].SubItems[5].Text == Sukuranburu.GetString("{YesLowercase}");
            }

            foreach (ListViewItem SelectedValue in RecordInvListView.SelectedItems)
            {
                int SaveId = Convert.ToInt32(SelectedValue.SubItems[1].Text);
                int Offset = Offsets.RecordInv_First + (SaveId * 2);

                if (Flag)
                {
                    SelectedValue.SubItems[5].Text = Sukuranburu.GetString("{NoLowercase}");
                    SelectedSlot.UpdateOffset_Byte(Offset + 1, 0);
                }
                else
                {
                    SelectedValue.SubItems[5].Text = Sukuranburu.GetString("{YesLowercase}");
                    SelectedSlot.UpdateOffset_Byte(Offset + 1, 1);
                }
            }
        }
    }
}
