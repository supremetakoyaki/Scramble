using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class TrophyEditor : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private Dictionary<byte, PictureBox> WallUI_Trophies;
        private const double WALL_UI_SCALE = 0.311844078;

        private byte SelectedTrophy;

        private bool ReadyForUserInput = false;

        public TrophyEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            DisplayLanguageStrings();

            if (Sukuranburu.RequiresRescaling)
            {
                TrophyListView.AutoSize = true;
            }

            SerializeTrophies();
            SerializeWall();

            ReadyForUserInput = true;

            if (TrophyListView.Items.Count > 0)
            {
                TrophyListView.Items[0].Selected = true;
                TrophyListView.Select();
            }
        }

        private void DisplayLanguageStrings()
        {
            Text = Sukuranburu.GetString("{TrophyEditor}");
            TrophyWall_GroupBox.Text = Sukuranburu.GetString("{TrophyWall}");
            TrophyOverview_GroupBox.Text = Sukuranburu.GetString("{Trophies}");
            SelectedTrophy_GroupBox.Text = Sukuranburu.GetString("{SelectedTrophy}");
            Hint_Label.Text = Sukuranburu.GetString("{Hint:}");
            Unlocked_Checkbox.Text = Sukuranburu.GetString("{Unlocked_Trophy}");
            Unseen_Checkbox.Text = Sukuranburu.GetString("{Unseen_Trophy}");
            X_Label.Text = Sukuranburu.GetString("{X:}");
            Y_Label.Text = Sukuranburu.GetString("{Y:}");
            Scale_Label.Text = Sukuranburu.GetString("{Scale:}");
            Rotation_Label.Text = Sukuranburu.GetString("{RotationAngle:}");
            UnlockAllTrophies_Button.Text = Sukuranburu.GetString("{UnlockAllTrophies}");
            ResetPositionAll_Button.Text = Sukuranburu.GetString("{ResetPositionAll}");
            IdHeader.Text = Sukuranburu.GetString("{Id}");
            NameHeader.Text = Sukuranburu.GetString("{Name}");
            DeployTrophy_Button.Text = Sukuranburu.GetString("{Deploy}");
        }

        private void SerializeTrophies()
        {
            foreach (Trophy TrophyItem in Sukuranburu.GetItemManager().GetTrophies().Values.OrderBy(t=>t.SortIndex))
            {
                ListViewItem ItemToAdd = new ListViewItem(new string[] { TrophyItem.SortIndex.ToString(), TrophyItem.Id.ToString(), Sukuranburu.GetGameString(TrophyItem.TrophyTitle) });
                ItemToAdd.Tag = TrophyItem.Id;

                TrophyListView.Items.Add(ItemToAdd);
            }
        }

        private void SerializeWall()
        {
            TrophyWall_PictureBox.Image = ImageMethods.DrawImage("Record_bg_list", 1248, 212, DeviceDpi);

            WallUI_Trophies = new Dictionary<byte, PictureBox>();

            foreach (Trophy TrophyItem in Sukuranburu.GetItemManager().GetTrophies().Values)
            {
                PictureBox Trophy_PictureBox = new PictureBox();
                Trophy_PictureBox.BackColor = Color.Transparent;
                Trophy_PictureBox.Image = null;
                Trophy_PictureBox.Parent = TrophyWall_PictureBox;
                Trophy_PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

                WallUI_Trophies.Add(TrophyItem.Id, Trophy_PictureBox);
                DrawTrophyOnWall(TrophyItem.Id);
            }
        }

        private void DrawTrophyOnWall(byte TrophyId)
        {
            Trophy TrophyItem = Sukuranburu.GetItemManager().GetTrophy(TrophyId);
            if (TrophyItem == null || WallUI_Trophies == null || !WallUI_Trophies.ContainsKey(TrophyId))
            {
                throw new NullReferenceException("Trophy doesn't exist. Method: DrawTrophyOnWall");//return;
            }

            PictureBox Trophy_PictureBox = WallUI_Trophies[TrophyId];

            int OffsetSum = 15 * TrophyItem.Id;
            bool Unlocked = SelectedSlot.RetrieveOffset_Byte(Offsets.Trophies_Unlocked_First + OffsetSum) != 0;
            bool Deployed = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum) != -1;

            if (!Unlocked || !Deployed)
            {
                Trophy_PictureBox.Visible = false;
                return;
            }

            short XPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_XPos_First + OffsetSum);
            short YPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_YPos_First + OffsetSum);
            float Scale = SelectedSlot.RetrieveOffset_Float(Offsets.Trophies_Scale_First + OffsetSum);
            short Angle = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_RotationAngle_First + OffsetSum);

            Bitmap Image = ImageMethods.DrawImage_Percentage(string.Format("{0}_off", TrophyItem.TrophyIcon), WALL_UI_SCALE * Scale, DeviceDpi, Angle);
            Trophy_PictureBox.Visible = true;
            Trophy_PictureBox.Width = Image.Width;
            Trophy_PictureBox.Height = Image.Height;
            Trophy_PictureBox.Location = GetWallUiPosition(XPos, YPos, Image.Width / 2, Image.Height / 2);
            Trophy_PictureBox.Image = Image;
        }

        private Point GetWallUiPosition(short X, short Y, int ImageCenterX, int ImageCenterY)
        {
            double ScaleFactor = (double)DeviceDpi / 96;

            // assign center position.
            int UiX = TrophyWall_PictureBox.Width / 2;
            int UiY = TrophyWall_PictureBox.Height / 2;

            UiX += (int)Math.Round(X * WALL_UI_SCALE * ScaleFactor) - ImageCenterX;

            if (Y > 0)
            {
                UiY -= (int)Math.Round(Y * WALL_UI_SCALE * ScaleFactor) + ImageCenterY;
            }
            else
            {
                UiY += (int)Math.Round(Y * WALL_UI_SCALE * ScaleFactor) - ImageCenterY;
            }

            return new Point(UiX, UiY);
        }

        private void DisplayEmptyTrophy()
        {
            SelectedTrophy_Name_RichTextBox.Text = Sukuranburu.GetString("{NoSelectedTrophy}");
            SelectedTrophy_Desc_RichTextBox.Text = "—";
            SelectedTrophy_Hint_RichTextBox.Text = "—";
            SelectedTrophy_PictureBox.Image = null;

            Unlocked_Checkbox.Checked = false;
            Unlocked_Checkbox.Enabled = false;
            Unseen_Checkbox.Checked = false;
            Unseen_Checkbox.Enabled = false;
            XPos_NumUpDown.Value = 0;
            XPos_NumUpDown.Enabled = false;
            YPos_NumUpDown.Value = 0;
            YPos_NumUpDown.Enabled = false;
            Scale_NumUpDown.Value = 0.6666667M;
            Scale_NumUpDown.Enabled = false;
            DeployTrophy_Button.Enabled = false;

            Rotation_NumUpDown.Value = 0;
            Rotation_NumUpDown.Enabled = false;
        }

        private void DisplayTrophy(Trophy TrophyItem)
        {
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TrophyItem.TrophyTitle), SelectedTrophy_Name_RichTextBox);
            Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TrophyItem.TrophySummary), SelectedTrophy_Desc_RichTextBox);

            if (string.IsNullOrWhiteSpace(TrophyItem.TrophyHint))
            {
                SelectedTrophy_Hint_RichTextBox.Text = "—";
            }
            else
            {
                Sukuranburu.GetGameTextProcessor().SetTaggedText(Sukuranburu.GetGameString(TrophyItem.TrophyHint), SelectedTrophy_Hint_RichTextBox);
            }

            SelectedTrophy_PictureBox.Image = ImageMethods.DrawImage_Percentage(string.Format("{0}_off", TrophyItem.TrophyIcon), 0.595, DeviceDpi);

            int OffsetSum = 15 * TrophyItem.Id;

            Unlocked_Checkbox.Enabled = true;
            Unseen_Checkbox.Enabled = true;
            XPos_NumUpDown.Enabled = true;
            YPos_NumUpDown.Enabled = true;
            Rotation_NumUpDown.Enabled = true;
            Scale_NumUpDown.Enabled = true;
            DeployTrophy_Button.Enabled = true;

            Unlocked_Checkbox.Checked = SelectedSlot.RetrieveOffset_Byte(Offsets.Trophies_Unlocked_First + OffsetSum) != 0;
            Unseen_Checkbox.Checked = SelectedSlot.RetrieveOffset_Byte(Offsets.Trophies_Unseen_First + OffsetSum) != 0;

            short XPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_XPos_First + OffsetSum);
            if (XPos < XPos_NumUpDown.Minimum || XPos > XPos_NumUpDown.Maximum)
            {
                XPos = 0;
            }

            short YPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_YPos_First + OffsetSum);
            if (YPos < YPos_NumUpDown.Minimum || YPos > YPos_NumUpDown.Maximum)
            {
                YPos = 0;
            }

            decimal Scale = (decimal)SelectedSlot.RetrieveOffset_Float(Offsets.Trophies_Scale_First + OffsetSum);
            if (Scale < Scale_NumUpDown.Minimum)
            {
                Scale = Scale_NumUpDown.Minimum;
            }
            else if (Scale > Scale_NumUpDown.Maximum)
            {
                Scale = Scale_NumUpDown.Maximum;
            }

            short RotationAngle = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_RotationAngle_First + OffsetSum);
            if (RotationAngle < Rotation_NumUpDown.Minimum || RotationAngle > Rotation_NumUpDown.Maximum)
            {
                RotationAngle = 0;
            }

            XPos_NumUpDown.Value = XPos;
            YPos_NumUpDown.Value = YPos;
            Scale_NumUpDown.Value = Scale;
            Rotation_NumUpDown.Value = RotationAngle;
        }

        private void TrophyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                SelectedTrophy = 0xFF;
                return;
            }

            if (TrophyListView == null || TrophyListView.SelectedItems.Count != 1)
            {
                SelectedTrophy = 0xFF;
                DisplayEmptyTrophy();
                ReadyForUserInput = true;
                return;
            }

            byte TrophyId = (byte)TrophyListView.SelectedItems[0].Tag;
            Trophy TrophyItem = Sukuranburu.GetItemManager().GetTrophy(TrophyId);

            if (TrophyItem == null)
            {
                SelectedTrophy = 0xFF;
                DisplayEmptyTrophy();
                ReadyForUserInput = true;
                return;
            }

            SelectedTrophy = TrophyId;
            DisplayTrophy(TrophyItem);
            ReadyForUserInput = true;
        }

        private void TrophyListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnSorter.Sort(TrophyListView, e);
        }

        private void TrophyEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ColumnSorter.DisposeColumn();
        }

        private void XPos_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;

            short X_ValueToSet = (short)XPos_NumUpDown.Value;
            int OffsetSum = 15 * SelectedTrophy;
            SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_XPos_First + OffsetSum, X_ValueToSet);
            DrawTrophyOnWall(SelectedTrophy);

            ReadyForUserInput = true;
        }

        private void YPos_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;

            short Y_ValueToSet = (short)YPos_NumUpDown.Value;
            int OffsetSum = 15 * SelectedTrophy;
            SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_YPos_First + OffsetSum, Y_ValueToSet);
            DrawTrophyOnWall(SelectedTrophy);

            ReadyForUserInput = true;
        }

        private void Scale_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;

            float Scale_ValueToSet = (float)Scale_NumUpDown.Value;
            int OffsetSum = 15 * SelectedTrophy;
            SelectedSlot.UpdateOffset_Float(Offsets.Trophies_Scale_First + OffsetSum, Scale_ValueToSet);
            DrawTrophyOnWall(SelectedTrophy);

            ReadyForUserInput = true;
        }

        private void Rotation_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;

            short Rotation_ValueToSet = (short)Rotation_NumUpDown.Value;
            int OffsetSum = 15 * SelectedTrophy;
            SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_RotationAngle_First + OffsetSum, Rotation_ValueToSet);
            DrawTrophyOnWall(SelectedTrophy);

            ReadyForUserInput = true;
        }

        private void Unlocked_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;

            byte FlagToSet = Unlocked_Checkbox.Checked ? (byte)1 : (byte)0;
            int OffsetSum = 15 * SelectedTrophy;
            SelectedSlot.UpdateOffset_Byte(Offsets.Trophies_Unlocked_First + OffsetSum, FlagToSet);
            DrawTrophyOnWall(SelectedTrophy);

            ReadyForUserInput = true;
        }

        private void Unseen_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;

            byte FlagToSet = Unseen_Checkbox.Checked ? (byte)1 : (byte)0;
            int OffsetSum = 15 * SelectedTrophy;
            SelectedSlot.UpdateOffset_Byte(Offsets.Trophies_Unseen_First + OffsetSum, FlagToSet);
            DrawTrophyOnWall(SelectedTrophy);

            ReadyForUserInput = true;
        }

        private void UnlockAllTrophies_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput)
            {
                return;
            }

            ReadyForUserInput = false;

            foreach (ListViewItem Trophy in TrophyListView.Items)
            {
                byte TrophyId = (byte)Trophy.Tag;
                int OffsetSum = 15 * TrophyId;
                SelectedSlot.UpdateOffset_Byte(Offsets.Trophies_Unlocked_First + OffsetSum, 1);
                DrawTrophyOnWall(TrophyId); // should I?
            }

            if (SelectedTrophy != 0xFF)
            {
                Unlocked_Checkbox.Checked = true;
            }

            ReadyForUserInput = true;
        }

        private void DeployTrophy_Button_Click(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;
            int OffsetSum = 15 * SelectedTrophy;
            short CurrentZPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum);

            if (CurrentZPos != -1)
            {
                SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum, -1);
                SelectedSlot.UpdateOffset_Byte(Offsets.Trophies_UnkFlag_First, 1); //?
            }
            else
            {
                SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Byte(Offsets.Trophies_UnkFlag_First, 0); //?
            }

            DrawTrophyOnWall(SelectedTrophy);
            ReadyForUserInput = true;
        }
    }
}
