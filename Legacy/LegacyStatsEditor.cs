using FinalRemixDb;
using NTwewyDb;
using Scramble.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Legacy
{
    public partial class LegacyStatsEditor : Form
    {
        public LegacySave SaveFile => Program.Legacy.OpenedSaveFile;
        public LegacyForm Legacy => Program.Legacy;

        private bool ReadyForUserInput = false;

        public const ushort MAXIMUM_VALUE = 9999;
        public const ushort MAXIMUM_SYNC_VALUE = 10000;

        public int SelectedCharacterId;

        public LegacyStatsEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            PopulateFoodCombo();

            DisplayCharacter();
            DisplayOtherStats();
            ReadyForUserInput = true;
        }

        private void PopulateFoodCombo()
        {
            foreach (TwewyItem Item in Legacy.GetTwewyManager().GetItems().Values)
            {
                if (Item.Type == 2)
                {
                    FoodItem_ComboBox.Items.Add(Item.GetName(Legacy.LanguageId));
                }
            }
        }

        private void DisplayCharacter()
        {
            int CharacterId = Convert.ToInt32(CharacterTabChoose.SelectedTab.Name.Replace("Tab_PC", ""));
            ushort FoodId = 0xFFFF;

            Character_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Legacy_PC{0}", CharacterId.ToString("D2"))) as Bitmap, 202, 253, DeviceDpi);

            switch (CharacterId)
            {
                case 0:
                    CharacterName_Label.Text = "Neku Sakuraba";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_DropRate);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Bravery);
                    FoodId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Food);

                    Sync_Label.Text = "Drop Rate:";
                    break;

                case 1:
                    CharacterName_Label.Text = "Shiki Misaki";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Bravery);
                    FoodId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Food);

                    Sync_Label.Text = "SYNC:";
                    break;

                case 2:
                    CharacterName_Label.Text = "Yoshiya Kiryu";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Bravery);
                    FoodId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Food);

                    Sync_Label.Text = "SYNC:";
                    break;

                case 3:
                    CharacterName_Label.Text = "Daisukenojo Bito";
                    Atk_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Attack);
                    Def_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Defense);
                    Sync_NumericUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Sync);
                    Bravery_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Bravery);
                    FoodId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Food);

                    Sync_Label.Text = "SYNC:";
                    break;
            }

            SelectedCharacterId = CharacterId;
            DisplayFoodBytes(SelectedCharacterId);

            if (FoodId == 0xFFFF)
            {
                FoodItem_ComboBox.SelectedIndex = 0;
                FoodItem_PictureBox.Image = null;
            }
            else
            {
                TwewyItem FoodItem = Legacy.GetTwewyManager().GetItem(FoodId);
                if (FoodItem != null)
                {
                    int FoodIndex = FoodItem.Index + 1;

                    if (FoodItem_ComboBox.Items.Count >= FoodIndex)
                    {
                        FoodItem_ComboBox.SelectedIndex = FoodIndex;
                        FoodItem_PictureBox.Image = ImageMethodsFr.DrawImage(FoodItem.Sprite, 23, 23, DeviceDpi);
                    }
                    else
                    {
                        FoodItem_ComboBox.SelectedIndex = 0;
                        FoodItem_PictureBox.Image = null;
                    }
                }
                else
                {
                    FoodItem_ComboBox.SelectedIndex = 0;
                    FoodItem_PictureBox.Image = null;
                }
            }
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

                case 1:
                    UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Bytes);
                    UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_IndexOfUnavailableBytes);
                    break;

                case 2:
                    UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Bytes);
                    UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_IndexOfUnavailableBytes);
                    break;

                case 3:
                    UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Bytes);
                    UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_IndexOfUnavailableBytes);
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

                    case 1:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Bytes, Fixed_Bytes);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_IndexOfUnavailableBytes, Fixed_UnavailableIndex);
                        break;

                    case 2:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Bytes, Fixed_Bytes);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_IndexOfUnavailableBytes, Fixed_UnavailableIndex);
                        break;

                    case 3:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Bytes, Fixed_Bytes);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_IndexOfUnavailableBytes, Fixed_UnavailableIndex);
                        break;
                }
            }
        }

        private void DisplayOtherStats()
        {
            Hp_NumUpDown.Value = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Hp);
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
            ushort New_UnavailableByteIndex = 24;

            switch (SelectedCharacterId)
            {
                case 0:
                    New_UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_Bytes);
                    New_UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Neku_IndexOfUnavailableBytes);
                    break;

                case 1:
                    New_UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_Bytes);
                    New_UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Shiki_IndexOfUnavailableBytes);
                    break;

                case 2:
                    New_UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_Bytes);
                    New_UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Joshua_IndexOfUnavailableBytes);
                    break;

                case 3:
                    New_UsedBytes = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_Bytes);
                    New_UnavailableByteIndex = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Beat_IndexOfUnavailableBytes);
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
                        New_UnavailableByteIndex = (ushort)(Index + 1);

                        if (New_UnavailableByteIndex > 24)
                        {
                            New_UnavailableByteIndex = 24;
                        }
                        break;
                }
            }
            else // right click
            {
                switch (Tag)
                {
                    case 0:
                        New_UnavailableByteIndex = Index;
                        break;

                    case 1:
                        New_UnavailableByteIndex = Index;
                        New_UsedBytes = (ushort)(Index + 1);
                        break;

                    case 2:
                        New_UnavailableByteIndex = (ushort)(Index + 1);
                        break;
                }
            }

            switch (SelectedCharacterId)
            {
                case 0:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Bytes, New_UsedBytes);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_IndexOfUnavailableBytes, New_UnavailableByteIndex);
                    break;

                case 1:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Bytes, New_UsedBytes);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_IndexOfUnavailableBytes, New_UnavailableByteIndex);
                    break;

                case 2:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Bytes, New_UsedBytes);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_IndexOfUnavailableBytes, New_UnavailableByteIndex);
                    break;

                case 3:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Bytes, New_UsedBytes);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_IndexOfUnavailableBytes, New_UnavailableByteIndex);
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
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            Atk_NumericUpDown.Value = MAXIMUM_VALUE;
            Def_NumericUpDown.Value = MAXIMUM_VALUE;
            Sync_NumericUpDown.Value = MAXIMUM_SYNC_VALUE;
            Bravery_NumUpDown.Value = MAXIMUM_VALUE;

            if (AllCharacters_Checkbox.Checked)
            {
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Attack, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Defense, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_DropRate, MAXIMUM_SYNC_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Bravery, MAXIMUM_VALUE);

                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Attack, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Defense, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Sync, MAXIMUM_SYNC_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Bravery, MAXIMUM_VALUE);

                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Attack, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Defense, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Sync, MAXIMUM_SYNC_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Bravery, MAXIMUM_VALUE);

                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Attack, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Defense, MAXIMUM_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Sync, MAXIMUM_SYNC_VALUE);
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Bravery, MAXIMUM_VALUE);

                ReadyForUserInput = true;
                return;
            }
            else
            {
                switch (SelectedCharacterId)
                {
                    case 0:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Attack, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Defense, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_DropRate, MAXIMUM_SYNC_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Bravery, MAXIMUM_VALUE);
                        break;

                    case 1:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Attack, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Defense, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Sync, MAXIMUM_SYNC_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Bravery, MAXIMUM_VALUE);
                        break;

                    case 2:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Attack, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Defense, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Sync, MAXIMUM_SYNC_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Bravery, MAXIMUM_VALUE);
                        break;

                    case 3:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Attack, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Defense, MAXIMUM_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Sync, MAXIMUM_SYNC_VALUE);
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Bravery, MAXIMUM_VALUE);
                        break;
                }
            }

            ReadyForUserInput = true;
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

        private void FoodItem_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (FoodItem_ComboBox.SelectedIndex == 0)
            {
                switch (SelectedCharacterId)
                {
                    case 0:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Food, 0xFFFF);
                        break;

                    case 1:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Food, 0xFFFF);
                        break;

                    case 2:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Food, 0xFFFF);
                        break;

                    case 3:
                        SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Food, 0xFFFF);
                        break;
                }

                FoodItem_PictureBox.Image = null;
                ReadyForUserInput = true;
                return;
            }

            TwewyItem FoodItem = Legacy.GetTwewyManager().GetItemWithIndex(FoodItem_ComboBox.SelectedIndex - 1, 2);
            if (FoodItem == null)
            {
                throw new NullReferenceException();
            }

            switch (SelectedCharacterId)
            {
                case 0:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Food, FoodItem.Id);
                    break;

                case 1:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Food, FoodItem.Id);
                    break;

                case 2:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Food, FoodItem.Id);
                    break;

                case 3:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Food, FoodItem.Id);
                    break;
            }

            FoodItem_PictureBox.Image = ImageMethodsFr.DrawImage(FoodItem.Sprite, 23, 23, DeviceDpi);
            ReadyForUserInput = true;
        }

        private void Atk_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            ushort ValueToSet = (ushort)Atk_NumericUpDown.Value;

            switch (SelectedCharacterId)
            {
                case 0:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Attack, ValueToSet);
                    break;

                case 1:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Attack, ValueToSet);
                    break;

                case 2:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Attack, ValueToSet);
                    break;

                case 3:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Attack, ValueToSet);
                    break;
            }

            ReadyForUserInput = true;
        }

        private void Def_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            ushort ValueToSet = (ushort)Def_NumericUpDown.Value;

            switch (SelectedCharacterId)
            {
                case 0:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Defense, ValueToSet);
                    break;

                case 1:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Defense, ValueToSet);
                    break;

                case 2:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Defense, ValueToSet);
                    break;

                case 3:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Defense, ValueToSet);
                    break;
            }

            ReadyForUserInput = true;
        }

        private void Sync_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            ushort ValueToSet = (ushort)Sync_NumericUpDown.Value;

            switch (SelectedCharacterId)
            {
                case 0:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_DropRate, ValueToSet);
                    break;

                case 1:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Sync, ValueToSet);
                    break;

                case 2:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Sync, ValueToSet);
                    break;

                case 3:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Sync, ValueToSet);
                    break;
            }

            ReadyForUserInput = true;
        }

        private void Bravery_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            ushort ValueToSet = (ushort)Bravery_NumUpDown.Value;

            switch (SelectedCharacterId)
            {
                case 0:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Neku_Bravery, ValueToSet);
                    break;

                case 1:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Shiki_Bravery, ValueToSet);
                    break;

                case 2:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Joshua_Bravery, ValueToSet);
                    break;

                case 3:
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Beat_Bravery, ValueToSet);
                    break;
            }

            ReadyForUserInput = true;
        }

        private void HP_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            ushort ValueToSet = (ushort)Hp_NumUpDown.Value;

            SaveFile.UpdateOffset_UInt16(LegacyOffsets.Hp, ValueToSet);

            ReadyForUserInput = true;
        }

        private void Exp_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            int ValueToSet = (int)Exp_NumericUpDown.Value;

            SaveFile.UpdateOffset_Int32(LegacyOffsets.Experience, ValueToSet);

            ReadyForUserInput = true;
        }

        private void CurrentLevel_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            ushort ValueToSet = (ushort)CurrentLevel_NumUpDown.Value;

            if (MaxLevel_NumUpDown.Value < ValueToSet)
            {
                MaxLevel_NumUpDown.Value = ValueToSet;
                SaveFile.UpdateOffset_UInt16(LegacyOffsets.MaxLevel, ValueToSet);
            }

            SaveFile.UpdateOffset_UInt16(LegacyOffsets.CurLevel, ValueToSet);

            ReadyForUserInput = true;
        }

        private void MaxLevel_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            ushort ValueToSet = (ushort)MaxLevel_NumUpDown.Value;

            SaveFile.UpdateOffset_UInt16(LegacyOffsets.MaxLevel, ValueToSet);
            ReadyForUserInput = true;
        }

        private void Money_NUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            int ValueToSet = (int)Money_NUpDown.Value;

            SaveFile.UpdateOffset_Int32(LegacyOffsets.Money, ValueToSet);

            ReadyForUserInput = true;
        }

        private void Difficulty_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            byte ValueToSet = 0;

            if (Difficulty_ComboBox.SelectedIndex >= 0 && Difficulty_ComboBox.SelectedIndex < 4)
            {
                ValueToSet = (byte)Difficulty_ComboBox.SelectedIndex;
            }
            else
            {
                Difficulty_ComboBox.SelectedIndex = 0;
            }

            SaveFile.UpdateOffset_Byte(LegacyOffsets.Difficulty, ValueToSet);

            ReadyForUserInput = true;
        }

        private void MaxStats_Other_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            Hp_NumUpDown.Value = 9999;
            Exp_NumericUpDown.Value = 999999999;
            CurrentLevel_NumUpDown.Value = 100;
            MaxLevel_NumUpDown.Value = 100;
            Money_NUpDown.Value = 9999999;

            SaveFile.UpdateOffset_UInt16(LegacyOffsets.Hp, 9999);
            SaveFile.UpdateOffset_Int32(LegacyOffsets.Experience, 999999999);
            SaveFile.UpdateOffset_UInt16(LegacyOffsets.CurLevel, 100);
            SaveFile.UpdateOffset_UInt16(LegacyOffsets.MaxLevel, 100);
            SaveFile.UpdateOffset_Int32(LegacyOffsets.Money, 9999999);

            ReadyForUserInput = true;
        }
    }
}
