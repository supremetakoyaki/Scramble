
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
            this.OpenStatsEditor_Button = new System.Windows.Forms.Button();
            this.OpenItemEditor_Button = new System.Windows.Forms.Button();
            this.OpenShopEditor_Button = new System.Windows.Forms.Button();
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
            this.VersionLabel.Text = "v0.8";
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
            this.groupBox1.Controls.Add(this.OpenShopEditor_Button);
            this.groupBox1.Controls.Add(this.OpenItemEditor_Button);
            this.groupBox1.Controls.Add(this.OpenStatsEditor_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 54);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editors";
            // 
            // OpenStatsEditor_Button
            // 
            this.OpenStatsEditor_Button.Location = new System.Drawing.Point(6, 22);
            this.OpenStatsEditor_Button.Name = "OpenStatsEditor_Button";
            this.OpenStatsEditor_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenStatsEditor_Button.TabIndex = 0;
            this.OpenStatsEditor_Button.Text = "Stats Editor";
            this.OpenStatsEditor_Button.UseVisualStyleBackColor = true;
            // 
            // OpenItemEditor_Button
            // 
            this.OpenItemEditor_Button.Location = new System.Drawing.Point(157, 22);
            this.OpenItemEditor_Button.Name = "OpenItemEditor_Button";
            this.OpenItemEditor_Button.Size = new System.Drawing.Size(145, 26);
            this.OpenItemEditor_Button.TabIndex = 1;
            this.OpenItemEditor_Button.Text = "Item Editor";
            this.OpenItemEditor_Button.UseVisualStyleBackColor = true;
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
            // LegacyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 170);
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
    }
}