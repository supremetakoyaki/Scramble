using NTwewyDb;
using Scramble.Classes;
using Scramble.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scramble.Legacy
{
    public partial class LegacyStatsEditor : Form
    {
        public LegacySave SaveFile => Program.Legacy.OpenedSaveFile;

        private bool ReadyForUserInput = false;

        public const ushort MAXIMUM_VALUE = 999; //or should I put 255?

        public LegacyStatsEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            DisplayCharacter();
            DisplayOtherStats();
            ReadyForUserInput = true;
        }

        private void DisplayCharacter()
        {
            int CharacterId = Convert.ToInt32(CharacterTabChoose.SelectedTab.Name.Replace("Tab_PC", ""));

            Character_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Legacy_PC{0}", CharacterId.ToString("D2"))) as Bitmap, 202, 253, DeviceDpi);

            switch (CharacterId)
            {
                case 0:
                    CharacterName_Label.Text = "Neku Sakuraba";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Luck);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Bravery);
                    //Food bytes
                    break;

                case 1:
                    CharacterName_Label.Text = "Shiki Misaki";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Bravery);
                    //Food bytes
                    break;

                case 2:
                    CharacterName_Label.Text = "Yoshiya Kiryu";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Bravery);
                    //Food bytes
                    break;

                case 3:
                    CharacterName_Label.Text = "Daisukenojo Bito";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Bravery);
                    //Food bytes
                    break;
            }
        }

        private void DisplayOtherStats()
        {
            Exp_NumericUpDown.Value = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Experience);
            CurrentLevel_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.CurLevel);
            MaxLevel_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.MaxLevel);
            Money_NUpDown.Value = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Money);
        }

        private void CharacterTabChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (CharacterTabChoose.SelectedIndex != -1)
            {
                DisplayCharacter();
            }

            ReadyForUserInput = true;
        }
    }
}
