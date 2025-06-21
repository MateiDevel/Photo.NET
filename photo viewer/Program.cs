using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photo_viewer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.firstRun == true)
            {
                Application.Run(new firstRunForm());
                Properties.Settings.Default.firstRun = false;
                Properties.Settings.Default.Save();
            }
            else 
            {
                Application.Run(new Form1());
            }
        }
    }
}
