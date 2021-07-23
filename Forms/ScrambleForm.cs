using Scramble.Classes;
using System;
using System.Windows.Forms;
using System.IO;
using Scramble.GameData;

namespace Scramble
{
    public partial class ScrambleForm : Form
    {
        public SaveFile OpenedSaveFile;

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
                this.Height = 400;
                this.Width = 550;
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

            //to-do: make get offset data methods @SaveData class
            InitializedSlotCheckbox.Checked = SelectedSlot.IsValid_Boolean;
            DifficultyCombo.SelectedIndex = Convert.ToInt32(SelectedSlot.Data[Offsets.Difficulty]);
            CurrentLevelNUpDown.Value = BitConverter.ToUInt32(SelectedSlot.Data, Offsets.CurrentLevel);
            MoneyNUpDown.Value = BitConverter.ToUInt32(SelectedSlot.Data, Offsets.Money);
            FpNumericUpDown.Value = BitConverter.ToUInt16(SelectedSlot.Data, Offsets.Fp);
            ExpNumericUpDown.Value = BitConverter.ToUInt32(SelectedSlot.Data, Offsets.Experience);
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
            SelectedSlot.UpdateOffset_Int16(Offsets.CurrentLevel, (short)CurrentLevelNUpDown.Value);
        }

        private void MoneyNUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_Int32(Offsets.Money, (int)MoneyNUpDown.Value);
        }

        private void FpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_Int16(Offsets.Fp, (short)FpNumericUpDown.Value);
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
    }
}
