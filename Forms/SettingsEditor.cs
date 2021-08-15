using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class SettingsEditor : Form
    {
        public GlobalData SaveGlobal => Program.Sukuranburu.OpenedSaveFile.GetGlobalData();
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private bool ReadyForUserInput = false;

        public SettingsEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            LoadLanguageStrings();
            LoadSettings();

            ReadyForUserInput = true;
        }

        private void LoadLanguageStrings()
        {
            Text = Sukuranburu.GetString("{SettingsEditor}");
            VolumeGroupBox.Text = Sukuranburu.GetString("{Volume}");
            MusicVol_Label.Text = Sukuranburu.GetString("{MusicVol:}");
            SfxVol_Label.Text = Sukuranburu.GetString("{SfxVol:}");
            VaVol_Label.Text = Sukuranburu.GetString("{VaVol:}");
            GeneralGroupBox.Text = Sukuranburu.GetString("{General}");
            VaLanguage_Label.Text = Sukuranburu.GetString("{VoiceLanguage:}");
            JapaneseVa_RadioButton.Text = Sukuranburu.GetString("{Japanese}");
            EnglishVa_RadioButton.Text = Sukuranburu.GetString("{English}");
            Other_Label.Text = Sukuranburu.GetString("{Other:}");
            ControllerVibration_Checkbox.Text = Sukuranburu.GetString("{ControllerVibration}");
            DialogueAutoPlay_Checkbox.Text = Sukuranburu.GetString("{DialogueAutoplay}");
            Subtitles_Checkbox.Text = Sukuranburu.GetString("{Subtitles}");
        }

        private void LoadSettings()
        {
            float MusicVol = SaveGlobal.RetrieveOffset_Float(Offsets.VolumeMusic);
            float SfxVol = SaveGlobal.RetrieveOffset_Float(Offsets.VolumeSfx);
            float VaVol = SaveGlobal.RetrieveOffset_Float(Offsets.VolumeVa);

            MusicVolTrackBar.Value = (int)(MusicVol * 10);
            SfxVolTrackBar.Value = (int)(SfxVol * 10);
            VaVolumeTrackBar.Value = (int)(VaVol * 10);

            if (SaveGlobal.RetrieveOffset_Byte(Offsets.VaLanguage) == 0)
            {
                JapaneseVa_RadioButton.Checked = true;
            }
            else
            {
                EnglishVa_RadioButton.Checked = true;
            }

            ControllerVibration_Checkbox.Checked = SaveGlobal.RetrieveOffset_Byte(Offsets.Vibration) != 0;
            DialogueAutoPlay_Checkbox.Checked = SaveGlobal.RetrieveOffset_Byte(Offsets.DialogueAutoplay) != 0;
            Subtitles_Checkbox.Checked = SaveGlobal.RetrieveOffset_Byte(Offsets.Subtitles) != 0;
        }

        private void MusicVolTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SaveGlobal.UpdateOffset_Float(Offsets.VolumeMusic, (float)MusicVolTrackBar.Value / 10f);
            ReadyForUserInput = true;
        }

        private void SfxVolTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SaveGlobal.UpdateOffset_Float(Offsets.VolumeSfx, (float)SfxVolTrackBar.Value / 10f);
            ReadyForUserInput = true;
        }

        private void VaVolumeTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SaveGlobal.UpdateOffset_Float(Offsets.VolumeVa, (float)VaVolumeTrackBar.Value / 10f);
            ReadyForUserInput = true;
        }

        private void JapaneseVa_RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (JapaneseVa_RadioButton.Checked)
            {
                SaveGlobal.UpdateOffset_Byte(Offsets.VaLanguage, 0);
            }

            ReadyForUserInput = true;
        }

        private void EnglishVa_RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (EnglishVa_RadioButton.Checked)
            {
                SaveGlobal.UpdateOffset_Byte(Offsets.VaLanguage, 1);
            }

            ReadyForUserInput = true;
        }

        private void ControllerVibration_Checkbox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SaveGlobal.UpdateOffset_Byte(Offsets.Vibration, Convert.ToByte(ControllerVibration_Checkbox.Checked));
            ReadyForUserInput = true;
        }

        private void DialogueAutoPlay_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SaveGlobal.UpdateOffset_Byte(Offsets.DialogueAutoplay, Convert.ToByte(DialogueAutoPlay_Checkbox.Checked));
            ReadyForUserInput = true;
        }

        private void Subtitles_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SaveGlobal.UpdateOffset_Byte(Offsets.Subtitles, Convert.ToByte(Subtitles_Checkbox.Checked));
            ReadyForUserInput = true;
        }
    }
}
