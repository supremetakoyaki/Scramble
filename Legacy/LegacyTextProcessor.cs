using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Scramble.Legacy
{
    public class LegacyTextProcessor
    {
        public const string BB_COLOR_PATTERN = "\\[(.*?)\\]";

        public void SetTaggedText(string Text, RichTextBox Box)
        {
            if (Box == null)
            {
                return;
            }

            Text = Text.Replace(@"\x22", "\"").Replace(@"\n", "\n");

            Box.Clear();
            Box.SelectionStart = Box.TextLength;
            Box.SelectionLength = 0;
            Box.SelectionFont = Box.Font;
            Box.SelectionColor = Box.ForeColor;

            Regex Expressions = new Regex(BB_COLOR_PATTERN);

            string[] SplittedText = Expressions.Split(Text);
            foreach (string Piece in SplittedText)
            {
                if (Piece.Length == 7 && Piece.StartsWith("#"))
                {
                    SetColor(Piece, Box);
                }
                else
                {
                    Box.AppendText(Piece);
                }
            }
        }

        private void SetColor(string Color, RichTextBox Box)
        {
            Box.SelectionStart = Box.TextLength;
            Box.SelectionLength = 0;

            Box.SelectionColor = ColorTranslator.FromHtml(Color);
        }
    }
}
