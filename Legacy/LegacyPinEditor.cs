using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalRemixDb;

namespace Scramble.Legacy
{
    public partial class LegacyPinEditor : Form
    {
        public LegacySave SaveFile => Program.Legacy.OpenedSaveFile;
        public LegacyForm Legacy => Program.Legacy;

        private bool ReadyForUserInput = false;

        private Dictionary<ushort, LegacyPin> Stockpile; // key= save index (0 to 255)
        private Dictionary<ushort, LegacyPin> Mastered; // key= save index (0 to 999)
        public LegacyPin SelectedPin;

        private const ushort STOCKPILE_SAVE_AMOUNT = 256;
        private const ushort MASTERED_SAVE_AMOUNT = 1000;
        private const ushort NOT_ASSIGNED_PIN = 0xFFFF;

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
                ListViewItem PinToAdd = new ListViewItem(new string[] { Pin.GetName(Legacy.LanguageId), Pin.Id.ToString() });
                PinToAdd.ImageKey = Pin.Sprite;

                AllPins_ListView.Items.Add(PinToAdd);
            }
        }

        private void PopulateStockpile()
        {
            Stockpile = new Dictionary<ushort, LegacyPin>();

            for (int i = 0; i < STOCKPILE_SAVE_AMOUNT; i++)
            {
                int OffsetSum = 15 * i;

                ushort PinId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum);

                if (PinId != NOT_ASSIGNED_PIN)
                {
                    PinId += 1; // add one.

                    ushort SaveIndex = (ushort)i;
                    ushort PinLevel = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 2);
                    ushort PinAmount = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Stockpile_Start + OffsetSum + 4); // shouldn't it always be 1?
                    int PinExperience = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Stockpile_Start + OffsetSum + 6);

                    LegacyPin PinToAdd = new LegacyPin(PinId, SaveIndex, PinLevel, PinAmount, PinExperience, false);
                    if (PinToAdd.BasePin != null)
                    {
                        ListViewItem ItemToAdd = new ListViewItem(new string[] { PinToAdd.BasePin.GetName(Legacy.LanguageId), PinToAdd.Id.ToString(), PinToAdd.Level.ToString() });
                        ItemToAdd.Tag = PinToAdd.SaveIndex;
                        ItemToAdd.ImageKey = PinToAdd.BasePin.Sprite;

                        Stockpile.Add(PinToAdd.SaveIndex, PinToAdd);
                        Stockpile_ListView.Items.Add(ItemToAdd);
                    }
                }
            }
        }

        private void PopulateMastered()
        {
            Mastered = new Dictionary<ushort, LegacyPin>();

            for (int i = 0; i < MASTERED_SAVE_AMOUNT; i++)
            {
                int OffsetSum = 11 * i;

                ushort PinId = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum);

                if (PinId != NOT_ASSIGNED_PIN)
                {
                    PinId += 1; // add one

                    ushort SaveIndex = (ushort)i;
                    ushort PinLevel = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 2);
                    int PinExperience = SaveFile.RetrieveOffset_Int32(LegacyOffsets.Mastered_Start + OffsetSum + 4);
                    ushort PinAmount = SaveFile.RetrieveOffset_UInt16(LegacyOffsets.Mastered_Start + OffsetSum + 9);

                    LegacyPin PinToAdd = new LegacyPin(PinId, SaveIndex, PinLevel, PinAmount, PinExperience, true);
                    if (PinToAdd.BasePin != null)
                    {
                        ListViewItem ItemToAdd = new ListViewItem(new string[] { PinToAdd.BasePin.GetName(Legacy.LanguageId), PinToAdd.Id.ToString(), PinToAdd.Amount.ToString() });
                        ItemToAdd.Tag = PinToAdd.SaveIndex;
                        ItemToAdd.ImageKey = PinToAdd.BasePin.Sprite;

                        Mastered.Add(PinToAdd.SaveIndex, PinToAdd);
                        Mastered_ListView.Items.Add(ItemToAdd);
                    }
                }
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
    }
}
