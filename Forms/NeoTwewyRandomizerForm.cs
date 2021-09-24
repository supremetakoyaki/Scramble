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
            LoadStatusLabels();
        }

        private void LoadLanguageStrings()
        {
            Text = Sukuranburu.GetString("{NeoTwewyRandomizer}");
            OverviewGroupBox.Text = Sukuranburu.GetString("{RandomizerOverviewTitle}");
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{RandomizerOverviewDesc}"), OverviewRichTextBox);
            RandomizerGroupBox.Text = Sukuranburu.GetString("{Randomizer}");
            RandomizeDay_Checkbox.Text = Sukuranburu.GetString("{RandomizeDay}");
            RandomizeParty_Checkbox.Text = Sukuranburu.GetString("{RandomizeParty}");
            RandomizePins_Checkbox.Text = Sukuranburu.GetString("{RandomizePins}");
            RandomizeClothing_Checkbox.Text = Sukuranburu.GetString("{RandomizeClothing}");
            RandomizeSkills_Checkbox.Text = Sukuranburu.GetString("{RandomizeSkills}");
            RandomizeSocialTree_Checkbox.Text = Sukuranburu.GetString("{RandomizeSocialTree}");
            RandomizeTrophies_Checkbox.Text = Sukuranburu.GetString("{RandomizeTrophies}");
            //in the future: RandomizeShop_Checkbox.Text = Sukuranburu.GetString("{RandomizeShop}");
            LevelOfChaos_Label.Text = Sukuranburu.GetString("{LevelOfChaos}");
            RandomizeButton.Text = Sukuranburu.GetString("{RandomizeButton}");
        }

        private void LoadStatusLabels()
        {
            RandomizeDay_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Buggy}");
            RandomizeDay_StatusLabel.ForeColor = Color.DarkGoldenrod;
            RandomizeParty_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_HighlyExperimental}");
            RandomizeParty_StatusLabel.ForeColor = Color.DarkRed;
            RandomizePins_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Ok}");
            RandomizePins_StatusLabel.ForeColor = Color.Green;
            RandomizeClothing_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Ok}");
            RandomizeClothing_StatusLabel.ForeColor = Color.Green;
            RandomizeSkills_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Ok}");
            RandomizeSkills_StatusLabel.ForeColor = Color.Green;
            RandomizeSocialTree_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Ok}");
            RandomizeSocialTree_StatusLabel.ForeColor = Color.Green;
            RandomizeTrophies_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Ok}");
            RandomizeTrophies_StatusLabel.ForeColor = Color.Green;
        }
    }
}
