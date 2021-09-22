using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scramble.Forms
{
    // JULY 28, 2021: Since the new database, this class requires optimization. I will do it in the future.

    public partial class PinInventoryEditor : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        public const int EMPTY_PIN_ID = 0xFFFF;
        private List<InventoryPin> InventoryPins;
        private InventoryPin SelectedPin;

        private bool ReadyForUserInput = false; // flag that indicates whether the editor is working on changing values on its own.    
        private bool WarnedAboutZeroPins = false;

        public PinInventoryEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            MyPinInventoryView.SmallImageList = Sukuranburu.ItemImageList_32x32;
            AllPinsListView.SmallImageList = Sukuranburu.ItemImageList_64x64;

            UberPin_PictureBox.BackColor = Color.Transparent;
            UberPin_PictureBox.Parent = PinImagePictureBox;
            UberPin_PictureBox.Location = new Point(68, 0);

            PinInputKey_PictureBox.BackColor = Color.Transparent;
            PinInputKey_PictureBox.Parent = PinImagePictureBox;
            PinInputKey_PictureBox.Location = new Point(0, 0);

            if (Sukuranburu.RequiresRescaling)
            {
                MyPinInventoryView.AutoSize = true;
                AllPinsListView.AutoSize = true;
            }

            DisplayLanguageStrings();

            Serialize();
            SerializeGlobal();
            ReadyForUserInput = true;
        }

        private void Serialize()
        {
            InventoryPins = new List<InventoryPin>();

            GenerateEquippedData();

            // Pin data:
            // int16: pin ID
            // int16: level
            // int32: experience

            int CurrentIndex = 0;
            for (int CurrentPointer = Offsets.PinInv_First; CurrentPointer < Offsets.PinInv_VeryLast; CurrentPointer += 8)
            {
                ushort PinId = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer);

                if (PinId != EMPTY_PIN_ID)
                {
                    ushort Level = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 2);
                    if (Level > 0x80) // this means this pin hasn't been seen yet (says "New")
                    {
                        Level -= 0x80;
                    }

                    uint Experience = SelectedSlot.RetrieveOffset_UInt32(CurrentPointer + 4);

                    InventoryPin PinToAdd = new InventoryPin(PinId, Level, Experience);
                    PinToAdd.ListIndex = InventoryPins.IndexOf(PinToAdd);

                    if (PinToAdd.ListIndex == -1)
                    {
                        PinToAdd.ListIndex = InventoryPins.Count;
                        InventoryPins.Add(PinToAdd);
                        PinToAdd.IntersectEquippingData(Sukuranburu.SelectedSlot.WhosEquippingThisPin(CurrentIndex));
                    }
                    else
                    {
                        if (InventoryPins[PinToAdd.ListIndex].Amount < 99)
                        {
                            InventoryPins[PinToAdd.ListIndex].Amount += 1;
                        }

                        InventoryPins[PinToAdd.ListIndex].IntersectEquippingData(Sukuranburu.SelectedSlot.WhosEquippingThisPin(CurrentIndex));
                    }
                }

                CurrentIndex += 1;
            }

            foreach (InventoryPin Pin in InventoryPins)
            {
                InsertPinToListView(Pin);
            }

            if (MyPinInventoryView.Items.Count > 0)
            {
                MyPinInventoryView.Items[0].Selected = true;
                MyPinInventoryView.Select();
            }

            //Sukuranburu.ShowNotice(GetString("DLG_PinEditorExperimentalNotice);
        }

        private void SerializeGlobal()
        {
            Dictionary<ushort, IGameItem> ItemDictionary = Sukuranburu.GetItemManager().GetItems();

            foreach (IGameItem Item in ItemDictionary.Values)
            {
                if (Item is PinItem)
                {
                    PinItem Pin = Item as PinItem;

                    string PinName = Sukuranburu.GetGameString(Pin.Name);

                    ListViewItem PinToAdd = new ListViewItem(new string[]
                    {
                    PinName,
                    Pin.ParticularId.ToString()
                    })
                    {
                        ImageKey = Pin.Sprite
                    };
                    AllPinsListView.Items.Add(PinToAdd);
                }
            }
        }
        private void DisplayLanguageStrings()
        {
            EquippedByCharacterComboBox.Items.Add(Sukuranburu.GetString("{NoOne}"));

            EquippedDeckComboBox.Items.AddRange(new object[] {
            Sukuranburu.GetString("{None}"),
            Sukuranburu.GetString("{DeckOne}"),
            Sukuranburu.GetString("{DeckTwo}"),
            Sukuranburu.GetString("{DeckThree}"),

            });

            Text = Sukuranburu.GetString("{PinsEditor}");
            groupBox1.Text = Sukuranburu.GetString("{PinInventory}");
            groupBox2.Text = Sukuranburu.GetString("{AllPins}");
            PinIdHeader.Text = Sukuranburu.GetString("{Id}");
            PinNameHeader.Text = Sukuranburu.GetString("{Name}");
            PinIsMasteredHeader.Text = Sukuranburu.GetString("{Mastered}");
            PinExperienceHeader.Text = Sukuranburu.GetString("{EXP}");
            AmountHeader.Text = Sukuranburu.GetString("{Amount}");
            AttackElementHeader.Text = Sukuranburu.GetString("{Affinity}");
            GlobalPinIdHeader.Text = Sukuranburu.GetString("{PinId}");
            GlobalPinNameHeader.Text = Sukuranburu.GetString("{Name}");

            RemovePinButton.Text = Sukuranburu.GetString("{RemoveThisPin}");
            RemoveAllPinsButton.Text = Sukuranburu.GetString("{RemoveAll}");
            LevelLabel.Text = Sukuranburu.GetString("{Level:}");
            ExpLabel.Text = Sukuranburu.GetString("{EXP:}");
            AmountLabel.Text = Sukuranburu.GetString("{Amount:}");
            EquippedLabel.Text = Sukuranburu.GetString("{Equipped}");
            MaxLevelLabel_Info.Text = Sukuranburu.GetString("{MaxLevel}");
            MasterPinButton.Text = Sukuranburu.GetString("{MasterThisPin}");

            Add99Checkbox.Text = Sukuranburu.GetString("{x99}");
            AddedPinIsMasteredCheckbox.Text = Sukuranburu.GetString("{Mastered}");
            AddPinAboutToMaster_Checkbox.Text = Sukuranburu.GetString("{AboutToMaster}");
            AddAllPinsButton.Text = Sukuranburu.GetString("{AddEachOfEveryPin}");
            AddPinButton.Text = Sukuranburu.GetString("{AddPin}");
        }

        private void GenerateEquippedData()
        {
            foreach (PartyMember Member in Sukuranburu.SelectedSlot.GetPartyMembers().Values)
            {
                EquippedByCharacterComboBox.Items.Add(Sukuranburu.GetGameString(Member.CharacterName));
            }
        }

        private void DisplayDefaultEquippedData()
        {
            if (SelectedPin == null || SelectedPin.DecksWithThisPin == null || SelectedPin.DecksWithThisPin.Count < 1)
            {
                EquippedDeckComboBox.SelectedIndex = 0;
                EquippedDeckComboBox.Enabled = SelectedPin != null && Sukuranburu.GetItemManager().PinIsMasterable(SelectedPin.PinId);
                EquippedByCharacterComboBox.Enabled = false;
                EquippedByCharacterComboBox.SelectedIndex = 0;
                CharacterIconPictureBox.Image = null;
                return;
            }

            byte FirstDeck = SelectedPin.DecksWithThisPin.Keys.First();
            byte MemberId = SelectedPin.DecksWithThisPin[FirstDeck];

            EquippedDeckComboBox.Enabled = true;
            EquippedByCharacterComboBox.Enabled = true;
            EquippedDeckComboBox.SelectedIndex = FirstDeck;
            EquippedByCharacterComboBox.Text = Sukuranburu.GetGameString(Sukuranburu.SelectedSlot.GetPartyMemberNameWithMemberId(MemberId));

            CharacterIconPictureBox.Image = ImageMethods.DrawImage(GetCharacterIconForPartyMember(EquippedByCharacterComboBox.Text), 32, 32, DeviceDpi);
        }

        private void DisplayEquippedData(byte DeckId)
        {
            if (SelectedPin == null || SelectedPin.DecksWithThisPin == null || SelectedPin.DecksWithThisPin.Count < 1 || !SelectedPin.DecksWithThisPin.ContainsKey(DeckId))
            {
                EquippedByCharacterComboBox.Enabled = DeckId != 0;
                EquippedByCharacterComboBox.SelectedIndex = 0;
                CharacterIconPictureBox.Image = null;
                return;
            }

            if (DeckId == 0)
            {
                EquippedByCharacterComboBox.Enabled = false;
                EquippedByCharacterComboBox.Text = Sukuranburu.GetString("{NoOne}");
                CharacterIconPictureBox.Image = null;
            }
            else
            {
                byte MemberId = SelectedPin.DecksWithThisPin[DeckId];
                EquippedByCharacterComboBox.Enabled = true;
                EquippedByCharacterComboBox.Text = Sukuranburu.GetGameString(Sukuranburu.SelectedSlot.GetPartyMemberNameWithMemberId(MemberId));
                CharacterIconPictureBox.Image = ImageMethods.DrawImage(GetCharacterIconForPartyMember(EquippedByCharacterComboBox.Text), 32, 32, DeviceDpi);
            }

        }

        private string GetCharacterIconForPartyMember(string CharacterNameValue)
        {
            if (CharacterNameValue == Sukuranburu.GetString("{NoOne}") || string.IsNullOrWhiteSpace(CharacterNameValue))
            {
                return null;
            }

            PartyMember Member = Sukuranburu.SelectedSlot.GetPartyMemberByNameValue(CharacterNameValue);
            if (Member != null)
            {
                return string.Format("Shop_img_chara_status_{0}", Member.CharacterId.ToString("D2"));
            }

            return null;
        }

        private void SaveAllData()
        {
            // First we're gonna clear out the pin equipped data

            for (int i = 0; i < 6; i++)
            {
                int OffsetSum = 36 * i;
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck1 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck2 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedPinIndex_Deck3 + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            }

            // Pin data:
            // int16: pin ID
            // int16: level
            // int32: experience

            int CurrentPointer = Offsets.PinInv_First;
            int PinIndexes = 0;

            foreach (InventoryPin Pin in InventoryPins)
            {
                for (int i = 0; i < Pin.Amount; i++)
                {
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer, Pin.PinId);
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer + 2, Pin.Level);
                    SelectedSlot.UpdateOffset_UInt32(CurrentPointer + 4, Pin.Experience);

                    // Add the equipped data.
                    if (Pin.DecksWithThisPin != null)
                    {
                        foreach (byte DeckId in Pin.DecksWithThisPin.Keys)
                        {
                            byte PartyMemberId = Pin.DecksWithThisPin[DeckId];
                            int OffsetSum = 36 * (PartyMemberId - 1);
                            int DeckOffsetSum = 4 * (DeckId - 1);

                            // check if we didn't add the equipped data already, for a duplicate of this pin, for example.
                            int ThisOffset = Offsets.PartyMember1_EquippedPinIndex_Deck1 + DeckOffsetSum + OffsetSum;
                            int StoredValue = SelectedSlot.RetrieveOffset_Int32(ThisOffset);

                            if (StoredValue == SaveData.NOT_ASSIGNED_DATA)
                            {
                                SelectedSlot.UpdateOffset_Int32(ThisOffset, PinIndexes);
                                SelectedSlot.GetPartyMemberWithId(PartyMemberId).EquippedPinIndexes[DeckId] = PinIndexes;
                            }
                        }
                    }

                    CurrentPointer += 8;
                    PinIndexes += 1;
                }
            }

            // Fill in the blanks.
            for (int i = CurrentPointer; i < Offsets.PinInv_VeryLast; i += 8)
            {
                SelectedSlot.UpdateOffset_UInt16(i, EMPTY_PIN_ID);
                SelectedSlot.UpdateOffset_UInt16(i + 2, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 4, 0);
                SelectedSlot.UpdateOffset_UInt16(i + 6, 0);
            }

            SelectedSlot.UpdateOffset_Int32(Offsets.PinInv_Count, PinIndexes);
            SelectedSlot.UpdateOffset_Int32(Offsets.PinInv_CountOfIndexes, PinIndexes - 1);
        }

        private void InsertPinToListView(InventoryPin Pin)
        {
            string Name = Sukuranburu.GetGameString(Pin.BasePin.Name);

            string MasteredSymbol = "—";
            if (Sukuranburu.GetItemManager().PinIsMasterable(Pin.BasePin))
            {
                MasteredSymbol = PinIsMastered(Pin.PinId, (byte)Pin.Level) ? "★" : Sukuranburu.GetString("{NoLowercase}");
            }

            string ElementName = "—";

            PinAttackElement AttackElement = Sukuranburu.GetItemManager().GetAttackElement(Pin.BasePin.MashupElement);
            if (AttackElement != null && !string.IsNullOrWhiteSpace(AttackElement.ElementIcon))
            {
                ElementName = Sukuranburu.GetGameString(AttackElement.ElementName);
            }

            ListViewItem PinToAdd = new ListViewItem(new string[]
                   {
                        Name,
                        Pin.PinId.ToString(),
                        Pin.Level.ToString(),
                        Pin.Experience.ToString(),
                        MasteredSymbol,
                        Pin.Amount.ToString(),
                        ElementName
                   })
            {
                ImageKey = Pin.BasePin.Sprite,
                Tag = Pin.ListIndex
            };
            MyPinInventoryView.Items.Add(PinToAdd);
        }

        private void SelectPin()
        {
            ReadyForUserInput = false;

            if (MyPinInventoryView.SelectedItems.Count < 1 || MyPinInventoryView.Items.Count < 1)
            {
                PinNameLabel.Text = Sukuranburu.GetString("{NoSelectedPin}");
                PinInfo_RichTextBox.Clear();

                AttackElementIcon_PictureBox.Image = null;
                AttackElement_Label.Text = string.Empty;
                UberPin_PictureBox.Image = null;
                UberPin_PictureBox.Visible = false;
                PinInputKey_PictureBox.Image = null;
                PinInputKey_PictureBox.Visible = false;

                RemovePinButton.Enabled = false;
                MasterPinButton.Enabled = false;
                PinImagePictureBox.Image = null;
                BrandPictureBox.Image = null;
                BrandLabel.Text = string.Empty;

                PinLevelNUpDown.Enabled = false;
                ExperienceNUpDown.Enabled = false;
                PinAmountUpDown.Enabled = false;

                MaxLevelLabel_Value.Text = "—";
                MasteredLabel.Text = string.Empty;

                PinLevelNUpDown.Value = 1;
                ExperienceNUpDown.Value = 0;
                PinAmountUpDown.Value = 1;
                SelectedPin = null;

                ReadyForUserInput = true;

                DisplayDefaultEquippedData();
                return;
            }

            InventoryPin Pin = InventoryPins[(int)MyPinInventoryView.SelectedItems[0].Tag];
            SelectedPin = Pin;

            Brand PinBrand = Sukuranburu.GetItemManager().GetBrand(Pin.BasePin.Brand);

            string PinName = Sukuranburu.GetGameString(Pin.BasePin.Name);
            string PinInfo = Sukuranburu.GetGameString(Pin.BasePin.Info);

            PinNameLabel.Text = PinName;
            Sukuranburu.GetGameTextProcessor().SetTaggedText(PinInfo, PinInfo_RichTextBox);


            PinImagePictureBox.Image = ImageMethods.DrawImage(Pin.BasePin.Sprite, 100, 100, DeviceDpi);

            if (PinBrand == null || PinBrand.Id == 0)
            {
                BrandPictureBox.Image = null;
                BrandLabel.Text = string.Empty;
            }
            else
            {
                BrandPictureBox.Image = ImageMethods.DrawImage(PinBrand.Sprite, 170, 60, DeviceDpi);
                BrandLabel.Text = Sukuranburu.GetGameString(PinBrand.Name);
            }

            RemovePinButton.Enabled = true;
            PinAmountUpDown.Enabled = true;

            PinLevelNUpDown.Enabled = true;
            ExperienceNUpDown.Enabled = true;
            PinAmountUpDown.Enabled = true;

            MaxLevelLabel_Value.Text = Pin.BasePin.MaxLevel.ToString();

            if (Sukuranburu.GetItemManager().PinIsMasterable(Pin.BasePin)) // a.k.a. battle pin
            {
                PinAttackElement AttackElement = Sukuranburu.GetItemManager().GetAttackElement(Pin.BasePin.MashupElement);
                if (AttackElement == null || AttackElement.ElementIcon == string.Empty)
                {
                    AttackElementIcon_PictureBox.Visible = false;
                    AttackElementIcon_PictureBox.Image = null;
                    AttackElement_Label.Text = string.Empty;
                }
                else
                {
                    AttackElementIcon_PictureBox.Visible = true;
                    AttackElementIcon_PictureBox.Image = ImageMethods.DrawImage(AttackElement.ElementIcon, 20, 20, DeviceDpi);
                    AttackElement_Label.Text = Sukuranburu.GetGameString(AttackElement.ElementName);
                }

                if (Sukuranburu.GetItemManager().PinIsUber(Pin.BasePin))
                {
                    UberPin_PictureBox.Image = ImageMethods.GetImageAsIs("GodBadge_star");
                    UberPin_PictureBox.Visible = true;
                }

                PinInputKey_PictureBox.Image = ImageMethods.DrawImage(Sukuranburu.GetItemManager().GetPsychKeyImage(Pin.BasePin), 32, 32, DeviceDpi);
                PinInputKey_PictureBox.Visible = true;

                MasterPinButton.Enabled = true;

                if (PinIsMastered(Pin.PinId, (byte)Pin.Level))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }
            else
            {
                MasterPinButton.Enabled = false;

                AttackElementIcon_PictureBox.Image = null;
                AttackElement_Label.Text = string.Empty;
                UberPin_PictureBox.Image = null;
                UberPin_PictureBox.Visible = false;
                PinInputKey_PictureBox.Image = null;
                PinInputKey_PictureBox.Visible = false;
            }

            PinLevelNUpDown.Value = Pin.Level;
            ExperienceNUpDown.Value = Pin.Experience;
            PinAmountUpDown.Value = Pin.Amount;

            DisplayDefaultEquippedData();

            ReadyForUserInput = true;
        }

        private void MyPinInventoryView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPin();
        }

        private bool PinIsMastered(ushort PinId, byte Level)
        {
            return Sukuranburu.GetItemManager().GetPinItem(PinId).MaxLevel == Level && Sukuranburu.GetItemManager().PinIsMasterable(PinId);
        }

        private void RemovePinButton_Click(object sender, EventArgs e)
        {
            if (MyPinInventoryView.Items.Count > 0 && MyPinInventoryView.SelectedItems.Count > 0)
            {
                ;
                int ThisIndex = (int)MyPinInventoryView.SelectedItems[0].Tag;
                InventoryPin Pin = InventoryPins[ThisIndex];

                MyPinInventoryView.Items.RemoveAt(ThisIndex);
                InventoryPins.Remove(Pin);

                if (ThisIndex > 0)
                {
                    if (MyPinInventoryView.Items.Count > ThisIndex)
                    {
                        MyPinInventoryView.Items[ThisIndex].Selected = true;
                        MyPinInventoryView.Select();
                    }
                    else if (MyPinInventoryView.Items.Count == ThisIndex)
                    {
                        MyPinInventoryView.Items[ThisIndex - 1].Selected = true;
                        MyPinInventoryView.Select();
                    }
                    else
                    {
                        SelectPin();
                    }

                }
                else
                {
                    SelectPin();
                }
            }
        }

        private void PinInventoryEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllData();
            ColumnSorter.DisposeColumn();
        }

        private void MyPinInventoryView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemovePinButton_Click(sender, e);
            }
        }

        private void PinLevelNUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (SelectedPin == null || PinLevelNUpDown.Value < PinLevelNUpDown.Minimum)
            {
                PinLevelNUpDown.Value = PinLevelNUpDown.Minimum;
                ReadyForUserInput = true;
                return;
            }
            else if (PinLevelNUpDown.Value > PinLevelNUpDown.Maximum)
            {
                PinLevelNUpDown.Value = PinLevelNUpDown.Maximum;
            }

            // Check for validity
            byte LevelToSet = (byte)PinLevelNUpDown.Value;
            byte MaxPossibleLevel = SelectedPin.BasePin.MaxLevel;

            if (LevelToSet > MaxPossibleLevel)
            {
                LevelToSet = MaxPossibleLevel;
                PinLevelNUpDown.Value = LevelToSet;
            }

            uint ExperienceToSet = (uint)ExperienceNUpDown.Value;
            uint ReqExperienceAtThisLevel = Sukuranburu.GetItemManager().GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, LevelToSet);
            uint MaxPossibleExperience = Sukuranburu.GetItemManager().GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, MaxPossibleLevel);

            if (ExperienceToSet > MaxPossibleExperience)
            {
                ExperienceToSet = MaxPossibleExperience;
                ExperienceNUpDown.Value = ExperienceToSet;
            }
            else
            {
                ExperienceToSet = ReqExperienceAtThisLevel;
                ExperienceNUpDown.Value = ExperienceToSet;
            }

            if (Sukuranburu.GetItemManager().PinIsMasterable(SelectedPin.BasePin))
            {
                if (PinIsMastered(SelectedPin.PinId, (byte)PinLevelNUpDown.Value))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }

            UpdateLevelAndExperience();

            ReadyForUserInput = true;
        }

        private void ExperienceNUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (SelectedPin == null || ExperienceNUpDown.Value < ExperienceNUpDown.Minimum)
            {
                ExperienceNUpDown.Value = ExperienceNUpDown.Minimum;
                ReadyForUserInput = true;
                return;
            }
            else if (ExperienceNUpDown.Value > ExperienceNUpDown.Maximum)
            {
                ExperienceNUpDown.Value = ExperienceNUpDown.Maximum;
            }

            // Check for validity
            byte LevelToSet = (byte)PinLevelNUpDown.Value;
            uint ExperienceToSet = (uint)ExperienceNUpDown.Value;
            byte MaxPossibleLevel = SelectedPin.BasePin.MaxLevel;
            uint MaxPossibleExperience = Sukuranburu.GetItemManager().GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, MaxPossibleLevel);

            if (ExperienceToSet >= MaxPossibleExperience)
            {
                ExperienceToSet = MaxPossibleExperience;
                LevelToSet = MaxPossibleLevel;
            }
            else
            {
                LevelToSet = Sukuranburu.GetItemManager().GetPinLevelWithPinIdAndExperience(SelectedPin.PinId, ExperienceToSet);
            }

            ExperienceNUpDown.Value = ExperienceToSet;
            PinLevelNUpDown.Value = LevelToSet;

            if (Sukuranburu.GetItemManager().PinIsMasterable(SelectedPin.BasePin))
            {
                if (PinIsMastered(SelectedPin.PinId, (byte)PinLevelNUpDown.Value))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }

            UpdateLevelAndExperience();

            ReadyForUserInput = true;
        }

        private void MasterPinButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (SelectedPin == null)
            {
                ReadyForUserInput = true;
                return;
            }

            byte MaxPossibleLevel = SelectedPin.BasePin.MaxLevel;
            uint MaxPossibleExperience = Sukuranburu.GetItemManager().GetPinExperienceWithPinIdAndLevel(SelectedPin.PinId, MaxPossibleLevel);

            ExperienceNUpDown.Value = MaxPossibleExperience;
            PinLevelNUpDown.Value = MaxPossibleLevel;

            if (Sukuranburu.GetItemManager().PinIsMasterable(SelectedPin.BasePin))
            {
                if (PinIsMastered(SelectedPin.PinId, (byte)PinLevelNUpDown.Value))
                {
                    MasteredLabel.Text = "★";
                }
                else
                {
                    MasteredLabel.Text = string.Empty;
                }
            }

            UpdateLevelAndExperience();

            ReadyForUserInput = true;
        }

        private void UpdateLevelAndExperience()
        {
            int Index = UpdateColumn(new int[] { 2, 3 }, new object[] { PinLevelNUpDown.Value, ExperienceNUpDown.Value });

            SelectedPin.Level = (ushort)PinLevelNUpDown.Value;
            SelectedPin.Experience = (ushort)ExperienceNUpDown.Value;

            if (Index != -1 && Sukuranburu.GetItemManager().PinIsMasterable(SelectedPin.PinId))
            {
                MyPinInventoryView.Items[Index].SubItems[4].Text = PinIsMastered(SelectedPin.PinId, (byte)SelectedPin.Level) ? "★" : Sukuranburu.GetString("{NoLowercase}");
            }
        }

        private void PinAmountUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            ushort AmountToSet = (ushort)PinAmountUpDown.Value;

            if (AmountToSet < (ushort)PinAmountUpDown.Minimum)
            {
                AmountToSet = (ushort)PinAmountUpDown.Minimum;
            }
            else if (AmountToSet > (ushort)PinAmountUpDown.Maximum)
            {
                AmountToSet = (ushort)PinAmountUpDown.Maximum;
            }

            UpdateAmount();

            ReadyForUserInput = true;
        }

        private int UpdateColumn(int ItemIndex, object Value)
        {
            for (int i = 0; i < MyPinInventoryView.Items.Count; i++)//foreach (ListViewItem Item in MyPinInventoryView.Items)
            {
                ListViewItem Item = MyPinInventoryView.Items[i];

                if (Item.SubItems[1].Text == SelectedPin.PinId.ToString() && Item.SubItems[2].Text == SelectedPin.Level.ToString() && Item.SubItems[3].Text == SelectedPin.Experience.ToString())
                {
                    Item.SubItems[ItemIndex].Text = Value.ToString();
                    return i;
                }
            }

            return -1;
        }

        private int UpdateColumn(int[] ItemIndex, object[] Value)
        {
            for (int i = 0; i < MyPinInventoryView.Items.Count; i++)//foreach (ListViewItem Item in MyPinInventoryView.Items)
            {
                ListViewItem Item = MyPinInventoryView.Items[i];

                if (Item.SubItems[1].Text == SelectedPin.PinId.ToString() && Item.SubItems[2].Text == SelectedPin.Level.ToString() && Item.SubItems[3].Text == SelectedPin.Experience.ToString())
                {
                    for (int j = 0; j < ItemIndex.Length; j++)
                    {
                        Item.SubItems[ItemIndex[j]].Text = Value[j].ToString();
                    }

                    return i;
                }
            }

            return -1;
        }

        private void UpdateAmount()
        {
            UpdateColumn(5, PinAmountUpDown.Value);
            SelectedPin.Amount = (ushort)PinAmountUpDown.Value;
        }

        private void RemoveAllPinsButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_DeleteAllPinsAreYouSure")))
            {
                if (!WarnedAboutZeroPins)
                {
                    Sukuranburu.ShowNotice(Sukuranburu.GetString("DLG_ZeroPinsWarning"));
                    WarnedAboutZeroPins = true;
                }

                MyPinInventoryView.Items.Clear();
                InventoryPins.Clear();
                SelectedPin = null;

                SelectPin();
            }

            ReadyForUserInput = true;
        }

        private void AddPinButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (AllPinsListView.SelectedItems.Count < 1)
            {
                Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_NoPinsToAddSelected"));
                ReadyForUserInput = true;
                return;
            }

            foreach (ListViewItem Item in AllPinsListView.SelectedItems)
            {
                AddPin(Item, true);
            }

            SelectPin();
            ReadyForUserInput = true;
        }

        private void AddAllPinsButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }
            ReadyForUserInput = false;

            foreach (ListViewItem Item in AllPinsListView.Items)
            {
                AddPin(Item, false);
            }

            SelectPin();
            ReadyForUserInput = true;
        }

        private void AddPin(ListViewItem Item, bool Individual) //individual= adding this pin through "Add pin" button.
        {
            ushort PinId = Convert.ToUInt16(Item.SubItems[1].Text);
            PinItem Pin = Sukuranburu.GetItemManager().GetPinItem(PinId);

            byte Level = 1;
            uint Experience = 0;

            if (Sukuranburu.GetItemManager().PinIsMasterable(Pin))
            {
                if (AddedPinIsMasteredCheckbox.Checked)
                {
                    Level = Pin.MaxLevel;
                    Experience = Sukuranburu.GetItemManager().GetPinExperienceWithPinIdAndLevel(PinId, Level);
                }
                else if (AddPinAboutToMaster_Checkbox.Checked)
                {
                    Level = (byte)(Pin.MaxLevel - 1);
                    Experience = Sukuranburu.GetItemManager().GetPinExperienceWithPinIdAndLevel(PinId, Pin.MaxLevel) - 1;
                }
            }

            InventoryPin PinToAdd = new InventoryPin(PinId, Level, Experience);

            if (InventoryPins.Contains(PinToAdd))
            {
                if (Individual && InventoryPins[PinToAdd.ListIndex].Amount == 99)
                {
                    Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_YouCantAddMorePins"));
                    ReadyForUserInput = true;
                    return;
                }

                int Index = InventoryPins.IndexOf(PinToAdd);

                if (Add99Checkbox.Checked)
                {
                    InventoryPins[Index].Amount = 99;
                }
                else if (InventoryPins[PinToAdd.ListIndex].Amount < 99)
                {
                    InventoryPins[Index].Amount += 1;
                }

                MyPinInventoryView.Items[Index].SubItems[5].Text = InventoryPins[Index].Amount.ToString();
            }
            else
            {
                if (Add99Checkbox.Checked)
                {
                    PinToAdd.Amount = 99;
                }
                else
                {
                    PinToAdd.Amount = 1;
                }

                PinToAdd.ListIndex = InventoryPins.Count;
                InventoryPins.Add(PinToAdd);
                InsertPinToListView(PinToAdd);
            }
        }

        private void EquippedDeckComboBox_TextChanged(object sender, EventArgs e)
        {
            DisplayEquippedData((byte)EquippedDeckComboBox.SelectedIndex);
        }

        private void EquippedByCharacterComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            byte DeckId = (byte)EquippedDeckComboBox.SelectedIndex;
            if (DeckId == 0)
            {
                ReadyForUserInput = true;
                return;
            }
            else if (EquippedByCharacterComboBox.Text == Sukuranburu.GetString("{NoOne}"))
            {
                if (SelectedPin.DecksWithThisPin != null)
                {
                    SelectedPin.DecksWithThisPin.Remove(DeckId);

                    if (SelectedPin.DecksWithThisPin.Count == 0)
                    {
                        SelectedPin.DecksWithThisPin = null; // clear. necessary? idk
                    }
                }

                ReadyForUserInput = true;
                CharacterIconPictureBox.Image = null;
                return;
            }

            // check for validity.

            PartyMember OldMember = null;
            if (SelectedPin.DecksWithThisPin != null)
            {
                if (SelectedPin.DecksWithThisPin.ContainsKey(DeckId))
                {
                    OldMember = Sukuranburu.SelectedSlot.GetPartyMemberWithId(SelectedPin.DecksWithThisPin[DeckId]);
                }
            }
            else
            {
                SelectedPin.DecksWithThisPin = new Dictionary<byte, byte>();
            }

            PartyMember NewMember = Sukuranburu.SelectedSlot.GetPartyMemberByNameValue(EquippedByCharacterComboBox.Text);
            InventoryPin NewMember_PreviouslyEquippedPin = InventoryPins.FirstOrDefault(p
               => p.DecksWithThisPin != null
               && p.DecksWithThisPin.ContainsKey(DeckId)
               && p.DecksWithThisPin[DeckId] == NewMember.Id);

            if (OldMember != null)
            {
                // do an exchange
                if (NewMember_PreviouslyEquippedPin != null)
                {
                    NewMember_PreviouslyEquippedPin.DecksWithThisPin[DeckId] = (byte)OldMember.Id;
                } // else I could do some warning, because old member never had an equipped pin in the first place °_°.
            }

            if (SelectedPin.DecksWithThisPin.ContainsKey(DeckId))
            {
                SelectedPin.DecksWithThisPin[DeckId] = (byte)NewMember.Id;
            }
            else
            {
                SelectedPin.DecksWithThisPin.Add(DeckId, (byte)NewMember.Id);
            }

            CharacterIconPictureBox.Image = ImageMethods.DrawImage(GetCharacterIconForPartyMember(EquippedByCharacterComboBox.Text), 32, 32, DeviceDpi);
            ReadyForUserInput = true;
        }

        private void AllPinsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(AllPinsListView, e);
        }

        private void MyPinInventoryView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(MyPinInventoryView, e);
        }

        private void AddedPinIsMasteredCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AddedPinIsMasteredCheckbox.Checked)
            {
                AddPinAboutToMaster_Checkbox.Checked = false;
            }
        }

        private void AddPinAboutToMaster_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AddPinAboutToMaster_Checkbox.Checked)
            {
                AddedPinIsMasteredCheckbox.Checked = false;
            }
        }
    }
}
