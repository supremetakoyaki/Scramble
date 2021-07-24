
namespace Scramble
{
    partial class ScrambleForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScrambleForm));
            this.OpenSaveFileButton = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.SaveSlotsGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveSlotsListBox = new System.Windows.Forms.ListBox();
            this.DateOfSavePicker = new System.Windows.Forms.DateTimePicker();
            this.DateSavedLabel = new System.Windows.Forms.Label();
            this.SaveChangesButton = new System.Windows.Forms.Button();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.MoneyNUpDown = new System.Windows.Forms.NumericUpDown();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.DifficultyCombo = new System.Windows.Forms.ComboBox();
            this.CurrentLevelLabel = new System.Windows.Forms.Label();
            this.CurrentLevelNUpDown = new System.Windows.Forms.NumericUpDown();
            this.FpLabel = new System.Windows.Forms.Label();
            this.FpNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BackupCheckbox = new System.Windows.Forms.CheckBox();
            this.InitializedSlotCheckbox = new System.Windows.Forms.CheckBox();
            this.ExperienceLabel = new System.Windows.Forms.Label();
            this.ExpNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LvLabel = new System.Windows.Forms.Label();
            this.OpenRecordEditButton = new System.Windows.Forms.Button();
            this.OpenSocialEditButton = new System.Windows.Forms.Button();
            this.OpenInvEditorButton = new System.Windows.Forms.Button();
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.DumpSlotDataButton = new System.Windows.Forms.Button();
            this.ImportSlotDataButton = new System.Windows.Forms.Button();
            this.OpenNoisepediaEditButton = new System.Windows.Forms.Button();
            this.OpenCharacterEditButton = new System.Windows.Forms.Button();
            this.OpenClothEditButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SaveSlotsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyNUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLevelNUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpNumericUpDown)).BeginInit();
            this.GeneralGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenSaveFileButton
            // 
            this.OpenSaveFileButton.Location = new System.Drawing.Point(168, 12);
            this.OpenSaveFileButton.Name = "OpenSaveFileButton";
            this.OpenSaveFileButton.Size = new System.Drawing.Size(119, 74);
            this.OpenSaveFileButton.TabIndex = 1;
            this.OpenSaveFileButton.Text = "Open Save File...";
            this.OpenSaveFileButton.UseVisualStyleBackColor = true;
            this.OpenSaveFileButton.Click += new System.EventHandler(this.OpenSaveFileButton_Click);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(139, 74);
            this.LogoPictureBox.TabIndex = 6;
            this.LogoPictureBox.TabStop = false;
            // 
            // SaveSlotsGroupBox
            // 
            this.SaveSlotsGroupBox.Controls.Add(this.SaveSlotsListBox);
            this.SaveSlotsGroupBox.Location = new System.Drawing.Point(12, 107);
            this.SaveSlotsGroupBox.Name = "SaveSlotsGroupBox";
            this.SaveSlotsGroupBox.Size = new System.Drawing.Size(139, 198);
            this.SaveSlotsGroupBox.TabIndex = 3;
            this.SaveSlotsGroupBox.TabStop = false;
            this.SaveSlotsGroupBox.Text = "Save Slots";
            // 
            // SaveSlotsListBox
            // 
            this.SaveSlotsListBox.FormattingEnabled = true;
            this.SaveSlotsListBox.ItemHeight = 15;
            this.SaveSlotsListBox.Items.AddRange(new object[] {
            "0 (Autosave)",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.SaveSlotsListBox.Location = new System.Drawing.Point(6, 22);
            this.SaveSlotsListBox.Name = "SaveSlotsListBox";
            this.SaveSlotsListBox.Size = new System.Drawing.Size(127, 169);
            this.SaveSlotsListBox.TabIndex = 4;
            this.SaveSlotsListBox.SelectedIndexChanged += new System.EventHandler(this.SaveSlotsListBox_SelectedIndexChanged);
            // 
            // DateOfSavePicker
            // 
            this.DateOfSavePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfSavePicker.Location = new System.Drawing.Point(6, 57);
            this.DateOfSavePicker.MaxDate = new System.DateTime(2037, 12, 31, 0, 0, 0, 0);
            this.DateOfSavePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DateOfSavePicker.Name = "DateOfSavePicker";
            this.DateOfSavePicker.Size = new System.Drawing.Size(184, 23);
            this.DateOfSavePicker.TabIndex = 6;
            this.DateOfSavePicker.ValueChanged += new System.EventHandler(this.DateOfSavePicker_ValueChanged);
            // 
            // DateSavedLabel
            // 
            this.DateSavedLabel.AutoSize = true;
            this.DateSavedLabel.Location = new System.Drawing.Point(6, 39);
            this.DateSavedLabel.Name = "DateSavedLabel";
            this.DateSavedLabel.Size = new System.Drawing.Size(124, 15);
            this.DateSavedLabel.TabIndex = 5;
            this.DateSavedLabel.Text = "Date and time of save:";
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.BackColor = System.Drawing.Color.PowderBlue;
            this.SaveChangesButton.Location = new System.Drawing.Point(292, 12);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new System.Drawing.Size(119, 74);
            this.SaveChangesButton.TabIndex = 2;
            this.SaveChangesButton.Text = "Save Changes";
            this.SaveChangesButton.UseVisualStyleBackColor = false;
            this.SaveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.AboutLabel.Location = new System.Drawing.Point(12, 321);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(96, 30);
            this.AboutLabel.TabIndex = 0;
            this.AboutLabel.Text = "Scramble ver.0.3 \nmade by T";
            this.AboutLabel.Click += new System.EventHandler(this.AboutLabel_Click);
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.Location = new System.Drawing.Point(6, 185);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(47, 15);
            this.MoneyLabel.TabIndex = 11;
            this.MoneyLabel.Text = "Money:";
            // 
            // MoneyNUpDown
            // 
            this.MoneyNUpDown.Location = new System.Drawing.Point(88, 183);
            this.MoneyNUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.MoneyNUpDown.Name = "MoneyNUpDown";
            this.MoneyNUpDown.Size = new System.Drawing.Size(102, 23);
            this.MoneyNUpDown.TabIndex = 12;
            this.MoneyNUpDown.ValueChanged += new System.EventHandler(this.MoneyNUpDown_ValueChanged);
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Location = new System.Drawing.Point(6, 94);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(58, 15);
            this.DifficultyLabel.TabIndex = 7;
            this.DifficultyLabel.Text = "Difficulty:";
            // 
            // DifficultyCombo
            // 
            this.DifficultyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DifficultyCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DifficultyCombo.FormattingEnabled = true;
            this.DifficultyCombo.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "Ultimate"});
            this.DifficultyCombo.Location = new System.Drawing.Point(88, 91);
            this.DifficultyCombo.MaxDropDownItems = 4;
            this.DifficultyCombo.Name = "DifficultyCombo";
            this.DifficultyCombo.Size = new System.Drawing.Size(102, 23);
            this.DifficultyCombo.TabIndex = 8;
            this.DifficultyCombo.SelectedIndexChanged += new System.EventHandler(this.DifficultyCombo_SelectedIndexChanged);
            // 
            // CurrentLevelLabel
            // 
            this.CurrentLevelLabel.AutoSize = true;
            this.CurrentLevelLabel.Location = new System.Drawing.Point(6, 156);
            this.CurrentLevelLabel.Name = "CurrentLevelLabel";
            this.CurrentLevelLabel.Size = new System.Drawing.Size(80, 15);
            this.CurrentLevelLabel.TabIndex = 9;
            this.CurrentLevelLabel.Text = "Current Level:";
            // 
            // CurrentLevelNUpDown
            // 
            this.CurrentLevelNUpDown.Location = new System.Drawing.Point(88, 154);
            this.CurrentLevelNUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CurrentLevelNUpDown.Name = "CurrentLevelNUpDown";
            this.CurrentLevelNUpDown.Size = new System.Drawing.Size(102, 23);
            this.CurrentLevelNUpDown.TabIndex = 10;
            this.CurrentLevelNUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CurrentLevelNUpDown.ValueChanged += new System.EventHandler(this.CurrentLevelNUpDown_ValueChanged);
            // 
            // FpLabel
            // 
            this.FpLabel.AutoSize = true;
            this.FpLabel.Location = new System.Drawing.Point(6, 214);
            this.FpLabel.Name = "FpLabel";
            this.FpLabel.Size = new System.Drawing.Size(23, 15);
            this.FpLabel.TabIndex = 13;
            this.FpLabel.Text = "FP:";
            // 
            // FpNumericUpDown
            // 
            this.FpNumericUpDown.Location = new System.Drawing.Point(88, 212);
            this.FpNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.FpNumericUpDown.Name = "FpNumericUpDown";
            this.FpNumericUpDown.Size = new System.Drawing.Size(102, 23);
            this.FpNumericUpDown.TabIndex = 14;
            this.FpNumericUpDown.ValueChanged += new System.EventHandler(this.FpNumericUpDown_ValueChanged);
            // 
            // BackupCheckbox
            // 
            this.BackupCheckbox.AutoSize = true;
            this.BackupCheckbox.Checked = true;
            this.BackupCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BackupCheckbox.Location = new System.Drawing.Point(417, 12);
            this.BackupCheckbox.Name = "BackupCheckbox";
            this.BackupCheckbox.Size = new System.Drawing.Size(111, 19);
            this.BackupCheckbox.TabIndex = 2;
            this.BackupCheckbox.Text = "Make a back-up";
            this.BackupCheckbox.UseVisualStyleBackColor = true;
            // 
            // InitializedSlotCheckbox
            // 
            this.InitializedSlotCheckbox.AutoSize = true;
            this.InitializedSlotCheckbox.Location = new System.Drawing.Point(6, 22);
            this.InitializedSlotCheckbox.Name = "InitializedSlotCheckbox";
            this.InitializedSlotCheckbox.Size = new System.Drawing.Size(98, 19);
            this.InitializedSlotCheckbox.TabIndex = 4;
            this.InitializedSlotCheckbox.Text = "Initialized slot";
            this.InitializedSlotCheckbox.UseVisualStyleBackColor = true;
            this.InitializedSlotCheckbox.CheckedChanged += new System.EventHandler(this.InitializedSlotCheckbox_CheckedChanged);
            // 
            // ExperienceLabel
            // 
            this.ExperienceLabel.AutoSize = true;
            this.ExperienceLabel.Location = new System.Drawing.Point(6, 127);
            this.ExperienceLabel.Name = "ExperienceLabel";
            this.ExperienceLabel.Size = new System.Drawing.Size(67, 15);
            this.ExperienceLabel.TabIndex = 15;
            this.ExperienceLabel.Text = "Experience:";
            // 
            // ExpNumericUpDown
            // 
            this.ExpNumericUpDown.Location = new System.Drawing.Point(88, 125);
            this.ExpNumericUpDown.Maximum = new decimal(new int[] {
            961500,
            0,
            0,
            0});
            this.ExpNumericUpDown.Name = "ExpNumericUpDown";
            this.ExpNumericUpDown.Size = new System.Drawing.Size(102, 23);
            this.ExpNumericUpDown.TabIndex = 16;
            this.ExpNumericUpDown.ValueChanged += new System.EventHandler(this.ExpNumericUpDown_ValueChanged);
            // 
            // LvLabel
            // 
            this.LvLabel.AutoSize = true;
            this.LvLabel.ForeColor = System.Drawing.Color.MediumBlue;
            this.LvLabel.Location = new System.Drawing.Point(196, 129);
            this.LvLabel.Name = "LvLabel";
            this.LvLabel.Size = new System.Drawing.Size(27, 15);
            this.LvLabel.TabIndex = 17;
            this.LvLabel.Text = "Lv.1";
            // 
            // OpenRecordEditButton
            // 
            this.OpenRecordEditButton.Location = new System.Drawing.Point(417, 333);
            this.OpenRecordEditButton.Name = "OpenRecordEditButton";
            this.OpenRecordEditButton.Size = new System.Drawing.Size(111, 23);
            this.OpenRecordEditButton.TabIndex = 18;
            this.OpenRecordEditButton.Text = "Collection Editor";
            this.OpenRecordEditButton.UseVisualStyleBackColor = true;
            this.OpenRecordEditButton.Click += new System.EventHandler(this.OpenRecordEditButton_Click);
            // 
            // OpenSocialEditButton
            // 
            this.OpenSocialEditButton.Enabled = false;
            this.OpenSocialEditButton.Location = new System.Drawing.Point(417, 145);
            this.OpenSocialEditButton.Name = "OpenSocialEditButton";
            this.OpenSocialEditButton.Size = new System.Drawing.Size(111, 23);
            this.OpenSocialEditButton.TabIndex = 19;
            this.OpenSocialEditButton.Text = "Social Editor";
            this.OpenSocialEditButton.UseVisualStyleBackColor = true;
            // 
            // OpenInvEditorButton
            // 
            this.OpenInvEditorButton.Enabled = false;
            this.OpenInvEditorButton.Location = new System.Drawing.Point(417, 174);
            this.OpenInvEditorButton.Name = "OpenInvEditorButton";
            this.OpenInvEditorButton.Size = new System.Drawing.Size(111, 23);
            this.OpenInvEditorButton.TabIndex = 20;
            this.OpenInvEditorButton.Text = "Pins Editor";
            this.OpenInvEditorButton.UseVisualStyleBackColor = true;
            this.OpenInvEditorButton.Click += new System.EventHandler(this.OpenInvEditorButton_Click);
            // 
            // GeneralGroupBox
            // 
            this.GeneralGroupBox.Controls.Add(this.InitializedSlotCheckbox);
            this.GeneralGroupBox.Controls.Add(this.DateOfSavePicker);
            this.GeneralGroupBox.Controls.Add(this.DateSavedLabel);
            this.GeneralGroupBox.Controls.Add(this.MoneyLabel);
            this.GeneralGroupBox.Controls.Add(this.LvLabel);
            this.GeneralGroupBox.Controls.Add(this.MoneyNUpDown);
            this.GeneralGroupBox.Controls.Add(this.ExpNumericUpDown);
            this.GeneralGroupBox.Controls.Add(this.DifficultyLabel);
            this.GeneralGroupBox.Controls.Add(this.ExperienceLabel);
            this.GeneralGroupBox.Controls.Add(this.DifficultyCombo);
            this.GeneralGroupBox.Controls.Add(this.CurrentLevelLabel);
            this.GeneralGroupBox.Controls.Add(this.CurrentLevelNUpDown);
            this.GeneralGroupBox.Controls.Add(this.FpNumericUpDown);
            this.GeneralGroupBox.Controls.Add(this.FpLabel);
            this.GeneralGroupBox.Location = new System.Drawing.Point(168, 107);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Size = new System.Drawing.Size(243, 249);
            this.GeneralGroupBox.TabIndex = 21;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "Global data";
            // 
            // DumpSlotDataButton
            // 
            this.DumpSlotDataButton.Location = new System.Drawing.Point(417, 34);
            this.DumpSlotDataButton.Name = "DumpSlotDataButton";
            this.DumpSlotDataButton.Size = new System.Drawing.Size(111, 23);
            this.DumpSlotDataButton.TabIndex = 22;
            this.DumpSlotDataButton.Text = "Dump Slot Data";
            this.DumpSlotDataButton.UseVisualStyleBackColor = true;
            this.DumpSlotDataButton.Click += new System.EventHandler(this.DumpSlotDebugButton_Click);
            // 
            // ImportSlotDataButton
            // 
            this.ImportSlotDataButton.Location = new System.Drawing.Point(417, 63);
            this.ImportSlotDataButton.Name = "ImportSlotDataButton";
            this.ImportSlotDataButton.Size = new System.Drawing.Size(111, 23);
            this.ImportSlotDataButton.TabIndex = 23;
            this.ImportSlotDataButton.Text = "Import Slot Data";
            this.ImportSlotDataButton.UseVisualStyleBackColor = true;
            this.ImportSlotDataButton.Click += new System.EventHandler(this.ImportSlotDataButton_Click);
            // 
            // OpenNoisepediaEditButton
            // 
            this.OpenNoisepediaEditButton.Enabled = false;
            this.OpenNoisepediaEditButton.Location = new System.Drawing.Point(417, 304);
            this.OpenNoisepediaEditButton.Name = "OpenNoisepediaEditButton";
            this.OpenNoisepediaEditButton.Size = new System.Drawing.Size(111, 23);
            this.OpenNoisepediaEditButton.TabIndex = 24;
            this.OpenNoisepediaEditButton.Text = "Noisepedia Editor";
            this.OpenNoisepediaEditButton.UseVisualStyleBackColor = true;
            // 
            // OpenCharacterEditButton
            // 
            this.OpenCharacterEditButton.Location = new System.Drawing.Point(417, 116);
            this.OpenCharacterEditButton.Name = "OpenCharacterEditButton";
            this.OpenCharacterEditButton.Size = new System.Drawing.Size(111, 23);
            this.OpenCharacterEditButton.TabIndex = 25;
            this.OpenCharacterEditButton.Text = "Character Editor";
            this.OpenCharacterEditButton.UseVisualStyleBackColor = true;
            // 
            // OpenClothEditButton
            // 
            this.OpenClothEditButton.Enabled = false;
            this.OpenClothEditButton.Location = new System.Drawing.Point(417, 203);
            this.OpenClothEditButton.Name = "OpenClothEditButton";
            this.OpenClothEditButton.Size = new System.Drawing.Size(111, 23);
            this.OpenClothEditButton.TabIndex = 26;
            this.OpenClothEditButton.Text = "Clothing Editor";
            this.OpenClothEditButton.UseVisualStyleBackColor = true;
            // 
            // ScrambleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 370);
            this.Controls.Add(this.OpenClothEditButton);
            this.Controls.Add(this.OpenCharacterEditButton);
            this.Controls.Add(this.OpenNoisepediaEditButton);
            this.Controls.Add(this.ImportSlotDataButton);
            this.Controls.Add(this.DumpSlotDataButton);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.OpenInvEditorButton);
            this.Controls.Add(this.OpenSocialEditButton);
            this.Controls.Add(this.OpenRecordEditButton);
            this.Controls.Add(this.BackupCheckbox);
            this.Controls.Add(this.AboutLabel);
            this.Controls.Add(this.SaveChangesButton);
            this.Controls.Add(this.SaveSlotsGroupBox);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.OpenSaveFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ScrambleForm";
            this.Text = "Scramble — NEO TWEWY Save Editor";
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.SaveSlotsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MoneyNUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLevelNUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpNumericUpDown)).EndInit();
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OpenSaveFileButton;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.GroupBox SaveSlotsGroupBox;
        private System.Windows.Forms.ListBox SaveSlotsListBox;
        private System.Windows.Forms.DateTimePicker DateOfSavePicker;
        private System.Windows.Forms.Label DateSavedLabel;
        private System.Windows.Forms.Button SaveChangesButton;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.Label MoneyLabel;
        private System.Windows.Forms.NumericUpDown MoneyNUpDown;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.ComboBox DifficultyCombo;
        private System.Windows.Forms.Label CurrentLevelLabel;
        private System.Windows.Forms.NumericUpDown CurrentLevelNUpDown;
        private System.Windows.Forms.Label FpLabel;
        private System.Windows.Forms.NumericUpDown FpNumericUpDown;
        private System.Windows.Forms.CheckBox BackupCheckbox;
        private System.Windows.Forms.CheckBox InitializedSlotCheckbox;
        private System.Windows.Forms.Label ExperienceLabel;
        private System.Windows.Forms.NumericUpDown ExpNumericUpDown;
        private System.Windows.Forms.Label LvLabel;
        private System.Windows.Forms.Button OpenRecordEditButton;
        private System.Windows.Forms.Button OpenSocialEditButton;
        private System.Windows.Forms.Button OpenInvEditorButton;
        private System.Windows.Forms.GroupBox GeneralGroupBox;
        private System.Windows.Forms.Button DumpSlotDataButton;
        private System.Windows.Forms.Button ImportSlotDataButton;
        private System.Windows.Forms.Button OpenNoisepediaEditButton;
        private System.Windows.Forms.Button OpenCharacterEditButton;
        private System.Windows.Forms.Button OpenClothEditButton;
    }
}

