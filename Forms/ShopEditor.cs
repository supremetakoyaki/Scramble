using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class ShopEditor : Form
    {
        public SaveSlot SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private const int EMPTY_FOOD_ID = -1;

        private Shop SelectedShop;
        private readonly Dictionary<int, int> ComboBoxFoodIndexes;
        private bool ReadyForUserInput = false;

        public ShopEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            if (Sukuranburu.RequiresRescaling)
            {
                ShopListListView.AutoSize = true;
            }

            ComboBoxFoodIndexes = new Dictionary<int, int>();

            DisplayLanguageStrings();
            SerializeShopList();

            if (ShopListListView.Items.Count > 0)
            {
                ShopListListView.Items[0].Selected = true;
            }

            ReadyForUserInput = true;
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{ShopEditor}");
            IdHeader.Text = Sukuranburu.GetString("{Id}");
            NameHeader.Text = Sukuranburu.GetString("{Name}");
            CategoryHeader.Text = Sukuranburu.GetString("{Category}");
            ShopDataGroupBox.Text = Sukuranburu.GetString("{SelectedShop}");
            SelectedShopTimesUsedLabel.Text = Sukuranburu.GetString("{TimesUsed:}");
            SelectedShopLastFoodsTitleLabel.Text = Sukuranburu.GetString("{LastOrderedFood}");

            SelectedShopLastFoodCharacter1Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(1)));
            SelectedShopLastFoodCharacter3Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(3)));

            if (Sukuranburu.ShowSpoilers == false)
            {
                if (SelectedSlot.FurthestDay > 0) //w1d1 onwards
                {
                    SelectedShopLastFoodCharacter7Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(7)));
                }
                else
                {
                    SelectedShopLastFoodCharacter7Label.Text = string.Format("{0}:", Sukuranburu.GetString("{Spoiler}"));
                }

                if (SelectedSlot.FurthestDay > 2) //w1d3 onwards
                {
                    SelectedShopLastFoodCharacter4Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(4)));
                }
                else
                {
                    SelectedShopLastFoodCharacter4Label.Text = string.Format("{0}:", Sukuranburu.GetString("{Spoiler}"));
                }

                if (SelectedSlot.FurthestDay > 9) //w2d3 onwards
                {
                    SelectedShopLastFoodCharacter5Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(5)));
                }
                else
                {
                    SelectedShopLastFoodCharacter5Label.Text = string.Format("{0}:", Sukuranburu.GetString("{Spoiler}"));
                }

                if (SelectedSlot.FurthestDay > 14) // w3d1 onwards
                {
                    SelectedShopLastFoodCharacter2Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(2)));
                }
                else
                {
                    SelectedShopLastFoodCharacter2Label.Text = string.Format("{0}:", Sukuranburu.GetString("{Spoiler}"));
                }

                if (SelectedSlot.FurthestDay > 18) //w3d5 onwards
                {
                    SelectedShopLastFoodCharacter6Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(6)));
                }
                else
                {
                    SelectedShopLastFoodCharacter6Label.Text = string.Format("{0}:", Sukuranburu.GetString("{Spoiler}"));
                }
            }
            else
            {
                SelectedShopLastFoodCharacter1Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(1)));
                SelectedShopLastFoodCharacter2Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(2)));
                SelectedShopLastFoodCharacter3Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(3)));
                SelectedShopLastFoodCharacter4Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(4)));
                SelectedShopLastFoodCharacter5Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(5)));
                SelectedShopLastFoodCharacter6Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(6)));
                SelectedShopLastFoodCharacter7Label.Text = string.Format("{0}:", Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(7)));
            }

            ResetCharacterFoodComboBoxes();

            ShopGoodsGroupBox.Text = Sukuranburu.GetString("{ShopGoods}");
            BrandsGroupBox.Text = Sukuranburu.GetString("{Brands}");
        }

        private void ResetCharacterFoodComboBoxes()
        {
            ComboBoxFoodIndexes.Clear();
            ComboBoxFoodIndexes.Add(0, EMPTY_FOOD_ID);

            SelectedShopLastFoodCharacter1ComboBox.Items.Clear();
            SelectedShopLastFoodCharacter2ComboBox.Items.Clear();
            SelectedShopLastFoodCharacter3ComboBox.Items.Clear();
            SelectedShopLastFoodCharacter4ComboBox.Items.Clear();
            SelectedShopLastFoodCharacter5ComboBox.Items.Clear();
            SelectedShopLastFoodCharacter6ComboBox.Items.Clear();
            SelectedShopLastFoodCharacter7ComboBox.Items.Clear();
            SelectedShopLastFoodCharacter1ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            SelectedShopLastFoodCharacter2ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            SelectedShopLastFoodCharacter3ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            SelectedShopLastFoodCharacter4ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            SelectedShopLastFoodCharacter5ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            SelectedShopLastFoodCharacter6ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            SelectedShopLastFoodCharacter7ComboBox.Items.Add(Sukuranburu.GetString("{None}"));
            SelectedShopLastFoodCharacter1ComboBox.SelectedIndex = 0;
            SelectedShopLastFoodCharacter2ComboBox.SelectedIndex = 0;
            SelectedShopLastFoodCharacter3ComboBox.SelectedIndex = 0;
            SelectedShopLastFoodCharacter4ComboBox.SelectedIndex = 0;
            SelectedShopLastFoodCharacter5ComboBox.SelectedIndex = 0;
            SelectedShopLastFoodCharacter6ComboBox.SelectedIndex = 0;
            SelectedShopLastFoodCharacter7ComboBox.SelectedIndex = 0;
        }

        private void ChangeCharacterFoodComboBoxesEnableStatus(bool Status)
        {
            SelectedShopLastFoodCharacter1ComboBox.Enabled = Status;
            SelectedShopLastFoodCharacter2ComboBox.Enabled = Status;
            SelectedShopLastFoodCharacter3ComboBox.Enabled = Status;
            SelectedShopLastFoodCharacter4ComboBox.Enabled = Status;
            SelectedShopLastFoodCharacter5ComboBox.Enabled = Status;
            SelectedShopLastFoodCharacter6ComboBox.Enabled = Status;
            SelectedShopLastFoodCharacter7ComboBox.Enabled = Status;
        }

        private void SerializeShopList()
        {
            foreach (Shop ShopItem in Sukuranburu.GetItemManager().GetShops().Values)
            {
                string ShopName = Sukuranburu.GetGameString(ShopItem.Name, true);

                if (Sukuranburu.ShowSpoilers == false)
                {
                    bool IsSpoiler = ShopItem.Id != 0 && SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopNumTimesUsed + (ShopItem.Id * 68)) < 1;

                    if (IsSpoiler)
                    {
                        ShopName = Sukuranburu.GetString("{Spoiler}");
                    }
                }

                ListViewItem ItemToAdd = new ListViewItem(new string[] { ShopItem.Id.ToString(), ShopName, GetShopTypeString(ShopItem.ShopType) })
                {
                    Tag = ShopItem.Id
                };
                ShopListListView.Items.Add(ItemToAdd);
            }
        }

        private void DisplayShop()
        {
            if (SelectedShop == null)
            {
                return;
            }

            SelectedShopTimesUsedNumUpDown.Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopNumTimesUsed + (SelectedShop.Id * 68));
            bool IsSpoiler = Sukuranburu.ShowSpoilers == false && SelectedShop.Id != 0 && SelectedShopTimesUsedNumUpDown.Value < 1;

            if (IsSpoiler)
            {
                SelectedShopCatRichTextBox.Text = "—";
                SelectedShopNameRichTextBox.Text = Sukuranburu.GetString("{Spoiler}");
                SelectedShopSymbolPictureBox.Image = null;
            }
            else
            {
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(SelectedShop.ShopCategory), SelectedShopCatRichTextBox);
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(SelectedShop.Name), SelectedShopNameRichTextBox);

                IGameItem SymbolItem = Sukuranburu.GetItemManager().GetItem(SelectedShop.SymbolItem);
                if (SymbolItem == null)
                {
                    SelectedShopSymbolPictureBox.Image = null;
                }
                else
                {
                    SelectedShopSymbolPictureBox.Image = ImageMethods.DrawImage(SymbolItem.Sprite, 80, 80, DeviceDpi);
                }
            }

            ResetCharacterFoodComboBoxes();

            if (SelectedShop.ShopType != 1) // Is not a restaurant
            {
                ChangeCharacterFoodComboBoxesEnableStatus(false);
            }
            else
            {
                ChangeCharacterFoodComboBoxesEnableStatus(true);

                // Serialize food items in each combobox
            }
        }

        private string GetShopTypeString(int ShopType)
        {
            switch (ShopType)
            {
                default:
                    return "INVALID";

                case 0:
                    return Sukuranburu.GetString("{ShopType_0}");

                case 1:
                    return Sukuranburu.GetString("{ShopType_1}");

                case 2:
                    return Sukuranburu.GetString("{ShopType_2}");
            }
        }

        private void ShopListListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || ShopListListView.SelectedIndices.Count != 1)
            {
                return;
            }

            sbyte ShopId = (sbyte)ShopListListView.SelectedItems[0].Tag;
            Shop ShopItem = Sukuranburu.GetItemManager().GetShop(ShopId);

            if (ShopItem == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedShop = ShopItem;
            DisplayShop();
            ReadyForUserInput = true;
        }

        private void SelectedShopTimesUsedNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopNumTimesUsed + (68 * SelectedShop.Id), (int)SelectedShopTimesUsedNumUpDown.Value);
            ReadyForUserInput = true;
        }

        private void ShopListListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(ShopListListView, e);
        }

        private void ShopEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ColumnSorter.DisposeColumn();
        }
    }
}
