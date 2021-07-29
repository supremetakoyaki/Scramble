using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class ClothingInventoryEditor : Form
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

        public const short EMPTY_CLOTHING_ID = -1;
        public const byte SLOT_HEADWEAR = 0;
        public const byte SLOT_TOP = 1;
        public const byte SLOT_BOTTOM = 2;
        public const byte SLOT_SHOEWEAR = 3;
        public const byte SLOT_ACCESSORY = 4;
        public const byte SLOT_TOP_AND_BOTTOM = 5;

        private List<InventoryFashion> InventoryClothes;
        private InventoryFashion SelectedClothing;

        public const ushort MAXIMUM = 2000;
        int TotalCount;

        private bool ReadyForUserInput = false; // flag that indicates whether the editor is working on changing values on its own.    


        public ClothingInventoryEditor()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.MyClothingInvListView.SmallImageList = Sukuranburu.Get32x32AllCollectionIconsImageList();
            this.AllClothingItemsListView.SmallImageList = Sukuranburu.Get64x64FashionImageList();

            DisplayLanguageStrings();
            Serialize();
            SerializeGlobal();

            ReadyForUserInput = true;
            SelectClothing();
        }

        private void DisplayLanguageStrings()
        {
            this.EquippedByCharacterComboBox.Items.Add(Sukuranburu.GetString("{NoOne}"));

            this.Text = Sukuranburu.GetString("{ClothingEditor}");
            this.ClothingInvGroupBox.Text = Sukuranburu.GetString("{MyClothingInventory}");
            this.AllClothingItemsGroupBox.Text = Sukuranburu.GetString("{AllClothingItems}");
            this.ClthIdHeader.Text = Sukuranburu.GetString("{Id}");
            this.ClthNameHeader.Text = Sukuranburu.GetString("{Name}");
            this.ClthSlotHeader.Text = Sukuranburu.GetString("{Type}");
            this.ClthAmountHeader.Text = Sukuranburu.GetString("{Amount}");
            this.GlobalClthIdHeader.Text = Sukuranburu.GetString("{Id}");
            this.GlobalClthNameHeader.Text = Sukuranburu.GetString("{Name}");
            this.EquippedLabel.Text = Sukuranburu.GetString("{Equipped}");
            this.ATKLabel.Text = Sukuranburu.GetString("{Atk:}");
            this.DefenseLabel.Text = Sukuranburu.GetString("{Def:}");
            this.HpLabel.Text = Sukuranburu.GetString("{Hp:}");
            this.ReqStyleLabel.Text = Sukuranburu.GetString("{ReqStyle}");
            this.AbilityLabel.Text = Sukuranburu.GetString("{Ability:}");
            this.AmountLabel.Text = Sukuranburu.GetString("{Amount:}");
            this.RemoveClothingButton.Text = Sukuranburu.GetString("{RemoveThisClothing}");
            this.RemoveAllClothingButton.Text = Sukuranburu.GetString("{RemoveAllClothing}");
            this.AddClothingItemButton.Text = Sukuranburu.GetString("{AddClothing}");
            this.AddEachOfEveryClothingButton.Text = Sukuranburu.GetString("{AddEveryClothing}");
        }
        private void Serialize()
        {
            InventoryClothes = new List<InventoryFashion>();
            GenerateEquippedData();

            //Clothing data
            // int16 ID

            int ClothesCount = SelectedSlot.RetrieveOffset_Int32(Offsets.ClothingInv_Count);

            for (int Index = 0; Index < ClothesCount; Index++)
            {
                int ClothingId = (int)(SelectedSlot.RetrieveOffset_UInt16(Offsets.ClothingInv_First + (Index * 2)));
                ClothingId -= 1; // you subtract 1 to the ID

                if (ClothingId > 0x8000)
                {
                    ClothingId -= 0x8000; // this means the clothing is unseen (says "New" in the inventory).
                }

                if (ClothingId != EMPTY_CLOTHING_ID && TotalCount < MAXIMUM)
                {
                    InventoryFashion ClothingToAdd = new InventoryFashion((ushort)ClothingId);
                    int invIndex = InventoryClothes.IndexOf(ClothingToAdd);

                    if (invIndex == -1)
                    {
                        ClothingToAdd.Amount = 1;
                        ClothingToAdd.EquipperId = ClothingToAdd.WhosEquippingThis(Index);

                        TotalCount += 1;
                        InventoryClothes.Add(ClothingToAdd);
                    }
                    else
                    {
                        if (InventoryClothes[invIndex].Amount < 9)
                        {
                            InventoryClothes[invIndex].Amount += 1;
                            TotalCount += 1;
                        }

                        if (InventoryClothes[invIndex].EquipperId == 0)
                        {
                            InventoryClothes[invIndex].EquipperId = ClothingToAdd.WhosEquippingThis(Index);
                        }
                    }
                }
            }

            foreach (InventoryFashion Piece in InventoryClothes)
            {
                InsertClothingToListView(Piece);
            }

            if (MyClothingInvListView.Items.Count > 0)
            {
                MyClothingInvListView.Items[0].Selected = true;
                MyClothingInvListView.Select();
            }
        }

        private void SerializeGlobal()
        {
            var ItemDictionary = Sukuranburu.GetItemManager().GetItems();

            foreach (IGameItem Item in ItemDictionary.Values)
            {
                if (Item is ClothingItem)
                {
                    ClothingItem Clothing = Item as ClothingItem;

                    string ClothingName = Sukuranburu.GetGameString(Clothing.Name);
                    string ClothingIcon = string.Format("{0}.png", Clothing.Sprite);

                    ListViewItem PinToAdd = new ListViewItem(new string[]
                    {
                    ClothingName,
                    Clothing.ParticularId.ToString()
                    });

                    PinToAdd.ImageKey = ClothingIcon;
                    AllClothingItemsListView.Items.Add(PinToAdd);
                }
            }
        }

        private void GenerateEquippedData()
        {
            foreach (PartyMember Member in Sukuranburu.SelectedSlot.GetPartyMembers().Values)
            {
                this.EquippedByCharacterComboBox.Items.Add(Sukuranburu.GetGameString(Member.CharacterName));
            }
        }

        private void SelectClothing()
        {
            ReadyForUserInput = false;

            if (MyClothingInvListView.SelectedIndices.Count == 0 || MyClothingInvListView.SelectedItems.Count != 1 || MyClothingInvListView.Items.Count < 1)
            {
                ClothingItem_NameLabel.Text = Sukuranburu.GetString("{NoClothingSelected}");

                RemoveClothingButton.Enabled = false;
                AmountNumericUpDown.Enabled = false;
                ClothingItem_PictureBox.Image = null;
                BrandPictureBox.Image = null;

                AtkValueLabel.Text = "—";
                DefValueLabel.Text = "—";
                HpValueLabel.Text = "—";
                ReqStyleValueLabel.Text = "—";
                ReqStyleValueLabel.Location = new Point(243, 469);
                AbilityNameLabel.Text = "—";
                AbilityDescLabel.Text = "—";


                SlotType_PictureBox.Image = null;
                WearTypeLabel.Text = string.Empty;

                AmountNumericUpDown.Value = 1;
                SelectedClothing = null;

                ReadyForUserInput = true;

                DisplayDefaultEquippedData();
                return;
            }

            InventoryFashion Clothing = InventoryClothes[MyClothingInvListView.SelectedIndices[0]];
            SelectedClothing = Clothing;

            Brand ClothingBrand = Sukuranburu.GetItemManager().GetBrand(Clothing.BaseClothing.Brand);

            string ClothingName = Sukuranburu.GetGameString(Clothing.BaseClothing.Name);
            string ClothingSprite = string.Format("{0}.png", Clothing.BaseClothing.Sprite);
            string BrandSprite = string.Format("{0}.png", ClothingBrand.Sprite);

            ClothingItem_NameLabel.Text = ClothingName;
            BrandLabel.Text = Sukuranburu.GetGameString(ClothingBrand.Name);
            ClothingItem_PictureBox.Image = Sukuranburu.Get128x128FashionImageList().Images[ClothingSprite];
            BrandPictureBox.Image = Sukuranburu.GetBrandImageList().Images[BrandSprite];

            SlotType_PictureBox.Image = Sukuranburu.Get32x32MiscIconsImageList().Images[string.Format("Item_icon_category_Next{0}.png", Clothing.BaseClothing.SlotType.ToString("D2"))];
            WearTypeLabel.Text = Sukuranburu.GetString("{WearType" + Clothing.BaseClothing.SlotType + "}");

            RemoveClothingButton.Enabled = true;
            AmountNumericUpDown.Enabled = true;
            AmountNumericUpDown.Value = Clothing.Amount;

            AtkValueLabel.Text = string.Format("+{0}", Clothing.BaseClothing.AtkBoost);
            DefValueLabel.Text = string.Format("+{0}", Clothing.BaseClothing.DefBoost);
            HpValueLabel.Text = string.Format("+{0}", Clothing.BaseClothing.HpBoost);
            ReqStyleValueLabel.Text = Clothing.BaseClothing.StyleReq.ToString();
            ReqStyleValueLabel.Location = new Point(251, 469);

            Ability ClothingAbility = Sukuranburu.GetItemManager().GetAbility(Clothing.BaseClothing.AbilityId);

            if (ClothingAbility == null)
            {
                AbilityNameLabel.Text = "—";
                AbilityDescLabel.Text = "—";
            }
            else
            {
                AbilityNameLabel.Text = Sukuranburu.GetGameString(ClothingAbility.Name);
                AbilityDescLabel.Text = Sukuranburu.GetGameString(ClothingAbility.Info);
            }

            DisplayDefaultEquippedData();
            ReadyForUserInput = true;
        }

        private void DisplayDefaultEquippedData()
        {
            if (SelectedClothing == null)
            {
                this.EquippedByCharacterComboBox.Enabled = false;
                this.EquippedByCharacterComboBox.SelectedIndex = 0;
                this.CharacterIconPictureBox.Image = Sukuranburu.GetCharacterIconList().Images["0.png"];
                return;
            }

            this.EquippedByCharacterComboBox.Enabled = true;
            if (SelectedClothing.EquipperId != 0)
            {
                this.EquippedByCharacterComboBox.Text = Sukuranburu.GetGameString(Sukuranburu.SelectedSlot.GetPartyMemberNameWithMemberId(SelectedClothing.EquipperId));
                this.CharacterIconPictureBox.Image = Sukuranburu.GetCharacterIconList().Images[GetCharacterIconForPartyMember((string)EquippedByCharacterComboBox.Text)];
            }
        }

        private string GetCharacterIconForPartyMember(string CharacterNameValue)
        {
            if (CharacterNameValue == Sukuranburu.GetString("{NoOne}") || string.IsNullOrWhiteSpace(CharacterNameValue))
            {
                return "0.png";
            }

            PartyMember Member = Sukuranburu.SelectedSlot.GetPartyMemberByNameValue(CharacterNameValue);
            if (Member != null)
            {
                return Member.CharacterId + ".png";
            }

            return "0.png";
        }

        public string GetCharacterIconForPartyMember(int MemberId)
        {
            PartyMember Member = Sukuranburu.SelectedSlot.GetPartyMemberWithId(MemberId);
            if (Member != null)
            {
                return Member.CharacterId + ".png";
            }

            return "0.png";
        }

        private void InsertClothingToListView(InventoryFashion Piece)
        {
            string Name = Sukuranburu.GetGameString(Piece.BaseClothing.Name);
            string Icon = string.Format("{0}.png", Piece.BaseClothing.Sprite);

            ListViewItem ClothingToAdd = new ListViewItem(new string[]
                   {
                        Name,
                        Piece.Id.ToString(),
                        Sukuranburu.GetString("{WearType" + Piece.BaseClothing.SlotType + "}"),
                        Piece.Amount.ToString()
                   });

            ClothingToAdd.ImageKey = Icon;
            MyClothingInvListView.Items.Add(ClothingToAdd);
        }

        private void UpdateAmount()
        {
            int Index = InventoryClothes.IndexOf(SelectedClothing);

            SelectedClothing.Amount = (ushort)AmountNumericUpDown.Value;
            MyClothingInvListView.Items[Index].SubItems[3].Text = SelectedClothing.Amount.ToString();
        }

        private void AddClothing(ListViewItem Item, bool Individual) //individual= adding this piece through "Add pin" button.
        {
            ushort ClothingId = Convert.ToUInt16(Item.SubItems[1].Text);
            ClothingItem ClothingItem = Sukuranburu.GetItemManager().GetClothingItem(ClothingId);

            InventoryFashion ClothingToAdd = new InventoryFashion(ClothingId);

            if (TotalCount >= MAXIMUM)
            {
                if (Individual)
                {
                    Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_YouCantAddMoreClothes"));
                }
                return;
            }

            if (InventoryClothes.Contains(ClothingToAdd))
            {
                int Index = InventoryClothes.IndexOf(ClothingToAdd);
                if (Individual && (TotalCount >= MAXIMUM || InventoryClothes[Index].Amount == 9))
                {
                    Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_YouCantAddMoreClothes"));

                    ReadyForUserInput = true;
                    return;
                }

                if (TotalCount + 1 <= MAXIMUM)
                {
                    InventoryClothes[Index].Amount += 1;
                    TotalCount += 1;
                }

                MyClothingInvListView.Items[Index].SubItems[3].Text = InventoryClothes[Index].Amount.ToString();
            }
            else
            {
                if (TotalCount + 1 <= MAXIMUM)
                {
                    TotalCount += 1;
                    ClothingToAdd.Amount = 1;
                }

                InventoryClothes.Add(ClothingToAdd);
                InsertClothingToListView(ClothingToAdd);
            }
        }

        private void SaveAllData()
        {
            // First we're gonna clear out the pin equipped data
            for (int i = 0; i < 6; i++)
            {
                int OffsetSum = 36 * i;
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedHeadwearIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedTopIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedBottomIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedShoesIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
                SelectedSlot.UpdateOffset_Int32(Offsets.PartyMember1_EquippedAccessoryIndex + OffsetSum, SaveData.NOT_ASSIGNED_DATA);
            }

            foreach (PartyMember Member in SelectedSlot.GetPartyMembers().Values)
            {
                for (int i = 0; i < 5; i++)
                {
                    Member.EquippedClothingIndexes[i] = -1;
                }
            }

            int CurrentPointer = Offsets.ClothingInv_First;
            int Indexes = 0;

            // Clothing data
            // int16: ID + 1 (+32768 if we want it to show "New")
            foreach (InventoryFashion Clothing in InventoryClothes)
            {
                for (int i = 0; i < Clothing.Amount; i++)
                {
                    SelectedSlot.UpdateOffset_UInt16(CurrentPointer, (ushort)(Clothing.Id + 1));

                    if (Clothing.EquipperId != 0)
                    {
                        bool IsTopAndBottom = Clothing.BaseClothing.SlotType == 5;
                        byte SlotType = IsTopAndBottom ? SLOT_TOP : Clothing.BaseClothing.SlotType;

                        int OffsetSum = 36 * (Clothing.EquipperId - 1);
                        int SlotSum = 4 * SlotType;

                        int ThisOffset = Offsets.PartyMember1_EquippedHeadwearIndex + OffsetSum + SlotSum;

                        // check if we didn't add the equipped data already, for a duplicate of this pin, for example.
                        int StoredValue = SelectedSlot.RetrieveOffset_Int32(ThisOffset);

                        if (StoredValue == SaveData.NOT_ASSIGNED_DATA)
                        {
                            SelectedSlot.UpdateOffset_Int32(ThisOffset, Indexes);
                            SelectedSlot.GetPartyMemberWithId(Clothing.EquipperId).EquippedClothingIndexes[SlotType] = Indexes;

                            if (IsTopAndBottom) // would this work?
                            {
                                SelectedSlot.UpdateOffset_Int32(ThisOffset + 4, Indexes);
                                SelectedSlot.GetPartyMemberWithId(Clothing.EquipperId).EquippedClothingIndexes[SlotType+1] = Indexes;
                            }
                        }
                    }

                    CurrentPointer += 2;
                    Indexes += 1;
                }
            }

            SelectedSlot.UpdateOffset_Int32(Offsets.ClothingInv_Count, Indexes);
        }

        private void MyClothingInvListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectClothing();
        }

        private void AmountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            ushort AmountToSet = (ushort)AmountNumericUpDown.Value;
            if (AmountToSet < (ushort)AmountNumericUpDown.Minimum)
            {
                AmountToSet = (ushort)AmountNumericUpDown.Minimum;
            }
            else if (AmountToSet > (ushort)AmountNumericUpDown.Maximum)
            {
                AmountToSet = (ushort)AmountNumericUpDown.Maximum;
            }

            ushort OldAmount = SelectedClothing.Amount;
            int Change = AmountToSet - OldAmount;

            if (TotalCount + Change > MAXIMUM)
            {
                AmountNumericUpDown.Value = OldAmount;
                ReadyForUserInput = true;

                Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_YouCantAddMoreClothes"));
                return;
            }

            TotalCount += Change;

            UpdateAmount();

            ReadyForUserInput = true;
        }

        private void RemoveClothingButton_Click(object sender, EventArgs e)
        {
            if (MyClothingInvListView.Items.Count > 0 && MyClothingInvListView.SelectedIndices.Count > 0)
            {
                int ThisIndex = MyClothingInvListView.SelectedIndices[0];
                InventoryFashion Clothing = InventoryClothes[ThisIndex];

                MyClothingInvListView.Items.RemoveAt(ThisIndex);
                InventoryClothes.Remove(Clothing);

                if (ThisIndex > 0)
                {
                    if (MyClothingInvListView.Items.Count > ThisIndex)
                    {
                        MyClothingInvListView.Items[ThisIndex].Selected = true;
                        MyClothingInvListView.Select();
                    }
                    else if (MyClothingInvListView.Items.Count == ThisIndex)
                    {
                        MyClothingInvListView.Items[ThisIndex - 1].Selected = true;
                        MyClothingInvListView.Select();
                    }
                    else
                    {
                        SelectClothing();
                    }

                }
                else
                {
                    SelectClothing();
                }
            }
        }

        private void RemoveAllClothingButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (Sukuranburu.ShowPrompt(Sukuranburu.GetString("DLG_DeleteAllClothingAreYouSure")))
            {
                MyClothingInvListView.Items.Clear();
                InventoryClothes.Clear();
                SelectedClothing = null;

                SelectClothing();
            }

            ReadyForUserInput = true;
        }

        private void AddClothingItemButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (MyClothingInvListView.SelectedIndices.Count < 1)
            {
                Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_NoClothingToAddSelected"));
                ReadyForUserInput = true;
                return;
            }

            ListViewItem Item = AllClothingItemsListView.SelectedItems[0];

            AddClothing(Item, true);

            SelectClothing();
            ReadyForUserInput = true;
        }

        private void AddEachOfEveryClothingButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            if (TotalCount >= MAXIMUM)
            {
                Sukuranburu.ShowWarning(Sukuranburu.GetString("DLG_YouCantAddMoreClothes"));
                return;
            }

            ReadyForUserInput = false;

            foreach (ListViewItem Item in AllClothingItemsListView.Items)
            {
                AddClothing(Item, false);
            }

            SelectClothing();
            ReadyForUserInput = true;
        }

        private void EquippedByCharacterComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedClothing == null)
            {
                return;
            }

            ReadyForUserInput = false;

            if (EquippedByCharacterComboBox.Text == Sukuranburu.GetString("{NoOne}"))
            {
                SelectedClothing.EquipperId = 0;

                ReadyForUserInput = true;
                this.CharacterIconPictureBox.Image = Sukuranburu.GetCharacterIconList().Images["0.png"];
                return;
            }

            // Validity checking
            PartyMember OldMember = SelectedSlot.GetPartyMemberWithId(SelectedClothing.EquipperId);
            PartyMember NewMember = Sukuranburu.SelectedSlot.GetPartyMemberByNameValue(EquippedByCharacterComboBox.Text);

            Dictionary<byte, InventoryFashion> NewMember_PreviouslyEquippedClothing = InventoryClothes.Where(c
                   => c.EquipperId == NewMember.Id).ToDictionary(x => x.BaseClothing.SlotType, x => x);

            foreach (byte SlotType in NewMember_PreviouslyEquippedClothing.Keys)
            {
                InventoryFashion PreviousPiece = NewMember_PreviouslyEquippedClothing[SlotType];

                if (SelectedClothing.BaseClothing.SlotType == SLOT_TOP_AND_BOTTOM)
                {
                    if (SlotType == SLOT_TOP || SlotType == SLOT_BOTTOM || SlotType == SLOT_TOP_AND_BOTTOM)
                    {
                        PreviousPiece.EquipperId = OldMember != null ? (byte)OldMember.Id : (byte)0;
                    }
                }
                else if (SlotType == SLOT_TOP_AND_BOTTOM && (SelectedClothing.BaseClothing.SlotType == SLOT_TOP || SelectedClothing.BaseClothing.SlotType == SLOT_BOTTOM))
                {
                    PreviousPiece.EquipperId = OldMember != null ? (byte)OldMember.Id : (byte)0;
                }
                else if (SlotType == SLOT_TOP && SelectedClothing.BaseClothing.SlotType == SLOT_TOP_AND_BOTTOM)
                {
                    PreviousPiece.EquipperId = OldMember != null ? (byte)OldMember.Id : (byte)0;
                }
                else if (SlotType == SLOT_BOTTOM && SelectedClothing.BaseClothing.SlotType == SLOT_TOP_AND_BOTTOM)
                {
                    PreviousPiece.EquipperId = OldMember != null ? (byte)OldMember.Id : (byte)0;
                }
                else if (SlotType == SelectedClothing.BaseClothing.SlotType)
                {
                    PreviousPiece.EquipperId = OldMember != null ? (byte)OldMember.Id : (byte)0;
                }
            }

            Dictionary<byte, InventoryFashion> OldMember_PreviouslyEquippedClothing = OldMember != null ? InventoryClothes.Where(c
       => c.EquipperId == OldMember.Id).ToDictionary(x => x.BaseClothing.SlotType, x => x) : null;

            if (OldMember_PreviouslyEquippedClothing != null)
            {
                if (OldMember_PreviouslyEquippedClothing.ContainsKey(SLOT_TOP_AND_BOTTOM))
                {
                    if (OldMember_PreviouslyEquippedClothing.ContainsKey(SLOT_TOP))
                    {
                        OldMember_PreviouslyEquippedClothing[SLOT_TOP].EquipperId = 0;
                    }

                    if (OldMember_PreviouslyEquippedClothing.ContainsKey(SLOT_BOTTOM))
                    {
                        OldMember_PreviouslyEquippedClothing[SLOT_BOTTOM].EquipperId = 0;

                    }
                }
            }

            SelectedClothing.EquipperId = (byte)NewMember.Id;

            this.CharacterIconPictureBox.Image = Sukuranburu.GetCharacterIconList().Images[GetCharacterIconForPartyMember(NewMember.Id)];
            ReadyForUserInput = true;
        }

        private void ClothingInventoryEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllData();
        }
    }
}
