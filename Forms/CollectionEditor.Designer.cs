using System.Windows.Forms;

namespace Scramble.Forms
{
    partial class CollectionEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChangeSeeStatusButton = new System.Windows.Forms.Button();
            this.UnseeAllButton = new System.Windows.Forms.Button();
            this.ChangeLockStatusButton = new System.Windows.Forms.Button();
            this.RecordInvListView = new System.Windows.Forms.ListView();
            this.ItemNameHeader = new System.Windows.Forms.ColumnHeader();
            this.SaveIDHeader = new System.Windows.Forms.ColumnHeader();
            this.ItemIDHeader = new System.Windows.Forms.ColumnHeader();
            this.TypeHeader = new System.Windows.Forms.ColumnHeader();
            this.UnlockedHeader = new System.Windows.Forms.ColumnHeader();
            this.FlagHeader = new System.Windows.Forms.ColumnHeader();
            this.UnlockAllButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChangeSeeStatusButton);
            this.groupBox1.Controls.Add(this.UnseeAllButton);
            this.groupBox1.Controls.Add(this.ChangeLockStatusButton);
            this.groupBox1.Controls.Add(this.RecordInvListView);
            this.groupBox1.Controls.Add(this.UnlockAllButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // ChangeSeeStatusButton
            // 
            this.ChangeSeeStatusButton.Location = new System.Drawing.Point(461, 363);
            this.ChangeSeeStatusButton.Name = "ChangeSeeStatusButton";
            this.ChangeSeeStatusButton.Size = new System.Drawing.Size(189, 30);
            this.ChangeSeeStatusButton.TabIndex = 4;
            this.ChangeSeeStatusButton.Text = "(Un)see selected";
            this.ChangeSeeStatusButton.UseVisualStyleBackColor = true;
            this.ChangeSeeStatusButton.Click += new System.EventHandler(this.ChangeSeeStatusButton_Click);
            // 
            // UnseeAllButton
            // 
            this.UnseeAllButton.BackColor = System.Drawing.Color.AliceBlue;
            this.UnseeAllButton.Location = new System.Drawing.Point(6, 363);
            this.UnseeAllButton.Name = "UnseeAllButton";
            this.UnseeAllButton.Size = new System.Drawing.Size(189, 30);
            this.UnseeAllButton.TabIndex = 2;
            this.UnseeAllButton.Text = "(Un)see all";
            this.UnseeAllButton.UseVisualStyleBackColor = false;
            this.UnseeAllButton.Click += new System.EventHandler(this.UnseeAllButton_Click);
            // 
            // ChangeLockStatusButton
            // 
            this.ChangeLockStatusButton.Location = new System.Drawing.Point(461, 330);
            this.ChangeLockStatusButton.Name = "ChangeLockStatusButton";
            this.ChangeLockStatusButton.Size = new System.Drawing.Size(189, 30);
            this.ChangeLockStatusButton.TabIndex = 3;
            this.ChangeLockStatusButton.Text = "(Un)lock selected";
            this.ChangeLockStatusButton.UseVisualStyleBackColor = true;
            this.ChangeLockStatusButton.Click += new System.EventHandler(this.ChangeLockStatusButton_Click);
            // 
            // RecordInvListView
            // 
            this.RecordInvListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemNameHeader,
            this.SaveIDHeader,
            this.ItemIDHeader,
            this.TypeHeader,
            this.UnlockedHeader,
            this.FlagHeader});
            this.RecordInvListView.FullRowSelect = true;
            this.RecordInvListView.HideSelection = false;
            this.RecordInvListView.Location = new System.Drawing.Point(6, 22);
            this.RecordInvListView.Name = "RecordInvListView";
            this.RecordInvListView.Size = new System.Drawing.Size(644, 302);
            this.RecordInvListView.TabIndex = 0;
            this.RecordInvListView.UseCompatibleStateImageBehavior = false;
            this.RecordInvListView.View = System.Windows.Forms.View.Details;
            // 
            // ItemNameHeader
            // 
            this.ItemNameHeader.DisplayIndex = 2;
            this.ItemNameHeader.Text = "Name";
            this.ItemNameHeader.Width = 270;
            // 
            // SaveIDHeader
            // 
            this.SaveIDHeader.DisplayIndex = 0;
            this.SaveIDHeader.Text = "Save ID";
            this.SaveIDHeader.Width = 50;
            // 
            // ItemIDHeader
            // 
            this.ItemIDHeader.DisplayIndex = 1;
            this.ItemIDHeader.Text = "Item ID";
            this.ItemIDHeader.Width = 50;
            // 
            // TypeHeader
            // 
            this.TypeHeader.Text = "Type";
            this.TypeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TypeHeader.Width = 70;
            // 
            // UnlockedHeader
            // 
            this.UnlockedHeader.Text = "Unlocked";
            this.UnlockedHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UnlockedHeader.Width = 90;
            // 
            // FlagHeader
            // 
            this.FlagHeader.Text = "Unseen";
            this.FlagHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FlagHeader.Width = 90;
            // 
            // UnlockAllButton
            // 
            this.UnlockAllButton.BackColor = System.Drawing.Color.PaleGreen;
            this.UnlockAllButton.Location = new System.Drawing.Point(6, 330);
            this.UnlockAllButton.Name = "UnlockAllButton";
            this.UnlockAllButton.Size = new System.Drawing.Size(189, 30);
            this.UnlockAllButton.TabIndex = 1;
            this.UnlockAllButton.Text = "(Un)lock all";
            this.UnlockAllButton.UseVisualStyleBackColor = false;
            this.UnlockAllButton.Click += new System.EventHandler(this.UnlockAllButton_Click);
            // 
            // CollectionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 424);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CollectionEditor";
            this.Text = "Collection Editor";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView RecordInvListView;
        private System.Windows.Forms.ColumnHeader SaveIDHeader;
        private System.Windows.Forms.ColumnHeader ItemIDHeader;
        private System.Windows.Forms.ColumnHeader ItemNameHeader;
        private System.Windows.Forms.ColumnHeader UnlockedHeader;
        private System.Windows.Forms.ColumnHeader FlagHeader;
        private System.Windows.Forms.Button UnlockAllButton;
        private Button ChangeLockStatusButton;
        private Button ChangeSeeStatusButton;
        private ColumnHeader TypeHeader;
        private Button UnseeAllButton;
    }
}