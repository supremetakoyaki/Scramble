
namespace Scramble.Forms
{
    partial class DayEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReachedDays_GroupBox = new System.Windows.Forms.GroupBox();
            this.FurthestDay_ComboBox = new System.Windows.Forms.ComboBox();
            this.FurthestDay_Label = new System.Windows.Forms.Label();
            this.CurrentDay_ComboBox = new System.Windows.Forms.ComboBox();
            this.CurrentDay_Label = new System.Windows.Forms.Label();
            this.ChaptersGroupBox = new System.Windows.Forms.GroupBox();
            this.DiveGoldRanks_PictureBox = new System.Windows.Forms.PictureBox();
            this.SocialQuests_PictureBox = new System.Windows.Forms.PictureBox();
            this.PigNoiseIcon_PictureBox = new System.Windows.Forms.PictureBox();
            this.NagiDiveGoldRanksListView = new System.Windows.Forms.ListView();
            this.DiveGoldRankIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NagiDiveGoldRanksLabel = new System.Windows.Forms.Label();
            this.ConnectedSocialQuestsListView = new System.Windows.Forms.ListView();
            this.SocialTreeIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SocialTreeNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SocialQuestsLabel = new System.Windows.Forms.Label();
            this.PigNoiseListView = new System.Windows.Forms.ListView();
            this.PigNoiseIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PigNoiseLabel = new System.Windows.Forms.Label();
            this.ChapterNameLabel = new System.Windows.Forms.Label();
            this.ChapterListListView = new System.Windows.Forms.ListView();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdvancedEventGroupBox = new System.Windows.Forms.GroupBox();
            this.ComingSoonLabel = new System.Windows.Forms.Label();
            this.EditEventLogSelectButton = new System.Windows.Forms.Button();
            this.EditEventLogButton = new System.Windows.Forms.Button();
            this.EditEventButton = new System.Windows.Forms.Button();
            this.EditScenarioButton = new System.Windows.Forms.Button();
            this.PigNoiseDefeatAll_Button = new System.Windows.Forms.Button();
            this.ReachedDays_GroupBox.SuspendLayout();
            this.ChaptersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiveGoldRanks_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SocialQuests_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PigNoiseIcon_PictureBox)).BeginInit();
            this.AdvancedEventGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReachedDays_GroupBox
            // 
            this.ReachedDays_GroupBox.Controls.Add(this.FurthestDay_ComboBox);
            this.ReachedDays_GroupBox.Controls.Add(this.FurthestDay_Label);
            this.ReachedDays_GroupBox.Controls.Add(this.CurrentDay_ComboBox);
            this.ReachedDays_GroupBox.Controls.Add(this.CurrentDay_Label);
            this.ReachedDays_GroupBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ReachedDays_GroupBox.Location = new System.Drawing.Point(10, 12);
            this.ReachedDays_GroupBox.Name = "ReachedDays_GroupBox";
            this.ReachedDays_GroupBox.Size = new System.Drawing.Size(352, 76);
            this.ReachedDays_GroupBox.TabIndex = 0;
            this.ReachedDays_GroupBox.TabStop = false;
            this.ReachedDays_GroupBox.Text = "{ReachedDays}";
            // 
            // FurthestDay_ComboBox
            // 
            this.FurthestDay_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FurthestDay_ComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FurthestDay_ComboBox.FormattingEnabled = true;
            this.FurthestDay_ComboBox.Location = new System.Drawing.Point(166, 47);
            this.FurthestDay_ComboBox.Name = "FurthestDay_ComboBox";
            this.FurthestDay_ComboBox.Size = new System.Drawing.Size(180, 23);
            this.FurthestDay_ComboBox.TabIndex = 3;
            this.FurthestDay_ComboBox.SelectedIndexChanged += new System.EventHandler(this.FurthestDay_ComboBox_SelectedIndexChanged);
            // 
            // FurthestDay_Label
            // 
            this.FurthestDay_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FurthestDay_Label.Location = new System.Drawing.Point(6, 47);
            this.FurthestDay_Label.Name = "FurthestDay_Label";
            this.FurthestDay_Label.Size = new System.Drawing.Size(154, 19);
            this.FurthestDay_Label.TabIndex = 2;
            this.FurthestDay_Label.Text = "{FurthestDay:}";
            // 
            // CurrentDay_ComboBox
            // 
            this.CurrentDay_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentDay_ComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CurrentDay_ComboBox.FormattingEnabled = true;
            this.CurrentDay_ComboBox.Location = new System.Drawing.Point(166, 18);
            this.CurrentDay_ComboBox.Name = "CurrentDay_ComboBox";
            this.CurrentDay_ComboBox.Size = new System.Drawing.Size(180, 23);
            this.CurrentDay_ComboBox.TabIndex = 1;
            this.CurrentDay_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrentDay_ComboBox_SelectedIndexChanged);
            // 
            // CurrentDay_Label
            // 
            this.CurrentDay_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.CurrentDay_Label.Location = new System.Drawing.Point(6, 19);
            this.CurrentDay_Label.Name = "CurrentDay_Label";
            this.CurrentDay_Label.Size = new System.Drawing.Size(154, 19);
            this.CurrentDay_Label.TabIndex = 0;
            this.CurrentDay_Label.Text = "{CurrentDay:}";
            // 
            // ChaptersGroupBox
            // 
            this.ChaptersGroupBox.Controls.Add(this.PigNoiseDefeatAll_Button);
            this.ChaptersGroupBox.Controls.Add(this.DiveGoldRanks_PictureBox);
            this.ChaptersGroupBox.Controls.Add(this.SocialQuests_PictureBox);
            this.ChaptersGroupBox.Controls.Add(this.PigNoiseIcon_PictureBox);
            this.ChaptersGroupBox.Controls.Add(this.NagiDiveGoldRanksListView);
            this.ChaptersGroupBox.Controls.Add(this.NagiDiveGoldRanksLabel);
            this.ChaptersGroupBox.Controls.Add(this.ConnectedSocialQuestsListView);
            this.ChaptersGroupBox.Controls.Add(this.SocialQuestsLabel);
            this.ChaptersGroupBox.Controls.Add(this.PigNoiseListView);
            this.ChaptersGroupBox.Controls.Add(this.PigNoiseLabel);
            this.ChaptersGroupBox.Controls.Add(this.ChapterNameLabel);
            this.ChaptersGroupBox.Controls.Add(this.ChapterListListView);
            this.ChaptersGroupBox.Location = new System.Drawing.Point(10, 94);
            this.ChaptersGroupBox.Name = "ChaptersGroupBox";
            this.ChaptersGroupBox.Size = new System.Drawing.Size(712, 381);
            this.ChaptersGroupBox.TabIndex = 1;
            this.ChaptersGroupBox.TabStop = false;
            this.ChaptersGroupBox.Text = "{Chapters}";
            // 
            // DiveGoldRanks_PictureBox
            // 
            this.DiveGoldRanks_PictureBox.Location = new System.Drawing.Point(626, 295);
            this.DiveGoldRanks_PictureBox.Name = "DiveGoldRanks_PictureBox";
            this.DiveGoldRanks_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.DiveGoldRanks_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DiveGoldRanks_PictureBox.TabIndex = 10;
            this.DiveGoldRanks_PictureBox.TabStop = false;
            // 
            // SocialQuests_PictureBox
            // 
            this.SocialQuests_PictureBox.Location = new System.Drawing.Point(626, 182);
            this.SocialQuests_PictureBox.Name = "SocialQuests_PictureBox";
            this.SocialQuests_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.SocialQuests_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SocialQuests_PictureBox.TabIndex = 9;
            this.SocialQuests_PictureBox.TabStop = false;
            // 
            // PigNoiseIcon_PictureBox
            // 
            this.PigNoiseIcon_PictureBox.Location = new System.Drawing.Point(626, 72);
            this.PigNoiseIcon_PictureBox.Name = "PigNoiseIcon_PictureBox";
            this.PigNoiseIcon_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.PigNoiseIcon_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PigNoiseIcon_PictureBox.TabIndex = 8;
            this.PigNoiseIcon_PictureBox.TabStop = false;
            // 
            // NagiDiveGoldRanksListView
            // 
            this.NagiDiveGoldRanksListView.CheckBoxes = true;
            this.NagiDiveGoldRanksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DiveGoldRankIdHeader});
            this.NagiDiveGoldRanksListView.HideSelection = false;
            this.NagiDiveGoldRanksListView.Location = new System.Drawing.Point(364, 295);
            this.NagiDiveGoldRanksListView.MultiSelect = false;
            this.NagiDiveGoldRanksListView.Name = "NagiDiveGoldRanksListView";
            this.NagiDiveGoldRanksListView.Size = new System.Drawing.Size(256, 80);
            this.NagiDiveGoldRanksListView.TabIndex = 7;
            this.NagiDiveGoldRanksListView.UseCompatibleStateImageBehavior = false;
            this.NagiDiveGoldRanksListView.View = System.Windows.Forms.View.Details;
            // 
            // DiveGoldRankIdHeader
            // 
            this.DiveGoldRankIdHeader.Text = "{Id}";
            this.DiveGoldRankIdHeader.Width = 210;
            // 
            // NagiDiveGoldRanksLabel
            // 
            this.NagiDiveGoldRanksLabel.AutoSize = true;
            this.NagiDiveGoldRanksLabel.Location = new System.Drawing.Point(365, 277);
            this.NagiDiveGoldRanksLabel.Name = "NagiDiveGoldRanksLabel";
            this.NagiDiveGoldRanksLabel.Size = new System.Drawing.Size(122, 15);
            this.NagiDiveGoldRanksLabel.TabIndex = 6;
            this.NagiDiveGoldRanksLabel.Text = "{NagiDiveGoldRanks:}";
            // 
            // ConnectedSocialQuestsListView
            // 
            this.ConnectedSocialQuestsListView.CheckBoxes = true;
            this.ConnectedSocialQuestsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SocialTreeIdHeader,
            this.SocialTreeNameHeader});
            this.ConnectedSocialQuestsListView.HideSelection = false;
            this.ConnectedSocialQuestsListView.Location = new System.Drawing.Point(364, 182);
            this.ConnectedSocialQuestsListView.MultiSelect = false;
            this.ConnectedSocialQuestsListView.Name = "ConnectedSocialQuestsListView";
            this.ConnectedSocialQuestsListView.Size = new System.Drawing.Size(256, 80);
            this.ConnectedSocialQuestsListView.TabIndex = 5;
            this.ConnectedSocialQuestsListView.UseCompatibleStateImageBehavior = false;
            this.ConnectedSocialQuestsListView.View = System.Windows.Forms.View.Details;
            this.ConnectedSocialQuestsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ConnectedSocialQuestsListView_ItemChecked);
            // 
            // SocialTreeIdHeader
            // 
            this.SocialTreeIdHeader.Text = "{Id}";
            this.SocialTreeIdHeader.Width = 50;
            // 
            // SocialTreeNameHeader
            // 
            this.SocialTreeNameHeader.Text = "{Name}";
            this.SocialTreeNameHeader.Width = 160;
            // 
            // SocialQuestsLabel
            // 
            this.SocialQuestsLabel.AutoSize = true;
            this.SocialQuestsLabel.Location = new System.Drawing.Point(364, 164);
            this.SocialQuestsLabel.Name = "SocialQuestsLabel";
            this.SocialQuestsLabel.Size = new System.Drawing.Size(85, 15);
            this.SocialQuestsLabel.TabIndex = 4;
            this.SocialQuestsLabel.Text = "{SocialQuests:}";
            // 
            // PigNoiseListView
            // 
            this.PigNoiseListView.CheckBoxes = true;
            this.PigNoiseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PigNoiseIdHeader});
            this.PigNoiseListView.HideSelection = false;
            this.PigNoiseListView.Location = new System.Drawing.Point(364, 72);
            this.PigNoiseListView.MultiSelect = false;
            this.PigNoiseListView.Name = "PigNoiseListView";
            this.PigNoiseListView.Size = new System.Drawing.Size(256, 80);
            this.PigNoiseListView.TabIndex = 3;
            this.PigNoiseListView.UseCompatibleStateImageBehavior = false;
            this.PigNoiseListView.View = System.Windows.Forms.View.Details;
            this.PigNoiseListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.PigNoiseListView_ItemChecked);
            // 
            // PigNoiseIdHeader
            // 
            this.PigNoiseIdHeader.Text = "{Id}";
            this.PigNoiseIdHeader.Width = 210;
            // 
            // PigNoiseLabel
            // 
            this.PigNoiseLabel.AutoSize = true;
            this.PigNoiseLabel.Location = new System.Drawing.Point(364, 54);
            this.PigNoiseLabel.Name = "PigNoiseLabel";
            this.PigNoiseLabel.Size = new System.Drawing.Size(65, 15);
            this.PigNoiseLabel.TabIndex = 2;
            this.PigNoiseLabel.Text = "{PigNoise:}";
            // 
            // ChapterNameLabel
            // 
            this.ChapterNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChapterNameLabel.Location = new System.Drawing.Point(364, 22);
            this.ChapterNameLabel.Name = "ChapterNameLabel";
            this.ChapterNameLabel.Size = new System.Drawing.Size(256, 17);
            this.ChapterNameLabel.TabIndex = 1;
            this.ChapterNameLabel.Text = "{SelectedChapterName}";
            // 
            // ChapterListListView
            // 
            this.ChapterListListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader});
            this.ChapterListListView.HideSelection = false;
            this.ChapterListListView.Location = new System.Drawing.Point(6, 22);
            this.ChapterListListView.MultiSelect = false;
            this.ChapterListListView.Name = "ChapterListListView";
            this.ChapterListListView.Size = new System.Drawing.Size(352, 324);
            this.ChapterListListView.TabIndex = 0;
            this.ChapterListListView.UseCompatibleStateImageBehavior = false;
            this.ChapterListListView.View = System.Windows.Forms.View.Details;
            this.ChapterListListView.SelectedIndexChanged += new System.EventHandler(this.ChapterListListView_SelectedIndexChanged);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "{Name}";
            this.NameHeader.Width = 325;
            // 
            // AdvancedEventGroupBox
            // 
            this.AdvancedEventGroupBox.Controls.Add(this.ComingSoonLabel);
            this.AdvancedEventGroupBox.Controls.Add(this.EditEventLogSelectButton);
            this.AdvancedEventGroupBox.Controls.Add(this.EditEventLogButton);
            this.AdvancedEventGroupBox.Controls.Add(this.EditEventButton);
            this.AdvancedEventGroupBox.Controls.Add(this.EditScenarioButton);
            this.AdvancedEventGroupBox.Location = new System.Drawing.Point(368, 12);
            this.AdvancedEventGroupBox.Name = "AdvancedEventGroupBox";
            this.AdvancedEventGroupBox.Size = new System.Drawing.Size(354, 76);
            this.AdvancedEventGroupBox.TabIndex = 2;
            this.AdvancedEventGroupBox.TabStop = false;
            this.AdvancedEventGroupBox.Text = "{Advanced}";
            // 
            // ComingSoonLabel
            // 
            this.ComingSoonLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComingSoonLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ComingSoonLabel.Location = new System.Drawing.Point(6, 18);
            this.ComingSoonLabel.Name = "ComingSoonLabel";
            this.ComingSoonLabel.Size = new System.Drawing.Size(342, 55);
            this.ComingSoonLabel.TabIndex = 6;
            this.ComingSoonLabel.Text = "Coming Soon";
            this.ComingSoonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditEventLogSelectButton
            // 
            this.EditEventLogSelectButton.Enabled = false;
            this.EditEventLogSelectButton.Location = new System.Drawing.Point(125, 47);
            this.EditEventLogSelectButton.Name = "EditEventLogSelectButton";
            this.EditEventLogSelectButton.Size = new System.Drawing.Size(113, 23);
            this.EditEventLogSelectButton.TabIndex = 3;
            this.EditEventLogSelectButton.Text = "EventLogSelect";
            this.EditEventLogSelectButton.UseVisualStyleBackColor = true;
            // 
            // EditEventLogButton
            // 
            this.EditEventLogButton.Enabled = false;
            this.EditEventLogButton.Location = new System.Drawing.Point(6, 47);
            this.EditEventLogButton.Name = "EditEventLogButton";
            this.EditEventLogButton.Size = new System.Drawing.Size(113, 23);
            this.EditEventLogButton.TabIndex = 2;
            this.EditEventLogButton.Text = "EventLog";
            this.EditEventLogButton.UseVisualStyleBackColor = true;
            // 
            // EditEventButton
            // 
            this.EditEventButton.Enabled = false;
            this.EditEventButton.Location = new System.Drawing.Point(125, 19);
            this.EditEventButton.Name = "EditEventButton";
            this.EditEventButton.Size = new System.Drawing.Size(113, 23);
            this.EditEventButton.TabIndex = 1;
            this.EditEventButton.Text = "Event";
            this.EditEventButton.UseVisualStyleBackColor = true;
            // 
            // EditScenarioButton
            // 
            this.EditScenarioButton.Enabled = false;
            this.EditScenarioButton.Location = new System.Drawing.Point(6, 19);
            this.EditScenarioButton.Name = "EditScenarioButton";
            this.EditScenarioButton.Size = new System.Drawing.Size(113, 23);
            this.EditScenarioButton.TabIndex = 0;
            this.EditScenarioButton.Text = "Scenario";
            this.EditScenarioButton.UseVisualStyleBackColor = true;
            // 
            // PigNoiseDefeatAll_Button
            // 
            this.PigNoiseDefeatAll_Button.Location = new System.Drawing.Point(6, 352);
            this.PigNoiseDefeatAll_Button.Name = "PigNoiseDefeatAll_Button";
            this.PigNoiseDefeatAll_Button.Size = new System.Drawing.Size(154, 23);
            this.PigNoiseDefeatAll_Button.TabIndex = 11;
            this.PigNoiseDefeatAll_Button.Text = "All Pig Noise Defeated";
            this.PigNoiseDefeatAll_Button.UseVisualStyleBackColor = true;
            this.PigNoiseDefeatAll_Button.Click += new System.EventHandler(this.PigNoiseDefeatAll_Button_Click);
            // 
            // DayEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(734, 487);
            this.Controls.Add(this.AdvancedEventGroupBox);
            this.Controls.Add(this.ChaptersGroupBox);
            this.Controls.Add(this.ReachedDays_GroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DayEditor";
            this.Text = "{DayEditor}";
            this.ReachedDays_GroupBox.ResumeLayout(false);
            this.ChaptersGroupBox.ResumeLayout(false);
            this.ChaptersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiveGoldRanks_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SocialQuests_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PigNoiseIcon_PictureBox)).EndInit();
            this.AdvancedEventGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ReachedDays_GroupBox;
        private System.Windows.Forms.ComboBox FurthestDay_ComboBox;
        private System.Windows.Forms.Label FurthestDay_Label;
        private System.Windows.Forms.ComboBox CurrentDay_ComboBox;
        private System.Windows.Forms.Label CurrentDay_Label;
        private System.Windows.Forms.GroupBox ChaptersGroupBox;
        private System.Windows.Forms.GroupBox AdvancedEventGroupBox;
        private System.Windows.Forms.Button EditEventLogSelectButton;
        private System.Windows.Forms.Button EditEventLogButton;
        private System.Windows.Forms.Button EditEventButton;
        private System.Windows.Forms.Button EditScenarioButton;
        private System.Windows.Forms.ListView ChapterListListView;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.Label SocialQuestsLabel;
        private System.Windows.Forms.ListView PigNoiseListView;
        private System.Windows.Forms.Label PigNoiseLabel;
        private System.Windows.Forms.Label ChapterNameLabel;
        private System.Windows.Forms.ListView ConnectedSocialQuestsListView;
        private System.Windows.Forms.ColumnHeader PigNoiseIdHeader;
        private System.Windows.Forms.Label ComingSoonLabel;
        private System.Windows.Forms.ListView NagiDiveGoldRanksListView;
        private System.Windows.Forms.ColumnHeader DiveGoldRankIdHeader;
        private System.Windows.Forms.Label NagiDiveGoldRanksLabel;
        private System.Windows.Forms.ColumnHeader SocialTreeIdHeader;
        private System.Windows.Forms.PictureBox PigNoiseIcon_PictureBox;
        private System.Windows.Forms.ColumnHeader SocialTreeNameHeader;
        private System.Windows.Forms.PictureBox DiveGoldRanks_PictureBox;
        private System.Windows.Forms.PictureBox SocialQuests_PictureBox;
        private System.Windows.Forms.Button PigNoiseDefeatAll_Button;
    }
}