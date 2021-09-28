using NTwewyDb;
using Scramble.Legacy;
using Scramble.Properties;
using Scramble.Util;
using System;
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

            NeoTwewy_ToolTip.SetToolTip(NTWEWY_Button, "\"NEO: The World Ends with You\" Save Editor");
            TwewyFr_ToolTip.SetToolTip(TWEWYFR_Button, "\"The World Ends with You -Final Remix-\" Save Editor");
            ConvertSr2Fr_ToolTip.SetToolTip(Convert_FromSoloRemix_Button, "Convert Solo Remix save file to Final Remix save file");
            NeoTwewyUtilToolTip.SetToolTip(NeoTwewyUtilButton, "Convert between PC and PS4/Switch NEO:TWEWY save files.");

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

        private void UpdateChecker_Label_Click(object sender, EventArgs e)
        {
            Program.OpenSite("https://github.com/supremetakoyaki/Scramble");
        }
    }
}
