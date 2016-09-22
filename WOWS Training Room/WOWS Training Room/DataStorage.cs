using System;
using System.IO;

namespace WOWS_Training_Room
{
    public static class DataStorage
    {
        // Constants for setting up.
        public const int DEFAULT_VALUE = 1;
        public const int INITIAL_SETUP = 0;

        // Constants for whether training room and replay mode is enabled.
        public const string ENABLED = "1";
        public const string DISABLED = "0";

        // Constants for all data entry
        public const string PATH = @"Path:";
        public const string TRAINING = @"TrainingRoom:";
        public const string REPLAY = @"ReplayMode:";
        public const string LAUNCH = @"Launch:";

        // Constant for battle types
        public const string RANDOM_BATTLE = @"RandomBattle";
        public const string COOP_BATTLE = @"CooperationBattle";
        public const string TRAINING_BATTLE = @"TrainingBattle";

        // Constant for important files.
        public const string GAME_EXE = @"\WoWSLauncher.exe";
        public const string UNINSTALL_EXE = @"\unins000.exe";
        public const string PREFER_XML = @"\preferences.xml";

        // Getting Username and Documents path
        public static string userDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string targetPath = userDocument + @"\WOWSPreferencesEditor";
        public static string targetFile = targetPath + @"\data.txt";
        public static int launchTime = 0;

        // Setup data document and data.xml
        public static void setup()
        {
            // Test if the directory is correct.
            Console.WriteLine(targetPath);
            // If there is no such directory, create one.
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            // If there is no data.txt, create one as well.
            if (!File.Exists(targetFile))
            {
                // Create and close this file
                File.Create(targetFile).Close();
            }

            if (File.ReadAllText(targetFile) == @"")
            {
                string[] lines = { PATH, TRAINING + DISABLED, REPLAY + DISABLED, LAUNCH + "0" };
                File.WriteAllLines(targetFile, lines);
            }
        }

        // Getting data from data.txt
        public static string getData(string data)
        {
            string temp = "";
            foreach (string line in File.ReadLines(targetFile))
            {
                
                if (line.Contains(data))
                {
                    temp = line.Substring(line.IndexOf(':')+1);
                    Console.WriteLine(temp);
                }
            }

            return temp;
        }

        // Setting new data to data.txt
        public static void setData(string entry, string oldData, string newData)
        {
            string temp = File.ReadAllText(targetFile);
            // If there is no oldDate
            if (oldData == "")
            {
                temp = temp.Replace(entry, entry + newData);
            }
            else
            {
                temp = temp.Replace(entry + oldData, entry + newData);
            }

            Console.WriteLine(temp);

            File.WriteAllText(targetFile, temp);
        }

        // Check if training room is enabled
        public static bool isTrainingRoomEnabled()
        {
            bool isEnabled = false;

            // Get the path for preferences.xml
            string preference = getData(PATH) + PREFER_XML;
            string temp = File.ReadAllText(preference);

            if (temp.Contains(TRAINING_BATTLE))
            {
                isEnabled = true;
            }

            Console.WriteLine(Convert.ToString(isEnabled));
            return isEnabled;
        }

        // Check if replay mode is enabled
        public static bool isReplayModeEnabled()
        {
            bool isEnabled = false;

            Console.WriteLine(Convert.ToString(isEnabled));
            return isEnabled;
        }

        // Check whether user provides correct game path
        public static bool isGamePathLegal(string gamepath)
        {
            bool isLegal = false;

            // WoWsLauncher.exe is found in this folder, it should be legal path
            if (File.Exists(gamepath + @"\WoWSLauncher.exe"))
            {
                isLegal = true;
            }

            return isLegal;
        }
    }
}
