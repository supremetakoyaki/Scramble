﻿
namespace Scramble.Forms
{
    partial class RecordsEditor
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
            this.RecordInvListView = new System.Windows.Forms.ListView();
            this.SaveIDHeader = new System.Windows.Forms.ColumnHeader();
            this.ItemIDHeader = new System.Windows.Forms.ColumnHeader();
            this.ItemNameHeader = new System.Windows.Forms.ColumnHeader();
            this.UnlockedHeader = new System.Windows.Forms.ColumnHeader();
            this.FlagHeader = new System.Windows.Forms.ColumnHeader();
            this.UnlockAllButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RecordInvListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // RecordInvListView
            // 
            this.RecordInvListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SaveIDHeader,
            this.ItemIDHeader,
            this.ItemNameHeader,
            this.UnlockedHeader,
            this.FlagHeader});
            this.RecordInvListView.HideSelection = false;
            this.RecordInvListView.Location = new System.Drawing.Point(6, 22);
            this.RecordInvListView.Name = "RecordInvListView";
            this.RecordInvListView.Size = new System.Drawing.Size(496, 302);
            this.RecordInvListView.TabIndex = 0;
            this.RecordInvListView.UseCompatibleStateImageBehavior = false;
            this.RecordInvListView.View = System.Windows.Forms.View.Details;
            // 
            // SaveIDHeader
            // 
            this.SaveIDHeader.Text = "Save ID";
            // 
            // ItemIDHeader
            // 
            this.ItemIDHeader.Text = "Item ID";
            // 
            // ItemNameHeader
            // 
            this.ItemNameHeader.Text = "Name";
            // 
            // UnlockedHeader
            // 
            this.UnlockedHeader.Text = "Unlocked";
            // 
            // FlagHeader
            // 
            this.FlagHeader.Text = "Flag";
            // 
            // UnlockAllButton
            // 
            this.UnlockAllButton.Location = new System.Drawing.Point(12, 348);
            this.UnlockAllButton.Name = "UnlockAllButton";
            this.UnlockAllButton.Size = new System.Drawing.Size(102, 23);
            this.UnlockAllButton.TabIndex = 1;
            this.UnlockAllButton.Text = "Unlock all";
            this.UnlockAllButton.UseVisualStyleBackColor = true;
            this.UnlockAllButton.Click += new System.EventHandler(this.UnlockAllButton_Click);
            // 
            // RecordsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 383);
            this.Controls.Add(this.UnlockAllButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RecordsEditor";
            this.Text = "Records Editor";
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
    }
}