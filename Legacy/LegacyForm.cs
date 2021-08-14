﻿using NTwewyDb;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scramble.Legacy
{
    public partial class LegacyForm : Form
    {
        public double ScaleFactor
        {
            get;
            private set;
        }

        private LegacyStatsEditor StatsEditor;

        public bool RequiresRescaling => ScaleFactor != 1.0;

        public LegacySave OpenedSaveFile;
        private bool ReadyForUserInput = false;

        public LegacyForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Logo_PictureBox.Image = ImageMethods.DrawImage(Properties.Resources.ResourceManager.GetObject("Logo_Legacy") as Bitmap, 139, 74, DeviceDpi);

            SetUpGraphics();
            ChangeFormSize(135, 333);

            ReadyForUserInput = true;
        }

        public void SetUpGraphics()
        {
            ScaleFactor = (double)DeviceDpi / (double)96;
            DpiChanged += new DpiChangedEventHandler(LegacyForm_DpiChanged);
        }

        private void ChangeFormSize(int Height, int Width)
        {
            if (RequiresRescaling)
            {
                this.Height = (int)Math.Floor(Height * ScaleFactor);
                this.Width = (int)Math.Floor(Width * ScaleFactor) - 2;
            }
            else
            {
                this.Height = Height;
                this.Width = Width;
            }
        }

        public void ShowWarning(string Message)
        {
            MessageBox.Show(Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowNotice(string Message)
        {
            MessageBox.Show(Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool ShowPrompt(string Message)
        {
            return MessageBox.Show(Message, "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void LegacyForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            ScaleFactor = DeviceDpi / 96;
            ChangeFormSize(Height, Width);
        }

        private void OpenSaveFileButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }
            else if (OpenedSaveFile != null && ShowPrompt("There's a save file opened already. If you didn't save changes, they will be lost. Continue?") == false)
            {
                return;
            }

            ReadyForUserInput = false;
            OpenFileDialog Dialog = new OpenFileDialog();

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(Dialog.FileName))
                {
                    ShowWarning("The file could not be found.");
                    ReadyForUserInput = true;
                    return;
                }

                byte[] AllData = File.ReadAllBytes(Dialog.FileName);

                OpenedSaveFile = new LegacySave(AllData, Dialog.FileName, out byte Result);

                if (Result == 0) // invalid file size
                {
                    ShowWarning("Invalid file size. It should be 51,252 bytes.");
                    OpenedSaveFile = null;

                    ChangeFormSize(135, 333);
                    ReadyForUserInput = true;
                    return;
                }

                ChangeFormSize(270, 500);
                Text = "Scramble — TWEWY Final Remix Save Editor";
            }

            ReadyForUserInput = true;
        }

        private void SaveChanges_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || OpenedSaveFile == null)
            {
                return;
            }
            else
            {
                if (File.Exists(OpenedSaveFile.FilePath))
                {
                    File.Copy(OpenedSaveFile.FilePath, OpenedSaveFile.FilePath + " (" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ").bak");
                }
                else
                {
                    ShowWarning("I couldn't make a backup file. The original save file no longer exists for some reason.");
                }
            }

            ReadyForUserInput = false;

            if (File.Exists(OpenedSaveFile.FilePath))
            {
                File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
                ShowNotice("Changes saved successfully.");
            }
            else
            {
                SaveFileDialog NewDialog = new SaveFileDialog
                {
                    FileName = "gamesave",
                    AddExtension = false
                };

                if (NewDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenedSaveFile.FilePath = NewDialog.FileName;
                    File.WriteAllBytes(OpenedSaveFile.FilePath, OpenedSaveFile.ToBytes());
                    ShowNotice("Changes saved successfully.");
                }
            }

            ReadyForUserInput = true;
        }

        private void VersionLabel_Click(object sender, EventArgs e)
        {
            OpenSite("https://github.com/supremetakoyaki/Scramble");
        }

        private void OpenSite(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void OpenStatsEditor_Button_Click(object sender, EventArgs e)
        {
            StatsEditor = new LegacyStatsEditor();
            StatsEditor.ShowDialog();
        }

        private void ThankYou_Label_MouseEnter(object sender, EventArgs e)
        {
            ThankYou_Label.ForeColor = Color.DarkSlateBlue;
        }

        private void ThankYou_Label_MouseLeave(object sender, EventArgs e)
        {
            ThankYou_Label.ForeColor = SystemColors.Control;
        }

        private void DumpData_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SaveFileDialog DumpDialog = new SaveFileDialog
            {
                Filter = "Scramble TWEWY Final Remix Data (*.finalremix)|*.finalremix",
                DefaultExt = "finalremix",
                AddExtension = true
            };

            if (DumpDialog.ShowDialog() == DialogResult.OK)
            {
                OpenedSaveFile.DumpData(DumpDialog.FileName);
                ShowNotice("The save data has been dumped successfully.");
            }
        }

        private void ImportData_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            OpenFileDialog ImportDialog = new OpenFileDialog
            {
                Filter = "Scramble TWEWY Final Remix Data (*.finalremix)|*.finalremix",
                DefaultExt = "finalremix",
                AddExtension = true
            };

            if (ImportDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] ImportedData = File.ReadAllBytes(ImportDialog.FileName);

                    if (ImportedData.Length != 51188)
                    {
                        ShowWarning("This is an invalid data file. Size must be 51,188 bytes.");
                        return;
                    }

                    if (ShowPrompt("Do you wanna overwrite the current data for this save file?"))
                    {
                        OpenedSaveFile.ImportData(ImportedData);
                    }
                }
                catch (Exception Exc)
                {
                    ShowWarning(Exc.Message);
                    return;
                }
            }
        }
    }
}