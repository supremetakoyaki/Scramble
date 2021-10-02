using NTwewyDb;
using Scramble.Legacy;
using Scramble.Properties;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            NTWEWY_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Logo_NTWEWY") as Bitmap, 171, 173, DeviceDpi);
            TWEWYFR_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Logo_TWEWYFR") as Bitmap, 171, 173, DeviceDpi);
            Convert_FromSoloRemix_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Convert_SR_to_FR") as Bitmap, 171, 20, DeviceDpi);
            NeoTwewyUtilButton.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Convert_NeoPC_NeoPS4SW") as Bitmap, 171, 20, DeviceDpi);
            Unity3dDecryptEncryptButton.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Unity3d_Decrypt_Encrypt") as Bitmap, 171, 20, DeviceDpi);

            VersionLabel.Text = Program.ScrambleVersion;
            GithubIconPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("GithubIcon") as Bitmap, 15, 15, DeviceDpi);
            GbaTempIconPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("GbaTempIcon") as Bitmap, 15, 15, DeviceDpi);

            NeoTwewy_ToolTip.SetToolTip(NTWEWY_Button, "\"NEO: The World Ends with You\" Save Editor");
            TwewyFr_ToolTip.SetToolTip(TWEWYFR_Button, "\"The World Ends with You -Final Remix-\" Save Editor");
            ConvertSr2Fr_ToolTip.SetToolTip(Convert_FromSoloRemix_Button, "Convert Solo Remix save file to Final Remix save file");
            NeoTwewyUtilToolTip.SetToolTip(NeoTwewyUtilButton, "Convert between PC and PS4/Switch NEO:TWEWY save files.");
            NeoTwewyUnity3dDecryptToolTip.SetToolTip(Unity3dDecryptEncryptButton, "Decrypt and encrypt .unity3d files from the PC release of NEO:TWEWY");
            GithubIconTooltip.SetToolTip(GithubIconPictureBox, "Open the Scramble repository in GitHub");
            GbaTempIconTooltip.SetToolTip(GbaTempIconPictureBox, "Open the Scramble thread in GBATemp");

            Task.Run(() =>
            {
                TryCheckForUpdates();
            });
        }

        public void TryCheckForUpdates()
        {
            string Message = "Checking for updates. . .";
            Color Colour = SystemColors.ControlText;

            try
            {
                string LatestReleaseUri_Api = "https://api.github.com/repos/supremetakoyaki/Scramble/releases/latest";

                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add("User-Agent", "request");
                    string ApiResponse = Client.DownloadString(LatestReleaseUri_Api);

                    string LatestVersion_str = ApiResponse.Split(new[] { "tag_name" }, StringSplitOptions.None)[1].Substring(4).Split('"')[0];

                    Version CurrentVersion = new Version(Program.ScrambleVersion.Substring(1));
                    Version LatestVersion = new Version(LatestVersion_str);

                    if (CurrentVersion.CompareTo(LatestVersion) < 0)
                    {
                        Message = "There's a new version available!";
                        Colour = Color.DarkBlue;
                    }
                    else
                    {
                        Message = "You're running the latest version.";
                        Colour = Color.Green;
                    }
                }
            }
            catch
            {
                Message = "I couldn't check for updates.";
                Colour = SystemColors.ControlDark;
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    UpdateChecker_Label.ForeColor = Colour;
                    UpdateChecker_Label.Text = Message;
                }));
            }
            else
            {
                UpdateChecker_Label.ForeColor = Colour;
                UpdateChecker_Label.Text = Message;
            }
        }

        private void NTWEWY_Button_Click(object sender, EventArgs e)
        {
            Hide();

            Program.Sukuranburu = new ScrambleForm();
            Program.Sukuranburu.ShowDialog();

            Close();
        }

        private void TWEWYFR_Button_Click(object sender, EventArgs e)
        {
            Hide();

            Program.Legacy = new LegacyForm();
            Program.Legacy.ShowDialog();

            Close();
        }

        private void Convert_FromSoloRemix_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog
            {
                Filter = "TWEWY Solo Remix Save File (*.dat)|*.dat",
                DefaultExt = "dat",
                AddExtension = true
            };

            if (OpenDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            byte[] SoloRemix_SaveFile;

            try
            {
                SoloRemix_SaveFile = File.ReadAllBytes(OpenDialog.FileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show("I couldn't open the file! " + exc.Message);
                return;
            }

            if (!TwewySaveConverter.IsValidSoloRemixSaveFile(SoloRemix_SaveFile))
            {
                MessageBox.Show("This is not a valid TWEWY Solo Remix save file. File size should be 28.5 KB and include the header at the beginning.", "Notice");
                return;
            }

            byte[] ConvertedSave = TwewySaveConverter.FromSoloRemix(SoloRemix_SaveFile);

            SaveFileDialog SaveDialog = new SaveFileDialog
            {
                FileName = "gamesave",
                AddExtension = false
            };

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Solo Remix save file successfully converted to Final Remix save file.", "Notice");
                File.WriteAllBytes(SaveDialog.FileName, ConvertedSave);
                return;
            }
        }

        private void NeoTwewyUtilButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog
            {
                Filter = "NEO TWEWY Save File|*.*",
                AddExtension = true
            };

            if (OpenDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            byte[] SaveFile;

            try
            {
                SaveFile = File.ReadAllBytes(OpenDialog.FileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show("I couldn't open the file! " + exc.Message);
                return;
            }

            if (!NeoTwewySaveConverter.IsValidSaveFile(SaveFile))
            {
                MessageBox.Show("This is not a valid NEO: The World Ends with You save file.", "Notice");
                return;
            }

            byte[] ConvertedSave = NeoTwewySaveConverter.ProcessFile(SaveFile, out bool FromPcVer);

            string OutputFileName = "f1fc4b9d54965358d41213ae8ff0a0f7";
            if (FromPcVer)
            {
                OutputFileName = "gamesave";
            }

            SaveFileDialog SaveDialog = new SaveFileDialog
            {
                FileName = OutputFileName,
                AddExtension = false
            };

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                if (FromPcVer)
                {
                    MessageBox.Show("Save file succesfully converted from PC to PS4/Switch.", "Notice");
                }
                else
                {
                    MessageBox.Show("Save file succesfully converted from PS4/Switch to PC.", "Notice");
                }
                File.WriteAllBytes(SaveDialog.FileName, ConvertedSave);
                return;
            }
        }

        private void Unity3dDecryptEncryptButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog
            {
                Title = "Select one or more Unity Assets",
                Filter = "NEO TWEWY Unity Asset (*.unity3d)|*.unity3d",
                DefaultExt = "unity3d",
                AddExtension = true,
                Multiselect = true
            };

            if (OpenDialog.ShowDialog() != DialogResult.OK || OpenDialog.FileNames.Length == 0)
            {
                return;
            }

            if (OpenDialog.FileNames.Length > 9)
            {
                if (MessageBox.Show("It is possible that this operation may take a long time. Please wait patiently. The program will become unresponsive until the process is done. Continue?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            List<string> ErrorFiles;
            Dictionary<string, byte[]> ProcessedFiles = Unity3dCrypto.ProcessFiles(OpenDialog.FileNames, out ErrorFiles);

            if (ProcessedFiles.Count == 0)
            {
                MessageBox.Show("None of the files were valid.", "Error");
                return;
            }

            SaveFileDialog SaveDialog = new SaveFileDialog
            {
                Title = "Choose an output folder",
                FileName = "Save here"
            };

            if (SaveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string Folder = Path.GetDirectoryName(SaveDialog.FileName);

            foreach (string KeyFileName in ProcessedFiles.Keys)
            {
                File.WriteAllBytes(string.Format("{0}\\{1}", Folder, KeyFileName), ProcessedFiles[KeyFileName]);
            }

            if (ErrorFiles != null && ErrorFiles.Count > 0)
            {
                MessageBox.Show("The following files were not valid and thus were not processed:" + string.Join("\n- ", ErrorFiles), "Notice");
            }

            MessageBox.Show("Done.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateChecker_Label_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://github.com/supremetakoyaki/Scramble/releases/latest");
        }

        private void GithubIconPictureBox_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://github.com/supremetakoyaki/Scramble/");
        }

        private void GbaTempIconPictureBox_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://gbatemp.net/threads/scramble-neo-the-world-ends-with-you-save-editor.591780/");
        }
    }
}
