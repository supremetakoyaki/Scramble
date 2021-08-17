
namespace Scramble.Forms
{
    partial class TurfWarEditor
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
            this.HighScore_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.CurrentScore_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.CurrentScore_Label = new System.Windows.Forms.Label();
            this.HighScore_Label = new System.Windows.Forms.Label();
            this.PointsIcon_PictureBox = new System.Windows.Forms.PictureBox();
            this.TurfWars_GroupBox = new System.Windows.Forms.GroupBox();
            this.MaxPrizes_AllScrambles_Checkbox = new System.Windows.Forms.CheckBox();
            this.MaxPrizes_Button = new System.Windows.Forms.Button();
            this.TurfWarPlacement_ComboBox = new System.Windows.Forms.ComboBox();
            this.Prizes_Label = new System.Windows.Forms.Label();
            this.TurfWar_ListView = new System.Windows.Forms.ListView();
            this.TurfWarNameHeader = new System.Windows.Forms.ColumnHeader();
            this.Points_GroupBox = new System.Windows.Forms.GroupBox();
            this.MaxCurrentPoints_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HighScore_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentScore_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointsIcon_PictureBox)).BeginInit();
            this.TurfWars_GroupBox.SuspendLayout();
            this.Points_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // HighScore_NumUpDown
            // 
            this.HighScore_NumUpDown.Location = new System.Drawing.Point(300, 32);
            this.HighScore_NumUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.HighScore_NumUpDown.Name = "HighScore_NumUpDown";
            this.HighScore_NumUpDown.Size = new System.Drawing.Size(124, 23);
            this.HighScore_NumUpDown.TabIndex = 4;
            this.HighScore_NumUpDown.ValueChanged += new System.EventHandler(this.HighScore_NumUpDown_ValueChanged);
            // 
            // CurrentScore_NumUpDown
            // 
            this.CurrentScore_NumUpDown.Location = new System.Drawing.Point(193, 35);
            this.CurrentScore_NumUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.CurrentScore_NumUpDown.Name = "CurrentScore_NumUpDown";
            this.CurrentScore_NumUpDown.Size = new System.Drawing.Size(85, 23);
            this.CurrentScore_NumUpDown.TabIndex = 3;
            this.CurrentScore_NumUpDown.ValueChanged += new System.EventHandler(this.CurrentScore_NumUpDown_ValueChanged);
            // 
            // CurrentScore_Label
            // 
            this.CurrentScore_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CurrentScore_Label.Location = new System.Drawing.Point(72, 35);
            this.CurrentScore_Label.Name = "CurrentScore_Label";
            this.CurrentScore_Label.Size = new System.Drawing.Size(115, 23);
            this.CurrentScore_Label.TabIndex = 2;
            this.CurrentScore_Label.Text = "{CurrentScore:}";
            // 
            // HighScore_Label
            // 
            this.HighScore_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HighScore_Label.Location = new System.Drawing.Point(194, 32);
            this.HighScore_Label.Name = "HighScore_Label";
            this.HighScore_Label.Size = new System.Drawing.Size(100, 19);
            this.HighScore_Label.TabIndex = 1;
            this.HighScore_Label.Text = "{HighScore:}";
            // 
            // PointsIcon_PictureBox
            // 
            this.PointsIcon_PictureBox.Location = new System.Drawing.Point(6, 22);
            this.PointsIcon_PictureBox.Name = "PointsIcon_PictureBox";
            this.PointsIcon_PictureBox.Size = new System.Drawing.Size(50, 50);
            this.PointsIcon_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PointsIcon_PictureBox.TabIndex = 1;
            this.PointsIcon_PictureBox.TabStop = false;
            // 
            // TurfWars_GroupBox
            // 
            this.TurfWars_GroupBox.Controls.Add(this.MaxPrizes_AllScrambles_Checkbox);
            this.TurfWars_GroupBox.Controls.Add(this.MaxPrizes_Button);
            this.TurfWars_GroupBox.Controls.Add(this.TurfWarPlacement_ComboBox);
            this.TurfWars_GroupBox.Controls.Add(this.HighScore_Label);
            this.TurfWars_GroupBox.Controls.Add(this.Prizes_Label);
            this.TurfWars_GroupBox.Controls.Add(this.HighScore_NumUpDown);
            this.TurfWars_GroupBox.Controls.Add(this.TurfWar_ListView);
            this.TurfWars_GroupBox.Location = new System.Drawing.Point(12, 101);
            this.TurfWars_GroupBox.Name = "TurfWars_GroupBox";
            this.TurfWars_GroupBox.Size = new System.Drawing.Size(430, 148);
            this.TurfWars_GroupBox.TabIndex = 1;
            this.TurfWars_GroupBox.TabStop = false;
            this.TurfWars_GroupBox.Text = "{TurfWars}";
            // 
            // MaxPrizes_AllScrambles_Checkbox
            // 
            this.MaxPrizes_AllScrambles_Checkbox.AutoSize = true;
            this.MaxPrizes_AllScrambles_Checkbox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaxPrizes_AllScrambles_Checkbox.Location = new System.Drawing.Point(324, 123);
            this.MaxPrizes_AllScrambles_Checkbox.Name = "MaxPrizes_AllScrambles_Checkbox";
            this.MaxPrizes_AllScrambles_Checkbox.Size = new System.Drawing.Size(96, 17);
            this.MaxPrizes_AllScrambles_Checkbox.TabIndex = 7;
            this.MaxPrizes_AllScrambles_Checkbox.Text = "{AllScrambles}";
            this.MaxPrizes_AllScrambles_Checkbox.UseVisualStyleBackColor = true;
            // 
            // MaxPrizes_Button
            // 
            this.MaxPrizes_Button.BackColor = System.Drawing.Color.Ivory;
            this.MaxPrizes_Button.Location = new System.Drawing.Point(194, 119);
            this.MaxPrizes_Button.Name = "MaxPrizes_Button";
            this.MaxPrizes_Button.Size = new System.Drawing.Size(124, 23);
            this.MaxPrizes_Button.TabIndex = 5;
            this.MaxPrizes_Button.Text = "{MaxPrizes}";
            this.MaxPrizes_Button.UseVisualStyleBackColor = false;
            this.MaxPrizes_Button.Click += new System.EventHandler(this.MaxPrizes_Button_Click);
            // 
            // TurfWarPlacement_ComboBox
            // 
            this.TurfWarPlacement_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TurfWarPlacement_ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TurfWarPlacement_ComboBox.FormattingEnabled = true;
            this.TurfWarPlacement_ComboBox.Location = new System.Drawing.Point(300, 77);
            this.TurfWarPlacement_ComboBox.Name = "TurfWarPlacement_ComboBox";
            this.TurfWarPlacement_ComboBox.Size = new System.Drawing.Size(124, 21);
            this.TurfWarPlacement_ComboBox.TabIndex = 6;
            this.TurfWarPlacement_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TurfWarPlacement_ComboBox_SelectedIndexChanged);
            // 
            // Prizes_Label
            // 
            this.Prizes_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Prizes_Label.Location = new System.Drawing.Point(194, 77);
            this.Prizes_Label.Name = "Prizes_Label";
            this.Prizes_Label.Size = new System.Drawing.Size(100, 19);
            this.Prizes_Label.TabIndex = 5;
            this.Prizes_Label.Text = "{Prizes:}";
            // 
            // TurfWar_ListView
            // 
            this.TurfWar_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TurfWarNameHeader});
            this.TurfWar_ListView.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TurfWar_ListView.FullRowSelect = true;
            this.TurfWar_ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TurfWar_ListView.HideSelection = false;
            this.TurfWar_ListView.Location = new System.Drawing.Point(6, 22);
            this.TurfWar_ListView.MultiSelect = false;
            this.TurfWar_ListView.Name = "TurfWar_ListView";
            this.TurfWar_ListView.Size = new System.Drawing.Size(180, 120);
            this.TurfWar_ListView.TabIndex = 0;
            this.TurfWar_ListView.UseCompatibleStateImageBehavior = false;
            this.TurfWar_ListView.View = System.Windows.Forms.View.Details;
            this.TurfWar_ListView.SelectedIndexChanged += new System.EventHandler(this.TurfWar_ListView_SelectedIndexChanged);
            // 
            // TurfWarNameHeader
            // 
            this.TurfWarNameHeader.Text = "{Name}";
            this.TurfWarNameHeader.Width = 160;
            // 
            // Points_GroupBox
            // 
            this.Points_GroupBox.Controls.Add(this.MaxCurrentPoints_Button);
            this.Points_GroupBox.Controls.Add(this.CurrentScore_NumUpDown);
            this.Points_GroupBox.Controls.Add(this.PointsIcon_PictureBox);
            this.Points_GroupBox.Controls.Add(this.CurrentScore_Label);
            this.Points_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.Points_GroupBox.Name = "Points_GroupBox";
            this.Points_GroupBox.Size = new System.Drawing.Size(430, 83);
            this.Points_GroupBox.TabIndex = 0;
            this.Points_GroupBox.TabStop = false;
            this.Points_GroupBox.Text = "{Points}";
            // 
            // MaxCurrentPoints_Button
            // 
            this.MaxCurrentPoints_Button.BackColor = System.Drawing.Color.Ivory;
            this.MaxCurrentPoints_Button.Location = new System.Drawing.Point(300, 33);
            this.MaxCurrentPoints_Button.Name = "MaxCurrentPoints_Button";
            this.MaxCurrentPoints_Button.Size = new System.Drawing.Size(124, 23);
            this.MaxCurrentPoints_Button.TabIndex = 4;
            this.MaxCurrentPoints_Button.Text = "{MaxPoints}";
            this.MaxCurrentPoints_Button.UseVisualStyleBackColor = false;
            this.MaxCurrentPoints_Button.Click += new System.EventHandler(this.MaxCurrentPoints_Button_Click);
            // 
            // TurfWarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 261);
            this.Controls.Add(this.TurfWars_GroupBox);
            this.Controls.Add(this.Points_GroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TurfWarEditor";
            this.Text = "{TurfWarEditor}";
            ((System.ComponentModel.ISupportInitialize)(this.HighScore_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentScore_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointsIcon_PictureBox)).EndInit();
            this.TurfWars_GroupBox.ResumeLayout(false);
            this.TurfWars_GroupBox.PerformLayout();
            this.Points_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PointsIcon_PictureBox;
        private System.Windows.Forms.NumericUpDown HighScore_NumUpDown;
        private System.Windows.Forms.NumericUpDown CurrentScore_NumUpDown;
        private System.Windows.Forms.Label CurrentScore_Label;
        private System.Windows.Forms.Label HighScore_Label;
        private System.Windows.Forms.GroupBox TurfWars_GroupBox;
        private System.Windows.Forms.ListView TurfWar_ListView;
        private System.Windows.Forms.ComboBox TurfWarPlacement_ComboBox;
        private System.Windows.Forms.Label Prizes_Label;
        private System.Windows.Forms.ColumnHeader TurfWarNameHeader;
        private System.Windows.Forms.GroupBox Points_GroupBox;
        private System.Windows.Forms.Button MaxPrizes_Button;
        private System.Windows.Forms.Button MaxCurrentPoints_Button;
        private System.Windows.Forms.CheckBox MaxPrizes_AllScrambles_Checkbox;
    }
}