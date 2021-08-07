using NTwewyDb;
using Scramble.Classes;
using Scramble.Forms;
using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scramble
{
    public partial class ScrambleForm : Form
    {
        public SaveFile OpenedSaveFile;
        public CollectionEditor RecordsEditor;
        public PinInventoryEditor PinInvEditor;
        public ClothingInventoryEditor ClothInvEditor;
        public CharacterStatEditor CharaStatEditor;
        public SkillTreeEditor SocialEditor;

        public MiscEditor MiscEditor;

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

        private readonly LanguageStrings LangStrings;
        public byte CurrentLanguage;

        private readonly GameTextProcessor GameTextProcessor;

        #region NEO TWEWY Database instances
        private readonly ItemManager ItmManager;
        private readonly CharacterManager CharaManager;
        private readonly GameLocaleManager GameLocManager;
        private readonly SocialNetworkManager SocialManager;
        #endregion

        public bool SwitchVersion = true;

        private List<byte> SafeCharacters;
        public bool ShowSpoilers => ShowSpoilersCheckbox.Checked;

        // Scaling for people who do NOT have 100% DPI setting. a.k.a. insane people D;
        private Graphics Graphics;

        public double ScaleFactor
        {
            get;
            private set;
        }

        public bool RequiresRescaling => ScaleFactor != 1.0;

        private bool ReadyForUserInput = false;

        public ScrambleForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            SetUpGraphics();

            DateOfSavePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            ChangeFormSize(148, 309);

            // NEO TWEWY Database instances
            ItmManager = new ItemManager();
            CharaManager = new CharacterManager();
            GameLocManager = new GameLocaleManager();
            SocialManager = new SocialNetworkManager();

            LangStrings = new LanguageStrings();
            GameTextProcessor = new GameTextProcessor();

            LanguageSelectComboBox.Text = "English";
            ReadyForUserInput = true;

            Task.Run(TryCheckForUpdates);
        }

        public void SetUpGraphics()
        {
            Graphics = CreateGraphics();
            ScaleFactor = Graphics.DpiX / 96;
            DpiChanged += new DpiChangedEventHandler(ScrambleForm_DpiChanged);
        }

        public void DisplayLanguageStrings()
        {
            Text = OpenedSaveFile == null ? GetString("{ScrambleShortTitle}") : GetString("{ScrambleLongTitle}");
            OpenSaveFileButton.Text = GetString("{OpenSaveFile}");
            SaveChangesButton.Text = GetString("{SaveChanges}");

            SaveSlotsGroupBox.Text = GetString("{SaveSlots}");
            SaveSlotsListBox.Items.RemoveAt(0);
            SaveSlotsListBox.Items.Insert(0, string.Format("0 ({0})", GetString("{Autosave}")));
            SaveSlotsListBox.SelectedIndex = 0;

            SelectLanguageLabel.Text = GetString("{Language}");

            BackupCheckbox.Text = GetString("{BackupCheckbox}");
            DumpSlotDataButton.Text = GetString("{DumpSlotData}");
            ImportSlotDataButton.Text = GetString("{ImportSlotData}");
            GlobalGroupBox.Text = GetString("{Global}");
            GameSettingsEditorButton.Text = GetString("{SettingsEditor}");
            MiscFlagsEditorButton.Text = GetString("{MiscEditor}");

            GeneralGroupBox.Text = GetString("{ThisSelectedSlot}");
            InitializedSlotCheckbox.Text = GetString("{InitializedSlotCheckbox}");
            DateSavedLabel.Text = GetString("{DateAndTimeOfSave}");
            DifficultyLabel.Text = GetString("{Difficulty}");
            ExperienceLabel.Text = GetString("{Experience}");
            CurrentLevelLabel.Text = GetString("{CurrentLevel}");
            MoneyLabel.Text = GetString("{Money}");
            FpLabel.Text = GetString("{Fp:}");
            LvLabel_Pre.Text = GetString("{Lv}");
            PartyMembersLabel.Text = GetString("{YourParty}");

            OpenCharacterEditButton.Text = GetString("{CharacterEditor}");
            OpenInvEditorButton.Text = GetString("{PinsEditor}");
            OpenClothEditButton.Text = GetString("{ClothingEditor}");
            OpenSocialEditButton.Text = GetString("{SocialEditor}");
            OpenRecordEditButton.Text = GetString("{CollectionEditor}");
            OpenNoisepediaEditButton.Text = GetString("{NoisepediaEditor}");

            OpenShopEdit_Button.Text = GetString("{ShopEditor}");
            OpenDayEditor_Button.Text = GetString("{DayEditor}");

            ShowSpoilersCheckbox.Text = GetString("{ShowSpoilers}");

            DifficultyCombo.Items.Clear();
            for (byte i = 1; i < 5; i++)
            {
                DifficultyCombo.Items.Add(GetGameString(string.Format("Setting_Difficulty{0}", i.ToString("D2"))));
            }

            if (SelectedSlot != null)
            {
                DifficultyCombo.SelectedIndex = SelectedSlot.RetrieveOffset_Byte(Offsets.Difficulty);
                CurrentDay_Label.Text = GetDayName(SelectedSlot.CurrentDay);
            }

            CaloriesEaten_Label.Text = GetString("{CaloriesEaten}");
            OverateCheckbox.Text = GetString("{Overate}");
        }

        public void TryCheckForUpdates()
        {
            try
            {
                string LatestReleaseUri_Api = "https://api.github.com/repos/supremetakoyaki/Scramble/releases/latest";
                string LatestReleaseUri = "https://github.com/supremetakoyaki/Scramble/releases/latest";

                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add("User-Agent", "request");
                    string ApiResponse = Client.DownloadString(LatestReleaseUri_Api);

                    string LatestVersion_str = ApiResponse.Split("tag_name")[1].Substring(4).Split('"')[0];

                    Version CurrentVersion = new Version(AboutLabel.Text.Substring(1));
                    Version LatestVersion = new Version(LatestVersion_str);

                    if (CurrentVersion.CompareTo(LatestVersion) < 0)
                    {
                        if (ShowPrompt(GetString("DLG_NewUpdateFound")))
                        {
                            OpenSite(LatestReleaseUri);
                        }
                    }
                }
            }
            catch// (Exception e)
            {
                //debug: MessageBox.Show(e.ToString());
            }
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

        private void SelectSlot(int Id)
        {
            ReadyForUserInput = false;

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
            int Player_Fp = SelectedSlot.RetrieveOffset_Int32(Offsets.Fp);
            int Player_Calories = SelectedSlot.RetrieveOffset_Int32(Offsets.Calories);
            bool Player_Overate = SelectedSlot.RetrieveOffset_Byte(Offsets.Overate) != 0;

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

            int TheoreticalLevel = GetCharacterManager().GetLevel((int)ExpNumericUpDown.Value);
            LvLabel.Text = TheoreticalLevel.ToString();

            if (CurrentLevelNUpDown.Value > TheoreticalLevel)
            {
                CurrentLevelNUpDown.Value = TheoreticalLevel;
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

            if (Player_Calories >= Calories_NumUpDown.Minimum && Player_Calories <= Calories_NumUpDown.Maximum)
            {
                Calories_NumUpDown.Value = Player_Calories;
            }
            else
            {
                Calories_NumUpDown.Value = Calories_NumUpDown.Maximum;
            }

            OverateCheckbox.Checked = Player_Overate;

            SerializePartyMembers();
            UpdateCaloriesPercentage();

            CurrentDay_Label.Text = GetDayName(SelectedSlot.CurrentDay);

            ReadyForUserInput = true;
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

            SafeCharacters = new List<byte>();

            foreach (PartyMember Member in SelectedSlot.GetPartyMembers().Values)
            {
                SafeCharacters.Add(Member.CharacterId);

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

            // Show Rindo anyway
            if (!SafeCharacters.Contains(1))
            {
                SafeCharacters.Add(1);
            }

            // Show Fret anyway
            if (!SafeCharacters.Contains(3))
            {
                SafeCharacters.Add(3);
            }

            // Show Minamimoto anyway
            if (!SafeCharacters.Contains(7))
            {
                SafeCharacters.Add(7);
            }

            if (SelectedSlot.GetPartyMembers().Count > 5) // basically we beat the game...
            {
                // show all of them because anyone could have been replaced.
                if (!SafeCharacters.Contains(2))
                {
                    SafeCharacters.Add(2);
                }
                if (!SafeCharacters.Contains(4))
                {
                    SafeCharacters.Add(4);
                }
                if (!SafeCharacters.Contains(5))
                {
                    SafeCharacters.Add(5);
                }
                if (!SafeCharacters.Contains(6))
                {
                    SafeCharacters.Add(6);
                }
            }
        }

        private void OpenSaveFileButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }
            else if (OpenedSaveFile != null && ShowPrompt(GetString("DLG_SaveDataAlreadyOpened")) == false)
            {
                return;
            }

            ReadyForUserInput = false;
            OpenFileDialog Dialog = new OpenFileDialog();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(Dialog.FileName))
                {
                    ShowWarning(GetString("DLG_FileNotFound"));
                    ReadyForUserInput = true;
                    return;
                }

                byte[] AllData = File.ReadAllBytes(Dialog.FileName);

                OpenedSaveFile = new SaveFile(Dialog.FileName, AllData, out byte Result);

                if (Result == 0) // invalid file size
                {
                    ShowWarning(GetString("DLG_InvalidSaveFile"));
                    OpenedSaveFile = null;

                    ChangeFormSize(148, 309);
                    ReadyForUserInput = true;
                    return;
                }

                if (SaveSlotsListBox.SelectedIndex == -1)
                {
                    SaveSlotsListBox.SelectedIndex = 0;
                    SaveSlotsListBox.Select();
                }
                else
                {
                    SelectSlot(SaveSlotsListBox.SelectedIndex);
                }

                ChangeFormSize(435, 760);
                Text = "Scramble — NEO TWEWY Save Editor";
            }

            ReadyForUserInput = true;
        }

        private void UpdateCalories()
        {
            SelectedSlot.UpdateOffset_Byte(Offsets.Overate, Convert.ToByte(OverateCheckbox.Checked));
            SelectedSlot.UpdateOffset_Int32(Offsets.Calories, (int)Calories_NumUpDown.Value);
        }

        private void UpdateCaloriesPercentage()
        {
            if (SelectedSlot.GetPartyMembers().Count == 0)
            {
                CaloriesPercentage_Label.Text = "0%";
                CaloriesPercentage_Label.ForeColor = Color.Green;
                return;
            }

            decimal Percentage = Math.Floor(Calories_NumUpDown.Value / (1000 * SelectedSlot.GetPartyMembers().Count) * 100);

            CaloriesPercentage_Label.Text = string.Format("{0}%", Percentage);

            if (Percentage >= 100)
            {
                CaloriesPercentage_Label.ForeColor = Color.FromArgb(215, 0, 0);
            }
            else if (Percentage >= 85)
            {
                CaloriesPercentage_Label.ForeColor = Color.FromArgb(200, 100, 0);
            }
            else
            {
                CaloriesPercentage_Label.ForeColor = Color.Green;
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
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateUnix(DateOfSavePicker.Value.Date + DateOfSavePicker.Value.TimeOfDay);
        }

        private void DifficultyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Byte(Offsets.Difficulty, (byte)DifficultyCombo.SelectedIndex);
        }

        private void CurrentLevelNUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            int MaxTheoreticalLevel = GetCharacterManager().GetLevel((int)ExpNumericUpDown.Value);
            if (CurrentLevelNUpDown.Value > MaxTheoreticalLevel)
            {
                CurrentLevelNUpDown.Value = MaxTheoreticalLevel;
            }

            SelectedSlot.UpdateOffset_UInt16(Offsets.CurrentLevel, (ushort)CurrentLevelNUpDown.Value);
        }

        private void MoneyNUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(Offsets.Money, (int)MoneyNUpDown.Value);
        }

        private void FpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(Offsets.Fp, (int)FpNumericUpDown.Value);
        }

        private void Calories_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            int MaxCalories = 1000 * SelectedSlot.GetPartyMembers().Count;

            if (OverateCheckbox.Checked && Calories_NumUpDown.Value < MaxCalories)
            {
                OverateCheckbox.Checked = false;
            }
            else if (!OverateCheckbox.Checked && Calories_NumUpDown.Value >= MaxCalories)
            {
                OverateCheckbox.Checked = true;
            }

            UpdateCalories();
            UpdateCaloriesPercentage();

            ReadyForUserInput = true;
        }

        private void OverateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            int MaxCalories = 1000 * SelectedSlot.GetPartyMembers().Count;

            if (OverateCheckbox.Checked)
            {
                if (Calories_NumUpDown.Value < MaxCalories)
                {
                    Calories_NumUpDown.Value = MaxCalories;
                }
            }
            else
            {
                if (Calories_NumUpDown.Value >= MaxCalories)
                {
                    Calories_NumUpDown.Value = 0;//MaxCalories - 1;
                }
            }

            UpdateCalories();
            UpdateCaloriesPercentage();

            ReadyForUserInput = true;
        }

        private void InitializedSlotCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.IsValid = InitializedSlotCheckbox.Checked ? (byte)1 : (byte)0;
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }
            else if (BackupCheckbox.Checked == false)
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

            ReadyForUserInput = false;

            if (File.Exists(OpenedSaveFile.FilePath))
            {
                File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
                ShowNotice(GetString("DLG_SaveDataSaved"));
            }
            else
            {
                SaveFileDialog NewDialog = new SaveFileDialog
                {
                    FileName = "gamesave",
                    AddExtension = false
                };

                if (NewDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenedSaveFile.FilePath = NewDialog.FileName;
                    File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
                    ShowNotice(GetString("DLG_SaveDataSaved"));
                }
            }

            ReadyForUserInput = true;
        }

        private void ExpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

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

        private void MiscFlagsEditorButton_Click(object sender, EventArgs e)
        {
            MiscEditor = new MiscEditor();
            MiscEditor.ShowDialog();
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

        private void ChangeFormSize(int Height, int Width)
        {
            if (RequiresRescaling)
            {
                this.Height = (int)Math.Floor(Height * ScaleFactor);
                this.Width = (int)Math.Floor(Width * ScaleFactor);
            }
            else
            {
                this.Height = Height;
                this.Width = Width;
            }
        }

        private void DumpSlotDebugButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SaveFileDialog DumpDialog = new SaveFileDialog
            {
                Filter = "Scramble Save Slot (*.slot)|*.slot",
                DefaultExt = "slot",
                AddExtension = true
            };

            if (DumpDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedSlot.DumpData(DumpDialog.FileName);
                ShowNotice(GetString("DLG_SaveSlotDumped"));
            }
        }

        private void ImportSlotDataButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            OpenFileDialog ImportDialog = new OpenFileDialog
            {
                Filter = "Scramble Save Slot (*.slot)|*.slot",
                DefaultExt = "slot",
                AddExtension = true
            };

            if (ImportDialog.ShowDialog() == DialogResult.OK)
            {
                try
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
                catch (Exception Exc)
                {
                    ShowWarning(Exc.Message);
                    return;
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

        private void OpenCharacterEditButton_Click(object sender, EventArgs e)
        {
            CharaStatEditor = new CharacterStatEditor();
            CharaStatEditor.ShowDialog();
        }

        private void OpenSocialEditButton_Click(object sender, EventArgs e)
        {
            SocialEditor = new SkillTreeEditor();
            SocialEditor.ShowDialog();
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

        public ImageList Get100x100PinImageList()
        {
            return PinImageList_100x100;
        }

        public ImageList Get128x128FashionImageList()
        {
            return FashionImageList_128x128;
        }

        public ImageList Get64x64FashionImageList()
        {
            return FashionImageList_64x64;
        }

        public ImageList Get170x60BrandImageList()
        {
            return BrandImageList_170x60;
        }

        public ImageList Get102x36BrandImageList()
        {
            return BrandImageList_102x36;
        }

        public ImageList Get128x128FoodImageList()
        {
            return FoodImageList_128x128;
        }

        public ImageList Get64x64FoodImageList()
        {
            return FoodImageList_64x64;
        }

        public ImageList Get32x32MiscIconsImageList()
        {
            return MiscIconsImageList_32x32;
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

        public SocialNetworkManager GetSocialNetworkManager()
        {
            return SocialManager;
        }

        public string GetGameString(string Key)
        {
            string Value;

            string Locale = GetGameLocaleManager().GetLocale(CurrentLanguage, Key);
            if (Locale.StartsWith("<PF_"))
            {
                Value = GetGameLocaleManager().GetLocale(CurrentLanguage, string.Format("PF_{0}_{1}", SwitchVersion ? "SW" : "PS4", Key));
            }
            else
            {
                Value = GetGameLocaleManager().GetLocale(CurrentLanguage, Key);
            }

            GetGameTextProcessor().ReplaceCharacterTags(ref Value);
            return Value;
        }

        public string GetReverseString(string Value)
        {
            return GetGameLocaleManager().ReverseLookup(CurrentLanguage, Value);
        }

        public string GetDayName(int Day)
        {
            bool Valid = false;
            return GetDayName(Day, ref Valid);
        }

        public string GetDayName(int Day, ref bool Valid)
        {
            if (Day == -1)
            {
                Valid = false;
                return GetString("{None}");
            }
            else if (Day == 24)
            {
                Valid = true;
                return GetGameString("Day_Name_another");
            }
            else if (Day == 22 || Day == 23)
            {
                Valid = true;
                return GetGameString(string.Format("Day_Name_w3d{0}", Day - 14));
            }

            int WeekNumber = (int)Math.Ceiling(Day / (double)7);
            int DayNumber = Day % 7;

            if (WeekNumber == 0)
            {
                WeekNumber = 1;
            }
            else if (DayNumber == 0)
            {
                DayNumber = 7;
            }

            Valid = true;
            return GetGameString(string.Format("Day_Name_w{0}d{1}", WeekNumber, DayNumber));
        }
        #endregion

        public GameTextProcessor GetGameTextProcessor()
        {
            return GameTextProcessor;
        }

        public bool CharacterIsSpoiler(byte CharaId)
        {
            return SafeCharacters.Contains(CharaId) == false;
        }

        public bool CharacterIsPartyMember(byte CharaId)
        {
            return SelectedSlot.GetPartyMemberWithCharacterId(CharaId) != null;
        }

        private void ScrambleForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            Graphics = CreateGraphics();
            ScaleFactor = Graphics.DpiX / 96;

            ChangeFormSize(Height, Width);
        }
    }
}
