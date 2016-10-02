using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WOWS_Training_Room.Resources;

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
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Console.WriteLine(currentCulture.EnglishName);

            // Currently, there is only globalization for simplified chinese
            if (currentCulture.EnglishName.Contains(@"Chinese") &&
                currentCulture.EnglishName.Contains(@"Simplified"))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(@"zh-Hans");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(@"zh-Hans");
            }

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
