using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class NeoTwewyRandomizerForm : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private GameRandomizer GameRandomizer;

        public NeoTwewyRandomizerForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            GameRandomizer = new GameRandomizer();

            RandomizerPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("RandomizerOverview_Logo") as Bitmap, 710, 105, DeviceDpi);
            LoadLanguageStrings();
        }

        private void LoadLanguageStrings()
        {
            Text = Sukuranburu.GetString("{NeoTwewyRandomizer}");
            OverviewGroupBox.Text = Sukuranburu.GetString("{RandomizerOverviewTitle}");
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{RandomizerOverviewDesc}"), OverviewRichTextBox);
            RandomizerGroupBox.Text = Sukuranburu.GetString("{Randomizer}");
        }
    }
}
