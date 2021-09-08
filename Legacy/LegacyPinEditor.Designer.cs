
namespace Scramble.Legacy
{
    partial class LegacyPinEditor
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
            this.PinList_GroupBox = new System.Windows.Forms.GroupBox();
            this.Pin_Inventory_Label = new System.Windows.Forms.Label();
            this.ClearMastered_Button = new System.Windows.Forms.Button();
            this.ClearStockpile_Button = new System.Windows.Forms.Button();
            this.Amount_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Amount_Label = new System.Windows.Forms.Label();
            this.RemovePin_Button = new System.Windows.Forms.Button();
            this.Experience_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Experience_Label = new System.Windows.Forms.Label();
            this.SendToOtherInv_Button = new System.Windows.Forms.Button();
            this.Level_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Level_Label = new System.Windows.Forms.Label();
            this.DividerHorizontal_Label = new System.Windows.Forms.Label();
            this.SelectedPin_Desc_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.SelectedPin_Name_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.SelectedPin_PictureBox = new System.Windows.Forms.PictureBox();
            this.Mastered_ListView = new System.Windows.Forms.ListView();
            this.Mastered_PinNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mastered_PinIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mastered_PinAmountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stockpile_ListView = new System.Windows.Forms.ListView();
            this.PinNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PinIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PinLevelHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mastered_Label = new System.Windows.Forms.Label();
            this.Stockpile_Label = new System.Windows.Forms.Label();
            this.AllPins_GroupBox = new System.Windows.Forms.GroupBox();
            this.InfoMastered_Label = new System.Windows.Forms.Label();
            this.Add99ToMastered_Checkbox = new System.Windows.Forms.CheckBox();
            this.EachPin_Checkbox = new System.Windows.Forms.CheckBox();
            this.AddPinToMastered_Button = new System.Windows.Forms.Button();
            this.AddPinToStockpile_Button = new System.Windows.Forms.Button();
            this.AllPins_ListView = new System.Windows.Forms.ListView();
            this.AllPins_NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AllPins_IdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PinList_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Experience_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Level_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedPin_PictureBox)).BeginInit();
            this.AllPins_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PinList_GroupBox
            // 
            this.PinList_GroupBox.Controls.Add(this.Pin_Inventory_Label);
            this.PinList_GroupBox.Controls.Add(this.ClearMastered_Button);
            this.PinList_GroupBox.Controls.Add(this.ClearStockpile_Button);
            this.PinList_GroupBox.Controls.Add(this.Amount_NumUpDown);
            this.PinList_GroupBox.Controls.Add(this.Amount_Label);
            this.PinList_GroupBox.Controls.Add(this.RemovePin_Button);
            this.PinList_GroupBox.Controls.Add(this.Experience_NumUpDown);
            this.PinList_GroupBox.Controls.Add(this.Experience_Label);
            this.PinList_GroupBox.Controls.Add(this.SendToOtherInv_Button);
            this.PinList_GroupBox.Controls.Add(this.Level_NumUpDown);
            this.PinList_GroupBox.Controls.Add(this.Level_Label);
            this.PinList_GroupBox.Controls.Add(this.DividerHorizontal_Label);
            this.PinList_GroupBox.Controls.Add(this.SelectedPin_Desc_RichTextBox);
            this.PinList_GroupBox.Controls.Add(this.SelectedPin_Name_RichTextBox);
            this.PinList_GroupBox.Controls.Add(this.SelectedPin_PictureBox);
            this.PinList_GroupBox.Controls.Add(this.Mastered_ListView);
            this.PinList_GroupBox.Controls.Add(this.Stockpile_ListView);
            this.PinList_GroupBox.Controls.Add(this.Mastered_Label);
            this.PinList_GroupBox.Controls.Add(this.Stockpile_Label);
            this.PinList_GroupBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PinList_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.PinList_GroupBox.Name = "PinList_GroupBox";
            this.PinList_GroupBox.Size = new System.Drawing.Size(589, 577);
            this.PinList_GroupBox.TabIndex = 0;
            this.PinList_GroupBox.TabStop = false;
            this.PinList_GroupBox.Text = "Your Pin Inventory";
            // 
            // Pin_Inventory_Label
            // 
            this.Pin_Inventory_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Pin_Inventory_Label.Location = new System.Drawing.Point(6, 483);
            this.Pin_Inventory_Label.Name = "Pin_Inventory_Label";
            this.Pin_Inventory_Label.Size = new System.Drawing.Size(80, 19);
            this.Pin_Inventory_Label.TabIndex = 3;
            this.Pin_Inventory_Label.Text = "—";
            this.Pin_Inventory_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClearMastered_Button
            // 
            this.ClearMastered_Button.BackColor = System.Drawing.Color.Gainsboro;
            this.ClearMastered_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClearMastered_Button.ForeColor = System.Drawing.Color.Indigo;
            this.ClearMastered_Button.Location = new System.Drawing.Point(172, 533);
            this.ClearMastered_Button.Name = "ClearMastered_Button";
            this.ClearMastered_Button.Size = new System.Drawing.Size(160, 38);
            this.ClearMastered_Button.TabIndex = 17;
            this.ClearMastered_Button.Text = "Clear entire mastered";
            this.ClearMastered_Button.UseVisualStyleBackColor = false;
            this.ClearMastered_Button.Click += new System.EventHandler(this.ClearMastered_Button_Click);
            // 
            // ClearStockpile_Button
            // 
            this.ClearStockpile_Button.BackColor = System.Drawing.Color.Gainsboro;
            this.ClearStockpile_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClearStockpile_Button.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ClearStockpile_Button.Location = new System.Drawing.Point(6, 533);
            this.ClearStockpile_Button.Name = "ClearStockpile_Button";
            this.ClearStockpile_Button.Size = new System.Drawing.Size(160, 38);
            this.ClearStockpile_Button.TabIndex = 16;
            this.ClearStockpile_Button.Text = "Clear entire stockpile";
            this.ClearStockpile_Button.UseVisualStyleBackColor = false;
            this.ClearStockpile_Button.Click += new System.EventHandler(this.ClearStockpile_Button_Click);
            // 
            // Amount_NumUpDown
            // 
            this.Amount_NumUpDown.Enabled = false;
            this.Amount_NumUpDown.Location = new System.Drawing.Point(479, 467);
            this.Amount_NumUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.Amount_NumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Amount_NumUpDown.Name = "Amount_NumUpDown";
            this.Amount_NumUpDown.Size = new System.Drawing.Size(82, 23);
            this.Amount_NumUpDown.TabIndex = 15;
            this.Amount_NumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Amount_NumUpDown.ValueChanged += new System.EventHandler(this.Amount_NupUpDown_ValueChanged);
            // 
            // Amount_Label
            // 
            this.Amount_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Amount_Label.Location = new System.Drawing.Point(398, 469);
            this.Amount_Label.Name = "Amount_Label";
            this.Amount_Label.Size = new System.Drawing.Size(75, 15);
            this.Amount_Label.TabIndex = 14;
            this.Amount_Label.Text = "Amount:";
            // 
            // RemovePin_Button
            // 
            this.RemovePin_Button.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RemovePin_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RemovePin_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RemovePin_Button.Location = new System.Drawing.Point(506, 499);
            this.RemovePin_Button.Name = "RemovePin_Button";
            this.RemovePin_Button.Size = new System.Drawing.Size(77, 23);
            this.RemovePin_Button.TabIndex = 13;
            this.RemovePin_Button.Text = "Remove";
            this.RemovePin_Button.UseVisualStyleBackColor = false;
            this.RemovePin_Button.Click += new System.EventHandler(this.RemovePin_Button_Click);
            // 
            // Experience_NumUpDown
            // 
            this.Experience_NumUpDown.Location = new System.Drawing.Point(479, 438);
            this.Experience_NumUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Experience_NumUpDown.Name = "Experience_NumUpDown";
            this.Experience_NumUpDown.Size = new System.Drawing.Size(82, 23);
            this.Experience_NumUpDown.TabIndex = 12;
            this.Experience_NumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Experience_NumUpDown.ValueChanged += new System.EventHandler(this.Experience_NumUpDown_ValueChanged);
            // 
            // Experience_Label
            // 
            this.Experience_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Experience_Label.Location = new System.Drawing.Point(398, 440);
            this.Experience_Label.Name = "Experience_Label";
            this.Experience_Label.Size = new System.Drawing.Size(75, 15);
            this.Experience_Label.TabIndex = 11;
            this.Experience_Label.Text = "Experience:";
            // 
            // SendToOtherInv_Button
            // 
            this.SendToOtherInv_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SendToOtherInv_Button.ForeColor = System.Drawing.Color.BlueViolet;
            this.SendToOtherInv_Button.Location = new System.Drawing.Point(379, 499);
            this.SendToOtherInv_Button.Name = "SendToOtherInv_Button";
            this.SendToOtherInv_Button.Size = new System.Drawing.Size(121, 23);
            this.SendToOtherInv_Button.TabIndex = 10;
            this.SendToOtherInv_Button.Text = "Send to stockpile";
            this.SendToOtherInv_Button.UseVisualStyleBackColor = true;
            this.SendToOtherInv_Button.Click += new System.EventHandler(this.SendToOtherInv_Button_Click);
            // 
            // Level_NumUpDown
            // 
            this.Level_NumUpDown.Location = new System.Drawing.Point(479, 409);
            this.Level_NumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Level_NumUpDown.Name = "Level_NumUpDown";
            this.Level_NumUpDown.Size = new System.Drawing.Size(82, 23);
            this.Level_NumUpDown.TabIndex = 9;
            this.Level_NumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Level_NumUpDown.ValueChanged += new System.EventHandler(this.Level_NumUpDown_ValueChanged);
            // 
            // Level_Label
            // 
            this.Level_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Level_Label.Location = new System.Drawing.Point(398, 411);
            this.Level_Label.Name = "Level_Label";
            this.Level_Label.Size = new System.Drawing.Size(75, 15);
            this.Level_Label.TabIndex = 8;
            this.Level_Label.Text = "Level:";
            // 
            // DividerHorizontal_Label
            // 
            this.DividerHorizontal_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DividerHorizontal_Label.Location = new System.Drawing.Point(6, 528);
            this.DividerHorizontal_Label.Name = "DividerHorizontal_Label";
            this.DividerHorizontal_Label.Size = new System.Drawing.Size(574, 2);
            this.DividerHorizontal_Label.TabIndex = 7;
            // 
            // SelectedPin_Desc_RichTextBox
            // 
            this.SelectedPin_Desc_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedPin_Desc_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedPin_Desc_RichTextBox.Enabled = false;
            this.SelectedPin_Desc_RichTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SelectedPin_Desc_RichTextBox.Location = new System.Drawing.Point(92, 426);
            this.SelectedPin_Desc_RichTextBox.Name = "SelectedPin_Desc_RichTextBox";
            this.SelectedPin_Desc_RichTextBox.Size = new System.Drawing.Size(282, 96);
            this.SelectedPin_Desc_RichTextBox.TabIndex = 6;
            this.SelectedPin_Desc_RichTextBox.Text = "Lorem ipsum";
            // 
            // SelectedPin_Name_RichTextBox
            // 
            this.SelectedPin_Name_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedPin_Name_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedPin_Name_RichTextBox.Enabled = false;
            this.SelectedPin_Name_RichTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.SelectedPin_Name_RichTextBox.Location = new System.Drawing.Point(92, 400);
            this.SelectedPin_Name_RichTextBox.Name = "SelectedPin_Name_RichTextBox";
            this.SelectedPin_Name_RichTextBox.Size = new System.Drawing.Size(282, 20);
            this.SelectedPin_Name_RichTextBox.TabIndex = 5;
            this.SelectedPin_Name_RichTextBox.Text = "(No selected pin)";
            // 
            // SelectedPin_PictureBox
            // 
            this.SelectedPin_PictureBox.Location = new System.Drawing.Point(6, 400);
            this.SelectedPin_PictureBox.Name = "SelectedPin_PictureBox";
            this.SelectedPin_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.SelectedPin_PictureBox.TabIndex = 4;
            this.SelectedPin_PictureBox.TabStop = false;
            // 
            // Mastered_ListView
            // 
            this.Mastered_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Mastered_PinNameHeader,
            this.Mastered_PinIdHeader,
            this.Mastered_PinAmountHeader});
            this.Mastered_ListView.FullRowSelect = true;
            this.Mastered_ListView.HideSelection = false;
            this.Mastered_ListView.Location = new System.Drawing.Point(298, 49);
            this.Mastered_ListView.MultiSelect = false;
            this.Mastered_ListView.Name = "Mastered_ListView";
            this.Mastered_ListView.Size = new System.Drawing.Size(285, 340);
            this.Mastered_ListView.TabIndex = 3;
            this.Mastered_ListView.UseCompatibleStateImageBehavior = false;
            this.Mastered_ListView.View = System.Windows.Forms.View.Details;
            this.Mastered_ListView.SelectedIndexChanged += new System.EventHandler(this.Mastered_ListView_SelectedIndexChanged);
            // 
            // Mastered_PinNameHeader
            // 
            this.Mastered_PinNameHeader.DisplayIndex = 1;
            this.Mastered_PinNameHeader.Text = "Name";
            this.Mastered_PinNameHeader.Width = 165;
            // 
            // Mastered_PinIdHeader
            // 
            this.Mastered_PinIdHeader.DisplayIndex = 0;
            this.Mastered_PinIdHeader.Text = "ID";
            this.Mastered_PinIdHeader.Width = 39;
            // 
            // Mastered_PinAmountHeader
            // 
            this.Mastered_PinAmountHeader.Text = "Amount";
            // 
            // Stockpile_ListView
            // 
            this.Stockpile_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PinNameHeader,
            this.PinIdHeader,
            this.PinLevelHeader});
            this.Stockpile_ListView.FullRowSelect = true;
            this.Stockpile_ListView.HideSelection = false;
            this.Stockpile_ListView.Location = new System.Drawing.Point(6, 49);
            this.Stockpile_ListView.MultiSelect = false;
            this.Stockpile_ListView.Name = "Stockpile_ListView";
            this.Stockpile_ListView.Size = new System.Drawing.Size(286, 340);
            this.Stockpile_ListView.TabIndex = 2;
            this.Stockpile_ListView.UseCompatibleStateImageBehavior = false;
            this.Stockpile_ListView.View = System.Windows.Forms.View.Details;
            this.Stockpile_ListView.SelectedIndexChanged += new System.EventHandler(this.Stockpile_ListView_SelectedIndexChanged);
            // 
            // PinNameHeader
            // 
            this.PinNameHeader.DisplayIndex = 1;
            this.PinNameHeader.Text = "Name";
            this.PinNameHeader.Width = 165;
            // 
            // PinIdHeader
            // 
            this.PinIdHeader.DisplayIndex = 0;
            this.PinIdHeader.Text = "ID";
            this.PinIdHeader.Width = 40;
            // 
            // PinLevelHeader
            // 
            this.PinLevelHeader.Text = "Level";
            // 
            // Mastered_Label
            // 
            this.Mastered_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Mastered_Label.ForeColor = System.Drawing.Color.BlueViolet;
            this.Mastered_Label.Location = new System.Drawing.Point(295, 19);
            this.Mastered_Label.Name = "Mastered_Label";
            this.Mastered_Label.Size = new System.Drawing.Size(288, 27);
            this.Mastered_Label.TabIndex = 1;
            this.Mastered_Label.Text = "MASTERED";
            this.Mastered_Label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Stockpile_Label
            // 
            this.Stockpile_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Stockpile_Label.ForeColor = System.Drawing.Color.Teal;
            this.Stockpile_Label.Location = new System.Drawing.Point(6, 19);
            this.Stockpile_Label.Name = "Stockpile_Label";
            this.Stockpile_Label.Size = new System.Drawing.Size(288, 27);
            this.Stockpile_Label.TabIndex = 0;
            this.Stockpile_Label.Text = "STOCKPILE";
            this.Stockpile_Label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // AllPins_GroupBox
            // 
            this.AllPins_GroupBox.Controls.Add(this.InfoMastered_Label);
            this.AllPins_GroupBox.Controls.Add(this.Add99ToMastered_Checkbox);
            this.AllPins_GroupBox.Controls.Add(this.EachPin_Checkbox);
            this.AllPins_GroupBox.Controls.Add(this.AddPinToMastered_Button);
            this.AllPins_GroupBox.Controls.Add(this.AddPinToStockpile_Button);
            this.AllPins_GroupBox.Controls.Add(this.AllPins_ListView);
            this.AllPins_GroupBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AllPins_GroupBox.Location = new System.Drawing.Point(607, 12);
            this.AllPins_GroupBox.Name = "AllPins_GroupBox";
            this.AllPins_GroupBox.Size = new System.Drawing.Size(305, 577);
            this.AllPins_GroupBox.TabIndex = 1;
            this.AllPins_GroupBox.TabStop = false;
            this.AllPins_GroupBox.Text = "All Pins";
            // 
            // InfoMastered_Label
            // 
            this.InfoMastered_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.InfoMastered_Label.Location = new System.Drawing.Point(9, 486);
            this.InfoMastered_Label.Name = "InfoMastered_Label";
            this.InfoMastered_Label.Size = new System.Drawing.Size(143, 39);
            this.InfoMastered_Label.TabIndex = 5;
            this.InfoMastered_Label.Text = "The following only apply to mastered inventory:";
            // 
            // Add99ToMastered_Checkbox
            // 
            this.Add99ToMastered_Checkbox.AutoSize = true;
            this.Add99ToMastered_Checkbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Add99ToMastered_Checkbox.Location = new System.Drawing.Point(158, 504);
            this.Add99ToMastered_Checkbox.Name = "Add99ToMastered_Checkbox";
            this.Add99ToMastered_Checkbox.Size = new System.Drawing.Size(44, 19);
            this.Add99ToMastered_Checkbox.TabIndex = 4;
            this.Add99ToMastered_Checkbox.Text = "x99";
            this.Add99ToMastered_Checkbox.UseVisualStyleBackColor = true;
            // 
            // EachPin_Checkbox
            // 
            this.EachPin_Checkbox.AutoSize = true;
            this.EachPin_Checkbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EachPin_Checkbox.Location = new System.Drawing.Point(158, 483);
            this.EachPin_Checkbox.Name = "EachPin_Checkbox";
            this.EachPin_Checkbox.Size = new System.Drawing.Size(133, 19);
            this.EachPin_Checkbox.TabIndex = 3;
            this.EachPin_Checkbox.Text = "Add one of each pin";
            this.EachPin_Checkbox.UseVisualStyleBackColor = true;
            // 
            // AddPinToMastered_Button
            // 
            this.AddPinToMastered_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddPinToMastered_Button.ForeColor = System.Drawing.Color.BlueViolet;
            this.AddPinToMastered_Button.Location = new System.Drawing.Point(155, 528);
            this.AddPinToMastered_Button.Name = "AddPinToMastered_Button";
            this.AddPinToMastered_Button.Size = new System.Drawing.Size(144, 43);
            this.AddPinToMastered_Button.TabIndex = 2;
            this.AddPinToMastered_Button.Text = "Add pin to mastered";
            this.AddPinToMastered_Button.UseVisualStyleBackColor = true;
            this.AddPinToMastered_Button.Click += new System.EventHandler(this.AddPinToMastered_Button_Click);
            // 
            // AddPinToStockpile_Button
            // 
            this.AddPinToStockpile_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddPinToStockpile_Button.ForeColor = System.Drawing.Color.Teal;
            this.AddPinToStockpile_Button.Location = new System.Drawing.Point(6, 528);
            this.AddPinToStockpile_Button.Name = "AddPinToStockpile_Button";
            this.AddPinToStockpile_Button.Size = new System.Drawing.Size(143, 43);
            this.AddPinToStockpile_Button.TabIndex = 1;
            this.AddPinToStockpile_Button.Text = "Add pin to stockpile";
            this.AddPinToStockpile_Button.UseVisualStyleBackColor = true;
            this.AddPinToStockpile_Button.Click += new System.EventHandler(this.AddPinToStockpile_Button_Click);
            // 
            // AllPins_ListView
            // 
            this.AllPins_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AllPins_NameHeader,
            this.AllPins_IdHeader});
            this.AllPins_ListView.FullRowSelect = true;
            this.AllPins_ListView.HideSelection = false;
            this.AllPins_ListView.Location = new System.Drawing.Point(6, 22);
            this.AllPins_ListView.MultiSelect = false;
            this.AllPins_ListView.Name = "AllPins_ListView";
            this.AllPins_ListView.Size = new System.Drawing.Size(293, 455);
            this.AllPins_ListView.TabIndex = 0;
            this.AllPins_ListView.UseCompatibleStateImageBehavior = false;
            this.AllPins_ListView.View = System.Windows.Forms.View.Details;
            // 
            // AllPins_NameHeader
            // 
            this.AllPins_NameHeader.DisplayIndex = 1;
            this.AllPins_NameHeader.Text = "Name";
            this.AllPins_NameHeader.Width = 225;
            // 
            // AllPins_IdHeader
            // 
            this.AllPins_IdHeader.DisplayIndex = 0;
            this.AllPins_IdHeader.Text = "ID";
            this.AllPins_IdHeader.Width = 45;
            // 
            // LegacyPinEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(924, 601);
            this.Controls.Add(this.AllPins_GroupBox);
            this.Controls.Add(this.PinList_GroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LegacyPinEditor";
            this.Text = "Pin Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LegacyPinEditor_FormClosing);
            this.PinList_GroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Amount_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Experience_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Level_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedPin_PictureBox)).EndInit();
            this.AllPins_GroupBox.ResumeLayout(false);
            this.AllPins_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PinList_GroupBox;
        private System.Windows.Forms.ListView Mastered_ListView;
        private System.Windows.Forms.ColumnHeader Mastered_PinNameHeader;
        private System.Windows.Forms.ColumnHeader Mastered_PinIdHeader;
        private System.Windows.Forms.ColumnHeader Mastered_PinAmountHeader;
        private System.Windows.Forms.ListView Stockpile_ListView;
        private System.Windows.Forms.ColumnHeader PinNameHeader;
        private System.Windows.Forms.ColumnHeader PinIdHeader;
        private System.Windows.Forms.ColumnHeader PinLevelHeader;
        private System.Windows.Forms.Label Mastered_Label;
        private System.Windows.Forms.Label Stockpile_Label;
        private System.Windows.Forms.GroupBox AllPins_GroupBox;
        private System.Windows.Forms.Button AddPinToStockpile_Button;
        private System.Windows.Forms.ListView AllPins_ListView;
        private System.Windows.Forms.ColumnHeader AllPins_NameHeader;
        private System.Windows.Forms.ColumnHeader AllPins_IdHeader;
        private System.Windows.Forms.PictureBox SelectedPin_PictureBox;
        private System.Windows.Forms.RichTextBox SelectedPin_Desc_RichTextBox;
        private System.Windows.Forms.RichTextBox SelectedPin_Name_RichTextBox;
        private System.Windows.Forms.Label Level_Label;
        private System.Windows.Forms.Label DividerHorizontal_Label;
        private System.Windows.Forms.Button SendToOtherInv_Button;
        private System.Windows.Forms.NumericUpDown Level_NumUpDown;
        private System.Windows.Forms.Label Amount_Label;
        private System.Windows.Forms.Button RemovePin_Button;
        private System.Windows.Forms.NumericUpDown Experience_NumUpDown;
        private System.Windows.Forms.Label Experience_Label;
        private System.Windows.Forms.Button AddPinToMastered_Button;
        private System.Windows.Forms.Button ClearMastered_Button;
        private System.Windows.Forms.Button ClearStockpile_Button;
        private System.Windows.Forms.NumericUpDown Amount_NumUpDown;
        private System.Windows.Forms.Label Pin_Inventory_Label;
        private System.Windows.Forms.CheckBox Add99ToMastered_Checkbox;
        private System.Windows.Forms.CheckBox EachPin_Checkbox;
        private System.Windows.Forms.Label InfoMastered_Label;
    }
}