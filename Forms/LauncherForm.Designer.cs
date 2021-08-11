
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
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 224);
            this.Controls.Add(this.TWEWYFR_Button);
            this.Controls.Add(this.NTWEWY_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LauncherForm";
            this.Text = "Scramble";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NTWEWY_Button;
        private System.Windows.Forms.Button TWEWYFR_Button;
    }
}