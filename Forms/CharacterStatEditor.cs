using NTwewyDb;
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

namespace Scramble.Forms
{
    public partial class CharacterStatEditor : Form
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

        private int SelectedCharacterId;

        public CharacterStatEditor()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            DisplayLanguageStrings();
            DisplayCharacter();
        }

        private void DisplayLanguageStrings()
        {
            for (int i = 1; i < 8; i++)
            {
                TabPage Page = CharacterTabControl.TabPages[string.Format("CharacterTab{0}", i)];
                if (Page != null)
                {
                    Character GameCharacter = Sukuranburu.GetCharacterManager().GetCharacter(i);
                    Page.Text = Sukuranburu.GetGameString(GameCharacter.Name);
                }
            }
        }

        private void DisplayCharacter()
        {
            SelectedCharacterId = Convert.ToInt32(CharacterTabControl.SelectedTab.Name.Replace("CharacterTab", ""));
            this.Character_PictureBox.Image = global::Scramble.Properties.Resources.ResourceManager.GetObject(string.Format("Character{0}_170x300", SelectedCharacterId)) as Bitmap;

            Character GameCharacter = Sukuranburu.GetCharacterManager().GetCharacter(SelectedCharacterId);
            this.CharacterLabel.Text = Sukuranburu.GetGameString(GameCharacter.Name);
        }

        private void CharacterTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CharacterTabControl.SelectedIndex != -1)
            {
                DisplayCharacter();
            }
        }
    }
}
