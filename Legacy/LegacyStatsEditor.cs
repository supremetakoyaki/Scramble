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

        public const ushort MAXIMUM_VALUE = 999;
        public const ushort MAXIMUM_SYNC_VALUE = 10000;

        public int SelectedCharacterId;

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
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Bravery);
                    break;

                case 1:
                    CharacterName_Label.Text = "Shiki Misaki";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Bravery);
                    break;

                case 2:
                    CharacterName_Label.Text = "Yoshiya Kiryu";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Bravery);
                    break;

                case 3:
                    CharacterName_Label.Text = "Daisukenojo Bito";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Bravery);
                    break;
            }

            SelectedCharacterId = CharacterId;
            DisplayFoodBytes(SelectedCharacterId);
        }

        private void DisplayFoodBytes(int CharacterId, bool AttemptToFixMismatched = false)
        {
            ushort UsedBytes = 0;
            ushort UnavailableByteIndex = 24; // or is it -1 for default?

            switch (CharacterId)
            {
                case 0:
                    UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Bytes);
                    UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_IndexOfUnavailableBytes);
                    break;
            }

            ushort Fixed_Bytes = 0;
            ushort Fixed_UnavailableIndex = 24;

            for (int i = 0; i < 24; i++)
            {
                PictureBox BytePictureBox = (PictureBox)Controls.Find(string.Format("FoodByte_PictureBox_{0}", i), true)[0];

                if (BytePictureBox != null)
                {
                    if (i >= UnavailableByteIndex)
                    {
                        BytePictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Legacy_Byte_X") as Bitmap, 13, 13, DeviceDpi);
                        BytePictureBox.Tag = 2;
                        Fixed_UnavailableIndex--;
                    }
                    else if (UsedBytes - 1 >= i)
                    {
                        BytePictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Legacy_Byte_Fulfilled") as Bitmap, 13, 13, DeviceDpi);
                        BytePictureBox.Tag = 1;
                        Fixed_Bytes++;
                    }
                    else
                    {
                        BytePictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Legacy_Byte_Empty") as Bitmap, 13, 13, DeviceDpi);
                        BytePictureBox.Tag = 0;
                    }
                }
            }

            if (AttemptToFixMismatched)
            {
                switch (SelectedCharacterId)
                {
                    case 0:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Bytes, Fixed_Bytes);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_IndexOfUnavailableBytes, Fixed_UnavailableIndex);
                        break;
                }
            }
        }

        private void DisplayOtherStats()
        {
            Exp_NumericUpDown.Value = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Experience);
            CurrentLevel_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.CurLevel);
            MaxLevel_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.MaxLevel);
            Money_NUpDown.Value = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Money);
            Difficulty_ComboBox.SelectedIndex = SaveFile.RetrieveOffset_Byte(LegacyOffsets.Difficulty);
        }

        private void ModifyFoodBytes(byte Index, byte Click)
        {
            PictureBox BytePictureBox = (PictureBox)Controls.Find(string.Format("FoodByte_PictureBox_{0}", Index), true)[0];

            int Tag = (int)BytePictureBox.Tag;
            ushort New_UsedBytes = 0;
            ushort New_UnavailabilityByteIndex = 24;

            switch (SelectedCharacterId)
            {
                case 0:
                    New_UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Bytes);
                    New_UnavailabilityByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_IndexOfUnavailableBytes);
                    break;
            }

            if (Click == 0) // left click
            {
                switch (Tag)
                {
                    case 0:
                        New_UsedBytes = (ushort)(Index + 1);
                        break;

                    case 1:
                        New_UsedBytes = Index;
                        break;

                    case 2:
                        New_UsedBytes = (ushort)(Index + 1);
                        New_UnavailabilityByteIndex = (ushort)(Index + 1);

                        if (New_UnavailabilityByteIndex > 24)
                        {
                            New_UnavailabilityByteIndex = 24;
                        }
                        break;
                }
            }
            else // right click
            {
                switch (Tag)
                {
                    case 0:
                        New_UnavailabilityByteIndex = Index;
                        break;

                    case 1:
                        New_UnavailabilityByteIndex = Index;
                        New_UsedBytes = (ushort)(Index + 1);
                        break;

                    case 2:
                        New_UnavailabilityByteIndex = (ushort)(Index + 1);
                        break;
                }
            }

            switch (SelectedCharacterId)
            {
                case 0:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Bytes, New_UsedBytes);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_IndexOfUnavailableBytes, New_UnavailabilityByteIndex);
                    break;
            }

            DisplayFoodBytes(SelectedCharacterId, true);
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

        private void MaxStats_Button_Click(object sender, EventArgs e)
        {

        }

        #region Click Food Byte Picture Box Methods
        private void FoodByte_PictureBox_0_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }

            ModifyFoodBytes(0, Click);
        }

        private void FoodByte_PictureBox_1_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }

            ModifyFoodBytes(1, Click);
        }

        private void FoodByte_PictureBox_2_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }

            ModifyFoodBytes(2, Click);
        }

        private void FoodByte_PictureBox_3_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(3, Click);
        }

        private void FoodByte_PictureBox_4_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(4, Click);
        }

        private void FoodByte_PictureBox_5_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(5, Click);
        }

        private void FoodByte_PictureBox_6_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(6, Click);
        }

        private void FoodByte_PictureBox_7_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(7, Click);
        }

        private void FoodByte_PictureBox_8_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(8, Click);
        }

        private void FoodByte_PictureBox_9_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(9, Click);
        }

        private void FoodByte_PictureBox_10_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(10, Click);
        }

        private void FoodByte_PictureBox_11_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(11, Click);
        }

        private void FoodByte_PictureBox_12_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(12, Click);
        }

        private void FoodByte_PictureBox_13_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(13, Click);
        }

        private void FoodByte_PictureBox_14_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(14, Click);
        }

        private void FoodByte_PictureBox_15_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(15, Click);
        }

        private void FoodByte_PictureBox_16_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(16, Click);
        }

        private void FoodByte_PictureBox_17_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(17, Click);
        }

        private void FoodByte_PictureBox_18_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(18, Click);
        }

        private void FoodByte_PictureBox_19_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(19, Click);
        }

        private void FoodByte_PictureBox_20_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(20, Click);
        }

        private void FoodByte_PictureBox_21_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(21, Click);
        }

        private void FoodByte_PictureBox_22_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(22, Click);
        }

        private void FoodByte_PictureBox_23_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            byte Click = 0;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Click = 1;
            }
            ModifyFoodBytes(23, Click);
        }
        #endregion
    }
}
