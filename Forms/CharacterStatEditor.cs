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

        public const ushort MAXIMUM_VALUE = 999;

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
            else if (PlayerHp > HpValueUpDown.Maximum)
            {
                PlayerHp = (int)HpValueUpDown.Maximum;
            }

            if (PlayerAtk < AtkValueUpDown.Minimum)
            {
                PlayerAtk = (int)AtkValueUpDown.Minimum;
            }
            else if (PlayerAtk > AtkValueUpDown.Maximum)
            {
                PlayerAtk = (int)AtkValueUpDown.Maximum;
            }

            if (PlayerDef < DefValueUpDown.Minimum)
            {
                PlayerDef = (int)DefValueUpDown.Minimum;
            }
            else if (PlayerDef > DefValueUpDown.Maximum)
            {
                PlayerDef = (int)DefValueUpDown.Maximum;
            }

            if (PlayerStyle < StyleValueUpDown.Minimum)
            {
                PlayerStyle = (int)StyleValueUpDown.Minimum;
            }
            else if (PlayerStyle > StyleValueUpDown.Maximum)
            {
                PlayerStyle = (int)StyleValueUpDown.Maximum;
            }

            HpValueUpDown.Value = PlayerHp;
            AtkValueUpDown.Value = PlayerAtk;
            DefValueUpDown.Value = PlayerDef;
            StyleValueUpDown.Value = PlayerStyle;
        }

        private void UpdateHp(int AmountToSet, int CharacterId)
        {
            int OffsetSum = (CharacterId - 1) * 20;
            SelectedSlot.UpdateOffset_Int32(Offsets.Character1_Hp + OffsetSum, AmountToSet);
        }

        private void UpdateAtk(int AmountToSet, int CharacterId)
        {
            int OffsetSum = (CharacterId - 1) * 20;
            SelectedSlot.UpdateOffset_Int32(Offsets.Character1_Atk + OffsetSum, AmountToSet);
        }

        private void UpdateDef(int AmountToSet, int CharacterId)
        {
            int OffsetSum = (CharacterId - 1) * 20;
            SelectedSlot.UpdateOffset_Int32(Offsets.Character1_Def + OffsetSum, AmountToSet);
        }

        private void UpdateStyle(int AmountToSet, int CharacterId)
        {
            int OffsetSum = (CharacterId - 1) * 20;
            SelectedSlot.UpdateOffset_Int32(Offsets.Character1_Style + OffsetSum, AmountToSet);
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

        private void HpValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (HpValueUpDown.Value < HpValueUpDown.Minimum)
            {
                HpValueUpDown.Value = (int)HpValueUpDown.Minimum;
            }
            else if (HpValueUpDown.Value > HpValueUpDown.Maximum)
            {
                HpValueUpDown.Value = (int)HpValueUpDown.Maximum;
            }

            UpdateHp((int)HpValueUpDown.Value, SelectedCharacterId);

            ReadyForUserInput = true;
        }

        private void AtkValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (AtkValueUpDown.Value < AtkValueUpDown.Minimum)
            {
                AtkValueUpDown.Value = (int)AtkValueUpDown.Minimum;
            }
            else if (AtkValueUpDown.Value > AtkValueUpDown.Maximum)
            {
                AtkValueUpDown.Value = (int)AtkValueUpDown.Maximum;
            }

            UpdateAtk((int)AtkValueUpDown.Value, SelectedCharacterId);

            ReadyForUserInput = true;
        }

        private void DefValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (DefValueUpDown.Value < DefValueUpDown.Minimum)
            {
                DefValueUpDown.Value = (int)DefValueUpDown.Minimum;
            }
            else if (DefValueUpDown.Value > DefValueUpDown.Maximum)
            {
                DefValueUpDown.Value = (int)DefValueUpDown.Maximum;
            }

            UpdateDef((int)DefValueUpDown.Value, SelectedCharacterId);

            ReadyForUserInput = true;
        }

        private void StyleValueUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (StyleValueUpDown.Value < StyleValueUpDown.Minimum)
            {
                StyleValueUpDown.Value = (int)StyleValueUpDown.Minimum;
            }
            else if (StyleValueUpDown.Value > StyleValueUpDown.Maximum)
            {
                StyleValueUpDown.Value = (int)StyleValueUpDown.Maximum;
            }

            UpdateStyle((int)StyleValueUpDown.Value, SelectedCharacterId);

            ReadyForUserInput = true;
        }

        private void MaxStatsButton_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (AllCharactersCheckbox.Checked)
            {
                for (int Id = 1; Id < 8; Id++)
                {
                    UpdateHp(MAXIMUM_VALUE, Id);
                    UpdateAtk(MAXIMUM_VALUE, Id);
                    UpdateDef(MAXIMUM_VALUE, Id);
                    UpdateStyle(MAXIMUM_VALUE, Id);
                }
            }
            else
            {
                UpdateHp(MAXIMUM_VALUE, SelectedCharacterId);
                UpdateAtk(MAXIMUM_VALUE, SelectedCharacterId);
                UpdateDef(MAXIMUM_VALUE, SelectedCharacterId);
                UpdateStyle(MAXIMUM_VALUE, SelectedCharacterId);
            }

            this.HpValueUpDown.Value = MAXIMUM_VALUE;
            this.AtkValueUpDown.Value = MAXIMUM_VALUE;
            this.DefValueUpDown.Value = MAXIMUM_VALUE;
            this.StyleValueUpDown.Value = MAXIMUM_VALUE;

            ReadyForUserInput = true;
        }
    }
}
