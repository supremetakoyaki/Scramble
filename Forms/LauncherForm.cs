using NTwewyDb;
using Scramble.Properties;
using System;
using System.Drawing;
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

            NTWEWY_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Logo_NTWEWY") as Bitmap, 200, 200, DeviceDpi);
            TWEWYFR_Button.BackgroundImage = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("Logo_TWEWYFR") as Bitmap, 200, 200, DeviceDpi);
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
            //Program.Legacy = new LegacyForm();
            Close();
        }
    }
}
