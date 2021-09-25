using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Properties;
using System;
using System.Drawing;
using System.Threading;
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
            RandomizeMoney_Checkbox.Text = Sukuranburu.GetString("{RandomizeMoney}");
            RandomizeExperience_Checkbox.Text = Sukuranburu.GetString("{RandomizeExperience}");
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
            RandomizeMoney_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Ok}");
            RandomizeMoney_StatusLabel.ForeColor = Color.Green;
            RandomizeExperience_StatusLabel.Text = Sukuranburu.GetString("{RandomizerChoice_Ok}");
            RandomizeExperience_StatusLabel.ForeColor = Color.Green;
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
            Invoke(new Action(() => { DicePictureBox.Visible = true; WaitMessage.Text = GameRandomizer.GetWaitingMessage(); }));

            while (RandomizerProgressBar.Value != RandomizerProgressBar.Maximum)
            {
            }

            Thread.Sleep(1500);
            Invoke(new Action(() => { DicePictureBox.Visible = false; WaitMessage.Text = string.Empty; }));
        }

        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            RandomizeButton.Enabled = false;
            RandomizerProgressBar.Value = 0;
            RandomizerProgressBar.Maximum = Convert.ToByte(RandomizeMoney_Checkbox.Checked) + Convert.ToByte(RandomizeExperience_Checkbox.Checked) + Convert.ToByte(RandomizeDay_Checkbox.Checked) + Convert.ToByte(RandomizeParty_Checkbox.Checked) + Convert.ToByte(RandomizePins_Checkbox.Checked) + Convert.ToByte(RandomizeClothing_Checkbox.Checked) + Convert.ToByte(RandomizeSkills_Checkbox.Checked) + Convert.ToByte(RandomizeSocialTree_Checkbox.Checked) + Convert.ToByte(RandomizeTrophies_Checkbox.Checked);
            RandomizerChaos LevelOfChaos = (RandomizerChaos)LevelOfChaos_Trackbar.Value;

            Task.Factory.StartNew(ShowDice);

            if (RandomizeMoney_Checkbox.Checked)
            {
                GameRandomizer.RandomizeMoney(LevelOfChaos);
                RandomizerProgressBar.Value += 1;
            }

            if (RandomizeExperience_Checkbox.Checked)
            {
                GameRandomizer.RandomizeExperience(LevelOfChaos);
                RandomizerProgressBar.Value += 1;
            }

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
                GameRandomizer.RandomizeClothing(LevelOfChaos);
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

            RandomizerProgressBar.Value = RandomizerProgressBar.Maximum;
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
