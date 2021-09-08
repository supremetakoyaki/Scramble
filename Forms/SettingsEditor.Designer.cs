
namespace Scramble.Forms
{
    partial class SettingsEditor
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
            this.VolumeGroupBox = new System.Windows.Forms.GroupBox();
            this.VaVolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.VaVol_Label = new System.Windows.Forms.Label();
            this.SfxVolTrackBar = new System.Windows.Forms.TrackBar();
            this.SfxVol_Label = new System.Windows.Forms.Label();
            this.MusicVolTrackBar = new System.Windows.Forms.TrackBar();
            this.MusicVol_Label = new System.Windows.Forms.Label();
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.Subtitles_Checkbox = new System.Windows.Forms.CheckBox();
            this.DialogueAutoPlay_Checkbox = new System.Windows.Forms.CheckBox();
            this.ControllerVibration_Checkbox = new System.Windows.Forms.CheckBox();
            this.Other_Label = new System.Windows.Forms.Label();
            this.EnglishVa_RadioButton = new System.Windows.Forms.RadioButton();
            this.JapaneseVa_RadioButton = new System.Windows.Forms.RadioButton();
            this.VaLanguage_Label = new System.Windows.Forms.Label();
            this.VolumeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VaVolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SfxVolTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolTrackBar)).BeginInit();
            this.GeneralGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // VolumeGroupBox
            // 
            this.VolumeGroupBox.Controls.Add(this.VaVolumeTrackBar);
            this.VolumeGroupBox.Controls.Add(this.VaVol_Label);
            this.VolumeGroupBox.Controls.Add(this.SfxVolTrackBar);
            this.VolumeGroupBox.Controls.Add(this.SfxVol_Label);
            this.VolumeGroupBox.Controls.Add(this.MusicVolTrackBar);
            this.VolumeGroupBox.Controls.Add(this.MusicVol_Label);
            this.VolumeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.VolumeGroupBox.Name = "VolumeGroupBox";
            this.VolumeGroupBox.Size = new System.Drawing.Size(260, 195);
            this.VolumeGroupBox.TabIndex = 0;
            this.VolumeGroupBox.TabStop = false;
            this.VolumeGroupBox.Text = "{Volume}";
            // 
            // VaVolumeTrackBar
            // 
            this.VaVolumeTrackBar.Location = new System.Drawing.Point(134, 137);
            this.VaVolumeTrackBar.Name = "VaVolumeTrackBar";
            this.VaVolumeTrackBar.Size = new System.Drawing.Size(120, 45);
            this.VaVolumeTrackBar.TabIndex = 5;
            this.VaVolumeTrackBar.TickFrequency = 2;
            this.VaVolumeTrackBar.ValueChanged += new System.EventHandler(this.VaVolumeTrackBar_ValueChanged);
            // 
            // VaVol_Label
            // 
            this.VaVol_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.VaVol_Label.Location = new System.Drawing.Point(6, 137);
            this.VaVol_Label.Name = "VaVol_Label";
            this.VaVol_Label.Size = new System.Drawing.Size(122, 24);
            this.VaVol_Label.TabIndex = 4;
            this.VaVol_Label.Text = "{VaVol:}";
            this.VaVol_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SfxVolTrackBar
            // 
            this.SfxVolTrackBar.Location = new System.Drawing.Point(134, 86);
            this.SfxVolTrackBar.Name = "SfxVolTrackBar";
            this.SfxVolTrackBar.Size = new System.Drawing.Size(120, 45);
            this.SfxVolTrackBar.TabIndex = 3;
            this.SfxVolTrackBar.TickFrequency = 2;
            this.SfxVolTrackBar.ValueChanged += new System.EventHandler(this.SfxVolTrackBar_ValueChanged);
            // 
            // SfxVol_Label
            // 
            this.SfxVol_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfxVol_Label.Location = new System.Drawing.Point(6, 86);
            this.SfxVol_Label.Name = "SfxVol_Label";
            this.SfxVol_Label.Size = new System.Drawing.Size(122, 24);
            this.SfxVol_Label.TabIndex = 2;
            this.SfxVol_Label.Text = "{SfxVol:}";
            this.SfxVol_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MusicVolTrackBar
            // 
            this.MusicVolTrackBar.Location = new System.Drawing.Point(134, 35);
            this.MusicVolTrackBar.Name = "MusicVolTrackBar";
            this.MusicVolTrackBar.Size = new System.Drawing.Size(120, 45);
            this.MusicVolTrackBar.TabIndex = 1;
            this.MusicVolTrackBar.TickFrequency = 2;
            this.MusicVolTrackBar.ValueChanged += new System.EventHandler(this.MusicVolTrackBar_ValueChanged);
            // 
            // MusicVol_Label
            // 
            this.MusicVol_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.MusicVol_Label.Location = new System.Drawing.Point(6, 35);
            this.MusicVol_Label.Name = "MusicVol_Label";
            this.MusicVol_Label.Size = new System.Drawing.Size(122, 24);
            this.MusicVol_Label.TabIndex = 0;
            this.MusicVol_Label.Text = "{MusicVol:}";
            this.MusicVol_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GeneralGroupBox
            // 
            this.GeneralGroupBox.Controls.Add(this.Subtitles_Checkbox);
            this.GeneralGroupBox.Controls.Add(this.DialogueAutoPlay_Checkbox);
            this.GeneralGroupBox.Controls.Add(this.ControllerVibration_Checkbox);
            this.GeneralGroupBox.Controls.Add(this.Other_Label);
            this.GeneralGroupBox.Controls.Add(this.EnglishVa_RadioButton);
            this.GeneralGroupBox.Controls.Add(this.JapaneseVa_RadioButton);
            this.GeneralGroupBox.Controls.Add(this.VaLanguage_Label);
            this.GeneralGroupBox.Location = new System.Drawing.Point(12, 213);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Size = new System.Drawing.Size(260, 196);
            this.GeneralGroupBox.TabIndex = 1;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "{General}";
            // 
            // Subtitles_Checkbox
            // 
            this.Subtitles_Checkbox.AutoSize = true;
            this.Subtitles_Checkbox.Location = new System.Drawing.Point(6, 164);
            this.Subtitles_Checkbox.Name = "Subtitles_Checkbox";
            this.Subtitles_Checkbox.Size = new System.Drawing.Size(79, 19);
            this.Subtitles_Checkbox.TabIndex = 6;
            this.Subtitles_Checkbox.Text = "{Subtitles}";
            this.Subtitles_Checkbox.UseVisualStyleBackColor = true;
            this.Subtitles_Checkbox.CheckedChanged += new System.EventHandler(this.Subtitles_Checkbox_CheckedChanged);
            // 
            // DialogueAutoPlay_Checkbox
            // 
            this.DialogueAutoPlay_Checkbox.AutoSize = true;
            this.DialogueAutoPlay_Checkbox.Location = new System.Drawing.Point(6, 139);
            this.DialogueAutoPlay_Checkbox.Name = "DialogueAutoPlay_Checkbox";
            this.DialogueAutoPlay_Checkbox.Size = new System.Drawing.Size(129, 19);
            this.DialogueAutoPlay_Checkbox.TabIndex = 5;
            this.DialogueAutoPlay_Checkbox.Text = "{DialogueAutoplay}";
            this.DialogueAutoPlay_Checkbox.UseVisualStyleBackColor = true;
            this.DialogueAutoPlay_Checkbox.CheckedChanged += new System.EventHandler(this.DialogueAutoPlay_Checkbox_CheckedChanged);
            // 
            // ControllerVibration_Checkbox
            // 
            this.ControllerVibration_Checkbox.AutoSize = true;
            this.ControllerVibration_Checkbox.Location = new System.Drawing.Point(6, 114);
            this.ControllerVibration_Checkbox.Name = "ControllerVibration_Checkbox";
            this.ControllerVibration_Checkbox.Size = new System.Drawing.Size(135, 19);
            this.ControllerVibration_Checkbox.TabIndex = 2;
            this.ControllerVibration_Checkbox.Text = "{ControllerVibration}";
            this.ControllerVibration_Checkbox.UseVisualStyleBackColor = true;
            this.ControllerVibration_Checkbox.CheckedChanged += new System.EventHandler(this.ControllerVibration_Checkbox_CheckedChanged);
            // 
            // Other_Label
            // 
            this.Other_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Other_Label.Location = new System.Drawing.Point(6, 88);
            this.Other_Label.Name = "Other_Label";
            this.Other_Label.Size = new System.Drawing.Size(242, 23);
            this.Other_Label.TabIndex = 4;
            this.Other_Label.Text = "{Other:}";
            // 
            // EnglishVa_RadioButton
            // 
            this.EnglishVa_RadioButton.Location = new System.Drawing.Point(140, 54);
            this.EnglishVa_RadioButton.Name = "EnglishVa_RadioButton";
            this.EnglishVa_RadioButton.Size = new System.Drawing.Size(114, 19);
            this.EnglishVa_RadioButton.TabIndex = 3;
            this.EnglishVa_RadioButton.Text = "{English}";
            this.EnglishVa_RadioButton.UseVisualStyleBackColor = true;
            this.EnglishVa_RadioButton.CheckedChanged += new System.EventHandler(this.EnglishVa_RadioButton_CheckedChanged);
            // 
            // JapaneseVa_RadioButton
            // 
            this.JapaneseVa_RadioButton.Location = new System.Drawing.Point(6, 54);
            this.JapaneseVa_RadioButton.Name = "JapaneseVa_RadioButton";
            this.JapaneseVa_RadioButton.Size = new System.Drawing.Size(114, 19);
            this.JapaneseVa_RadioButton.TabIndex = 2;
            this.JapaneseVa_RadioButton.Text = "{Japanese}";
            this.JapaneseVa_RadioButton.UseVisualStyleBackColor = true;
            this.JapaneseVa_RadioButton.CheckedChanged += new System.EventHandler(this.JapaneseVa_RadioButton_CheckedChanged);
            // 
            // VaLanguage_Label
            // 
            this.VaLanguage_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.VaLanguage_Label.Location = new System.Drawing.Point(6, 28);
            this.VaLanguage_Label.Name = "VaLanguage_Label";
            this.VaLanguage_Label.Size = new System.Drawing.Size(242, 23);
            this.VaLanguage_Label.TabIndex = 2;
            this.VaLanguage_Label.Text = "{VoiceLanguage:}";
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 421);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.VolumeGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsEditor";
            this.Text = "{SettingsEditor}";
            this.VolumeGroupBox.ResumeLayout(false);
            this.VolumeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VaVolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SfxVolTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicVolTrackBar)).EndInit();
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox VolumeGroupBox;
        private System.Windows.Forms.TrackBar MusicVolTrackBar;
        private System.Windows.Forms.Label MusicVol_Label;
        private System.Windows.Forms.Label SfxVol_Label;
        private System.Windows.Forms.TrackBar SfxVolTrackBar;
        private System.Windows.Forms.Label VaVol_Label;
        private System.Windows.Forms.TrackBar VaVolumeTrackBar;
        private System.Windows.Forms.GroupBox GeneralGroupBox;
        private System.Windows.Forms.CheckBox ControllerVibration_Checkbox;
        private System.Windows.Forms.Label Other_Label;
        private System.Windows.Forms.RadioButton EnglishVa_RadioButton;
        private System.Windows.Forms.RadioButton JapaneseVa_RadioButton;
        private System.Windows.Forms.Label VaLanguage_Label;
        private System.Windows.Forms.CheckBox DialogueAutoPlay_Checkbox;
        private System.Windows.Forms.CheckBox Subtitles_Checkbox;
    }
}