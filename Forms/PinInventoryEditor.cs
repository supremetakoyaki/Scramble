using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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

        public ScrambleForm Sukuranburu
        {
            get
            {
                return Program.Sukuranburu;
            }
        }

        public const int EMPTY_PIN_ID = 0xFFFF;
        private List<InventoryPin> InventoryPins;
        private InventoryPin SelectedPin;

        bool ReadyForUserInput = false; // flag that indicates whether the editor is working on changing values on its own.    

        public PinInventoryEditor()
        {
            InitializeComponent();

            Serialize();
            SerializeGlobal();
            ReadyForUserInput = true;
        }

        public void Serialize()
        {
            InventoryPins = new List<InventoryPin>();

            // Pin data:
            // int16: pin ID
            // int16: level
            // int16: experience
            // int16: i have no idea.

            // IDEA: I could, for the sake of convenience, use the value in offset "PinInv_Count".
            // I will think about it.

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
            // Pin data:
            // int16: pin ID
            // int16: level
            // int16: experience
            // int16: i have no idea.

            int CurrentPointer = Offsets.PinInv_First;
            int PinCount = 0;

            foreach (InventoryPin Pin in InventoryPins)
            {
                for (int i = 0; i < Pin.Amount; i++)
                {
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer, Pin.PinId);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, Pin.Level);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 4, Pin.Experience);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 6, 0);

                    CurrentPointer += 8;
                    PinCount += 1;
                }
            }

            // Fill in the blanks.
            for (int i = CurrentPointer; i < Offsets.PinInv_Last; i += 8)
            {
                SelectedSlot.UpdateOffset_UInt16(i, EMPTY_PIN_ID);
                SelectedSlot.UpdateOffset_UInt16(i + 2, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 4, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 6, 0);
            }

            SelectedSlot.UpdateOffset_Int32(Offsets.PinInv_Count, PinCount);
            SelectedSlot.UpdateOffset_Int32(Offsets.PinInv_LastIndex, PinCount - 1);
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
            ReadyForUserInput = false;

            if (MyPinInventoryView.SelectedIndices.Count == 0 || MyPinInventoryView.SelectedItems.Count != 1 || MyPinInventoryView.Items.Count < 1)
            {
                PinNameLabel.Text = "(No selected pin)";

                RemovePinButton.Enabled = false;
                MasterPinButton.Enabled = false;
                UpdatePinButton.Enabled = false;
                PinAmountUpDown.Enabled = false;
                PinImagePictureBox.Image = null;
                BrandPictureBox.Image = null;

                PinLevelNUpDown.Enabled = false;
                ExperienceNUpDown.Enabled = false;
                PinAmountUpDown.Enabled = false;

                MaxLevelLabel_Value.Text = "—";
                MasteredLabel.Text = string.Empty;

                PinLevelNUpDown.Value = 1;
                ExperienceNUpDown.Value = 0;
                PinAmountUpDown.Value = 1;
                SelectedPin = null;

                ReadyForUserInput = true;
                return;
            }

            InventoryPin Pin = InventoryPins[MyPinInventoryView.SelectedIndices[0]];
            SelectedPin = Pin;

            byte BrandId = ItemTable.GetPinBrandWithPinId(Pin.PinId);

            string PinName = ItemTable.GetPinNameWithPinId(Pin.PinId);
            string PinSprite = ItemTable.GetPinSpriteWithPinId(Pin.PinId) + ".png";
            string BrandSprite = ItemTable.GetBrandSprite(BrandId) + ".png";

            PinNameLabel.Text = PinName;
            BrandLabel.Text = ItemTable.GetBrandName(BrandId);
            PinImagePictureBox.Image = this.PinImageList_Big.Images[PinSprite];
            BrandPictureBox.Image = this.BrandImageList.Images[BrandSprite];

            RemovePinButton.Enabled = true;
            UpdatePinButton.Enabled = true;
            PinAmountUpDown.Enabled = true;

            PinLevelNUpDown.Enabled = true;
            ExperienceNUpDown.Enabled = true;
            PinAmountUpDown.Enabled = true;

            MaxLevelLabel_Value.Text = ItemTable.GetPinMaxLevelWithPinId(Pin.PinId).ToString();

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

            ReadyForUserInput = true;
        }

        private void UpdatePinButton_Click(object sender, EventArgs e)
        {
            UpdateLevelAndExperience();
            UpdateAmount();
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

                if (ThisIndex > 0)
                {
                    if (MyPinInventoryView.Items.Count > ThisIndex)
                    {
                        MyPinInventoryView.Items[ThisIndex].Selected = true;
                        MyPinInventoryView.Select();
                    }
                    else if (MyPinInventoryView.Items.Count == ThisIndex)
                    {
                        MyPinInventoryView.Items[ThisIndex - 1].Selected = true;
                        MyPinInventoryView.Select();
                    }
                    else
                    {
                        SelectPin();
                    }

                }
                else
                {
                    SelectPin();
                }
            }
        }

        private void PinInventoryEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllData();
        }

        private void MyPinInventoryView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemovePinButton_Click(sender, e);
            }
        }

        private void PinLevelNUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (SelectedPin == null || PinLevelNUpDown.Value < PinLevelNUpDown.Minimum)
            {
                PinLevelNUpDown.Value = PinLevelNUpDown.Minimum;
                ReadyForUserInput = true;
                return;
            }
            else if (PinLevelNUpDown.Value > PinLevelNUpDown.Maximum)
            {
                PinLevelNUpDown.Value = PinLevelNUpDown.Maximum;
            }

            // Check for validity
            byte LevelToSet = (byte)PinLevelNUpDown.Value;
            byte MaxPossibleLevel = ItemTable.GetPinMaxLevelWithPinId(SelectedPin.PinId);

            if (LevelToSet > MaxPossibleLevel)
            {
                LevelToSet = MaxPossibleLevel;
                PinLevelNUpDown.Value = LevelToSet;
            }

            ushort ExperienceToSet = (ushort)ExperienceNUpDown.Value;
            int ReqExperienceAtThisLevel = ItemTable.GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, LevelToSet);
            int MaxPossibleExperience = ItemTable.GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, MaxPossibleLevel);

            if (ExperienceToSet > MaxPossibleExperience)
            {
                ExperienceToSet = (ushort)MaxPossibleExperience;
                ExperienceNUpDown.Value = ExperienceToSet;
            }
            else
            {
                ExperienceToSet = (ushort)ReqExperienceAtThisLevel;
                ExperienceNUpDown.Value = ExperienceToSet;
            }

            if (ItemTable.PinIsMasterable(SelectedPin.PinId))
            {
                if (PinIsMastered(SelectedPin.PinId, (byte)PinLevelNUpDown.Value))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }

            if (AutoUpdateCheckbox.Checked)
            {
                UpdateLevelAndExperience();
            }

            ReadyForUserInput = true;
        }

        private void ExperienceNUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (SelectedPin == null || ExperienceNUpDown.Value < ExperienceNUpDown.Minimum)
            {
                ExperienceNUpDown.Value = ExperienceNUpDown.Minimum;
                ReadyForUserInput = true;
                return;
            }
            else if (ExperienceNUpDown.Value > ExperienceNUpDown.Maximum)
            {
                ExperienceNUpDown.Value = ExperienceNUpDown.Maximum;
            }

            // Check for validity
            byte LevelToSet = (byte)PinLevelNUpDown.Value;
            ushort ExperienceToSet = (ushort)ExperienceNUpDown.Value;
            byte MaxPossibleLevel = ItemTable.GetPinMaxLevelWithPinId(SelectedPin.PinId);
            ushort MaxPossibleExperience = (ushort)ItemTable.GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, MaxPossibleLevel);

            if (ExperienceToSet >= MaxPossibleExperience)
            {
                ExperienceToSet = MaxPossibleExperience;
                LevelToSet = MaxPossibleLevel;
            }
            else
            {
                LevelToSet = ItemTable.GetPinLevelWithPinIdAndExperience(SelectedPin.PinId, (short)ExperienceToSet);
            }

            ExperienceNUpDown.Value = ExperienceToSet;
            PinLevelNUpDown.Value = LevelToSet;

            if (ItemTable.PinIsMasterable(SelectedPin.PinId))
            {
                if (PinIsMastered(SelectedPin.PinId, (byte)PinLevelNUpDown.Value))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }

            if (AutoUpdateCheckbox.Checked)
            {
                UpdateLevelAndExperience();
            }

            ReadyForUserInput = true;
        }

        private void MasterPinButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (SelectedPin == null)
            {
                ReadyForUserInput = true;
                return;
            }

            byte MaxPossibleLevel = ItemTable.GetPinMaxLevelWithPinId(SelectedPin.PinId);
            ushort MaxPossibleExperience = (ushort)ItemTable.GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, MaxPossibleLevel);

            ExperienceNUpDown.Value = MaxPossibleExperience;
            PinLevelNUpDown.Value = MaxPossibleLevel;

            if (ItemTable.PinIsMasterable(SelectedPin.PinId))
            {
                if (PinIsMastered(SelectedPin.PinId, (byte)PinLevelNUpDown.Value))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }

            if (AutoUpdateCheckbox.Checked)
            {
                UpdateLevelAndExperience();
            }

            ReadyForUserInput = true;
        }

        private void UpdateLevelAndExperience()
        {
            int Index = InventoryPins.IndexOf(SelectedPin);

            SelectedPin.Level = (ushort)PinLevelNUpDown.Value;
            SelectedPin.Experience = (ushort)ExperienceNUpDown.Value;

            MyPinInventoryView.Items[Index].SubItems[2].Text = SelectedPin.Level.ToString();
            MyPinInventoryView.Items[Index].SubItems[3].Text = SelectedPin.Experience.ToString();

            if (ItemTable.PinIsMasterable(SelectedPin.PinId))
            {
                MyPinInventoryView.Items[Index].SubItems[4].Text = PinIsMastered(SelectedPin.PinId, (byte)SelectedPin.Level) ? "★" : "no";
            }
        }

        private void PinAmountUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            ushort AmountToSet = (ushort)PinAmountUpDown.Value;

            if (AmountToSet < (ushort)PinAmountUpDown.Minimum)
            {
                AmountToSet = (ushort)PinAmountUpDown.Minimum;
            }
            else if (AmountToSet > (ushort)PinAmountUpDown.Maximum)
            {
                AmountToSet = (ushort)PinAmountUpDown.Maximum;
            }

            if (AutoUpdateCheckbox.Checked)
            {
                UpdateAmount();
            }

            ReadyForUserInput = true;
        }

        private void UpdateAmount()
        {
            int Index = InventoryPins.IndexOf(SelectedPin);

            SelectedPin.Amount = (ushort)PinAmountUpDown.Value;
            MyPinInventoryView.Items[Index].SubItems[5].Text = SelectedPin.Amount.ToString();
        }

        private void RemoveAllPinsButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (Sukuranburu.ShowPrompt(DialogMessages.DeleteAllPinsAreYouSure))
            {
                MyPinInventoryView.Items.Clear();
                InventoryPins.Clear();
                SelectedPin = null;

                SelectPin();
            }

            ReadyForUserInput = true;
        }

        private void AddPinButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (AllPinsListView.SelectedIndices.Count < 1)
            {
                Sukuranburu.ShowWarning(DialogMessages.NoPinToAddSelected);
                ReadyForUserInput = true;
                return;
            }

            ListViewItem Item = AllPinsListView.SelectedItems[0];

            AddPin(Item, true);

            SelectPin();
            ReadyForUserInput = true;
        }

        private void AddAllPinsButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }
            ReadyForUserInput = false;

            foreach (ListViewItem Item in AllPinsListView.Items)
            {
                AddPin(Item, false);
            }

            SelectPin();
            ReadyForUserInput = true;
        }

        private void AddPin(ListViewItem Item, bool Individual) //individual= adding this pin through "Add pin" button.
        {
            ushort PinId = Convert.ToUInt16(Item.SubItems[1].Text);

            ushort Level = 1;
            ushort Experience = 0;

            if (ItemTable.PinIsMasterable(PinId) && AddedPinIsMasteredCheckbox.Checked)
            {
                Level = ItemTable.GetPinMaxLevelWithPinId(PinId);
                Experience = (ushort)ItemTable.GetPinExperienceWithPinIdAndLevel(PinId, (byte)Level);
            }

            InventoryPin PinToAdd = new InventoryPin(PinId, Level, Experience);

            if (InventoryPins.Contains(PinToAdd))
            {
                int Index = InventoryPins.IndexOf(PinToAdd);
                if (Individual && InventoryPins[Index].Amount == 99)
                {
                    Sukuranburu.ShowWarning(DialogMessages.YouCantAddMorePins);
                    ReadyForUserInput = true;
                    return;
                }

                if (Add99Checkbox.Checked)
                {
                    InventoryPins[Index].Amount = 99;
                }
                else
                {
                    InventoryPins[Index].Amount += 1;
                }

                MyPinInventoryView.Items[Index].SubItems[5].Text = InventoryPins[Index].Amount.ToString();
            }
            else
            {
                if (Add99Checkbox.Checked)
                {
                    PinToAdd.Amount = 99;
                }
                else
                {
                    PinToAdd.Amount = 1;
                }

                InventoryPins.Add(PinToAdd);
                InsertPinToListView(PinToAdd);
            }
        }
    }
}
