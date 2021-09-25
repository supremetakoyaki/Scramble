using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Properties;
using System;
using System.Drawing;
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

        private void ShowDice()
        {
            DicePictureBox.Invoke(new Action(() => { DicePictureBox.Visible = true; }));

            while (RandomizerProgressBar.Maximum != 100)
            {
            }

            DicePictureBox.Invoke(new Action(() => { DicePictureBox.Visible = false; }));
        }

        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            RandomizeButton.Enabled = false;
            RandomizerProgressBar.Value = 0;
            RandomizerProgressBar.Maximum = Convert.ToByte(RandomizeDay_Checkbox.Checked) + Convert.ToByte(RandomizeParty_Checkbox.Checked) + Convert.ToByte(RandomizePins_Checkbox.Checked) + Convert.ToByte(RandomizeClothing_Checkbox.Checked) + Convert.ToByte(RandomizeSkills_Checkbox.Checked) + Convert.ToByte(RandomizeSocialTree_Checkbox.Checked) + Convert.ToByte(RandomizeTrophies_Checkbox.Checked);
            RandomizerChaos LevelOfChaos = (RandomizerChaos)LevelOfChaos_Trackbar.Value;

            Task.Factory.StartNew(ShowDice);

            if (RandomizeDay_Checkbox.Checked)
            {
                GameRandomizer.RandomizeDay(LevelOfChaos);
                RandomizerProgressBar.Value += 1;
            }

            if (RandomizeParty_Checkbox.Checked)
            {
                GameRandomizer.RandomizeParty(LevelOfChaos);
                RandomizerProgressBar.Value += 1;
            }

            if (RandomizePins_Checkbox.Checked)
            {
                GameRandomizer.RandomizePins(LevelOfChaos);
                RandomizerProgressBar.Value += 1;
            }

            if (RandomizeClothing_Checkbox.Checked)
            {
                RandomizerProgressBar.Value += 1;
            }

            if (RandomizeSkills_Checkbox.Checked)
            {
                RandomizerProgressBar.Value += 1;
            }

            if (RandomizeSocialTree_Checkbox.Checked)
            {
                RandomizerProgressBar.Value += 1;
            }

            if (RandomizeTrophies_Checkbox.Checked)
            {
                RandomizerProgressBar.Value += 1;
            }

            RandomizerProgressBar.Maximum = 100;
            RandomizerProgressBar.Value = 100;
            RandomizeButton.Enabled = true;
        }
    }

    public enum RandomizerChaos
    {
        Mild = 0,
        Moderate = 1,
        Heavy = 2
    }
}
