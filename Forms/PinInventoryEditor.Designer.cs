
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PinInventoryEditor));
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
            this.PinImageList_Small = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Add99Checkbox = new System.Windows.Forms.CheckBox();
            this.AddedPinIsMasteredCheckbox = new System.Windows.Forms.CheckBox();
            this.AddAllPinsButton = new System.Windows.Forms.Button();
            this.AddPinButton = new System.Windows.Forms.Button();
            this.AllPinsListView = new System.Windows.Forms.ListView();
            this.GlobalPinNameHeader = new System.Windows.Forms.ColumnHeader();
            this.GlobalPinIdHeader = new System.Windows.Forms.ColumnHeader();
            this.PinImageList_Big = new System.Windows.Forms.ImageList(this.components);
            this.BrandImageList = new System.Windows.Forms.ImageList(this.components);
            this.CharacterIconImageList = new System.Windows.Forms.ImageList(this.components);
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
            this.EquippedDeckComboBox.Items.AddRange(new object[] {
            "(none)",
            "Deck 1",
            "Deck 2",
            "Deck 3"});
            this.EquippedDeckComboBox.Location = new System.Drawing.Point(188, 567);
            this.EquippedDeckComboBox.Name = "EquippedDeckComboBox";
            this.EquippedDeckComboBox.Size = new System.Drawing.Size(67, 23);
            this.EquippedDeckComboBox.TabIndex = 22;
            this.EquippedDeckComboBox.TextChanged += new System.EventHandler(this.EquippedDeckComboBox_TextChanged);
            // 
            // CharacterIconPictureBox
            // 
            this.CharacterIconPictureBox.Location = new System.Drawing.Point(394, 561);
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
            this.EquippedByCharacterComboBox.Items.AddRange(new object[] {
            "(no one)"});
            this.EquippedByCharacterComboBox.Location = new System.Drawing.Point(261, 567);
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
            this.EquippedLabel.Text = "Equipped:";
            // 
            // MaxLevelLabel_Value
            // 
            this.MaxLevelLabel_Value.AutoSize = true;
            this.MaxLevelLabel_Value.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MaxLevelLabel_Value.ForeColor = System.Drawing.Color.MediumBlue;
            this.MaxLevelLabel_Value.Location = new System.Drawing.Point(303, 448);
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
            this.MasteredLabel.Location = new System.Drawing.Point(318, 441);
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
            this.MasterPinButton.Location = new System.Drawing.Point(246, 475);
            this.MasterPinButton.Name = "MasterPinButton";
            this.MasterPinButton.Size = new System.Drawing.Size(97, 23);
            this.MasterPinButton.TabIndex = 4;
            this.MasterPinButton.Text = "Master this pin";
            this.MasterPinButton.UseVisualStyleBackColor = true;
            this.MasterPinButton.Click += new System.EventHandler(this.MasterPinButton_Click);
            // 
            // PinImagePictureBox
            // 
            this.PinImagePictureBox.Location = new System.Drawing.Point(28, 442);
            this.PinImagePictureBox.Name = "PinImagePictureBox";
            this.PinImagePictureBox.Size = new System.Drawing.Size(64, 64);
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
            this.MyPinInventoryView.HideSelection = false;
            this.MyPinInventoryView.Location = new System.Drawing.Point(6, 22);
            this.MyPinInventoryView.MultiSelect = false;
            this.MyPinInventoryView.Name = "MyPinInventoryView";
            this.MyPinInventoryView.Size = new System.Drawing.Size(558, 374);
            this.MyPinInventoryView.SmallImageList = this.PinImageList_Small;
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
            this.PinNameHeader.Width = 265;
            // 
            // PinIdHeader
            // 
            this.PinIdHeader.DisplayIndex = 0;
            this.PinIdHeader.Text = "Pin ID";
            this.PinIdHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PinIdHeader.Width = 45;
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
            this.PinIsMasteredHeader.Width = 67;
            // 
            // AmountHeader
            // 
            this.AmountHeader.Text = "Amount";
            this.AmountHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AmountHeader.Width = 67;
            // 
            // PinImageList_Small
            // 
            this.PinImageList_Small.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.PinImageList_Small.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PinImageList_Small.ImageStream")));
            this.PinImageList_Small.TransparentColor = System.Drawing.Color.Transparent;
            this.PinImageList_Small.Images.SetKeyName(0, "bad_99_00_00.png");
            this.PinImageList_Small.Images.SetKeyName(1, "bad_99_00_01.png");
            this.PinImageList_Small.Images.SetKeyName(2, "bad_99_00_02.png");
            this.PinImageList_Small.Images.SetKeyName(3, "bad_99_00_03.png");
            this.PinImageList_Small.Images.SetKeyName(4, "bad_99_00_04.png");
            this.PinImageList_Small.Images.SetKeyName(5, "bad_99_00_05.png");
            this.PinImageList_Small.Images.SetKeyName(6, "bad_99_00_06.png");
            this.PinImageList_Small.Images.SetKeyName(7, "bad_99_00_07.png");
            this.PinImageList_Small.Images.SetKeyName(8, "bad_99_00_08.png");
            this.PinImageList_Small.Images.SetKeyName(9, "bad_99_00_09.png");
            this.PinImageList_Small.Images.SetKeyName(10, "ID001_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(11, "ID002_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(12, "ID003_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(13, "ID004_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(14, "ID005_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(15, "ID006_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(16, "ID007_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(17, "ID008_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(18, "ID009_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(19, "ID010_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(20, "ID011_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(21, "ID012_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(22, "ID013_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(23, "ID014_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(24, "ID015_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(25, "ID016_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(26, "ID017_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(27, "ID018_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(28, "ID019_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(29, "ID020_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(30, "ID021_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(31, "ID022_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(32, "ID023_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(33, "ID024_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(34, "ID025_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(35, "ID026_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(36, "ID027_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(37, "ID028_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(38, "ID029_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(39, "ID030_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(40, "ID031_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(41, "ID032_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(42, "ID033_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(43, "ID034_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(44, "ID035_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(45, "ID036_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(46, "ID037_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(47, "ID038_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(48, "ID039_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(49, "ID040_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(50, "ID041_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(51, "ID042_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(52, "ID043_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(53, "ID044_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(54, "ID045_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(55, "ID046_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(56, "ID047_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(57, "ID048_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(58, "ID049_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(59, "ID050_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(60, "ID051_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(61, "ID052_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(62, "ID053_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(63, "ID054_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(64, "ID055_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(65, "ID056_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(66, "ID057_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(67, "ID058_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(68, "ID059_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(69, "ID060_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(70, "ID061_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(71, "ID062_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(72, "ID063_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(73, "ID064_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(74, "ID065_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(75, "ID066_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(76, "ID067_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(77, "ID068_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(78, "ID069_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(79, "ID070_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(80, "ID071_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(81, "ID072_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(82, "ID073_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(83, "ID074_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(84, "ID075_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(85, "ID076_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(86, "ID077_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(87, "ID078_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(88, "ID079_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(89, "ID080_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(90, "ID081_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(91, "ID082_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(92, "ID083_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(93, "ID084_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(94, "ID085_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(95, "ID086_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(96, "ID087_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(97, "ID088_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(98, "ID089_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(99, "ID090_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(100, "ID091_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(101, "ID092_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(102, "ID093_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(103, "ID094_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(104, "ID095_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(105, "ID096_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(106, "ID097_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(107, "ID098_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(108, "ID099_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(109, "ID100_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(110, "ID101_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(111, "ID102_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(112, "ID103_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(113, "ID104_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(114, "ID105_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(115, "ID106_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(116, "ID107_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(117, "ID108_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(118, "ID109_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(119, "ID110_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(120, "ID111_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(121, "ID112_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(122, "ID113_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(123, "ID114_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(124, "ID115_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(125, "ID116_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(126, "ID117_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(127, "ID118_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(128, "ID119_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(129, "ID120_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(130, "ID121_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(131, "ID122_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(132, "ID123_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(133, "ID124_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(134, "ID125_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(135, "ID126_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(136, "ID127_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(137, "ID128_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(138, "ID129_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(139, "ID130_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(140, "ID131_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(141, "ID132_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(142, "ID133_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(143, "ID134_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(144, "ID135_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(145, "ID136_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(146, "ID137_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(147, "ID138_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(148, "ID139_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(149, "ID140_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(150, "ID141_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(151, "ID142_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(152, "ID143_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(153, "ID144_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(154, "ID145_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(155, "ID146_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(156, "ID147_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(157, "ID148_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(158, "ID149_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(159, "ID150_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(160, "ID151_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(161, "ID152_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(162, "ID153_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(163, "ID154_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(164, "ID155_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(165, "ID156_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(166, "ID157_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(167, "ID158_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(168, "ID159_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(169, "ID160_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(170, "ID161_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(171, "ID162_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(172, "ID163_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(173, "ID164_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(174, "ID165_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(175, "ID166_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(176, "ID167_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(177, "ID168_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(178, "ID169_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(179, "ID170_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(180, "ID171_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(181, "ID172_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(182, "ID173_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(183, "ID174_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(184, "ID175_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(185, "ID176_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(186, "ID177_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(187, "ID178_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(188, "ID179_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(189, "ID180_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(190, "ID181_ConyCony.png");
            this.PinImageList_Small.Images.SetKeyName(191, "ID182_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(192, "ID183_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(193, "ID184_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(194, "ID185_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(195, "ID186_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(196, "ID187_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(197, "ID188_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(198, "ID189_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(199, "ID190_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(200, "ID191_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(201, "ID192_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(202, "ID193_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(203, "ID194_ILCAVALLODELRE.png");
            this.PinImageList_Small.Images.SetKeyName(204, "ID195_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(205, "ID196_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(206, "ID197_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(207, "ID198_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(208, "ID199_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(209, "ID200_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(210, "ID201_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(211, "ID202_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(212, "ID203_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(213, "ID204_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(214, "ID205_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(215, "ID206_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(216, "ID207_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(217, "ID208_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(218, "ID209_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(219, "ID210_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(220, "ID211_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(221, "ID212_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(222, "ID213_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(223, "ID214_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(224, "ID215_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(225, "ID216_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(226, "ID217_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(227, "ID218_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(228, "ID219_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(229, "ID220_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(230, "ID221_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(231, "ID222_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(232, "ID223_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(233, "ID224_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(234, "ID225_TopoTopo.png");
            this.PinImageList_Small.Images.SetKeyName(235, "ID226_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(236, "ID227_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(237, "ID228_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(238, "ID229_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(239, "ID230_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(240, "ID231_NATURALPUPPY.png");
            this.PinImageList_Small.Images.SetKeyName(241, "ID232_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(242, "ID233_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(243, "ID234_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(244, "ID235_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(245, "ID236_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(246, "ID237_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(247, "ID238_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(248, "ID239_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(249, "ID240_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(250, "ID241_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(251, "ID242_RyuGu.png");
            this.PinImageList_Small.Images.SetKeyName(252, "ID243_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(253, "ID244_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(254, "ID245_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(255, "ID246_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(256, "ID247_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(257, "ID248_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(258, "ID249_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(259, "ID250_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(260, "ID251_croakypanic.png");
            this.PinImageList_Small.Images.SetKeyName(261, "ID252_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(262, "ID253_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(263, "ID254_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(264, "ID255_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(265, "ID256_ShepherdHouse.png");
            this.PinImageList_Small.Images.SetKeyName(266, "ID257_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(267, "ID258_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(268, "ID259_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(269, "ID260_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(270, "ID261_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(271, "ID262_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(272, "ID263_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(273, "ID264_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(274, "ID265_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(275, "ID266_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(276, "ID267_garagara.png");
            this.PinImageList_Small.Images.SetKeyName(277, "ID268_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(278, "ID269_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(279, "ID270_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(280, "ID271_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(281, "ID272_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(282, "ID273_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(283, "ID274_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(284, "ID275_HogFang.png");
            this.PinImageList_Small.Images.SetKeyName(285, "ID276_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(286, "ID277_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(287, "ID278_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(288, "ID279_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(289, "ID280_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(290, "ID281_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(291, "ID282_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(292, "ID283_TigrePUNKS.png");
            this.PinImageList_Small.Images.SetKeyName(293, "ID284_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(294, "ID285_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(295, "ID286_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(296, "ID287_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(297, "ID288_MONOCROW.png");
            this.PinImageList_Small.Images.SetKeyName(298, "ID289_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(299, "ID290_Jolibecot.png");
            this.PinImageList_Small.Images.SetKeyName(300, "ID291_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(301, "ID292_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(302, "ID293_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(303, "ID294_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(304, "ID295_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(305, "ID296_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(306, "ID297_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(307, "ID298_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(308, "ID299_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(309, "ID300_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(310, "ID301_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(311, "ID302_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(312, "ID303_GattoNero.png");
            this.PinImageList_Small.Images.SetKeyName(313, "ID304_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(314, "ID305_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(315, "ID306_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(316, "ID307_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(317, "ID308_JupiterOfTheMonkey.png");
            this.PinImageList_Small.Images.SetKeyName(318, "ID309_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(319, "ID310_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(320, "ID311_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(321, "ID312_NoBrand.png");
            this.PinImageList_Small.Images.SetKeyName(322, "ID323_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(323, "ID324_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(324, "ID325_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(325, "ID326_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(326, "ID327_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(327, "ID328_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(328, "ID329_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(329, "ID330_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(330, "ID331_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(331, "ID332_sozai.png");
            this.PinImageList_Small.Images.SetKeyName(332, "ID333_sozai.png");
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
            this.Add99Checkbox.Location = new System.Drawing.Point(171, 547);
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
            this.AddAllPinsButton.Location = new System.Drawing.Point(171, 567);
            this.AddAllPinsButton.Name = "AddAllPinsButton";
            this.AddAllPinsButton.Size = new System.Drawing.Size(130, 23);
            this.AddAllPinsButton.TabIndex = 13;
            this.AddAllPinsButton.Text = "Add each of every pin";
            this.AddAllPinsButton.UseVisualStyleBackColor = false;
            this.AddAllPinsButton.Click += new System.EventHandler(this.AddAllPinsButton_Click);
            // 
            // AddPinButton
            // 
            this.AddPinButton.Location = new System.Drawing.Point(6, 547);
            this.AddPinButton.Name = "AddPinButton";
            this.AddPinButton.Size = new System.Drawing.Size(100, 43);
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
            this.AllPinsListView.SmallImageList = this.PinImageList_Big;
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
            // PinImageList_Big
            // 
            this.PinImageList_Big.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.PinImageList_Big.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PinImageList_Big.ImageStream")));
            this.PinImageList_Big.TransparentColor = System.Drawing.Color.Transparent;
            this.PinImageList_Big.Images.SetKeyName(0, "bad_99_00_00.png");
            this.PinImageList_Big.Images.SetKeyName(1, "bad_99_00_01.png");
            this.PinImageList_Big.Images.SetKeyName(2, "bad_99_00_02.png");
            this.PinImageList_Big.Images.SetKeyName(3, "bad_99_00_03.png");
            this.PinImageList_Big.Images.SetKeyName(4, "bad_99_00_04.png");
            this.PinImageList_Big.Images.SetKeyName(5, "bad_99_00_05.png");
            this.PinImageList_Big.Images.SetKeyName(6, "bad_99_00_06.png");
            this.PinImageList_Big.Images.SetKeyName(7, "bad_99_00_07.png");
            this.PinImageList_Big.Images.SetKeyName(8, "bad_99_00_08.png");
            this.PinImageList_Big.Images.SetKeyName(9, "bad_99_00_09.png");
            this.PinImageList_Big.Images.SetKeyName(10, "ID001_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(11, "ID002_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(12, "ID003_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(13, "ID004_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(14, "ID005_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(15, "ID006_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(16, "ID007_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(17, "ID008_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(18, "ID009_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(19, "ID010_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(20, "ID011_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(21, "ID012_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(22, "ID013_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(23, "ID014_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(24, "ID015_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(25, "ID016_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(26, "ID017_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(27, "ID018_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(28, "ID019_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(29, "ID020_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(30, "ID021_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(31, "ID022_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(32, "ID023_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(33, "ID024_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(34, "ID025_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(35, "ID026_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(36, "ID027_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(37, "ID028_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(38, "ID029_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(39, "ID030_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(40, "ID031_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(41, "ID032_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(42, "ID033_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(43, "ID034_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(44, "ID035_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(45, "ID036_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(46, "ID037_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(47, "ID038_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(48, "ID039_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(49, "ID040_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(50, "ID041_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(51, "ID042_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(52, "ID043_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(53, "ID044_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(54, "ID045_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(55, "ID046_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(56, "ID047_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(57, "ID048_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(58, "ID049_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(59, "ID050_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(60, "ID051_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(61, "ID052_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(62, "ID053_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(63, "ID054_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(64, "ID055_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(65, "ID056_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(66, "ID057_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(67, "ID058_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(68, "ID059_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(69, "ID060_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(70, "ID061_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(71, "ID062_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(72, "ID063_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(73, "ID064_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(74, "ID065_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(75, "ID066_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(76, "ID067_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(77, "ID068_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(78, "ID069_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(79, "ID070_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(80, "ID071_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(81, "ID072_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(82, "ID073_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(83, "ID074_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(84, "ID075_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(85, "ID076_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(86, "ID077_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(87, "ID078_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(88, "ID079_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(89, "ID080_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(90, "ID081_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(91, "ID082_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(92, "ID083_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(93, "ID084_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(94, "ID085_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(95, "ID086_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(96, "ID087_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(97, "ID088_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(98, "ID089_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(99, "ID090_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(100, "ID091_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(101, "ID092_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(102, "ID093_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(103, "ID094_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(104, "ID095_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(105, "ID096_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(106, "ID097_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(107, "ID098_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(108, "ID099_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(109, "ID100_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(110, "ID101_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(111, "ID102_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(112, "ID103_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(113, "ID104_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(114, "ID105_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(115, "ID106_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(116, "ID107_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(117, "ID108_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(118, "ID109_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(119, "ID110_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(120, "ID111_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(121, "ID112_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(122, "ID113_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(123, "ID114_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(124, "ID115_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(125, "ID116_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(126, "ID117_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(127, "ID118_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(128, "ID119_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(129, "ID120_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(130, "ID121_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(131, "ID122_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(132, "ID123_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(133, "ID124_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(134, "ID125_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(135, "ID126_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(136, "ID127_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(137, "ID128_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(138, "ID129_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(139, "ID130_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(140, "ID131_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(141, "ID132_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(142, "ID133_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(143, "ID134_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(144, "ID135_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(145, "ID136_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(146, "ID137_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(147, "ID138_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(148, "ID139_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(149, "ID140_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(150, "ID141_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(151, "ID142_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(152, "ID143_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(153, "ID144_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(154, "ID145_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(155, "ID146_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(156, "ID147_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(157, "ID148_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(158, "ID149_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(159, "ID150_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(160, "ID151_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(161, "ID152_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(162, "ID153_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(163, "ID154_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(164, "ID155_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(165, "ID156_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(166, "ID157_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(167, "ID158_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(168, "ID159_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(169, "ID160_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(170, "ID161_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(171, "ID162_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(172, "ID163_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(173, "ID164_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(174, "ID165_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(175, "ID166_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(176, "ID167_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(177, "ID168_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(178, "ID169_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(179, "ID170_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(180, "ID171_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(181, "ID172_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(182, "ID173_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(183, "ID174_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(184, "ID175_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(185, "ID176_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(186, "ID177_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(187, "ID178_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(188, "ID179_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(189, "ID180_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(190, "ID181_ConyCony.png");
            this.PinImageList_Big.Images.SetKeyName(191, "ID182_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(192, "ID183_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(193, "ID184_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(194, "ID185_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(195, "ID186_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(196, "ID187_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(197, "ID188_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(198, "ID189_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(199, "ID190_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(200, "ID191_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(201, "ID192_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(202, "ID193_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(203, "ID194_ILCAVALLODELRE.png");
            this.PinImageList_Big.Images.SetKeyName(204, "ID195_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(205, "ID196_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(206, "ID197_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(207, "ID198_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(208, "ID199_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(209, "ID200_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(210, "ID201_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(211, "ID202_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(212, "ID203_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(213, "ID204_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(214, "ID205_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(215, "ID206_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(216, "ID207_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(217, "ID208_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(218, "ID209_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(219, "ID210_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(220, "ID211_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(221, "ID212_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(222, "ID213_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(223, "ID214_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(224, "ID215_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(225, "ID216_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(226, "ID217_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(227, "ID218_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(228, "ID219_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(229, "ID220_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(230, "ID221_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(231, "ID222_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(232, "ID223_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(233, "ID224_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(234, "ID225_TopoTopo.png");
            this.PinImageList_Big.Images.SetKeyName(235, "ID226_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(236, "ID227_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(237, "ID228_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(238, "ID229_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(239, "ID230_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(240, "ID231_NATURALPUPPY.png");
            this.PinImageList_Big.Images.SetKeyName(241, "ID232_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(242, "ID233_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(243, "ID234_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(244, "ID235_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(245, "ID236_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(246, "ID237_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(247, "ID238_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(248, "ID239_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(249, "ID240_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(250, "ID241_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(251, "ID242_RyuGu.png");
            this.PinImageList_Big.Images.SetKeyName(252, "ID243_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(253, "ID244_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(254, "ID245_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(255, "ID246_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(256, "ID247_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(257, "ID248_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(258, "ID249_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(259, "ID250_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(260, "ID251_croakypanic.png");
            this.PinImageList_Big.Images.SetKeyName(261, "ID252_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(262, "ID253_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(263, "ID254_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(264, "ID255_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(265, "ID256_ShepherdHouse.png");
            this.PinImageList_Big.Images.SetKeyName(266, "ID257_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(267, "ID258_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(268, "ID259_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(269, "ID260_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(270, "ID261_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(271, "ID262_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(272, "ID263_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(273, "ID264_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(274, "ID265_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(275, "ID266_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(276, "ID267_garagara.png");
            this.PinImageList_Big.Images.SetKeyName(277, "ID268_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(278, "ID269_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(279, "ID270_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(280, "ID271_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(281, "ID272_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(282, "ID273_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(283, "ID274_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(284, "ID275_HogFang.png");
            this.PinImageList_Big.Images.SetKeyName(285, "ID276_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(286, "ID277_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(287, "ID278_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(288, "ID279_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(289, "ID280_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(290, "ID281_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(291, "ID282_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(292, "ID283_TigrePUNKS.png");
            this.PinImageList_Big.Images.SetKeyName(293, "ID284_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(294, "ID285_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(295, "ID286_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(296, "ID287_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(297, "ID288_MONOCROW.png");
            this.PinImageList_Big.Images.SetKeyName(298, "ID289_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(299, "ID290_Jolibecot.png");
            this.PinImageList_Big.Images.SetKeyName(300, "ID291_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(301, "ID292_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(302, "ID293_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(303, "ID294_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(304, "ID295_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(305, "ID296_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(306, "ID297_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(307, "ID298_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(308, "ID299_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(309, "ID300_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(310, "ID301_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(311, "ID302_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(312, "ID303_GattoNero.png");
            this.PinImageList_Big.Images.SetKeyName(313, "ID304_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(314, "ID305_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(315, "ID306_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(316, "ID307_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(317, "ID308_JupiterOfTheMonkey.png");
            this.PinImageList_Big.Images.SetKeyName(318, "ID309_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(319, "ID310_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(320, "ID311_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(321, "ID312_NoBrand.png");
            this.PinImageList_Big.Images.SetKeyName(322, "ID323_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(323, "ID324_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(324, "ID325_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(325, "ID326_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(326, "ID327_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(327, "ID328_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(328, "ID329_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(329, "ID330_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(330, "ID331_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(331, "ID332_sozai.png");
            this.PinImageList_Big.Images.SetKeyName(332, "ID333_sozai.png");
            // 
            // BrandImageList
            // 
            this.BrandImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.BrandImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BrandImageList.ImageStream")));
            this.BrandImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.BrandImageList.Images.SetKeyName(0, "brand_01.png");
            this.BrandImageList.Images.SetKeyName(1, "brand_02.png");
            this.BrandImageList.Images.SetKeyName(2, "brand_03.png");
            this.BrandImageList.Images.SetKeyName(3, "brand_04.png");
            this.BrandImageList.Images.SetKeyName(4, "brand_05.png");
            this.BrandImageList.Images.SetKeyName(5, "brand_06.png");
            this.BrandImageList.Images.SetKeyName(6, "brand_07.png");
            this.BrandImageList.Images.SetKeyName(7, "brand_08.png");
            this.BrandImageList.Images.SetKeyName(8, "brand_09.png");
            this.BrandImageList.Images.SetKeyName(9, "brand_10.png");
            this.BrandImageList.Images.SetKeyName(10, "brand_11.png");
            this.BrandImageList.Images.SetKeyName(11, "brand_12.png");
            this.BrandImageList.Images.SetKeyName(12, "brand_13.png");
            this.BrandImageList.Images.SetKeyName(13, "brand_14.png");
            this.BrandImageList.Images.SetKeyName(14, "brand_15.png");
            // 
            // CharacterIconImageList
            // 
            this.CharacterIconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.CharacterIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CharacterIconImageList.ImageStream")));
            this.CharacterIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.CharacterIconImageList.Images.SetKeyName(0, "0.png");
            this.CharacterIconImageList.Images.SetKeyName(1, "1.png");
            this.CharacterIconImageList.Images.SetKeyName(2, "2.png");
            this.CharacterIconImageList.Images.SetKeyName(3, "3.png");
            this.CharacterIconImageList.Images.SetKeyName(4, "4.png");
            this.CharacterIconImageList.Images.SetKeyName(5, "5.png");
            this.CharacterIconImageList.Images.SetKeyName(6, "6.png");
            this.CharacterIconImageList.Images.SetKeyName(7, "7.png");
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
        private System.Windows.Forms.ImageList PinImageList_Small;
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
        private System.Windows.Forms.ImageList PinImageList_Big;
        private System.Windows.Forms.Label MasteredLabel;
        private System.Windows.Forms.Button RemoveAllPinsButton;
        private System.Windows.Forms.Button AddAllPinsButton;
        private System.Windows.Forms.CheckBox AddedPinIsMasteredCheckbox;
        private System.Windows.Forms.PictureBox BrandPictureBox;
        private System.Windows.Forms.ImageList BrandImageList;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label MaxLevelLabel_Value;
        private System.Windows.Forms.Label MaxLevelLabel_Info;
        private System.Windows.Forms.CheckBox Add99Checkbox;
        private System.Windows.Forms.ComboBox EquippedDeckComboBox;
        private System.Windows.Forms.PictureBox CharacterIconPictureBox;
        private System.Windows.Forms.ComboBox EquippedByCharacterComboBox;
        private System.Windows.Forms.Label EquippedLabel;
        private System.Windows.Forms.ImageList CharacterIconImageList;
    }
}