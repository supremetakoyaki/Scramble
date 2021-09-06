using NTwewyDb;
using Scramble.Classes;
using Scramble.GameData;
using Scramble.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace Scramble.Forms
{
    public partial class TrophyEditor : Form
    {
        public SaveData SelectedSlot => Program.Sukuranburu.SelectedSlot;
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private List<Tuple<byte, short>> LayeredTrophies;
        private byte SelectedTrophy;

        private bool ReadyForUserInput = false;

        public TrophyEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            DisplayLanguageStrings();

            if (Sukuranburu.RequiresRescaling)
            {
                TrophyListView.AutoSize = true;
            }

            SerializeTrophies();
            SortLayers();
            SerializeWall();

            if (TrophyListView.Items.Count > 0)
            {
                TrophyListView.Items[0].Selected = true;
                TrophyListView.Select();
            }
            else
            {
                DisplayEmptyTrophy();
            }

            ReadyForUserInput = true;
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
            ShowAsNew_Checkbox.Text = Sukuranburu.GetString("{ShowAsNew}");
            AutoDrawWall_Checkbox.Text = Sukuranburu.GetString("{AutoDraw}");
            RedrawWall_Button.Text = Sukuranburu.GetString("{RedrawWall}");
            ExportPng_Button.Text = Sukuranburu.GetString("{ExportPng}");
            Z_Label.Text = Sukuranburu.GetString("{Z:}");
        }

        private void SerializeTrophies()
        {
            LayeredTrophies = new List<Tuple<byte, short>>();

            foreach (Trophy TrophyItem in Sukuranburu.GetItemManager().GetTrophies().Values.OrderBy(t => t.SortIndex))
            {
                ListViewItem ItemToAdd = new ListViewItem(new string[] { TrophyItem.SortIndex.ToString(), TrophyItem.Id.ToString(), Sukuranburu.GetGameString(TrophyItem.TrophyTitle) });
                ItemToAdd.Tag = TrophyItem.Id;
                TrophyListView.Items.Add(ItemToAdd);

                short LayerIndex = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_ZPos_First + (15 * TrophyItem.Id));
                LayeredTrophies.Add(new Tuple<byte, short>(TrophyItem.Id, LayerIndex));
            }
        }

        private void SortLayers()
        {
            LayeredTrophies = LayeredTrophies.OrderByDescending(x => x.Item2).ToList();
        }

        private void FixLayerIndexes()
        {
            short Index = 0;
            for (int i = LayeredTrophies.Count - 1; i > -1; i--)
            {
                if (LayeredTrophies[i].Item2 != -1)
                {
                    LayeredTrophies[i] = new Tuple<byte, short>(LayeredTrophies[i].Item1, Index);
                    SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_ZPos_First + (15 * LayeredTrophies[i].Item1), Index);
                    Index += 1;
                }
            }
        }

        private void SerializeWall()
        {
            TrophyWall_PictureBox.Image = GenerateImage(0.311844078, DeviceDpi, 1248, 212);
        }

        private Bitmap GenerateImage(double WallScale, float Dpi, int Width, int Height)
        {
            Bitmap BaseImage = ImageMethods.DrawImage("Record_bg_list", Width, Height, Dpi);

            int X_Center = BaseImage.Width / 2;
            int Y_Center = BaseImage.Height / 2;

            using (Graphics G = Graphics.FromImage(BaseImage))
            {
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;

                foreach (Tuple<byte, short> LayeredTrophy in LayeredTrophies)//(Trophy TrophyItem in Sukuranburu.GetItemManager().GetTrophies().Values)
                {
                    byte TrophyId = LayeredTrophy.Item1;
                    Trophy TrophyItem = Sukuranburu.GetItemManager().GetTrophy(TrophyId);

                    if (TrophyItem != null)
                    {
                        int OffsetSum = 15 * TrophyId;
                        bool Unlocked = SelectedSlot.RetrieveOffset_Byte(Offsets.Trophies_Unlocked_First + OffsetSum) != 0;
                        bool Deployed = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum) != -1;

                        if (Unlocked && Deployed) // Time to draw!
                        {
                            short XPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_XPos_First + OffsetSum);
                            short YPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_YPos_First + OffsetSum);
                            float Scale = SelectedSlot.RetrieveOffset_Float(Offsets.Trophies_Scale_First + OffsetSum);
                            short Angle = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_RotationAngle_First + OffsetSum);

                            Angle = (short)(0 - Angle);

                            Bitmap TrophyImage = ImageMethods.DrawImage_Percentage(string.Format("{0}_off", TrophyItem.TrophyIcon), WallScale * Scale, Dpi);
                            TrophyImage = BitmapUtil.RotateImage(TrophyImage, Angle);

                            int ImageX = X_Center + (int)(XPos * WallScale) - (TrophyImage.Width / 2);
                            int ImageY = Y_Center - (int)(YPos * WallScale) - (TrophyImage.Height / 2);
                            G.DrawImage(TrophyImage, ImageX, ImageY, TrophyImage.Width, TrophyImage.Height);
                        }
                    }
                }
            }

            return BaseImage;
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
            ZPos_NumUpDown.Value = -1;
            ZPos_NumUpDown.Enabled = false;
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
            ZPos_NumUpDown.Enabled = true;
            Rotation_NumUpDown.Enabled = true;
            Scale_NumUpDown.Enabled = true;

            Unlocked_Checkbox.Checked = SelectedSlot.RetrieveOffset_Byte(Offsets.Trophies_Unlocked_First + OffsetSum) != 0;
            Unseen_Checkbox.Checked = SelectedSlot.RetrieveOffset_Byte(Offsets.Trophies_Unseen_First + OffsetSum) != 0;
            ShowAsNew_Checkbox.Checked = SelectedSlot.RetrieveOffset_Byte(Offsets.Trophies_Unseen_First + OffsetSum) != 0;
            DeployTrophy_Button.Enabled = Unlocked_Checkbox.Checked;

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

            short ZPos = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum);
            if (ZPos < ZPos_NumUpDown.Minimum)
            {
                ZPos = (short)ZPos_NumUpDown.Minimum;
            }
            else if (ZPos > ZPos_NumUpDown.Maximum)
            {
                ZPos = (short)ZPos_NumUpDown.Maximum;
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
            ZPos_NumUpDown.Value = ZPos;
            Scale_NumUpDown.Value = Scale;
            Rotation_NumUpDown.Value = RotationAngle;
        }

        private void UpdateLayer(byte Id, short Value)
        {
            for (int i = 0; i < LayeredTrophies.Count; i++)
            {
                if (LayeredTrophies[i].Item1 == Id)
                {
                    LayeredTrophies[i] = new Tuple<byte, short>(Id, Value);
                    return;
                }
            }
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
                //DisplayEmptyTrophy();
                ReadyForUserInput = true;
                return;
            }

            ReadyForUserInput = false;

            byte TrophyId = (byte)TrophyListView.SelectedItems[0].Tag;
            Trophy TrophyItem = Sukuranburu.GetItemManager().GetTrophy(TrophyId);

            if (TrophyItem == null)
            {
                SelectedTrophy = 0xFF;
                //DisplayEmptyTrophy();
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
            FixLayerIndexes();
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

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

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

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

            ReadyForUserInput = true;
        }

        private void ZPos_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;
            int OffsetSum = 15 * SelectedTrophy;

            short Z_PreviousValue = SelectedSlot.RetrieveOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum);
            short Z_ValueToSet = (short)ZPos_NumUpDown.Value;
            SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum, Z_ValueToSet);

            UpdateLayer(SelectedTrophy, Z_ValueToSet);

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

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

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

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

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

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
            DeployTrophy_Button.Enabled = Unlocked_Checkbox.Checked;
            SortLayers();

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

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

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

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
            }

            if (SelectedTrophy != 0xFF)
            {
                Unlocked_Checkbox.Checked = true;
                DeployTrophy_Button.Enabled = true;
            }

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

            ReadyForUserInput = true;
        }

        private void ResetPositionAll_Button_Click(object sender, EventArgs e)
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

                //SelectedSlot.UpdateOffset_Byte(Offsets.Trophies_Unseen_First + OffsetSum, 1);
                SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_XPos_First + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_YPos_First + OffsetSum, 0);
                SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum, -1);
                SelectedSlot.UpdateOffset_Float(Offsets.Trophies_Scale_First + OffsetSum, 0.6666667f);
                SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_RotationAngle_First + OffsetSum, 0);
            }

            if (SelectedTrophy != 0xFF)
            {
                //Unseen_Checkbox.Checked = true;
                XPos_NumUpDown.Value = 0;
                YPos_NumUpDown.Value = 0;
                Scale_NumUpDown.Value = 0.6666667M;
                Rotation_NumUpDown.Value = 0;
            }

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
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
                ZPos_NumUpDown.Value = -1;
            }
            else
            {
                SelectedSlot.UpdateOffset_Int16(Offsets.Trophies_ZPos_First + OffsetSum, 0);
                ZPos_NumUpDown.Value = 0;
            }

            SortLayers();
            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

            ReadyForUserInput = true;
        }

        private void ShowAsNew_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ReadyForUserInput || SelectedTrophy == 0xFF)
            {
                return;
            }

            ReadyForUserInput = false;

            byte FlagToSet = ShowAsNew_Checkbox.Checked ? (byte)1 : (byte)0;
            int OffsetSum = 15 * SelectedTrophy;
            SelectedSlot.UpdateOffset_Byte(Offsets.Trophies_ShowAsNew_First + OffsetSum, FlagToSet);

            if (AutoDrawWall_Checkbox.Checked)
            {
                SerializeWall();
            }

            ReadyForUserInput = true;
        }

        private void RedrawWall_Button_Click(object sender, EventArgs e)
        {
            SerializeWall();
        }

        private void ExportPng_Button_Click(object sender, EventArgs e)
        {
            SaveFileDialog ExportDialog = new SaveFileDialog
            {
                Filter = "PNG file (*.png)|*.png",
                DefaultExt = "png",
                AddExtension = true
            };

            if (ExportDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Image = GenerateImage(1, 96, 4002, 680);
                Image.Save(ExportDialog.FileName, ImageFormat.Png);
            }
        }
    }
}
