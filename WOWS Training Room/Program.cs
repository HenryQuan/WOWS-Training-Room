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

            // Check the language wich user uses

            // Check if the path is being Created
            if (!File.Exists(WOWS.targetFile) || DataStorage.getData(DataStorage.PATH) == @"")
            {
                // Setup for DataStorage
                WOWS.setup();

                // GamePath for first launch
                Application.Run(new gamePath());

                // Then launch our main form
                Application.Run(new WOWS());
            }
            else
            {
                // Dont have to setup everytime
                Application.Run(new WOWS());
            }     
        }
    }
}
