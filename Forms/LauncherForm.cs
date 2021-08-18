using NTwewyDb;
using Scramble.Legacy;
using Scramble.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Scramble.Util;

namespace Scramble.Forms
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            NTWEWY_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Logo_NTWEWY") as Bitmap, 200, 200, DeviceDpi);
            TWEWYFR_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Logo_TWEWYFR") as Bitmap, 200, 200, DeviceDpi);
            Convert_FromSoloRemix_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Convert_SR_to_FR") as Bitmap, 194, 23, DeviceDpi);
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
    }
}
