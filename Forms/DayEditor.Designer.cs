
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
            this.AdvancedEventGroupBox = new System.Windows.Forms.GroupBox();
            this.EditEventLogSelectButton = new System.Windows.Forms.Button();
            this.EditEventLogButton = new System.Windows.Forms.Button();
            this.EditEventButton = new System.Windows.Forms.Button();
            this.EditScenarioButton = new System.Windows.Forms.Button();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChapterListListView = new System.Windows.Forms.ListView();
            this.ReachedDays_GroupBox.SuspendLayout();
            this.ChaptersGroupBox.SuspendLayout();
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
            this.ChaptersGroupBox.Controls.Add(this.ChapterListListView);
            this.ChaptersGroupBox.Location = new System.Drawing.Point(10, 94);
            this.ChaptersGroupBox.Name = "ChaptersGroupBox";
            this.ChaptersGroupBox.Size = new System.Drawing.Size(602, 355);
            this.ChaptersGroupBox.TabIndex = 1;
            this.ChaptersGroupBox.TabStop = false;
            this.ChaptersGroupBox.Text = "{Chapters}";
            // 
            // AdvancedEventGroupBox
            // 
            this.AdvancedEventGroupBox.Controls.Add(this.EditEventLogSelectButton);
            this.AdvancedEventGroupBox.Controls.Add(this.EditEventLogButton);
            this.AdvancedEventGroupBox.Controls.Add(this.EditEventButton);
            this.AdvancedEventGroupBox.Controls.Add(this.EditScenarioButton);
            this.AdvancedEventGroupBox.Location = new System.Drawing.Point(368, 12);
            this.AdvancedEventGroupBox.Name = "AdvancedEventGroupBox";
            this.AdvancedEventGroupBox.Size = new System.Drawing.Size(244, 76);
            this.AdvancedEventGroupBox.TabIndex = 2;
            this.AdvancedEventGroupBox.TabStop = false;
            this.AdvancedEventGroupBox.Text = "{Advanced}";
            // 
            // EditEventLogSelectButton
            // 
            this.EditEventLogSelectButton.Location = new System.Drawing.Point(125, 47);
            this.EditEventLogSelectButton.Name = "EditEventLogSelectButton";
            this.EditEventLogSelectButton.Size = new System.Drawing.Size(113, 23);
            this.EditEventLogSelectButton.TabIndex = 3;
            this.EditEventLogSelectButton.Text = "EventLogSelect";
            this.EditEventLogSelectButton.UseVisualStyleBackColor = true;
            // 
            // EditEventLogButton
            // 
            this.EditEventLogButton.Location = new System.Drawing.Point(6, 47);
            this.EditEventLogButton.Name = "EditEventLogButton";
            this.EditEventLogButton.Size = new System.Drawing.Size(113, 23);
            this.EditEventLogButton.TabIndex = 2;
            this.EditEventLogButton.Text = "EventLog";
            this.EditEventLogButton.UseVisualStyleBackColor = true;
            // 
            // EditEventButton
            // 
            this.EditEventButton.Location = new System.Drawing.Point(125, 19);
            this.EditEventButton.Name = "EditEventButton";
            this.EditEventButton.Size = new System.Drawing.Size(113, 23);
            this.EditEventButton.TabIndex = 1;
            this.EditEventButton.Text = "Event";
            this.EditEventButton.UseVisualStyleBackColor = true;
            // 
            // EditScenarioButton
            // 
            this.EditScenarioButton.Location = new System.Drawing.Point(6, 19);
            this.EditScenarioButton.Name = "EditScenarioButton";
            this.EditScenarioButton.Size = new System.Drawing.Size(113, 23);
            this.EditScenarioButton.TabIndex = 0;
            this.EditScenarioButton.Text = "Scenario";
            this.EditScenarioButton.UseVisualStyleBackColor = true;
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "{Name}";
            this.NameHeader.Width = 325;
            // 
            // ChapterListListView
            // 
            this.ChapterListListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader});
            this.ChapterListListView.HideSelection = false;
            this.ChapterListListView.Location = new System.Drawing.Point(6, 22);
            this.ChapterListListView.MultiSelect = false;
            this.ChapterListListView.Name = "ChapterListListView";
            this.ChapterListListView.Size = new System.Drawing.Size(352, 327);
            this.ChapterListListView.TabIndex = 0;
            this.ChapterListListView.UseCompatibleStateImageBehavior = false;
            this.ChapterListListView.View = System.Windows.Forms.View.Details;
            // 
            // DayEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 461);
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
    }
}