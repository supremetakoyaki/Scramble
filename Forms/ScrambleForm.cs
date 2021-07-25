using Scramble.Classes;
using Scramble.Forms;
using Scramble.GameData;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scramble
{
    public partial class ScrambleForm : Form
    {
        public SaveFile OpenedSaveFile;
        public RecordsEditor RecordsEditor;
        public PinInventoryEditor PinInvEditor;

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
            this.Width = 309;
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

            // Check for valid data
            byte Player_Difficulty = SelectedSlot.RetrieveOffset_Byte(Offsets.Difficulty);
            int Player_Experience = SelectedSlot.RetrieveOffset_Int32(Offsets.Experience);
            ushort Player_Current_Level = SelectedSlot.RetrieveOffset_UInt16(Offsets.CurrentLevel);
            int Player_Money = SelectedSlot.RetrieveOffset_Int32(Offsets.Money);
            ushort Player_Fp = SelectedSlot.RetrieveOffset_UInt16(Offsets.Fp);

            if (Player_Difficulty < 4)
            {
                DifficultyCombo.SelectedIndex = Player_Difficulty;
            }
            else
            {
                DifficultyCombo.SelectedIndex = 1;
            }

            if (Player_Experience >= ExpNumericUpDown.Minimum && Player_Experience <= ExpNumericUpDown.Maximum)
            {
                ExpNumericUpDown.Value = Player_Experience;
            }
            else
            {
                ExpNumericUpDown.Value = ExpNumericUpDown.Maximum;
            }

            if (Player_Current_Level >= CurrentLevelNUpDown.Minimum && Player_Current_Level <= CurrentLevelNUpDown.Maximum)
            {
                CurrentLevelNUpDown.Value = Player_Current_Level;
            }
            else
            {
                CurrentLevelNUpDown.Value = CurrentLevelNUpDown.Maximum;
            }

            if (Player_Money >= MoneyNUpDown.Minimum && Player_Money <= MoneyNUpDown.Maximum)
            {
                MoneyNUpDown.Value = Player_Money;
            }
            else
            {
                MoneyNUpDown.Value = MoneyNUpDown.Maximum;
            }

            if (Player_Fp >= FpNumericUpDown.Minimum && Player_Fp <= FpNumericUpDown.Maximum)
            {
                FpNumericUpDown.Value = Player_Fp;
            }
            else
            {
                FpNumericUpDown.Value = FpNumericUpDown.Maximum;
            }
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
            SelectedSlot.UpdateUnix(DateOfSavePicker.Value.Date + DateOfSavePicker.Value.TimeOfDay);
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
                if (File.Exists(OpenedSaveFile.FilePath))
                {
                    File.Copy(OpenedSaveFile.FilePath, OpenedSaveFile.FilePath + " (" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ").bak");
                }
                else
                {
                    ShowWarning(DialogMessages.BackupNotPossibleFileNotFound);
                }
            }

            if (File.Exists(OpenedSaveFile.FilePath))
            {
                File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
                ShowNotice(DialogMessages.SaveDataSaved);
            }
            else
            {
                SaveFileDialog NewDialog = new SaveFileDialog();
                NewDialog.FileName = "gamesave";
                NewDialog.AddExtension = false;

                if (NewDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenedSaveFile.FilePath = NewDialog.FileName;
                    File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
                    ShowNotice(DialogMessages.SaveDataSaved);
                }
            }
        }

        private void ExpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_Int32(Offsets.Experience, (int)ExpNumericUpDown.Value);

            int TheoreticalLevel = LevelTable.GetLevel((int)ExpNumericUpDown.Value);
            LvLabel.Text = "Lv." + TheoreticalLevel;

            if (CurrentLevelNUpDown.Value > TheoreticalLevel)
            {
                CurrentLevelNUpDown.Value = TheoreticalLevel;
            }
        }

        private void OpenRecordEditButton_Click(object sender, EventArgs e)
        {
            RecordsEditor = new RecordsEditor();
            RecordsEditor.ShowDialog();
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            OpenSite("https://github.com/supremetakoyaki/Scramble");
        }
        private void OpenSite(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void DumpSlotDebugButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog DumpDialog = new SaveFileDialog();
            DumpDialog.Filter = "Scramble Save Slot (*.slot)|*.slot";
            DumpDialog.DefaultExt = "slot";
            DumpDialog.AddExtension = true;

            if (DumpDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedSlot.DumpData(DumpDialog.FileName);
                ShowNotice(DialogMessages.SaveSlotDumped);
            }
        }

        private void ImportSlotDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImportDialog = new OpenFileDialog();
            ImportDialog.Filter = "Scramble Save Slot (*.slot)|*.slot";
            ImportDialog.DefaultExt = "slot";
            ImportDialog.AddExtension = true;

            if (ImportDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] ImportedData = File.ReadAllBytes(ImportDialog.FileName);

                if (ImportedData.Length != 319952)
                {
                    ShowWarning(DialogMessages.InvalidSlotFile);
                    return;
                }

                if (ShowPrompt(DialogMessages.OverwriteSlotPrompt))
                {
                    SelectedSlot.ImportData(ImportedData);
                    SelectSlot(SelectedSlot.Id);
                }
            }
        }

        private void OpenInvEditorButton_Click(object sender, EventArgs e)
        {
            PinInvEditor = new PinInventoryEditor();
            PinInvEditor.ShowDialog();
        }
    }
}
