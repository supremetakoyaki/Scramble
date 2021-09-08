
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
            this.ReachedDay_WarningLabel = new System.Windows.Forms.Label();
            this.FurthestDay_ComboBox = new System.Windows.Forms.ComboBox();
            this.FurthestDay_Label = new System.Windows.Forms.Label();
            this.CurrentDay_ComboBox = new System.Windows.Forms.ComboBox();
            this.CurrentDay_Label = new System.Windows.Forms.Label();
            this.ReachedDays_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReachedDays_GroupBox
            // 
            this.ReachedDays_GroupBox.Controls.Add(this.ReachedDay_WarningLabel);
            this.ReachedDays_GroupBox.Controls.Add(this.FurthestDay_ComboBox);
            this.ReachedDays_GroupBox.Controls.Add(this.FurthestDay_Label);
            this.ReachedDays_GroupBox.Controls.Add(this.CurrentDay_ComboBox);
            this.ReachedDays_GroupBox.Controls.Add(this.CurrentDay_Label);
            this.ReachedDays_GroupBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ReachedDays_GroupBox.Location = new System.Drawing.Point(10, 10);
            this.ReachedDays_GroupBox.Name = "ReachedDays_GroupBox";
            this.ReachedDays_GroupBox.Size = new System.Drawing.Size(377, 142);
            this.ReachedDays_GroupBox.TabIndex = 0;
            this.ReachedDays_GroupBox.TabStop = false;
            this.ReachedDays_GroupBox.Text = "{ReachedDays}";
            // 
            // ReachedDay_WarningLabel
            // 
            this.ReachedDay_WarningLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ReachedDay_WarningLabel.ForeColor = System.Drawing.Color.Crimson;
            this.ReachedDay_WarningLabel.Location = new System.Drawing.Point(5, 88);
            this.ReachedDay_WarningLabel.Name = "ReachedDay_WarningLabel";
            this.ReachedDay_WarningLabel.Size = new System.Drawing.Size(367, 52);
            this.ReachedDay_WarningLabel.TabIndex = 4;
            this.ReachedDay_WarningLabel.Text = "{Warning}";
            this.ReachedDay_WarningLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FurthestDay_ComboBox
            // 
            this.FurthestDay_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FurthestDay_ComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FurthestDay_ComboBox.FormattingEnabled = true;
            this.FurthestDay_ComboBox.Location = new System.Drawing.Point(182, 55);
            this.FurthestDay_ComboBox.Name = "FurthestDay_ComboBox";
            this.FurthestDay_ComboBox.Size = new System.Drawing.Size(174, 23);
            this.FurthestDay_ComboBox.TabIndex = 3;
            this.FurthestDay_ComboBox.SelectedIndexChanged += new System.EventHandler(this.FurthestDay_ComboBox_SelectedIndexChanged);
            // 
            // FurthestDay_Label
            // 
            this.FurthestDay_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.FurthestDay_Label.Location = new System.Drawing.Point(22, 55);
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
            this.CurrentDay_ComboBox.Location = new System.Drawing.Point(182, 29);
            this.CurrentDay_ComboBox.Name = "CurrentDay_ComboBox";
            this.CurrentDay_ComboBox.Size = new System.Drawing.Size(174, 23);
            this.CurrentDay_ComboBox.TabIndex = 1;
            this.CurrentDay_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrentDay_ComboBox_SelectedIndexChanged);
            // 
            // CurrentDay_Label
            // 
            this.CurrentDay_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.CurrentDay_Label.Location = new System.Drawing.Point(22, 30);
            this.CurrentDay_Label.Name = "CurrentDay_Label";
            this.CurrentDay_Label.Size = new System.Drawing.Size(154, 19);
            this.CurrentDay_Label.TabIndex = 0;
            this.CurrentDay_Label.Text = "{CurrentDay:}";
            // 
            // DayEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(398, 163);
            this.Controls.Add(this.ReachedDays_GroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DayEditor";
            this.Text = "{DayEditor}";
            this.ReachedDays_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ReachedDays_GroupBox;
        private System.Windows.Forms.Label ReachedDay_WarningLabel;
        private System.Windows.Forms.ComboBox FurthestDay_ComboBox;
        private System.Windows.Forms.Label FurthestDay_Label;
        private System.Windows.Forms.ComboBox CurrentDay_ComboBox;
        private System.Windows.Forms.Label CurrentDay_Label;
    }
}