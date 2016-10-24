using System;
using System.IO;

namespace WOWS_Training_Room
{
    public static class DataStorage
    {
        // Constants for whether training room and replay mode is enabled.
        public const string ENABLED = "1";
        public const string DISABLED = "0";

        // Constants for all data entry
        public const string PATH = @"Path:";
        public const string TRAINING = @"TrainingRoom:";
        public const string REPLAY = @"ReplayMode:";
        public const string LAUNCH = @"Launch:";
        public const string BACKUP = @"Backup:";

        // Constants for battle types
        public const string RANDOM_BATTLE = @"RandomBattle";
        public const string COOP_BATTLE = @"CooperativeBattle";
        public const string TRAINING_BATTLE = @"TrainingBattle";

        // Constants for important files.
        public const string GAME_EXE = @"\WoWSLauncher.exe";
        public const string UNINSTALL_EXE = @"\unins000.exe";
        public const string PREFER_XML = @"\preferences.xml";

        // Constants for replay mode
        public const string SCRIPTS = @"scriptsPreferences";
        public const string REPLAY_MODE = @"isReplayEnabled";
        public const string REPLAY_UPDATE = @"ReplayCameraUpdate";
        public const string REPLAY_MODE_TEXT = @"<isReplayEnabled>true</isReplayEnabled>";
        public const string REPLAY_UPDATE_TEXT = @"<ReplayCameraUpdate>30</ReplayCameraUpdate>";

        public static string userDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string targetPath = userDocument + @"\WOWSPreferencesEditor";
        public static string targetFile = targetPath + @"\data.txt";

        public static int launchTime = 0;

        static DataStorage()
        {
            // Well, nothing here
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

        public static bool isBackup()
        {
            bool isEnabled = false;

            // Get the path for preferences.xml
            string backup = getData(BACKUP);

            if (backup == @"1")
            {
                isEnabled = true;
            }

            Console.WriteLine(Convert.ToString(isEnabled));
            return isEnabled;
        }

        // Check if training room is enabled
        public static bool isTrainingRoomEnabled()
        {
            bool isEnabled = false;

            if (isGamePathLegal(getData(PATH)))
            {
                // Get the path for preferences.xml
                string preference = getData(PATH) + PREFER_XML;
                string temp = File.ReadAllText(preference);

                if (temp.Contains(TRAINING_BATTLE))
                {
                    isEnabled = true;
                }

                Console.WriteLine(Convert.ToString(isEnabled));
            }
            
            return isEnabled;
        }

        // Check if replay mode is enabled
        public static bool isReplayModeEnabled()
        {
            bool isEnabled = false;

            if (isGamePathLegal(getData(PATH)))
            {
                string preference = getData(PATH) + PREFER_XML;

                // Load our preferences.xml
                if (File.ReadAllText(preference).Contains(REPLAY_MODE))
                {
                    isEnabled = true;
                }

                Console.WriteLine(Convert.ToString(isEnabled));
            }
                
            return isEnabled;
        }

        // Check if training room is enabled
        public static bool isDownloadBoostEnabled()
        {
            bool isEnabled = false;

            if (isGamePathLegal(getData(PATH)))
            {
                // Get the path for preferences.xml
                string preference = getData(PATH) + @"\WoWSLauncher.cfg";
                string temp = File.ReadAllText(preference);

                if (temp.Contains(@"<launcher_transport>2</launcher_transport>"))
                {
                    isEnabled = true;
                }

                Console.WriteLine(Convert.ToString(isEnabled));
            }

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
