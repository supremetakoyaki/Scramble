namespace Scramble.Forms
{
    partial class ShopEditor
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
            this.ShopListGroupBox = new System.Windows.Forms.GroupBox();
            this.ShopListListView = new System.Windows.Forms.ListView();
            this.IdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CategoryHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShopDataGroupBox = new System.Windows.Forms.GroupBox();
            this.SelectedShopLastFoodCharacter7ComboBox = new System.Windows.Forms.ComboBox();
            this.SelectedShopLastFoodCharacter7Label = new System.Windows.Forms.Label();
            this.SelectedShopLastFoodCharacter6ComboBox = new System.Windows.Forms.ComboBox();
            this.SelectedShopLastFoodCharacter6Label = new System.Windows.Forms.Label();
            this.SelectedShopLastFoodCharacter5ComboBox = new System.Windows.Forms.ComboBox();
            this.SelectedShopLastFoodCharacter5Label = new System.Windows.Forms.Label();
            this.SelectedShopLastFoodCharacter4ComboBox = new System.Windows.Forms.ComboBox();
            this.SelectedShopLastFoodCharacter4Label = new System.Windows.Forms.Label();
            this.SelectedShopLastFoodCharacter3ComboBox = new System.Windows.Forms.ComboBox();
            this.SelectedShopLastFoodCharacter3Label = new System.Windows.Forms.Label();
            this.SelectedShopLastFoodCharacter2ComboBox = new System.Windows.Forms.ComboBox();
            this.SelectedShopLastFoodCharacter2Label = new System.Windows.Forms.Label();
            this.SelectedShopLastFoodCharacter1ComboBox = new System.Windows.Forms.ComboBox();
            this.SelectedShopLastFoodCharacter1Label = new System.Windows.Forms.Label();
            this.SelectedShopLastFoodsTitleLabel = new System.Windows.Forms.Label();
            this.SelectedShopTimesUsedNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.SelectedShopTimesUsedLabel = new System.Windows.Forms.Label();
            this.SelectedShopNameRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SelectedShopCatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ShopGoodsGroupBox = new System.Windows.Forms.GroupBox();
            this.BrandsGroupBox = new System.Windows.Forms.GroupBox();
            this.SelectedShopSymbolPictureBox = new System.Windows.Forms.PictureBox();
            this.ShopListGroupBox.SuspendLayout();
            this.ShopDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedShopTimesUsedNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedShopSymbolPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ShopListGroupBox
            // 
            this.ShopListGroupBox.Controls.Add(this.ShopListListView);
            this.ShopListGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ShopListGroupBox.Name = "ShopListGroupBox";
            this.ShopListGroupBox.Size = new System.Drawing.Size(474, 657);
            this.ShopListGroupBox.TabIndex = 0;
            this.ShopListGroupBox.TabStop = false;
            this.ShopListGroupBox.Text = "{ShopList}";
            // 
            // ShopListListView
            // 
            this.ShopListListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdHeader,
            this.NameHeader,
            this.CategoryHeader});
            this.ShopListListView.FullRowSelect = true;
            this.ShopListListView.HideSelection = false;
            this.ShopListListView.Location = new System.Drawing.Point(6, 22);
            this.ShopListListView.MultiSelect = false;
            this.ShopListListView.Name = "ShopListListView";
            this.ShopListListView.Size = new System.Drawing.Size(462, 541);
            this.ShopListListView.TabIndex = 0;
            this.ShopListListView.UseCompatibleStateImageBehavior = false;
            this.ShopListListView.View = System.Windows.Forms.View.Details;
            this.ShopListListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ShopListListView_ColumnClick);
            this.ShopListListView.SelectedIndexChanged += new System.EventHandler(this.ShopListListView_SelectedIndexChanged);
            // 
            // IdHeader
            // 
            this.IdHeader.Text = "{Id}";
            this.IdHeader.Width = 45;
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "{Name}";
            this.NameHeader.Width = 270;
            // 
            // CategoryHeader
            // 
            this.CategoryHeader.Text = "{Category}";
            this.CategoryHeader.Width = 120;
            // 
            // ShopDataGroupBox
            // 
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopSymbolPictureBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter7ComboBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter7Label);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter6ComboBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter6Label);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter5ComboBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter5Label);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter4ComboBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter4Label);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter3ComboBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter3Label);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter2ComboBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter2Label);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter1ComboBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodCharacter1Label);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopLastFoodsTitleLabel);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopTimesUsedNumUpDown);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopTimesUsedLabel);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopNameRichTextBox);
            this.ShopDataGroupBox.Controls.Add(this.SelectedShopCatRichTextBox);
            this.ShopDataGroupBox.Location = new System.Drawing.Point(492, 12);
            this.ShopDataGroupBox.Name = "ShopDataGroupBox";
            this.ShopDataGroupBox.Size = new System.Drawing.Size(451, 269);
            this.ShopDataGroupBox.TabIndex = 1;
            this.ShopDataGroupBox.TabStop = false;
            this.ShopDataGroupBox.Text = "{SelectedShop}";
            // 
            // SelectedShopLastFoodCharacter7ComboBox
            // 
            this.SelectedShopLastFoodCharacter7ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedShopLastFoodCharacter7ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SelectedShopLastFoodCharacter7ComboBox.FormattingEnabled = true;
            this.SelectedShopLastFoodCharacter7ComboBox.Location = new System.Drawing.Point(116, 234);
            this.SelectedShopLastFoodCharacter7ComboBox.Name = "SelectedShopLastFoodCharacter7ComboBox";
            this.SelectedShopLastFoodCharacter7ComboBox.Size = new System.Drawing.Size(92, 21);
            this.SelectedShopLastFoodCharacter7ComboBox.TabIndex = 18;
            // 
            // SelectedShopLastFoodCharacter7Label
            // 
            this.SelectedShopLastFoodCharacter7Label.Location = new System.Drawing.Point(6, 236);
            this.SelectedShopLastFoodCharacter7Label.Name = "SelectedShopLastFoodCharacter7Label";
            this.SelectedShopLastFoodCharacter7Label.Size = new System.Drawing.Size(104, 19);
            this.SelectedShopLastFoodCharacter7Label.TabIndex = 17;
            this.SelectedShopLastFoodCharacter7Label.Text = "{Character7:}";
            // 
            // SelectedShopLastFoodCharacter6ComboBox
            // 
            this.SelectedShopLastFoodCharacter6ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedShopLastFoodCharacter6ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SelectedShopLastFoodCharacter6ComboBox.FormattingEnabled = true;
            this.SelectedShopLastFoodCharacter6ComboBox.Location = new System.Drawing.Point(353, 207);
            this.SelectedShopLastFoodCharacter6ComboBox.Name = "SelectedShopLastFoodCharacter6ComboBox";
            this.SelectedShopLastFoodCharacter6ComboBox.Size = new System.Drawing.Size(92, 21);
            this.SelectedShopLastFoodCharacter6ComboBox.TabIndex = 16;
            // 
            // SelectedShopLastFoodCharacter6Label
            // 
            this.SelectedShopLastFoodCharacter6Label.Location = new System.Drawing.Point(243, 209);
            this.SelectedShopLastFoodCharacter6Label.Name = "SelectedShopLastFoodCharacter6Label";
            this.SelectedShopLastFoodCharacter6Label.Size = new System.Drawing.Size(104, 19);
            this.SelectedShopLastFoodCharacter6Label.TabIndex = 15;
            this.SelectedShopLastFoodCharacter6Label.Text = "{Character6:}";
            // 
            // SelectedShopLastFoodCharacter5ComboBox
            // 
            this.SelectedShopLastFoodCharacter5ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedShopLastFoodCharacter5ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SelectedShopLastFoodCharacter5ComboBox.FormattingEnabled = true;
            this.SelectedShopLastFoodCharacter5ComboBox.Location = new System.Drawing.Point(116, 207);
            this.SelectedShopLastFoodCharacter5ComboBox.Name = "SelectedShopLastFoodCharacter5ComboBox";
            this.SelectedShopLastFoodCharacter5ComboBox.Size = new System.Drawing.Size(92, 21);
            this.SelectedShopLastFoodCharacter5ComboBox.TabIndex = 14;
            // 
            // SelectedShopLastFoodCharacter5Label
            // 
            this.SelectedShopLastFoodCharacter5Label.Location = new System.Drawing.Point(6, 209);
            this.SelectedShopLastFoodCharacter5Label.Name = "SelectedShopLastFoodCharacter5Label";
            this.SelectedShopLastFoodCharacter5Label.Size = new System.Drawing.Size(104, 19);
            this.SelectedShopLastFoodCharacter5Label.TabIndex = 13;
            this.SelectedShopLastFoodCharacter5Label.Text = "{Character5:}";
            // 
            // SelectedShopLastFoodCharacter4ComboBox
            // 
            this.SelectedShopLastFoodCharacter4ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedShopLastFoodCharacter4ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SelectedShopLastFoodCharacter4ComboBox.FormattingEnabled = true;
            this.SelectedShopLastFoodCharacter4ComboBox.Location = new System.Drawing.Point(353, 180);
            this.SelectedShopLastFoodCharacter4ComboBox.Name = "SelectedShopLastFoodCharacter4ComboBox";
            this.SelectedShopLastFoodCharacter4ComboBox.Size = new System.Drawing.Size(92, 21);
            this.SelectedShopLastFoodCharacter4ComboBox.TabIndex = 12;
            // 
            // SelectedShopLastFoodCharacter4Label
            // 
            this.SelectedShopLastFoodCharacter4Label.Location = new System.Drawing.Point(243, 182);
            this.SelectedShopLastFoodCharacter4Label.Name = "SelectedShopLastFoodCharacter4Label";
            this.SelectedShopLastFoodCharacter4Label.Size = new System.Drawing.Size(104, 19);
            this.SelectedShopLastFoodCharacter4Label.TabIndex = 11;
            this.SelectedShopLastFoodCharacter4Label.Text = "{Character4:}";
            // 
            // SelectedShopLastFoodCharacter3ComboBox
            // 
            this.SelectedShopLastFoodCharacter3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedShopLastFoodCharacter3ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SelectedShopLastFoodCharacter3ComboBox.FormattingEnabled = true;
            this.SelectedShopLastFoodCharacter3ComboBox.Location = new System.Drawing.Point(116, 180);
            this.SelectedShopLastFoodCharacter3ComboBox.Name = "SelectedShopLastFoodCharacter3ComboBox";
            this.SelectedShopLastFoodCharacter3ComboBox.Size = new System.Drawing.Size(92, 21);
            this.SelectedShopLastFoodCharacter3ComboBox.TabIndex = 10;
            // 
            // SelectedShopLastFoodCharacter3Label
            // 
            this.SelectedShopLastFoodCharacter3Label.Location = new System.Drawing.Point(6, 182);
            this.SelectedShopLastFoodCharacter3Label.Name = "SelectedShopLastFoodCharacter3Label";
            this.SelectedShopLastFoodCharacter3Label.Size = new System.Drawing.Size(104, 19);
            this.SelectedShopLastFoodCharacter3Label.TabIndex = 9;
            this.SelectedShopLastFoodCharacter3Label.Text = "{Character3:}";
            // 
            // SelectedShopLastFoodCharacter2ComboBox
            // 
            this.SelectedShopLastFoodCharacter2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedShopLastFoodCharacter2ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SelectedShopLastFoodCharacter2ComboBox.FormattingEnabled = true;
            this.SelectedShopLastFoodCharacter2ComboBox.Location = new System.Drawing.Point(353, 153);
            this.SelectedShopLastFoodCharacter2ComboBox.Name = "SelectedShopLastFoodCharacter2ComboBox";
            this.SelectedShopLastFoodCharacter2ComboBox.Size = new System.Drawing.Size(92, 21);
            this.SelectedShopLastFoodCharacter2ComboBox.TabIndex = 8;
            // 
            // SelectedShopLastFoodCharacter2Label
            // 
            this.SelectedShopLastFoodCharacter2Label.Location = new System.Drawing.Point(243, 155);
            this.SelectedShopLastFoodCharacter2Label.Name = "SelectedShopLastFoodCharacter2Label";
            this.SelectedShopLastFoodCharacter2Label.Size = new System.Drawing.Size(104, 19);
            this.SelectedShopLastFoodCharacter2Label.TabIndex = 7;
            this.SelectedShopLastFoodCharacter2Label.Text = "{Character2:}";
            // 
            // SelectedShopLastFoodCharacter1ComboBox
            // 
            this.SelectedShopLastFoodCharacter1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedShopLastFoodCharacter1ComboBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SelectedShopLastFoodCharacter1ComboBox.FormattingEnabled = true;
            this.SelectedShopLastFoodCharacter1ComboBox.Location = new System.Drawing.Point(116, 153);
            this.SelectedShopLastFoodCharacter1ComboBox.Name = "SelectedShopLastFoodCharacter1ComboBox";
            this.SelectedShopLastFoodCharacter1ComboBox.Size = new System.Drawing.Size(92, 21);
            this.SelectedShopLastFoodCharacter1ComboBox.TabIndex = 6;
            // 
            // SelectedShopLastFoodCharacter1Label
            // 
            this.SelectedShopLastFoodCharacter1Label.Location = new System.Drawing.Point(6, 155);
            this.SelectedShopLastFoodCharacter1Label.Name = "SelectedShopLastFoodCharacter1Label";
            this.SelectedShopLastFoodCharacter1Label.Size = new System.Drawing.Size(104, 19);
            this.SelectedShopLastFoodCharacter1Label.TabIndex = 5;
            this.SelectedShopLastFoodCharacter1Label.Text = "{Character1:}";
            // 
            // SelectedShopLastFoodsTitleLabel
            // 
            this.SelectedShopLastFoodsTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedShopLastFoodsTitleLabel.Location = new System.Drawing.Point(6, 122);
            this.SelectedShopLastFoodsTitleLabel.Name = "SelectedShopLastFoodsTitleLabel";
            this.SelectedShopLastFoodsTitleLabel.Size = new System.Drawing.Size(439, 13);
            this.SelectedShopLastFoodsTitleLabel.TabIndex = 4;
            this.SelectedShopLastFoodsTitleLabel.Text = "————————————— Last ordered food —————————————";
            this.SelectedShopLastFoodsTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectedShopTimesUsedNumUpDown
            // 
            this.SelectedShopTimesUsedNumUpDown.Location = new System.Drawing.Point(116, 80);
            this.SelectedShopTimesUsedNumUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.SelectedShopTimesUsedNumUpDown.Name = "SelectedShopTimesUsedNumUpDown";
            this.SelectedShopTimesUsedNumUpDown.Size = new System.Drawing.Size(91, 23);
            this.SelectedShopTimesUsedNumUpDown.TabIndex = 3;
            this.SelectedShopTimesUsedNumUpDown.ValueChanged += new System.EventHandler(this.SelectedShopTimesUsedNumUpDown_ValueChanged);
            // 
            // SelectedShopTimesUsedLabel
            // 
            this.SelectedShopTimesUsedLabel.Location = new System.Drawing.Point(6, 82);
            this.SelectedShopTimesUsedLabel.Name = "SelectedShopTimesUsedLabel";
            this.SelectedShopTimesUsedLabel.Size = new System.Drawing.Size(104, 21);
            this.SelectedShopTimesUsedLabel.TabIndex = 2;
            this.SelectedShopTimesUsedLabel.Text = "{TimesUsed:}";
            // 
            // SelectedShopNameRichTextBox
            // 
            this.SelectedShopNameRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedShopNameRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedShopNameRichTextBox.Enabled = false;
            this.SelectedShopNameRichTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.SelectedShopNameRichTextBox.Location = new System.Drawing.Point(9, 45);
            this.SelectedShopNameRichTextBox.Multiline = false;
            this.SelectedShopNameRichTextBox.Name = "SelectedShopNameRichTextBox";
            this.SelectedShopNameRichTextBox.ReadOnly = true;
            this.SelectedShopNameRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.SelectedShopNameRichTextBox.Size = new System.Drawing.Size(338, 25);
            this.SelectedShopNameRichTextBox.TabIndex = 1;
            this.SelectedShopNameRichTextBox.Text = "{NoSelectedShop}";
            // 
            // SelectedShopCatRichTextBox
            // 
            this.SelectedShopCatRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectedShopCatRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedShopCatRichTextBox.Enabled = false;
            this.SelectedShopCatRichTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.SelectedShopCatRichTextBox.Location = new System.Drawing.Point(9, 31);
            this.SelectedShopCatRichTextBox.Multiline = false;
            this.SelectedShopCatRichTextBox.Name = "SelectedShopCatRichTextBox";
            this.SelectedShopCatRichTextBox.ReadOnly = true;
            this.SelectedShopCatRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.SelectedShopCatRichTextBox.Size = new System.Drawing.Size(338, 17);
            this.SelectedShopCatRichTextBox.TabIndex = 0;
            this.SelectedShopCatRichTextBox.Text = "—";
            // 
            // ShopGoodsGroupBox
            // 
            this.ShopGoodsGroupBox.Location = new System.Drawing.Point(492, 287);
            this.ShopGoodsGroupBox.Name = "ShopGoodsGroupBox";
            this.ShopGoodsGroupBox.Size = new System.Drawing.Size(451, 376);
            this.ShopGoodsGroupBox.TabIndex = 2;
            this.ShopGoodsGroupBox.TabStop = false;
            this.ShopGoodsGroupBox.Text = "{ShopGoods}";
            // 
            // BrandsGroupBox
            // 
            this.BrandsGroupBox.Location = new System.Drawing.Point(949, 12);
            this.BrandsGroupBox.Name = "BrandsGroupBox";
            this.BrandsGroupBox.Size = new System.Drawing.Size(303, 269);
            this.BrandsGroupBox.TabIndex = 3;
            this.BrandsGroupBox.TabStop = false;
            this.BrandsGroupBox.Text = "{Brands}";
            // 
            // SelectedShopSymbolPictureBox
            // 
            this.SelectedShopSymbolPictureBox.Location = new System.Drawing.Point(353, 23);
            this.SelectedShopSymbolPictureBox.Name = "SelectedShopSymbolPictureBox";
            this.SelectedShopSymbolPictureBox.Size = new System.Drawing.Size(80, 80);
            this.SelectedShopSymbolPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SelectedShopSymbolPictureBox.TabIndex = 19;
            this.SelectedShopSymbolPictureBox.TabStop = false;
            // 
            // ShopEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.BrandsGroupBox);
            this.Controls.Add(this.ShopGoodsGroupBox);
            this.Controls.Add(this.ShopDataGroupBox);
            this.Controls.Add(this.ShopListGroupBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShopEditor";
            this.Text = "ShopEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShopEditor_FormClosing);
            this.ShopListGroupBox.ResumeLayout(false);
            this.ShopDataGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SelectedShopTimesUsedNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedShopSymbolPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ShopListGroupBox;
        private System.Windows.Forms.GroupBox ShopDataGroupBox;
        private System.Windows.Forms.GroupBox ShopGoodsGroupBox;
        private System.Windows.Forms.ListView ShopListListView;
        private System.Windows.Forms.GroupBox BrandsGroupBox;
        private System.Windows.Forms.ColumnHeader IdHeader;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader CategoryHeader;
        private System.Windows.Forms.RichTextBox SelectedShopNameRichTextBox;
        private System.Windows.Forms.RichTextBox SelectedShopCatRichTextBox;
        private System.Windows.Forms.NumericUpDown SelectedShopTimesUsedNumUpDown;
        private System.Windows.Forms.Label SelectedShopTimesUsedLabel;
        private System.Windows.Forms.Label SelectedShopLastFoodCharacter1Label;
        private System.Windows.Forms.Label SelectedShopLastFoodsTitleLabel;
        private System.Windows.Forms.ComboBox SelectedShopLastFoodCharacter7ComboBox;
        private System.Windows.Forms.Label SelectedShopLastFoodCharacter7Label;
        private System.Windows.Forms.ComboBox SelectedShopLastFoodCharacter6ComboBox;
        private System.Windows.Forms.Label SelectedShopLastFoodCharacter6Label;
        private System.Windows.Forms.ComboBox SelectedShopLastFoodCharacter5ComboBox;
        private System.Windows.Forms.Label SelectedShopLastFoodCharacter5Label;
        private System.Windows.Forms.ComboBox SelectedShopLastFoodCharacter4ComboBox;
        private System.Windows.Forms.Label SelectedShopLastFoodCharacter4Label;
        private System.Windows.Forms.ComboBox SelectedShopLastFoodCharacter3ComboBox;
        private System.Windows.Forms.Label SelectedShopLastFoodCharacter3Label;
        private System.Windows.Forms.ComboBox SelectedShopLastFoodCharacter2ComboBox;
        private System.Windows.Forms.Label SelectedShopLastFoodCharacter2Label;
        private System.Windows.Forms.ComboBox SelectedShopLastFoodCharacter1ComboBox;
        private System.Windows.Forms.PictureBox SelectedShopSymbolPictureBox;
    }
}