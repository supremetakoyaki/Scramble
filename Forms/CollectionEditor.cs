using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class CollectionEditor : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private List<ushort> MasteredPins;
        private bool MasterAllPinsFlag;
        private const uint UNASSIGNED = 0xFFFF;

        public CollectionEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            RecordInvListView.SmallImageList = Sukuranburu.ItemImageList_32x32;

            if (Sukuranburu.RequiresRescaling)
            {
                RecordInvListView.AutoSize = true;
            }

            MasterAllPinsFlag = false;
            LoadMasteredPins();
            Serialize();
        }

        private void LoadMasteredPins()
        {
            MasteredPins = new List<ushort>(400);

            for (int i = Offsets.MasteredPins_First; i < Offsets.MasteredPins_Last; i += 4)
            {
                uint PinId_UInt = SelectedSlot.RetrieveOffset_UInt32(i);
                if (PinId_UInt != UNASSIGNED && PinId_UInt <= ushort.MaxValue)
                {
                    ushort PinId = (ushort)PinId_UInt;
                    if (!MasteredPins.Contains(PinId))
                    {
                        MasteredPins.Add(PinId);
                    }
                }
            }
        }

        private void SaveMasteredPins()
        {
            if (MasteredPins == null)
            {
                return;
            }

            int Index = 0;
            for (int i = Offsets.MasteredPins_First; i < Offsets.MasteredPins_Last; i += 4)
            {
                if (MasteredPins.Count > Index)
                {
                    SelectedSlot.UpdateOffset_UInt32(i, MasteredPins[Index]); // It is 4 bytes in the save after all...!
                }
                else
                {
                    SelectedSlot.UpdateOffset_UInt32(i, UNASSIGNED);
                }

                Index++;
            }
        }

        private string GetMasteredStatus(IGameItem Item)
        {
            if (Item.Type == ItemType.Pin && MasteredPins != null && Sukuranburu.GetItemManager().PinIsMasterable((PinItem)Item))
            {
                return MasteredPins.Contains(Item.ParticularId) ? Sukuranburu.GetString("{YesLowercase}") + " ★" : Sukuranburu.GetString("{NoLowercase}");
            }

            return "—";
        }

        private void Serialize()
        {
            Dictionary<int, ushort> RecordDictionary = Sukuranburu.GetItemManager().GetSaveIndexes();

            foreach (int SaveId in RecordDictionary.Keys)
            {
                ushort GlobalId = RecordDictionary[SaveId];
                IGameItem Item = Sukuranburu.GetItemManager().GetItem(GlobalId);

                string Name = Sukuranburu.GetGameString(Item.Name);
                string TypeStr = Item.Type.ToString();

                int CurrentPointer = Offsets.RecordInv_First + (SaveId * 2);

                bool Unlocked = SelectedSlot.RetrieveOffset_Byte(CurrentPointer) == 1;
                bool Flag = SelectedSlot.RetrieveOffset_Byte(CurrentPointer + 1) == 1;
                string MasteredStatus = GetMasteredStatus(Item);

                ListViewItem ItemToAdd = new ListViewItem(new string[] { Name, SaveId.ToString(), GlobalId.ToString(), TypeStr, Unlocked ? Sukuranburu.GetString("{YesLowercase}") : Sukuranburu.GetString("{NoLowercase}"), Flag ? Sukuranburu.GetString("{YesLowercase}") : Sukuranburu.GetString("{NoLowercase}"), MasteredStatus })
                {
                    ImageKey = Item.Sprite
                };

                RecordInvListView.Items.Add(ItemToAdd);
            }


            DisplayLanguageStrings();
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{CollectionEditor}");
            groupBox1.Text = Sukuranburu.GetString("{Items}");
            SaveIDHeader.Text = Sukuranburu.GetString("{SaveId}");
            ItemNameHeader.Text = Sukuranburu.GetString("{Name}");
            ItemIDHeader.Text = Sukuranburu.GetString("{ItemId}");
            TypeHeader.Text = Sukuranburu.GetString("{Type}");
            UnlockedHeader.Text = Sukuranburu.GetString("{Unlocked}");
            FlagHeader.Text = Sukuranburu.GetString("{Unseen}");
            UnlockAllButton.Text = Sukuranburu.GetString("{UnlockAll}");
            UnseeAllButton.Text = Sukuranburu.GetString("{UnseeAll}");
            ChangeLockStatusButton.Text = Sukuranburu.GetString("{UnlockSelected}");
            ChangeSeeStatusButton.Text = Sukuranburu.GetString("{UnseeSelected}");
            PinMasteredHeader.Text = Sukuranburu.GetString("{Mastered}");
            UnmasterAllPins_Button.Text = Sukuranburu.GetString("{UnmasterAllPins}");
            UnmasterSelectedPins_Button.Text = Sukuranburu.GetString("{UnmasterSelected}");
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

        private void UnmasterAllPins_Button_Click(object sender, EventArgs e)
        {
            MasterAllPinsFlag = !MasterAllPinsFlag;

            foreach (ListViewItem Item in RecordInvListView.Items)
            {
                if (Item.SubItems[3].Text == "Pin")
                {
                    ushort GlobalId = Convert.ToUInt16(Item.SubItems[2].Text);
                    PinItem Pin = Sukuranburu.GetItemManager().GetItem(GlobalId) as PinItem;

                    if (Pin != null && Sukuranburu.GetItemManager().PinIsMasterable(Pin))
                    {
                        if (MasterAllPinsFlag && !MasteredPins.Contains(Pin.ParticularId))
                        {
                            MasteredPins.Add(Pin.ParticularId);
                        }
                        else if (!MasterAllPinsFlag)// actually not necessary: && MasteredPins.Contains(Pin.ParticularId))
                        {
                            MasteredPins.Remove(Pin.ParticularId);
                        }
                    }
                }
            }

            RecordInvListView.Items.Clear();
            Serialize();
        }

        private void UnmasterSelectedPins_Button_Click(object sender, EventArgs e)
        {
            if (RecordInvListView.SelectedItems.Count < 1)
            {
                return;
            }

            bool Flag = RecordInvListView.SelectedItems[0].SubItems[6].Text == Sukuranburu.GetString("{NoLowercase}") || RecordInvListView.SelectedItems[0].SubItems[6].Text == "—";

            foreach (ListViewItem SelectedValue in RecordInvListView.SelectedItems)
            {
                if (SelectedValue.SubItems[3].Text == "Pin")
                {
                    ushort GlobalId = Convert.ToUInt16(SelectedValue.SubItems[2].Text);
                    PinItem Pin = Sukuranburu.GetItemManager().GetItem(GlobalId) as PinItem;

                    if (Pin != null && Sukuranburu.GetItemManager().PinIsMasterable(Pin))
                    {
                        if (Flag && !MasteredPins.Contains(Pin.ParticularId))
                        {
                            MasteredPins.Add(Pin.ParticularId);
                        }
                        else if (!Flag)// unnecessary actually: && MasteredPins.Contains(Pin.ParticularId))
                        {
                            MasteredPins.Remove(Pin.ParticularId);
                        }

                        SelectedValue.SubItems[6].Text = GetMasteredStatus(Pin);
                    }
                }
            }
        }

        private void CollectionEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveMasteredPins();
            ColumnSorter.DisposeColumn();
        }

        private void RecordInvListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(RecordInvListView, e);
        }
    }
}
