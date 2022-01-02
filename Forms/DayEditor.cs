using Scramble.Classes;
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
            ChapterListListView.SmallImageList = Sukuranburu.ChapterIconImageList_144x32;

            DisplayLanguageStrings();
            FillChapterLists();

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
    }
}
