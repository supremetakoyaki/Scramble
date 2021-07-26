
namespace Scramble.Forms
{
    partial class FashionInventoryEditor
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
            this.ClothingInvGroupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // ClothingInvGroupBox
            // 
            this.ClothingInvGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ClothingInvGroupBox.Name = "ClothingInvGroupBox";
            this.ClothingInvGroupBox.Size = new System.Drawing.Size(459, 314);
            this.ClothingInvGroupBox.TabIndex = 0;
            this.ClothingInvGroupBox.TabStop = false;
            this.ClothingInvGroupBox.Text = "Clothing Inventory";
            // 
            // FashionInventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClothingInvGroupBox);
            this.Name = "FashionInventoryEditor";
            this.Text = "Clothing Inventory Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ClothingInvGroupBox;
    }
}