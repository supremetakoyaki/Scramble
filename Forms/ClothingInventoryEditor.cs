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
            

            DisplayLanguageStrings();

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
    }
}
