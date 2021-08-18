
namespace Scramble.Forms
{
    partial class LauncherForm
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
            this.NTWEWY_Button = new System.Windows.Forms.Button();
            this.TWEWYFR_Button = new System.Windows.Forms.Button();
            this.Utilities_GroupBox = new System.Windows.Forms.GroupBox();
            this.Convert_FromSoloRemix_Button = new System.Windows.Forms.Button();
            this.Utilities_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NTWEWY_Button
            // 
            this.NTWEWY_Button.Location = new System.Drawing.Point(12, 12);
            this.NTWEWY_Button.Name = "NTWEWY_Button";
            this.NTWEWY_Button.Size = new System.Drawing.Size(200, 200);
            this.NTWEWY_Button.TabIndex = 1;
            this.NTWEWY_Button.UseVisualStyleBackColor = true;
            this.NTWEWY_Button.Click += new System.EventHandler(this.NTWEWY_Button_Click);
            // 
            // TWEWYFR_Button
            // 
            this.TWEWYFR_Button.Location = new System.Drawing.Point(218, 12);
            this.TWEWYFR_Button.Name = "TWEWYFR_Button";
            this.TWEWYFR_Button.Size = new System.Drawing.Size(200, 200);
            this.TWEWYFR_Button.TabIndex = 2;
            this.TWEWYFR_Button.UseVisualStyleBackColor = true;
            this.TWEWYFR_Button.Click += new System.EventHandler(this.TWEWYFR_Button_Click);
            // 
            // Utilities_GroupBox
            // 
            this.Utilities_GroupBox.Controls.Add(this.Convert_FromSoloRemix_Button);
            this.Utilities_GroupBox.Location = new System.Drawing.Point(12, 218);
            this.Utilities_GroupBox.Name = "Utilities_GroupBox";
            this.Utilities_GroupBox.Size = new System.Drawing.Size(406, 51);
            this.Utilities_GroupBox.TabIndex = 3;
            this.Utilities_GroupBox.TabStop = false;
            this.Utilities_GroupBox.Text = "Utilities";
            // 
            // Convert_FromSoloRemix_Button
            // 
            this.Convert_FromSoloRemix_Button.Location = new System.Drawing.Point(206, 22);
            this.Convert_FromSoloRemix_Button.Name = "Convert_FromSoloRemix_Button";
            this.Convert_FromSoloRemix_Button.Size = new System.Drawing.Size(194, 23);
            this.Convert_FromSoloRemix_Button.TabIndex = 0;
            this.Convert_FromSoloRemix_Button.UseVisualStyleBackColor = true;
            this.Convert_FromSoloRemix_Button.Click += new System.EventHandler(this.Convert_FromSoloRemix_Button_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 281);
            this.Controls.Add(this.Utilities_GroupBox);
            this.Controls.Add(this.TWEWYFR_Button);
            this.Controls.Add(this.NTWEWY_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LauncherForm";
            this.Text = "Scramble";
            this.Utilities_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NTWEWY_Button;
        private System.Windows.Forms.Button TWEWYFR_Button;
        private System.Windows.Forms.GroupBox Utilities_GroupBox;
        private System.Windows.Forms.Button Convert_FromSoloRemix_Button;
    }
}