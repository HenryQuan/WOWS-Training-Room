using System;
using System.IO;
using System.Windows.Forms;

namespace WOWS_Training_Room
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(WOWS.targetFile))
            {
                // Setup for DataStorage
                WOWS.setup();

                // GamePath for first launch
                Application.Run(new gamePath());
                Application.Run(new WOWS());
            }
            else
            {
                Application.Run(new WOWS());
            }     
        }
    }
}
