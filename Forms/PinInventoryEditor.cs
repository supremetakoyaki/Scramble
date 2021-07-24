using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class PinInventoryEditor : Form
    {
        public SaveData SelectedSlot
        {
            get
            {
                return Program.Sukuranburu.SelectedSlot;
            }
        }

        public const int EMPTY_PIN_ID = 0xFFFF;
        private List<InventoryPin> InventoryPins;
        

        public PinInventoryEditor()
        {
            InitializeComponent();
            Serialize();
        }

        public void Serialize()
        {
            InventoryPins = new List<InventoryPin>();

            // Pin data:
            // int16: pin ID
            // int16: level
            // int16: experience
            // int16: i have no idea.

            for (int CurrentPointer = Offsets.PinInv_First; CurrentPointer < Offsets.PinInv_Last; CurrentPointer += 8)
            {
                ushort PinId = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer);

                if (PinId != EMPTY_PIN_ID)
                {
                    ushort Level = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 2);
                    ushort Experience = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 4);
                    // UNUSED?: ushort Unknown = SelectedSlot.RetrieveOffset_UInt16(CurrentPointer + 6);

                    InventoryPin PinToAdd = new InventoryPin(PinId, Level, Experience);
                    int Index = InventoryPins.IndexOf(PinToAdd);

                    if (Index == -1)
                    {
                        InventoryPins.Add(PinToAdd);
                    }
                    else
                    {
                        if (InventoryPins[Index].Amount < 100)
                        {
                            InventoryPins[Index].Amount += 1;
                        }
                    }
                }
            }

            foreach (InventoryPin Pin in InventoryPins)
            {
                string Name = ItemTable.GetPinNameWithPinId(Pin.PinId);
                string Icon = ItemTable.GetPinSpriteWithPinId(Pin.PinId) + ".png";

                ListViewItem PinToAdd = new ListViewItem(new string[]
                    {
                        Name,
                        Pin.PinId.ToString(),
                        Pin.Level.ToString(),
                        Pin.Experience.ToString(),
                        PinIsMastered(Pin.PinId, (byte)Pin.Level) ? "★" : "no",
                        Pin.Amount.ToString()
                    });

                PinToAdd.ImageKey = Icon;
                MyPinInventoryView.Items.Add(PinToAdd);
            }
        }

        private void UpdatePinButton_Click(object sender, EventArgs e)
        {

        }

        private void MyPinInventoryView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool PinIsMastered(ushort PinId, byte Level)
        {
            return ItemTable.GetPinMaxLevelWithPinId(PinId) == Level && ItemTable.PinIsMasterable(PinId);
        }
    }
}
