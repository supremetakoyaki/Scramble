using Scramble.Classes;
using System;
using System.Windows.Forms;
using System.IO;
using Scramble.GameData;
using Scramble.Forms;
using System.Diagnostics;

namespace Scramble
{
    public partial class ScrambleForm : Form
    {
        public SaveFile OpenedSaveFile;
        public RecordsEditor RecordsEditor;

        public SaveData SelectedSlot
        {
            get
            {
                if (OpenedSaveFile == null)
                {
                    return null;
                }

                return OpenedSaveFile.GetSaveSlot(SaveSlotsListBox.SelectedIndex);
            }
        }

        public ScrambleForm()
        {
            InitializeComponent();

            this.DateOfSavePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.Height = 148;
            this.Width = 300;
            this.Text = "Scramble";
        }

        private void ShowWarning(string Message)
        {
            MessageBox.Show(Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowNotice(string Message)
        {
            MessageBox.Show(Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ShowPrompt(string Message)
        {
            return MessageBox.Show(Message, "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OpenSaveFileButton_Click(object sender, EventArgs e)
        {
            if (OpenedSaveFile != null && ShowPrompt(DialogMessages.SaveDataAlreadyOpened) == false)
            {
                return;
            }

            OpenFileDialog Dialog = new OpenFileDialog();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(Dialog.FileName))
                {
                    ShowWarning(DialogMessages.FileNotFound);
                    return;
                }

                byte[] AllData = File.ReadAllBytes(Dialog.FileName);
                byte Result;

                OpenedSaveFile = new SaveFile(Dialog.FileName, AllData, out Result);

                if (Result == 0) // invalid file size
                {
                    ShowWarning(DialogMessages.InvalidSaveFile);
                    OpenedSaveFile = null;
                }

                this.SaveSlotsListBox.SelectedIndex = 0;
                this.Height = 409;
                this.Width = 556;
                this.Text = "Scramble — NEO TWEWY Save Editor";
            }
        }
        private void SelectSlot(int Id)
        {
            if (SelectedSlot.UnixTimestamp_Integer == 0)
            {
                DateOfSavePicker.Value = DateOfSavePicker.MinDate;
            }
            else
            {
                DateOfSavePicker.Value = DateTimeOffset.FromUnixTimeSeconds(SelectedSlot.UnixTimestamp_Integer).DateTime;
            }

            InitializedSlotCheckbox.Checked = SelectedSlot.IsValid_Boolean;
            DifficultyCombo.SelectedIndex = SelectedSlot.RetrieveOffset_Byte(Offsets.Difficulty);
            ExpNumericUpDown.Value = SelectedSlot.RetrieveOffset_Int32(Offsets.Experience);
            CurrentLevelNUpDown.Value = SelectedSlot.RetrieveOffset_UInt16(Offsets.CurrentLevel);
            MoneyNUpDown.Value = SelectedSlot.RetrieveOffset_Int32(Offsets.Money);
            FpNumericUpDown.Value = SelectedSlot.RetrieveOffset_UInt16(Offsets.Fp);
        }

        private void SaveSlotsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OpenedSaveFile != null)
            {
                SelectSlot(SaveSlotsListBox.SelectedIndex);
            }
        }
        private void DateOfSavePicker_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateUnix(DateOfSavePicker.Value.Date);
        }

        private void TimeOfSavePicker_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateUnix(DateOfSavePicker.Value.Date);
        }

        private void DifficultyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_Byte(Offsets.Difficulty, (byte)DifficultyCombo.SelectedIndex);
        }

        private void CurrentLevelNUpDown_ValueChanged(object sender, EventArgs e)
        {
            ushort MaxTheoreticalLevel = (ushort)LevelTable.GetLevel((int)ExpNumericUpDown.Value);
            if ((ushort)CurrentLevelNUpDown.Value > MaxTheoreticalLevel)
            {
                CurrentLevelNUpDown.Value = MaxTheoreticalLevel;
            }

            SelectedSlot.UpdateOffset_UInt16(Offsets.CurrentLevel, (ushort)CurrentLevelNUpDown.Value);
        }

        private void MoneyNUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_Int32(Offsets.Money, (int)MoneyNUpDown.Value);
        }

        private void FpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_UInt16(Offsets.Fp, (ushort)FpNumericUpDown.Value);
        }

        private void InitializedSlotCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SelectedSlot.IsValid = InitializedSlotCheckbox.Checked ? (byte)1 : (byte)0;
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            if (BackupCheckbox.Checked == false)
            {
                if (ShowPrompt(DialogMessages.BackupCheckboxNotChecked) == false)
                {
                    return;
                }
            }
            else
            {
                // make a copy of the unmodified save file...
                File.Copy(OpenedSaveFile.FilePath, OpenedSaveFile.FilePath + " (" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ").bak");
            }

            File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
            ShowNotice(DialogMessages.SaveDataSaved);
        }

        private void ExpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_Int32(Offsets.Experience, (int)ExpNumericUpDown.Value);
            LvLabel.Text = "Lv." + LevelTable.GetLevel((int)ExpNumericUpDown.Value);
        }

        private void OpenRecordEditButton_Click(object sender, EventArgs e)
        {
            RecordsEditor = new RecordsEditor();
            RecordsEditor.ShowDialog();
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/supremetakoyaki/Scramble");
        }
    }
}
