using FinalRemixDb;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scramble.Legacy
{
    public partial class LegacyPinEditor : Form
    {
        public LegacySave SaveFile => Program.Legacy.OpenedSaveFile;
        public LegacyForm Legacy => Program.Legacy;

        private bool ReadyForUserInput = false;

        private Dictionary<ushort, LegacyInventoryPin> Stockpile; // key= save index (0 to 255)
        private Dictionary<ushort, LegacyInventoryPin> Mastered; // key= save index (0 to 999)
        public LegacyInventoryPin SelectedPin;

        private const ushort STOCKPILE_SAVE_AMOUNT = 256;
        private const ushort MASTERED_SAVE_AMOUNT = 1000;
        private const ushort EMPTY = 0xFFFF;

        public LegacyPinEditor()
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            if (Legacy.RequiresRescaling)
            {
                Stockpile_ListView.AutoSize = true;
                Mastered_ListView.AutoSize = true;
                AllPins_ListView.AutoSize = true;
            }

            Stockpile_ListView.SmallImageList = Legacy.GetPinImageList_32x32();
            Mastered_ListView.SmallImageList = Legacy.GetPinImageList_32x32();
            AllPins_ListView.SmallImageList = Legacy.GetPinImageList_64x64();

            PopulateAllPins();
            PopulateStockpile();
            PopulateMastered();

            if (Stockpile_ListView.Items.Count > 0)
            {
                Stockpile_ListView.Items[0].Selected = true;
                Stockpile_ListView.Select();
            }

            ReadyForUserInput = true;
        }

        private void PopulateAllPins()
        {
            foreach (TwewyPin Pin in Legacy.GetTwewyManager().GetPins().Values)
            {
                ListViewItem PinToAdd = new ListViewItem(new string[] { Pin.GetName(Legacy.LanguageId), Pin.Id.ToString() })
                {
                    ImageKey = Pin.Sprite,
                    Tag = Pin.Id
                };

                AllPins_ListView.Items.Add(PinToAdd);
            }
        }

        private void PopulateStockpile()
        {
            Stockpile = new Dictionary<ushort, LegacyInventoryPin>();

            for (int i = 0; i < STOCKPILE_SAVE_AMOUNT; i++)
            {
                int OffsetSum = 15 * i;

                ushort PinId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum);

                if (PinId != EMPTY)
                {
                    ushort SaveIndex = (ushort)i;
                    ushort PinLevel = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 2);
                    ushort PinAmount = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 4); // shouldn't it always be 1?
                    int PinExperience = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Stockpile_Start + OffsetSum + 6);

                    LegacyInventoryPin PinToAdd = new LegacyInventoryPin(PinId, SaveIndex, PinLevel, PinAmount, PinExperience, false);
                    if (PinToAdd.BasePin != null)
                    {
                        ListViewItem ItemToAdd = new ListViewItem(new string[] { PinToAdd.BasePin.GetName(Legacy.LanguageId), PinToAdd.Id.ToString(), PinToAdd.Level.ToString() })
                        {
                            Tag = PinToAdd.SaveIndex,
                            ImageKey = PinToAdd.BasePin.Sprite
                        };

                        Stockpile.Add(PinToAdd.SaveIndex, PinToAdd);
                        Stockpile_ListView.Items.Add(ItemToAdd);
                    }
                }
            }
        }

        private void PopulateMastered()
        {
            Mastered = new Dictionary<ushort, LegacyInventoryPin>();

            for (int i = 0; i < MASTERED_SAVE_AMOUNT; i++)
            {
                int OffsetSum = 11 * i;

                ushort PinId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum);

                if (PinId != EMPTY)
                {
                    ushort SaveIndex = (ushort)i;
                    ushort PinLevel = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 2);
                    int PinExperience = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Mastered_Start + OffsetSum + 4);
                    ushort PinAmount = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 9);

                    LegacyInventoryPin PinToAdd = new LegacyInventoryPin(PinId, SaveIndex, PinLevel, PinAmount, PinExperience, true);
                    if (PinToAdd.BasePin != null)
                    {
                        ListViewItem ItemToAdd = new ListViewItem(new string[] { PinToAdd.BasePin.GetName(Legacy.LanguageId), PinToAdd.Id.ToString(), PinToAdd.Amount.ToString() })
                        {
                            Tag = PinToAdd.SaveIndex,
                            ImageKey = PinToAdd.BasePin.Sprite
                        };

                        Mastered.Add(PinToAdd.SaveIndex, PinToAdd);
                        Mastered_ListView.Items.Add(ItemToAdd);
                    }
                }
            }
        }

        private void SaveAllData()
        {
            for (ushort i = 0; i < STOCKPILE_SAVE_AMOUNT; i++)
            {
                int OffsetSum = 15 * i;
                if (Stockpile.ContainsKey(i))
                {
                    LegacyInventoryPin Pin = Stockpile[i];
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum, Pin.Id); // Pin ID
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 2, Pin.Level); // Level
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 4, Pin.Amount); // Amount
                    SaveFile.UpdateOffset_Int32(LegacyOffsets.Stockpile_Start + OffsetSum + 6, Pin.Experience); // Experience
                }
                else
                {

                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum, EMPTY);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 2, 1);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 4, 0);
                    SaveFile.UpdateOffset_Int32(LegacyOffsets.Stockpile_Start + OffsetSum + 6, 0);
                }

                SaveFile.UpdateOffset_Int32(LegacyOffsets.Stockpile_Start + OffsetSum + 10, 0); //?
                SaveFile.UpdateOffset_Byte(LegacyOffsets.Stockpile_Start + OffsetSum + 14, 0); //?
            }

            for (ushort i = 0; i < MASTERED_SAVE_AMOUNT; i++)
            {
                int OffsetSum = 11 * i;
                if (Mastered.ContainsKey(i))
                {
                    LegacyInventoryPin Pin = Mastered[i];
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum, Pin.Id);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 2, Pin.Level);
                    SaveFile.UpdateOffset_Int32(LegacyOffsets.Mastered_Start + OffsetSum + 4, Pin.Experience);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 9, Pin.Amount);
                }
                else
                {
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum, EMPTY);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 2, 100);
                    SaveFile.UpdateOffset_Int32(LegacyOffsets.Mastered_Start + OffsetSum + 4, 0);
                    SaveFile.UpdateOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 9, 0);
                }

                SaveFile.UpdateOffset_Byte(LegacyOffsets.Mastered_Start + OffsetSum + 8, 0);
            }
        }

        private void DisplayEmptyPin()
        {
            SelectedPin_Name_RichTextBox.Text = "(No selected pin)";
            SelectedPin_Desc_RichTextBox.Clear();
            SelectedPin_PictureBox.Image = null;

            SendToOtherInv_Button.Enabled = false;
            SendToOtherInv_Button.Text = "—";
            SendToOtherInv_Button.ForeColor = SystemColors.ControlText;
            Pin_Inventory_Label.Text = "—";
            Pin_Inventory_Label.ForeColor = SystemColors.ControlText;
            Level_NumUpDown.Enabled = false;
            Experience_NumUpDown.Enabled = false;
            Amount_NupUpDown.Enabled = false;

            RemovePin_Button.Enabled = false;
        }

        private void DisplayPin()
        {
            if (SelectedPin == null)
            {
                DisplayEmptyPin();
                return;
            }

            SendToOtherInv_Button.Enabled = true;
            Level_NumUpDown.Enabled = true;
            Experience_NumUpDown.Enabled = true;

            if (SelectedPin.Mastered)
            {
                Pin_Inventory_Label.Text = "Mastered";
                Pin_Inventory_Label.ForeColor = Color.BlueViolet;
                SendToOtherInv_Button.Text = "Send to stockpile";
                SendToOtherInv_Button.ForeColor = Color.Teal;
                Amount_NupUpDown.Enabled = true;

            }
            else
            {
                Pin_Inventory_Label.Text = "Stockpile";
                Pin_Inventory_Label.ForeColor = Color.Teal;
                SendToOtherInv_Button.Text = "Send to mastered";
                SendToOtherInv_Button.ForeColor = Color.BlueViolet;
                Amount_NupUpDown.Enabled = false;
            }

            RemovePin_Button.Enabled = true;

            Legacy.GetTwewyTextProcessor().SetTaggedText(SelectedPin.BasePin.GetName(Legacy.LanguageId), SelectedPin_Name_RichTextBox);
            Legacy.GetTwewyTextProcessor().SetTaggedText(SelectedPin.BasePin.GetDescription(Legacy.LanguageId), SelectedPin_Desc_RichTextBox);
            SelectedPin_PictureBox.Image = ImageMethodsFr.DrawImage(SelectedPin.BasePin.Sprite, 80, 80, DeviceDpi);
            Level_NumUpDown.Value = SelectedPin.Level;
            Experience_NumUpDown.Value = SelectedPin.Experience;
            Amount_NupUpDown.Value = SelectedPin.Amount;
        }

        private ListViewItem SeekListViewItem_Mastered(ushort SaveIndex)
        {
            foreach (ListViewItem Item in Mastered_ListView.Items)
            {
                if ((ushort)Item.Tag == SaveIndex)
                {
                    return Item;
                }
            }

            return null;
        }

        private void InsertPinToStockpile(ushort SaveIndex, TwewyPin Pin)
        {
            if (Pin == null || Stockpile.ContainsKey(SaveIndex))
            {
                return; // and maybe throw an error idk
            }

            LegacyInventoryPin PinToAdd = new LegacyInventoryPin(Pin.Id, SaveIndex, 1, 1, 0, false);
            Stockpile[SaveIndex] = PinToAdd;

            ListViewItem ItemToAdd = new ListViewItem(new string[] { PinToAdd.BasePin.GetName(Legacy.LanguageId), PinToAdd.Id.ToString(), PinToAdd.Level.ToString() })
            {
                Tag = PinToAdd.SaveIndex,
                ImageKey = PinToAdd.BasePin.Sprite
            };
            Stockpile_ListView.Items.Add(ItemToAdd);

            DisplayPin();
        }

        private void InsertPinToMastered(ushort SaveIndex, TwewyPin Pin, bool Individual)
        {
            if (Pin == null)
            {
                return; // and maybe throw an error idk
            }

            if (Mastered.ContainsKey(SaveIndex) == false)
            {
                LegacyInventoryPin PinToAdd = new LegacyInventoryPin(Pin.Id, SaveIndex, 15, 0, 99999, true);
                Mastered[SaveIndex] = PinToAdd;
            }

            if (Add99ToMastered_Checkbox.Checked)
            {
                Mastered[SaveIndex].Amount = 99;
            }
            else if (Mastered[SaveIndex].Amount + 1 < 100)
            {
                Mastered[SaveIndex].Amount += 1;
            }
            else
            {
                if (Individual)
                {
                    Legacy.ShowNotice("You can't add more of this pin, you already have 99.");
                }

                return;
            }

            ListViewItem ItemToAdd = SeekListViewItem_Mastered(SaveIndex);
            if (ItemToAdd == null)
            {
                ItemToAdd = new ListViewItem(new string[] { Mastered[SaveIndex].BasePin.GetName(Legacy.LanguageId), Mastered[SaveIndex].Id.ToString(), Mastered[SaveIndex].Amount.ToString() })
                {
                    Tag = Mastered[SaveIndex].SaveIndex,
                    ImageKey = Mastered[SaveIndex].BasePin.Sprite
                };
                Mastered_ListView.Items.Add(ItemToAdd);
            }
            else
            {
                ItemToAdd.SubItems[2].Text = Mastered[SaveIndex].Amount.ToString();
            }

            if (SelectedPin == Mastered[SaveIndex])
            {
                Amount_NupUpDown.Value = Mastered[SaveIndex].Amount;

            }
        }

        public ushort GetNextSaveIndex_Stockpile()
        {
            if (Stockpile == null)
            {
                return EMPTY;
            }

            for (ushort i = 0; i < STOCKPILE_SAVE_AMOUNT; i++)
            {
                if (Stockpile.ContainsKey(i) == false)
                {
                    return i;
                }
            }

            return EMPTY;
        }

        public ushort GetNextSaveIndex_Mastered(ushort PinId)
        {
            if (Mastered == null)
            {
                return EMPTY;
            }

            ushort ReturnKey = EMPTY;
            for (ushort i = 0; i < MASTERED_SAVE_AMOUNT; i++)
            {
                if (Mastered.ContainsKey(i) && Mastered[i].Id == PinId)
                {
                    return i;
                }
                else if (Mastered.ContainsKey(i) == false)
                {
                    ReturnKey = i;
                }
            }

            return ReturnKey;
        }

        private void RemovePin(LegacyInventoryPin Pin, bool DeleteSaveIndex = true)
        {
            if (Pin == null)
            {
                return;
            }

            if (Pin.Mastered)
            {
            }
            else
            {

            }
        }

        private void Stockpile_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            Mastered_ListView.SelectedItems.Clear();
            if (Stockpile_ListView.SelectedItems.Count == 0)
            {
                SelectedPin = null;
                DisplayEmptyPin();
                ReadyForUserInput = true;
                return;
            }

            ushort SaveIndex = (ushort)Stockpile_ListView.SelectedItems[0].Tag;
            if (!Stockpile.ContainsKey(SaveIndex))
            {
                SelectedPin = null;
                DisplayEmptyPin();
                ReadyForUserInput = true;
                return;
            }

            SelectedPin = Stockpile[SaveIndex];
            DisplayPin();

            ReadyForUserInput = true;
        }

        private void Mastered_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }


            ReadyForUserInput = false;

            Stockpile_ListView.SelectedItems.Clear();
            if (Mastered_ListView.SelectedItems.Count == 0)
            {
                SelectedPin = null;
                DisplayEmptyPin();
                ReadyForUserInput = true;
                return;
            }

            ushort SaveIndex = (ushort)Mastered_ListView.SelectedItems[0].Tag;
            if (!Mastered.ContainsKey(SaveIndex))
            {
                SelectedPin = null;
                DisplayEmptyPin();
                ReadyForUserInput = true;
                return;
            }

            SelectedPin = Mastered[SaveIndex];
            DisplayPin();

            ReadyForUserInput = true;

            ReadyForUserInput = true;
        }

        private void ClearStockpile_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            Stockpile.Clear();
            Stockpile_ListView.Items.Clear();

            ReadyForUserInput = true;
        }

        private void ClearMastered_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            Mastered.Clear();
            Mastered_ListView.Items.Clear();

            ReadyForUserInput = true;
        }

        private void LegacyPinEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllData();
        }

        private void AddPinToStockpile_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (AllPins_ListView.SelectedItems.Count == 0)
            {
                Legacy.ShowNotice("You didn't select any pin to add.");
                ReadyForUserInput = true;
                return;
            }

            if (Stockpile.Count >= STOCKPILE_SAVE_AMOUNT)
            {
                Legacy.ShowWarning("You can't store more pins in your stockpile. The limit is 256.");
                ReadyForUserInput = true;
                return;
            }

            ushort NextSaveIndex = GetNextSaveIndex_Stockpile();
            if (NextSaveIndex == EMPTY)
            {
                Legacy.ShowWarning("You -seemingly- can't store more pins in your stockpile. The limit is 256.");
                ReadyForUserInput = true;
                return;
            }

            // Enough checking...

            ListViewItem SelectedGlobalPin = AllPins_ListView.SelectedItems[0];
            TwewyPin GamePin = Legacy.GetTwewyManager().GetPin((ushort)SelectedGlobalPin.Tag);
            if (GamePin == null)
            {
                // Probably throw an exception... this shouldn't happen.
                ReadyForUserInput = true;
                return;
            }

            InsertPinToStockpile(NextSaveIndex, GamePin);
            ReadyForUserInput = true;
        }

        private void AddPinToMastered_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (Mastered.Count >= MASTERED_SAVE_AMOUNT)
            {
                Legacy.ShowWarning("You can't store more pins in your mastered inventory... Wait, what? This is impossible. Please report this.");
                ReadyForUserInput = true;
                return;
            }

            if (EachPin_Checkbox.Checked)
            {
                AddPinToMastered_Button.Text = "Working...";
                AddPinToMastered_Button.Enabled = false;

                foreach (TwewyPin GlobalPin in Legacy.GetTwewyManager().GetPins().Values)
                {
                    ushort SaveIndex = GetNextSaveIndex_Mastered(GlobalPin.Id);
                    InsertPinToMastered(SaveIndex, GlobalPin, false);
                }

                ReadyForUserInput = true;
                AddPinToMastered_Button.Text = "Add pin to mastered";
                AddPinToMastered_Button.Enabled = true;
                return;
            }

            if (AllPins_ListView.SelectedItems.Count == 0)
            {
                Legacy.ShowNotice("You didn't select any pin to add.");
                ReadyForUserInput = true;
                return;
            }

            ListViewItem SelectedGlobalPin = AllPins_ListView.SelectedItems[0];

            ushort PinId = (ushort)SelectedGlobalPin.Tag;
            ushort NextSaveIndex = GetNextSaveIndex_Mastered(PinId);
            if (NextSaveIndex == EMPTY)
            {
                Legacy.ShowWarning("You -seemingly- can't store more pins in your mastered inventory... Wait, what? This is impossible. Please report this.");
                ReadyForUserInput = true;
                return;
            }


            TwewyPin GamePin = Legacy.GetTwewyManager().GetPin(PinId);
            if (GamePin == null)
            {
                // Probably throw an exception... this shouldn't happen.
                ReadyForUserInput = true;
                return;
            }

            InsertPinToMastered(NextSaveIndex, GamePin, true);
            ReadyForUserInput = true;
        }

        private void RemovePin_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            if (SelectedPin == null)
            {
                return;
            }

            ReadyForUserInput = false;
            RemovePin(SelectedPin);
            ReadyForUserInput = true;
        }

        private void SendToOtherInv_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            if (SelectedPin == null)
            {
                return;
            }

            ReadyForUserInput = false;

            if (SelectedPin.Mastered)
            { 
            }
            else
            {

            }
            ReadyForUserInput = true;
        }
    }
}
