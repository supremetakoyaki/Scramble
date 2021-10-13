using NTwewyDb;
using Scramble.Classes;
using Scramble.Forms;
using Scramble.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public NoisepediaEditor NoisepediaEditor;
        public DayEditor DayEditor;
        public TurfWarEditor TurfWarEditor;
        public TrophyEditor TrophyEditor;
        public ShopEditor ShopEditor;
        public PartyEditor PartyEditor;

        public SettingsEditor SettEditor;
        public MiscEditor MiscEditor;

        public NeoTwewyRandomizerForm RandomizerEditor;

        public SaveSlot SelectedSlot
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

        public SaveSlot SafeSelectedSlot
        {
            get
            {
                if (OpenedSaveFile == null)
                {
                    return null;
                }

                int Slot = 0;
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        Slot = SaveSlotsListBox.SelectedIndex;
                    }));
                }
                else
                {
                    Slot = SaveSlotsListBox.SelectedIndex;
                }

                return OpenedSaveFile.GetSaveSlot(Slot);
            }
        }

        private readonly LanguageManager LangStrings;
        public int CurrentLanguage;

        private readonly GameTextProcessor GameTextProcessor;

        #region NEO TWEWY Database instances
        private readonly ItemManager ItmManager;
        private readonly CharacterManager CharaManager;
        private readonly GameLocaleManager GameLocManager;
        private readonly SocialNetworkManager SocialManager;
        private readonly NoiseManager NoizuManager;
        #endregion

        #region Image Lists
        public ImageList ItemImageList_32x32 { get; private set; }
        public ImageList ItemImageList_64x64 { get; private set; }
        #endregion

        public bool SwitchVersion = true;

        private List<byte> SafeCharacters;
        public bool ShowSpoilers => ShowSpoilersCheckbox.Checked;

        private Bitmap MrMewInactive;
        private Bitmap MrMewActive;

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
            LogoPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Scramble_mini") as Bitmap, 200, 74, DeviceDpi);
            KofiPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("KofiDonate") as Bitmap, 128, 25, DeviceDpi);

            VersionLabel.Parent = LogoPictureBox;
            VersionLabel.Location = new Point(116, 59);
            VersionLabel.Text = Program.ScrambleVersion;
            GithubIconPictureBox.Parent = LogoPictureBox;
            GithubIconPictureBox.Location = new Point(164, 59);
            GithubIconPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("GithubIcon") as Bitmap, 15, 15, DeviceDpi);
            GbaTempIconPictureBox.Parent = LogoPictureBox;
            GbaTempIconPictureBox.Location = new Point(185, 59);
            GbaTempIconPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("GbaTempIcon") as Bitmap, 15, 15, DeviceDpi);
           
            MrMewActive = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("MrMew_Active") as Bitmap, 128, 128, DeviceDpi);
            MrMewInactive = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("MrMew_Inactive") as Bitmap, 128, 128, DeviceDpi);

            SetUpGraphics();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            DateOfSavePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            ChangeFormSize(140, 359);
            MrMewPictureBox.Image = MrMewInactive;

            // NEO TWEWY Database instances
            ItmManager = new ItemManager();
            CharaManager = new CharacterManager();
            GameLocManager = new GameLocaleManager();
            SocialManager = new SocialNetworkManager();
            NoizuManager = new NoiseManager();

            LangStrings = new LanguageManager(LanguageSelectComboBox);
            GameTextProcessor = new GameTextProcessor();

            LanguageSelectComboBox.Text = "English";
            KofiTooltip.SetToolTip(KofiPictureBox, GetString("{KofiButtonTip}"));
            ReadyForUserInput = true;

            Task.Run(() => { PopulateImageLists(); });
        }

        public void SetUpGraphics()
        {
            ScaleFactor = DeviceDpi / (double)96;
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
            MaxLevelLabel.Text = GetString("{Lv}");

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

            MenuMusicComboBox.Items.Clear();
            for (int i = 1; i < 52; i++)
            {
                MenuMusicComboBox.Items.Add(GetGameString(string.Format("MSC_Name_00{0}", i.ToString("D2"))));
            }

            if (SelectedSlot != null)
            {
                DifficultyCombo.SelectedIndex = SelectedSlot.RetrieveOffset_Byte(GameOffsets.DifficultyLevel);
                MenuMusicComboBox.SelectedIndex = SelectedSlot.RetrieveOffset_Int32(GameOffsets.MenuMusic) - 1001;

                int TheoreticalLevel = GetCharacterManager().GetLevel((int)ExpNumericUpDown.Value);
                MaxLevelLabel.Text = GetString("{Lv}") + TheoreticalLevel;

                if (OpenedSaveFile.IsPcVersion)
                {
                    PcVersionGlobalEditingNotSupportedToolTip.RemoveAll();
                    PcVersionGlobalEditingNotSupportedToolTip.SetToolTip(GlobalGroupBox, GetString("{PcGlobalYouCantEditThisYet}"));
                }
            }

            CaloriesEaten_Label.Text = GetString("{CaloriesEaten}");
            OverateCheckbox.Text = GetString("{Overate}");
            OpenTrophyEdit_Button.Text = GetString("{TrophyEditor}");
            OpenTurfWar_Edit.Text = GetString("{TurfWarEditor}");
            OpenRandomizerButton.Text = GetString("{Randomizer}");

            SaveAsButton.Text = GetString("{SaveAs}");
            SaveSlotInfoGroupBox.Text = GetString("{SlotInfo}");
            PartyGroupBox.Text = GetString("{PartyMembers}");
            OpenPartyMemberEditorButton.Text = GetString("{EditParty}");
            OtherToolsGroupBox.Text = GetString("{OtherTools}");
            StatsGroupBox.Text = GetString("{PartyStats}");
            OtherStatsGroupBox.Text = GetString("{MoreStats}");
            MenuMusicLabel.Text = GetString("{MenuMusic:}");
            OpenMismatchFixerButton.Text = GetString("{MismatchFixer}");
        }

        private void PopulateImageLists()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                    {
                        OpenClothEditButton.Enabled = false;
                        OpenClothEditButton.Text = GetString("{Loading...}");

                        OpenInvEditorButton.Enabled = false;
                        OpenInvEditorButton.Text = GetString("{Loading...}");

                        OpenRecordEditButton.Enabled = false;
                        OpenRecordEditButton.Text = GetString("{Loading...}");

                        OpenShopEdit_Button.Enabled = false;
                        OpenShopEdit_Button.Text = GetString("{Loading...}");

                        OpenPartyMemberEditorButton.Enabled = false;
                        OpenPartyMemberEditorButton.Text = GetString("{Loading...}");
                    }));
            }
            else
            {
                OpenClothEditButton.Enabled = false;
                OpenClothEditButton.Text = GetString("{Loading...}");

                OpenInvEditorButton.Enabled = false;
                OpenInvEditorButton.Text = GetString("{Loading...}");

                OpenRecordEditButton.Enabled = false;
                OpenRecordEditButton.Text = GetString("{Loading...}");

                OpenShopEdit_Button.Enabled = false;
                OpenShopEdit_Button.Text = GetString("{Loading...}");

                OpenPartyMemberEditorButton.Enabled = false;
                OpenPartyMemberEditorButton.Text = GetString("{Loading...}");
            }


            ItemImageList_32x32 = new ImageList();
            ItemImageList_64x64 = new ImageList();

            ItemImageList_32x32.ImageSize = new Size(32, 32);
            ItemImageList_32x32.ColorDepth = ColorDepth.Depth32Bit;

            ItemImageList_64x64.ImageSize = new Size(64, 64);
            ItemImageList_64x64.ColorDepth = ColorDepth.Depth32Bit;

            foreach (IGameItem GameItem in GetItemManager().GetItems().Values)
            {
                ItemImageList_32x32.Images.Add(GameItem.Sprite, ImageMethods.DrawImage(GameItem.Sprite, 32, 32, DeviceDpi));
                ItemImageList_64x64.Images.Add(GameItem.Sprite, ImageMethods.DrawImage(GameItem.Sprite, 64, 64, DeviceDpi));
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    OpenClothEditButton.Enabled = true;
                    OpenClothEditButton.Text = GetString("{ClothingEditor}");

                    OpenInvEditorButton.Enabled = true;
                    OpenInvEditorButton.Text = GetString("{PinsEditor}");

                    OpenRecordEditButton.Enabled = true;
                    OpenRecordEditButton.Text = GetString("{CollectionEditor}");

                    OpenShopEdit_Button.Enabled = true;
                    OpenShopEdit_Button.Text = GetString("{ShopEditor}");

                    OpenPartyMemberEditorButton.Enabled = true;
                    OpenPartyMemberEditorButton.Text = GetString("{EditParty}");
                }));
            }
            else
            {
                OpenClothEditButton.Enabled = true;
                OpenClothEditButton.Text = GetString("{ClothingEditor}");

                OpenInvEditorButton.Enabled = true;
                OpenInvEditorButton.Text = GetString("{PinsEditor}");

                OpenRecordEditButton.Enabled = true;
                OpenRecordEditButton.Text = GetString("{CollectionEditor}");

                OpenShopEdit_Button.Enabled = true;
                OpenShopEdit_Button.Text = GetString("{ShopEditor}");

                OpenPartyMemberEditorButton.Enabled = true;
                OpenPartyMemberEditorButton.Text = GetString("{EditParty}");
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
            byte Player_Difficulty = SelectedSlot.RetrieveOffset_Byte(GameOffsets.DifficultyLevel);
            int MenuMusic = SelectedSlot.RetrieveOffset_Int32(GameOffsets.MenuMusic);
            int Player_Experience = SelectedSlot.RetrieveOffset_Int32(GameOffsets.PlayerTeam_Exp);
            ushort Player_Current_Level = SelectedSlot.RetrieveOffset_UInt16(GameOffsets.PlayerTeam_NowLevel);
            int Player_Money = SelectedSlot.RetrieveOffset_Int32(GameOffsets.PlayerTeam_Money);
            int Player_Fp = SelectedSlot.RetrieveOffset_Int32(GameOffsets.SkillPoint);
            int Player_Calories = SelectedSlot.RetrieveOffset_Int32(GameOffsets.PlayerTeam_Satiety);
            bool Player_Overate = SelectedSlot.RetrieveOffset_Byte(GameOffsets.PlayerTeam_IsSatietyPenalty) != 0;

            if (Player_Difficulty < 4)
            {
                DifficultyCombo.SelectedIndex = Player_Difficulty;
            }
            else
            {
                DifficultyCombo.SelectedIndex = 1;
            }

            if (MenuMusic < 1001 || MenuMusic > 1051)
            {
                MenuMusic = 1001;
            }

            MenuMusicComboBox.SelectedIndex = MenuMusic - 1001;

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
            MaxLevelLabel.Text = GetString("{Lv}") + TheoreticalLevel;

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

            DayNowLabel.Text = GetGameString(GetDayName(SelectedSlot.CurrentDay));

            SerializePartyMembers();
            UpdateCaloriesPercentage();

            ReadyForUserInput = true;
        }

        public void SerializePartyMembers()
        {
            // Clear the images first
            PartyMember1_PictureBox.Image = null;
            PartyMember2_PictureBox.Image = null;
            PartyMember3_PictureBox.Image = null;
            PartyMember4_PictureBox.Image = null;
            PartyMember5_PictureBox.Image = null;
            PartyMember6_PictureBox.Image = null;

            // Clear the tooltips
            PartyMember1Tooltip.RemoveAll();
            PartyMember2Tooltip.RemoveAll();
            PartyMember3Tooltip.RemoveAll();
            PartyMember4Tooltip.RemoveAll();
            PartyMember5Tooltip.RemoveAll();
            PartyMember6Tooltip.RemoveAll();

            SafeCharacters = new List<byte>();

            foreach (PartyMember Member in SelectedSlot.GetPartyMembers().Values)
            {
                SafeCharacters.Add(Member.CharacterId);

                switch (Member.Id)
                {
                    case 1:
                        PartyMember1_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Chara{0}_party", Member.CharacterId)) as Bitmap, 44, 44, DeviceDpi);
                        PartyMember1Tooltip.SetToolTip(PartyMember1_PictureBox, GetGameString(GetCharacterManager().GetCharacterName(Member.CharacterId)));
                        break;

                    case 2:
                        PartyMember2_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Chara{0}_party", Member.CharacterId)) as Bitmap, 44, 44, DeviceDpi);
                        PartyMember2Tooltip.SetToolTip(PartyMember2_PictureBox, GetGameString(GetCharacterManager().GetCharacterName(Member.CharacterId)));
                        break;

                    case 3:
                        PartyMember3_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Chara{0}_party", Member.CharacterId)) as Bitmap, 44, 44, DeviceDpi);
                        PartyMember3Tooltip.SetToolTip(PartyMember3_PictureBox, GetGameString(GetCharacterManager().GetCharacterName(Member.CharacterId)));
                        break;

                    case 4:
                        PartyMember4_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Chara{0}_party", Member.CharacterId)) as Bitmap, 44, 44, DeviceDpi);
                        PartyMember4Tooltip.SetToolTip(PartyMember4_PictureBox, GetGameString(GetCharacterManager().GetCharacterName(Member.CharacterId)));
                        break;

                    case 5:
                        PartyMember5_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Chara{0}_party", Member.CharacterId)) as Bitmap, 44, 44, DeviceDpi);
                        PartyMember5Tooltip.SetToolTip(PartyMember5_PictureBox, GetGameString(GetCharacterManager().GetCharacterName(Member.CharacterId)));
                        break;

                    case 6:
                        PartyMember6_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("Chara{0}_party", Member.CharacterId)) as Bitmap, 44, 44, DeviceDpi);
                        PartyMember6Tooltip.SetToolTip(PartyMember6_PictureBox, GetGameString(GetCharacterManager().GetCharacterName(Member.CharacterId)));
                        break;
                }
            }

            // Always show Rindo.
            if (!SafeCharacters.Contains(1))
            {
                SafeCharacters.Add(1);
            }

            // Always show Fret.
            if (!SafeCharacters.Contains(3))
            {
                SafeCharacters.Add(3);
            }

            // Show Minamimoto if party members > 2 or furthest day > 1
            if (!SafeCharacters.Contains(7) && (SelectedSlot.GetPartyMembers().Count > 2 || SelectedSlot.FurthestDay > 1))
            {
                SafeCharacters.Add(7);
            }

            if (SelectedSlot.GetPartyMembers().Count > 5 || SelectedSlot.FurthestDay > 18) // basically we beat the game...
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
                if (!SafeCharacters.Contains(7))
                {
                    SafeCharacters.Add(7);
                }
            }
        }

        internal void SetDifficulty(int DifficultyToSet)
        {
            ReadyForUserInput = true;
            DifficultyCombo.SelectedIndex = DifficultyToSet;
        }

        internal void SetFp(int FpToSet)
        {
            ReadyForUserInput = true;
            FpNumericUpDown.Value = FpToSet;
        }

        internal void SetMoney(int MoneyToSet)
        {
            ReadyForUserInput = true;
            MoneyNUpDown.Value = MoneyToSet;
        }

        internal void SetExperience(int ExperienceToSet)
        {
            ReadyForUserInput = true;
            ExpNumericUpDown.Value = ExperienceToSet;
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

                byte Result = 0;
                try
                {
                    byte[] AllData = File.ReadAllBytes(Dialog.FileName);
                    OpenedSaveFile = new SaveFile(Dialog.FileName, AllData, out  Result);
                }
                catch (Exception Ex)
                {
                    ShowWarning(Ex.Message);
                    ReadyForUserInput = true;
                    return;
                }

                if (Result == 0)
                {
                    ShowWarning(GetString("DLG_InvalidSaveFile"));
                    OpenedSaveFile = null;

                    ChangeFormSize(140, 359);
                    ReadyForUserInput = true;
                    return;
                }

                if (OpenedSaveFile.IsPcVersion)
                {
                    GameSettingsEditorButton.Enabled = false;
                    MiscFlagsEditorButton.Enabled = false;
                    PcVersionGlobalEditingNotSupportedToolTip.SetToolTip(GlobalGroupBox, GetString("{PcGlobalYouCantEditThisYet}"));
                }
                else
                {
                    GameSettingsEditorButton.Enabled = true;
                    MiscFlagsEditorButton.Enabled = true;
                    PcVersionGlobalEditingNotSupportedToolTip.SetToolTip(GlobalGroupBox, null);
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

                ChangeFormSize(666, 697);
                Text = "Scramble — NEO TWEWY Save Editor";
            }

            ReadyForUserInput = true;
        }

        private void UpdateCalories()
        {
            SelectedSlot.UpdateOffset_Byte(GameOffsets.PlayerTeam_IsSatietyPenalty, Convert.ToByte(OverateCheckbox.Checked));
            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_Satiety, (int)Calories_NumUpDown.Value);
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

            SelectedSlot.UpdateOffset_Byte(GameOffsets.DifficultyLevel, (byte)DifficultyCombo.SelectedIndex);
        }

        private void MenuMusicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.MenuMusic, MenuMusicComboBox.SelectedIndex + 1001);
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

            SelectedSlot.UpdateOffset_UInt16(GameOffsets.PlayerTeam_NowLevel, (ushort)CurrentLevelNUpDown.Value);
        }

        private void MoneyNUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_Money, (int)MoneyNUpDown.Value);
        }

        private void FpNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.SkillPoint, (int)FpNumericUpDown.Value);
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
            if (!ReadyForUserInput || OpenedSaveFile == null)
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

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_Exp, (int)ExpNumericUpDown.Value);

            int TheoreticalLevel = GetCharacterManager().GetLevel((int)ExpNumericUpDown.Value);
            MaxLevelLabel.Text = GetString("{Lv}") + TheoreticalLevel;

            if (CurrentLevelNUpDown.Value > TheoreticalLevel)
            {
                CurrentLevelNUpDown.Value = TheoreticalLevel;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_MaxLevel, TheoreticalLevel);
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

        private void GameSettingsEditorButton_Click(object sender, EventArgs e)
        {
            SettEditor = new SettingsEditor();
            SettEditor.ShowDialog();
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://github.com/supremetakoyaki/Scramble");
        }

        private void ChangeFormSize(int Height, int Width)
        {
            if (RequiresRescaling)
            {
                this.Height = (int)Math.Floor(Height * ScaleFactor);
                this.Width = (int)Math.Floor(Width * ScaleFactor) - 2;
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

        private void OpenNoisepediaEditButton_Click(object sender, EventArgs e)
        {
            NoisepediaEditor = new NoisepediaEditor();
            NoisepediaEditor.ShowDialog();
        }

        private void OpenDayEditor_Button_Click(object sender, EventArgs e)
        {
            if (ShowSpoilers == false && ShowPrompt(GetString("DLG_ActionWillSpoil")) == false)
            {
                return;
            }

            DayEditor = new DayEditor();
            DayEditor.ShowDialog();
        }

        private void OpenTurfWar_Edit_Click(object sender, EventArgs e)
        {
            TurfWarEditor = new TurfWarEditor();
            TurfWarEditor.ShowDialog();
        }

        private void OpenTrophyEdit_Button_Click(object sender, EventArgs e)
        {
            TrophyEditor = new TrophyEditor();
            TrophyEditor.ShowDialog();
        }

        private void OpenShopEdit_Button_Click(object sender, EventArgs e)
        {
            ShopEditor = new ShopEditor();
            ShopEditor.ShowDialog();
        }

        private void LanguageSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentLanguage = LanguageSelectComboBox.SelectedIndex;
            DisplayLanguageStrings();
        }

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

        public NoiseManager GetNoiseManager()
        {
            return NoizuManager;
        }

        public string GetGameString(string Key, bool ReplaceSizeTags = false)
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

            if (ReplaceSizeTags)
            {
                Value = Value.Replace("<size=74%>", "").Replace("</size>", "");
            }

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
            ScaleFactor = DeviceDpi / 96;
            ChangeFormSize(Height, Width);
            Task.Run(PopulateImageLists);
        }

        private void OpenRandomizerButton_Click(object sender, EventArgs e)
        {
            if (ShowSpoilers == false && ShowPrompt(GetString("DLG_ActionWillSpoil")) == false)
            {
                return;
            }

            RandomizerEditor = new NeoTwewyRandomizerForm();
            RandomizerEditor.ShowDialog();
        }

        private void GithubIconPictureBox_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://github.com/supremetakoyaki/Scramble/");
        }

        private void GbaTempIconPictureBox_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://gbatemp.net/threads/scramble-neo-the-world-ends-with-you-save-editor.591780/");
        }

        private void KofiPictureBox_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://ko-fi.com/gyakutensaiban");
        }

        private void MrMewPictureBox_MouseEnter(object sender, EventArgs e)
        {
            MrMewPictureBox.Image = MrMewActive;
            ThankYou_Label.Visible = true;
        }

        private void MrMewPictureBox_MouseLeave(object sender, EventArgs e)
        {
            MrMewPictureBox.Image = MrMewInactive;
            ThankYou_Label.Visible = false;
        }

        private void OpenPartyMemberEditorButton_Click(object sender, EventArgs e)
        {
            if (ShowSpoilers == false && ShowPrompt(GetString("DLG_ActionWillSpoil")) == false)
            {
                return;
            }

            PartyEditor = new PartyEditor();
            PartyEditor.ShowDialog();
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            ReadyForUserInput = false;

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

            ReadyForUserInput = true;
        }
    }
}
