
namespace Scramble.Forms
{
    partial class NoisepediaEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoisepediaEditor));
            this.NoiseImgPictureBox = new System.Windows.Forms.PictureBox();
            this.NoiseListGroupBox = new System.Windows.Forms.GroupBox();
            this.NoisepediaListView = new System.Windows.Forms.ListView();
            this.UnlockAllButton = new System.Windows.Forms.Button();
            this.UnlockAll_PinsCheckbox = new System.Windows.Forms.CheckBox();
            this.NoiseInfo_GroupBox = new System.Windows.Forms.GroupBox();
            this.NoiseName_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.SortedIdHeader = new System.Windows.Forms.ColumnHeader();
            this.NoiseIdHeader = new System.Windows.Forms.ColumnHeader();
            this.NameHeader = new System.Windows.Forms.ColumnHeader();
            this.NoiseDesc_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.RecordLevel_Label = new System.Windows.Forms.Label();
            this.RecordLevel_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ErasedCount_Label = new System.Windows.Forms.Label();
            this.ErasedCount_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Encountered_Checkbox = new System.Windows.Forms.CheckBox();
            this.PinDrop_Easy_PictureBox = new System.Windows.Forms.PictureBox();
            this.PinDrop_Normal_PictureBox = new System.Windows.Forms.PictureBox();
            this.PinDrop_Hard_PictureBox = new System.Windows.Forms.PictureBox();
            this.PinDrop_Ultimate_PictureBox = new System.Windows.Forms.PictureBox();
            this.Hp_Label = new System.Windows.Forms.Label();
            this.HpValue_Label = new System.Windows.Forms.Label();
            this.ExpValue_Label = new System.Windows.Forms.Label();
            this.Exp_Label = new System.Windows.Forms.Label();
            this.PpValue_Label = new System.Windows.Forms.Label();
            this.Pp_Label = new System.Windows.Forms.Label();
            this.Easy_Label = new System.Windows.Forms.Label();
            this.Normal_Label = new System.Windows.Forms.Label();
            this.Hard_Label = new System.Windows.Forms.Label();
            this.Ultimate_Label = new System.Windows.Forms.Label();
            this.Easy_DropRateValue_Label = new System.Windows.Forms.Label();
            this.Normal_DropRateValue_Label = new System.Windows.Forms.Label();
            this.Hard_DropRateValue_Label = new System.Windows.Forms.Label();
            this.Ultimate_DropRateValue_Label = new System.Windows.Forms.Label();
            this.Pin_Easy_Checkbox = new System.Windows.Forms.CheckBox();
            this.Pin_Normal_Checkbox = new System.Windows.Forms.CheckBox();
            this.Pin_Hard_Checkbox = new System.Windows.Forms.CheckBox();
            this.Pin_Ultimate_Checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NoiseImgPictureBox)).BeginInit();
            this.NoiseListGroupBox.SuspendLayout();
            this.NoiseInfo_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordLevel_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErasedCount_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Easy_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Normal_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Hard_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Ultimate_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NoiseImgPictureBox
            // 
            this.NoiseImgPictureBox.Location = new System.Drawing.Point(6, 28);
            this.NoiseImgPictureBox.Name = "NoiseImgPictureBox";
            this.NoiseImgPictureBox.Size = new System.Drawing.Size(850, 478);
            this.NoiseImgPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.NoiseImgPictureBox.TabIndex = 0;
            this.NoiseImgPictureBox.TabStop = false;
            // 
            // NoiseListGroupBox
            // 
            this.NoiseListGroupBox.Controls.Add(this.UnlockAll_PinsCheckbox);
            this.NoiseListGroupBox.Controls.Add(this.UnlockAllButton);
            this.NoiseListGroupBox.Controls.Add(this.NoisepediaListView);
            this.NoiseListGroupBox.Location = new System.Drawing.Point(12, 12);
            this.NoiseListGroupBox.Name = "NoiseListGroupBox";
            this.NoiseListGroupBox.Size = new System.Drawing.Size(280, 513);
            this.NoiseListGroupBox.TabIndex = 0;
            this.NoiseListGroupBox.TabStop = false;
            this.NoiseListGroupBox.Text = "{NoiseList}";
            // 
            // NoisepediaListView
            // 
            this.NoisepediaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SortedIdHeader,
            this.NoiseIdHeader,
            this.NameHeader});
            this.NoisepediaListView.FullRowSelect = true;
            this.NoisepediaListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.NoisepediaListView.HideSelection = false;
            this.NoisepediaListView.Location = new System.Drawing.Point(6, 22);
            this.NoisepediaListView.MultiSelect = false;
            this.NoisepediaListView.Name = "NoisepediaListView";
            this.NoisepediaListView.Size = new System.Drawing.Size(268, 456);
            this.NoisepediaListView.TabIndex = 0;
            this.NoisepediaListView.UseCompatibleStateImageBehavior = false;
            this.NoisepediaListView.View = System.Windows.Forms.View.Details;
            // 
            // UnlockAllButton
            // 
            this.UnlockAllButton.BackColor = System.Drawing.Color.LightCyan;
            this.UnlockAllButton.Location = new System.Drawing.Point(6, 484);
            this.UnlockAllButton.Name = "UnlockAllButton";
            this.UnlockAllButton.Size = new System.Drawing.Size(147, 23);
            this.UnlockAllButton.TabIndex = 1;
            this.UnlockAllButton.Text = "{UnlockAll}";
            this.UnlockAllButton.UseVisualStyleBackColor = false;
            // 
            // UnlockAll_PinsCheckbox
            // 
            this.UnlockAll_PinsCheckbox.AutoSize = true;
            this.UnlockAll_PinsCheckbox.Checked = true;
            this.UnlockAll_PinsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UnlockAll_PinsCheckbox.Location = new System.Drawing.Point(159, 487);
            this.UnlockAll_PinsCheckbox.Name = "UnlockAll_PinsCheckbox";
            this.UnlockAll_PinsCheckbox.Size = new System.Drawing.Size(56, 19);
            this.UnlockAll_PinsCheckbox.TabIndex = 2;
            this.UnlockAll_PinsCheckbox.Text = "{Pins}";
            this.UnlockAll_PinsCheckbox.UseVisualStyleBackColor = true;
            // 
            // NoiseInfo_GroupBox
            // 
            this.NoiseInfo_GroupBox.Controls.Add(this.Pin_Ultimate_Checkbox);
            this.NoiseInfo_GroupBox.Controls.Add(this.Pin_Hard_Checkbox);
            this.NoiseInfo_GroupBox.Controls.Add(this.Pin_Normal_Checkbox);
            this.NoiseInfo_GroupBox.Controls.Add(this.Pin_Easy_Checkbox);
            this.NoiseInfo_GroupBox.Controls.Add(this.Ultimate_DropRateValue_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Hard_DropRateValue_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Normal_DropRateValue_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Easy_DropRateValue_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Ultimate_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Hard_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Normal_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Easy_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.PpValue_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Pp_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.ExpValue_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Exp_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.HpValue_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.Hp_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.PinDrop_Ultimate_PictureBox);
            this.NoiseInfo_GroupBox.Controls.Add(this.PinDrop_Hard_PictureBox);
            this.NoiseInfo_GroupBox.Controls.Add(this.PinDrop_Normal_PictureBox);
            this.NoiseInfo_GroupBox.Controls.Add(this.PinDrop_Easy_PictureBox);
            this.NoiseInfo_GroupBox.Controls.Add(this.Encountered_Checkbox);
            this.NoiseInfo_GroupBox.Controls.Add(this.ErasedCount_NumUpDown);
            this.NoiseInfo_GroupBox.Controls.Add(this.ErasedCount_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.RecordLevel_NumUpDown);
            this.NoiseInfo_GroupBox.Controls.Add(this.RecordLevel_Label);
            this.NoiseInfo_GroupBox.Controls.Add(this.NoiseDesc_RichTextBox);
            this.NoiseInfo_GroupBox.Controls.Add(this.NoiseName_RichTextBox);
            this.NoiseInfo_GroupBox.Controls.Add(this.NoiseImgPictureBox);
            this.NoiseInfo_GroupBox.Location = new System.Drawing.Point(298, 12);
            this.NoiseInfo_GroupBox.Name = "NoiseInfo_GroupBox";
            this.NoiseInfo_GroupBox.Size = new System.Drawing.Size(862, 513);
            this.NoiseInfo_GroupBox.TabIndex = 2;
            this.NoiseInfo_GroupBox.TabStop = false;
            this.NoiseInfo_GroupBox.Text = "{NoiseInfo}";
            // 
            // NoiseName_RichTextBox
            // 
            this.NoiseName_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.NoiseName_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NoiseName_RichTextBox.Enabled = false;
            this.NoiseName_RichTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NoiseName_RichTextBox.Location = new System.Drawing.Point(17, 43);
            this.NoiseName_RichTextBox.Multiline = false;
            this.NoiseName_RichTextBox.Name = "NoiseName_RichTextBox";
            this.NoiseName_RichTextBox.ReadOnly = true;
            this.NoiseName_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.NoiseName_RichTextBox.Size = new System.Drawing.Size(431, 27);
            this.NoiseName_RichTextBox.TabIndex = 3;
            this.NoiseName_RichTextBox.TabStop = false;
            this.NoiseName_RichTextBox.Text = "{NoiseName}";
            // 
            // SortedIdHeader
            // 
            this.SortedIdHeader.Text = "{SortedId}";
            this.SortedIdHeader.Width = 42;
            // 
            // NoiseIdHeader
            // 
            this.NoiseIdHeader.Text = "{NoiseId}";
            this.NoiseIdHeader.Width = 42;
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 180;
            // 
            // NoiseDesc_RichTextBox
            // 
            this.NoiseDesc_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.NoiseDesc_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NoiseDesc_RichTextBox.Enabled = false;
            this.NoiseDesc_RichTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoiseDesc_RichTextBox.Location = new System.Drawing.Point(17, 76);
            this.NoiseDesc_RichTextBox.Name = "NoiseDesc_RichTextBox";
            this.NoiseDesc_RichTextBox.ReadOnly = true;
            this.NoiseDesc_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.NoiseDesc_RichTextBox.Size = new System.Drawing.Size(431, 119);
            this.NoiseDesc_RichTextBox.TabIndex = 4;
            this.NoiseDesc_RichTextBox.TabStop = false;
            this.NoiseDesc_RichTextBox.Text = resources.GetString("NoiseDesc_RichTextBox.Text");
            // 
            // RecordLevel_Label
            // 
            this.RecordLevel_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RecordLevel_Label.Location = new System.Drawing.Point(238, 227);
            this.RecordLevel_Label.Name = "RecordLevel_Label";
            this.RecordLevel_Label.Size = new System.Drawing.Size(136, 23);
            this.RecordLevel_Label.TabIndex = 13;
            this.RecordLevel_Label.Text = "{RecordLevel:}";
            // 
            // RecordLevel_NumUpDown
            // 
            this.RecordLevel_NumUpDown.Location = new System.Drawing.Point(380, 227);
            this.RecordLevel_NumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RecordLevel_NumUpDown.Name = "RecordLevel_NumUpDown";
            this.RecordLevel_NumUpDown.Size = new System.Drawing.Size(68, 23);
            this.RecordLevel_NumUpDown.TabIndex = 14;
            this.RecordLevel_NumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ErasedCount_Label
            // 
            this.ErasedCount_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ErasedCount_Label.Location = new System.Drawing.Point(238, 256);
            this.ErasedCount_Label.Name = "ErasedCount_Label";
            this.ErasedCount_Label.Size = new System.Drawing.Size(136, 23);
            this.ErasedCount_Label.TabIndex = 15;
            this.ErasedCount_Label.Text = "{ErasedCount:}";
            // 
            // ErasedCount_NumUpDown
            // 
            this.ErasedCount_NumUpDown.Location = new System.Drawing.Point(380, 256);
            this.ErasedCount_NumUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.ErasedCount_NumUpDown.Name = "ErasedCount_NumUpDown";
            this.ErasedCount_NumUpDown.Size = new System.Drawing.Size(68, 23);
            this.ErasedCount_NumUpDown.TabIndex = 16;
            this.ErasedCount_NumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Encountered_Checkbox
            // 
            this.Encountered_Checkbox.AutoSize = true;
            this.Encountered_Checkbox.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Encountered_Checkbox.Location = new System.Drawing.Point(243, 198);
            this.Encountered_Checkbox.Name = "Encountered_Checkbox";
            this.Encountered_Checkbox.Size = new System.Drawing.Size(108, 21);
            this.Encountered_Checkbox.TabIndex = 12;
            this.Encountered_Checkbox.Text = "{Encountered}";
            this.Encountered_Checkbox.UseVisualStyleBackColor = true;
            // 
            // PinDrop_Easy_PictureBox
            // 
            this.PinDrop_Easy_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PinDrop_Easy_PictureBox.Location = new System.Drawing.Point(17, 322);
            this.PinDrop_Easy_PictureBox.Name = "PinDrop_Easy_PictureBox";
            this.PinDrop_Easy_PictureBox.Size = new System.Drawing.Size(100, 100);
            this.PinDrop_Easy_PictureBox.TabIndex = 7;
            this.PinDrop_Easy_PictureBox.TabStop = false;
            // 
            // PinDrop_Normal_PictureBox
            // 
            this.PinDrop_Normal_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PinDrop_Normal_PictureBox.Location = new System.Drawing.Point(157, 322);
            this.PinDrop_Normal_PictureBox.Name = "PinDrop_Normal_PictureBox";
            this.PinDrop_Normal_PictureBox.Size = new System.Drawing.Size(100, 100);
            this.PinDrop_Normal_PictureBox.TabIndex = 8;
            this.PinDrop_Normal_PictureBox.TabStop = false;
            // 
            // PinDrop_Hard_PictureBox
            // 
            this.PinDrop_Hard_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PinDrop_Hard_PictureBox.Location = new System.Drawing.Point(297, 322);
            this.PinDrop_Hard_PictureBox.Name = "PinDrop_Hard_PictureBox";
            this.PinDrop_Hard_PictureBox.Size = new System.Drawing.Size(100, 100);
            this.PinDrop_Hard_PictureBox.TabIndex = 9;
            this.PinDrop_Hard_PictureBox.TabStop = false;
            // 
            // PinDrop_Ultimate_PictureBox
            // 
            this.PinDrop_Ultimate_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PinDrop_Ultimate_PictureBox.Location = new System.Drawing.Point(437, 322);
            this.PinDrop_Ultimate_PictureBox.Name = "PinDrop_Ultimate_PictureBox";
            this.PinDrop_Ultimate_PictureBox.Size = new System.Drawing.Size(100, 100);
            this.PinDrop_Ultimate_PictureBox.TabIndex = 10;
            this.PinDrop_Ultimate_PictureBox.TabStop = false;
            // 
            // Hp_Label
            // 
            this.Hp_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Hp_Label.ForeColor = System.Drawing.Color.ForestGreen;
            this.Hp_Label.Location = new System.Drawing.Point(17, 198);
            this.Hp_Label.Name = "Hp_Label";
            this.Hp_Label.Size = new System.Drawing.Size(72, 23);
            this.Hp_Label.TabIndex = 6;
            this.Hp_Label.Text = "{Hp:}";
            // 
            // HpValue_Label
            // 
            this.HpValue_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HpValue_Label.Location = new System.Drawing.Point(95, 198);
            this.HpValue_Label.Name = "HpValue_Label";
            this.HpValue_Label.Size = new System.Drawing.Size(88, 23);
            this.HpValue_Label.TabIndex = 7;
            this.HpValue_Label.Text = "{HpValue}";
            // 
            // ExpValue_Label
            // 
            this.ExpValue_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExpValue_Label.Location = new System.Drawing.Point(95, 227);
            this.ExpValue_Label.Name = "ExpValue_Label";
            this.ExpValue_Label.Size = new System.Drawing.Size(88, 23);
            this.ExpValue_Label.TabIndex = 9;
            this.ExpValue_Label.Text = "{ExpValue}";
            // 
            // Exp_Label
            // 
            this.Exp_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Exp_Label.ForeColor = System.Drawing.Color.DarkCyan;
            this.Exp_Label.Location = new System.Drawing.Point(17, 227);
            this.Exp_Label.Name = "Exp_Label";
            this.Exp_Label.Size = new System.Drawing.Size(72, 23);
            this.Exp_Label.TabIndex = 8;
            this.Exp_Label.Text = "{Exp:}";
            // 
            // PpValue_Label
            // 
            this.PpValue_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PpValue_Label.Location = new System.Drawing.Point(95, 256);
            this.PpValue_Label.Name = "PpValue_Label";
            this.PpValue_Label.Size = new System.Drawing.Size(88, 23);
            this.PpValue_Label.TabIndex = 11;
            this.PpValue_Label.Text = "{PpValue}";
            // 
            // Pp_Label
            // 
            this.Pp_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Pp_Label.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.Pp_Label.Location = new System.Drawing.Point(17, 256);
            this.Pp_Label.Name = "Pp_Label";
            this.Pp_Label.Size = new System.Drawing.Size(72, 23);
            this.Pp_Label.TabIndex = 10;
            this.Pp_Label.Text = "{Pp:}";
            // 
            // Easy_Label
            // 
            this.Easy_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Easy_Label.Location = new System.Drawing.Point(17, 425);
            this.Easy_Label.Name = "Easy_Label";
            this.Easy_Label.Size = new System.Drawing.Size(100, 19);
            this.Easy_Label.TabIndex = 17;
            this.Easy_Label.Text = "{EASY}";
            this.Easy_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Normal_Label
            // 
            this.Normal_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Normal_Label.Location = new System.Drawing.Point(157, 425);
            this.Normal_Label.Name = "Normal_Label";
            this.Normal_Label.Size = new System.Drawing.Size(100, 19);
            this.Normal_Label.TabIndex = 18;
            this.Normal_Label.Text = "{NORMAL}";
            this.Normal_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Hard_Label
            // 
            this.Hard_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Hard_Label.Location = new System.Drawing.Point(297, 425);
            this.Hard_Label.Name = "Hard_Label";
            this.Hard_Label.Size = new System.Drawing.Size(100, 19);
            this.Hard_Label.TabIndex = 19;
            this.Hard_Label.Text = "{HARD}";
            this.Hard_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Ultimate_Label
            // 
            this.Ultimate_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Ultimate_Label.Location = new System.Drawing.Point(437, 425);
            this.Ultimate_Label.Name = "Ultimate_Label";
            this.Ultimate_Label.Size = new System.Drawing.Size(100, 19);
            this.Ultimate_Label.TabIndex = 20;
            this.Ultimate_Label.Text = "{ULTIMATE}";
            this.Ultimate_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Easy_DropRateValue_Label
            // 
            this.Easy_DropRateValue_Label.BackColor = System.Drawing.Color.Transparent;
            this.Easy_DropRateValue_Label.Location = new System.Drawing.Point(58, 444);
            this.Easy_DropRateValue_Label.Name = "Easy_DropRateValue_Label";
            this.Easy_DropRateValue_Label.Size = new System.Drawing.Size(59, 23);
            this.Easy_DropRateValue_Label.TabIndex = 21;
            this.Easy_DropRateValue_Label.Text = "{Drop%}";
            this.Easy_DropRateValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Normal_DropRateValue_Label
            // 
            this.Normal_DropRateValue_Label.BackColor = System.Drawing.Color.Transparent;
            this.Normal_DropRateValue_Label.Location = new System.Drawing.Point(198, 444);
            this.Normal_DropRateValue_Label.Name = "Normal_DropRateValue_Label";
            this.Normal_DropRateValue_Label.Size = new System.Drawing.Size(59, 23);
            this.Normal_DropRateValue_Label.TabIndex = 22;
            this.Normal_DropRateValue_Label.Text = "{Drop%}";
            this.Normal_DropRateValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Hard_DropRateValue_Label
            // 
            this.Hard_DropRateValue_Label.BackColor = System.Drawing.Color.Transparent;
            this.Hard_DropRateValue_Label.Location = new System.Drawing.Point(338, 444);
            this.Hard_DropRateValue_Label.Name = "Hard_DropRateValue_Label";
            this.Hard_DropRateValue_Label.Size = new System.Drawing.Size(59, 23);
            this.Hard_DropRateValue_Label.TabIndex = 23;
            this.Hard_DropRateValue_Label.Text = "{Drop%}";
            this.Hard_DropRateValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Ultimate_DropRateValue_Label
            // 
            this.Ultimate_DropRateValue_Label.BackColor = System.Drawing.Color.Transparent;
            this.Ultimate_DropRateValue_Label.Location = new System.Drawing.Point(478, 444);
            this.Ultimate_DropRateValue_Label.Name = "Ultimate_DropRateValue_Label";
            this.Ultimate_DropRateValue_Label.Size = new System.Drawing.Size(59, 23);
            this.Ultimate_DropRateValue_Label.TabIndex = 24;
            this.Ultimate_DropRateValue_Label.Text = "{Drop%}";
            this.Ultimate_DropRateValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Pin_Easy_Checkbox
            // 
            this.Pin_Easy_Checkbox.AutoSize = true;
            this.Pin_Easy_Checkbox.Location = new System.Drawing.Point(17, 449);
            this.Pin_Easy_Checkbox.Name = "Pin_Easy_Checkbox";
            this.Pin_Easy_Checkbox.Size = new System.Drawing.Size(15, 14);
            this.Pin_Easy_Checkbox.TabIndex = 24;
            this.Pin_Easy_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Pin_Normal_Checkbox
            // 
            this.Pin_Normal_Checkbox.AutoSize = true;
            this.Pin_Normal_Checkbox.Location = new System.Drawing.Point(157, 449);
            this.Pin_Normal_Checkbox.Name = "Pin_Normal_Checkbox";
            this.Pin_Normal_Checkbox.Size = new System.Drawing.Size(15, 14);
            this.Pin_Normal_Checkbox.TabIndex = 25;
            this.Pin_Normal_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Pin_Hard_Checkbox
            // 
            this.Pin_Hard_Checkbox.AutoSize = true;
            this.Pin_Hard_Checkbox.Location = new System.Drawing.Point(297, 449);
            this.Pin_Hard_Checkbox.Name = "Pin_Hard_Checkbox";
            this.Pin_Hard_Checkbox.Size = new System.Drawing.Size(15, 14);
            this.Pin_Hard_Checkbox.TabIndex = 26;
            this.Pin_Hard_Checkbox.UseVisualStyleBackColor = true;
            // 
            // Pin_Ultimate_Checkbox
            // 
            this.Pin_Ultimate_Checkbox.AutoSize = true;
            this.Pin_Ultimate_Checkbox.Location = new System.Drawing.Point(437, 449);
            this.Pin_Ultimate_Checkbox.Name = "Pin_Ultimate_Checkbox";
            this.Pin_Ultimate_Checkbox.Size = new System.Drawing.Size(15, 14);
            this.Pin_Ultimate_Checkbox.TabIndex = 27;
            this.Pin_Ultimate_Checkbox.UseVisualStyleBackColor = true;
            // 
            // NoisepediaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1172, 537);
            this.Controls.Add(this.NoiseInfo_GroupBox);
            this.Controls.Add(this.NoiseListGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NoisepediaEditor";
            this.Text = "{NoisepediaEditor}";
            ((System.ComponentModel.ISupportInitialize)(this.NoiseImgPictureBox)).EndInit();
            this.NoiseListGroupBox.ResumeLayout(false);
            this.NoiseListGroupBox.PerformLayout();
            this.NoiseInfo_GroupBox.ResumeLayout(false);
            this.NoiseInfo_GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordLevel_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErasedCount_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Easy_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Normal_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Hard_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinDrop_Ultimate_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox NoiseImgPictureBox;
        private System.Windows.Forms.GroupBox NoiseListGroupBox;
        private System.Windows.Forms.Button UnlockAllButton;
        private System.Windows.Forms.ListView NoisepediaListView;
        private System.Windows.Forms.CheckBox UnlockAll_PinsCheckbox;
        private System.Windows.Forms.ColumnHeader SortedIdHeader;
        private System.Windows.Forms.ColumnHeader NoiseIdHeader;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.GroupBox NoiseInfo_GroupBox;
        private System.Windows.Forms.Label RecordLevel_Label;
        private System.Windows.Forms.RichTextBox NoiseDesc_RichTextBox;
        private System.Windows.Forms.RichTextBox NoiseName_RichTextBox;
        private System.Windows.Forms.CheckBox Pin_Ultimate_Checkbox;
        private System.Windows.Forms.CheckBox Pin_Hard_Checkbox;
        private System.Windows.Forms.CheckBox Pin_Normal_Checkbox;
        private System.Windows.Forms.CheckBox Pin_Easy_Checkbox;
        private System.Windows.Forms.Label Ultimate_DropRateValue_Label;
        private System.Windows.Forms.Label Hard_DropRateValue_Label;
        private System.Windows.Forms.Label Normal_DropRateValue_Label;
        private System.Windows.Forms.Label Easy_DropRateValue_Label;
        private System.Windows.Forms.Label Ultimate_Label;
        private System.Windows.Forms.Label Hard_Label;
        private System.Windows.Forms.Label Normal_Label;
        private System.Windows.Forms.Label Easy_Label;
        private System.Windows.Forms.Label PpValue_Label;
        private System.Windows.Forms.Label Pp_Label;
        private System.Windows.Forms.Label ExpValue_Label;
        private System.Windows.Forms.Label Exp_Label;
        private System.Windows.Forms.Label HpValue_Label;
        private System.Windows.Forms.Label Hp_Label;
        private System.Windows.Forms.PictureBox PinDrop_Ultimate_PictureBox;
        private System.Windows.Forms.PictureBox PinDrop_Hard_PictureBox;
        private System.Windows.Forms.PictureBox PinDrop_Normal_PictureBox;
        private System.Windows.Forms.PictureBox PinDrop_Easy_PictureBox;
        private System.Windows.Forms.CheckBox Encountered_Checkbox;
        private System.Windows.Forms.NumericUpDown ErasedCount_NumUpDown;
        private System.Windows.Forms.Label ErasedCount_Label;
        private System.Windows.Forms.NumericUpDown RecordLevel_NumUpDown;
    }
}