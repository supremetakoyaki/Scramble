
namespace Scramble.Legacy
{
    partial class LegacyForm
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
            this.Logo_PictureBox = new System.Windows.Forms.PictureBox();
            this.OpenSaveFileButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SaveChanges_Button = new System.Windows.Forms.Button();
            this.BackupCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OpenSettingsEdit_Button = new System.Windows.Forms.Button();
            this.OpenNoiseEdit_Button = new System.Windows.Forms.Button();
            this.OpenPinsEdit_Button = new System.Windows.Forms.Button();
            this.OpenShopEditor_Button = new System.Windows.Forms.Button();
            this.OpenItemEditor_Button = new System.Windows.Forms.Button();
            this.OpenStatsEditor_Button = new System.Windows.Forms.Button();
            this.ImportData_Button = new System.Windows.Forms.Button();
            this.DumpData_Button = new System.Windows.Forms.Button();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.Language_ComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logo_PictureBox
            // 
            this.Logo_PictureBox.Location = new System.Drawing.Point(12, 12);
            this.Logo_PictureBox.Name = "Logo_PictureBox";
            this.Logo_PictureBox.Size = new System.Drawing.Size(139, 74);
            this.Logo_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Logo_PictureBox.TabIndex = 0;
            this.Logo_PictureBox.TabStop = false;
            // 
            // OpenSaveFileButton
            // 
            this.OpenSaveFileButton.Location = new System.Drawing.Point(157, 12);
            this.OpenSaveFileButton.Name = "OpenSaveFileButton";
            this.OpenSaveFileButton.Size = new System.Drawing.Size(155, 74);
            this.OpenSaveFileButton.TabIndex = 1;
            this.OpenSaveFileButton.Text = "Open Save File...";
            this.OpenSaveFileButton.UseVisualStyleBackColor = true;
            this.OpenSaveFileButton.Click += new System.EventHandler(this.OpenSaveFileButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.VersionLabel.Location = new System.Drawing.Point(114, 72);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(37, 14);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = string.Empty;
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.VersionLabel.Click += new System.EventHandler(this.VersionLabel_Click);
            // 
            // SaveChanges_Button
            // 
            this.SaveChanges_Button.BackColor = System.Drawing.Color.LightCyan;
            this.SaveChanges_Button.Location = new System.Drawing.Point(318, 46);
            this.SaveChanges_Button.Name = "SaveChanges_Button";
            this.SaveChanges_Button.Size = new System.Drawing.Size(154, 40);
            this.SaveChanges_Button.TabIndex = 3;
            this.SaveChanges_Button.Text = "Save Changes";
            this.SaveChanges_Button.UseVisualStyleBackColor = false;
            this.SaveChanges_Button.Click += new System.EventHandler(this.SaveChanges_Button_Click);
            // 
            // BackupCheckbox
            // 
            this.BackupCheckbox.AutoSize = true;
            this.BackupCheckbox.Location = new System.Drawing.Point(318, 21);
            this.BackupCheckbox.Name = "BackupCheckbox";
            this.BackupCheckbox.Size = new System.Drawing.Size(106, 19);
            this.BackupCheckbox.TabIndex = 4;
            this.BackupCheckbox.Text = "Make a backup";
            this.BackupCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OpenSettingsEdit_Button);
            this.groupBox1.Controls.Add(this.OpenNoiseEdit_Button);
            this.groupBox1.Controls.Add(this.OpenPinsEdit_Button);
            this.groupBox1.Controls.Add(this.OpenShopEditor_Button);
            this.groupBox1.Controls.Add(this.OpenItemEditor_Button);
            this.groupBox1.Controls.Add(this.OpenStatsEditor_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 86);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editors";
            // 
            // OpenSettingsEdit_Button
            // 
            this.OpenSettingsEdit_Button.Enabled = false;
            this.OpenSettingsEdit_Button.Location = new System.Drawing.Point(309, 54);
            this.OpenSettingsEdit_Button.Name = "OpenSettingsEdit_Button";
            this.OpenSettingsEdit_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenSettingsEdit_Button.TabIndex = 5;
            this.OpenSettingsEdit_Button.Text = "Settings Editor";
            this.OpenSettingsEdit_Button.UseVisualStyleBackColor = true;
            // 
            // OpenNoiseEdit_Button
            // 
            this.OpenNoiseEdit_Button.Enabled = false;
            this.OpenNoiseEdit_Button.Location = new System.Drawing.Point(157, 54);
            this.OpenNoiseEdit_Button.Name = "OpenNoiseEdit_Button";
            this.OpenNoiseEdit_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenNoiseEdit_Button.TabIndex = 4;
            this.OpenNoiseEdit_Button.Text = "Noise Report Editor";
            this.OpenNoiseEdit_Button.UseVisualStyleBackColor = true;
            // 
            // OpenPinsEdit_Button
            // 
            this.OpenPinsEdit_Button.Enabled = false;
            this.OpenPinsEdit_Button.Location = new System.Drawing.Point(6, 54);
            this.OpenPinsEdit_Button.Name = "OpenPinsEdit_Button";
            this.OpenPinsEdit_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenPinsEdit_Button.TabIndex = 3;
            this.OpenPinsEdit_Button.Text = "Pins Editor";
            this.OpenPinsEdit_Button.UseVisualStyleBackColor = true;
            // 
            // OpenShopEditor_Button
            // 
            this.OpenShopEditor_Button.Enabled = false;
            this.OpenShopEditor_Button.Location = new System.Drawing.Point(308, 22);
            this.OpenShopEditor_Button.Name = "OpenShopEditor_Button";
            this.OpenShopEditor_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenShopEditor_Button.TabIndex = 2;
            this.OpenShopEditor_Button.Text = "Shop Editor";
            this.OpenShopEditor_Button.UseVisualStyleBackColor = true;
            // 
            // OpenItemEditor_Button
            // 
            this.OpenItemEditor_Button.Location = new System.Drawing.Point(157, 22);
            this.OpenItemEditor_Button.Name = "OpenItemEditor_Button";
            this.OpenItemEditor_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenItemEditor_Button.TabIndex = 1;
            this.OpenItemEditor_Button.Text = "Item Editor";
            this.OpenItemEditor_Button.UseVisualStyleBackColor = true;
            this.OpenItemEditor_Button.Click += new System.EventHandler(this.OpenItemEditor_Button_Click);
            // 
            // OpenStatsEditor_Button
            // 
            this.OpenStatsEditor_Button.Location = new System.Drawing.Point(6, 22);
            this.OpenStatsEditor_Button.Name = "OpenStatsEditor_Button";
            this.OpenStatsEditor_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenStatsEditor_Button.TabIndex = 0;
            this.OpenStatsEditor_Button.Text = "Stats Editor";
            this.OpenStatsEditor_Button.UseVisualStyleBackColor = true;
            this.OpenStatsEditor_Button.Click += new System.EventHandler(this.OpenStatsEditor_Button_Click);
            // 
            // ImportData_Button
            // 
            this.ImportData_Button.BackColor = System.Drawing.Color.SeaShell;
            this.ImportData_Button.Location = new System.Drawing.Point(114, 196);
            this.ImportData_Button.Name = "ImportData_Button";
            this.ImportData_Button.Size = new System.Drawing.Size(94, 23);
            this.ImportData_Button.TabIndex = 6;
            this.ImportData_Button.Text = "Import Data";
            this.ImportData_Button.UseVisualStyleBackColor = false;
            this.ImportData_Button.Click += new System.EventHandler(this.ImportData_Button_Click);
            // 
            // DumpData_Button
            // 
            this.DumpData_Button.BackColor = System.Drawing.Color.SeaShell;
            this.DumpData_Button.Location = new System.Drawing.Point(12, 196);
            this.DumpData_Button.Name = "DumpData_Button";
            this.DumpData_Button.Size = new System.Drawing.Size(94, 23);
            this.DumpData_Button.TabIndex = 7;
            this.DumpData_Button.Text = "Dump Data";
            this.DumpData_Button.UseVisualStyleBackColor = false;
            this.DumpData_Button.Click += new System.EventHandler(this.DumpData_Button_Click);
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LanguageLabel.Location = new System.Drawing.Point(306, 200);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(60, 19);
            this.LanguageLabel.TabIndex = 9;
            this.LanguageLabel.Text = "Language:";
            // 
            // Language_ComboBox
            // 
            this.Language_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Language_ComboBox.Enabled = false;
            this.Language_ComboBox.FormattingEnabled = true;
            this.Language_ComboBox.Items.AddRange(new object[] {
            "English",
            "日本語",
            "Español",
            "Français"});
            this.Language_ComboBox.Location = new System.Drawing.Point(372, 196);
            this.Language_ComboBox.Name = "Language_ComboBox";
            this.Language_ComboBox.Size = new System.Drawing.Size(100, 23);
            this.Language_ComboBox.TabIndex = 10;
            // 
            // LegacyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(484, 231);
            this.Controls.Add(this.Language_ComboBox);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.DumpData_Button);
            this.Controls.Add(this.ImportData_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BackupCheckbox);
            this.Controls.Add(this.SaveChanges_Button);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.OpenSaveFileButton);
            this.Controls.Add(this.Logo_PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LegacyForm";
            this.Text = "Scramble";
            ((System.ComponentModel.ISupportInitialize)(this.Logo_PictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo_PictureBox;
        private System.Windows.Forms.Button OpenSaveFileButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button SaveChanges_Button;
        private System.Windows.Forms.CheckBox BackupCheckbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OpenItemEditor_Button;
        private System.Windows.Forms.Button OpenStatsEditor_Button;
        private System.Windows.Forms.Button OpenShopEditor_Button;
        private System.Windows.Forms.Button OpenPinsEdit_Button;
        private System.Windows.Forms.Button OpenNoiseEdit_Button;
        private System.Windows.Forms.Button OpenSettingsEdit_Button;
        private System.Windows.Forms.Button ImportData_Button;
        private System.Windows.Forms.Button DumpData_Button;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.ComboBox Language_ComboBox;
    }
}