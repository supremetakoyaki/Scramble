using NTwewyDb;
using Scramble.Classes;
using Scramble.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class DayEditor : Form
    {
        public SaveSlot SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private bool ReadyForUserInput = false;

        public DayEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (Sukuranburu.RequiresRescaling)
            {
                ChapterListListView.AutoSize = true;
                PigNoiseListView.AutoSize = true;
                ConnectedSocialQuestsListView.AutoSize = true;
                NagiDiveGoldRanksListView.AutoSize = true;
            }

            ChapterListListView.SmallImageList = Sukuranburu.ChapterIconImageList_144x32;
            PigNoiseIcon_PictureBox.Image = ImageMethods.DrawImage("Chapter_pig_icon01", 80, 80, DeviceDpi);
            SocialQuests_PictureBox.Image = ImageMethods.DrawImage("Friendship_icon", 66, 80, DeviceDpi);
            DiveGoldRanks_PictureBox.Image = ImageMethods.DrawImage("Dive_icon_medal_05", 66, 66, DeviceDpi);

            DisplayLanguageStrings();
            FillChapterLists();

            ChapterListListView.Items[0].Selected = true;
            ChapterListListView.Select();
            ReadyForUserInput = true;
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{DayEditor}");
            ReachedDays_GroupBox.Text = Sukuranburu.GetString("{ReachedDays}");
            CurrentDay_Label.Text = Sukuranburu.GetString("{CurrentDay:}");
            FurthestDay_Label.Text = Sukuranburu.GetString("{FurthestDay:}");
            ChaptersGroupBox.Text = Sukuranburu.GetString("{Chapters}");
            NameHeader.Text = Sukuranburu.GetString("{Name}");
            AdvancedEventGroupBox.Text = Sukuranburu.GetString("{AdvancedEditing}");
            EditScenarioButton.Text = Sukuranburu.GetString("{EditScenario}");
            EditEventButton.Text = Sukuranburu.GetString("{EditEvent}");
            EditEventLogButton.Text = Sukuranburu.GetString("{EditEventLog}");
            EditEventLogSelectButton.Text = Sukuranburu.GetString("{EditEventLogSelect}");
            PigNoiseLabel.Text = Sukuranburu.GetString("{PigNoise:}");
            SocialQuestsLabel.Text = Sukuranburu.GetString("{SocialQuests:}");
            NagiDiveGoldRanksLabel.Text = Sukuranburu.GetString("{NagiDiveGoldRanks:}");
            PigNoiseIdHeader.Text = Sukuranburu.GetString("{Id}");
            SocialTreeIdHeader.Text = Sukuranburu.GetString("{Id}");
            SocialTreeNameHeader.Text = Sukuranburu.GetString("{Name}");
            DiveGoldRankIdHeader.Text = Sukuranburu.GetString("{Id}");
        }

        private void FillChapterLists()
        {
            for (int i = 0; i < 25; i++)
            {
                string DayName = Sukuranburu.GetDayName(i);
                CurrentDay_ComboBox.Items.Add(DayName);
                FurthestDay_ComboBox.Items.Add(DayName);

                ChapterListListView.Items.Add(new ListViewItem(DayName)
                {
                    Tag = i,
                    ImageKey = $"Chapter_btn{i:00}"
                });
            }

            FurthestDay_ComboBox.Items.Add(Sukuranburu.GetString("{BeatTheGame}"));

            CurrentDay_ComboBox.SelectedIndex = SelectedSlot.CurrentDay;
            if (SelectedSlot.FurthestDay > 24)
            {
                FurthestDay_ComboBox.SelectedIndex = 25;
            }
            else
            {
                FurthestDay_ComboBox.SelectedIndex = SelectedSlot.FurthestDay;
            }
        }

        private void SelectChapter()
        {
            if (ChapterListListView.SelectedItems.Count != 1)
            {
                return;
            }

            byte ChapterId = Convert.ToByte((int)ChapterListListView.SelectedItems[0].Tag);
            Chapter SelectedChapter = Sukuranburu.GetScenarioManager().GetChapter(ChapterId);
            if (SelectedChapter == null)
            {
                return;
            }

            ChapterNameLabel.Text = Sukuranburu.GetDayName(ChapterId);
            PigNoiseListView.Items.Clear();
            ConnectedSocialQuestsListView.Items.Clear();
            NagiDiveGoldRanksListView.Items.Clear();

            if (SelectedChapter.PigNoise != null && SelectedChapter.PigNoise.Length > 0)
            {
                PigNoiseListView.Enabled = true;
                for (int i = 0; i < SelectedChapter.PigNoise.Length; i++)
                {
                    uint PigNoiseId = SelectedChapter.PigNoise[i];
                    PigNoiseListView.Items.Add(new ListViewItem(PigNoiseId.ToString())
                    {
                        Tag = PigNoiseId,
                        Checked = RetrievePigNoiseValue(PigNoiseId)
                    });
                }
            }
            else
            {
                PigNoiseListView.Enabled = false;
            }

            if (SelectedChapter.SubmissionSkill != null && SelectedChapter.SubmissionSkill.Length > 0)
            {
                ConnectedSocialQuestsListView.Enabled = true;
                for (int i = 0; i < SelectedChapter.SubmissionSkill.Length; i++)
                {
                    byte SkillTreeId = SelectedChapter.SubmissionSkill[i];
                    string SkillTreeName = Sukuranburu.GetString("{Unknown}");
                    bool ConnectionStatus = false;

                    SkillTree SkillTreeItem = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItem(SkillTreeId);
                    if (SkillTreeItem != null)
                    {
                        SkillTreeName = Sukuranburu.GetGameString(SkillTreeItem.CharacterName);
                        ConnectionStatus = ByteUtil.GetBit(SelectedSlot.RetrieveOffset_Byte(GameOffsets.SkillTreeFlags + SkillTreeItem.SaveIndex), 6);
                    }

                    ConnectedSocialQuestsListView.Items.Add(new ListViewItem(new string[] { SkillTreeId.ToString(), SkillTreeName })
                    {
                        Tag = SkillTreeId,
                        Checked = ConnectionStatus
                    });
                }
            }
            else
            {
                ConnectedSocialQuestsListView.Enabled = false;
            }

            if (SelectedChapter.DiveId != null && SelectedChapter.SubmissionSkill.Length > 0)
            {
                NagiDiveGoldRanksListView.Enabled = true;
                for (int i = 0; i < SelectedChapter.DiveId.Length; i++)
                {
                    uint DiveId = SelectedChapter.DiveId[i];

                    NagiDiveGoldRanksListView.Items.Add(new ListViewItem(DiveId.ToString())
                    {
                        Tag = DiveId,
                        Checked = false
                    });
                }
            }
            else
            {
                NagiDiveGoldRanksListView.Enabled = false;
            }
        }

        private bool RetrievePigNoiseValue(uint PigNoiseId)
        {
            int OffsetSum = (int)PigNoiseId / 8;
            byte ByteToSet = SelectedSlot.RetrieveOffset_Byte(GameOffsets.PigDefeatNoiseFlag + OffsetSum);
            byte BitIndex = (byte)(PigNoiseId % 8);

            return ByteUtil.GetBit(ByteToSet, BitIndex);
        }

        private void UpdatePigNoiseValue(uint PigNoiseId, bool Value)
        {
            int OffsetSum = (int)PigNoiseId / 8;
            byte ByteToSet = SelectedSlot.RetrieveOffset_Byte(GameOffsets.PigDefeatNoiseFlag + OffsetSum);
            byte BitIndex = (byte)(PigNoiseId % 8);

            ByteToSet = ByteUtil.SetBit(ByteToSet, BitIndex, Value);
            SelectedSlot.UpdateOffset_Byte(GameOffsets.PigDefeatNoiseFlag + OffsetSum, ByteToSet);
        }

        private void CurrentDay_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            SelectedSlot.UpdateOffset_Int32(GameOffsets.CurrentPlayDateDay, CurrentDay_ComboBox.SelectedIndex);

            if (CurrentDay_ComboBox.SelectedIndex > FurthestDay_ComboBox.SelectedIndex)
            {
                FurthestDay_ComboBox.SelectedIndex = CurrentDay_ComboBox.SelectedIndex;
                SelectedSlot.UpdateOffset_Int32(GameOffsets.ScenarioNewestDateDay, FurthestDay_ComboBox.SelectedIndex);
            }

            SelectedSlot.RetrieveDayData();
            ReadyForUserInput = true;
        }

        private void FurthestDay_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (FurthestDay_ComboBox.SelectedIndex < CurrentDay_ComboBox.SelectedIndex)
            {
                Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_FurthestDayCantBeLowerThanCurrentDay"));
                if (SelectedSlot.FurthestDay > 24)
                {
                    FurthestDay_ComboBox.SelectedIndex = 25;
                }
                else
                {
                    FurthestDay_ComboBox.SelectedIndex = SelectedSlot.FurthestDay; // return to previous value.
                }
                ReadyForUserInput = true;
                return;
            }

            if (FurthestDay_ComboBox.SelectedIndex == 25)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.ScenarioNewestDateDay, 99);
            }
            else
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.ScenarioNewestDateDay, FurthestDay_ComboBox.SelectedIndex);
            }
            SelectedSlot.RetrieveDayData();
            ReadyForUserInput = true;
        }

        private void ChapterListListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectChapter();
            ReadyForUserInput = true;
        }


        private void PigNoiseListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ListViewItem Item = e.Item;
            if (Item == null)
            {
                return;
            }

            ReadyForUserInput = false;
            uint PigNoiseId = (uint)Item.Tag;
            UpdatePigNoiseValue(PigNoiseId, Item.Checked);
            ReadyForUserInput = true;
        }

        private void ConnectedSocialQuestsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ListViewItem Item = e.Item;
            if (Item == null)
            {
                return;
            }

            SkillTree TreeItem = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItem((byte)Item.Tag);
            if (TreeItem == null)
            {
                return;
            }

            ReadyForUserInput = false;
            int Offset = GameOffsets.SkillTreeFlags + TreeItem.SaveIndex;
            byte ValueToSet = SelectedSlot.RetrieveOffset_Byte(Offset);
            ValueToSet = ByteUtil.SetBit(ValueToSet, 6, Item.Checked);
            SelectedSlot.UpdateOffset_Byte(Offset, ValueToSet);

            if (Item.Checked == false)
            {
                Skill SkillItem = Sukuranburu.GetSocialNetworkManager().GetSkill((ushort)TreeItem.SkillId);

                if (SkillItem != null)
                {
                    int SkillOffsetSum = SkillItem.SaveIndex / 8;
                    byte SkillByteToSet = SelectedSlot.RetrieveOffset_Byte(GameOffsets.SkillFlag + SkillOffsetSum);
                    byte SkillBitIndex = (byte)(SkillItem.SaveIndex % 8);

                    SkillByteToSet = ByteUtil.SetBit(SkillByteToSet, SkillBitIndex, false);
                    SelectedSlot.UpdateOffset_Byte(GameOffsets.SkillFlag + SkillOffsetSum, SkillByteToSet);
                }
            }

            ReadyForUserInput = true;
        }

        private void PigNoiseDefeatAll_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            foreach (ListViewItem Item in PigNoiseListView.Items)
            {
                Item.Checked = true;
            }

            foreach (Chapter ChapterItem in Sukuranburu.GetScenarioManager().GetChapters().Values)
            {
                if (ChapterItem.PigNoise != null)
                {
                    foreach (uint PigNoiseId in ChapterItem.PigNoise)
                    {
                        UpdatePigNoiseValue(PigNoiseId, true);
                    }
                }
            }

            ReadyForUserInput = true;
        }
    }
}
