using Scramble.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Scramble.GameData;

namespace Scramble
{
    public partial class ScrambleForm : Form
    {
        public SaveFile OpenedSaveFile;

        public ScrambleForm()
        {
            InitializeComponent();
            this.Height = 150;
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
                this.Height = 350;
                this.Width = 550;
            }
        }
        private void SelectSlot(int Id)
        {
            SaveData ThisSlot = OpenedSaveFile.GetSaveSlot(Id);

            DateOfSavePicker.Value = DateTimeOffset.FromUnixTimeSeconds(ThisSlot.UnixTimestamp_Integer).DateTime;
            DifficultyCombo.SelectedIndex = Convert.ToInt32(ThisSlot.Data[Offsets.Difficulty]);
            CurrentLevelNUpDown.Value = BitConverter.ToUInt32(ThisSlot.Data, Offsets.CurrentLevel);
            MoneyNUpDown.Value = BitConverter.ToUInt32(ThisSlot.Data, Offsets.Money);
        }

        private void SaveSlotsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OpenedSaveFile != null)
            {
                SelectSlot(SaveSlotsListBox.SelectedIndex);
            }
        }
    }
}
