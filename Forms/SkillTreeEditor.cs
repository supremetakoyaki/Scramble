using NTwewyDb;
using Scramble.Classes;
using Scramble.Properties;
using System.Drawing;
using System.Linq;
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

        private bool ReadyForUserInput = false;

        public SkillTreeEditor()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            if (Sukuranburu.RequiresRescaling)
            {
                SkillTreeView.AutoSize = true;
            }

            DisplayLanguageStrings();
            BuildSkillTree(-1, null);

            ReadyForUserInput = true;
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

        private void BuildSkillTree(int ParentId, TreeNode ParentNode)
        {
            var SkillTreeItems = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItems(ParentId);

            foreach (SkillTree Item in SkillTreeItems.Values)
            {
                TreeNode Node = new TreeNode();
                Node.Text = ReplaceStringTags(Sukuranburu.GetGameString(Item.CharacterName));
                Node.Name = string.Format("SkillTree{0}Node", Item.Id);
                Node.Tag = Item.Id;

                if (ParentNode == null)
                {
                    SkillTreeView.Nodes.Add(Node);
                }
                else
                {
                    ParentNode.Nodes.Add(Node);
                }

                BuildSkillTree(Item.Id, Node);
            }
        }

        private void DisplayNode(TreeNode Node)
        {
            if (Node == null)
            {
                DisplayEmptyNode();
                return;
            }

            ushort NodeId = (ushort)Node.Tag;
            SkillTree TreeItem = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItem(NodeId);

            if (TreeItem == null)
            {
                DisplayEmptyNode();
                return;
            }

            this.CharacterNameLabel.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.CharacterName));
            this.CharacterInfoLabel.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()));
            this.TimeframeValueLabel.Text = Sukuranburu.GetGameString(TreeItem.DayText);
            this.LocationValueLabel.Text = Sukuranburu.GetGameString(TreeItem.PlaceText);

            this.Character_PictureBox.Image = Resources.ResourceManager.GetObject(TreeItem.CharacterIcon) as Bitmap;

            if (TreeItem.SkillId == -1)
            {
                DisplayEmptySkill();
                return;
            }

            Skill SkillItem = Sukuranburu.GetSocialNetworkManager().GetSkill((ushort)TreeItem.SkillId);
            if (SkillItem == null)
            {
                DisplayEmptySkill();
                return;
            }

            this.RewardName_Label.Text = Sukuranburu.GetGameString(SkillItem.Name);
            this.SkillInfo_Label.Text = Sukuranburu.GetGameString(SkillItem.Info);
            this.FpValue_Label.Text = SkillItem.PointsRequired.ToString();
        }

        private void DisplayEmptyNode()
        {
            DisplayEmptySkill();
        }

        private void DisplayEmptySkill()
        {

        }

        private string ReplaceStringTags(string Text)
        {
            return Text.Replace("<BR>", "\n").Replace("<MK_11>", "\"");
        }

        private void SkillTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisplayNode(e.Node);
        }
    }
}
