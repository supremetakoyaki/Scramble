using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using System;
using System.Drawing;
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
        private bool ReadyForUserInput = false;

        public CharacterStatEditor()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            DisplayLanguageStrings();
            DisplayCharacter();
            ReadyForUserInput = true;
        }

        private void DisplayLanguageStrings()
        {
            for (int i = 1; i < 8; i++)
            {
                TabPage Page = CharacterTabControl.TabPages[string.Format("CharacterTab{0}", i)];
                if (Page != null)
                {
                    Character GameCharacter = Sukuranburu.GetCharacterManager().GetCharacter(i);
                    if (Sukuranburu.CharacterIsSpoiler((byte)GameCharacter.Id) && Sukuranburu.ShowSpoilers == false)
                    {
                        Page.Text = Sukuranburu.GetString("{Spoiler}");
                    }
                    else
                    {
                        Page.Text = Sukuranburu.GetGameString(GameCharacter.Name);
                    }
                }
            }

            this.Text = Sukuranburu.GetString("{CharacterEditor}");
            StatNameLabel.Text = Sukuranburu.GetString("{StatName}");
            BaseLabel.Text = Sukuranburu.GetString("{BaseValue}");
            PlayerEarnedLabel.Text = Sukuranburu.GetString("{PlayerValue}");
            HpLabel.Text = Sukuranburu.GetString("{Hp:}");
            AtkLabel.Text = Sukuranburu.GetString("{Atk:}");
            DefLabel.Text = Sukuranburu.GetString("{Def:}");
            StyleLabel.Text = Sukuranburu.GetString("{Style:}");
            PlusLabel.Text = Sukuranburu.GetString("{+}");
            PlusLabel2.Text = Sukuranburu.GetString("{+}");
            PlusLabel3.Text = Sukuranburu.GetString("{+}");
            PlusLabel4.Text = Sukuranburu.GetString("{+}");
            MaxStatsButton.Text = Sukuranburu.GetString("{MaxStats}");
            AllCharactersCheckbox.Text = Sukuranburu.GetString("{AllCharacters}");
        }

        private void DisplayCharacter()
        {
            SelectedCharacterId = Convert.ToInt32(CharacterTabControl.SelectedTab.Name.Replace("CharacterTab", ""));
            Character GameCharacter = Sukuranburu.GetCharacterManager().GetCharacter(SelectedCharacterId);

            if (Sukuranburu.CharacterIsSpoiler((byte)SelectedCharacterId) && Sukuranburu.ShowSpoilers == false)
            {
                Character_PictureBox.Image = Properties.Resources.ResourceManager.GetObject("CharacterS_170x300") as Bitmap;
                CharacterLabel.Text = Sukuranburu.GetString("{Spoiler}");
            }
            else
            {
                Character_PictureBox.Image = Properties.Resources.ResourceManager.GetObject(string.Format("Character{0}_170x300", SelectedCharacterId)) as Bitmap;
                CharacterLabel.Text = Sukuranburu.GetGameString(GameCharacter.Name);
            }

            if (Sukuranburu.CharacterIsPartyMember((byte)SelectedCharacterId))
            {
                InYourPartyLabel.Text = Sukuranburu.GetString("{InYourParty}");
            }
            else
            {
                InYourPartyLabel.Text = string.Empty;
            }

            BattlePlayer Player = Sukuranburu.GetCharacterManager().GetBattlePlayer(SelectedCharacterId);
            HpBaseLabelValue.Text = Player.BaseHp.ToString();
            AtkBaseValueLabel.Text = Player.BaseAtk.ToString();
            DefBaseValueLabel.Text = Player.BaseDef.ToString();
            StyleBaseValueLabel.Text = Player.BaseSense.ToString();

            int OffsetSum = (SelectedCharacterId - 1) * 20;

            int PlayerHp = (int)SelectedSlot.RetrieveOffset_Int32(Offsets.Character1_Hp + OffsetSum);
            int PlayerAtk = (int)SelectedSlot.RetrieveOffset_Int32(Offsets.Character1_Atk  + OffsetSum);
            int PlayerDef = (int)SelectedSlot.RetrieveOffset_Int32(Offsets.Character1_Def + OffsetSum);
            int PlayerStyle = (int)SelectedSlot.RetrieveOffset_Int32(Offsets.Character1_Style + OffsetSum);

            if (PlayerHp < HpValueUpDown.Minimum)
            {
                PlayerHp = (int)HpValueUpDown.Minimum;
            }
            else if (PlayerHp < HpValueUpDown.Maximum)
            {
                PlayerHp = (int)HpValueUpDown.Maximum;
            }

            if (PlayerAtk < AtkValueUpDown.Minimum)
            {
                PlayerAtk = (int)AtkValueUpDown.Minimum;
            }
            else if (PlayerAtk < AtkValueUpDown.Maximum)
            {
                PlayerAtk = (int)AtkValueUpDown.Maximum;
            }

            if (PlayerDef < DefValueUpDown.Minimum)
            {
                PlayerDef = (int)DefValueUpDown.Minimum;
            }
            else if (PlayerDef < DefValueUpDown.Maximum)
            {
                PlayerDef = (int)DefValueUpDown.Maximum;
            }

            if (PlayerStyle < StyleValueUpDown.Minimum)
            {
                PlayerStyle = (int)StyleValueUpDown.Minimum;
            }
            else if (PlayerStyle < StyleValueUpDown.Maximum)
            {
                PlayerStyle = (int)StyleValueUpDown.Maximum;
            }

            HpValueUpDown.Value = PlayerHp;
            AtkValueUpDown.Value = PlayerAtk;
            DefValueUpDown.Value = PlayerDef;
            StyleValueUpDown.Value = PlayerStyle;
        }

        private void CharacterTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (CharacterTabControl.SelectedIndex != -1)
            {
                DisplayCharacter();
            }

            ReadyForUserInput = true;
        }
    }
}
