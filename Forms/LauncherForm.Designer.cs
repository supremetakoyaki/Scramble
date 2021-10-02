
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
            this.components = new System.ComponentModel.Container();
            this.NTWEWY_Button = new System.Windows.Forms.Button();
            this.TWEWYFR_Button = new System.Windows.Forms.Button();
            this.Utilities_GroupBox = new System.Windows.Forms.GroupBox();
            this.UpdateChecker_Label = new System.Windows.Forms.Label();
            this.Convert_FromSoloRemix_Button = new System.Windows.Forms.Button();
            this.ConvertSr2Fr_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NeoTwewy_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TwewyFr_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NeoTwewyUtilButton = new System.Windows.Forms.Button();
            this.NeoTwewyUtilToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Unity3dDecryptEncryptButton = new System.Windows.Forms.Button();
            this.Utilities_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NTWEWY_Button
            // 
            this.NTWEWY_Button.Location = new System.Drawing.Point(10, 10);
            this.NTWEWY_Button.Name = "NTWEWY_Button";
            this.NTWEWY_Button.Size = new System.Drawing.Size(171, 173);
            this.NTWEWY_Button.TabIndex = 1;
            this.NTWEWY_Button.UseVisualStyleBackColor = true;
            this.NTWEWY_Button.Click += new System.EventHandler(this.NTWEWY_Button_Click);
            // 
            // TWEWYFR_Button
            // 
            this.TWEWYFR_Button.Location = new System.Drawing.Point(187, 10);
            this.TWEWYFR_Button.Name = "TWEWYFR_Button";
            this.TWEWYFR_Button.Size = new System.Drawing.Size(171, 173);
            this.TWEWYFR_Button.TabIndex = 2;
            this.TWEWYFR_Button.UseVisualStyleBackColor = true;
            this.TWEWYFR_Button.Click += new System.EventHandler(this.TWEWYFR_Button_Click);
            // 
            // Utilities_GroupBox
            // 
            this.Utilities_GroupBox.Controls.Add(this.UpdateChecker_Label);
            this.Utilities_GroupBox.Location = new System.Drawing.Point(9, 238);
            this.Utilities_GroupBox.Name = "Utilities_GroupBox";
            this.Utilities_GroupBox.Size = new System.Drawing.Size(348, 38);
            this.Utilities_GroupBox.TabIndex = 3;
            this.Utilities_GroupBox.TabStop = false;
            // 
            // UpdateChecker_Label
            // 
            this.UpdateChecker_Label.AutoSize = true;
            this.UpdateChecker_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateChecker_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.UpdateChecker_Label.Location = new System.Drawing.Point(3, 19);
            this.UpdateChecker_Label.Name = "UpdateChecker_Label";
            this.UpdateChecker_Label.Size = new System.Drawing.Size(124, 13);
            this.UpdateChecker_Label.TabIndex = 4;
            this.UpdateChecker_Label.Text = "Checking for updates...";
            this.UpdateChecker_Label.Click += new System.EventHandler(this.UpdateChecker_Label_Click);
            // 
            // Convert_FromSoloRemix_Button
            // 
            this.Convert_FromSoloRemix_Button.Location = new System.Drawing.Point(187, 189);
            this.Convert_FromSoloRemix_Button.Name = "Convert_FromSoloRemix_Button";
            this.Convert_FromSoloRemix_Button.Size = new System.Drawing.Size(171, 20);
            this.Convert_FromSoloRemix_Button.TabIndex = 0;
            this.Convert_FromSoloRemix_Button.UseVisualStyleBackColor = true;
            this.Convert_FromSoloRemix_Button.Click += new System.EventHandler(this.Convert_FromSoloRemix_Button_Click);
            // 
            // ConvertSr2Fr_ToolTip
            // 
            this.ConvertSr2Fr_ToolTip.AutomaticDelay = 250;
            // 
            // NeoTwewy_ToolTip
            // 
            this.NeoTwewy_ToolTip.AutomaticDelay = 250;
            // 
            // TwewyFr_ToolTip
            // 
            this.TwewyFr_ToolTip.AutomaticDelay = 250;
            // 
            // NeoTwewyUtilButton
            // 
            this.NeoTwewyUtilButton.Location = new System.Drawing.Point(9, 189);
            this.NeoTwewyUtilButton.Name = "NeoTwewyUtilButton";
            this.NeoTwewyUtilButton.Size = new System.Drawing.Size(171, 20);
            this.NeoTwewyUtilButton.TabIndex = 4;
            this.NeoTwewyUtilButton.UseVisualStyleBackColor = true;
            this.NeoTwewyUtilButton.Click += new System.EventHandler(this.NeoTwewyUtilButton_Click);
            // 
            // NeoTwewyUtilToolTip
            // 
            this.NeoTwewyUtilToolTip.AutomaticDelay = 250;
            // 
            // Unity3dDecryptEncryptButton
            // 
            this.Unity3dDecryptEncryptButton.Location = new System.Drawing.Point(9, 215);
            this.Unity3dDecryptEncryptButton.Name = "Unity3dDecryptEncryptButton";
            this.Unity3dDecryptEncryptButton.Size = new System.Drawing.Size(171, 20);
            this.Unity3dDecryptEncryptButton.TabIndex = 5;
            this.Unity3dDecryptEncryptButton.UseVisualStyleBackColor = true;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(369, 288);
            this.Controls.Add(this.Unity3dDecryptEncryptButton);
            this.Controls.Add(this.NeoTwewyUtilButton);
            this.Controls.Add(this.Utilities_GroupBox);
            this.Controls.Add(this.Convert_FromSoloRemix_Button);
            this.Controls.Add(this.TWEWYFR_Button);
            this.Controls.Add(this.NTWEWY_Button);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LauncherForm";
            this.Text = "Scramble — Launcher";
            this.Utilities_GroupBox.ResumeLayout(false);
            this.Utilities_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NTWEWY_Button;
        private System.Windows.Forms.Button TWEWYFR_Button;
        private System.Windows.Forms.GroupBox Utilities_GroupBox;
        private System.Windows.Forms.Button Convert_FromSoloRemix_Button;
        private System.Windows.Forms.Label UpdateChecker_Label;
        private System.Windows.Forms.ToolTip ConvertSr2Fr_ToolTip;
        private System.Windows.Forms.ToolTip NeoTwewy_ToolTip;
        private System.Windows.Forms.ToolTip TwewyFr_ToolTip;
        private System.Windows.Forms.Button NeoTwewyUtilButton;
        private System.Windows.Forms.ToolTip NeoTwewyUtilToolTip;
        private System.Windows.Forms.Button Unity3dDecryptEncryptButton;
    }
}