using NTwewyDb;
using Scramble.Classes;
using Scramble.Properties;
using System;
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

        private int InfoIndex = 0;
        private bool WarnedAboutSpoilerCheck = false;

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
            this.SkillUnlocked_Checkbox.Text = Sukuranburu.GetString("{Unlocked}");
        }

        private void BuildSkillTree(int ParentId, TreeNode ParentNode)
        {
            var SkillTreeItems = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItems(ParentId);

            foreach (SkillTree Item in SkillTreeItems.Values)
            {
                TreeNode Node = new TreeNode();
                Node.Name = string.Format("SkillTree{0}Node", Item.Id);
                Node.Tag = (ushort)Item.Id;

                if (ParentNode == null)
                {
                    SkillTreeView.Nodes.Add(Node);
                }
                else
                {
                    ParentNode.Nodes.Add(Node);
                }

                // do something with the save

                if (Sukuranburu.ShowSpoilers == false && Node.Checked == false)
                {
                    Node.Text = Sukuranburu.GetString("{Spoiler}");
                }
                else
                {
                    Node.Text = ReplaceStringTags(Sukuranburu.GetGameString(Item.CharacterName));
                }

                BuildSkillTree(Item.Id, Node);

                if (ParentId < 1)
                {
                    Node.Expand();
                }
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

            if (Sukuranburu.ShowSpoilers == false && Node.Checked == false)
            {
                this.CharacterNameLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.CharacterInfoLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.TimeframeValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.LocationValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.Character_PictureBox.Image = Resources.ResourceManager.GetObject("CHR_Spoiler") as Bitmap;
                this.ShowMoreInfoButton.Enabled = false;
            }
            else
            {
                this.CharacterNameLabel.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.CharacterName));
                this.CharacterInfoLabel.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()));
                this.TimeframeValueLabel.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.DayText));
                this.LocationValueLabel.Text = Sukuranburu.GetGameString(TreeItem.PlaceText);
                this.Character_PictureBox.Image = Resources.ResourceManager.GetObject(TreeItem.CharacterIcon) as Bitmap;

                if (TreeItem.CharacterInfo.Length > 1)
                {
                    this.ShowMoreInfoButton.Enabled = true;
                }
                else
                {
                    this.ShowMoreInfoButton.Enabled = false;
                }
            }

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
            if (SkillItem.Info == "Com_ItemName" && SkillItem.ShopReward > 0)
            {
                IGameItem GameItem = Sukuranburu.GetItemManager().GetItem((ushort)SkillItem.ShopReward);
                if (GameItem != null)
                {
                    this.SkillInfo_Label.Text = ReplaceStringTags(Sukuranburu.GetGameString(GameItem.Name));
                }
                else
                {
                    this.SkillInfo_Label.Text = SkillItem.ShopReward.ToString(); // or what could I do here?
                }
            }
            else
            {
                this.SkillInfo_Label.Text = ReplaceStringTags(Sukuranburu.GetGameString(SkillItem.Info));
            }

            this.FpValue_Label.Text = SkillItem.PointsRequired.ToString();
        }

        private void DisplayEmptyNode()
        {
            this.CharacterNameLabel.Text = Sukuranburu.GetString("{NoSelectedCharacter}");
            this.CharacterInfoLabel.Text = "—";
            this.TimeframeValueLabel.Text = "—";
            this.LocationValueLabel.Text = "—";
            this.Character_PictureBox.Image = null;
            this.ShowMoreInfoButton.Enabled = false;

            DisplayEmptySkill();
        }

        private void DisplayEmptySkill()
        {
            this.RewardName_Label.Text = "—";
            this.SkillInfo_Label.Text = "—";
            this.FpValue_Label.Text = "0";
        }

        private string ReplaceStringTags(string Text)
        {
            return Text.Replace("<BR>", "\n").Replace("<MK_11>", "\"").Replace("<MK_1>", "*");
        }

        private void SkillTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisplayNode(e.Node);
        }

        private void ShowMoreInfoButton_Click(object sender, EventArgs e)
        {
            TreeNode Node = SkillTreeView.SelectedNode;
            if (Node == null)
            {
                // Display empty node?
                return;
            }

            ushort NodeId = (ushort)Node.Tag;
            SkillTree TreeItem = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItem(NodeId);

            if (TreeItem == null)
            {
                return;
            }

            if (Sukuranburu.ShowSpoilers == false && Node.Checked == false)
            {
                return; // bruh
            }

            if (TreeItem.CharacterInfo.Length > (InfoIndex + 1))
            {
                this.CharacterInfoLabel.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.CharacterInfo[++InfoIndex]));
            }
            else
            {
                InfoIndex = 0;
                this.CharacterInfoLabel.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()));
            }
        }

        private void SkillTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            TreeNode Node = e.Node;
            if (Node == null)
            {
                ReadyForUserInput = true;
                return;
            }

            if (Sukuranburu.ShowSpoilers == false && Node.Checked == true)
            {
                if (WarnedAboutSpoilerCheck == false && !Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_Social_SpoilersWarn")))
                {
                    Node.Checked = false;
                    ReadyForUserInput = true;
                    return;
                }

                WarnedAboutSpoilerCheck = true;

                SkillTree TreeItem = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItem((ushort)Node.Tag);

                if (TreeItem != null)
                {
                    Node.Text = ReplaceStringTags(Sukuranburu.GetGameString(TreeItem.CharacterName));
                }

                if (Node.IsSelected)
                {
                    DisplayNode(Node);
                }
            }

            // update in save file.

            ReadyForUserInput = true;
        }
    }
}
