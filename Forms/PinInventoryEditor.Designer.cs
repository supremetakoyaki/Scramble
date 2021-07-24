
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
            this.PinLevelNUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoUpdateCheckbox = new System.Windows.Forms.CheckBox();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.MasterPinButton = new System.Windows.Forms.Button();
            this.PinImagePictureBox = new System.Windows.Forms.PictureBox();
            this.UpdatePinButton = new System.Windows.Forms.Button();
            this.MyPinInventoryView = new System.Windows.Forms.ListView();
            this.PinNameHeader = new System.Windows.Forms.ColumnHeader();
            this.PinIdHeader = new System.Windows.Forms.ColumnHeader();
            this.PinLevelHeader = new System.Windows.Forms.ColumnHeader();
            this.PinExperienceHeader = new System.Windows.Forms.ColumnHeader();
            this.PinIsMasteredHeader = new System.Windows.Forms.ColumnHeader();
            this.AmountHeader = new System.Windows.Forms.ColumnHeader();
            this.PinImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExperienceNUpDown = new System.Windows.Forms.NumericUpDown();
            this.ExpLabel = new System.Windows.Forms.Label();
            this.PinAmountUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PinLevelNUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExperienceNUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAmountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PinAmountUpDown);
            this.groupBox1.Controls.Add(this.AmountLabel);
            this.groupBox1.Controls.Add(this.ExperienceNUpDown);
            this.groupBox1.Controls.Add(this.ExpLabel);
            this.groupBox1.Controls.Add(this.PinLevelNUpDown);
            this.groupBox1.Controls.Add(this.AutoUpdateCheckbox);
            this.groupBox1.Controls.Add(this.LevelLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.MasterPinButton);
            this.groupBox1.Controls.Add(this.PinImagePictureBox);
            this.groupBox1.Controls.Add(this.UpdatePinButton);
            this.groupBox1.Controls.Add(this.MyPinInventoryView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 540);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pin Inventory";
            // 
            // PinLevelNUpDown
            // 
            this.PinLevelNUpDown.Location = new System.Drawing.Point(119, 434);
            this.PinLevelNUpDown.Name = "PinLevelNUpDown";
            this.PinLevelNUpDown.Size = new System.Drawing.Size(52, 23);
            this.PinLevelNUpDown.TabIndex = 9;
            this.PinLevelNUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AutoUpdateCheckbox
            // 
            this.AutoUpdateCheckbox.AutoSize = true;
            this.AutoUpdateCheckbox.Checked = true;
            this.AutoUpdateCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoUpdateCheckbox.Location = new System.Drawing.Point(306, 505);
            this.AutoUpdateCheckbox.Name = "AutoUpdateCheckbox";
            this.AutoUpdateCheckbox.Size = new System.Drawing.Size(94, 19);
            this.AutoUpdateCheckbox.TabIndex = 8;
            this.AutoUpdateCheckbox.Text = "Auto-update";
            this.AutoUpdateCheckbox.UseVisualStyleBackColor = true;
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(76, 437);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(37, 15);
            this.LevelLabel.TabIndex = 7;
            this.LevelLabel.Text = "Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(76, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "{PinName}";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Location = new System.Drawing.Point(6, 501);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Remove this pin";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // MasterPinButton
            // 
            this.MasterPinButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.MasterPinButton.Location = new System.Drawing.Point(177, 433);
            this.MasterPinButton.Name = "MasterPinButton";
            this.MasterPinButton.Size = new System.Drawing.Size(97, 23);
            this.MasterPinButton.TabIndex = 4;
            this.MasterPinButton.Text = "Master this pin";
            this.MasterPinButton.UseVisualStyleBackColor = true;
            // 
            // PinImagePictureBox
            // 
            this.PinImagePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("PinImagePictureBox.Image")));
            this.PinImagePictureBox.Location = new System.Drawing.Point(6, 417);
            this.PinImagePictureBox.Name = "PinImagePictureBox";
            this.PinImagePictureBox.Size = new System.Drawing.Size(64, 64);
            this.PinImagePictureBox.TabIndex = 3;
            this.PinImagePictureBox.TabStop = false;
            // 
            // UpdatePinButton
            // 
            this.UpdatePinButton.Location = new System.Drawing.Point(406, 481);
            this.UpdatePinButton.Name = "UpdatePinButton";
            this.UpdatePinButton.Size = new System.Drawing.Size(106, 43);
            this.UpdatePinButton.TabIndex = 2;
            this.UpdatePinButton.Text = "Update values";
            this.UpdatePinButton.UseVisualStyleBackColor = true;
            this.UpdatePinButton.Click += new System.EventHandler(this.UpdatePinButton_Click);
            // 
            // MyPinInventoryView
            // 
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
            this.MyPinInventoryView.Name = "MyPinInventoryView";
            this.MyPinInventoryView.Size = new System.Drawing.Size(506, 374);
            this.MyPinInventoryView.SmallImageList = this.PinImageList;
            this.MyPinInventoryView.TabIndex = 1;
            this.MyPinInventoryView.UseCompatibleStateImageBehavior = false;
            this.MyPinInventoryView.View = System.Windows.Forms.View.Details;
            this.MyPinInventoryView.SelectedIndexChanged += new System.EventHandler(this.MyPinInventoryView_SelectedIndexChanged);
            // 
            // PinNameHeader
            // 
            this.PinNameHeader.DisplayIndex = 1;
            this.PinNameHeader.Text = "Name";
            this.PinNameHeader.Width = 44;
            // 
            // PinIdHeader
            // 
            this.PinIdHeader.DisplayIndex = 0;
            this.PinIdHeader.Text = "Pin ID";
            this.PinIdHeader.Width = 43;
            // 
            // PinLevelHeader
            // 
            this.PinLevelHeader.Text = "Level";
            this.PinLevelHeader.Width = 39;
            // 
            // PinExperienceHeader
            // 
            this.PinExperienceHeader.Text = "EXP";
            this.PinExperienceHeader.Width = 32;
            // 
            // PinIsMasteredHeader
            // 
            this.PinIsMasteredHeader.Text = "Mastered";
            this.PinIsMasteredHeader.Width = 61;
            // 
            // AmountHeader
            // 
            this.AmountHeader.Text = "Amount";
            this.AmountHeader.Width = 283;
            // 
            // PinImageList
            // 
            this.PinImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.PinImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PinImageList.ImageStream")));
            this.PinImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.PinImageList.Images.SetKeyName(0, "bad_99_00_00.png");
            this.PinImageList.Images.SetKeyName(1, "bad_99_00_01.png");
            this.PinImageList.Images.SetKeyName(2, "bad_99_00_02.png");
            this.PinImageList.Images.SetKeyName(3, "bad_99_00_03.png");
            this.PinImageList.Images.SetKeyName(4, "bad_99_00_04.png");
            this.PinImageList.Images.SetKeyName(5, "bad_99_00_05.png");
            this.PinImageList.Images.SetKeyName(6, "bad_99_00_06.png");
            this.PinImageList.Images.SetKeyName(7, "bad_99_00_07.png");
            this.PinImageList.Images.SetKeyName(8, "bad_99_00_08.png");
            this.PinImageList.Images.SetKeyName(9, "bad_99_00_09.png");
            this.PinImageList.Images.SetKeyName(10, "ID001_NoBrand.png");
            this.PinImageList.Images.SetKeyName(11, "ID002_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(12, "ID003_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(13, "ID004_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(14, "ID005_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(15, "ID006_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(16, "ID007_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(17, "ID008_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(18, "ID009_NoBrand.png");
            this.PinImageList.Images.SetKeyName(19, "ID010_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(20, "ID011_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(21, "ID012_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(22, "ID013_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(23, "ID014_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(24, "ID015_croakypanic.png");
            this.PinImageList.Images.SetKeyName(25, "ID016_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(26, "ID017_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(27, "ID018_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(28, "ID019_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(29, "ID020_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(30, "ID021_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(31, "ID022_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(32, "ID023_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(33, "ID024_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(34, "ID025_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(35, "ID026_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(36, "ID027_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(37, "ID028_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(38, "ID029_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(39, "ID030_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(40, "ID031_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(41, "ID032_NoBrand.png");
            this.PinImageList.Images.SetKeyName(42, "ID033_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(43, "ID034_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(44, "ID035_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(45, "ID036_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(46, "ID037_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(47, "ID038_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(48, "ID039_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(49, "ID040_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(50, "ID041_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(51, "ID042_NoBrand.png");
            this.PinImageList.Images.SetKeyName(52, "ID043_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(53, "ID044_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(54, "ID045_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(55, "ID046_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(56, "ID047_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(57, "ID048_NoBrand.png");
            this.PinImageList.Images.SetKeyName(58, "ID049_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(59, "ID050_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(60, "ID051_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(61, "ID052_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(62, "ID053_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(63, "ID054_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(64, "ID055_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(65, "ID056_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(66, "ID057_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(67, "ID058_NoBrand.png");
            this.PinImageList.Images.SetKeyName(68, "ID059_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(69, "ID060_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(70, "ID061_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(71, "ID062_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(72, "ID063_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(73, "ID064_croakypanic.png");
            this.PinImageList.Images.SetKeyName(74, "ID065_croakypanic.png");
            this.PinImageList.Images.SetKeyName(75, "ID066_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(76, "ID067_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(77, "ID068_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(78, "ID069_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(79, "ID070_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(80, "ID071_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(81, "ID072_NoBrand.png");
            this.PinImageList.Images.SetKeyName(82, "ID073_ConyCony.png");
            this.PinImageList.Images.SetKeyName(83, "ID074_ConyCony.png");
            this.PinImageList.Images.SetKeyName(84, "ID075_ConyCony.png");
            this.PinImageList.Images.SetKeyName(85, "ID076_ConyCony.png");
            this.PinImageList.Images.SetKeyName(86, "ID077_ConyCony.png");
            this.PinImageList.Images.SetKeyName(87, "ID078_ConyCony.png");
            this.PinImageList.Images.SetKeyName(88, "ID079_ConyCony.png");
            this.PinImageList.Images.SetKeyName(89, "ID080_ConyCony.png");
            this.PinImageList.Images.SetKeyName(90, "ID081_NoBrand.png");
            this.PinImageList.Images.SetKeyName(91, "ID082_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(92, "ID083_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(93, "ID084_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(94, "ID085_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(95, "ID086_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(96, "ID087_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(97, "ID088_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(98, "ID089_NoBrand.png");
            this.PinImageList.Images.SetKeyName(99, "ID090_garagara.png");
            this.PinImageList.Images.SetKeyName(100, "ID091_garagara.png");
            this.PinImageList.Images.SetKeyName(101, "ID092_garagara.png");
            this.PinImageList.Images.SetKeyName(102, "ID093_garagara.png");
            this.PinImageList.Images.SetKeyName(103, "ID094_garagara.png");
            this.PinImageList.Images.SetKeyName(104, "ID095_garagara.png");
            this.PinImageList.Images.SetKeyName(105, "ID096_garagara.png");
            this.PinImageList.Images.SetKeyName(106, "ID097_garagara.png");
            this.PinImageList.Images.SetKeyName(107, "ID098_croakypanic.png");
            this.PinImageList.Images.SetKeyName(108, "ID099_croakypanic.png");
            this.PinImageList.Images.SetKeyName(109, "ID100_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(110, "ID101_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(111, "ID102_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(112, "ID103_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(113, "ID104_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(114, "ID105_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(115, "ID106_NoBrand.png");
            this.PinImageList.Images.SetKeyName(116, "ID107_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(117, "ID108_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(118, "ID109_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(119, "ID110_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(120, "ID111_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(121, "ID112_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(122, "ID113_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(123, "ID114_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(124, "ID115_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(125, "ID116_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(126, "ID117_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(127, "ID118_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(128, "ID119_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(129, "ID120_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(130, "ID121_NoBrand.png");
            this.PinImageList.Images.SetKeyName(131, "ID122_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(132, "ID123_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(133, "ID124_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(134, "ID125_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(135, "ID126_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(136, "ID127_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(137, "ID128_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(138, "ID129_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(139, "ID130_NoBrand.png");
            this.PinImageList.Images.SetKeyName(140, "ID131_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(141, "ID132_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(142, "ID133_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(143, "ID134_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(144, "ID135_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(145, "ID136_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(146, "ID137_NoBrand.png");
            this.PinImageList.Images.SetKeyName(147, "ID138_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(148, "ID139_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(149, "ID140_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(150, "ID141_ConyCony.png");
            this.PinImageList.Images.SetKeyName(151, "ID142_ConyCony.png");
            this.PinImageList.Images.SetKeyName(152, "ID143_ConyCony.png");
            this.PinImageList.Images.SetKeyName(153, "ID144_ConyCony.png");
            this.PinImageList.Images.SetKeyName(154, "ID145_ConyCony.png");
            this.PinImageList.Images.SetKeyName(155, "ID146_ConyCony.png");
            this.PinImageList.Images.SetKeyName(156, "ID147_ConyCony.png");
            this.PinImageList.Images.SetKeyName(157, "ID148_ConyCony.png");
            this.PinImageList.Images.SetKeyName(158, "ID149_NoBrand.png");
            this.PinImageList.Images.SetKeyName(159, "ID150_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(160, "ID151_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(161, "ID152_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(162, "ID153_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(163, "ID154_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(164, "ID155_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(165, "ID156_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(166, "ID157_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(167, "ID158_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(168, "ID159_NoBrand.png");
            this.PinImageList.Images.SetKeyName(169, "ID160_RyuGu.png");
            this.PinImageList.Images.SetKeyName(170, "ID161_RyuGu.png");
            this.PinImageList.Images.SetKeyName(171, "ID162_RyuGu.png");
            this.PinImageList.Images.SetKeyName(172, "ID163_RyuGu.png");
            this.PinImageList.Images.SetKeyName(173, "ID164_RyuGu.png");
            this.PinImageList.Images.SetKeyName(174, "ID165_RyuGu.png");
            this.PinImageList.Images.SetKeyName(175, "ID166_RyuGu.png");
            this.PinImageList.Images.SetKeyName(176, "ID167_RyuGu.png");
            this.PinImageList.Images.SetKeyName(177, "ID168_croakypanic.png");
            this.PinImageList.Images.SetKeyName(178, "ID169_RyuGu.png");
            this.PinImageList.Images.SetKeyName(179, "ID170_RyuGu.png");
            this.PinImageList.Images.SetKeyName(180, "ID171_RyuGu.png");
            this.PinImageList.Images.SetKeyName(181, "ID172_croakypanic.png");
            this.PinImageList.Images.SetKeyName(182, "ID173_RyuGu.png");
            this.PinImageList.Images.SetKeyName(183, "ID174_NoBrand.png");
            this.PinImageList.Images.SetKeyName(184, "ID175_ConyCony.png");
            this.PinImageList.Images.SetKeyName(185, "ID176_ConyCony.png");
            this.PinImageList.Images.SetKeyName(186, "ID177_croakypanic.png");
            this.PinImageList.Images.SetKeyName(187, "ID178_croakypanic.png");
            this.PinImageList.Images.SetKeyName(188, "ID179_ConyCony.png");
            this.PinImageList.Images.SetKeyName(189, "ID180_ConyCony.png");
            this.PinImageList.Images.SetKeyName(190, "ID181_ConyCony.png");
            this.PinImageList.Images.SetKeyName(191, "ID182_NoBrand.png");
            this.PinImageList.Images.SetKeyName(192, "ID183_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(193, "ID184_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(194, "ID185_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(195, "ID186_croakypanic.png");
            this.PinImageList.Images.SetKeyName(196, "ID187_croakypanic.png");
            this.PinImageList.Images.SetKeyName(197, "ID188_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(198, "ID189_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(199, "ID190_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(200, "ID191_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(201, "ID192_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(202, "ID193_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(203, "ID194_ILCAVALLODELRE.png");
            this.PinImageList.Images.SetKeyName(204, "ID195_NoBrand.png");
            this.PinImageList.Images.SetKeyName(205, "ID196_HogFang.png");
            this.PinImageList.Images.SetKeyName(206, "ID197_HogFang.png");
            this.PinImageList.Images.SetKeyName(207, "ID198_HogFang.png");
            this.PinImageList.Images.SetKeyName(208, "ID199_HogFang.png");
            this.PinImageList.Images.SetKeyName(209, "ID200_HogFang.png");
            this.PinImageList.Images.SetKeyName(210, "ID201_HogFang.png");
            this.PinImageList.Images.SetKeyName(211, "ID202_HogFang.png");
            this.PinImageList.Images.SetKeyName(212, "ID203_HogFang.png");
            this.PinImageList.Images.SetKeyName(213, "ID204_HogFang.png");
            this.PinImageList.Images.SetKeyName(214, "ID205_HogFang.png");
            this.PinImageList.Images.SetKeyName(215, "ID206_NoBrand.png");
            this.PinImageList.Images.SetKeyName(216, "ID207_RyuGu.png");
            this.PinImageList.Images.SetKeyName(217, "ID208_RyuGu.png");
            this.PinImageList.Images.SetKeyName(218, "ID209_RyuGu.png");
            this.PinImageList.Images.SetKeyName(219, "ID210_RyuGu.png");
            this.PinImageList.Images.SetKeyName(220, "ID211_NoBrand.png");
            this.PinImageList.Images.SetKeyName(221, "ID212_RyuGu.png");
            this.PinImageList.Images.SetKeyName(222, "ID213_RyuGu.png");
            this.PinImageList.Images.SetKeyName(223, "ID214_RyuGu.png");
            this.PinImageList.Images.SetKeyName(224, "ID215_RyuGu.png");
            this.PinImageList.Images.SetKeyName(225, "ID216_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(226, "ID217_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(227, "ID218_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(228, "ID219_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(229, "ID220_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(230, "ID221_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(231, "ID222_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(232, "ID223_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(233, "ID224_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(234, "ID225_TopoTopo.png");
            this.PinImageList.Images.SetKeyName(235, "ID226_NoBrand.png");
            this.PinImageList.Images.SetKeyName(236, "ID227_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(237, "ID228_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(238, "ID229_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(239, "ID230_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(240, "ID231_NATURALPUPPY.png");
            this.PinImageList.Images.SetKeyName(241, "ID232_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(242, "ID233_croakypanic.png");
            this.PinImageList.Images.SetKeyName(243, "ID234_croakypanic.png");
            this.PinImageList.Images.SetKeyName(244, "ID235_croakypanic.png");
            this.PinImageList.Images.SetKeyName(245, "ID236_croakypanic.png");
            this.PinImageList.Images.SetKeyName(246, "ID237_croakypanic.png");
            this.PinImageList.Images.SetKeyName(247, "ID238_NoBrand.png");
            this.PinImageList.Images.SetKeyName(248, "ID239_NoBrand.png");
            this.PinImageList.Images.SetKeyName(249, "ID240_RyuGu.png");
            this.PinImageList.Images.SetKeyName(250, "ID241_RyuGu.png");
            this.PinImageList.Images.SetKeyName(251, "ID242_RyuGu.png");
            this.PinImageList.Images.SetKeyName(252, "ID243_NoBrand.png");
            this.PinImageList.Images.SetKeyName(253, "ID244_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(254, "ID245_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(255, "ID246_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(256, "ID247_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(257, "ID248_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(258, "ID249_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(259, "ID250_croakypanic.png");
            this.PinImageList.Images.SetKeyName(260, "ID251_croakypanic.png");
            this.PinImageList.Images.SetKeyName(261, "ID252_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(262, "ID253_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(263, "ID254_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(264, "ID255_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(265, "ID256_ShepherdHouse.png");
            this.PinImageList.Images.SetKeyName(266, "ID257_garagara.png");
            this.PinImageList.Images.SetKeyName(267, "ID258_garagara.png");
            this.PinImageList.Images.SetKeyName(268, "ID259_garagara.png");
            this.PinImageList.Images.SetKeyName(269, "ID260_garagara.png");
            this.PinImageList.Images.SetKeyName(270, "ID261_garagara.png");
            this.PinImageList.Images.SetKeyName(271, "ID262_garagara.png");
            this.PinImageList.Images.SetKeyName(272, "ID263_garagara.png");
            this.PinImageList.Images.SetKeyName(273, "ID264_garagara.png");
            this.PinImageList.Images.SetKeyName(274, "ID265_garagara.png");
            this.PinImageList.Images.SetKeyName(275, "ID266_garagara.png");
            this.PinImageList.Images.SetKeyName(276, "ID267_garagara.png");
            this.PinImageList.Images.SetKeyName(277, "ID268_NoBrand.png");
            this.PinImageList.Images.SetKeyName(278, "ID269_HogFang.png");
            this.PinImageList.Images.SetKeyName(279, "ID270_HogFang.png");
            this.PinImageList.Images.SetKeyName(280, "ID271_HogFang.png");
            this.PinImageList.Images.SetKeyName(281, "ID272_HogFang.png");
            this.PinImageList.Images.SetKeyName(282, "ID273_HogFang.png");
            this.PinImageList.Images.SetKeyName(283, "ID274_HogFang.png");
            this.PinImageList.Images.SetKeyName(284, "ID275_HogFang.png");
            this.PinImageList.Images.SetKeyName(285, "ID276_NoBrand.png");
            this.PinImageList.Images.SetKeyName(286, "ID277_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(287, "ID278_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(288, "ID279_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(289, "ID280_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(290, "ID281_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(291, "ID282_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(292, "ID283_TigrePUNKS.png");
            this.PinImageList.Images.SetKeyName(293, "ID284_NoBrand.png");
            this.PinImageList.Images.SetKeyName(294, "ID285_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(295, "ID286_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(296, "ID287_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(297, "ID288_MONOCROW.png");
            this.PinImageList.Images.SetKeyName(298, "ID289_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(299, "ID290_Jolibecot.png");
            this.PinImageList.Images.SetKeyName(300, "ID291_NoBrand.png");
            this.PinImageList.Images.SetKeyName(301, "ID292_GattoNero.png");
            this.PinImageList.Images.SetKeyName(302, "ID293_GattoNero.png");
            this.PinImageList.Images.SetKeyName(303, "ID294_GattoNero.png");
            this.PinImageList.Images.SetKeyName(304, "ID295_GattoNero.png");
            this.PinImageList.Images.SetKeyName(305, "ID296_GattoNero.png");
            this.PinImageList.Images.SetKeyName(306, "ID297_GattoNero.png");
            this.PinImageList.Images.SetKeyName(307, "ID298_GattoNero.png");
            this.PinImageList.Images.SetKeyName(308, "ID299_GattoNero.png");
            this.PinImageList.Images.SetKeyName(309, "ID300_GattoNero.png");
            this.PinImageList.Images.SetKeyName(310, "ID301_GattoNero.png");
            this.PinImageList.Images.SetKeyName(311, "ID302_GattoNero.png");
            this.PinImageList.Images.SetKeyName(312, "ID303_GattoNero.png");
            this.PinImageList.Images.SetKeyName(313, "ID304_NoBrand.png");
            this.PinImageList.Images.SetKeyName(314, "ID305_NoBrand.png");
            this.PinImageList.Images.SetKeyName(315, "ID306_NoBrand.png");
            this.PinImageList.Images.SetKeyName(316, "ID307_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(317, "ID308_JupiterOfTheMonkey.png");
            this.PinImageList.Images.SetKeyName(318, "ID309_NoBrand.png");
            this.PinImageList.Images.SetKeyName(319, "ID310_NoBrand.png");
            this.PinImageList.Images.SetKeyName(320, "ID311_NoBrand.png");
            this.PinImageList.Images.SetKeyName(321, "ID312_NoBrand.png");
            this.PinImageList.Images.SetKeyName(322, "ID323_sozai.png");
            this.PinImageList.Images.SetKeyName(323, "ID324_sozai.png");
            this.PinImageList.Images.SetKeyName(324, "ID325_sozai.png");
            this.PinImageList.Images.SetKeyName(325, "ID326_sozai.png");
            this.PinImageList.Images.SetKeyName(326, "ID327_sozai.png");
            this.PinImageList.Images.SetKeyName(327, "ID328_sozai.png");
            this.PinImageList.Images.SetKeyName(328, "ID329_sozai.png");
            this.PinImageList.Images.SetKeyName(329, "ID330_sozai.png");
            this.PinImageList.Images.SetKeyName(330, "ID331_sozai.png");
            this.PinImageList.Images.SetKeyName(331, "ID332_sozai.png");
            this.PinImageList.Images.SetKeyName(332, "ID333_sozai.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(549, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 332);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // ExperienceNUpDown
            // 
            this.ExperienceNUpDown.Location = new System.Drawing.Point(119, 463);
            this.ExperienceNUpDown.Maximum = new decimal(new int[] {
            1356,
            0,
            0,
            0});
            this.ExperienceNUpDown.Name = "ExperienceNUpDown";
            this.ExperienceNUpDown.Size = new System.Drawing.Size(52, 23);
            this.ExperienceNUpDown.TabIndex = 11;
            // 
            // ExpLabel
            // 
            this.ExpLabel.AutoSize = true;
            this.ExpLabel.Location = new System.Drawing.Point(76, 466);
            this.ExpLabel.Name = "ExpLabel";
            this.ExpLabel.Size = new System.Drawing.Size(30, 15);
            this.ExpLabel.TabIndex = 10;
            this.ExpLabel.Text = "EXP:";
            // 
            // PinAmountUpDown
            // 
            this.PinAmountUpDown.Location = new System.Drawing.Point(460, 433);
            this.PinAmountUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PinAmountUpDown.Name = "PinAmountUpDown";
            this.PinAmountUpDown.Size = new System.Drawing.Size(52, 23);
            this.PinAmountUpDown.TabIndex = 13;
            this.PinAmountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(406, 437);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(54, 15);
            this.AmountLabel.TabIndex = 12;
            this.AmountLabel.Text = "Amount:";
            // 
            // PinInventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 558);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PinInventoryEditor";
            this.Text = "Pin Inventory Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PinLevelNUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExperienceNUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinAmountUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UpdatePinButton;
        private System.Windows.Forms.ListView MyPinInventoryView;
        private System.Windows.Forms.ColumnHeader PinIdHeader;
        private System.Windows.Forms.ColumnHeader PinNameHeader;
        private System.Windows.Forms.ColumnHeader PinLevelHeader;
        private System.Windows.Forms.ColumnHeader PinExperienceHeader;
        private System.Windows.Forms.ColumnHeader PinIsMasteredHeader;
        private System.Windows.Forms.ImageList PinImageList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader AmountHeader;
        private System.Windows.Forms.PictureBox PinImagePictureBox;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button MasterPinButton;
        private System.Windows.Forms.CheckBox AutoUpdateCheckbox;
        private System.Windows.Forms.NumericUpDown PinLevelNUpDown;
        private System.Windows.Forms.NumericUpDown ExperienceNUpDown;
        private System.Windows.Forms.Label ExpLabel;
        private System.Windows.Forms.NumericUpDown PinAmountUpDown;
        private System.Windows.Forms.Label AmountLabel;
    }
}