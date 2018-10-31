using System;
using System.Collections.Generic;
using System.Windows.Forms;

// $G$ SFN-012 (+12) Bonus: Events in the Logic layer are handled by the UI.
// $G$ SFN-013 (+6) Bonus: Animation

// $G$ SFN-999 (-5) max rows should be 10
// $G$ SFN-999 (-5) game layout not exactly as requested - the buttons for selecting which column to drop not showing a symbol

namespace FourInARow
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameSettingsForm());
        }
    }
}
