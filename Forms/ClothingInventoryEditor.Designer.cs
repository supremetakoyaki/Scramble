
namespace Scramble.Forms
{
    partial class ClothingInventoryEditor
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
            this.DefenseLabel = new System.Windows.Forms.Label();
            this.ATKLabel = new System.Windows.Forms.Label();
            this.CharacterIconPictureBox = new System.Windows.Forms.PictureBox();
            this.EquippedByCharacterComboBox = new System.Windows.Forms.ComboBox();
            this.EquippedLabel = new System.Windows.Forms.Label();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.BrandPictureBox = new System.Windows.Forms.PictureBox();
            this.ClothingItem_NameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SlotType_PictureBox = new System.Windows.Forms.PictureBox();
            this.ClothingItem_PictureBox = new System.Windows.Forms.PictureBox();
            this.MyClothingInvListView = new System.Windows.Forms.ListView();
            this.ClthNameHeader = new System.Windows.Forms.ColumnHeader();
            this.ClthIdHeader = new System.Windows.Forms.ColumnHeader();
            this.ClthSlotHeader = new System.Windows.Forms.ColumnHeader();
            this.HealthPointLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClothingInvGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlotType_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClothingItem_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ClothingInvGroupBox
            // 
            this.ClothingInvGroupBox.Controls.Add(this.label2);
            this.ClothingInvGroupBox.Controls.Add(this.HealthPointLabel);
            this.ClothingInvGroupBox.Controls.Add(this.DefenseLabel);
            this.ClothingInvGroupBox.Controls.Add(this.ATKLabel);
            this.ClothingInvGroupBox.Controls.Add(this.CharacterIconPictureBox);
            this.ClothingInvGroupBox.Controls.Add(this.EquippedByCharacterComboBox);
            this.ClothingInvGroupBox.Controls.Add(this.EquippedLabel);
            this.ClothingInvGroupBox.Controls.Add(this.BrandLabel);
            this.ClothingInvGroupBox.Controls.Add(this.BrandPictureBox);
            this.ClothingInvGroupBox.Controls.Add(this.ClothingItem_NameLabel);
            this.ClothingInvGroupBox.Controls.Add(this.label1);
            this.ClothingInvGroupBox.Controls.Add(this.SlotType_PictureBox);
            this.ClothingInvGroupBox.Controls.Add(this.ClothingItem_PictureBox);
            this.ClothingInvGroupBox.Controls.Add(this.MyClothingInvListView);
            this.ClothingInvGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ClothingInvGroupBox.Name = "ClothingInvGroupBox";
            this.ClothingInvGroupBox.Size = new System.Drawing.Size(609, 637);
            this.ClothingInvGroupBox.TabIndex = 0;
            this.ClothingInvGroupBox.TabStop = false;
            this.ClothingInvGroupBox.Text = "Clothing Inventory";
            // 
            // DefenseLabel
            // 
            this.DefenseLabel.AutoSize = true;
            this.DefenseLabel.Location = new System.Drawing.Point(174, 454);
            this.DefenseLabel.Name = "DefenseLabel";
            this.DefenseLabel.Size = new System.Drawing.Size(30, 15);
            this.DefenseLabel.TabIndex = 26;
            this.DefenseLabel.Text = "DEF:";
            // 
            // ATKLabel
            // 
            this.ATKLabel.AutoSize = true;
            this.ATKLabel.Location = new System.Drawing.Point(174, 436);
            this.ATKLabel.Name = "ATKLabel";
            this.ATKLabel.Size = new System.Drawing.Size(30, 15);
            this.ATKLabel.TabIndex = 25;
            this.ATKLabel.Text = "ATK:";
            // 
            // CharacterIconPictureBox
            // 
            this.CharacterIconPictureBox.Location = new System.Drawing.Point(557, 549);
            this.CharacterIconPictureBox.Name = "CharacterIconPictureBox";
            this.CharacterIconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.CharacterIconPictureBox.TabIndex = 24;
            this.CharacterIconPictureBox.TabStop = false;
            // 
            // EquippedByCharacterComboBox
            // 
            this.EquippedByCharacterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquippedByCharacterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EquippedByCharacterComboBox.FormattingEnabled = true;
            this.EquippedByCharacterComboBox.Items.AddRange(new object[] {
            Program.Sukuranburu.GetString("{NoOne}")});
            this.EquippedByCharacterComboBox.Location = new System.Drawing.Point(419, 555);
            this.EquippedByCharacterComboBox.Name = "EquippedByCharacterComboBox";
            this.EquippedByCharacterComboBox.Size = new System.Drawing.Size(132, 23);
            this.EquippedByCharacterComboBox.TabIndex = 23;
            // 
            // EquippedLabel
            // 
            this.EquippedLabel.AutoSize = true;
            this.EquippedLabel.Location = new System.Drawing.Point(460, 533);
            this.EquippedLabel.Name = "EquippedLabel";
            this.EquippedLabel.Size = new System.Drawing.Size(60, 15);
            this.EquippedLabel.TabIndex = 22;
            this.EquippedLabel.Text = "Equipped:";
            // 
            // BrandLabel
            // 
            this.BrandLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BrandLabel.Location = new System.Drawing.Point(419, 474);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(170, 15);
            this.BrandLabel.TabIndex = 18;
            this.BrandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrandPictureBox
            // 
            this.BrandPictureBox.Location = new System.Drawing.Point(419, 391);
            this.BrandPictureBox.Name = "BrandPictureBox";
            this.BrandPictureBox.Size = new System.Drawing.Size(170, 60);
            this.BrandPictureBox.TabIndex = 17;
            this.BrandPictureBox.TabStop = false;
            // 
            // ClothingItem_NameLabel
            // 
            this.ClothingItem_NameLabel.AutoSize = true;
            this.ClothingItem_NameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClothingItem_NameLabel.Location = new System.Drawing.Point(174, 391);
            this.ClothingItem_NameLabel.Name = "ClothingItem_NameLabel";
            this.ClothingItem_NameLabel.Size = new System.Drawing.Size(107, 17);
            this.ClothingItem_NameLabel.TabIndex = 4;
            this.ClothingItem_NameLabel.Text = "{Clothing Name}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(68, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "{SlotType}";
            // 
            // SlotType_PictureBox
            // 
            this.SlotType_PictureBox.Location = new System.Drawing.Point(30, 525);
            this.SlotType_PictureBox.Name = "SlotType_PictureBox";
            this.SlotType_PictureBox.Size = new System.Drawing.Size(32, 32);
            this.SlotType_PictureBox.TabIndex = 2;
            this.SlotType_PictureBox.TabStop = false;
            // 
            // ClothingItem_PictureBox
            // 
            this.ClothingItem_PictureBox.Location = new System.Drawing.Point(30, 391);
            this.ClothingItem_PictureBox.Name = "ClothingItem_PictureBox";
            this.ClothingItem_PictureBox.Size = new System.Drawing.Size(128, 128);
            this.ClothingItem_PictureBox.TabIndex = 1;
            this.ClothingItem_PictureBox.TabStop = false;
            // 
            // MyClothingInvListView
            // 
            this.MyClothingInvListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClthNameHeader,
            this.ClthIdHeader,
            this.ClthSlotHeader});
            this.MyClothingInvListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MyClothingInvListView.HideSelection = false;
            this.MyClothingInvListView.Location = new System.Drawing.Point(6, 22);
            this.MyClothingInvListView.Name = "MyClothingInvListView";
            this.MyClothingInvListView.Size = new System.Drawing.Size(597, 349);
            this.MyClothingInvListView.TabIndex = 0;
            this.MyClothingInvListView.UseCompatibleStateImageBehavior = false;
            this.MyClothingInvListView.View = System.Windows.Forms.View.Details;
            // 
            // ClthNameHeader
            // 
            this.ClthNameHeader.DisplayIndex = 1;
            this.ClthNameHeader.Text = "Name";
            this.ClthNameHeader.Width = 250;
            // 
            // ClthIdHeader
            // 
            this.ClthIdHeader.DisplayIndex = 0;
            this.ClthIdHeader.Text = "ID";
            this.ClthIdHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClthIdHeader.Width = 40;
            // 
            // ClthSlotHeader
            // 
            this.ClthSlotHeader.Text = "Type";
            this.ClthSlotHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClthSlotHeader.Width = 120;
            // 
            // HealthPointLabel
            // 
            this.HealthPointLabel.AutoSize = true;
            this.HealthPointLabel.Location = new System.Drawing.Point(174, 474);
            this.HealthPointLabel.Name = "HealthPointLabel";
            this.HealthPointLabel.Size = new System.Drawing.Size(26, 15);
            this.HealthPointLabel.TabIndex = 27;
            this.HealthPointLabel.Text = "HP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Required STYLE:";
            // 
            // ClothingInventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 661);
            this.Controls.Add(this.ClothingInvGroupBox);
            this.Name = "ClothingInventoryEditor";
            this.Text = "Clothing Inventory Editor";
            this.ClothingInvGroupBox.ResumeLayout(false);
            this.ClothingInvGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrandPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlotType_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClothingItem_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ClothingInvGroupBox;
        private System.Windows.Forms.ListView MyClothingInvListView;
        private System.Windows.Forms.ColumnHeader ClthNameHeader;
        private System.Windows.Forms.ColumnHeader ClthIdHeader;
        private System.Windows.Forms.PictureBox ClothingItem_PictureBox;
        private System.Windows.Forms.PictureBox SlotType_PictureBox;
        private System.Windows.Forms.Label ClothingItem_NameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader ClthSlotHeader;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.PictureBox BrandPictureBox;
        private System.Windows.Forms.PictureBox CharacterIconPictureBox;
        private System.Windows.Forms.ComboBox EquippedByCharacterComboBox;
        private System.Windows.Forms.Label EquippedLabel;
        private System.Windows.Forms.Label DefenseLabel;
        private System.Windows.Forms.Label ATKLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label HealthPointLabel;
    }
}