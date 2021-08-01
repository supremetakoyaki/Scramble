using NTwewyDb;
using Scramble.Classes;
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
    public partial class SkillTreeEditor : Form
    {
        public SaveData SelectedSlot
        {
            get
            {
                return Program.Sukuranburu.SelectedSlot;
            }
        }

        public ScrambleForm Sukuranburu
        {
            get
            {
                return Program.Sukuranburu;
            }
        }

        public SkillTreeEditor()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            DisplayLanguageStrings();
            BuildSkillTree();
        }

        private void DisplayLanguageStrings()
        {
            this.Text = Sukuranburu.GetString("{SocialEditor}");
            this.SkillTreeGroupBox.Text = Sukuranburu.GetString("{SkillTreeMap}");
            this.CharacterInfoGroupBox.Text = Sukuranburu.GetString("{CharacterInfo}");
            this.SkillLabel.Text = Sukuranburu.GetString("{RewardSkill}");
            this.X_Label.Text = Sukuranburu.GetString("{x}");
            this.FpLabel.Text = Sukuranburu.GetString("{FP}");
            this.TimeframeLabel.Text = Sukuranburu.GetString("{Timeframe:}");
            this.LocationLabel.Text = Sukuranburu.GetString("{Location:}");
            this.UnlockAllButton.Text = Sukuranburu.GetString("{UnlockAll_SkillTree}");
            this.UnlockAll_ConnectionCheckbox.Text = Sukuranburu.GetString("{Connection}");
            this.UnlockAll_SkillCheckbox.Text = Sukuranburu.GetString("{Skill}");
            this.ConnectionMadeCheckbox.Text = Sukuranburu.GetString("{ConnectionEstablished}");
        }

        private void BuildSkillTree()
        {
            var SkillTreeItems = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItems(-1);

            foreach (SkillTree Item in SkillTreeItems.Values)
            {
            }
        }
    }
}
