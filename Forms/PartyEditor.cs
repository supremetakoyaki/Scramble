using NTwewyDb;
using Scramble.Classes;
using Scramble.Properties;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class PartyEditor : Form
    {
        public SaveSlot SelectedSlot => Program.Sukuranburu.SafeSelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private readonly bool ReadyForUserInput = false;

        private bool IsAdvancedMode => AdvancedModeButton.Enabled == false;

        public PartyEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            PartyMembersGroupBox.Size = new Size(881, 307);
            ChangeFormSize(362, 916);

            DisplayLanguageStrings();
            SerializePartyMembers();
            SerializeAdvancedMode();
            CheckIssues();

            if (Sukuranburu.RequiresRescaling)
            {
                CompletePinInventoryListView.AutoSize = true;
                CompleteClothingInventoryListView.AutoSize = true;
            }

            CompletePinInventoryListView.SmallImageList = Sukuranburu.ItemImageList_32x32;
            CompleteClothingInventoryListView.SmallImageList = Sukuranburu.ItemImageList_32x32;

            ReadyForUserInput = true;
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{PartyEditor}");
            PartyMembersGroupBox.Text = Sukuranburu.GetString("{PartyMembers}");
            AdvancedModeButton.Text = Sukuranburu.GetString("{AdvancedMode}");
            Deck1Label1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{DeckOne}"), Sukuranburu.GetString("{:}"));
            Deck2Label1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{DeckTwo}"), Sukuranburu.GetString("{:}"));
            Deck3Label1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{DeckThree}"), Sukuranburu.GetString("{:}"));
            HeadwearLabel1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{WearType0}"), Sukuranburu.GetString("{:}"));
            TopLabel1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{WearType1}"), Sukuranburu.GetString("{:}"));
            BottomLabel1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{WearType2}"), Sukuranburu.GetString("{:}"));
            ShoewearLabel1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{WearType3}"), Sukuranburu.GetString("{:}"));
            AccessoryLabel1.Text = string.Format("{0}{1}", Sukuranburu.GetString("{WearType4}"), Sukuranburu.GetString("{:}"));
            IssuesGroupBox.Text = Sukuranburu.GetString("{Issues}");
            EquippableItemsGroupBox.Text = Sukuranburu.GetString("{EquippableItems}");
            PinIndexHeader.Text = Sukuranburu.GetString("{Index}");
            PinIdHeader.Text = Sukuranburu.GetString("{Id}");
            PinNameHeader.Text = Sukuranburu.GetString("{Name}");
            PinLevelHeader.Text = Sukuranburu.GetString("{Level}");
            ClothingIndexHeader.Text = Sukuranburu.GetString("{Index}");
            ClothingIdHeader.Text = Sukuranburu.GetString("{Id}");
            ClothingNameHeader.Text = Sukuranburu.GetString("{Name}");
            QuickSearchLabel1.Text = Sukuranburu.GetString("{QuickSearch:}");
            QuickSearchLabel2.Text = Sukuranburu.GetString("{QuickSearch:}");
            LoadItemsButton.Text = Sukuranburu.GetString("{LoadItems}");
        }

        private void ChangeFormSize(int Height, int Width)
        {
            if (Sukuranburu.RequiresRescaling)
            {
                this.Height = (int)Math.Floor(Height * Sukuranburu.ScaleFactor);
                this.Width = (int)Math.Floor(Width * Sukuranburu.ScaleFactor);
            }
            else
            {
                this.Height = Height;
                this.Width = Width;
            }
        }

        private async void CheckIssues()
        {
            if (IsAdvancedMode == false)
            {
                await Task.Run(CheckIssuesParty);
                return;
            }

            string PartyIssues = await Task.Run(CheckIssuesParty);
            string IndexIssues = await Task.Run(CheckIssuesSaveIndexes);

            if (PartyIssues == string.Empty && IndexIssues == string.Empty)
            {
                IssueIconPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("icon_check") as Bitmap, 24, 24, DeviceDpi);
                IssueStatusLabel.Text = Sukuranburu.GetString("{ThereAreNoIssues}");
                IssuesListRichTextBox.Clear();
            }
            else
            {
                IssueIconPictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject("icon_warning") as Bitmap, 24, 24, DeviceDpi);
                IssueStatusLabel.Text = Sukuranburu.GetString("{ThereAreIssues}");
                Sukuranburu.GetGameTextProcessor().SetTaggedText(PartyIssues + IndexIssues, IssuesListRichTextBox);
            }
        }

        private string CheckIssuesParty()
        {
            bool DuplicateFound = false;

            List<int> PartyMembers = new List<int>();
            Action LoopChecker = new Action(() =>
            {
                for (int i = 1; i < 7; i++)
                {
                    ComboBox pComboBox = (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_ComboBox", i)] as ComboBox);
                    int PartyMemberId = pComboBox.SelectedIndex;
                    if (PartyMemberId != 0)
                    {
                        if (PartyMembers.Contains(PartyMemberId))
                        {
                            DuplicateFound = true;
                            pComboBox.ForeColor = Color.Red;
                        }
                        else
                        {
                            pComboBox.ForeColor = SystemColors.ControlText;
                        }

                        PartyMembers.Add(PartyMemberId);
                    }
                    else
                    {
                        pComboBox.ForeColor = SystemColors.ControlText;
                    }
                }
            });

            if (InvokeRequired)
            {
                Invoke(LoopChecker);
            }
            else
            {
                LoopChecker();
            }

            if (DuplicateFound)
            {
                return Sukuranburu.GetString("{Issue_DuplicatePartyMember}");
            }
            else if (PartyMembers.Count == 0)
            {
                return Sukuranburu.GetString("{Issue_EmptyPartyMembers}");
            }

            return string.Empty;
        }

        private string CheckIssuesSaveIndexes()
        {
            StringBuilder Sb = new StringBuilder();

            List<int> DeckOnePins = new List<int>();
            List<int> DeckTwoPins = new List<int>();
            List<int> DeckThreePins = new List<int>();
            List<int> Headwear = new List<int>();
            List<int> Tops = new List<int>();
            List<int> Bottoms = new List<int>();
            List<int> Shoes = new List<int>();
            List<int> Accessories = new List<int>();

            int DuplicateItems = 0;
            int NonExistent = 0;

            Action LoopChecker = new Action(() =>
            {
                for (int i = 1; i < 7; i++)
                {
                    NumericUpDown DeckOneNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_Deck1SaveIndex_NumUpDown", i)] as NumericUpDown;
                    NumericUpDown DeckTwoNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_Deck2SaveIndex_NumUpDown", i)] as NumericUpDown;
                    NumericUpDown DeckThreeNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_Deck3SaveIndex_NumUpDown", i)] as NumericUpDown;
                    NumericUpDown HeadwearNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_HeadwearSaveIndex_NumUpDown", i)] as NumericUpDown;
                    NumericUpDown TopNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_TopSaveIndex_NumUpDown", i)] as NumericUpDown;
                    NumericUpDown BottomNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_BottomSaveIndex_NumUpDown", i)] as NumericUpDown;
                    NumericUpDown ShoesNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_ShoesSaveIndex_NumUpDown", i)] as NumericUpDown;
                    NumericUpDown AccessoryNumUpDown = PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_AccessorySaveIndex_NumUpDown", i)] as NumericUpDown;

                    if (DeckOneNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyBadgeList + (8 * (int)DeckOneNumUpDown.Value)) == PinInventoryEditor.EMPTY_PIN_ID)
                        {
                            NonExistent++;
                            DeckOneNumUpDown.ForeColor = Color.Red;
                        }
                        else if (DeckOnePins.Contains((int)DeckOneNumUpDown.Value))
                        {
                            DuplicateItems++;
                            DeckOneNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            DeckOnePins.Add((int)DeckOneNumUpDown.Value);
                            DeckOneNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (DeckTwoNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyBadgeList + (8 * (int)DeckTwoNumUpDown.Value)) == PinInventoryEditor.EMPTY_PIN_ID)
                        {
                            NonExistent++;
                            DeckTwoNumUpDown.ForeColor = Color.Red;
                        }
                        else if (DeckTwoPins.Contains((int)DeckTwoNumUpDown.Value))
                        {
                            DuplicateItems++;
                            DeckTwoNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            DeckTwoPins.Add((int)DeckTwoNumUpDown.Value);
                            DeckTwoNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (DeckThreeNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyBadgeList + (8 * (int)DeckThreeNumUpDown.Value)) == PinInventoryEditor.EMPTY_PIN_ID)
                        {
                            NonExistent++;
                            DeckThreeNumUpDown.ForeColor = Color.Red;
                        }
                        else if (DeckThreePins.Contains((int)DeckThreeNumUpDown.Value))
                        {
                            DuplicateItems++;
                            DeckThreeNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            DeckThreePins.Add((int)DeckThreeNumUpDown.Value);
                            DeckThreeNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (HeadwearNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyCostumeList + (2 * (int)HeadwearNumUpDown.Value)) - 1 == ClothingInventoryEditor.EMPTY_CLOTHING_ID_ACTUAL)
                        {
                            NonExistent++;
                            HeadwearNumUpDown.ForeColor = Color.Red;
                        }
                        else if (Headwear.Contains((int)HeadwearNumUpDown.Value))
                        {
                            DuplicateItems++;
                            HeadwearNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            Headwear.Add((int)HeadwearNumUpDown.Value);
                            HeadwearNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (TopNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyCostumeList + (2 * (int)TopNumUpDown.Value)) - 1 == ClothingInventoryEditor.EMPTY_CLOTHING_ID_ACTUAL)
                        {
                            NonExistent++;
                            TopNumUpDown.ForeColor = Color.Red;
                        }
                        else if (Tops.Contains((int)TopNumUpDown.Value))
                        {
                            DuplicateItems++;
                            TopNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            Tops.Add((int)TopNumUpDown.Value);
                            TopNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (BottomNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyCostumeList + (2 * (int)BottomNumUpDown.Value)) - 1 == ClothingInventoryEditor.EMPTY_CLOTHING_ID_ACTUAL)
                        {
                            NonExistent++;
                            BottomNumUpDown.ForeColor = Color.Red;
                        }
                        else if (Bottoms.Contains((int)BottomNumUpDown.Value))
                        {
                            DuplicateItems++;
                            BottomNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            Bottoms.Add((int)BottomNumUpDown.Value);
                            BottomNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (ShoesNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyCostumeList + (2 * (int)ShoesNumUpDown.Value)) - 1 == ClothingInventoryEditor.EMPTY_CLOTHING_ID_ACTUAL)
                        {
                            NonExistent++;
                            ShoesNumUpDown.ForeColor = Color.Red;
                        }
                        else if (Shoes.Contains((int)ShoesNumUpDown.Value))
                        {
                            DuplicateItems++;
                            ShoesNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            Shoes.Add((int)ShoesNumUpDown.Value);
                            ShoesNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }

                    if (AccessoryNumUpDown.Value != SaveSlot.NOT_ASSIGNED_DATA)
                    {
                        if (SelectedSlot.RetrieveOffset_UInt16(GameOffsets.MyCostumeList + (2 * (int)AccessoryNumUpDown.Value)) - 1 == ClothingInventoryEditor.EMPTY_CLOTHING_ID_ACTUAL)
                        {
                            NonExistent++;
                            AccessoryNumUpDown.ForeColor = Color.Red;
                        }
                        else if (Accessories.Contains((int)AccessoryNumUpDown.Value))
                        {
                            DuplicateItems++;
                            AccessoryNumUpDown.ForeColor = Color.Red;
                        }
                        else
                        {
                            Accessories.Add((int)AccessoryNumUpDown.Value);
                            AccessoryNumUpDown.ForeColor = SystemColors.WindowText;
                        }
                    }
                }
            });

            if (InvokeRequired)
            {
                Invoke(LoopChecker);
            }
            else
            {
                LoopChecker();
            }

            if (DeckOnePins.Count == 0)
            {
                Sb.Append(Sukuranburu.GetString("{Issue_NoEquippedPinOnDeck1}"));
            }

            if (NonExistent > 0)
            {
                Sb.Append(string.Format(Sukuranburu.GetString("{Issue_EquippingNonExistentItem}"), NonExistent));
            }

            if (DuplicateItems > 0)
            {
                Sb.Append(string.Format(Sukuranburu.GetString("{Issue_DuplicateEquippedItem}"), DuplicateItems));
            }

            return Sb.ToString();
        }

        private void SerializePartyMembers()
        {
            PartyMember1_ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            PartyMember2_ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            PartyMember3_ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            PartyMember4_ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            PartyMember5_ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            PartyMember6_ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            PartyMember1_ComboBox.SelectedIndex = 0;
            PartyMember2_ComboBox.SelectedIndex = 0;
            PartyMember3_ComboBox.SelectedIndex = 0;
            PartyMember4_ComboBox.SelectedIndex = 0;
            PartyMember5_ComboBox.SelectedIndex = 0;
            PartyMember6_ComboBox.SelectedIndex = 0;

            for (int i = 1; i < 8; i++)
            {
                PartyMember1_ComboBox.Items.Add(Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(i)));
                PartyMember2_ComboBox.Items.Add(Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(i)));
                PartyMember3_ComboBox.Items.Add(Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(i)));
                PartyMember4_ComboBox.Items.Add(Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(i)));
                PartyMember5_ComboBox.Items.Add(Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(i)));
                PartyMember6_ComboBox.Items.Add(Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(i)));
            }

            foreach (PartyMember Member in SelectedSlot.GetPartyMembers().Values)
            {
                switch (Member.Id)
                {
                    case 1:
                        PartyMember1_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", Member.CharacterId)) as Bitmap, 140, 220, DeviceDpi);
                        PartyMember1_ComboBox.SelectedIndex = Member.CharacterId;
                        break;

                    case 2:
                        PartyMember2_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", Member.CharacterId)) as Bitmap, 140, 220, DeviceDpi);
                        PartyMember2_ComboBox.SelectedIndex = Member.CharacterId;
                        break;

                    case 3:
                        PartyMember3_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", Member.CharacterId)) as Bitmap, 140, 220, DeviceDpi);
                        PartyMember3_ComboBox.SelectedIndex = Member.CharacterId;
                        break;

                    case 4:
                        PartyMember4_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", Member.CharacterId)) as Bitmap, 140, 220, DeviceDpi);
                        PartyMember4_ComboBox.SelectedIndex = Member.CharacterId;
                        break;

                    case 5:
                        PartyMember5_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", Member.CharacterId)) as Bitmap, 140, 220, DeviceDpi);
                        PartyMember5_ComboBox.SelectedIndex = Member.CharacterId;
                        break;

                    case 6:
                        PartyMember6_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", Member.CharacterId)) as Bitmap, 140, 220, DeviceDpi);
                        PartyMember6_ComboBox.SelectedIndex = Member.CharacterId;
                        break;
                }
            }
        }

        private void SerializeAdvancedMode()
        {
            for (int i = 0; i < 6; i++)
            {
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_Deck1SaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + (36 * i));
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_Deck2SaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + (36 * i));
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_Deck3SaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + (36 * i));
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_HeadwearSaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Head + (36 * i));
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_TopSaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Top + (36 * i));
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_BottomSaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Bottom + (36 * i));
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_ShoesSaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Foot + (36 * i));
                (PartyMembersGroupBox.Controls[string.Format("PartyMember{0}_AccessorySaveIndex_NumUpDown", i + 1)] as NumericUpDown).Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.EquipCosIndex_Accessory + (36 * i));
            }
        }

        private void LoadItemInventory()
        {
            List<ListViewItem> PinItemList = new List<ListViewItem>();
            List<ListViewItem> ClothingItemList = new List<ListViewItem>();

            int CurrentIndex = 0;
            for (int CurrentPointer = GameOffsets.MyBadgeList; CurrentPointer < GameOffsets.MyBadgeList_Last; CurrentPointer += 8)
            {
                ushort PinId = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer);

                if (PinId != PinInventoryEditor.EMPTY_PIN_ID)
                {
                    ushort Level = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 2);
                    if (Level > 0x80)
                    {
                        Level -= 0x80;
                    }

                    string PinName = string.Empty;
                    string PinSprite = string.Empty;
                    PinItem Pin = Sukuranburu.GetItemManager().GetPinItem(PinId);

                    if (Pin != null)
                    {
                        PinName = Sukuranburu.GetGameString(Pin.Name);
                        PinSprite = Pin.Sprite;
                    }

                    string LevelString = Level.ToString();
                    if (Pin.MaxLevel == Level)
                    {
                        LevelString += " ★";
                    }

                    ListViewItem ItemToAdd = new ListViewItem(new string[] { PinName, CurrentIndex.ToString(), PinId.ToString(), LevelString })
                    {
                        ImageKey = PinSprite,
                        Tag = CurrentIndex
                    };

                    PinItemList.Add(ItemToAdd);
                }

                CurrentIndex += 1;
            }

            CurrentIndex = 0;
            for (int CurrentPointer = GameOffsets.MyCostumeList; CurrentPointer < GameOffsets.MyCostumeList_Last; CurrentPointer += 2)
            {
                int ClothingId = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer) - 1;

                if (ClothingId > 0x8000)
                {
                    ClothingId -= 0x8000; // this means the clothing is unseen (says "New" in the inventory).
                }

                if (ClothingId != ClothingInventoryEditor.EMPTY_CLOTHING_ID_ACTUAL)
                {
                    string ClothingName = string.Empty;
                    string ClothingSprite = string.Empty;
                    ClothingItem Clothing = Sukuranburu.GetItemManager().GetClothingItem((ushort)ClothingId);

                    if (Clothing != null)
                    {
                        ClothingName = Sukuranburu.GetGameString(Clothing.Name);
                        ClothingSprite = Clothing.Sprite;
                    }

                    ListViewItem ItemToAdd = new ListViewItem(new string[] { ClothingName, CurrentIndex.ToString(), ClothingId.ToString() })
                    {
                        ImageKey = ClothingSprite,
                        Tag = CurrentIndex
                    };

                    ClothingItemList.Add(ItemToAdd);
                }

                CurrentIndex += 1;
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    CompletePinInventoryListView.Items.AddRange(PinItemList.ToArray());
                    CompleteClothingInventoryListView.Items.AddRange(ClothingItemList.ToArray());
                    LoadItemsButton.Text = Sukuranburu.GetString("{ItemsLoaded}");
                }));
            }
            else
            {
                CompletePinInventoryListView.Items.AddRange(PinItemList.ToArray());
                CompleteClothingInventoryListView.Items.AddRange(ClothingItemList.ToArray());
                LoadItemsButton.Text = Sukuranburu.GetString("{ItemsLoaded}");
            }
        }

        private void PartyMember1_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_PartyMember, PartyMember1_ComboBox.SelectedIndex - 1);

            if (PartyMember1_ComboBox.SelectedIndex == 0)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID, SaveSlot.NOT_ASSIGNED_DATA);
                PartyMember1_PictureBox.Image = null;
            }
            else
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID, PartyMember1_ComboBox.SelectedIndex);
                PartyMember1_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", PartyMember1_ComboBox.SelectedIndex)) as Bitmap, 140, 220, DeviceDpi);
            }

            CheckIssues();
        }

        private void PartyMember2_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_PartyMember + 4, PartyMember2_ComboBox.SelectedIndex - 1);

            if (PartyMember2_ComboBox.SelectedIndex == 0)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + 36, SaveSlot.NOT_ASSIGNED_DATA);
                PartyMember2_PictureBox.Image = null;
            }
            else
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + 36, PartyMember2_ComboBox.SelectedIndex);
                PartyMember2_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", PartyMember2_ComboBox.SelectedIndex)) as Bitmap, 140, 220, DeviceDpi);
            }

            CheckIssues();
        }

        private void PartyMember3_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_PartyMember + (4 * 2), PartyMember3_ComboBox.SelectedIndex - 1);

            if (PartyMember3_ComboBox.SelectedIndex == 0)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 2), SaveSlot.NOT_ASSIGNED_DATA);
                PartyMember3_PictureBox.Image = null;
            }
            else
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 2), PartyMember3_ComboBox.SelectedIndex);
                PartyMember3_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", PartyMember3_ComboBox.SelectedIndex)) as Bitmap, 140, 220, DeviceDpi);
            }

            CheckIssues();
        }

        private void PartyMember4_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_PartyMember + (4 * 3), PartyMember4_ComboBox.SelectedIndex - 1);

            if (PartyMember4_ComboBox.SelectedIndex == 0)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 3), SaveSlot.NOT_ASSIGNED_DATA);
                PartyMember4_PictureBox.Image = null;
            }
            else
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 3), PartyMember4_ComboBox.SelectedIndex);
                PartyMember4_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", PartyMember4_ComboBox.SelectedIndex)) as Bitmap, 140, 220, DeviceDpi);
            }

            CheckIssues();
        }

        private void PartyMember5_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_PartyMember + (4 * 4), PartyMember5_ComboBox.SelectedIndex - 1);

            if (PartyMember5_ComboBox.SelectedIndex == 0)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 4), SaveSlot.NOT_ASSIGNED_DATA);
                PartyMember5_PictureBox.Image = null;
            }
            else
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 4), PartyMember5_ComboBox.SelectedIndex);
                PartyMember5_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", PartyMember5_ComboBox.SelectedIndex)) as Bitmap, 140, 220, DeviceDpi);
            }

            CheckIssues();
        }

        private void PartyMember6_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.PlayerTeam_PartyMember + (4 * 5), PartyMember6_ComboBox.SelectedIndex - 1);

            if (PartyMember6_ComboBox.SelectedIndex == 0)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 5), SaveSlot.NOT_ASSIGNED_DATA);
                PartyMember6_PictureBox.Image = null;
            }
            else
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipPlayerID + (36 * 5), PartyMember6_ComboBox.SelectedIndex);
                PartyMember6_PictureBox.Image = ImageMethods.DrawImage(Resources.ResourceManager.GetObject(string.Format("CH0{0}_party", PartyMember6_ComboBox.SelectedIndex)) as Bitmap, 140, 220, DeviceDpi);
            }

            CheckIssues();
        }

        private void LoadItemsButton_Click(object sender, EventArgs e)
        {
            LoadItemsButton.Enabled = false;
            LoadItemsButton.Text = Sukuranburu.GetString("{Loading...}");

            Task.Run(() => { LoadItemInventory(); });
        }

        private void SearchPinsTextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < CompletePinInventoryListView.Items.Count; i++)
            {
                ListViewItem Item = CompletePinInventoryListView.Items[i];

                if (Item.SubItems[0].Text.ToLower().StartsWith(SearchPinsTextBox.Text))
                {
                    Item.Selected = true;
                    CompletePinInventoryListView.EnsureVisible(i);
                    return;
                }
            }
        }

        private void SearchClothingTextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < CompleteClothingInventoryListView.Items.Count; i++)
            {
                ListViewItem Item = CompleteClothingInventoryListView.Items[i];

                if (Item.SubItems[0].Text.ToLower().StartsWith(SearchClothingTextBox.Text))
                {
                    Item.Selected = true;
                    CompleteClothingInventoryListView.EnsureVisible(i);
                    return;
                }
            }
        }

        private void PartyEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SelectedSlot.LoadPartyMembers();
            Sukuranburu.SerializePartyMembers();
            ColumnSorter.DisposeColumn();
        }

        private void CompletePinInventoryListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(CompletePinInventoryListView, e);
        }

        private void CompleteClothingInventoryListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(CompleteClothingInventoryListView, e);
        }

        private void AdvancedModeButton_Click(object sender, EventArgs e)
        {
            AdvancedModeButton.Enabled = false;
            AdvancedModeButton.Visible = false;
            ChangeFormSize(753, 1280);
            PartyMembersGroupBox.Size = new Size(882, 583);

            CheckIssues();
        }

        #region Numeric Up Down Value Changed methods >_<
        private void PartyMember1_Deck1SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1, (int)PartyMember1_Deck1SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember1_Deck2SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2, (int)PartyMember1_Deck2SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember1_Deck3SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3, (int)PartyMember1_Deck3SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember1_HeadwearSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Head, (int)PartyMember1_HeadwearSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember1_TopSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Top, (int)PartyMember1_TopSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember1_BottomSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Bottom, (int)PartyMember1_BottomSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember1_ShoesSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Foot, (int)PartyMember1_ShoesSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember1_AccessorySaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Accessory, (int)PartyMember1_AccessorySaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_Deck1SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + 36, (int)PartyMember2_Deck1SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_Deck2SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + 36, (int)PartyMember2_Deck2SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_Deck3SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + 36, (int)PartyMember2_Deck3SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_HeadwearSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Head + 36, (int)PartyMember2_HeadwearSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_TopSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Top + 36, (int)PartyMember2_TopSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_BottomSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Bottom + 36, (int)PartyMember2_BottomSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_ShoesSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Foot + 36, (int)PartyMember2_ShoesSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember2_AccessorySaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Accessory + 36, (int)PartyMember2_AccessorySaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_Deck1SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + (36 * 2), (int)PartyMember3_Deck1SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_Deck2SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + (36 * 2), (int)PartyMember3_Deck2SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_Deck3SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + (36 * 2), (int)PartyMember3_Deck3SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_HeadwearSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Head + (36 * 2), (int)PartyMember3_HeadwearSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_TopSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Top + (36 * 2), (int)PartyMember3_TopSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_BottomSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Bottom + (36 * 2), (int)PartyMember3_BottomSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_ShoesSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Foot + (36 * 2), (int)PartyMember3_ShoesSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember3_AccessorySaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Accessory + (36 * 2), (int)PartyMember3_AccessorySaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_Deck1SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + (36 * 3), (int)PartyMember4_Deck1SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_Deck2SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + (36 * 3), (int)PartyMember4_Deck2SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_Deck3SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + (36 * 3), (int)PartyMember4_Deck3SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_HeadwearSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Head + (36 * 3), (int)PartyMember4_HeadwearSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_TopSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Top + (36 * 3), (int)PartyMember4_TopSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_BottomSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Bottom + (36 * 3), (int)PartyMember4_BottomSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_ShoesSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Foot + (36 * 3), (int)PartyMember4_ShoesSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember4_AccessorySaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Accessory + (36 * 3), (int)PartyMember4_AccessorySaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_Deck1SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + (36 * 4), (int)PartyMember5_Deck1SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_Deck2SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + (36 * 4), (int)PartyMember5_Deck2SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_Deck3SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + (36 * 4), (int)PartyMember5_Deck3SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_HeadwearSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Head + (36 * 4), (int)PartyMember5_HeadwearSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_TopSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Top + (36 * 4), (int)PartyMember5_TopSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_BottomSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Bottom + (36 * 4), (int)PartyMember5_BottomSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_ShoesSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Foot + (36 * 4), (int)PartyMember5_ShoesSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember5_AccessorySaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Accessory + (36 * 4), (int)PartyMember5_AccessorySaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_Deck1SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck1 + (36 * 5), (int)PartyMember6_Deck1SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_Deck2SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck2 + (36 * 5), (int)PartyMember6_Deck2SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_Deck3SaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.BadgeEquipPlayerIndex_Deck3 + (36 * 5), (int)PartyMember6_Deck3SaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_HeadwearSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Head + (36 * 5), (int)PartyMember6_HeadwearSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_TopSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Top + (36 * 5), (int)PartyMember6_TopSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_BottomSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Bottom + (36 * 5), (int)PartyMember6_BottomSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_ShoesSaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Foot + (36 * 5), (int)PartyMember6_ShoesSaveIndex_NumUpDown.Value);
            CheckIssues();
        }

        private void PartyMember6_AccessorySaveIndex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            SelectedSlot.UpdateOffset_Int32(GameOffsets.EquipCosIndex_Accessory + (36 * 5), (int)PartyMember6_AccessorySaveIndex_NumUpDown.Value);
            CheckIssues();
        }
        #endregion
    }
}
