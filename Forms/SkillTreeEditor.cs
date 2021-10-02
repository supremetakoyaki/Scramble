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
        public SaveSlot SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private SkillTree SelectedSkillTree;
        private TreeNode SelectedNode;

        private int InfoIndex = 0;

        private bool ReadyForUserInput = false;
        private bool UnlockAll_Flag = false;

        public SkillTreeEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ShopLogo_PictureBox.BackColor = Color.Transparent;
            ShopLogo_PictureBox.Parent = Character_PictureBox;
            ShopLogo_PictureBox.Location = new Point(0, 0);

            SkillIcon_PictureBox.Image = ImageMethods.DrawImage("itm_03_0200", 70, 70, DeviceDpi);

            LockStatusToolTip.SetToolTip(CharacterLockStatus_Label, Sukuranburu.GetString("{Hint_SkillTree_LockStatus}"));

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
            Text = Sukuranburu.GetString("{SocialEditor}");
            SkillTreeGroupBox.Text = Sukuranburu.GetString("{SkillTreeMap}");
            CharacterInfoGroupBox.Text = Sukuranburu.GetString("{CharacterInfo}");
            SkillLabel.Text = Sukuranburu.GetString("{RewardSkill}");
            X_Label.Text = Sukuranburu.GetString("{x}");
            FpLabel.Text = Sukuranburu.GetString("{FP}");
            TimeframeLabel.Text = Sukuranburu.GetString("{Timeframe:}");
            LocationLabel.Text = Sukuranburu.GetString("{Location:}");
            UnlockAllButton.Text = Sukuranburu.GetString("{UnlockAll}");
            UnlockAll_ConnectionCheckbox.Text = Sukuranburu.GetString("{Connection}");
            UnlockAll_EncounterCheckbox.Text = Sukuranburu.GetString("{Encounter}");
            UnlockAll_SkillCheckbox.Text = Sukuranburu.GetString("{Skill}");
            ConnectionMadeCheckbox.Text = Sukuranburu.GetString("{ConnectionEstablished}");
            Encountered_Checkbox.Text = Sukuranburu.GetString("{Encounter}");
            SkillUnlocked_Checkbox.Text = Sukuranburu.GetString("{Unlocked}");
            FirstEntry_Label.Text = Sukuranburu.GetString("{FirstEntry:}");
            ConnectionDay_Label.Text = Sukuranburu.GetString("{Connection:}");
            Shop_Label.Text = Sukuranburu.GetString("{Shop:}");
        }

        private void BuildSkillTree(int ParentId, TreeNode ParentNode)
        {
            System.Collections.Generic.Dictionary<ushort, SkillTree> SkillTreeItems = Sukuranburu.GetSocialNetworkManager().GetSkillTreeItems(ParentId);

            foreach (SkillTree Item in SkillTreeItems.Values)
            {
                TreeNode Node = new TreeNode
                {
                    Name = string.Format("SkillTree{0}Node", Item.Id),
                    Tag = (ushort)Item.Id
                };

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
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), CharacterName_RichTextBox);
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{Spoiler}"), CharacterInfo_RichTextBox);
                InfoIndex = 0;

                TimeframeLabel.ForeColor = SystemColors.ControlDark;
                LocationLabel.ForeColor = SystemColors.ControlDark;
                TimeframeValueLabel.ForeColor = SystemColors.ControlDark;
                LocationValueLabel.ForeColor = SystemColors.ControlDark;
                TimeframeValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                LocationValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                Character_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("CHR_Spoiler") as Bitmap, 375, 450, DeviceDpi);
                ShowMoreInfoButton.Enabled = false;
                ShowMoreInfoButton.Visible = false;

                FirstEntryValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                ConnectionDayValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
                ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;
                FirstEntry_Label.ForeColor = SystemColors.ControlDark;
                FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;

                Shop_Label.Visible = false;
                ShopName_RichTextBox.Clear();
                ShopLogo_PictureBox.Image = null;

                Encountered_Checkbox.Enabled = true;
                Encountered_Checkbox.Checked = RetrieveEncounterStatus(Node, TreeItem);
                ConnectionMadeCheckbox.Enabled = true;
                ConnectionMadeCheckbox.Checked = RetrieveConnectionStatus(Node, TreeItem);

                switch (CharacterIsUnlocked(TreeItem))
                {
                    case 0:
                        CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_L}");
                        CharacterLockStatus_Label.ForeColor = Color.IndianRed;
                        break;

                    case 1:
                        CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_P}");
                        CharacterLockStatus_Label.ForeColor = Color.DarkGoldenrod;
                        break;

                    case 2:
                        CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_U}");
                        CharacterLockStatus_Label.ForeColor = Color.Green;
                        break;
                }
            }
            else
            {
                bool FirstEntryDayValid = false;
                bool ConnectionDayValid = false;

                FirstEntryValue_Label.Text = Sukuranburu.GetDayName(TreeItem.EntryDay, ref FirstEntryDayValid);

                if (Sukuranburu.ShowSpoilers == false && CharacterIsUnlocked(TreeItem) == 1)
                {
                    TimeframeLabel.ForeColor = SystemColors.ControlDark;
                    LocationLabel.ForeColor = SystemColors.ControlDark;
                    TimeframeValueLabel.ForeColor = SystemColors.ControlDark;
                    LocationValueLabel.ForeColor = SystemColors.ControlDark;

                    TimeframeValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                    LocationValueLabel.Text = Sukuranburu.GetString("{Spoiler}");
                    ConnectionDayValue_Label.Text = Sukuranburu.GetString("{Spoiler}");
                }
                else
                {
                    TimeframeLabel.ForeColor = Color.FromArgb(192, 64, 0);
                    LocationLabel.ForeColor = Color.FromArgb(160, 40, 85);
                    TimeframeValueLabel.ForeColor = SystemColors.ControlText;
                    LocationValueLabel.ForeColor = SystemColors.ControlText;

                    TimeframeValueLabel.Text = Sukuranburu.GetGameString(TreeItem.DayText);
                    LocationValueLabel.Text = Sukuranburu.GetGameString(TreeItem.PlaceText);
                    ConnectionDayValue_Label.Text = Sukuranburu.GetDayName(TreeItem.ConnectDay, ref ConnectionDayValid);
                }

                Character_PictureBox.Image = ImageMethods.DrawImage(TreeItem.CharacterIcon, 540, 450, DeviceDpi);//Resources.ResourceManager.GetObject(TreeItem.CharacterIcon) as Bitmap;

                if (Sukuranburu.ShowSpoilers == false)
                {
                    if (CharacterIsUnlocked(TreeItem) < 2)
                    {
                        ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
                        ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;

                        if (CharacterIsUnlocked(TreeItem) == 0)
                        {
                            FirstEntry_Label.ForeColor = SystemColors.ControlDark;
                            FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;
                        }
                    }
                    else
                    {
                        ConnectionDay_Label.ForeColor = Color.FromArgb(75, 50, 190);
                        ConnectionDayValue_Label.ForeColor = SystemColors.ControlText;
                        FirstEntry_Label.ForeColor = Color.FromArgb(120, 0, 200);
                        FirstEntryValue_Label.ForeColor = SystemColors.ControlText;
                    }
                }
                else
                {
                    if (FirstEntryDayValid)
                    {
                        FirstEntry_Label.ForeColor = Color.FromArgb(120, 0, 200);
                        FirstEntryValue_Label.ForeColor = SystemColors.ControlText;
                    }
                    else
                    {
                        FirstEntry_Label.ForeColor = SystemColors.ControlDark;
                        FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;
                    }

                    if (ConnectionDayValid)
                    {
                        ConnectionDay_Label.ForeColor = Color.FromArgb(75, 50, 190);
                        ConnectionDayValue_Label.ForeColor = SystemColors.ControlText;
                    }
                    else
                    {
                        ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
                        ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;
                    }
                }

                if (TreeItem.ShopId != -1)
                {
                    Shop_Label.Visible = true;

                    Shop CharacterShop = Sukuranburu.GetItemManager().GetShop(TreeItem.ShopId);
                    if (CharacterShop != null)
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(CharacterShop.Name), ShopName_RichTextBox);

                        if (CharacterShop.Brand > 0)
                        {
                            Brand ShopBrand = Sukuranburu.GetItemManager().GetBrand(CharacterShop.Brand);
                            if (ShopBrand != null)
                            {
                                ShopLogo_PictureBox.Image = ImageMethods.DrawImage(ShopBrand.Sprite, 102, 36, DeviceDpi);
                            }
                            else
                            {
                                ShopLogo_PictureBox.Image = null;
                            }
                        }
                        else
                        {
                            ShopLogo_PictureBox.Image = null;
                        }
                    }
                    else
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString("Com_Unknown"), ShopName_RichTextBox);
                        ShopLogo_PictureBox.Image = null;
                    }
                }
                else
                {
                    Shop_Label.Visible = false;
                    ShopName_RichTextBox.Clear();
                    ShopLogo_PictureBox.Image = null;
                }

                Encountered_Checkbox.Enabled = true;
                Encountered_Checkbox.Checked = RetrieveEncounterStatus(Node, TreeItem);
                ConnectionMadeCheckbox.Enabled = true;
                ConnectionMadeCheckbox.Checked = RetrieveConnectionStatus(Node, TreeItem);

                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterName), CharacterName_RichTextBox);

                if (Sukuranburu.ShowSpoilers)
                {
                    ShowMoreInfoButton.Enabled = true;
                }
                else
                {
                    ShowMoreInfoButton.Enabled = false;
                }

                if (Encountered_Checkbox.Checked || ConnectionMadeCheckbox.Checked)
                {
                    if (TreeItem.InfoUpdateIfConnect && TreeItem.CharacterInfo.Length > 1 && ConnectionMadeCheckbox.Checked)
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterInfo[1]), CharacterInfo_RichTextBox);
                        ShowMoreInfoButton.Enabled = true;
                    }
                    else
                    {
                        Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()), CharacterInfo_RichTextBox);
                    }
                }
                else
                {
                    Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault()), CharacterInfo_RichTextBox);
                }

                switch (CharacterIsUnlocked(TreeItem))
                {
                    case 0:
                        CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_L}");
                        CharacterLockStatus_Label.ForeColor = Color.IndianRed;
                        break;

                    case 1:
                        CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_P}");
                        CharacterLockStatus_Label.ForeColor = Color.DarkGoldenrod;
                        break;

                    case 2:
                        CharacterLockStatus_Label.Text = Sukuranburu.GetString("{LockStatus_U}");
                        CharacterLockStatus_Label.ForeColor = Color.Green;
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

            RewardName_Label.Text = Sukuranburu.GetGameString(SkillItem.Name);
            if (SkillItem.Info == "Com_ItemName" && SkillItem.ShopReward > 0)
            {
                IGameItem GameItem = Sukuranburu.GetItemManager().GetItem((ushort)SkillItem.ShopReward);
                if (GameItem != null)
                {
                    SkillInfo_Label.Text = Sukuranburu.GetGameString(GameItem.Name);
                }
                else
                {
                    SkillInfo_Label.Text = SkillItem.ShopReward.ToString(); // or what could I do here?
                }
            }
            else
            {
                SkillInfo_Label.Text = Sukuranburu.GetGameString(SkillItem.Info);
            }

            SkillUnlocked_Checkbox.Checked = RetrieveSkillValue(SkillItem);
            SkillUnlocked_Checkbox.Enabled = true;

            FpValue_Label.Text = SkillItem.PointsRequired.ToString();
        }

        private void DisplayEmptyNode()
        {
            SelectedSkillTree = null;
            SelectedNode = null;

            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("{NoSelectedCharacter}"), CharacterName_RichTextBox);
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString("—"), CharacterInfo_RichTextBox);
            TimeframeLabel.ForeColor = SystemColors.ControlDark;
            LocationLabel.ForeColor = SystemColors.ControlDark;
            TimeframeValueLabel.ForeColor = SystemColors.ControlDark;
            LocationValueLabel.ForeColor = SystemColors.ControlDark;
            FirstEntry_Label.ForeColor = SystemColors.ControlDark;
            FirstEntryValue_Label.ForeColor = SystemColors.ControlDark;
            ConnectionDay_Label.ForeColor = SystemColors.ControlDark;
            ConnectionDayValue_Label.ForeColor = SystemColors.ControlDark;

            TimeframeValueLabel.Text = "—";
            LocationValueLabel.Text = "—";
            FirstEntryValue_Label.Text = "—";
            ConnectionDayValue_Label.Text = "—";

            Character_PictureBox.Image = null;
            ShowMoreInfoButton.Enabled = false;
            Shop_Label.Visible = false;
            ShopName_RichTextBox.Clear();
            ShopLogo_PictureBox.Image = null;
            Encountered_Checkbox.Enabled = false;
            ConnectionMadeCheckbox.Enabled = false;
            CharacterLockStatus_Label.Text = "—";

            DisplayEmptySkill();
        }

        private void DisplayEmptySkill()
        {
            RewardName_Label.Text = "—";
            SkillInfo_Label.Text = "—";
            FpValue_Label.Text = "0";
            SkillUnlocked_Checkbox.Checked = false;
            SkillUnlocked_Checkbox.Enabled = false;
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
            byte ByteToSet = SelectedSlot.RetrieveOffset_Byte(GameOffsets.SkillFlag + OffsetSum);
            byte BitIndex = (byte)(SkillItem.SaveIndex % 8);

            ByteToSet = ByteUtil.SetBit(ByteToSet, BitIndex, Value);
            SelectedSlot.UpdateOffset_Byte(GameOffsets.SkillFlag + OffsetSum, ByteToSet);
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
            byte ByteToSet = SelectedSlot.RetrieveOffset_Byte(GameOffsets.SkillFlag + OffsetSum);
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

            int Offset = GameOffsets.SkillTreeFlags + TreeItem.SaveIndex;
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

            int Offset = GameOffsets.SkillTreeFlags + TreeItem.SaveIndex;
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

            int Offset = GameOffsets.SkillTreeFlags + TreeItem.SaveIndex;
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

            int Offset = GameOffsets.SkillTreeFlags + TreeItem.SaveIndex;
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
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString(Sukuranburu.GetGameString(TreeItem.CharacterInfo[++InfoIndex])), CharacterInfo_RichTextBox);
            }
            else
            {
                InfoIndex = 0;
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetString(Sukuranburu.GetGameString(TreeItem.CharacterInfo.FirstOrDefault())), CharacterInfo_RichTextBox);
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
