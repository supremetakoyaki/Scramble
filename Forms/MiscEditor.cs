using Scramble.Classes;
using Scramble.GameData;
using Scramble.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class MiscEditor : Form
    {
        public GlobalData SaveGlobal => Program.Sukuranburu.OpenedSaveFile.GetGlobalData();
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private bool ReadyForUserInput = false;

        public MiscEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            LoadLanguageStrings();
            LoadUnlockedDlc();

            ReadyForUserInput = true;
        }

        private void LoadLanguageStrings()
        {
            Text = Sukuranburu.GetString("{MiscEditor}");
            DlcGroupBox.Text = Sukuranburu.GetString("{DlcTitle}");
            Dlc1_Checkbox.Text = Sukuranburu.GetString("{Dlc1_Name}");
            Dlc2_Checkbox.Text = Sukuranburu.GetString("{Dlc2_Name}");
        }

        private void LoadUnlockedDlc()
        {
            int DlcOffset = SaveGlobal.IsPcVersion ? SystemOffsets.DLCFlags_PC : SystemOffsets.DLCFlags_PS4SW;
            byte DlcByte = SaveGlobal.RetrieveOffset_Byte(DlcOffset);

            bool Dlc1_Unlocked = ByteUtil.GetBit(DlcByte, 0);
            bool Dlc2_Unlocked = ByteUtil.GetBit(DlcByte, 1);

            Dlc1_Checkbox.Checked = Dlc1_Unlocked;
            Dlc2_Checkbox.Checked = Dlc2_Unlocked;
        }

        private void Dlc1_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            int DlcOffset = SaveGlobal.IsPcVersion ? SystemOffsets.DLCFlags_PC : SystemOffsets.DLCFlags_PS4SW;
            byte OgByte = SaveGlobal.RetrieveOffset_Byte(DlcOffset);
            byte NewByte = ByteUtil.SetBit(OgByte, 0, Dlc1_Checkbox.Checked);
            SaveGlobal.UpdateOffset_Byte(DlcOffset, NewByte);

            ReadyForUserInput = true;
        }

        private void Dlc2_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            int DlcOffset = SaveGlobal.IsPcVersion ? SystemOffsets.DLCFlags_PC : SystemOffsets.DLCFlags_PS4SW;
            byte OgByte = SaveGlobal.RetrieveOffset_Byte(DlcOffset);
            byte NewByte = ByteUtil.SetBit(OgByte, 1, Dlc1_Checkbox.Checked);
            SaveGlobal.UpdateOffset_Byte(DlcOffset, NewByte);

            ReadyForUserInput = true;
        }

        private void DlcTitle_Label_Click(object sender, EventArgs e)
        {

        }
    }
}
