namespace Scramble.Forms
{
    partial class NeoTwewyRandomizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeoTwewyRandomizerForm));
            this.RandomizerPictureBox = new System.Windows.Forms.PictureBox();
            this.OverviewGroupBox = new System.Windows.Forms.GroupBox();
            this.OverviewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.RandomizerGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.RandomizerPictureBox)).BeginInit();
            this.OverviewGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RandomizerPictureBox
            // 
            this.RandomizerPictureBox.Location = new System.Drawing.Point(6, 22);
            this.RandomizerPictureBox.Name = "RandomizerPictureBox";
            this.RandomizerPictureBox.Size = new System.Drawing.Size(710, 105);
            this.RandomizerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.RandomizerPictureBox.TabIndex = 0;
            this.RandomizerPictureBox.TabStop = false;
            // 
            // OverviewGroupBox
            // 
            this.OverviewGroupBox.Controls.Add(this.OverviewRichTextBox);
            this.OverviewGroupBox.Controls.Add(this.RandomizerPictureBox);
            this.OverviewGroupBox.Location = new System.Drawing.Point(12, 12);
            this.OverviewGroupBox.Name = "OverviewGroupBox";
            this.OverviewGroupBox.Size = new System.Drawing.Size(724, 233);
            this.OverviewGroupBox.TabIndex = 1;
            this.OverviewGroupBox.TabStop = false;
            this.OverviewGroupBox.Text = "{Overview}";
            // 
            // OverviewRichTextBox
            // 
            this.OverviewRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.OverviewRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OverviewRichTextBox.Enabled = false;
            this.OverviewRichTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverviewRichTextBox.Location = new System.Drawing.Point(6, 133);
            this.OverviewRichTextBox.Name = "OverviewRichTextBox";
            this.OverviewRichTextBox.ReadOnly = true;
            this.OverviewRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.OverviewRichTextBox.Size = new System.Drawing.Size(710, 94);
            this.OverviewRichTextBox.TabIndex = 0;
            this.OverviewRichTextBox.Text = resources.GetString("OverviewRichTextBox.Text");
            // 
            // RandomizerGroupBox
            // 
            this.RandomizerGroupBox.Location = new System.Drawing.Point(12, 251);
            this.RandomizerGroupBox.Name = "RandomizerGroupBox";
            this.RandomizerGroupBox.Size = new System.Drawing.Size(724, 293);
            this.RandomizerGroupBox.TabIndex = 2;
            this.RandomizerGroupBox.TabStop = false;
            this.RandomizerGroupBox.Text = "{Randomizer}";
            // 
            // NeoTwewyRandomizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(748, 556);
            this.Controls.Add(this.RandomizerGroupBox);
            this.Controls.Add(this.OverviewGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NeoTwewyRandomizerForm";
            this.Text = "{NeoTwewyRandomizer}";
            ((System.ComponentModel.ISupportInitialize)(this.RandomizerPictureBox)).EndInit();
            this.OverviewGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox RandomizerPictureBox;
        private System.Windows.Forms.GroupBox OverviewGroupBox;
        private System.Windows.Forms.RichTextBox OverviewRichTextBox;
        private System.Windows.Forms.GroupBox RandomizerGroupBox;
    }
}