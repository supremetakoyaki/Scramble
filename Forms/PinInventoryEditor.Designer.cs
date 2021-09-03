
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
            this.UberPin_PictureBox = new System.Windows.Forms.PictureBox();
            this.AttackElement_Label = new System.Windows.Forms.Label();
            this.AttackElementIcon_PictureBox = new System.Windows.Forms.PictureBox();
            this.PinInfo_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.PinInputKey_PictureBox = new System.Windows.Forms.PictureBox();
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
            this.PinNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PinIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PinLevelHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PinExperienceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PinIsMasteredHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AmountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttackElementHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Add99Checkbox = new System.Windows.Forms.CheckBox();
            this.AddAllPinsButton = new System.Windows.Forms.Button();
            this.AddPinButton = new System.Windows.Forms.Button();
            this.AllPinsListView = new System.Windows.Forms.ListView();
            this.GlobalPinNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GlobalPinIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddedPinIsMasteredCheckbox = new System.Windows.Forms.CheckBox();
            this.AddPinAboutToMaster_Checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UberPin_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackElementIcon_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinInputKey_PictureBox)).BeginInit();
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
            this.groupBox1.Controls.Add(this.UberPin_PictureBox);
            this.groupBox1.Controls.Add(this.AttackElement_Label);
            this.groupBox1.Controls.Add(this.AttackElementIcon_PictureBox);
            this.groupBox1.Controls.Add(this.PinInfo_RichTextBox);
            this.groupBox1.Controls.Add(this.PinInputKey_PictureBox);
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
            this.groupBox1.Size = new System.Drawing.Size(770, 657);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pin Inventory";
            // 
            // UberPin_PictureBox
            // 
            this.UberPin_PictureBox.Location = new System.Drawing.Point(81, 400);
            this.UberPin_PictureBox.Name = "UberPin_PictureBox";
            this.UberPin_PictureBox.Size = new System.Drawing.Size(32, 32);
            this.UberPin_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.UberPin_PictureBox.TabIndex = 27;
            this.UberPin_PictureBox.TabStop = false;
            // 
            // AttackElement_Label
            // 
            this.AttackElement_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.AttackElement_Label.Location = new System.Drawing.Point(36, 517);
            this.AttackElement_Label.Name = "AttackElement_Label";
            this.AttackElement_Label.Size = new System.Drawing.Size(77, 18);
            this.AttackElement_Label.TabIndex = 26;
            this.AttackElement_Label.Text = "{Element}";
            this.AttackElement_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AttackElementIcon_PictureBox
            // 
            this.AttackElementIcon_PictureBox.Location = new System.Drawing.Point(13, 517);
            this.AttackElementIcon_PictureBox.Name = "AttackElementIcon_PictureBox";
            this.AttackElementIcon_PictureBox.Size = new System.Drawing.Size(20, 20);
            this.AttackElementIcon_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.AttackElementIcon_PictureBox.TabIndex = 25;
            this.AttackElementIcon_PictureBox.TabStop = false;
            // 
            // PinInfo_RichTextBox
            // 
            this.PinInfo_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.PinInfo_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PinInfo_RichTextBox.Enabled = false;
            this.PinInfo_RichTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.PinInfo_RichTextBox.Location = new System.Drawing.Point(130, 428);
            this.PinInfo_RichTextBox.Name = "PinInfo_RichTextBox";
            this.PinInfo_RichTextBox.ReadOnly = true;
            this.PinInfo_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.PinInfo_RichTextBox.ShortcutsEnabled = false;
            this.PinInfo_RichTextBox.Size = new System.Drawing.Size(381, 109);
            this.PinInfo_RichTextBox.TabIndex = 24;
            this.PinInfo_RichTextBox.Text = "{PinInfo}";
            // 
            // PinInputKey_PictureBox
            // 
            this.PinInputKey_PictureBox.Location = new System.Drawing.Point(13, 400);
            this.PinInputKey_PictureBox.Name = "PinInputKey_PictureBox";
            this.PinInputKey_PictureBox.Size = new System.Drawing.Size(32, 32);
            this.PinInputKey_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PinInputKey_PictureBox.TabIndex = 23;
            this.PinInputKey_PictureBox.TabStop = false;
            // 
            // EquippedDeckComboBox
            // 
            this.EquippedDeckComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquippedDeckComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EquippedDeckComboBox.FormattingEnabled = true;
            this.EquippedDeckComboBox.Location = new System.Drawing.Point(350, 621);
            this.EquippedDeckComboBox.Name = "EquippedDeckComboBox";
            this.EquippedDeckComboBox.Size = new System.Drawing.Size(82, 21);
            this.EquippedDeckComboBox.TabIndex = 5;
            this.EquippedDeckComboBox.TextChanged += new System.EventHandler(this.EquippedDeckComboBox_TextChanged);
            // 
            // CharacterIconPictureBox
            // 
            this.CharacterIconPictureBox.Location = new System.Drawing.Point(571, 615);
            this.CharacterIconPictureBox.Name = "CharacterIconPictureBox";
            this.CharacterIconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.CharacterIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CharacterIconPictureBox.TabIndex = 21;
            this.CharacterIconPictureBox.TabStop = false;
            // 
            // EquippedByCharacterComboBox
            // 
            this.EquippedByCharacterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquippedByCharacterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EquippedByCharacterComboBox.FormattingEnabled = true;
            this.EquippedByCharacterComboBox.Location = new System.Drawing.Point(438, 621);
            this.EquippedByCharacterComboBox.Name = "EquippedByCharacterComboBox";
            this.EquippedByCharacterComboBox.Size = new System.Drawing.Size(127, 21);
            this.EquippedByCharacterComboBox.TabIndex = 6;
            this.EquippedByCharacterComboBox.TextChanged += new System.EventHandler(this.EquippedByCharacterComboBox_TextChanged);
            // 
            // EquippedLabel
            // 
            this.EquippedLabel.AutoSize = true;
            this.EquippedLabel.Location = new System.Drawing.Point(284, 624);
            this.EquippedLabel.Name = "EquippedLabel";
            this.EquippedLabel.Size = new System.Drawing.Size(60, 13);
            this.EquippedLabel.TabIndex = 19;
            this.EquippedLabel.Text = "{Equipped}";
            // 
            // MaxLevelLabel_Value
            // 
            this.MaxLevelLabel_Value.AutoSize = true;
            this.MaxLevelLabel_Value.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.MaxLevelLabel_Value.ForeColor = System.Drawing.Color.MediumBlue;
            this.MaxLevelLabel_Value.Location = new System.Drawing.Point(212, 566);
            this.MaxLevelLabel_Value.Name = "MaxLevelLabel_Value";
            this.MaxLevelLabel_Value.Size = new System.Drawing.Size(0, 15);
            this.MaxLevelLabel_Value.TabIndex = 18;
            // 
            // MaxLevelLabel_Info
            // 
            this.MaxLevelLabel_Info.AutoSize = true;
            this.MaxLevelLabel_Info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaxLevelLabel_Info.Location = new System.Drawing.Point(137, 566);
            this.MaxLevelLabel_Info.Name = "MaxLevelLabel_Info";
            this.MaxLevelLabel_Info.Size = new System.Drawing.Size(61, 13);
            this.MaxLevelLabel_Info.TabIndex = 17;
            this.MaxLevelLabel_Info.Text = "Max level:  ";
            // 
            // BrandLabel
            // 
            this.BrandLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BrandLabel.Location = new System.Drawing.Point(584, 463);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(170, 15);
            this.BrandLabel.TabIndex = 16;
            this.BrandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandPictureBox
            // 
            this.BrandPictureBox.Location = new System.Drawing.Point(584, 400);
            this.BrandPictureBox.Name = "BrandPictureBox";
            this.BrandPictureBox.Size = new System.Drawing.Size(170, 60);
            this.BrandPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BrandPictureBox.TabIndex = 15;
            this.BrandPictureBox.TabStop = false;
            // 
            // MasteredLabel
            // 
            this.MasteredLabel.AutoSize = true;
            this.MasteredLabel.Font = new System.Drawing.Font("Arial", 18F);
            this.MasteredLabel.Location = new System.Drawing.Point(227, 559);
            this.MasteredLabel.Name = "MasteredLabel";
            this.MasteredLabel.Size = new System.Drawing.Size(0, 27);
            this.MasteredLabel.TabIndex = 14;
            // 
            // RemoveAllPinsButton
            // 
            this.RemoveAllPinsButton.BackColor = System.Drawing.Color.Gainsboro;
            this.RemoveAllPinsButton.Location = new System.Drawing.Point(647, 621);
            this.RemoveAllPinsButton.Name = "RemoveAllPinsButton";
            this.RemoveAllPinsButton.Size = new System.Drawing.Size(107, 30);
            this.RemoveAllPinsButton.TabIndex = 8;
            this.RemoveAllPinsButton.Text = "Remove all";
            this.RemoveAllPinsButton.UseVisualStyleBackColor = false;
            this.RemoveAllPinsButton.Click += new System.EventHandler(this.RemoveAllPinsButton_Click);
            // 
            // PinAmountUpDown
            // 
            this.PinAmountUpDown.Enabled = false;
            this.PinAmountUpDown.Location = new System.Drawing.Point(79, 622);
            this.PinAmountUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PinAmountUpDown.Name = "PinAmountUpDown";
            this.PinAmountUpDown.Size = new System.Drawing.Size(52, 20);
            this.PinAmountUpDown.TabIndex = 4;
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
            this.AmountLabel.Location = new System.Drawing.Point(13, 624);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(46, 13);
            this.AmountLabel.TabIndex = 12;
            this.AmountLabel.Text = "Amount:";
            // 
            // ExperienceNUpDown
            // 
            this.ExperienceNUpDown.Enabled = false;
            this.ExperienceNUpDown.Location = new System.Drawing.Point(79, 593);
            this.ExperienceNUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.ExperienceNUpDown.Name = "ExperienceNUpDown";
            this.ExperienceNUpDown.Size = new System.Drawing.Size(52, 20);
            this.ExperienceNUpDown.TabIndex = 2;
            this.ExperienceNUpDown.ValueChanged += new System.EventHandler(this.ExperienceNUpDown_ValueChanged);
            // 
            // ExpLabel
            // 
            this.ExpLabel.AutoSize = true;
            this.ExpLabel.Location = new System.Drawing.Point(13, 595);
            this.ExpLabel.Name = "ExpLabel";
            this.ExpLabel.Size = new System.Drawing.Size(31, 13);
            this.ExpLabel.TabIndex = 10;
            this.ExpLabel.Text = "EXP:";
            // 
            // PinLevelNUpDown
            // 
            this.PinLevelNUpDown.Enabled = false;
            this.PinLevelNUpDown.Location = new System.Drawing.Point(79, 564);
            this.PinLevelNUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PinLevelNUpDown.Name = "PinLevelNUpDown";
            this.PinLevelNUpDown.Size = new System.Drawing.Size(52, 20);
            this.PinLevelNUpDown.TabIndex = 1;
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
            this.LevelLabel.Location = new System.Drawing.Point(13, 566);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(36, 13);
            this.LevelLabel.TabIndex = 7;
            this.LevelLabel.Text = "Level:";
            // 
            // PinNameLabel
            // 
            this.PinNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.PinNameLabel.Location = new System.Drawing.Point(127, 400);
            this.PinNameLabel.Name = "PinNameLabel";
            this.PinNameLabel.Size = new System.Drawing.Size(384, 37);
            this.PinNameLabel.TabIndex = 6;
            this.PinNameLabel.Text = "{PinName}";
            // 
            // RemovePinButton
            // 
            this.RemovePinButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RemovePinButton.Enabled = false;
            this.RemovePinButton.Location = new System.Drawing.Point(647, 574);
            this.RemovePinButton.Name = "RemovePinButton";
            this.RemovePinButton.Size = new System.Drawing.Size(107, 41);
            this.RemovePinButton.TabIndex = 7;
            this.RemovePinButton.Text = "Remove this pin";
            this.RemovePinButton.UseVisualStyleBackColor = false;
            this.RemovePinButton.Click += new System.EventHandler(this.RemovePinButton_Click);
            // 
            // MasterPinButton
            // 
            this.MasterPinButton.Enabled = false;
            this.MasterPinButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.MasterPinButton.Location = new System.Drawing.Point(137, 591);
            this.MasterPinButton.Name = "MasterPinButton";
            this.MasterPinButton.Size = new System.Drawing.Size(116, 23);
            this.MasterPinButton.TabIndex = 3;
            this.MasterPinButton.Text = "Master this pin";
            this.MasterPinButton.UseVisualStyleBackColor = true;
            this.MasterPinButton.Click += new System.EventHandler(this.MasterPinButton_Click);
            // 
            // PinImagePictureBox
            // 
            this.PinImagePictureBox.Location = new System.Drawing.Point(13, 400);
            this.PinImagePictureBox.Name = "PinImagePictureBox";
            this.PinImagePictureBox.Size = new System.Drawing.Size(100, 100);
            this.PinImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
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
            this.AmountHeader,
            this.AttackElementHeader});
            this.MyPinInventoryView.FullRowSelect = true;
            this.MyPinInventoryView.HideSelection = false;
            this.MyPinInventoryView.Location = new System.Drawing.Point(13, 22);
            this.MyPinInventoryView.MultiSelect = false;
            this.MyPinInventoryView.Name = "MyPinInventoryView";
            this.MyPinInventoryView.Size = new System.Drawing.Size(741, 362);
            this.MyPinInventoryView.TabIndex = 0;
            this.MyPinInventoryView.UseCompatibleStateImageBehavior = false;
            this.MyPinInventoryView.View = System.Windows.Forms.View.Details;
            this.MyPinInventoryView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MyPinInventoryView_ColumnClick);
            this.MyPinInventoryView.SelectedIndexChanged += new System.EventHandler(this.MyPinInventoryView_SelectedIndexChanged);
            this.MyPinInventoryView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyPinInventoryView_KeyDown);
            // 
            // PinNameHeader
            // 
            this.PinNameHeader.DisplayIndex = 1;
            this.PinNameHeader.Text = "Name";
            this.PinNameHeader.Width = 285;
            // 
            // PinIdHeader
            // 
            this.PinIdHeader.DisplayIndex = 0;
            this.PinIdHeader.Text = "ID";
            this.PinIdHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PinLevelHeader
            // 
            this.PinLevelHeader.Text = "Level";
            this.PinLevelHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.PinIsMasteredHeader.Width = 75;
            // 
            // AmountHeader
            // 
            this.AmountHeader.DisplayIndex = 6;
            this.AmountHeader.Text = "Amount";
            this.AmountHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AmountHeader.Width = 75;
            // 
            // AttackElementHeader
            // 
            this.AttackElementHeader.DisplayIndex = 5;
            this.AttackElementHeader.Text = "Affinity";
            this.AttackElementHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AttackElementHeader.Width = 115;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddPinAboutToMaster_Checkbox);
            this.groupBox2.Controls.Add(this.Add99Checkbox);
            this.groupBox2.Controls.Add(this.AddedPinIsMasteredCheckbox);
            this.groupBox2.Controls.Add(this.AddAllPinsButton);
            this.groupBox2.Controls.Add(this.AddPinButton);
            this.groupBox2.Controls.Add(this.AllPinsListView);
            this.groupBox2.Location = new System.Drawing.Point(788, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 657);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Pins";
            // 
            // Add99Checkbox
            // 
            this.Add99Checkbox.AutoSize = true;
            this.Add99Checkbox.Location = new System.Drawing.Point(141, 598);
            this.Add99Checkbox.Name = "Add99Checkbox";
            this.Add99Checkbox.Size = new System.Drawing.Size(43, 17);
            this.Add99Checkbox.TabIndex = 10;
            this.Add99Checkbox.Text = "x99";
            this.Add99Checkbox.UseVisualStyleBackColor = true;
            // 
            // AddAllPinsButton
            // 
            this.AddAllPinsButton.BackColor = System.Drawing.Color.Azure;
            this.AddAllPinsButton.Location = new System.Drawing.Point(139, 621);
            this.AddAllPinsButton.Name = "AddAllPinsButton";
            this.AddAllPinsButton.Size = new System.Drawing.Size(231, 30);
            this.AddAllPinsButton.TabIndex = 13;
            this.AddAllPinsButton.Text = "Add one of every pin";
            this.AddAllPinsButton.UseVisualStyleBackColor = false;
            this.AddAllPinsButton.Click += new System.EventHandler(this.AddAllPinsButton_Click);
            // 
            // AddPinButton
            // 
            this.AddPinButton.Location = new System.Drawing.Point(14, 596);
            this.AddPinButton.Name = "AddPinButton";
            this.AddPinButton.Size = new System.Drawing.Size(119, 55);
            this.AddPinButton.TabIndex = 12;
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
            this.AllPinsListView.Location = new System.Drawing.Point(14, 22);
            this.AllPinsListView.Name = "AllPinsListView";
            this.AllPinsListView.Size = new System.Drawing.Size(356, 568);
            this.AllPinsListView.TabIndex = 9;
            this.AllPinsListView.UseCompatibleStateImageBehavior = false;
            this.AllPinsListView.View = System.Windows.Forms.View.Details;
            this.AllPinsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AllPinsListView_ColumnClick);
            // 
            // GlobalPinNameHeader
            // 
            this.GlobalPinNameHeader.DisplayIndex = 1;
            this.GlobalPinNameHeader.Text = "Name";
            this.GlobalPinNameHeader.Width = 230;
            // 
            // GlobalPinIdHeader
            // 
            this.GlobalPinIdHeader.DisplayIndex = 0;
            this.GlobalPinIdHeader.Text = "Pin ID";
            this.GlobalPinIdHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GlobalPinIdHeader.Width = 80;
            // 
            // AddedPinIsMasteredCheckbox
            // 
            this.AddedPinIsMasteredCheckbox.AutoSize = true;
            this.AddedPinIsMasteredCheckbox.Location = new System.Drawing.Point(190, 598);
            this.AddedPinIsMasteredCheckbox.Name = "AddedPinIsMasteredCheckbox";
            this.AddedPinIsMasteredCheckbox.Size = new System.Drawing.Size(70, 17);
            this.AddedPinIsMasteredCheckbox.TabIndex = 11;
            this.AddedPinIsMasteredCheckbox.Text = "Mastered";
            this.AddedPinIsMasteredCheckbox.UseVisualStyleBackColor = true;
            this.AddedPinIsMasteredCheckbox.CheckedChanged += new System.EventHandler(this.AddedPinIsMasteredCheckbox_CheckedChanged);
            // 
            // AddPinAboutToMaster_Checkbox
            // 
            this.AddPinAboutToMaster_Checkbox.AutoSize = true;
            this.AddPinAboutToMaster_Checkbox.Location = new System.Drawing.Point(270, 598);
            this.AddPinAboutToMaster_Checkbox.Name = "AddPinAboutToMaster_Checkbox";
            this.AddPinAboutToMaster_Checkbox.Size = new System.Drawing.Size(100, 17);
            this.AddPinAboutToMaster_Checkbox.TabIndex = 14;
            this.AddPinAboutToMaster_Checkbox.Text = "About to master";
            this.AddPinAboutToMaster_Checkbox.UseVisualStyleBackColor = true;
            this.AddPinAboutToMaster_Checkbox.CheckedChanged += new System.EventHandler(this.AddPinAboutToMaster_Checkbox_CheckedChanged);
            // 
            // PinInventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PinInventoryEditor";
            this.Text = "{PinEditor}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PinInventoryEditor_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UberPin_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackElementIcon_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinInputKey_PictureBox)).EndInit();
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
        private System.Windows.Forms.PictureBox BrandPictureBox;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label MaxLevelLabel_Value;
        private System.Windows.Forms.Label MaxLevelLabel_Info;
        private System.Windows.Forms.CheckBox Add99Checkbox;
        private System.Windows.Forms.ComboBox EquippedDeckComboBox;
        private System.Windows.Forms.PictureBox CharacterIconPictureBox;
        private System.Windows.Forms.ComboBox EquippedByCharacterComboBox;
        private System.Windows.Forms.Label EquippedLabel;
        private System.Windows.Forms.Label AttackElement_Label;
        private System.Windows.Forms.PictureBox AttackElementIcon_PictureBox;
        private System.Windows.Forms.RichTextBox PinInfo_RichTextBox;
        private System.Windows.Forms.PictureBox PinInputKey_PictureBox;
        private System.Windows.Forms.ColumnHeader AttackElementHeader;
        private System.Windows.Forms.PictureBox UberPin_PictureBox;
        private System.Windows.Forms.CheckBox AddPinAboutToMaster_Checkbox;
        private System.Windows.Forms.CheckBox AddedPinIsMasteredCheckbox;
    }
}