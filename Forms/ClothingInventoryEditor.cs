using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;

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
        private List<InventoryFashion> InventoryClothes;
        private InventoryFashion SelectedClothing;

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
            this.Add99Checkbox.Text = Sukuranburu.GetString("{x99}");
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

                if (ClothingId != EMPTY_CLOTHING_ID)
                {
                    InventoryFashion ClothingToAdd = new InventoryFashion((ushort)ClothingId);
                    int invIndex = InventoryClothes.IndexOf(ClothingToAdd);

                    if (invIndex == -1)
                    {
                        ClothingToAdd.Amount = 1;
                        ClothingToAdd.EquipperId = ClothingToAdd.WhosEquippingThis(Index);

                        InventoryClothes.Add(ClothingToAdd);
                    }
                    else
                    {
                        if (InventoryClothes[invIndex].Amount < 99)
                        {
                            InventoryClothes[invIndex].Amount += 1;
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

            AtkValueLabel.Text = string.Format("+{0}", Clothing.BaseClothing.AtkBoost);
            DefValueLabel.Text = string.Format("+{0}", Clothing.BaseClothing.DefBoost);
            HpValueLabel.Text = string.Format("+{0}", Clothing.BaseClothing.HpBoost);
            ReqStyleValueLabel.Text = Clothing.BaseClothing.StyleReq.ToString();

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

            if (SelectedClothing.EquipperId != 0)
            {
                this.EquippedByCharacterComboBox.Enabled = true;
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

        private void InsertClothingToListView(InventoryFashion Piece)
        {
            string Name = Sukuranburu.GetGameString(Piece.BaseClothing.Name);
            string Icon = string.Format("{0}.png", Piece.BaseClothing.Sprite);

            ListViewItem ClothingToAdd = new ListViewItem(new string[]
                   {
                        Name,
                        Piece.Id.ToString(),
                        Sukuranburu.GetString("{WearType" + Piece.BaseClothing.SlotType + "}")
                   });

            ClothingToAdd.ImageKey = Icon;
            MyClothingInvListView.Items.Add(ClothingToAdd);
        }

        private void MyClothingInvListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectClothing();
        }
    }
}
