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
    public partial class ShopEditor : Form
    {
        public SaveSlot SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private const int EMPTY_FOOD_ID = -1;

        private Shop SelectedShop;
        private ShopGood SelectedGood;
        private Brand SelectedBrand;
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
                ShopGoodsListView.AutoSize = true;
                BrandsListView.AutoSize = true;
            }

            ComboBoxFoodIndexes = new Dictionary<int, int>();
            ShopGoodsListView.SmallImageList = Sukuranburu.ItemImageList_32x32;
            SelectedBrandVipIconPictureBox.Image = ImageMethods.DrawImage(Properties.Resources.ResourceManager.GetObject("ShopIconVip") as Bitmap, 50, 42, DeviceDpi);

            DisplayLanguageStrings();
            SerializeShopList();
            SerializeBrands();

            if (ShopListListView.Items.Count > 0)
            {
                ShopListListView.Items[0].Selected = true;
            }

            if (BrandsListView.Items.Count > 0)
            {
                BrandsListView.Items[0].Selected = true;
            }

            ReadyForUserInput = true;
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{ShopEditor}");
            ShopListGroupBox.Text = Sukuranburu.GetString("{ShopList}");
            IdHeader.Text = Sukuranburu.GetString("{Id}");
            NameHeader.Text = Sukuranburu.GetString("{Name}");
            CategoryHeader.Text = Sukuranburu.GetString("{Category}");
            BestFoodForRestaurantsButton.Text = Sukuranburu.GetString("{BestFoodForRestaurants}");
            ShopDataGroupBox.Text = Sukuranburu.GetString("{SelectedShop}");
            SelectedShopTimesUsedLabel.Text = Sukuranburu.GetString("{TimesUsed:}");
            SelectedShopLastFoodsTitleLabel.Text = Sukuranburu.GetString("{LastOrderedFood}");

            SelectedShopLastFoodCharacter1Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(1));
            SelectedShopLastFoodCharacter3Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(3));

            if (Sukuranburu.ShowSpoilers == false)
            {
                if (SelectedSlot.FurthestDay > 0) //w1d1 onwards
                {
                    SelectedShopLastFoodCharacter7Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(7));
                }
                else
                {
                    SelectedShopLastFoodCharacter7Label.Text = Sukuranburu.GetString("{Spoiler}");
                    SelectedShopCharacter7PictureBox.Tag = "Spoiler";
                }

                if (SelectedSlot.FurthestDay > 2) //w1d3 onwards
                {
                    SelectedShopLastFoodCharacter4Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(4));
                }
                else
                {
                    SelectedShopLastFoodCharacter4Label.Text = Sukuranburu.GetString("{Spoiler}");
                    SelectedShopCharacter4PictureBox.Tag = "Spoiler";
                }

                if (SelectedSlot.FurthestDay > 9) //w2d3 onwards
                {
                    SelectedShopLastFoodCharacter5Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(5));
                }
                else
                {
                    SelectedShopLastFoodCharacter5Label.Text = Sukuranburu.GetString("{Spoiler}");
                    SelectedShopCharacter5PictureBox.Tag = "Spoiler";
                }

                if (SelectedSlot.FurthestDay > 14) // w3d1 onwards
                {
                    SelectedShopLastFoodCharacter2Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(2));
                }
                else
                {
                    SelectedShopLastFoodCharacter2Label.Text = Sukuranburu.GetString("{Spoiler}");
                    SelectedShopCharacter2PictureBox.Tag = "Spoiler";
                }

                if (SelectedSlot.FurthestDay > 18) //w3d5 onwards
                {
                    SelectedShopLastFoodCharacter6Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(6));
                }
                else
                {
                    SelectedShopLastFoodCharacter6Label.Text = Sukuranburu.GetString("{Spoiler}");
                    SelectedShopCharacter6PictureBox.Tag = "Spoiler";
                }
            }
            else
            {
                SelectedShopLastFoodCharacter1Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(1));
                SelectedShopLastFoodCharacter2Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(2));
                SelectedShopLastFoodCharacter3Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(3));
                SelectedShopLastFoodCharacter4Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(4));
                SelectedShopLastFoodCharacter5Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(5));
                SelectedShopLastFoodCharacter6Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(6));
                SelectedShopLastFoodCharacter7Label.Text = Sukuranburu.GetGameString(Sukuranburu.GetCharacterManager().GetCharacterName(7));
            }

            ResetCharacterFoodComboBoxes();

            ShopGoodsGroupBox.Text = Sukuranburu.GetString("{ShopGoods}");
            ShopGoodSortIndexHeader.Text = Sukuranburu.GetString("{#}");
            ShopGoodIdHeader.Text = Sukuranburu.GetString("{Id}");
            ShopGoodNameHeader.Text = Sukuranburu.GetString("{Name}");
            SelectedShopGoodGroupBox.Text = Sukuranburu.GetString("{SelectedGood}");
            SelectedShopGoodShowAsNewCheckbox.Text = Sukuranburu.GetString("{ShowAsNew}");
            SelectedShopGoodTimesPurchasedLabel.Text = Sukuranburu.GetString("{NumberPurchased:}");
            SelectedShopGoodTimesExchangedLabel.Text = Sukuranburu.GetString("{NumberExchanged:}");
            SelectedShopGoodNoticeLabel.Text = Sukuranburu.GetString("{ClothingGoodsNote}");
            BrandsGroupBox.Text = Sukuranburu.GetString("{Brands}");
            BrandIdHeader.Text = Sukuranburu.GetString("{Id}");
            BrandNameHeader.Text = Sukuranburu.GetString("{Name}");
            BrandsMaxVipLevelAll.Text = Sukuranburu.GetString("{MaxVipLevelAll}");
            SelectedBrandGroupBox.Text = Sukuranburu.GetString("{SelectedBrand}");
            SelectedBrandPointsLabel.Text = Sukuranburu.GetString("{Points:}");
            SelectedBrandMaxVipLevelButton.Text = Sukuranburu.GetString("{MaxVipLevel}");
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

        private void SerializeCharacterFoodComboBoxes(IOrderedEnumerable<ShopGood> ShopGoodList)
        {
            int Character1FoodId = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopLastFoods + 4 + (68 * SelectedShop.Id));
            int Character2FoodId = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopLastFoods + 8 + (68 * SelectedShop.Id));
            int Character3FoodId = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopLastFoods + 12 + (68 * SelectedShop.Id));
            int Character4FoodId = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopLastFoods + 16 + (68 * SelectedShop.Id));
            int Character5FoodId = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopLastFoods + 20 + (68 * SelectedShop.Id));
            int Character6FoodId = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopLastFoods + 24 + (68 * SelectedShop.Id));
            int Character7FoodId = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopLastFoods + 28 + (68 * SelectedShop.Id));

            int i = 1;
            foreach (ShopGood Food in ShopGoodList)
            {
                IGameItem Item = Sukuranburu.GetItemManager().GetItemWithShopGood(Food);

                if (Item != null)
                {
                    string ItemName = Sukuranburu.GetGameString(Item.Name);

                    ComboBoxFoodIndexes.Add(i, Item.ParticularId);
                    SelectedShopLastFoodCharacter1ComboBox.Items.Add(ItemName);
                    SelectedShopLastFoodCharacter2ComboBox.Items.Add(ItemName);
                    SelectedShopLastFoodCharacter3ComboBox.Items.Add(ItemName);
                    SelectedShopLastFoodCharacter4ComboBox.Items.Add(ItemName);
                    SelectedShopLastFoodCharacter5ComboBox.Items.Add(ItemName);
                    SelectedShopLastFoodCharacter6ComboBox.Items.Add(ItemName);
                    SelectedShopLastFoodCharacter7ComboBox.Items.Add(ItemName);

                    if (Character1FoodId == Item.ParticularId)
                    {
                        SelectedShopLastFoodCharacter1ComboBox.SelectedIndex = i;
                    }

                    if (Character2FoodId == Item.ParticularId)
                    {
                        SelectedShopLastFoodCharacter2ComboBox.SelectedIndex = i;
                    }

                    if (Character3FoodId == Item.ParticularId)
                    {
                        SelectedShopLastFoodCharacter3ComboBox.SelectedIndex = i;
                    }

                    if (Character4FoodId == Item.ParticularId)
                    {
                        SelectedShopLastFoodCharacter4ComboBox.SelectedIndex = i;
                    }

                    if (Character5FoodId == Item.ParticularId)
                    {
                        SelectedShopLastFoodCharacter5ComboBox.SelectedIndex = i;
                    }

                    if (Character6FoodId == Item.ParticularId)
                    {
                        SelectedShopLastFoodCharacter6ComboBox.SelectedIndex = i;
                    }

                    if (Character7FoodId == Item.ParticularId)
                    {
                        SelectedShopLastFoodCharacter7ComboBox.SelectedIndex = i;
                    }

                    i++;
                }
            }
        }

        private void SerializeShopList()
        {
            foreach (Shop ShopItem in Sukuranburu.GetItemManager().GetShops().Values)
            {
                ListViewItem ItemToAdd = new ListViewItem(new string[] { ShopItem.Id.ToString(), Sukuranburu.GetGameString(ShopItem.Name, true), GetShopTypeString(ShopItem.ShopType) })
                {
                    Tag = ShopItem.Id
                };
                ShopListListView.Items.Add(ItemToAdd);
            }
        }

        private void SerializeBrands()
        {
            foreach (Brand BrandItem in Sukuranburu.GetItemManager().GetBrands().Values)
            {
                if (BrandItem.Id > 0) // We don't want the "Unbranded"
                {
                    ListViewItem ItemToAdd = new ListViewItem(new string[] { BrandItem.Id.ToString(), Sukuranburu.GetGameString(BrandItem.Name) })
                    {
                        Tag = BrandItem.Id
                    };
                    BrandsListView.Items.Add(ItemToAdd);
                }
            }
        }

        private void DisplayShop()
        {
            if (SelectedShop == null)
            {
                return;
            }

            SelectedShopTimesUsedNumUpDown.Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopNumTimesUsed + (SelectedShop.Id * 68));

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

            ResetCharacterFoodComboBoxes();
            IOrderedEnumerable<ShopGood> ShopGoodList = Sukuranburu.GetItemManager().GetShopGoods(SelectedShop.Id);

            if (SelectedShop.ShopType != 1) // Is not a restaurant
            {
                ChangeCharacterFoodComboBoxesEnableStatus(false);
            }
            else
            {
                ChangeCharacterFoodComboBoxesEnableStatus(true);
                SerializeCharacterFoodComboBoxes(ShopGoodList);
            }

            DisplayTasteForEveryone();
            SerializeShopGoods(ShopGoodList);
        }

        private void DisplayShopGood()
        {
            if (SelectedGood == null)
            {
                return;
            }

            IGameItem Item = Sukuranburu.GetItemManager().GetItemWithShopGood(SelectedGood);
            if (Item == null)
            {
                return;
            }

            SelectedShopGoodNameLabel.Text = Sukuranburu.GetGameString(Item.Name);
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(Item.Info), SelectedShopGoodDescRichTextBox);
            SelectedShopGoodPictureBox.Image = ImageMethods.DrawImage(Item.Sprite, 100, 100, DeviceDpi);

            SelectedShopGoodPriceLabel.Text = string.Format(Sukuranburu.GetString("{YenNum}"), string.Format("{0:n0}", SelectedGood.Price));
            if (Item is FoodItem)
            {
                SelectedShopGoodCaloriesLabel.Text = string.Format(Sukuranburu.GetString("{KcalNum}"), (Item as FoodItem).Calories);
                SelectedShopGoodCaloriesLabel.Visible = true;
            }
            else
            {
                SelectedShopGoodCaloriesLabel.Visible = false;
            }

            SelectedShopGoodShowAsNewCheckbox.Checked = SelectedSlot.RetrieveOffset_Byte(GameOffsets.ShopGoods_IsNew + (9 * SelectedGood.SaveIndex)) != 0;
            SelectedGoodTimesPurchasedNumUpDown.Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopGoods_PurchaseNum + (9 * SelectedGood.SaveIndex));
            SelectedGoodTimesExchangedNumUpDown.Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.ShopGoods_ExchangeNum + (9 * SelectedGood.SaveIndex));
        }

        private void DisplayBrand()
        {
            if (SelectedBrand == null)
            {
                return;
            }

            SelectedBrandPictureBox.Image = ImageMethods.DrawImage(SelectedBrand.Sprite, 175, 62, DeviceDpi);
            SelectedBrandNameLabel.Text = Sukuranburu.GetGameString(SelectedBrand.Name);
            SelectedBrandPointsNumUpDown.Value = SelectedSlot.RetrieveOffset_Int32(GameOffsets.BrandPoint + (4 * SelectedBrand.Id));
            DisplayVipLevel();
        }

        private void DisplayVipLevel()
        {
            if (SelectedBrand == null)
            {
                SelectedBrandVipLevelLabel.Text = "—";
                return;
            }

            int VipLevel = 1;
            int BrandPoints = (int)SelectedBrandPointsNumUpDown.Value;

            for (int i = 0; i < 4; i++)
            {
                if (BrandPoints >= SelectedBrand.RankPoints[i])
                {
                    VipLevel = i + 2;
                }
            }

            SelectedBrandVipLevelLabel.Text = string.Format(Sukuranburu.GetString("{VipLevelNum}"), VipLevel);
        }

        private void DisplayFoodTaste(byte CharacterId, int FoodId, PictureBox IconBox, Label TasteLabel)
        {
            FoodItem Food;

            if (FoodId == -1 || (Food = Sukuranburu.GetItemManager().GetFoodItem((ushort)FoodId)) == null)
            {
                if ((string)IconBox.Tag == "Spoiler")
                {
                    IconBox.Image = null;
                }
                else
                {
                    IconBox.Image = ImageMethods.DrawImage(Properties.Resources.ResourceManager.GetObject(string.Format("Chara{0}_none", CharacterId)) as Bitmap, 35, 35, DeviceDpi);
                }
                TasteLabel.ForeColor = SystemColors.ControlText;
                TasteLabel.Text = "—";
                return;
            }

            int Taste = Food.CharaLikeness[CharacterId - 1];
            string Image;
            Color Color;

            switch (Taste)
            {
                default:
                    Image = "none";
                    Color = SystemColors.ControlText;
                    break;

                case 0:
                    Image = "normal";
                    Color = SystemColors.ControlText;
                    break;

                case 1:
                    Image = "bad";
                    Color = Color.DarkRed;
                    break;

                case 2:
                    Image = "like";
                    Color = Color.Green;
                    break;

                case 3:
                    Image = "like";
                    Color = Color.RoyalBlue;
                    break;

                case 4:
                    Image = "like";
                    Color = Color.SlateBlue;
                    break;
            }

            if ((string)IconBox.Tag == "Spoiler")
            {
                IconBox.Image = null;
            }
            else
            {
                IconBox.Image = ImageMethods.DrawImage(Properties.Resources.ResourceManager.GetObject(string.Format("Chara{0}_{1}", CharacterId, Image)) as Bitmap, 35, 35, DeviceDpi);
            }

            TasteLabel.ForeColor = Color;
            TasteLabel.Text = Sukuranburu.GetString(string.Format("{{FoodTaste{0}}}", Taste));
        }

        private void DisplayTasteForEveryone()
        {
            DisplayFoodTaste(1, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter1ComboBox.SelectedIndex], SelectedShopCharacter1PictureBox, SelectedShopCharacter1TasteLabel);
            DisplayFoodTaste(2, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter2ComboBox.SelectedIndex], SelectedShopCharacter2PictureBox, SelectedShopCharacter2TasteLabel);
            DisplayFoodTaste(3, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter3ComboBox.SelectedIndex], SelectedShopCharacter3PictureBox, SelectedShopCharacter3TasteLabel);
            DisplayFoodTaste(4, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter4ComboBox.SelectedIndex], SelectedShopCharacter4PictureBox, SelectedShopCharacter4TasteLabel);
            DisplayFoodTaste(5, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter5ComboBox.SelectedIndex], SelectedShopCharacter5PictureBox, SelectedShopCharacter5TasteLabel);
            DisplayFoodTaste(6, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter6ComboBox.SelectedIndex], SelectedShopCharacter6PictureBox, SelectedShopCharacter6TasteLabel);
            DisplayFoodTaste(7, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter7ComboBox.SelectedIndex], SelectedShopCharacter7PictureBox, SelectedShopCharacter7TasteLabel);
        }

        private void SerializeShopGoods(IOrderedEnumerable<ShopGood> ShopGoodList)
        {
            ShopGoodsListView.Items.Clear();

            if (SelectedShop == null)
            {
                return;
            }

            int i = 1;
            foreach (ShopGood ShopGood in ShopGoodList)
            {
                IGameItem Item = Sukuranburu.GetItemManager().GetItemWithShopGood(ShopGood);

                if (Item != null)
                {
                    ListViewItem GoodToAdd = new ListViewItem(new string[] { Sukuranburu.GetGameString(Item.Name), i.ToString(), ShopGood.Id.ToString() })
                    {
                        ImageKey = Item.Sprite,
                        Tag = ShopGood.Id
                    };

                    ShopGoodsListView.Items.Add(GoodToAdd);
                    i++;
                }
            }

            if (ShopGoodsListView.Items.Count > 0)
            {
                ShopGoodsListView.Items[0].Selected = true;
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

        private void ShopGoodsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShopGoodsListView.SelectedIndices.Count != 1)
            {
                return;
            }

            ushort GoodId = (ushort)ShopGoodsListView.SelectedItems[0].Tag;
            ShopGood GoodItem = Sukuranburu.GetItemManager().GetShopGood(GoodId);

            if (GoodItem == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedGood = GoodItem;
            DisplayShopGood();
            ReadyForUserInput = true;
        }

        private void BrandsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || BrandsListView.SelectedIndices.Count != 1)
            {
                return;
            }

            byte BrandId = (byte)BrandsListView.SelectedItems[0].Tag;
            Brand BrandItem = Sukuranburu.GetItemManager().GetBrand(BrandId);

            if (BrandItem == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedBrand = BrandItem;
            DisplayBrand();
            ReadyForUserInput = true;
        }

        private void BestFoodForRestaurantsButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;
            foreach (Shop ShopItem in Sukuranburu.GetItemManager().GetShops().Values)
            {
                if (ShopItem.ShopType == 1) // Restaurant
                {
                    FoodItem[] BestFoods = new FoodItem[7];
                    IOrderedEnumerable<ShopGood> GoodItemList = Sukuranburu.GetItemManager().GetShopGoods(ShopItem.Id);

                    foreach (ShopGood GoodItem in GoodItemList)
                    {
                        FoodItem Food = Sukuranburu.GetItemManager().GetItem(GoodItem.Item) as FoodItem;
                        if (Food != null)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                if (Food.CharaLikeness[i] != 1 && BestFoods[i] == null)
                                {
                                    BestFoods[i] = Food;
                                }
                                else if (Food.CharaLikeness[i] != 1 && Food.CharaLikeness[i] > BestFoods[i].CharaLikeness[i])
                                {
                                    BestFoods[i] = Food;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + (4 * (i + 1)) + (68 * ShopItem.Id), BestFoods[i].ParticularId);
                    }

                    if (ShopItem == SelectedShop)
                    {
                        ResetCharacterFoodComboBoxes();
                        ChangeCharacterFoodComboBoxesEnableStatus(true);
                        SerializeCharacterFoodComboBoxes(GoodItemList);
                        DisplayTasteForEveryone();
                    }
                }
            }

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

        private void SelectedShopLastFoodCharacter1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null || !ComboBoxFoodIndexes.ContainsKey(SelectedShopLastFoodCharacter1ComboBox.SelectedIndex))
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + 4 + (68 * SelectedShop.Id), ComboBoxFoodIndexes[SelectedShopLastFoodCharacter1ComboBox.SelectedIndex]);
            DisplayFoodTaste(1, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter1ComboBox.SelectedIndex], SelectedShopCharacter1PictureBox, SelectedShopCharacter1TasteLabel);
            ReadyForUserInput = true;
        }

        private void SelectedShopLastFoodCharacter2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null || !ComboBoxFoodIndexes.ContainsKey(SelectedShopLastFoodCharacter2ComboBox.SelectedIndex))
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + 8 + (68 * SelectedShop.Id), ComboBoxFoodIndexes[SelectedShopLastFoodCharacter2ComboBox.SelectedIndex]);
            DisplayFoodTaste(2, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter2ComboBox.SelectedIndex], SelectedShopCharacter2PictureBox, SelectedShopCharacter2TasteLabel);
            ReadyForUserInput = true;
        }

        private void SelectedShopLastFoodCharacter3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null || !ComboBoxFoodIndexes.ContainsKey(SelectedShopLastFoodCharacter3ComboBox.SelectedIndex))
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + 12 + (68 * SelectedShop.Id), ComboBoxFoodIndexes[SelectedShopLastFoodCharacter3ComboBox.SelectedIndex]);
            DisplayFoodTaste(3, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter3ComboBox.SelectedIndex], SelectedShopCharacter3PictureBox, SelectedShopCharacter3TasteLabel);
            ReadyForUserInput = true;
        }

        private void SelectedShopLastFoodCharacter4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null || !ComboBoxFoodIndexes.ContainsKey(SelectedShopLastFoodCharacter4ComboBox.SelectedIndex))
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + 16 + (68 * SelectedShop.Id), ComboBoxFoodIndexes[SelectedShopLastFoodCharacter4ComboBox.SelectedIndex]);
            DisplayFoodTaste(4, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter4ComboBox.SelectedIndex], SelectedShopCharacter4PictureBox, SelectedShopCharacter4TasteLabel);
            ReadyForUserInput = true;
        }

        private void SelectedShopLastFoodCharacter5ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null || !ComboBoxFoodIndexes.ContainsKey(SelectedShopLastFoodCharacter5ComboBox.SelectedIndex))
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + 20 + (68 * SelectedShop.Id), ComboBoxFoodIndexes[SelectedShopLastFoodCharacter5ComboBox.SelectedIndex]);
            DisplayFoodTaste(5, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter5ComboBox.SelectedIndex], SelectedShopCharacter5PictureBox, SelectedShopCharacter5TasteLabel);
            ReadyForUserInput = true;
        }

        private void SelectedShopLastFoodCharacter6ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null || !ComboBoxFoodIndexes.ContainsKey(SelectedShopLastFoodCharacter6ComboBox.SelectedIndex))
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + 24 + (68 * SelectedShop.Id), ComboBoxFoodIndexes[SelectedShopLastFoodCharacter6ComboBox.SelectedIndex]);
            DisplayFoodTaste(6, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter6ComboBox.SelectedIndex], SelectedShopCharacter6PictureBox, SelectedShopCharacter6TasteLabel);
            ReadyForUserInput = true;
        }

        private void SelectedShopLastFoodCharacter7ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedShop == null || !ComboBoxFoodIndexes.ContainsKey(SelectedShopLastFoodCharacter7ComboBox.SelectedIndex))
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopLastFoods + 28 + (68 * SelectedShop.Id), ComboBoxFoodIndexes[SelectedShopLastFoodCharacter7ComboBox.SelectedIndex]);
            DisplayFoodTaste(7, ComboBoxFoodIndexes[SelectedShopLastFoodCharacter7ComboBox.SelectedIndex], SelectedShopCharacter7PictureBox, SelectedShopCharacter7TasteLabel);
            ReadyForUserInput = true;
        }

        private void SelectedBrandPointsNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedBrand == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.BrandPoint + (4 * SelectedBrand.Id), (int)SelectedBrandPointsNumUpDown.Value);
            DisplayVipLevel();
            ReadyForUserInput = true;
        }

        private void BrandsMaxVipLevelAll_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            foreach (Brand BrandItem in Sukuranburu.GetItemManager().GetBrands().Values)
            {
                SelectedSlot.UpdateOffset_Int32(GameOffsets.BrandPoint + (4 * BrandItem.Id), BrandItem.RankPoints[3]);
                if (BrandItem == SelectedBrand)
                {
                    SelectedBrandPointsNumUpDown.Value = BrandItem.RankPoints[3];
                    SelectedBrandVipLevelLabel.Text = string.Format(Sukuranburu.GetString("{VipLevelNum}"), 5);
                }
            }

            ReadyForUserInput = true;
        }

        private void SelectedBrandMaxVipLevelButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedBrand == null)
            {
                return;
            }

            ReadyForUserInput = false;
            int MaxPointsForBrand = SelectedBrand.RankPoints[3];
            SelectedBrandPointsNumUpDown.Value = MaxPointsForBrand;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.BrandPoint + (4 * SelectedBrand.Id), MaxPointsForBrand);
            SelectedBrandVipLevelLabel.Text = string.Format(Sukuranburu.GetString("{VipLevelNum}"), 5);
            ReadyForUserInput = true;
        }

        private void SelectedShopGoodShowAsNewCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedGood == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Byte(GameOffsets.ShopGoods_IsNew + (9 * SelectedGood.SaveIndex), Convert.ToByte(SelectedShopGoodShowAsNewCheckbox.Checked));
            ReadyForUserInput = true;
        }

        private void SelectedGoodTimesPurchasedNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedGood == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopGoods_PurchaseNum + (9 * SelectedGood.SaveIndex), (int)SelectedGoodTimesPurchasedNumUpDown.Value);
            ReadyForUserInput = true;
        }

        private void SelectedGoodTimesExchangedNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedGood == null)
            {
                return;
            }

            ReadyForUserInput = false;
            SelectedSlot.UpdateOffset_Int32(GameOffsets.ShopGoods_ExchangeNum + (9 * SelectedGood.SaveIndex), (int)SelectedGoodTimesExchangedNumUpDown.Value);
            ReadyForUserInput = true;
        }

        private void ShopListListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(ShopListListView, e);
        }

        private void SelectedShopGoodsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(ShopGoodsListView, e);
        }

        private void BrandsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(BrandsListView, e);
        }

        private void ShopEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ColumnSorter.DisposeColumn();
        }
    }
}
