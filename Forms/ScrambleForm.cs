﻿using NTwewyDb;
using Scramble.Classes;
using Scramble.Forms;
using Scramble.GameData;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scramble
{
    public partial class ScrambleForm : Form
    {
        public SaveFile OpenedSaveFile;
        public CollectionEditor RecordsEditor;
        public PinInventoryEditor PinInvEditor;
        public ClothingInventoryEditor ClothInvEditor;

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

        private LanguageStrings LangStrings;
        public byte CurrentLanguage;

        #region NEO TWEWY Database instances
        private ItemManager ItmManager;
        private CharacterManager CharaManager;
        private GameLocaleManager GameLocManager;
        #endregion

        public ScrambleForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.DateOfSavePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.Height = 148;
            this.Width = 309;

            LangStrings = new LanguageStrings();
            LanguageSelectComboBox.Text = "English";

            // NEO TWEWY Database instances
            ItmManager = new ItemManager();
            CharaManager = new CharacterManager();
            GameLocManager = new GameLocaleManager();
        }

        public void DisplayLanguageStrings()
        {
            this.Text = OpenedSaveFile == null ? GetString("{ScrambleShortTitle}") : GetString("{ScrambleLongTitle}");
            this.OpenSaveFileButton.Text = GetString("{OpenSaveFile}");
            this.SaveChangesButton.Text = GetString("{SaveChanges}");

            this.SaveSlotsGroupBox.Text = GetString("{SaveSlots}");
            this.SaveSlotsListBox.Items.RemoveAt(0);
            this.SaveSlotsListBox.Items.Insert(0, string.Format("0 ({0})", GetString("{Autosave}")));
            this.SaveSlotsListBox.SelectedIndex = 0;

            this.SelectLanguageLabel.Text = GetString("{Language}");

            this.BackupCheckbox.Text = GetString("{BackupCheckbox}");
            this.DumpSlotDataButton.Text = GetString("{DumpSlotData}");
            this.ImportSlotDataButton.Text = GetString("{ImportSlotData}");
            this.GlobalGroupBox.Text = GetString("{Global}");
            this.GameSettingsEditorButton.Text = GetString("{SettingsEditor}");
            this.MiscFlagsEditorButton.Text = GetString("{MiscEditor}");

            this.GeneralGroupBox.Text = GetString("{ThisSelectedSlot}");
            this.InitializedSlotCheckbox.Text = GetString("{InitializedSlotCheckbox}");
            this.DateSavedLabel.Text = GetString("{DateAndTimeOfSave}");
            this.DifficultyLabel.Text = GetString("{Difficulty}");
            this.ExperienceLabel.Text = GetString("{Experience}");
            this.CurrentLevelLabel.Text = GetString("{CurrentLevel}");
            this.MoneyLabel.Text = GetString("{Money}");
            this.FpLabel.Text = GetString("{FP}");
            this.LvLabel_Pre.Text = GetString("{Lv}");
            this.PartyMembersLabel.Text = GetString("{YourParty}");

            this.OpenCharacterEditButton.Text = GetString("{CharacterEditor}");
            this.OpenInvEditorButton.Text = GetString("{PinsEditor}");
            this.OpenClothEditButton.Text = GetString("{ClothingEditor}");
            this.OpenSocialEditButton.Text = GetString("{SocialEditor}");
            this.OpenRecordEditButton.Text = GetString("{CollectionEditor}");
            this.OpenNoisepediaEditButton.Text = GetString("{NoisepediaEditor}");
        }

        public string GetString(string Key)
        {
            return LangStrings.GetLanguageString(CurrentLanguage, Key);
        }

        public void ShowWarning(string Message)
        {
            MessageBox.Show(Message, GetString("{Warning}"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowNotice(string Message)
        {
            MessageBox.Show(Message, GetString("{Notice}"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool ShowPrompt(string Message)
        {
            return MessageBox.Show(Message, GetString("{Hey}"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OpenSaveFileButton_Click(object sender, EventArgs e)
        {
            if (OpenedSaveFile != null && ShowPrompt(GetString("DLG_SaveDataAlreadyOpened}")) == false)
            {
                return;
            }

            OpenFileDialog Dialog = new OpenFileDialog();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(Dialog.FileName))
                {
                    ShowWarning(GetString("DLG_FileNotFound"));
                    return;
                }

                byte[] AllData = File.ReadAllBytes(Dialog.FileName);
                byte Result;

                OpenedSaveFile = new SaveFile(Dialog.FileName, AllData, out Result);

                if (Result == 0) // invalid file size
                {
                    ShowWarning(GetString("DLG_InvalidSaveFile"));
                    OpenedSaveFile = null;

                    this.Height = 148;
                    this.Width = 309;
                    return;
                }

                if (this.SaveSlotsListBox.SelectedIndex == -1)
                {
                    this.SaveSlotsListBox.SelectedIndex = 0;
                    this.SaveSlotsListBox.Select();
                }
                else
                {
                    SelectSlot(this.SaveSlotsListBox.SelectedIndex);
                }

                this.Height = 409;
                this.Width = 740;
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
                CurrentLevelNUpDown.Value = GetCharacterManager().GetLevel(Player_Current_Level);
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

            SerializePartyMembers();
        }

        private void SerializePartyMembers()
        {
            // Clear the images first
            PartyMember1_PictureBox.Image = null;
            PartyMember2_PictureBox.Image = null;
            PartyMember3_PictureBox.Image = null;
            PartyMember4_PictureBox.Image = null;
            PartyMember5_PictureBox.Image = null;
            PartyMember6_PictureBox.Image = null;

            foreach (PartyMember Member in SelectedSlot.GetPartyMembers().Values)
            {
                switch (Member.Id)
                {
                    case 1:
                        PartyMember1_PictureBox.Image = CharacterImageList_32x32.Images[Member.CharacterId + ".png"];
                        break;

                    case 2:
                        PartyMember2_PictureBox.Image = CharacterImageList_32x32.Images[Member.CharacterId + ".png"];
                        break;

                    case 3:
                        PartyMember3_PictureBox.Image = CharacterImageList_32x32.Images[Member.CharacterId + ".png"];
                        break;

                    case 4:
                        PartyMember4_PictureBox.Image = CharacterImageList_32x32.Images[Member.CharacterId + ".png"];
                        break;

                    case 5:
                        PartyMember5_PictureBox.Image = CharacterImageList_32x32.Images[Member.CharacterId + ".png"];
                        break;

                    case 6:
                        PartyMember6_PictureBox.Image = CharacterImageList_32x32.Images[Member.CharacterId + ".png"];
                        break;
                }
            }
        }

        private void SaveSlotsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SaveSlotsListBox.SelectedIndex != -1 && OpenedSaveFile != null)// && SelectedSlot.Id != SaveSlotsListBox.SelectedIndex)
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
            int MaxTheoreticalLevel = GetCharacterManager().GetLevel((int)ExpNumericUpDown.Value);
            if (CurrentLevelNUpDown.Value > MaxTheoreticalLevel)
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
                if (ShowPrompt(GetString("DLG_BackupCheckboxNotChecked")) == false)
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
                    ShowWarning(GetString("DLG_BackupNotPossibleFileNotFound"));
                }
            }

            if (File.Exists(OpenedSaveFile.FilePath))
            {
                File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
                ShowNotice(GetString("DLG_SaveDataSaved"));
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
                    ShowNotice(GetString("DLG_SaveDataSaved"));
                }
            }
        }

        private void ExpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedSlot.UpdateOffset_Int32(Offsets.Experience, (int)ExpNumericUpDown.Value);

            int TheoreticalLevel = GetCharacterManager().GetLevel((int)ExpNumericUpDown.Value);
            LvLabel.Text = TheoreticalLevel.ToString();

            if (CurrentLevelNUpDown.Value > TheoreticalLevel)
            {
                CurrentLevelNUpDown.Value = TheoreticalLevel;
            }
        }

        private void OpenRecordEditButton_Click(object sender, EventArgs e)
        {
            RecordsEditor = new CollectionEditor();
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
                ShowNotice(GetString("DLG_SaveSlotDumped"));
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
                    ShowWarning(GetString("DLG_InvalidSlotFile"));
                    return;
                }

                if (ShowPrompt(GetString("DLG_OverwriteSlotPrompt")))
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

        private void OpenClothEditButton_Click(object sender, EventArgs e)
        {
            ClothInvEditor = new ClothingInventoryEditor();
            ClothInvEditor.ShowDialog();
        }

        private void LanguageSelectComboBox_TextChanged(object sender, EventArgs e)
        {
            CurrentLanguage = (byte)LanguageSelectComboBox.SelectedIndex;
            DisplayLanguageStrings();
        }

        #region Get Image Lists Methods
        public ImageList GetCharacterIconList()
        {
            return CharacterImageList_32x32;
        }
        public ImageList Get32x32AllCollectionIconsImageList()
        {
            return AllCollectionIconsImageList_32x32;
        }

        public ImageList Get64x64PinImageList()
        {
            return PinImageList_64x64;
        }

        public ImageList Get128x128FashionImageList()
        {
            return FashionImageList_128x128;
        }

        public ImageList Get64x64FashionImageList()
        {
            return FashionImageList_64x64;
        }
        public ImageList GetBrandImageList()
        {
            return BrandImageList_170x60;
        }

        public ImageList Get128x128FoodImageList()
        {
            return FoodImageList_128x128;
        }

        public ImageList Get64x64FoodImageList()
        {
            return FoodImageList_64x64;
        }
        #endregion

        #region NEO TWEWY Database instances Methods
        public ItemManager GetItemManager()
        {
            return ItmManager;
        }

        public CharacterManager GetCharacterManager()
        {
            return CharaManager;
        }

        public GameLocaleManager GetGameLocaleManager()
        {
            return GameLocManager;
        }

        public string GetGameString(string Key)
        {
            return GetGameLocaleManager().GetLocale(CurrentLanguage, Key);
        }
        #endregion
    }
}
