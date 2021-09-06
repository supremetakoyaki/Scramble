
namespace Scramble.Forms
{
    partial class TrophyEditor
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
            this.TrophyWall_GroupBox = new System.Windows.Forms.GroupBox();
            this.TrophyWall_PictureBox = new System.Windows.Forms.PictureBox();
            this.TrophyOverview_GroupBox = new System.Windows.Forms.GroupBox();
            this.ResetPositionAll_Button = new System.Windows.Forms.Button();
            this.UnlockAllTrophies_Button = new System.Windows.Forms.Button();
            this.TrophyListView = new System.Windows.Forms.ListView();
            this.SortIndexHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectedTrophy_Name_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.SelectedTrophy_GroupBox = new System.Windows.Forms.GroupBox();
            this.ExportPng_Button = new System.Windows.Forms.Button();
            this.ShowAsNew_Checkbox = new System.Windows.Forms.CheckBox();
            this.RedrawWall_Button = new System.Windows.Forms.Button();
            this.AutoDrawWall_Checkbox = new System.Windows.Forms.CheckBox();
            this.DeployTrophy_Button = new System.Windows.Forms.Button();
            this.Scale_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Scale_Label = new System.Windows.Forms.Label();
            this.Rotation_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Rotation_Label = new System.Windows.Forms.Label();
            this.YPos_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Y_Label = new System.Windows.Forms.Label();
            this.XPos_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.X_Label = new System.Windows.Forms.Label();
            this.Unseen_Checkbox = new System.Windows.Forms.CheckBox();
            this.Unlocked_Checkbox = new System.Windows.Forms.CheckBox();
            this.SelectedTrophy_Hint_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.Hint_Label = new System.Windows.Forms.Label();
            this.SelectedTrophy_Desc_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.SelectedTrophy_PictureBox = new System.Windows.Forms.PictureBox();
            this.TrophyWall_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrophyWall_PictureBox)).BeginInit();
            this.TrophyOverview_GroupBox.SuspendLayout();
            this.SelectedTrophy_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scale_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotation_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPos_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPos_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedTrophy_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TrophyWall_GroupBox
            // 
            this.TrophyWall_GroupBox.Controls.Add(this.TrophyWall_PictureBox);
            this.TrophyWall_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.TrophyWall_GroupBox.Name = "TrophyWall_GroupBox";
            this.TrophyWall_GroupBox.Size = new System.Drawing.Size(1260, 240);
            this.TrophyWall_GroupBox.TabIndex = 0;
            this.TrophyWall_GroupBox.TabStop = false;
            this.TrophyWall_GroupBox.Text = "{TrophyWall}";
            // 
            // TrophyWall_PictureBox
            // 
            this.TrophyWall_PictureBox.Location = new System.Drawing.Point(6, 22);
            this.TrophyWall_PictureBox.Name = "TrophyWall_PictureBox";
            this.TrophyWall_PictureBox.Size = new System.Drawing.Size(1248, 212);
            this.TrophyWall_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TrophyWall_PictureBox.TabIndex = 0;
            this.TrophyWall_PictureBox.TabStop = false;
            // 
            // TrophyOverview_GroupBox
            // 
            this.TrophyOverview_GroupBox.Controls.Add(this.ResetPositionAll_Button);
            this.TrophyOverview_GroupBox.Controls.Add(this.UnlockAllTrophies_Button);
            this.TrophyOverview_GroupBox.Controls.Add(this.TrophyListView);
            this.TrophyOverview_GroupBox.Location = new System.Drawing.Point(12, 258);
            this.TrophyOverview_GroupBox.Name = "TrophyOverview_GroupBox";
            this.TrophyOverview_GroupBox.Size = new System.Drawing.Size(352, 491);
            this.TrophyOverview_GroupBox.TabIndex = 1;
            this.TrophyOverview_GroupBox.TabStop = false;
            this.TrophyOverview_GroupBox.Text = "{Trophies}";
            // 
            // ResetPositionAll_Button
            // 
            this.ResetPositionAll_Button.Location = new System.Drawing.Point(179, 462);
            this.ResetPositionAll_Button.Name = "ResetPositionAll_Button";
            this.ResetPositionAll_Button.Size = new System.Drawing.Size(167, 23);
            this.ResetPositionAll_Button.TabIndex = 2;
            this.ResetPositionAll_Button.Text = "{ResetPositionAll}";
            this.ResetPositionAll_Button.UseVisualStyleBackColor = true;
            this.ResetPositionAll_Button.Click += new System.EventHandler(this.ResetPositionAll_Button_Click);
            // 
            // UnlockAllTrophies_Button
            // 
            this.UnlockAllTrophies_Button.ForeColor = System.Drawing.Color.DarkBlue;
            this.UnlockAllTrophies_Button.Location = new System.Drawing.Point(6, 462);
            this.UnlockAllTrophies_Button.Name = "UnlockAllTrophies_Button";
            this.UnlockAllTrophies_Button.Size = new System.Drawing.Size(167, 23);
            this.UnlockAllTrophies_Button.TabIndex = 1;
            this.UnlockAllTrophies_Button.Text = "{UnlockAllTrophies}";
            this.UnlockAllTrophies_Button.UseVisualStyleBackColor = true;
            this.UnlockAllTrophies_Button.Click += new System.EventHandler(this.UnlockAllTrophies_Button_Click);
            // 
            // TrophyListView
            // 
            this.TrophyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SortIndexHeader,
            this.IdHeader,
            this.NameHeader});
            this.TrophyListView.FullRowSelect = true;
            this.TrophyListView.HideSelection = false;
            this.TrophyListView.Location = new System.Drawing.Point(6, 22);
            this.TrophyListView.MultiSelect = false;
            this.TrophyListView.Name = "TrophyListView";
            this.TrophyListView.Size = new System.Drawing.Size(340, 434);
            this.TrophyListView.TabIndex = 0;
            this.TrophyListView.UseCompatibleStateImageBehavior = false;
            this.TrophyListView.View = System.Windows.Forms.View.Details;
            this.TrophyListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TrophyListView_ColumnClick);
            this.TrophyListView.SelectedIndexChanged += new System.EventHandler(this.TrophyListView_SelectedIndexChanged);
            // 
            // SortIndexHeader
            // 
            this.SortIndexHeader.Text = "#";
            this.SortIndexHeader.Width = 55;
            // 
            // IdHeader
            // 
            this.IdHeader.Text = "{Id}";
            this.IdHeader.Width = 55;
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "{Name}";
            this.NameHeader.Width = 208;
            // 
            // SelectedTrophy_Name_RichTextBox
            // 
            this.SelectedTrophy_Name_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedTrophy_Name_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedTrophy_Name_RichTextBox.Enabled = false;
            this.SelectedTrophy_Name_RichTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTrophy_Name_RichTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectedTrophy_Name_RichTextBox.Location = new System.Drawing.Point(6, 22);
            this.SelectedTrophy_Name_RichTextBox.Name = "SelectedTrophy_Name_RichTextBox";
            this.SelectedTrophy_Name_RichTextBox.ReadOnly = true;
            this.SelectedTrophy_Name_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.SelectedTrophy_Name_RichTextBox.Size = new System.Drawing.Size(484, 31);
            this.SelectedTrophy_Name_RichTextBox.TabIndex = 3;
            this.SelectedTrophy_Name_RichTextBox.Text = "{No selected trophy}";
            // 
            // SelectedTrophy_GroupBox
            // 
            this.SelectedTrophy_GroupBox.Controls.Add(this.ExportPng_Button);
            this.SelectedTrophy_GroupBox.Controls.Add(this.ShowAsNew_Checkbox);
            this.SelectedTrophy_GroupBox.Controls.Add(this.RedrawWall_Button);
            this.SelectedTrophy_GroupBox.Controls.Add(this.AutoDrawWall_Checkbox);
            this.SelectedTrophy_GroupBox.Controls.Add(this.DeployTrophy_Button);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Scale_NumUpDown);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Scale_Label);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Rotation_NumUpDown);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Rotation_Label);
            this.SelectedTrophy_GroupBox.Controls.Add(this.YPos_NumUpDown);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Y_Label);
            this.SelectedTrophy_GroupBox.Controls.Add(this.XPos_NumUpDown);
            this.SelectedTrophy_GroupBox.Controls.Add(this.X_Label);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Unseen_Checkbox);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Unlocked_Checkbox);
            this.SelectedTrophy_GroupBox.Controls.Add(this.SelectedTrophy_Hint_RichTextBox);
            this.SelectedTrophy_GroupBox.Controls.Add(this.Hint_Label);
            this.SelectedTrophy_GroupBox.Controls.Add(this.SelectedTrophy_Desc_RichTextBox);
            this.SelectedTrophy_GroupBox.Controls.Add(this.SelectedTrophy_PictureBox);
            this.SelectedTrophy_GroupBox.Controls.Add(this.SelectedTrophy_Name_RichTextBox);
            this.SelectedTrophy_GroupBox.Location = new System.Drawing.Point(370, 258);
            this.SelectedTrophy_GroupBox.Name = "SelectedTrophy_GroupBox";
            this.SelectedTrophy_GroupBox.Size = new System.Drawing.Size(902, 491);
            this.SelectedTrophy_GroupBox.TabIndex = 2;
            this.SelectedTrophy_GroupBox.TabStop = false;
            this.SelectedTrophy_GroupBox.Text = "{SelectedTrophy}";
            // 
            // ExportPng_Button
            // 
            this.ExportPng_Button.ForeColor = System.Drawing.Color.MediumBlue;
            this.ExportPng_Button.Location = new System.Drawing.Point(260, 462);
            this.ExportPng_Button.Name = "ExportPng_Button";
            this.ExportPng_Button.Size = new System.Drawing.Size(94, 23);
            this.ExportPng_Button.TabIndex = 23;
            this.ExportPng_Button.Text = "{ExportPng}";
            this.ExportPng_Button.UseVisualStyleBackColor = true;
            this.ExportPng_Button.Click += new System.EventHandler(this.ExportPng_Button_Click);
            // 
            // ShowAsNew_Checkbox
            // 
            this.ShowAsNew_Checkbox.AutoSize = true;
            this.ShowAsNew_Checkbox.Location = new System.Drawing.Point(6, 250);
            this.ShowAsNew_Checkbox.Name = "ShowAsNew_Checkbox";
            this.ShowAsNew_Checkbox.Size = new System.Drawing.Size(108, 19);
            this.ShowAsNew_Checkbox.TabIndex = 22;
            this.ShowAsNew_Checkbox.Text = "Show as \"NEW\"";
            this.ShowAsNew_Checkbox.UseVisualStyleBackColor = true;
            this.ShowAsNew_Checkbox.CheckedChanged += new System.EventHandler(this.ShowAsNew_Checkbox_CheckedChanged);
            // 
            // RedrawWall_Button
            // 
            this.RedrawWall_Button.Location = new System.Drawing.Point(121, 462);
            this.RedrawWall_Button.Name = "RedrawWall_Button";
            this.RedrawWall_Button.Size = new System.Drawing.Size(133, 23);
            this.RedrawWall_Button.TabIndex = 21;
            this.RedrawWall_Button.Text = "{RedrawWall}";
            this.RedrawWall_Button.UseVisualStyleBackColor = true;
            this.RedrawWall_Button.Click += new System.EventHandler(this.RedrawWall_Button_Click);
            // 
            // AutoDrawWall_Checkbox
            // 
            this.AutoDrawWall_Checkbox.AutoSize = true;
            this.AutoDrawWall_Checkbox.Checked = true;
            this.AutoDrawWall_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoDrawWall_Checkbox.Location = new System.Drawing.Point(10, 465);
            this.AutoDrawWall_Checkbox.Name = "AutoDrawWall_Checkbox";
            this.AutoDrawWall_Checkbox.Size = new System.Drawing.Size(87, 19);
            this.AutoDrawWall_Checkbox.TabIndex = 20;
            this.AutoDrawWall_Checkbox.Text = "{AutoDraw}";
            this.AutoDrawWall_Checkbox.UseVisualStyleBackColor = true;
            // 
            // DeployTrophy_Button
            // 
            this.DeployTrophy_Button.ForeColor = System.Drawing.Color.BlueViolet;
            this.DeployTrophy_Button.Location = new System.Drawing.Point(221, 298);
            this.DeployTrophy_Button.Name = "DeployTrophy_Button";
            this.DeployTrophy_Button.Size = new System.Drawing.Size(133, 23);
            this.DeployTrophy_Button.TabIndex = 19;
            this.DeployTrophy_Button.Text = "{Deploy}";
            this.DeployTrophy_Button.UseVisualStyleBackColor = true;
            this.DeployTrophy_Button.Click += new System.EventHandler(this.DeployTrophy_Button_Click);
            // 
            // Scale_NumUpDown
            // 
            this.Scale_NumUpDown.DecimalPlaces = 7;
            this.Scale_NumUpDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Scale_NumUpDown.Location = new System.Drawing.Point(131, 345);
            this.Scale_NumUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Scale_NumUpDown.Minimum = new decimal(new int[] {
            3333334,
            0,
            0,
            458752});
            this.Scale_NumUpDown.Name = "Scale_NumUpDown";
            this.Scale_NumUpDown.Size = new System.Drawing.Size(84, 25);
            this.Scale_NumUpDown.TabIndex = 18;
            this.Scale_NumUpDown.Value = new decimal(new int[] {
            6666667,
            0,
            0,
            458752});
            this.Scale_NumUpDown.ValueChanged += new System.EventHandler(this.Scale_NumUpDown_ValueChanged);
            // 
            // Scale_Label
            // 
            this.Scale_Label.AutoSize = true;
            this.Scale_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scale_Label.ForeColor = System.Drawing.Color.SeaGreen;
            this.Scale_Label.Location = new System.Drawing.Point(3, 346);
            this.Scale_Label.Name = "Scale_Label";
            this.Scale_Label.Size = new System.Drawing.Size(49, 17);
            this.Scale_Label.TabIndex = 17;
            this.Scale_Label.Text = "{Scale:}";
            // 
            // Rotation_NumUpDown
            // 
            this.Rotation_NumUpDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Rotation_NumUpDown.Location = new System.Drawing.Point(131, 376);
            this.Rotation_NumUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Rotation_NumUpDown.Name = "Rotation_NumUpDown";
            this.Rotation_NumUpDown.Size = new System.Drawing.Size(84, 25);
            this.Rotation_NumUpDown.TabIndex = 16;
            this.Rotation_NumUpDown.ValueChanged += new System.EventHandler(this.Rotation_NumUpDown_ValueChanged);
            // 
            // Rotation_Label
            // 
            this.Rotation_Label.AutoSize = true;
            this.Rotation_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rotation_Label.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.Rotation_Label.Location = new System.Drawing.Point(3, 377);
            this.Rotation_Label.Name = "Rotation_Label";
            this.Rotation_Label.Size = new System.Drawing.Size(106, 17);
            this.Rotation_Label.TabIndex = 15;
            this.Rotation_Label.Text = "{RotationAngle:}";
            // 
            // YPos_NumUpDown
            // 
            this.YPos_NumUpDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.YPos_NumUpDown.Location = new System.Drawing.Point(131, 314);
            this.YPos_NumUpDown.Maximum = new decimal(new int[] {
            344,
            0,
            0,
            0});
            this.YPos_NumUpDown.Minimum = new decimal(new int[] {
            344,
            0,
            0,
            -2147483648});
            this.YPos_NumUpDown.Name = "YPos_NumUpDown";
            this.YPos_NumUpDown.Size = new System.Drawing.Size(84, 25);
            this.YPos_NumUpDown.TabIndex = 13;
            this.YPos_NumUpDown.ValueChanged += new System.EventHandler(this.YPos_NumUpDown_ValueChanged);
            // 
            // Y_Label
            // 
            this.Y_Label.AutoSize = true;
            this.Y_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y_Label.Location = new System.Drawing.Point(3, 315);
            this.Y_Label.Name = "Y_Label";
            this.Y_Label.Size = new System.Drawing.Size(27, 17);
            this.Y_Label.TabIndex = 12;
            this.Y_Label.Text = "{Y:}";
            // 
            // XPos_NumUpDown
            // 
            this.XPos_NumUpDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.XPos_NumUpDown.Location = new System.Drawing.Point(131, 283);
            this.XPos_NumUpDown.Maximum = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.XPos_NumUpDown.Minimum = new decimal(new int[] {
            2001,
            0,
            0,
            -2147483648});
            this.XPos_NumUpDown.Name = "XPos_NumUpDown";
            this.XPos_NumUpDown.Size = new System.Drawing.Size(84, 25);
            this.XPos_NumUpDown.TabIndex = 11;
            this.XPos_NumUpDown.ValueChanged += new System.EventHandler(this.XPos_NumUpDown_ValueChanged);
            // 
            // X_Label
            // 
            this.X_Label.AutoSize = true;
            this.X_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_Label.Location = new System.Drawing.Point(3, 284);
            this.X_Label.Name = "X_Label";
            this.X_Label.Size = new System.Drawing.Size(27, 17);
            this.X_Label.TabIndex = 10;
            this.X_Label.Text = "{X:}";
            // 
            // Unseen_Checkbox
            // 
            this.Unseen_Checkbox.AutoSize = true;
            this.Unseen_Checkbox.Location = new System.Drawing.Point(6, 225);
            this.Unseen_Checkbox.Name = "Unseen_Checkbox";
            this.Unseen_Checkbox.Size = new System.Drawing.Size(65, 19);
            this.Unseen_Checkbox.TabIndex = 9;
            this.Unseen_Checkbox.Text = "Unseen";
            this.Unseen_Checkbox.UseVisualStyleBackColor = true;
            this.Unseen_Checkbox.CheckedChanged += new System.EventHandler(this.Unseen_Checkbox_CheckedChanged);
            // 
            // Unlocked_Checkbox
            // 
            this.Unlocked_Checkbox.AutoSize = true;
            this.Unlocked_Checkbox.Location = new System.Drawing.Point(6, 200);
            this.Unlocked_Checkbox.Name = "Unlocked_Checkbox";
            this.Unlocked_Checkbox.Size = new System.Drawing.Size(76, 19);
            this.Unlocked_Checkbox.TabIndex = 8;
            this.Unlocked_Checkbox.Text = "Unlocked";
            this.Unlocked_Checkbox.UseVisualStyleBackColor = true;
            this.Unlocked_Checkbox.CheckedChanged += new System.EventHandler(this.Unlocked_Checkbox_CheckedChanged);
            // 
            // SelectedTrophy_Hint_RichTextBox
            // 
            this.SelectedTrophy_Hint_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedTrophy_Hint_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedTrophy_Hint_RichTextBox.Enabled = false;
            this.SelectedTrophy_Hint_RichTextBox.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.SelectedTrophy_Hint_RichTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectedTrophy_Hint_RichTextBox.Location = new System.Drawing.Point(6, 124);
            this.SelectedTrophy_Hint_RichTextBox.Name = "SelectedTrophy_Hint_RichTextBox";
            this.SelectedTrophy_Hint_RichTextBox.ReadOnly = true;
            this.SelectedTrophy_Hint_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.SelectedTrophy_Hint_RichTextBox.Size = new System.Drawing.Size(352, 46);
            this.SelectedTrophy_Hint_RichTextBox.TabIndex = 7;
            this.SelectedTrophy_Hint_RichTextBox.Text = "Nam vulputate venenatis tortor, at tempor leo aliquet id. Cras eget mi pulvinar.";
            // 
            // Hint_Label
            // 
            this.Hint_Label.AutoSize = true;
            this.Hint_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hint_Label.ForeColor = System.Drawing.Color.Indigo;
            this.Hint_Label.Location = new System.Drawing.Point(3, 104);
            this.Hint_Label.Name = "Hint_Label";
            this.Hint_Label.Size = new System.Drawing.Size(45, 17);
            this.Hint_Label.TabIndex = 6;
            this.Hint_Label.Text = "{Hint:}";
            // 
            // SelectedTrophy_Desc_RichTextBox
            // 
            this.SelectedTrophy_Desc_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedTrophy_Desc_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedTrophy_Desc_RichTextBox.Enabled = false;
            this.SelectedTrophy_Desc_RichTextBox.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.SelectedTrophy_Desc_RichTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectedTrophy_Desc_RichTextBox.Location = new System.Drawing.Point(6, 59);
            this.SelectedTrophy_Desc_RichTextBox.Name = "SelectedTrophy_Desc_RichTextBox";
            this.SelectedTrophy_Desc_RichTextBox.ReadOnly = true;
            this.SelectedTrophy_Desc_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.SelectedTrophy_Desc_RichTextBox.Size = new System.Drawing.Size(352, 42);
            this.SelectedTrophy_Desc_RichTextBox.TabIndex = 5;
            this.SelectedTrophy_Desc_RichTextBox.Text = "Proin sed tellus ut ipsum venenatis bibendum. Fusce venenatis a nunc et euismod. " +
    "Fusce a lacinia risus";
            // 
            // SelectedTrophy_PictureBox
            // 
            this.SelectedTrophy_PictureBox.Location = new System.Drawing.Point(364, 22);
            this.SelectedTrophy_PictureBox.Name = "SelectedTrophy_PictureBox";
            this.SelectedTrophy_PictureBox.Size = new System.Drawing.Size(532, 463);
            this.SelectedTrophy_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SelectedTrophy_PictureBox.TabIndex = 4;
            this.SelectedTrophy_PictureBox.TabStop = false;
            // 
            // TrophyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.SelectedTrophy_GroupBox);
            this.Controls.Add(this.TrophyOverview_GroupBox);
            this.Controls.Add(this.TrophyWall_GroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TrophyEditor";
            this.Text = "TrophyEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrophyEditor_FormClosing);
            this.TrophyWall_GroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrophyWall_PictureBox)).EndInit();
            this.TrophyOverview_GroupBox.ResumeLayout(false);
            this.SelectedTrophy_GroupBox.ResumeLayout(false);
            this.SelectedTrophy_GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scale_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotation_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPos_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPos_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedTrophy_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox TrophyWall_GroupBox;
        private System.Windows.Forms.GroupBox TrophyOverview_GroupBox;
        private System.Windows.Forms.Button ResetPositionAll_Button;
        private System.Windows.Forms.Button UnlockAllTrophies_Button;
        private System.Windows.Forms.ListView TrophyListView;
        private System.Windows.Forms.ColumnHeader SortIndexHeader;
        private System.Windows.Forms.ColumnHeader IdHeader;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.RichTextBox SelectedTrophy_Name_RichTextBox;
        private System.Windows.Forms.GroupBox SelectedTrophy_GroupBox;
        private System.Windows.Forms.RichTextBox SelectedTrophy_Hint_RichTextBox;
        private System.Windows.Forms.Label Hint_Label;
        private System.Windows.Forms.RichTextBox SelectedTrophy_Desc_RichTextBox;
        private System.Windows.Forms.PictureBox SelectedTrophy_PictureBox;
        private System.Windows.Forms.Label X_Label;
        private System.Windows.Forms.CheckBox Unseen_Checkbox;
        private System.Windows.Forms.CheckBox Unlocked_Checkbox;
        private System.Windows.Forms.NumericUpDown Rotation_NumUpDown;
        private System.Windows.Forms.Label Rotation_Label;
        private System.Windows.Forms.NumericUpDown YPos_NumUpDown;
        private System.Windows.Forms.Label Y_Label;
        private System.Windows.Forms.NumericUpDown XPos_NumUpDown;
        private System.Windows.Forms.NumericUpDown Scale_NumUpDown;
        private System.Windows.Forms.Label Scale_Label;
        private System.Windows.Forms.Button DeployTrophy_Button;
        private System.Windows.Forms.PictureBox TrophyWall_PictureBox;
        private System.Windows.Forms.Button RedrawWall_Button;
        private System.Windows.Forms.CheckBox AutoDrawWall_Checkbox;
        private System.Windows.Forms.CheckBox ShowAsNew_Checkbox;
        private System.Windows.Forms.Button ExportPng_Button;
    }
}