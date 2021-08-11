﻿using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class DayEditor : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private bool ReadyForUserInput = false;

        public DayEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            DisplayLanguageStrings();
            FillComboboxes();

            // for the time being.
            CurrentDay_ComboBox.Enabled = false;

            ReadyForUserInput = true;
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{DayEditor}");
            ReachedDays_GroupBox.Text = Sukuranburu.GetString("{ReachedDays}");
            CurrentDay_Label.Text = Sukuranburu.GetString("{CurrentDay:}");
            FurthestDay_Label.Text = Sukuranburu.GetString("{FurthestDay:}");
            ReachedDay_WarningLabel.Text = Sukuranburu.GetString("{ReachedDays_Warning}");
        }

        private void FillComboboxes()
        {
            for (int i = 0; i < 25; i++)
            {
                string DayName = Sukuranburu.GetDayName(i);

                CurrentDay_ComboBox.Items.Add(DayName);
                FurthestDay_ComboBox.Items.Add(DayName);
            }

            CurrentDay_ComboBox.SelectedIndex = SelectedSlot.CurrentDay;
            FurthestDay_ComboBox.SelectedIndex = SelectedSlot.FurthestDay;
        }

        private void CurrentDay_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            SelectedSlot.UpdateOffset_Int32(Offsets.CurrentDay, CurrentDay_ComboBox.SelectedIndex);

            if (CurrentDay_ComboBox.SelectedIndex > FurthestDay_ComboBox.SelectedIndex)
            {
                FurthestDay_ComboBox.SelectedIndex = CurrentDay_ComboBox.SelectedIndex;
                SelectedSlot.UpdateOffset_Int32(Offsets.MaxDay, FurthestDay_ComboBox.SelectedIndex);
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
                FurthestDay_ComboBox.SelectedIndex = SelectedSlot.FurthestDay; // return to previous value.
                ReadyForUserInput = true;
                return;
            }

            SelectedSlot.UpdateOffset_Int32(Offsets.MaxDay, FurthestDay_ComboBox.SelectedIndex);
            SelectedSlot.RetrieveDayData();
            ReadyForUserInput = true;
        }

        private void DayEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sukuranburu.DisplayCurrentDay();
        }
    }
}
