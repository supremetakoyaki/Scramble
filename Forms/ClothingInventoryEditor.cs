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

        public const ushort EMPTY_CLOTHING_ID = 0x0000;
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
                ushort ClothingId = SelectedSlot.RetrieveOffset_UInt16(Offsets.ClothingInv_First + (Index * 2));

                if (ClothingId != EMPTY_CLOTHING_ID)
                {
                    InventoryFashion ClothingToAdd = new InventoryFashion(ClothingId);
                    int invIndex = InventoryClothes.IndexOf(ClothingToAdd);

                    if (invIndex == -1)
                    {
                        ClothingToAdd.Amount = 1;
                        InventoryClothes.Add(ClothingToAdd);
                    }
                    else
                    {
                        if (InventoryClothes[invIndex].Amount < 99)
                        {
                            InventoryClothes[invIndex].Amount += 1;
                        }
                    }
                }
            }

            foreach (InventoryFashion Piece in InventoryClothes)
            {
                InsertClothingToListView(Piece);
            }
        }

        private void SerializeGlobal()
        {

        }

        private void GenerateEquippedData()
        {

        }

        private void InsertClothingToListView(InventoryFashion Piece)
        {
            string Name = Sukuranburu.GetGameString(Piece.BaseClothing.Name);
            string Icon = string.Format("{0}.png", Piece.BaseClothing.Sprite);

            ListViewItem ClothingToAdd = new ListViewItem(new string[]
                   {
                        Name,
                        Piece.Id.ToString(),
                        Sukuranburu.GetString(string.Format("{WearType{0}}", Piece.BaseClothing.SlotType))
                   });

            ClothingToAdd.ImageKey = Icon;
            MyClothingInvListView.Items.Add(ClothingToAdd);
        }
    }
}
