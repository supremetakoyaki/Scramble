using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class PinInventoryEditor : Form
    {
        public SaveData SelectedSlot
        {
            get
            {
                return Program.Sukuranburu.SelectedSlot;
            }
        }

        public const int EMPTY_PIN_ID = 0xFFFF;
        private List<InventoryPin> InventoryPins;
        

        public PinInventoryEditor()
        {
            InitializeComponent();
            Serialize();
            SerializeGlobal();
        }

        public void Serialize()
        {
            InventoryPins = new List<InventoryPin>();

            // Pin data:
            // int16: pin ID
            // int16: level
            // int16: experience
            // int16: i have no idea.

            for (int CurrentPointer = Offsets.PinInv_First; CurrentPointer < Offsets.PinInv_Last; CurrentPointer += 8)
            {
                ushort PinId = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer);

                if (PinId != EMPTY_PIN_ID)
                {
                    ushort Level = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 2);
                    if (Level == 0x81) // investigate this.
                    {
                        Level = 1;
                    }

                    ushort Experience = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 4);
                    // UNUSED?: ushort Unknown = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 6);

                    InventoryPin PinToAdd = new InventoryPin(PinId, Level, Experience);
                    int Index = InventoryPins.IndexOf(PinToAdd);

                    if (Index == -1)
                    {
                        InventoryPins.Add(PinToAdd);
                    }
                    else
                    {
                        if (InventoryPins[Index].Amount < 100)
                        {
                            InventoryPins[Index].Amount += 1;
                        }
                    }
                }
            }

            foreach (InventoryPin Pin in InventoryPins)
            {
                InsertPinToListView(Pin);
            }

            if (MyPinInventoryView.Items.Count > 0)
            {
                MyPinInventoryView.Items[0].Selected = true;
                MyPinInventoryView.Select();
            }
        }

        public void SerializeGlobal()
        {
            var AllPins = ItemTable.GetPinDictionary();
            
            foreach (int PinId in AllPins.Keys)
            {
                string PinName = ItemTable.GetPinNameWithPinId(PinId);
                string PinIcon = ItemTable.GetPinSpriteWithPinId(PinId) + ".png";

                ListViewItem PinToAdd = new ListViewItem(new string[]
                {
                    PinName,
                    PinId.ToString()
                });

                PinToAdd.ImageKey = PinIcon;
                AllPinsListView.Items.Add(PinToAdd);
            }
        }

        private void SaveAllData()
        {
            int CurrentPointer = Offsets.PinInv_First;

            foreach (InventoryPin Pin in InventoryPins)
            {
                for (int i = 0; i < Pin.Amount || CurrentPointer < Offsets.PinInv_Last; i++)
                {
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer, Pin.PinId);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, Pin.Level);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 4, Pin.Experience);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 6, 0);

                    CurrentPointer += 8;
                }
            }

            // Fill in the blanks.
            for (;  CurrentPointer < Offsets.PinInv_Last; CurrentPointer += 8)
            {
                SelectedSlot.UpdateOffset_UInt16(CurrentPointer, EMPTY_PIN_ID);
                SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, 0);
                SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 4, 0);
                SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 6, 0);
            }
        }

        private void InsertPinToListView(InventoryPin Pin)
        {
            string Name = ItemTable.GetPinNameWithPinId(Pin.PinId);
            string Icon = ItemTable.GetPinSpriteWithPinId(Pin.PinId) + ".png";

            string MasteredSymbol = "—";
            if (ItemTable.PinIsMasterable(Pin.PinId))
            {
                MasteredSymbol = PinIsMastered(Pin.PinId, (byte)Pin.Level) ? "★" : "no";
            }

            ListViewItem PinToAdd = new ListViewItem(new string[]
                   {
                        Name,
                        Pin.PinId.ToString(),
                        Pin.Level.ToString(),
                        Pin.Experience.ToString(),
                        MasteredSymbol,
                        Pin.Amount.ToString()
                   });

            PinToAdd.ImageKey = Icon;
            MyPinInventoryView.Items.Add(PinToAdd);
        }

        private void SelectPin()
        {
            if (MyPinInventoryView.Items.Count < 1)
            {
                PinNameLabel.Text = "(No selected pin)";

                RemovePinButton.Enabled = false;
                MasterPinButton.Enabled = false;
                UpdatePinButton.Enabled = false;
                PinAmountUpDown.Enabled = false;
                PinImagePictureBox.Image = null;

                PinLevelNUpDown.Enabled = false;
                ExperienceNUpDown.Enabled = false;
                PinAmountUpDown.Enabled = false;

                MasteredLabel.Text = string.Empty;

                PinLevelNUpDown.Value = 1;
                ExperienceNUpDown.Value = 0;
                PinAmountUpDown.Value = 1;
                return;
            }

            if (MyPinInventoryView.SelectedItems.Count != 1)
            {
                return;
            }

            InventoryPin Pin = InventoryPins[MyPinInventoryView.SelectedIndices[0]];

            string PinName = ItemTable.GetPinNameWithPinId(Pin.PinId);
            string PinSprite = ItemTable.GetPinSpriteWithPinId(Pin.PinId) + ".png";

            PinNameLabel.Text = PinName;
            PinImagePictureBox.Image = this.PinImageList_Big.Images[PinSprite];

            RemovePinButton.Enabled = true;
            UpdatePinButton.Enabled = true;
            PinAmountUpDown.Enabled = true;

            PinLevelNUpDown.Enabled = true;
            ExperienceNUpDown.Enabled = true;
            PinAmountUpDown.Enabled = true;

            if (ItemTable.PinIsMasterable(Pin.PinId))
            {
                MasterPinButton.Enabled = true;

                if (PinIsMastered(Pin.PinId, (byte)Pin.Level))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }
            else
            {
                MasterPinButton.Enabled = false;
            }

            PinLevelNUpDown.Value = Pin.Level;
            ExperienceNUpDown.Value = Pin.Experience;
            PinAmountUpDown.Value = Pin.Amount;
        }

        private void UpdatePinButton_Click(object sender, EventArgs e)
        {

        }

        private void MyPinInventoryView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPin();
        }

        private bool PinIsMastered(ushort PinId, byte Level)
        {
            return ItemTable.GetPinMaxLevelWithPinId(PinId) == Level && ItemTable.PinIsMasterable(PinId);
        }

        private void RemovePinButton_Click(object sender, EventArgs e)
        {
            if (MyPinInventoryView.Items.Count > 0 && MyPinInventoryView.SelectedIndices.Count > 0)
            {
                int ThisIndex = MyPinInventoryView.SelectedIndices[0];
                InventoryPin Pin = InventoryPins[ThisIndex];

                MyPinInventoryView.Items.RemoveAt(ThisIndex);
                InventoryPins.Remove(Pin);
            }

            SelectPin();
        }

        private void PinInventoryEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllData();
        }
    }
}
