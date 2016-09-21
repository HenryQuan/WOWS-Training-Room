using System;
using System.IO;
using System.Xml;

namespace WOWS_Training_Room
{
    public class DataStorage
    {
        // Constants for setting up.
        public const int DEFAULT_VALUE = -1;
        public const int INITIAL_SETUP = 0;
        public const int SETUP_SUCCESS = 1;
        public const int SETUP_ERROR = 2;

        // Constants for whether training room and replay mode is enabled.
        public const int ENABLED = 1;
        public const int DISABLED = 0;

        // Getting Username and Documents path
        public static string userDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string gamePath = "";
        public static string targetPath = userDocument + @"\WOWSPreferencesEditor";
        public static string targetFile = targetPath + @"\data.txt";

        // Setup data document and data.xml
        public int setup()
        {
            int returnValue = DEFAULT_VALUE;

            // Test if the directory is correct.
            Console.WriteLine(targetPath);

            // If there is no such directory, create one.
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
                returnValue = INITIAL_SETUP;
            }

            // If there is no data.txt, create one as well.
            if (!File.Exists(targetFile))
            {
                // Create and close this file
                File.Create(targetFile).Close();
                returnValue = INITIAL_SETUP;
            }

            if (File.ReadAllText(targetFile) == "")
            {
                // 0 means disabled, 1 means enabled.
                
            }

            foreach (string line in File.ReadLines(targetFile))
            {
                if (line.Contains(@"Path:"))
                {
                    gamePath = line.Substring(5);
                    Console.WriteLine(gamePath);
                }
            }

            if (gamePath == "")
            {
                returnValue = INITIAL_SETUP;
            }
        }

        // Getting game path from data.xml
        public static string getGamePath()
        {
            return gamePath;
        }
        
        // Setting new game path from WOWS form.
        public static string setGamePath(string path)
        {
            gamePath = path;
            return gamePath;
        }

        // Check if training room is enabled
        public static bool isTrainingRoomEnabled()
        {
            bool isEnabled = false;

            return isEnabled;
        }

        // Check if replay mode is enabled
        public static bool isReplayModeEnabled()
        {
            bool isEnabled = false;

            return isEnabled;
        }
    }
}
