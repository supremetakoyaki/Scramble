using System;
using System.Windows.Forms;

namespace Scramble
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static ScrambleForm Sukuranburu;

        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Sukuranburu = new ScrambleForm();
            Application.Run(Sukuranburu);
        }
    }
}
