using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Properties;
using Scramble.Util;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class NoisepediaEditor : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private bool ReadyForUserInput = false;
        private bool UnlockAll_Flag = false;

        public NoisepediaEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (Sukuranburu.RequiresRescaling)
            {
                NoisepediaListView.AutoSize = true;
            }

            DisplayLanguageStrings();
            SerializeNoisepedia();
            SelectNoise();
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{NoisepediaEditor}");
            NoiseListGroupBox.Text = Sukuranburu.GetString("{NoiseList}");
            SortedIdHeader.Text = Sukuranburu.GetString("{#}");
            NoiseIdHeader.Text = Sukuranburu.GetString("{Id}");
            NameHeader.Text = Sukuranburu.GetString("{Name}");

            UnlockAllButton.Text = Sukuranburu.GetString("{UnlockAll}");
            UnlockAll_PinsCheckbox.Text = Sukuranburu.GetString("{Pins}");

            NoiseInfo_GroupBox.Text = Sukuranburu.GetString("{NoiseInfo}");
            Hp_Label.Text = Sukuranburu.GetString("{Hp:}");
            Exp_Label.Text = Sukuranburu.GetString("{EXP:}");
            Pp_Label.Text = Sukuranburu.GetString("{Pp:}");
            Encountered_Checkbox.Text = Sukuranburu.GetString("{Encountered}");
            RecordLevel_Label.Text = Sukuranburu.GetString("{RecordLevel:}");
            ErasedCount_Label.Text = Sukuranburu.GetString("{ErasedCount:}");

            Easy_Label.Text = Sukuranburu.GetGameString("Setting_Difficulty01");
            Normal_Label.Text = Sukuranburu.GetGameString("Setting_Difficulty02");
            Hard_Label.Text = Sukuranburu.GetGameString("Setting_Difficulty03");
            Ultimate_Label.Text = Sukuranburu.GetGameString("Setting_Difficulty04");
        }

        private void SerializeNoisepedia()
        {
            foreach (NoisepediaEntry Entry in Sukuranburu.GetNoiseManager().GetNoisepediaDictionary().Values)
            {
                string NoiseName;

                if (Sukuranburu.ShowSpoilers == false)
                {
                    int Offset = Offsets.Noisepedia_Id0_NotEncounteredYet + (13 * Entry.Id);
                    bool NoiseIsSpoiler = SelectedSlot.RetrieveOffset_Byte(Offset) != 0;

                    if (NoiseIsSpoiler)
                    {
                        NoiseName = Sukuranburu.GetString("{Spoiler}");
                    }
                    else
                    {
                        NoiseName = Sukuranburu.GetGameString(Entry.Name);
                    }
                }
                else
                {
                    NoiseName = Sukuranburu.GetGameString(Entry.Name);
                }

                ListViewItem ItemToAdd = new ListViewItem(new string[]
                {
                    (Entry.SortIndex + 1).ToString(),
                    Entry.NoiseId.ToString(),
                    NoiseName
                })
                {
                    Tag = Entry.Id
                };

                NoisepediaListView.Items.Add(ItemToAdd);
            }

            if (NoisepediaListView.Items.Count > 0)
            {
                NoisepediaListView.Items[0].Selected = true;
                NoisepediaListView.Select();
            }
        }

        private void SelectNoise()
        {
            ReadyForUserInput = false;

            if (NoisepediaListView.SelectedIndices.Count != 1)
            {
                DisplayEmptyNoiseData();
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;
            NoisepediaEntry Entry = Sukuranburu.GetNoiseManager().GetNoisepediaEntry(EntryId);
            if (Entry == null)
            {
                DisplayEmptyNoiseData();
                ReadyForUserInput = true;
                return;
            }

            Noise Noizu = Sukuranburu.GetNoiseManager().GetNoiseWithNoisepediaEntry(Entry);
            if (Noizu == null)
            {
                DisplayEmptyNoiseData();
                ReadyForUserInput = true;
                return;
            }

            DisplayNoiseData(Entry, Noizu);
            ReadyForUserInput = true;
        }

        private void DisplayNoiseData(NoisepediaEntry Entry, Noise Noizu)
        {
            int RecordLevel = SelectedSlot.RetrieveOffset_Int32(Offsets.Noisepedia_Id0_RecordLevel + (13 * Entry.Id));
            int ErasedCount = SelectedSlot.RetrieveOffset_Int32(Offsets.Noisepedia_Id0_Erased + (13 * Entry.Id));
            bool EasyDrop_Unlocked = SelectedSlot.RetrieveOffset_Byte(Offsets.Noisepedia_Id0_EasyPinUnlocked + (13 * Entry.Id)) != 0;
            bool NormalDrop_Unlocked = SelectedSlot.RetrieveOffset_Byte(Offsets.Noisepedia_Id0_NormalPinUnlocked + (13 * Entry.Id)) != 0;
            bool HardDrop_Unlocked = SelectedSlot.RetrieveOffset_Byte(Offsets.Noisepedia_Id0_HardPinUnlocked + (13 * Entry.Id)) != 0;
            bool UltimateDrop_Unlocked = SelectedSlot.RetrieveOffset_Byte(Offsets.Noisepedia_Id0_UltimatePinUnlocked + (13 * Entry.Id)) != 0;
            bool NotEncounteredYet = SelectedSlot.RetrieveOffset_Byte(Offsets.Noisepedia_Id0_NotEncounteredYet + (13 * Entry.Id)) != 0;

            if (Sukuranburu.ShowSpoilers == false && NotEncounteredYet)
            {
                NoiseImgPictureBox.Image = null;
                NoiseSymbol_PictureBox.Image = null;
                BossIcon_PictureBox.Image = null;
            }
            else
            {
                NoiseImgPictureBox.Image = ImageMethods.DrawImageAligned(Entry.NoiseImagePath, 860, 484, 484, 484, 102, 0, DeviceDpi);
                NoiseSymbol_PictureBox.Image = ImageMethods.GetImageAsIs(string.Format("Map_icon_NoiseSymbol_{0}", Entry.SymbolType.ToString("D2")));

                if (NoiseSymbol_PictureBox.Image == null)
                {
                    NoiseSymbol_PictureBox.Image = ImageMethods.DrawImage(string.Format("UI_NoiseSymbol_{0}", Entry.SymbolType.ToString("D2")), 105, 105, DeviceDpi);
                }

                if (Entry.IsBoss)
                {
                    BossIcon_PictureBox.Image = ImageMethods.DrawImage("Boss_icon", 60, 60, DeviceDpi);
                }
                else
                {
                    BossIcon_PictureBox.Image = null;
                }
            }

            if (NotEncounteredYet && Sukuranburu.ShowSpoilers == false)
            {
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), NoiseName_RichTextBox);
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), NoiseDesc_RichTextBox);

                HpValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                ExpValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                PpValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
            }
            else
            {
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(Entry.Name), NoiseName_RichTextBox);
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(Entry.Info), NoiseDesc_RichTextBox);

                HpValue_Label.Text = Noizu.Hp.ToString();
                ExpValue_Label.Text = Noizu.Exp.ToString();
                PpValue_Label.Text = Noizu.Bp.ToString();
            }

            if (RecordLevel < 0 || RecordLevel > 100)
            {
                RecordLevel_NumUpDown.Value = 1;
                RecordLevel_NumUpDown.Enabled = false;
            }
            else
            {
                RecordLevel_NumUpDown.Value = RecordLevel;
                RecordLevel_NumUpDown.Enabled = true;
            }

            if (ErasedCount < 0)
            {
                ErasedCount_NumUpDown.Value = 1;
                ErasedCount_NumUpDown.Enabled = false;
            }
            else if (ErasedCount > 9999)
            {
                ErasedCount_NumUpDown.Value = 9999;
                ErasedCount_NumUpDown.Enabled = true;
            }
            else
            {
                ErasedCount_NumUpDown.Value = ErasedCount;
                ErasedCount_NumUpDown.Enabled = true;
            }

            Pin_Easy_Checkbox.Checked = EasyDrop_Unlocked;
            Pin_Normal_Checkbox.Checked = NormalDrop_Unlocked;
            Pin_Hard_Checkbox.Checked = HardDrop_Unlocked;
            Pin_Ultimate_Checkbox.Checked = UltimateDrop_Unlocked;

            Encountered_Checkbox.Checked = !NotEncounteredYet;

            Pin_Easy_Checkbox.Enabled = true;
            Pin_Normal_Checkbox.Enabled = true;
            Pin_Hard_Checkbox.Enabled = true;
            Pin_Ultimate_Checkbox.Enabled = true;
            Encountered_Checkbox.Enabled = true;

            if (Noizu.DropRate.Length != 4 || Noizu.PinDropId.Length != 4)
            {
                throw new IndexOutOfRangeException();
            }

            if (!Pin_Easy_Checkbox.Checked && Sukuranburu.ShowSpoilers == false)
            {
                Easy_DropRateValue_Label.Text = "?%";

                EasyPinToolTip.SetToolTip(PinDrop_Easy_PictureBox, Sukuranburu.GetString("{Spoiler}"));
                EasyPinToolTip.Active = true;
                PinDrop_Easy_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Spoiler_Pin") as Bitmap, 64, 64, DeviceDpi);
            }
            else
            {
                Easy_DropRateValue_Label.Text = string.Format("{0:0.##}%", Noizu.DropRate[0] * 100);
                PinItem Pin_Easy = Sukuranburu.GetItemManager().GetPinItem(Noizu.PinDropId[0]);

                EasyPinToolTip.SetToolTip(PinDrop_Easy_PictureBox, Sukuranburu.GetGameString(Pin_Easy.Name));
                EasyPinToolTip.Active = true;

                PinDrop_Easy_PictureBox.Image = ImageMethods.DrawImage(Pin_Easy.Sprite, 64, 64, DeviceDpi);
            }

            if (!Pin_Normal_Checkbox.Checked && Sukuranburu.ShowSpoilers == false)
            {
                Normal_DropRateValue_Label.Text = "?%";

                NormalPinToolTip.SetToolTip(PinDrop_Normal_PictureBox, Sukuranburu.GetString("{Spoiler}"));
                NormalPinToolTip.Active = true;
                PinDrop_Normal_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Spoiler_Pin") as Bitmap, 64, 64, DeviceDpi);
            }
            else
            {
                Normal_DropRateValue_Label.Text = string.Format("{0:0.##}%", Noizu.DropRate[1] * 100);
                PinItem Pin_Normal = Sukuranburu.GetItemManager().GetPinItem(Noizu.PinDropId[1]);

                NormalPinToolTip.SetToolTip(PinDrop_Normal_PictureBox, Sukuranburu.GetGameString(Pin_Normal.Name));
                NormalPinToolTip.Active = true;

                PinDrop_Normal_PictureBox.Image = ImageMethods.DrawImage(Pin_Normal.Sprite, 64, 64, DeviceDpi);
            }

            if (!Pin_Hard_Checkbox.Checked && Sukuranburu.ShowSpoilers == false)
            {
                Hard_DropRateValue_Label.Text = "?%";

                HardPinToolTip.SetToolTip(PinDrop_Hard_PictureBox, Sukuranburu.GetString("{Spoiler}"));
                HardPinToolTip.Active = true;
                PinDrop_Hard_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Spoiler_Pin") as Bitmap, 64, 64, DeviceDpi);
            }
            else
            {
                Hard_DropRateValue_Label.Text = string.Format("{0:0.##}%", Noizu.DropRate[2] * 100);
                PinItem Pin_Hard = Sukuranburu.GetItemManager().GetPinItem(Noizu.PinDropId[2]);

                HardPinToolTip.SetToolTip(PinDrop_Hard_PictureBox, Sukuranburu.GetGameString(Pin_Hard.Name));
                HardPinToolTip.Active = true;

                PinDrop_Hard_PictureBox.Image = ImageMethods.DrawImage(Pin_Hard.Sprite, 64, 64, DeviceDpi);
            }

            if (!Pin_Ultimate_Checkbox.Checked && Sukuranburu.ShowSpoilers == false)
            {
                Ultimate_DropRateValue_Label.Text = "?%";

                UltimatePinToolTip.SetToolTip(PinDrop_Ultimate_PictureBox, Sukuranburu.GetString("{Spoiler}"));
                UltimatePinToolTip.Active = true;
                PinDrop_Ultimate_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Spoiler_Pin") as Bitmap, 64, 64, DeviceDpi);
            }
            else
            {
                Ultimate_DropRateValue_Label.Text = string.Format("{0:0.##}%", Noizu.DropRate[3] * 100);
                PinItem Pin_Ultimate = Sukuranburu.GetItemManager().GetPinItem(Noizu.PinDropId[3]);

                UltimatePinToolTip.SetToolTip(PinDrop_Ultimate_PictureBox, Sukuranburu.GetGameString(Pin_Ultimate.Name));
                UltimatePinToolTip.Active = true;

                PinDrop_Ultimate_PictureBox.Image = ImageMethods.DrawImage(Pin_Ultimate.Sprite, 64, 64, DeviceDpi);
            }
        }

        private void DisplayEmptyNoiseData()
        {
            NoiseImgPictureBox.Image = null;
            NoiseSymbol_PictureBox.Image = null;
            BossIcon_PictureBox.Image = null;

            NoiseName_RichTextBox.Clear();
            NoiseDesc_RichTextBox.Clear();
            HpValue_Label.Text = "—";
            ExpValue_Label.Text = "—";
            PpValue_Label.Text = "—";

            RecordLevel_NumUpDown.Value = 1;
            RecordLevel_NumUpDown.Enabled = false;

            ErasedCount_NumUpDown.Value = 1;
            ErasedCount_NumUpDown.Enabled = false;

            Pin_Easy_Checkbox.Checked = false;
            Pin_Normal_Checkbox.Checked = false;
            Pin_Hard_Checkbox.Checked = false;
            Pin_Ultimate_Checkbox.Checked = false;
            Encountered_Checkbox.Checked = false;

            Pin_Easy_Checkbox.Enabled = false;
            Pin_Normal_Checkbox.Enabled = false;
            Pin_Hard_Checkbox.Enabled = false;
            Pin_Ultimate_Checkbox.Enabled = false;
            Encountered_Checkbox.Enabled = false;

            Easy_DropRateValue_Label.Text = "—";
            Normal_DropRateValue_Label.Text = "—";
            Hard_DropRateValue_Label.Text = "—";
            Ultimate_DropRateValue_Label.Text = "—";

            EasyPinToolTip.Active = false;
            NormalPinToolTip.Active = false;
            HardPinToolTip.Active = false;
            UltimatePinToolTip.Active = false;

            PinDrop_Easy_PictureBox.Image = null;
            PinDrop_Normal_PictureBox.Image = null;
            PinDrop_Hard_PictureBox.Image = null;
            PinDrop_Ultimate_PictureBox.Image = null;
        }

        private void UpdateRecordLevel(byte EntryId, int Value)
        {
            SelectedSlot.UpdateOffset_Int32(Offsets.Noisepedia_Id0_RecordLevel + (13 * EntryId), Value);
        }

        private void UpdateErasedCount(byte EntryId, int Value)
        {
            SelectedSlot.UpdateOffset_Int32(Offsets.Noisepedia_Id0_Erased + (13 * EntryId), Value);
        }

        private void UpdateEncountered(byte EntryId, bool Value)
        {
            // Note that the offset is called "NOT ENCOUNTERED YET", so the Value should be passed as the complete opposite!
            SelectedSlot.UpdateOffset_Byte(Offsets.Noisepedia_Id0_NotEncounteredYet + (13 * EntryId), Convert.ToByte(Value));
        }

        private void UpdatePinValue(byte EntryId, byte Difficulty, bool Value)
        {
            SelectedSlot.UpdateOffset_Byte(Offsets.Noisepedia_Id0_EasyPinUnlocked + (13 * EntryId) + Difficulty, Convert.ToByte(Value));
        }

        private void NoisepediaListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectNoise();
            ReadyForUserInput = true;
        }

        private void Encountered_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (NoisepediaListView.SelectedIndices.Count != 1 || (Sukuranburu.ShowSpoilers == false && Encountered_Checkbox.Checked && Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_ActionWillSpoil")) == false))
            {
                Encountered_Checkbox.Checked = !Encountered_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;
            NoisepediaEntry Entry = Sukuranburu.GetNoiseManager().GetNoisepediaEntry(EntryId);
            if (Entry == null)
            {
                Encountered_Checkbox.Checked = !Encountered_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            RecordLevel_NumUpDown.Value = 1;
            ErasedCount_NumUpDown.Value = 1;
            RecordLevel_NumUpDown.Enabled = Encountered_Checkbox.Checked;
            ErasedCount_NumUpDown.Enabled = Encountered_Checkbox.Checked;

            UpdateRecordLevel(Entry.Id, RecordLevel_NumUpDown.Enabled ? 1 : -1);
            UpdateErasedCount(Entry.Id, ErasedCount_NumUpDown.Enabled ? 1 : -1);

            UpdateEncountered(Entry.Id, !Encountered_Checkbox.Checked);

            if (Sukuranburu.ShowSpoilers == false)
            {
                ListViewItem EntryItem = NoisepediaListView.Items.Cast<ListViewItem>().FirstOrDefault(i => (byte)i.Tag == EntryId);
                if (EntryItem != null)
                {
                    if (Encountered_Checkbox.Checked)
                    {
                        EntryItem.SubItems[2].Text = Sukuranburu.GetGameString(Entry.Name);
                    }
                    else
                    {
                        EntryItem.SubItems[2].Text = Sukuranburu.GetString("{Spoiler}");
                    }
                }

                Noise Noizu = Sukuranburu.GetNoiseManager().GetNoiseWithNoisepediaEntry(Entry);
                DisplayNoiseData(Entry, Noizu);
            }

            ReadyForUserInput = true;
        }

        private void Pin_Easy_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (NoisepediaListView.SelectedIndices.Count != 1 || (Sukuranburu.ShowSpoilers == false && Pin_Easy_Checkbox.Checked && Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_ActionWillSpoil")) == false))
            {
                Pin_Easy_Checkbox.Checked = !Pin_Easy_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;
            NoisepediaEntry Entry = Sukuranburu.GetNoiseManager().GetNoisepediaEntry(EntryId);
            if (Entry == null)
            {
                Pin_Easy_Checkbox.Checked = !Pin_Easy_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            UpdatePinValue(EntryId, 0, Pin_Easy_Checkbox.Checked);
            if (Sukuranburu.ShowSpoilers == false)
            {
                Noise Noizu = Sukuranburu.GetNoiseManager().GetNoiseWithNoisepediaEntry(Entry);
                DisplayNoiseData(Entry, Noizu);
            }

            ReadyForUserInput = true;
        }

        private void Pin_Normal_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (NoisepediaListView.SelectedIndices.Count != 1 || (Sukuranburu.ShowSpoilers == false && Pin_Normal_Checkbox.Checked && Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_ActionWillSpoil")) == false))
            {
                Pin_Normal_Checkbox.Checked = !Pin_Normal_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;
            NoisepediaEntry Entry = Sukuranburu.GetNoiseManager().GetNoisepediaEntry(EntryId);
            if (Entry == null)
            {
                Pin_Normal_Checkbox.Checked = !Pin_Normal_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            UpdatePinValue(EntryId, 1, Pin_Normal_Checkbox.Checked);
            if (Sukuranburu.ShowSpoilers == false)
            {
                Noise Noizu = Sukuranburu.GetNoiseManager().GetNoiseWithNoisepediaEntry(Entry);
                DisplayNoiseData(Entry, Noizu);
            }

            ReadyForUserInput = true;
        }

        private void Pin_Hard_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (NoisepediaListView.SelectedIndices.Count != 1 || (Sukuranburu.ShowSpoilers == false && Pin_Hard_Checkbox.Checked && Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_ActionWillSpoil")) == false))
            {
                Pin_Hard_Checkbox.Checked = !Pin_Hard_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;
            NoisepediaEntry Entry = Sukuranburu.GetNoiseManager().GetNoisepediaEntry(EntryId);
            if (Entry == null)
            {
                Pin_Hard_Checkbox.Checked = !Pin_Hard_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            UpdatePinValue(EntryId, 2, Pin_Hard_Checkbox.Checked);
            if (Sukuranburu.ShowSpoilers == false)
            {
                Noise Noizu = Sukuranburu.GetNoiseManager().GetNoiseWithNoisepediaEntry(Entry);
                DisplayNoiseData(Entry, Noizu);
            }

            ReadyForUserInput = true;
        }

        private void Pin_Ultimate_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (NoisepediaListView.SelectedIndices.Count != 1 || (Sukuranburu.ShowSpoilers == false && Pin_Ultimate_Checkbox.Checked && Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_ActionWillSpoil")) == false))
            {
                Pin_Ultimate_Checkbox.Checked = !Pin_Ultimate_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;
            NoisepediaEntry Entry = Sukuranburu.GetNoiseManager().GetNoisepediaEntry(EntryId);
            if (Entry == null)
            {
                Pin_Ultimate_Checkbox.Checked = !Pin_Ultimate_Checkbox.Checked;
                ReadyForUserInput = true;
                return;
            }

            UpdatePinValue(EntryId, 3, Pin_Ultimate_Checkbox.Checked);
            if (Sukuranburu.ShowSpoilers == false)
            {
                Noise Noizu = Sukuranburu.GetNoiseManager().GetNoiseWithNoisepediaEntry(Entry);
                DisplayNoiseData(Entry, Noizu);
            }

            ReadyForUserInput = true;
        }

        private void RecordLevel_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            if (NoisepediaListView.SelectedIndices.Count != 1)
            {
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;

            ReadyForUserInput = false;
            UpdateRecordLevel(EntryId, (int)RecordLevel_NumUpDown.Value);
            ReadyForUserInput = true;
        }

        private void ErasedCount_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            if (NoisepediaListView.SelectedIndices.Count != 1)
            {
                ReadyForUserInput = true;
                return;
            }

            byte EntryId = (byte)NoisepediaListView.SelectedItems[0].Tag;

            ReadyForUserInput = false;
            UpdateErasedCount(EntryId, (int)ErasedCount_NumUpDown.Value);
            ReadyForUserInput = true;
        }

        private void UnlockAllButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }
            else if (UnlockAll_Flag == false && Sukuranburu.ShowSpoilers == false && Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_ActionWillSpoil")) == false)
            {
                return;
            }

            ReadyForUserInput = false;
            UnlockAll_Flag = !UnlockAll_Flag;

            foreach (ListViewItem Item in NoisepediaListView.Items)
            {
                byte EntryId = (byte)Item.Tag;

                UpdateEncountered(EntryId, !UnlockAll_Flag);
                if (UnlockAll_Flag == false)
                {
                    UpdateRecordLevel(EntryId, -1);
                    UpdateErasedCount(EntryId, -1);

                    if (Sukuranburu.ShowSpoilers == false)
                    {
                        Item.SubItems[2].Text = Sukuranburu.GetString("{Spoiler}");
                    }
                }
                else
                {
                    if (Sukuranburu.ShowSpoilers == false && Item.SubItems[2].Text == Sukuranburu.GetString("{Spoiler}"))
                    {
                        NoisepediaEntry Entry = Sukuranburu.GetNoiseManager().GetNoisepediaEntry(EntryId);
                        if (Entry != null)
                        {
                            Item.SubItems[2].Text = Sukuranburu.GetGameString(Entry.Name);
                        }
                    }

                    int RecordLevel = SelectedSlot.RetrieveOffset_Int32(Offsets.Noisepedia_Id0_RecordLevel + (13 * EntryId));
                    int ErasedCount = SelectedSlot.RetrieveOffset_Int32(Offsets.Noisepedia_Id0_Erased + (13 * EntryId));

                    if (RecordLevel == -1)
                    {
                        UpdateRecordLevel(EntryId, 1);
                    }

                    if (ErasedCount == -1)
                    {
                        UpdateErasedCount(EntryId, 1);
                    }
                }

                if (UnlockAll_PinsCheckbox.Checked)
                {
                    UpdatePinValue(EntryId, 0, UnlockAll_Flag);
                    UpdatePinValue(EntryId, 1, UnlockAll_Flag);
                    UpdatePinValue(EntryId, 2, UnlockAll_Flag);
                    UpdatePinValue(EntryId, 3, UnlockAll_Flag);
                }
            }

            SelectNoise();
            ReadyForUserInput = true;
        }

        private void NoisepediaListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(NoisepediaListView, e);
        }

        private void NoisepediaEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ColumnSorter.DisposeColumn();
        }
    }
}
