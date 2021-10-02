using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class TurfWarEditor : Form
    {
        public SaveSlot SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        public const byte TROPHY_NOPARTICIPATION = 0x00;
        public const byte TROPHY_YES_NOPLACEMENT = 0x01;
        public const byte TROPHY_YES_THIRDPLACE = 0x03;
        public const byte TROPHY_YES_SECONDPLACE = 0x07;
        public const byte TROPHY_YES_FIRSTPLACE = 0x0F;

        public const uint IDEAL_POINTS_SCRAMBLE_0 = 60000;
        public const uint IDEAL_POINTS_SCRAMBLE_1 = 400000;
        public const uint IDEAL_POINTS_SCRAMBLE_2 = 50000;

        public int CurrentPointsOffset
        {
            get
            {
                if (SelectedSlot.CurrentDay == 10) // w2d3
                {
                    return GameOffsets.StrugglePoint_w2d3;
                }

                return GameOffsets.StrugglePoint;
            }
        }

        private bool ReadyForUserInput = false;

        public TurfWarEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            if (Sukuranburu.RequiresRescaling)
            {
                TurfWar_ListView.AutoSize = true;
            }

            PointsIcon_PictureBox.Image = ImageMethods.DrawImage("Badge_icon", 50, 50, DeviceDpi);
            DisplayLanguageStrings();

            DisplayCurrentPoints();
            PopulateListView();

            TurfWarPlacement_ComboBox.SelectedIndex = 0;
            if (TurfWar_ListView.Items.Count > 0)
            {
                TurfWar_ListView.Items[0].Selected = true;
                TurfWar_ListView.Select();
            }

            DisplayTurfWar();

            ReadyForUserInput = true;
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{TurfWarEditor}");
            Points_GroupBox.Text = Sukuranburu.GetString("{Points}");
            TurfWars_GroupBox.Text = Sukuranburu.GetString("{TurfWars}");
            CurrentScore_Label.Text = Sukuranburu.GetString("{CurrentPoints:}");
            HighScore_Label.Text = Sukuranburu.GetString("{HighScore:}");
            Prizes_Label.Text = Sukuranburu.GetString("{Prizes:}");
            TurfWarNameHeader.Text = Sukuranburu.GetString("{Name}");
            MaxCurrentPoints_Button.Text = Sukuranburu.GetString("{MaxPoints}");
            MaxPrizes_Button.Text = Sukuranburu.GetString("{MaxPrizes}");
            MaxPrizes_AllScrambles_Checkbox.Text = Sukuranburu.GetString("{AllScrambles}");

            TurfWarPlacement_ComboBox.Items.Add(Sukuranburu.GetString("{NoParticipation}"));
            TurfWarPlacement_ComboBox.Items.Add(Sukuranburu.GetString("{NoPlacement}"));
            TurfWarPlacement_ComboBox.Items.Add(Sukuranburu.GetString("{OneReward}"));
            TurfWarPlacement_ComboBox.Items.Add(Sukuranburu.GetString("{TwoRewards}"));
            TurfWarPlacement_ComboBox.Items.Add(Sukuranburu.GetString("{ThreeRewards}"));
        }

        private void DisplayCurrentPoints()
        {
            uint CurrentPoints = SelectedSlot.RetrieveOffset_UInt32(CurrentPointsOffset);

            if (CurrentPoints > CurrentScore_NumUpDown.Maximum)
            {
                CurrentPoints = (uint)CurrentScore_NumUpDown.Maximum;
            }

            CurrentScore_NumUpDown.Value = CurrentPoints;
        }

        private void PopulateListView()
        {
            foreach (TurfWar TurfWar in Sukuranburu.GetNoiseManager().GetTurfWars().Values)
            {
                if (TurfWar.SaveIndex < 3) // We don't want the unused scrambles.
                {
                    ListViewItem ItemToAdd = new ListViewItem(new string[] { Sukuranburu.GetGameTextProcessor().RemoveTags(Sukuranburu.GetGameString(TurfWar.Title)) })
                    {
                        Tag = TurfWar.SaveIndex
                    };

                    TurfWar_ListView.Items.Add(ItemToAdd);
                }
            }
        }

        private void DisplayTurfWar()
        {
            if (TurfWar_ListView.SelectedItems.Count != 1)
            {
                return;
            }

            ListViewItem LvItem = TurfWar_ListView.SelectedItems[0];
            int OffsetSum = (5 * (int)LvItem.Tag);

            byte PlacementIndex = SelectedSlot.RetrieveOffset_Byte(GameOffsets.StruggleClearIsReward + OffsetSum);
            uint HighScore = SelectedSlot.RetrieveOffset_UInt32(GameOffsets.StruggleHighScore + OffsetSum);

            if (HighScore > HighScore_NumUpDown.Maximum)
            {
                HighScore = (uint)HighScore_NumUpDown.Maximum;
            }

            HighScore_NumUpDown.Value = HighScore;

            switch (PlacementIndex)
            {
                case TROPHY_NOPARTICIPATION:
                default:
                    TurfWarPlacement_ComboBox.SelectedIndex = 0;
                    break;

                case TROPHY_YES_NOPLACEMENT:
                    TurfWarPlacement_ComboBox.SelectedIndex = 1;
                    break;

                case TROPHY_YES_THIRDPLACE:
                    TurfWarPlacement_ComboBox.SelectedIndex = 2;
                    break;

                case TROPHY_YES_SECONDPLACE:
                    TurfWarPlacement_ComboBox.SelectedIndex = 3;
                    break;

                case TROPHY_YES_FIRSTPLACE:
                    TurfWarPlacement_ComboBox.SelectedIndex = 4;
                    break;
            }

            ReadyForUserInput = true;
        }

        private void TurfWar_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            DisplayTurfWar();

            ReadyForUserInput = true;
        }

        private void CurrentScore_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_UInt32(CurrentPointsOffset, (uint)CurrentScore_NumUpDown.Value);
            ReadyForUserInput = true;
        }

        private void MaxCurrentPoints_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_UInt32(CurrentPointsOffset, (uint)CurrentScore_NumUpDown.Maximum);
            CurrentScore_NumUpDown.Value = CurrentScore_NumUpDown.Maximum;
            ReadyForUserInput = true;
        }

        private void HighScore_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || TurfWar_ListView.SelectedItems.Count != 1)
            {
                return;
            }

            ReadyForUserInput = false;

            ListViewItem LvItem = TurfWar_ListView.SelectedItems[0];
            int OffsetSum = (5 * (int)LvItem.Tag);

            SelectedSlot.UpdateOffset_UInt32(GameOffsets.StruggleHighScore + OffsetSum, (uint)HighScore_NumUpDown.Value);
            ReadyForUserInput = true;
        }

        private void TurfWarPlacement_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || TurfWar_ListView.SelectedItems.Count != 1)
            {
                return;
            }

            ReadyForUserInput = false;

            ListViewItem LvItem = TurfWar_ListView.SelectedItems[0];
            int OffsetSum = (5 * (int)LvItem.Tag);

            byte ValueToSet;

            switch (TurfWarPlacement_ComboBox.SelectedIndex)
            {
                case 0:
                default:
                    ValueToSet = TROPHY_NOPARTICIPATION;
                    break;

                case 1:
                    ValueToSet = TROPHY_YES_NOPLACEMENT;
                    break;

                case 2:
                    ValueToSet = TROPHY_YES_THIRDPLACE;
                    break;

                case 3:
                    ValueToSet = TROPHY_YES_SECONDPLACE;
                    break;

                case 4:
                    ValueToSet = TROPHY_YES_FIRSTPLACE;
                    break;
            }

            SelectedSlot.UpdateOffset_Byte(GameOffsets.StruggleClearIsReward + OffsetSum, ValueToSet);
            ReadyForUserInput = true;
        }

        private void MaxPrizes_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (MaxPrizes_AllScrambles_Checkbox.Checked)
            {
                SelectedSlot.UpdateOffset_Byte(GameOffsets.StruggleClearIsReward, TROPHY_YES_FIRSTPLACE);
                SelectedSlot.UpdateOffset_Byte(GameOffsets.StruggleClearIsReward + 5, TROPHY_YES_FIRSTPLACE);
                SelectedSlot.UpdateOffset_Byte(GameOffsets.StruggleClearIsReward + 10, TROPHY_YES_FIRSTPLACE);
                SelectedSlot.UpdateOffset_UInt32(GameOffsets.StruggleHighScore, IDEAL_POINTS_SCRAMBLE_0);
                SelectedSlot.UpdateOffset_UInt32(GameOffsets.StruggleHighScore + 5, IDEAL_POINTS_SCRAMBLE_1);
                SelectedSlot.UpdateOffset_UInt32(GameOffsets.StruggleHighScore + 10, IDEAL_POINTS_SCRAMBLE_2);

                if (TurfWar_ListView.SelectedItems.Count == 1)
                {
                    ListViewItem LvItem = TurfWar_ListView.SelectedItems[0];
                    int SaveIndex = (int)LvItem.Tag;

                    if (SaveIndex == 0)
                    {
                        HighScore_NumUpDown.Value = IDEAL_POINTS_SCRAMBLE_0;
                    }
                    else if (SaveIndex == 1)
                    {
                        HighScore_NumUpDown.Value = IDEAL_POINTS_SCRAMBLE_1;
                    }
                    else if (SaveIndex == 2)
                    {
                        HighScore_NumUpDown.Value = IDEAL_POINTS_SCRAMBLE_2;
                    }

                    TurfWarPlacement_ComboBox.SelectedIndex = 4;
                }
            }
            else if (TurfWar_ListView.SelectedItems.Count == 1)
            {
                ListViewItem LvItem = TurfWar_ListView.SelectedItems[0];
                int SaveIndex = (int)LvItem.Tag;

                if (SaveIndex == 0)
                {
                    HighScore_NumUpDown.Value = IDEAL_POINTS_SCRAMBLE_0;
                }
                else if (SaveIndex == 1)
                {
                    HighScore_NumUpDown.Value = IDEAL_POINTS_SCRAMBLE_1;
                }
                else if (SaveIndex == 2)
                {
                    HighScore_NumUpDown.Value = IDEAL_POINTS_SCRAMBLE_2;
                }

                TurfWarPlacement_ComboBox.SelectedIndex = 4;
                SelectedSlot.UpdateOffset_UInt32(GameOffsets.StruggleHighScore + (5 * SaveIndex), (uint)HighScore_NumUpDown.Value);
                SelectedSlot.UpdateOffset_Byte(GameOffsets.StruggleClearIsReward + (5 * SaveIndex), TROPHY_YES_FIRSTPLACE);
            }

            ReadyForUserInput = true;
        }
    }
}
