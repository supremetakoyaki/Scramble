using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Properties;
using Scramble.Util;
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

        private SkillTree SelectedSkillTree;

        private int InfoIndex = 0;
        private bool WarnedAboutSpoilerCheck = false;

        private bool ReadyForUserInput = false;
        private bool UnlockAll_Flag = false;

        public SkillTreeEditor()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.ShopLogo_PictureBox.BackColor = Color.Transparent;
            this.ShopLogo_PictureBox.Parent = Character_PictureBox;
            this.ShopLogo_PictureBox.Location = new Point(0, 0);

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
            this.UnlockAllButton.Text = Sukuranburu.GetString("{UnlockAll}");
            this.UnlockAll_ConnectionCheckbox.Text = Sukuranburu.GetString("{Connection}");
            this.UnlockAll_EncounterCheckbox.Text = Sukuranburu.GetString("{Encounter}");
            this.UnlockAll_SkillCheckbox.Text = Sukuranburu.GetString("{Skill}");
            this.ConnectionMadeCheckbox.Text = Sukuranburu.GetString("{ConnectionEstablished}");
            this.SkillUnlocked_Checkbox.Text = Sukuranburu.GetString("{Unlocked}");
            this.FirstEntry_Label.Text = Sukuranburu.GetString("{FirstEntry:}");
            this.ConnectionDay_Label.Text = Sukuranburu.GetString("{Connection:}");
            this.Shop_Label.Text = Sukuranburu.GetString("{Shop:}");
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
                    Node.Text = Sukuranburu.GetGameString(Item.CharacterName);
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

            SelectedSkillTree = TreeItem;

            if (Sukuranburu.ShowSpoilers == false && Node.Checked == false)
            {
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), this.CharacterName_RichTextBox);
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), this.CharacterInfo_RichTextBox);
                this.TimeframeValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.LocationValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.Character_PictureBox.Image = Resources.ResourceManager.GetObject("CHR_Spoiler") as Bitmap;
                this.ShowMoreInfoButton.Enabled = false;

                this.FirstEntryValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                this.ConnectionDayValue_Label.Text = Sukuranburu.GetString("{Spoiler}");

                this.Shop_Label.Visible = false;
                this.ShopName_RichTextBox.Clear();
                this.ShopLogo_PictureBox.Image = null;
            }
            else
            {
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterName), this.CharacterName_RichTextBox);
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()), this.CharacterInfo_RichTextBox);

                this.TimeframeValueLabel.Text = Sukuranburu.GetGameString(TreeItem.DayText);
                this.LocationValueLabel.Text = Sukuranburu.GetGameString(TreeItem.PlaceText);
                this.Character_PictureBox.Image = Resources.ResourceManager.GetObject(TreeItem.CharacterIcon) as Bitmap;

                bool FirstEntryDayValid = false;
                bool ConnectionDayValid = false;

                this.FirstEntryValue_Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetDayName(TreeItem.EntryDay, ref FirstEntryDayValid));
                this.ConnectionDayValue_Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetDayName(TreeItem.ConnectDay, ref ConnectionDayValid));

                if (FirstEntryDayValid)
                {
                    this.FirstEntry_Label.ForeColor = Color.FromArgb(120, 0, 200);
                    this.FirstEntryValue_Label.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    this.FirstEntry_Label.ForeColor = SystemColors.ControlDark;
                    this.FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;
                }

                if (ConnectionDayValid)
                {
                    this.ConnectionDay_Label.ForeColor = Color.FromArgb(75, 50, 190);
                    this.ConnectionDayValue_Label.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    this.ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
                    this.ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;
                }

                if (TreeItem.CharacterInfo.Length > 1)
                {
                    this.ShowMoreInfoButton.Enabled = true;
                }
                else
                {
                    this.ShowMoreInfoButton.Enabled = false;
                }

                if (TreeItem.ShopId != -1)
                {
                    this.Shop_Label.Visible = true;

                    Shop CharacterShop = Sukuranburu.GetItemManager().GetShop(TreeItem.ShopId);
                    if (CharacterShop != null)
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(CharacterShop.Name), this.ShopName_RichTextBox);

                        if (CharacterShop.Brand > 0)
                        {
                            Brand ShopBrand = Sukuranburu.GetItemManager().GetBrand(CharacterShop.Brand);
                            if (ShopBrand != null)
                            {
                                this.ShopLogo_PictureBox.Image = Sukuranburu.Get102x36BrandImageList().Images[string.Format("{0}.png", ShopBrand.Sprite)];
                            }
                            else
                            {
                                this.ShopLogo_PictureBox.Image = null;
                            }
                        }
                        else
                        {
                            this.ShopLogo_PictureBox.Image = null;
                        }
                    }
                    else
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString("Com_Unknown"), this.ShopName_RichTextBox);
                        this.ShopLogo_PictureBox.Image = null;
                    }
                }
                else
                {
                    this.Shop_Label.Visible = false;
                    this.ShopName_RichTextBox.Clear();
                    this.ShopLogo_PictureBox.Image = null;
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
                    this.SkillInfo_Label.Text = Sukuranburu.GetGameString(GameItem.Name);
                }
                else
                {
                    this.SkillInfo_Label.Text = SkillItem.ShopReward.ToString(); // or what could I do here?
                }
            }
            else
            {
                this.SkillInfo_Label.Text = Sukuranburu.GetGameString(SkillItem.Info);
            }

            this.SkillUnlocked_Checkbox.Checked = RetrieveSkillValue(SkillItem);
            this.SkillUnlocked_Checkbox.Enabled = true;

            this.FpValue_Label.Text = SkillItem.PointsRequired.ToString();
        }

        private void DisplayEmptyNode()
        {
            SelectedSkillTree = null;

            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{NoSelectedCharacter}"), this.CharacterName_RichTextBox);
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("—"), this.CharacterInfo_RichTextBox);
            this.TimeframeValueLabel.Text = "—";
            this.LocationValueLabel.Text = "—";
            this.Character_PictureBox.Image = null;
            this.ShowMoreInfoButton.Enabled = false;
            this.Shop_Label.Visible = false;
            this.ShopName_RichTextBox.Clear();
            this.ShopLogo_PictureBox.Image = null;

            DisplayEmptySkill();
        }

        private void DisplayEmptySkill()
        {
            this.RewardName_Label.Text = "—";
            this.SkillInfo_Label.Text = "—";
            this.FpValue_Label.Text = "0";
            this.SkillUnlocked_Checkbox.Checked = false;
            this.SkillUnlocked_Checkbox.Enabled = false;
        }

        private void UpdateSkillValue(Skill SkillItem, bool Value)
        {
            if (SkillItem == null)
            {
                return;
            }
            
            if (SkillItem.SaveIndex > 103)
            {
                throw new ArgumentOutOfRangeException(); // Yeah, not happening unless a new update.
            }

            int OffsetSum = SkillItem.SaveIndex / 8;
            byte ByteToSet = SelectedSlot.RetrieveOffset_Byte(Offsets.Skills_First + OffsetSum);
            byte BitIndex = (byte)(SkillItem.SaveIndex % 8);

            ByteToSet = ByteUtil.SetBit(ByteToSet, BitIndex, Value);
            SelectedSlot.UpdateOffset_Byte(Offsets.Skills_First + OffsetSum, ByteToSet);
        }

        private bool RetrieveSkillValue(Skill SkillItem)
        {
            if (SkillItem == null)
            {
                return false;
            }

            if (SkillItem.SaveIndex > 103)
            {
                throw new ArgumentOutOfRangeException(); // Yeah, not happening unless a new update.
            }

            int OffsetSum = SkillItem.SaveIndex / 8;
            byte ByteToSet = SelectedSlot.RetrieveOffset_Byte(Offsets.Skills_First + OffsetSum);
            byte BitIndex = (byte)(SkillItem.SaveIndex % 8);

            return ByteUtil.GetBit(ByteToSet, BitIndex);
        }

        private void SkillTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ReadyForUserInput = false;

            DisplayNode(e.Node);

            ReadyForUserInput = true;
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
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString(Sukuranburu.GetGameString(TreeItem.CharacterInfo[++InfoIndex])), this.CharacterInfo_RichTextBox);
            }
            else
            {
                InfoIndex = 0;
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault())), this.CharacterInfo_RichTextBox);
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

            if (Sukuranburu.ShowSpoilers == false)
            {
                if (Node.Checked == true)
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
                        Node.Text = Sukuranburu.GetGameString(TreeItem.CharacterName);
                    }
                }
                else
                {
                    SkillTree TreeItem = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItem((ushort)Node.Tag);

                    if (TreeItem != null)
                    {
                        Node.Text = Sukuranburu.GetString("{Spoiler}");
                    }
                }

                if (Node.IsSelected)
                {
                    DisplayNode(Node);
                }
            }

            // update in save file.

            ReadyForUserInput = true;
        }

        private void SkillUnlocked_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            Skill SkillItem = Sukuranburu.GetSocialNetworkManager().GetSkill((ushort)SelectedSkillTree.SkillId);
            if (SkillItem == null)
            {
                SkillUnlocked_Checkbox.Checked = !SkillUnlocked_Checkbox.Checked;
                return;
            }

            UpdateSkillValue(SkillItem, SkillUnlocked_Checkbox.Checked);
        }

        private void UnlockAllButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (!UnlockAll_ConnectionCheckbox.Checked && !UnlockAll_EncounterCheckbox.Checked && !UnlockAll_SkillCheckbox.Checked)
            {
                ReadyForUserInput = true;
                Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_NoCheckboxSelected_SkillTree"));
                return;
            }

            UnlockAll_Flag = !UnlockAll_Flag;

            if (UnlockAll_SkillCheckbox.Checked)
            {
                foreach (Skill SkillItem in Sukuranburu.GetSocialNetworkManager().GetSkills())
                {
                    UpdateSkillValue(SkillItem, UnlockAll_Flag);
                }

                if (SelectedSkillTree != null && SkillUnlocked_Checkbox.Enabled)
                {
                    SkillUnlocked_Checkbox.Checked = UnlockAll_Flag;
                }
            }

            ReadyForUserInput = true;
        }
    }
}
