using Scramble.Classes;
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

namespace Scramble.Forms
{
    public partial class NoisepediaEditor : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        public NoisepediaEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            if (Sukuranburu.RequiresRescaling)
            {
                NoisepediaListView.AutoSize = true;
            }

            // Language Strings
            SerializeNoisepedia();
        }

        private void SerializeNoisepedia()
        {
            foreach (NoisepediaEntry Entry in Sukuranburu.GetNoiseManager().GetNoisepediaDictionary().Values)
            {
                string NoiseName = Sukuranburu.GetGameString(Entry.Name);

                ListViewItem ItemToAdd = new ListViewItem(new string[]
                {
                    (Entry.SortIndex + 1).ToString(),
                    Entry.NoiseId.ToString(),
                    NoiseName
                });
                ItemToAdd.Tag = Entry.Id;

                NoisepediaListView.Items.Add(ItemToAdd);
            }
        }
    }
}
