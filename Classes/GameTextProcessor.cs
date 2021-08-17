using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Scramble.Classes
{
    public class GameTextProcessor
    {
        public Dictionary<string, char> CharacterTags = new Dictionary<string, char>()
        {
            { "<NBSP>", (char)0xA0 },
            { "<BR>", (char)0xA },
            { "<CMT>", (char)0x0 },
            { "<MK_1>", (char)0x27 },
            { "<MK_11>", (char)0x22 },
            { "<MK_YEN>", (char)0xA5 },
            { "<MK_PLS>", (char)0x2B },
            { "<MK_PCT>", (char)0x25 }
        };

        public Dictionary<string, Color> ColorDic = new Dictionary<string, Color>()
        {
            { "RE", Color.Red },
            { "AQ", Color.Aqua },
            { "YE", Color.Yellow },
            { "GY", Color.Gray }
        };

        public const string ALL_PATTERN = "<[^>]*>";
        public const string COLOR_PATTERN = "<C(.*?)>(.*?)<\\/C>";
        public const string ITALIC_PATTERN = "<(.*?)>(.*?)<\\/i>";
        public const string SIZE_PATTERN = "<(.*?)%>(.*?)<\\/size>";
        //Not really necessary: public const string CENTER_PATTERN = "<center>(.*?)<\\/center>";

        public void ReplaceCharacterTags(ref string Text)
        {
            foreach (string Tag in CharacterTags.Keys)
            {
                Text = Text.Replace(Tag, $"{CharacterTags[Tag]}");
            }
        }

        public string RemoveTags(string Text)
        {
            return Regex.Replace(Text, ALL_PATTERN, "");
        }

        public void SetTaggedText(string Text, RichTextBox Box)
        {
            if (Box == null)
            {
                return;
            }

            Box.Clear();
            Box.SelectionStart = Box.TextLength;
            Box.SelectionLength = 0;
            Box.SelectionFont = Box.Font;
            Box.SelectionColor = Box.ForeColor;

            Regex Expressions = new Regex(COLOR_PATTERN + '|' + ITALIC_PATTERN + '|' + SIZE_PATTERN);

            string[] SplittedText = Expressions.Split(Text);
            foreach (string Piece in SplittedText)
            {

                if (Piece.Length == 2 && ColorDic.ContainsKey(Piece))
                {
                    SetColor(ColorDic[Piece], Box);
                }
                else if (Piece.StartsWith("size=") && double.TryParse(Piece.Substring(5), out double Percentage))
                {
                    SetSizePercentage(Percentage, Box);
                }
                else if (Piece == "i")
                {
                    SetItalics(Box);
                }
                else
                {
                    Box.AppendText(Piece);
                    Box.SelectionFont = Box.Font;
                    Box.SelectionColor = Box.ForeColor;
                }
            }
        }

        private void SetColor(Color Color, RichTextBox Box)
        {
            Box.SelectionStart = Box.TextLength;
            Box.SelectionLength = 0;

            Box.SelectionColor = Color;
        }

        private void SetSizePercentage(double Percentage, RichTextBox Box)
        {
            Box.SelectionStart = Box.TextLength;
            Box.SelectionLength = 0;

            float NewFontSize = (float)decimal.Round((decimal)(Box.SelectionFont.Size * (Percentage / 100)), 2);

            Box.SelectionFont = new Font(Box.SelectionFont.FontFamily, NewFontSize, Box.SelectionFont.Style);
        }

        private void SetItalics(RichTextBox Box)
        {
            Box.SelectionStart = Box.TextLength;
            Box.SelectionLength = 0;

            Box.SelectionFont = new Font(Box.SelectionFont.FontFamily, Box.SelectionFont.Size, FontStyle.Italic);
        }
    }
}
