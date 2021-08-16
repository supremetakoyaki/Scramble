
namespace Scramble.Legacy
{
    partial class LegacyItemEditor
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
            this.ItemsGroupBox = new System.Windows.Forms.GroupBox();
            this.ItemList_ListView = new System.Windows.Forms.ListView();
            this.SetAllMax_Button = new System.Windows.Forms.Button();
            this.ItemInformation_GroupBox = new System.Windows.Forms.GroupBox();
            this.Item_PictureBox = new System.Windows.Forms.PictureBox();
            this.ItemName_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.ItemType_Label = new System.Windows.Forms.Label();
            this.ItemType_Value_Label = new System.Windows.Forms.Label();
            this.ItemDescription_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.SetAllToMin_Button = new System.Windows.Forms.Button();
            this.Amount_NUpDown = new System.Windows.Forms.NumericUpDown();
            this.ItemsGroupBox.SuspendLayout();
            this.ItemInformation_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Item_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_NUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemsGroupBox
            // 
            this.ItemsGroupBox.Controls.Add(this.SetAllToMin_Button);
            this.ItemsGroupBox.Controls.Add(this.SetAllMax_Button);
            this.ItemsGroupBox.Controls.Add(this.ItemList_ListView);
            this.ItemsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ItemsGroupBox.Name = "ItemsGroupBox";
            this.ItemsGroupBox.Size = new System.Drawing.Size(297, 337);
            this.ItemsGroupBox.TabIndex = 0;
            this.ItemsGroupBox.TabStop = false;
            this.ItemsGroupBox.Text = "Item List";
            // 
            // ItemList_ListView
            // 
            this.ItemList_ListView.HideSelection = false;
            this.ItemList_ListView.Location = new System.Drawing.Point(6, 22);
            this.ItemList_ListView.MultiSelect = false;
            this.ItemList_ListView.Name = "ItemList_ListView";
            this.ItemList_ListView.Size = new System.Drawing.Size(285, 280);
            this.ItemList_ListView.TabIndex = 0;
            this.ItemList_ListView.UseCompatibleStateImageBehavior = false;
            this.ItemList_ListView.View = System.Windows.Forms.View.List;
            // 
            // SetAllMax_Button
            // 
            this.SetAllMax_Button.BackColor = System.Drawing.Color.MintCream;
            this.SetAllMax_Button.Location = new System.Drawing.Point(6, 308);
            this.SetAllMax_Button.Name = "SetAllMax_Button";
            this.SetAllMax_Button.Size = new System.Drawing.Size(140, 23);
            this.SetAllMax_Button.TabIndex = 1;
            this.SetAllMax_Button.Text = "Set all to max amount";
            this.SetAllMax_Button.UseVisualStyleBackColor = false;
            // 
            // ItemInformation_GroupBox
            // 
            this.ItemInformation_GroupBox.Controls.Add(this.Amount_NUpDown);
            this.ItemInformation_GroupBox.Controls.Add(this.AmountLabel);
            this.ItemInformation_GroupBox.Controls.Add(this.ItemDescription_RichTextBox);
            this.ItemInformation_GroupBox.Controls.Add(this.ItemType_Value_Label);
            this.ItemInformation_GroupBox.Controls.Add(this.ItemType_Label);
            this.ItemInformation_GroupBox.Controls.Add(this.ItemName_RichTextBox);
            this.ItemInformation_GroupBox.Controls.Add(this.Item_PictureBox);
            this.ItemInformation_GroupBox.Location = new System.Drawing.Point(315, 12);
            this.ItemInformation_GroupBox.Name = "ItemInformation_GroupBox";
            this.ItemInformation_GroupBox.Size = new System.Drawing.Size(337, 337);
            this.ItemInformation_GroupBox.TabIndex = 1;
            this.ItemInformation_GroupBox.TabStop = false;
            this.ItemInformation_GroupBox.Text = "Item Info";
            // 
            // Item_PictureBox
            // 
            this.Item_PictureBox.Location = new System.Drawing.Point(6, 22);
            this.Item_PictureBox.Name = "Item_PictureBox";
            this.Item_PictureBox.Size = new System.Drawing.Size(64, 64);
            this.Item_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Item_PictureBox.TabIndex = 0;
            this.Item_PictureBox.TabStop = false;
            // 
            // ItemName_RichTextBox
            // 
            this.ItemName_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ItemName_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItemName_RichTextBox.Enabled = false;
            this.ItemName_RichTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ItemName_RichTextBox.Location = new System.Drawing.Point(76, 22);
            this.ItemName_RichTextBox.Name = "ItemName_RichTextBox";
            this.ItemName_RichTextBox.Size = new System.Drawing.Size(255, 46);
            this.ItemName_RichTextBox.TabIndex = 1;
            this.ItemName_RichTextBox.Text = "No selected item";
            // 
            // ItemType_Label
            // 
            this.ItemType_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ItemType_Label.Location = new System.Drawing.Point(76, 71);
            this.ItemType_Label.Name = "ItemType_Label";
            this.ItemType_Label.Size = new System.Drawing.Size(51, 15);
            this.ItemType_Label.TabIndex = 2;
            this.ItemType_Label.Text = "Type:";
            // 
            // ItemType_Value_Label
            // 
            this.ItemType_Value_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ItemType_Value_Label.Location = new System.Drawing.Point(133, 71);
            this.ItemType_Value_Label.Name = "ItemType_Value_Label";
            this.ItemType_Value_Label.Size = new System.Drawing.Size(198, 15);
            this.ItemType_Value_Label.TabIndex = 3;
            this.ItemType_Value_Label.Text = "—";
            // 
            // ItemDescription_RichTextBox
            // 
            this.ItemDescription_RichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ItemDescription_RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItemDescription_RichTextBox.Enabled = false;
            this.ItemDescription_RichTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemDescription_RichTextBox.Location = new System.Drawing.Point(6, 111);
            this.ItemDescription_RichTextBox.Name = "ItemDescription_RichTextBox";
            this.ItemDescription_RichTextBox.Size = new System.Drawing.Size(325, 191);
            this.ItemDescription_RichTextBox.TabIndex = 4;
            this.ItemDescription_RichTextBox.Text = "No selected item";
            // 
            // AmountLabel
            // 
            this.AmountLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AmountLabel.Location = new System.Drawing.Point(6, 312);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(64, 19);
            this.AmountLabel.TabIndex = 5;
            this.AmountLabel.Text = "Amount:";
            // 
            // SetAllToMin_Button
            // 
            this.SetAllToMin_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SetAllToMin_Button.Location = new System.Drawing.Point(152, 308);
            this.SetAllToMin_Button.Name = "SetAllToMin_Button";
            this.SetAllToMin_Button.Size = new System.Drawing.Size(139, 23);
            this.SetAllToMin_Button.TabIndex = 2;
            this.SetAllToMin_Button.Text = "Clear all";
            this.SetAllToMin_Button.UseVisualStyleBackColor = false;
            // 
            // Amount_NUpDown
            // 
            this.Amount_NUpDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Amount_NUpDown.Location = new System.Drawing.Point(76, 308);
            this.Amount_NUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Amount_NUpDown.Name = "Amount_NUpDown";
            this.Amount_NUpDown.Size = new System.Drawing.Size(51, 22);
            this.Amount_NUpDown.TabIndex = 6;
            // 
            // LegacyItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(664, 361);
            this.Controls.Add(this.ItemInformation_GroupBox);
            this.Controls.Add(this.ItemsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LegacyItemEditor";
            this.Text = "Item Editor";
            this.ItemsGroupBox.ResumeLayout(false);
            this.ItemInformation_GroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Item_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_NUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ItemsGroupBox;
        private System.Windows.Forms.Button SetAllToMin_Button;
        private System.Windows.Forms.Button SetAllMax_Button;
        private System.Windows.Forms.ListView ItemList_ListView;
        private System.Windows.Forms.GroupBox ItemInformation_GroupBox;
        private System.Windows.Forms.NumericUpDown Amount_NUpDown;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.RichTextBox ItemDescription_RichTextBox;
        private System.Windows.Forms.Label ItemType_Value_Label;
        private System.Windows.Forms.Label ItemType_Label;
        private System.Windows.Forms.RichTextBox ItemName_RichTextBox;
        private System.Windows.Forms.PictureBox Item_PictureBox;
    }
}