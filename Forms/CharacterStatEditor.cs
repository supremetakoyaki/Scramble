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
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;

        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private int SelectedCharacterId;
        private bool ReadyForUserInput = false;

        public const ushort MAXIMUM_VALUE = 999;
        public const ushort MAXIMUM_DROPRATE = 19;

        public CharacterStatEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

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

            Text = Sukuranburu.GetString("{CharacterEditor}");
            StatNameLabel.Text = Sukuranburu.GetString("{StatName}");
            BaseLabel.Text = Sukuranburu.GetString("{BaseValue}");
            PlayerEarnedLabel.Text = Sukuranburu.GetString("{PlayerValue}");
            HpLabel.Text = Sukuranburu.GetString("{Hp:}");
            AtkLabel.Text = Sukuranburu.GetString("{Atk:}");
            DefLabel.Text = Sukuranburu.GetString("{Def:}");
            StyleLabel.Text = Sukuranburu.GetString("{Style:}");
            BonusDropRate_Label.Text = Sukuranburu.GetString("{DropRate:}");
            PlusLabel.Text = Sukuranburu.GetString("{+}");
            PlusLabel2.Text = Sukuranburu.GetString("{+}");
            PlusLabel3.Text = Sukuranburu.GetString("{+}");
            PlusLabel4.Text = Sukuranburu.GetString("{+}");
            PlusLabel5.Text = Sukuranburu.GetString("{+}");
            MaxStatsButton.Text = Sukuranburu.GetString("{MaxStats}");
            AllCharactersCheckbox.Text = Sukuranburu.GetString("{AllCharacters}");
        }

        private void DisplayCharacter()
        {
            SelectedCharacterId = Convert.ToInt32(CharacterTabControl.SelectedTab.Name.Replace("CharacterTab", ""));
            Character GameCharacter = Sukuranburu.GetCharacterManager().GetCharacter(SelectedCharacterId);

            if (Sukuranburu.CharacterIsSpoiler((byte)SelectedCharacterId) && Sukuranburu.ShowSpoilers == false)
            {
                Character_PictureBox.Image = ImageMethods.DrawImage(Properties.Resources.ResourceManager.GetObject("CH0S") as Bitmap, 179, 316, DeviceDpi);
                CharacterLabel.Text = Sukuranburu.GetString("{Spoiler}");
            }
            else
            {
                Character_PictureBox.Image = ImageMethods.DrawImage(Properties.Resources.ResourceManager.GetObject(string.Format("CH{0}", SelectedCharacterId.ToString("D2"))) as Bitmap, 179, 316, DeviceDpi);
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

            int PlayerHp = SelectedSlot.RetrieveOffset_Int32(Offsets.Character1_Hp + OffsetSum);
            int PlayerAtk = SelectedSlot.RetrieveOffset_Int32(Offsets.Character1_Atk + OffsetSum);
            int PlayerDef = SelectedSlot.RetrieveOffset_Int32(Offsets.Character1_Def + OffsetSum);
            ushort PlayerStyle = SelectedSlot.RetrieveOffset_UInt16(Offsets.Character1_Style + OffsetSum);
            ushort PlayerDropRate = SelectedSlot.RetrieveOffset_UInt16(Offsets.Character1_DropRateBonus + OffsetSum);

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
                PlayerStyle = (ushort)StyleValueUpDown.Minimum;
            }
            else if (PlayerStyle > StyleValueUpDown.Maximum)
            {
                PlayerStyle = (ushort)StyleValueUpDown.Maximum;
            }

            if (PlayerDropRate < BonusDropRate_NUpDown.Minimum)
            {
                PlayerDropRate = (ushort)BonusDropRate_NUpDown.Minimum;
            }
            else if (PlayerDropRate > BonusDropRate_NUpDown.Maximum)
            {
                PlayerDropRate = (ushort)BonusDropRate_NUpDown.Maximum;
            }

            HpValueUpDown.Value = PlayerHp;
            AtkValueUpDown.Value = PlayerAtk;
            DefValueUpDown.Value = PlayerDef;
            StyleValueUpDown.Value = PlayerStyle;
            BonusDropRate_NUpDown.Value = PlayerDropRate;
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

        private void UpdateStyle(ushort AmountToSet, int CharacterId)
        {
            int OffsetSum = (CharacterId - 1) * 20;
            SelectedSlot.UpdateOffset_UInt16(Offsets.Character1_Style + OffsetSum, AmountToSet);
        }

        private void UpdateDropRate(ushort AmountToSet, int CharacterId)
        {
            int OffsetSum = (CharacterId - 1) * 20;
            SelectedSlot.UpdateOffset_UInt16(Offsets.Character1_DropRateBonus + OffsetSum, AmountToSet);
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
                HpValueUpDown.Value = HpValueUpDown.Minimum;
            }
            else if (HpValueUpDown.Value > HpValueUpDown.Maximum)
            {
                HpValueUpDown.Value = HpValueUpDown.Maximum;
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
                AtkValueUpDown.Value = AtkValueUpDown.Minimum;
            }
            else if (AtkValueUpDown.Value > AtkValueUpDown.Maximum)
            {
                AtkValueUpDown.Value = AtkValueUpDown.Maximum;
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
                DefValueUpDown.Value = DefValueUpDown.Minimum;
            }
            else if (DefValueUpDown.Value > DefValueUpDown.Maximum)
            {
                DefValueUpDown.Value = DefValueUpDown.Maximum;
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
                StyleValueUpDown.Value = StyleValueUpDown.Minimum;
            }
            else if (StyleValueUpDown.Value > StyleValueUpDown.Maximum)
            {
                StyleValueUpDown.Value = StyleValueUpDown.Maximum;
            }

            UpdateStyle((ushort)StyleValueUpDown.Value, SelectedCharacterId);

            ReadyForUserInput = true;
        }

        private void BonusDropRate_NUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            if (BonusDropRate_NUpDown.Value < BonusDropRate_NUpDown.Minimum)
            {
                BonusDropRate_NUpDown.Value = BonusDropRate_NUpDown.Minimum;
            }
            else if (BonusDropRate_NUpDown.Value > BonusDropRate_NUpDown.Maximum)
            {
                BonusDropRate_NUpDown.Value = BonusDropRate_NUpDown.Maximum;
            }

            UpdateDropRate((ushort)BonusDropRate_NUpDown.Value, SelectedCharacterId);

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
                    UpdateDropRate(MAXIMUM_DROPRATE, Id);
                }
            }
            else
            {
                UpdateHp(MAXIMUM_VALUE, SelectedCharacterId);
                UpdateAtk(MAXIMUM_VALUE, SelectedCharacterId);
                UpdateDef(MAXIMUM_VALUE, SelectedCharacterId);
                UpdateStyle(MAXIMUM_VALUE, SelectedCharacterId);
                UpdateDropRate(MAXIMUM_DROPRATE, SelectedCharacterId);
            }

            HpValueUpDown.Value = MAXIMUM_VALUE;
            AtkValueUpDown.Value = MAXIMUM_VALUE;
            DefValueUpDown.Value = MAXIMUM_VALUE;
            StyleValueUpDown.Value = MAXIMUM_VALUE;
            BonusDropRate_NUpDown.Value = MAXIMUM_DROPRATE;

            ReadyForUserInput = true;
        }
    }
}
