
namespace Scramble.Forms
{
    partial class MiscEditor
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
            this.Dlc1_Checkbox = new System.Windows.Forms.CheckBox();
            this.Dlc2_Checkbox = new System.Windows.Forms.CheckBox();
            this.DlcGroupBox = new System.Windows.Forms.GroupBox();
            this.DlcGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dlc1_Checkbox
            // 
            this.Dlc1_Checkbox.AutoSize = true;
            this.Dlc1_Checkbox.Location = new System.Drawing.Point(6, 29);
            this.Dlc1_Checkbox.Name = "Dlc1_Checkbox";
            this.Dlc1_Checkbox.Size = new System.Drawing.Size(94, 19);
            this.Dlc1_Checkbox.TabIndex = 1;
            this.Dlc1_Checkbox.Text = "{Dlc1_Name}";
            this.Dlc1_Checkbox.UseVisualStyleBackColor = true;
            this.Dlc1_Checkbox.CheckedChanged += new System.EventHandler(this.Dlc1_Checkbox_CheckedChanged);
            // 
            // Dlc2_Checkbox
            // 
            this.Dlc2_Checkbox.AutoSize = true;
            this.Dlc2_Checkbox.Location = new System.Drawing.Point(6, 55);
            this.Dlc2_Checkbox.Name = "Dlc2_Checkbox";
            this.Dlc2_Checkbox.Size = new System.Drawing.Size(94, 19);
            this.Dlc2_Checkbox.TabIndex = 2;
            this.Dlc2_Checkbox.Text = "{Dlc2_Name}";
            this.Dlc2_Checkbox.UseVisualStyleBackColor = true;
            this.Dlc2_Checkbox.CheckedChanged += new System.EventHandler(this.Dlc2_Checkbox_CheckedChanged);
            // 
            // DlcGroupBox
            // 
            this.DlcGroupBox.Controls.Add(this.Dlc1_Checkbox);
            this.DlcGroupBox.Controls.Add(this.Dlc2_Checkbox);
            this.DlcGroupBox.Location = new System.Drawing.Point(12, 12);
            this.DlcGroupBox.Name = "DlcGroupBox";
            this.DlcGroupBox.Size = new System.Drawing.Size(297, 89);
            this.DlcGroupBox.TabIndex = 3;
            this.DlcGroupBox.TabStop = false;
            this.DlcGroupBox.Text = "{DlcTitle}";
            // 
            // MiscEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(321, 113);
            this.Controls.Add(this.DlcGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MiscEditor";
            this.Text = "{MiscEditor}";
            this.DlcGroupBox.ResumeLayout(false);
            this.DlcGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox Dlc1_Checkbox;
        private System.Windows.Forms.CheckBox Dlc2_Checkbox;
        private System.Windows.Forms.GroupBox DlcGroupBox;
    }
}