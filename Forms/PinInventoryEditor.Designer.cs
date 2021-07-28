
using System.Drawing;

namespace Scramble.Forms
{
    partial class PinInventoryEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EquippedDeckComboBox = new System.Windows.Forms.ComboBox();
            this.CharacterIconPictureBox = new System.Windows.Forms.PictureBox();
            this.EquippedByCharacterComboBox = new System.Windows.Forms.ComboBox();
            this.EquippedLabel = new System.Windows.Forms.Label();
            this.MaxLevelLabel_Value = new System.Windows.Forms.Label();
            this.MaxLevelLabel_Info = new System.Windows.Forms.Label();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.BrandPictureBox = new System.Windows.Forms.PictureBox();
            this.MasteredLabel = new System.Windows.Forms.Label();
            this.RemoveAllPinsButton = new System.Windows.Forms.Button();
            this.PinAmountUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.ExperienceNUpDown = new System.Windows.Forms.NumericUpDown();
            this.ExpLabel = new System.Windows.Forms.Label();
            this.PinLevelNUpDown = new System.Windows.Forms.NumericUpDown();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.PinNameLabel = new System.Windows.Forms.Label();
            this.RemovePinButton = new System.Windows.Forms.Button();
            this.MasterPinButton = new System.Windows.Forms.Button();
            this.PinImagePictureBox = new System.Windows.Forms.PictureBox();
            this.MyPinInventoryView = new System.Windows.Forms.ListView();
            this.PinNameHeader = new System.Windows.Forms.ColumnHeader();
            this.PinIdHeader = new System.Windows.Forms.ColumnHeader();
            this.PinLevelHeader = new System.Windows.Forms.ColumnHeader();
            this.PinExperienceHeader = new System.Windows.Forms.ColumnHeader();
            this.PinIsMasteredHeader = new System.Windows.Forms.ColumnHeader();
            this.AmountHeader = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Add99Checkbox = new System.Windows.Forms.CheckBox();
            this.AddedPinIsMasteredCheckbox = new System.Windows.Forms.CheckBox();
            this.AddAllPinsButton = new System.Windows.Forms.Button();
            this.AddPinButton = new System.Windows.Forms.Button();
            this.AllPinsListView = new System.Windows.Forms.ListView();
            this.GlobalPinNameHeader = new System.Windows.Forms.ColumnHeader();
            this.GlobalPinIdHeader = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAmountUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExperienceNUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinLevelNUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinImagePictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EquippedDeckComboBox);
            this.groupBox1.Controls.Add(this.CharacterIconPictureBox);
            this.groupBox1.Controls.Add(this.EquippedByCharacterComboBox);
            this.groupBox1.Controls.Add(this.EquippedLabel);
            this.groupBox1.Controls.Add(this.MaxLevelLabel_Value);
            this.groupBox1.Controls.Add(this.MaxLevelLabel_Info);
            this.groupBox1.Controls.Add(this.BrandLabel);
            this.groupBox1.Controls.Add(this.BrandPictureBox);
            this.groupBox1.Controls.Add(this.MasteredLabel);
            this.groupBox1.Controls.Add(this.RemoveAllPinsButton);
            this.groupBox1.Controls.Add(this.PinAmountUpDown);
            this.groupBox1.Controls.Add(this.AmountLabel);
            this.groupBox1.Controls.Add(this.ExperienceNUpDown);
            this.groupBox1.Controls.Add(this.ExpLabel);
            this.groupBox1.Controls.Add(this.PinLevelNUpDown);
            this.groupBox1.Controls.Add(this.LevelLabel);
            this.groupBox1.Controls.Add(this.PinNameLabel);
            this.groupBox1.Controls.Add(this.RemovePinButton);
            this.groupBox1.Controls.Add(this.MasterPinButton);
            this.groupBox1.Controls.Add(this.PinImagePictureBox);
            this.groupBox1.Controls.Add(this.MyPinInventoryView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 601);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pin Inventory";
            // 
            // EquippedDeckComboBox
            // 
            this.EquippedDeckComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquippedDeckComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EquippedDeckComboBox.FormattingEnabled = true;
            this.EquippedDeckComboBox.Location = new System.Drawing.Point(188, 567);
            this.EquippedDeckComboBox.Name = "EquippedDeckComboBox";
            this.EquippedDeckComboBox.Size = new System.Drawing.Size(82, 23);
            this.EquippedDeckComboBox.TabIndex = 22;
            this.EquippedDeckComboBox.TextChanged += new System.EventHandler(this.EquippedDeckComboBox_TextChanged);
            // 
            // CharacterIconPictureBox
            // 
            this.CharacterIconPictureBox.Location = new System.Drawing.Point(409, 561);
            this.CharacterIconPictureBox.Name = "CharacterIconPictureBox";
            this.CharacterIconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.CharacterIconPictureBox.TabIndex = 21;
            this.CharacterIconPictureBox.TabStop = false;
            // 
            // EquippedByCharacterComboBox
            // 
            this.EquippedByCharacterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquippedByCharacterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EquippedByCharacterComboBox.FormattingEnabled = true;
            this.EquippedByCharacterComboBox.Location = new System.Drawing.Point(276, 567);
            this.EquippedByCharacterComboBox.Name = "EquippedByCharacterComboBox";
            this.EquippedByCharacterComboBox.Size = new System.Drawing.Size(127, 23);
            this.EquippedByCharacterComboBox.TabIndex = 20;
            this.EquippedByCharacterComboBox.TextChanged += new System.EventHandler(this.EquippedByCharacterComboBox_TextChanged);
            // 
            // EquippedLabel
            // 
            this.EquippedLabel.AutoSize = true;
            this.EquippedLabel.Location = new System.Drawing.Point(122, 570);
            this.EquippedLabel.Name = "EquippedLabel";
            this.EquippedLabel.Size = new System.Drawing.Size(60, 15);
            this.EquippedLabel.TabIndex = 19;
            this.EquippedLabel.Text = "Equipado:";
            // 
            // MaxLevelLabel_Value
            // 
            this.MaxLevelLabel_Value.AutoSize = true;
            this.MaxLevelLabel_Value.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MaxLevelLabel_Value.ForeColor = System.Drawing.Color.MediumBlue;
            this.MaxLevelLabel_Value.Location = new System.Drawing.Point(321, 448);
            this.MaxLevelLabel_Value.Name = "MaxLevelLabel_Value";
            this.MaxLevelLabel_Value.Size = new System.Drawing.Size(0, 15);
            this.MaxLevelLabel_Value.TabIndex = 18;
            // 
            // MaxLevelLabel_Info
            // 
            this.MaxLevelLabel_Info.AutoSize = true;
            this.MaxLevelLabel_Info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaxLevelLabel_Info.Location = new System.Drawing.Point(246, 448);
            this.MaxLevelLabel_Info.Name = "MaxLevelLabel_Info";
            this.MaxLevelLabel_Info.Size = new System.Drawing.Size(66, 15);
            this.MaxLevelLabel_Info.TabIndex = 17;
            this.MaxLevelLabel_Info.Text = "Max level:  ";
            // 
            // BrandLabel
            // 
            this.BrandLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BrandLabel.Location = new System.Drawing.Point(394, 506);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(170, 15);
            this.BrandLabel.TabIndex = 16;
            this.BrandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandPictureBox
            // 
            this.BrandPictureBox.Location = new System.Drawing.Point(394, 443);
            this.BrandPictureBox.Name = "BrandPictureBox";
            this.BrandPictureBox.Size = new System.Drawing.Size(170, 60);
            this.BrandPictureBox.TabIndex = 15;
            this.BrandPictureBox.TabStop = false;
            // 
            // MasteredLabel
            // 
            this.MasteredLabel.AutoSize = true;
            this.MasteredLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MasteredLabel.Location = new System.Drawing.Point(336, 441);
            this.MasteredLabel.Name = "MasteredLabel";
            this.MasteredLabel.Size = new System.Drawing.Size(0, 27);
            this.MasteredLabel.TabIndex = 14;
            // 
            // RemoveAllPinsButton
            // 
            this.RemoveAllPinsButton.BackColor = System.Drawing.Color.Gainsboro;
            this.RemoveAllPinsButton.Location = new System.Drawing.Point(6, 567);
            this.RemoveAllPinsButton.Name = "RemoveAllPinsButton";
            this.RemoveAllPinsButton.Size = new System.Drawing.Size(107, 23);
            this.RemoveAllPinsButton.TabIndex = 7;
            this.RemoveAllPinsButton.Text = "Remove all";
            this.RemoveAllPinsButton.UseVisualStyleBackColor = false;
            this.RemoveAllPinsButton.Click += new System.EventHandler(this.RemoveAllPinsButton_Click);
            // 
            // PinAmountUpDown
            // 
            this.PinAmountUpDown.Enabled = false;
            this.PinAmountUpDown.Location = new System.Drawing.Point(188, 504);
            this.PinAmountUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PinAmountUpDown.Name = "PinAmountUpDown";
            this.PinAmountUpDown.Size = new System.Drawing.Size(52, 23);
            this.PinAmountUpDown.TabIndex = 5;
            this.PinAmountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PinAmountUpDown.ValueChanged += new System.EventHandler(this.PinAmountUpDown_ValueChanged);
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(122, 506);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(54, 15);
            this.AmountLabel.TabIndex = 12;
            this.AmountLabel.Text = "Amount:";
            // 
            // ExperienceNUpDown
            // 
            this.ExperienceNUpDown.Enabled = false;
            this.ExperienceNUpDown.Location = new System.Drawing.Point(188, 475);
            this.ExperienceNUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ExperienceNUpDown.Name = "ExperienceNUpDown";
            this.ExperienceNUpDown.Size = new System.Drawing.Size(52, 23);
            this.ExperienceNUpDown.TabIndex = 3;
            this.ExperienceNUpDown.ValueChanged += new System.EventHandler(this.ExperienceNUpDown_ValueChanged);
            // 
            // ExpLabel
            // 
            this.ExpLabel.AutoSize = true;
            this.ExpLabel.Location = new System.Drawing.Point(122, 477);
            this.ExpLabel.Name = "ExpLabel";
            this.ExpLabel.Size = new System.Drawing.Size(30, 15);
            this.ExpLabel.TabIndex = 10;
            this.ExpLabel.Text = "EXP:";
            // 
            // PinLevelNUpDown
            // 
            this.PinLevelNUpDown.Enabled = false;
            this.PinLevelNUpDown.Location = new System.Drawing.Point(188, 446);
            this.PinLevelNUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PinLevelNUpDown.Name = "PinLevelNUpDown";
            this.PinLevelNUpDown.Size = new System.Drawing.Size(52, 23);
            this.PinLevelNUpDown.TabIndex = 2;
            this.PinLevelNUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PinLevelNUpDown.ValueChanged += new System.EventHandler(this.PinLevelNUpDown_ValueChanged);
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(122, 448);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(37, 15);
            this.LevelLabel.TabIndex = 7;
            this.LevelLabel.Text = "Level:";
            // 
            // PinNameLabel
            // 
            this.PinNameLabel.AutoSize = true;
            this.PinNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PinNameLabel.Location = new System.Drawing.Point(122, 421);
            this.PinNameLabel.Name = "PinNameLabel";
            this.PinNameLabel.Size = new System.Drawing.Size(101, 15);
            this.PinNameLabel.TabIndex = 6;
            this.PinNameLabel.Text = "(No selected pin)";
            // 
            // RemovePinButton
            // 
            this.RemovePinButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RemovePinButton.Enabled = false;
            this.RemovePinButton.Location = new System.Drawing.Point(6, 540);
            this.RemovePinButton.Name = "RemovePinButton";
            this.RemovePinButton.Size = new System.Drawing.Size(107, 23);
            this.RemovePinButton.TabIndex = 6;
            this.RemovePinButton.Text = "Remove this pin";
            this.RemovePinButton.UseVisualStyleBackColor = false;
            this.RemovePinButton.Click += new System.EventHandler(this.RemovePinButton_Click);
            // 
            // MasterPinButton
            // 
            this.MasterPinButton.Enabled = false;
            this.MasterPinButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.MasterPinButton.Location = new System.Drawing.Point(246, 473);
            this.MasterPinButton.Name = "MasterPinButton";
            this.MasterPinButton.Size = new System.Drawing.Size(116, 23);
            this.MasterPinButton.TabIndex = 4;
            this.MasterPinButton.Text = "Master this pin";
            this.MasterPinButton.UseVisualStyleBackColor = true;
            this.MasterPinButton.Click += new System.EventHandler(this.MasterPinButton_Click);
            // 
            // PinImagePictureBox
            // 
            this.PinImagePictureBox.Location = new System.Drawing.Point(9, 424);
            this.PinImagePictureBox.Name = "PinImagePictureBox";
            this.PinImagePictureBox.Size = new System.Drawing.Size(100, 100);
            this.PinImagePictureBox.TabIndex = 3;
            this.PinImagePictureBox.TabStop = false;
            // 
            // MyPinInventoryView
            // 
            this.MyPinInventoryView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyPinInventoryView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PinNameHeader,
            this.PinIdHeader,
            this.PinLevelHeader,
            this.PinExperienceHeader,
            this.PinIsMasteredHeader,
            this.AmountHeader});
            this.MyPinInventoryView.FullRowSelect = true;
            this.MyPinInventoryView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MyPinInventoryView.HideSelection = false;
            this.MyPinInventoryView.Location = new System.Drawing.Point(6, 22);
            this.MyPinInventoryView.MultiSelect = false;
            this.MyPinInventoryView.Name = "MyPinInventoryView";
            this.MyPinInventoryView.Size = new System.Drawing.Size(558, 374);
            this.MyPinInventoryView.TabIndex = 1;
            this.MyPinInventoryView.UseCompatibleStateImageBehavior = false;
            this.MyPinInventoryView.View = System.Windows.Forms.View.Details;
            this.MyPinInventoryView.SelectedIndexChanged += new System.EventHandler(this.MyPinInventoryView_SelectedIndexChanged);
            this.MyPinInventoryView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyPinInventoryView_KeyDown);
            // 
            // PinNameHeader
            // 
            this.PinNameHeader.DisplayIndex = 1;
            this.PinNameHeader.Text = "Name";
            this.PinNameHeader.Width = 261;
            // 
            // PinIdHeader
            // 
            this.PinIdHeader.DisplayIndex = 0;
            this.PinIdHeader.Text = "ID";
            this.PinIdHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PinIdHeader.Width = 40;
            // 
            // PinLevelHeader
            // 
            this.PinLevelHeader.Text = "Level";
            this.PinLevelHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PinLevelHeader.Width = 50;
            // 
            // PinExperienceHeader
            // 
            this.PinExperienceHeader.Text = "EXP";
            this.PinExperienceHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PinExperienceHeader.Width = 50;
            // 
            // PinIsMasteredHeader
            // 
            this.PinIsMasteredHeader.Text = "Mastered";
            this.PinIsMasteredHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PinIsMasteredHeader.Width = 69;
            // 
            // AmountHeader
            // 
            this.AmountHeader.Text = "Amount";
            this.AmountHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AmountHeader.Width = 69;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Add99Checkbox);
            this.groupBox2.Controls.Add(this.AddedPinIsMasteredCheckbox);
            this.groupBox2.Controls.Add(this.AddAllPinsButton);
            this.groupBox2.Controls.Add(this.AddPinButton);
            this.groupBox2.Controls.Add(this.AllPinsListView);
            this.groupBox2.Location = new System.Drawing.Point(588, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 601);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Pins";
            // 
            // Add99Checkbox
            // 
            this.Add99Checkbox.AutoSize = true;
            this.Add99Checkbox.Location = new System.Drawing.Point(176, 547);
            this.Add99Checkbox.Name = "Add99Checkbox";
            this.Add99Checkbox.Size = new System.Drawing.Size(44, 19);
            this.Add99Checkbox.TabIndex = 11;
            this.Add99Checkbox.Text = "x99";
            this.Add99Checkbox.UseVisualStyleBackColor = true;
            // 
            // AddedPinIsMasteredCheckbox
            // 
            this.AddedPinIsMasteredCheckbox.AutoSize = true;
            this.AddedPinIsMasteredCheckbox.Location = new System.Drawing.Point(226, 547);
            this.AddedPinIsMasteredCheckbox.Name = "AddedPinIsMasteredCheckbox";
            this.AddedPinIsMasteredCheckbox.Size = new System.Drawing.Size(75, 19);
            this.AddedPinIsMasteredCheckbox.TabIndex = 12;
            this.AddedPinIsMasteredCheckbox.Text = "Mastered";
            this.AddedPinIsMasteredCheckbox.UseVisualStyleBackColor = true;
            // 
            // AddAllPinsButton
            // 
            this.AddAllPinsButton.BackColor = System.Drawing.Color.Azure;
            this.AddAllPinsButton.Location = new System.Drawing.Point(134, 567);
            this.AddAllPinsButton.Name = "AddAllPinsButton";
            this.AddAllPinsButton.Size = new System.Drawing.Size(167, 23);
            this.AddAllPinsButton.TabIndex = 13;
            this.AddAllPinsButton.Text = "Add each of every pin";
            this.AddAllPinsButton.UseVisualStyleBackColor = false;
            this.AddAllPinsButton.Click += new System.EventHandler(this.AddAllPinsButton_Click);
            // 
            // AddPinButton
            // 
            this.AddPinButton.Location = new System.Drawing.Point(6, 547);
            this.AddPinButton.Name = "AddPinButton";
            this.AddPinButton.Size = new System.Drawing.Size(122, 43);
            this.AddPinButton.TabIndex = 10;
            this.AddPinButton.Text = "Add pin";
            this.AddPinButton.UseVisualStyleBackColor = true;
            this.AddPinButton.Click += new System.EventHandler(this.AddPinButton_Click);
            // 
            // AllPinsListView
            // 
            this.AllPinsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GlobalPinNameHeader,
            this.GlobalPinIdHeader});
            this.AllPinsListView.HideSelection = false;
            this.AllPinsListView.Location = new System.Drawing.Point(6, 22);
            this.AllPinsListView.Name = "AllPinsListView";
            this.AllPinsListView.Size = new System.Drawing.Size(295, 519);
            this.AllPinsListView.TabIndex = 0;
            this.AllPinsListView.UseCompatibleStateImageBehavior = false;
            this.AllPinsListView.View = System.Windows.Forms.View.Details;
            // 
            // GlobalPinNameHeader
            // 
            this.GlobalPinNameHeader.DisplayIndex = 1;
            this.GlobalPinNameHeader.Text = "Name";
            this.GlobalPinNameHeader.Width = 228;
            // 
            // GlobalPinIdHeader
            // 
            this.GlobalPinIdHeader.DisplayIndex = 0;
            this.GlobalPinIdHeader.Text = "Pin ID";
            this.GlobalPinIdHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GlobalPinIdHeader.Width = 45;
            // 
            // PinInventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 624);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PinInventoryEditor";
            this.Text = "Pin Inventory Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PinInventoryEditor_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAmountUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExperienceNUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinLevelNUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinImagePictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView MyPinInventoryView;
        private System.Windows.Forms.ColumnHeader PinIdHeader;
        private System.Windows.Forms.ColumnHeader PinNameHeader;
        private System.Windows.Forms.ColumnHeader PinLevelHeader;
        private System.Windows.Forms.ColumnHeader PinExperienceHeader;
        private System.Windows.Forms.ColumnHeader PinIsMasteredHeader;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader AmountHeader;
        private System.Windows.Forms.PictureBox PinImagePictureBox;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label PinNameLabel;
        private System.Windows.Forms.Button RemovePinButton;
        private System.Windows.Forms.Button MasterPinButton;
        private System.Windows.Forms.NumericUpDown PinLevelNUpDown;
        private System.Windows.Forms.NumericUpDown ExperienceNUpDown;
        private System.Windows.Forms.Label ExpLabel;
        private System.Windows.Forms.NumericUpDown PinAmountUpDown;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Button AddPinButton;
        private System.Windows.Forms.ListView AllPinsListView;
        private System.Windows.Forms.ColumnHeader GlobalPinNameHeader;
        private System.Windows.Forms.ColumnHeader GlobalPinIdHeader;
        private System.Windows.Forms.Label MasteredLabel;
        private System.Windows.Forms.Button RemoveAllPinsButton;
        private System.Windows.Forms.Button AddAllPinsButton;
        private System.Windows.Forms.CheckBox AddedPinIsMasteredCheckbox;
        private System.Windows.Forms.PictureBox BrandPictureBox;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label MaxLevelLabel_Value;
        private System.Windows.Forms.Label MaxLevelLabel_Info;
        private System.Windows.Forms.CheckBox Add99Checkbox;
        private System.Windows.Forms.ComboBox EquippedDeckComboBox;
        private System.Windows.Forms.PictureBox CharacterIconPictureBox;
        private System.Windows.Forms.ComboBox EquippedByCharacterComboBox;
        private System.Windows.Forms.Label EquippedLabel;
    }
}