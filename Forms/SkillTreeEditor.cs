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
        private TreeNode SelectedNode;

        private int InfoIndex = 0;

        private bool ReadyForUserInput = false;
        private bool UnlockAll_Flag = false;

        public SkillTreeEditor()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.ShopLogo_PictureBox.BackColor = Color.Transparent;
            this.ShopLogo_PictureBox.Parent = Character_PictureBox;
            this.ShopLogo_PictureBox.Location = new Point(0, 0);

            this.LockStatusToolTip.SetToolTip(CharacterLockStatus_Label, Sukuranburu.GetString("{Hint_SkillTree_LockStatus}"));

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
            this.Encountered_Checkbox.Text = Sukuranburu.GetString("{Encounter}");
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

                if (Sukuranburu.ShowSpoilers == false && CharacterIsUnlocked(Item) == 0)
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
            SelectedNode = Node;

            if (Sukuranburu.ShowSpoilers == false && CharacterIsUnlocked(TreeItem) == 0)
            {
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), this.CharacterName_RichTextBox);
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), this.CharacterInfo_RichTextBox);
                InfoIndex = 0;

                this.TimeframeLabel.ForeColor = SystemColors.ControlDark;
                this.LocationLabel.ForeColor = SystemColors.ControlDark;
                this.TimeframeValueLabel.ForeColor = SystemColors.ControlDark;
                this.LocationValueLabel.ForeColor = SystemColors.ControlDark;
                this.TimeframeValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.LocationValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                this.Character_PictureBox.Image = Resources.ResourceManager.GetObject("CHR_Spoiler") as Bitmap;
                this.ShowMoreInfoButton.Enabled = false;
                this.ShowMoreInfoButton.Visible = false;

                this.FirstEntryValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                this.ConnectionDayValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                this.ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
                this.ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;
                this.FirstEntry_Label.ForeColor = SystemColors.ControlDark;
                this.FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;

                this.Shop_Label.Visible = false;
                this.ShopName_RichTextBox.Clear();
                this.ShopLogo_PictureBox.Image = null;

                this.Encountered_Checkbox.Enabled = true;
                this.Encountered_Checkbox.Checked = RetrieveEncounterStatus(Node, TreeItem);
                this.ConnectionMadeCheckbox.Enabled = true;
                this.ConnectionMadeCheckbox.Checked = RetrieveConnectionStatus(Node, TreeItem);

                switch (CharacterIsUnlocked(TreeItem))
                {
                    case 0:
                        this.CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_L}");
                        this.CharacterLockStatus_Label.ForeColor = Color.IndianRed;
                        break;

                    case 1:
                        this.CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_P}");
                        this.CharacterLockStatus_Label.ForeColor = Color.DarkGoldenrod;
                        break;

                    case 2:
                        this.CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_U}");
                        this.CharacterLockStatus_Label.ForeColor = Color.Green;
                        break;
                }
            }
            else
            {
                bool FirstEntryDayValid = false;
                bool ConnectionDayValid = false;

                this.FirstEntryValue_Label.Text = Sukuranburu.GetDayName(TreeItem.EntryDay, ref FirstEntryDayValid);

                if (Sukuranburu.ShowSpoilers == false && CharacterIsUnlocked(TreeItem) == 1)
                {
                    this.TimeframeLabel.ForeColor = SystemColors.ControlDark;
                    this.LocationLabel.ForeColor = SystemColors.ControlDark;
                    this.TimeframeValueLabel.ForeColor = SystemColors.ControlDark;
                    this.LocationValueLabel.ForeColor = SystemColors.ControlDark;

                    this.TimeframeValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                    this.LocationValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                    this.ConnectionDayValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                }
                else
                {
                    this.TimeframeLabel.ForeColor = Color.FromArgb(192, 64, 0);
                    this.LocationLabel.ForeColor = Color.FromArgb(160, 40, 85);
                    this.TimeframeValueLabel.ForeColor = SystemColors.ControlText;
                    this.LocationValueLabel.ForeColor = SystemColors.ControlText;

                    this.TimeframeValueLabel.Text = Sukuranburu.GetGameString(TreeItem.DayText);
                    this.LocationValueLabel.Text = Sukuranburu.GetGameString(TreeItem.PlaceText);
                    this.ConnectionDayValue_Label.Text = Sukuranburu.GetDayName(TreeItem.ConnectDay, ref ConnectionDayValid);
                }

                this.Character_PictureBox.Image = Resources.ResourceManager.GetObject(TreeItem.CharacterIcon) as Bitmap;

                if (Sukuranburu.ShowSpoilers == false)
                {
                    if (CharacterIsUnlocked(TreeItem) < 2)
                    {
                        this.ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
                        this.ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;

                        if (CharacterIsUnlocked(TreeItem) == 0)
                        {
                            this.FirstEntry_Label.ForeColor = SystemColors.ControlDark;
                            this.FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;
                        }
                    }
                    else
                    {
                        this.ConnectionDay_Label.ForeColor = Color.FromArgb(75, 50, 190);
                        this.ConnectionDayValue_Label.ForeColor = SystemColors.ControlText;
                        this.FirstEntry_Label.ForeColor = Color.FromArgb(120, 0, 200);
                        this.FirstEntryValue_Label.ForeColor = SystemColors.ControlText;
                    }
                }
                else
                {
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

                this.Encountered_Checkbox.Enabled = true;
                this.Encountered_Checkbox.Checked = RetrieveEncounterStatus(Node, TreeItem);
                this.ConnectionMadeCheckbox.Enabled = true;
                this.ConnectionMadeCheckbox.Checked = RetrieveConnectionStatus(Node, TreeItem);

                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterName), this.CharacterName_RichTextBox);

                if (Sukuranburu.ShowSpoilers)
                {
                    this.ShowMoreInfoButton.Enabled = true;
                }
                else
                {
                    this.ShowMoreInfoButton.Enabled = false;
                }

                if (Encountered_Checkbox.Checked || ConnectionMadeCheckbox.Checked)
                {
                    if (TreeItem.InfoUpdateIfConnect && TreeItem.CharacterInfo.Length > 1 && ConnectionMadeCheckbox.Checked)
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterInfo[1]), this.CharacterInfo_RichTextBox);
                        this.ShowMoreInfoButton.Enabled = true;
                    }
                    else
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()), this.CharacterInfo_RichTextBox);
                    }
                }
                else
                {
                    Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()), this.CharacterInfo_RichTextBox);
                }

                switch (CharacterIsUnlocked(TreeItem))
                {
                    case 0:
                        this.CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_L}");
                        this.CharacterLockStatus_Label.ForeColor = Color.IndianRed;
                        break;

                    case 1:
                        this.CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_P}");
                        this.CharacterLockStatus_Label.ForeColor = Color.DarkGoldenrod;
                        break;

                    case 2:
                        this.CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_U}");
                        this.CharacterLockStatus_Label.ForeColor = Color.Green;
                        break;
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
            SelectedNode = null;

            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{NoSelectedCharacter}"), this.CharacterName_RichTextBox);
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("—"), this.CharacterInfo_RichTextBox);
            this.TimeframeLabel.ForeColor = SystemColors.ControlDark;
            this.LocationLabel.ForeColor = SystemColors.ControlDark;
            this.TimeframeValueLabel.ForeColor = SystemColors.ControlDark;
            this.LocationValueLabel.ForeColor = SystemColors.ControlDark;
            this.FirstEntry_Label.ForeColor = SystemColors.ControlDark;
            this.FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;
            this.ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
            this.ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;

            this.TimeframeValueLabel.Text = "—";
            this.LocationValueLabel.Text = "—";
            this.FirstEntryValue_Label.Text = "—";
            this.ConnectionDayValue_Label.Text = "—";

            this.Character_PictureBox.Image = null;
            this.ShowMoreInfoButton.Enabled = false;
            this.Shop_Label.Visible = false;
            this.ShopName_RichTextBox.Clear();
            this.ShopLogo_PictureBox.Image = null;
            this.Encountered_Checkbox.Enabled = false;
            this.ConnectionMadeCheckbox.Enabled = false;
            this.CharacterLockStatus_Label.Text = "—";

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

            if (SkillItem.SaveIndex > 128)
            {
                throw new ArgumentOutOfRangeException();
            }

            int OffsetSum = SkillItem.SaveIndex / 8;
            byte ByteToSet = SelectedSlot.RetrieveOffset_Byte(Offsets.Skills_First + OffsetSum);
            byte BitIndex = (byte)(SkillItem.SaveIndex % 8);

            return ByteUtil.GetBit(ByteToSet, BitIndex);
        }

        private void UpdateEncounterStatus(TreeNode Node, SkillTree TreeItem, bool Value)
        {
            if (Node == null || TreeItem == null)
            {
                return;
            }

            if (TreeItem.SaveIndex > 128)
            {
                throw new ArgumentOutOfRangeException();
            }

            int Offset = Offsets.Social_ConnectionStatus_First + TreeItem.SaveIndex;
            byte ValueToSet = SelectedSlot.RetrieveOffset_Byte(Offset);

            ValueToSet = ByteUtil.SetBit(ValueToSet, 7, Value);
            SelectedSlot.UpdateOffset_Byte(Offset, ValueToSet);
        }

        private bool RetrieveEncounterStatus(TreeNode Node, SkillTree TreeItem)
        {
            if (Node == null || TreeItem == null)
            {
                return false;
            }

            if (TreeItem.SaveIndex > 128)
            {
                throw new ArgumentOutOfRangeException();
            }

            int Offset = Offsets.Social_ConnectionStatus_First + TreeItem.SaveIndex;
            return ByteUtil.GetBit(SelectedSlot.RetrieveOffset_Byte(Offset), 7);
        }

        private void UpdateConnectionStatus(TreeNode Node, SkillTree TreeItem, bool Value)
        {
            if (Node == null || TreeItem == null)
            {
                return;
            }

            if (TreeItem.SaveIndex > 128)
            {
                throw new ArgumentOutOfRangeException();
            }

            int Offset = Offsets.Social_ConnectionStatus_First + TreeItem.SaveIndex;
            byte ValueToSet = SelectedSlot.RetrieveOffset_Byte(Offset);

            ValueToSet = ByteUtil.SetBit(ValueToSet, 6, Value);
            SelectedSlot.UpdateOffset_Byte(Offset, ValueToSet);
        }

        private bool RetrieveConnectionStatus(TreeNode Node, SkillTree TreeItem)
        {
            if (Node == null || TreeItem == null)
            {
                return false;
            }

            if (TreeItem.SaveIndex > 128)
            {
                throw new ArgumentOutOfRangeException();
            }

            int Offset = Offsets.Social_ConnectionStatus_First + TreeItem.SaveIndex;
            return ByteUtil.GetBit(SelectedSlot.RetrieveOffset_Byte(Offset), 6);
        }

        private byte CharacterIsUnlocked(SkillTree TreeItem)
        {
            if (TreeItem == null)
            {
                return 0;
            }

            if (SelectedSlot.FurthestDay >= TreeItem.ConnectDay)
            {
                return 2;
            }
            else if (SelectedSlot.FurthestDay >= TreeItem.EntryDay)
            {
                return 1;
            }

            return 0;
        }

        private void RecursiveUnlockAll(TreeNode Node)
        {
            ushort TreeId = (ushort)Node.Tag;

            SkillTree TreeItem = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItem(TreeId);

            if (TreeItem == null)
            {
                return;
            }

            if (UnlockAll_EncounterCheckbox.Checked)
            {
                UpdateEncounterStatus(Node, TreeItem, UnlockAll_Flag);
            }

            if (UnlockAll_ConnectionCheckbox.Checked)
            {
                UpdateConnectionStatus(Node, TreeItem, UnlockAll_Flag);
            }

            foreach (TreeNode Child in Node.Nodes)
            {
                RecursiveUnlockAll(Child);
            }
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

            if (Sukuranburu.ShowSpoilers == false && CharacterIsUnlocked(TreeItem) == 0)
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

            if (UnlockAll_EncounterCheckbox.Checked || UnlockAll_ConnectionCheckbox.Checked)
            {
                foreach (TreeNode Node in SkillTreeView.Nodes)
                {
                    RecursiveUnlockAll(Node);
                }

                if (SelectedSkillTree != null)
                {
                    if (UnlockAll_EncounterCheckbox.Checked)
                    {
                        Encountered_Checkbox.Checked = UnlockAll_Flag;
                    }

                    if (UnlockAll_ConnectionCheckbox.Checked)
                    {
                        ConnectionMadeCheckbox.Checked = UnlockAll_Flag;

                        if (SelectedSkillTree.InfoUpdateIfConnect)
                        {
                            ShowMoreInfoButton_Click(null, null);
                        }
                    }
                }
            }

            ReadyForUserInput = true;
        }

        private void Encountered_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedSkillTree == null || SelectedNode == null)
            {
                return;
            }

            ReadyForUserInput = false;
            UpdateEncounterStatus(SelectedNode, SelectedSkillTree, ConnectionMadeCheckbox.Checked);
            ReadyForUserInput = true;
        }

        private void ConnectionMadeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedSkillTree == null || SelectedNode == null)
            {
                return;
            }
            
            ReadyForUserInput = false;
            UpdateConnectionStatus(SelectedNode, SelectedSkillTree, ConnectionMadeCheckbox.Checked);

            if (SelectedSkillTree.InfoUpdateIfConnect)
            {
                ShowMoreInfoButton_Click(sender, e);
            }
            else
            {
                // coming soon. Get scenario 
            }

            ReadyForUserInput = true;
        }
    }
}
