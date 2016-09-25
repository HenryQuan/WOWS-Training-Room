using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WOWS_Training_Room
{
    public partial class WOWS : Form
    { 
        // Constants for display texts.
        const string TRAINING_ENABLE = @"Enable Training Room";
        const string TRAINING_DISABLE = @"Disable Training Room";
        const string REPLAY_ENABLE = @"Enable Replay Mode";
        const string REPLAY_DISABLE = @"Disable Replay Mode";

        // Constants for whether training room and replay mode is enabled.
        public const string ENABLED = "1";
        public const string DISABLED = "0";

        // Constants for all data entry
        public const string PATH = @"Path:";
        public const string TRAINING = @"TrainingRoom:";
        public const string REPLAY = @"ReplayMode:";
        public const string LAUNCH = @"Launch:";
        public const string BACKUP = @"Backup:";

        // Getting Username and Documents path
        public static string userDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string targetPath = userDocument + @"\WOWSPreferencesEditor";
        public static string targetFile = targetPath + @"\data.txt";

        const string ERROR_MESSAGE = @"Error! Please enter the correct path.";
        const string WOWS_WEBSITE = @"http://worldofwarships.com/";
        const string WOWS_NUMEBR = @"http://wows-numbers.com/";
        const string WOWS_TODAY = @"https://warships.today/";

        const string REPLAYS = @"/replays";
        const string WOWS_GAME = @"/WorldOfWarships.exe";
        const string TEMP_GAME = @"temp.wowsreplay";
        const string EXTENSION_NAME = @"wowsreplay";

        public WOWS()
        {
            InitializeComponent();
        }

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
                string[] lines = { PATH, LAUNCH + "0" };
                File.WriteAllLines(targetFile, lines);
            }
        }

        private void WOWS_Load(object sender, EventArgs e)
        {
            
            // Load saved address
            pathBox.Text = DataStorage.getData(DataStorage.PATH);

            int oldLaunchTime = Convert.ToInt32(DataStorage.getData(DataStorage.LAUNCH));
            int newLaunchTime = oldLaunchTime;
            if (oldLaunchTime == 0)
            {
                // During first Launch popup a message
                MessageBox.Show(@"Welcome >_<");
            }
            else if (oldLaunchTime < 0)
            {
                MessageBox.Show(@"Please do not edit data.txt");
                newLaunchTime = 0;
            }
            // Add one to launchTime and save it.
            newLaunchTime += 1;
            DataStorage.setData(DataStorage.LAUNCH, Convert.ToString(oldLaunchTime), Convert.ToString(newLaunchTime));

            // Load correct text for training room and replay mode
            bool training = DataStorage.isTrainingRoomEnabled();
            bool replay = DataStorage.isReplayModeEnabled();
            bool backup = DataStorage.isBackup();
            // Only if the path is correct, we could do some stuff
            if (DataStorage.isGamePathLegal(DataStorage.getData(DataStorage.PATH)) == true)
            {
                if (training == true)
                {
                    this.trainingRoom.Text = TRAINING_DISABLE;
                }
                if (replay == true)
                {
                    this.replayMode.Text = REPLAY_DISABLE;
                }
            }


            if (DataStorage.isGamePathLegal(DataStorage.getData(DataStorage.PATH)) == true && backup == false)
            {
                // When the path is correct, create a backup to prevent incident.
                if (!File.Exists(targetPath + DataStorage.PREFER_XML))
                {
                    File.Copy(DataStorage.getData(DataStorage.PATH) + DataStorage.PREFER_XML, targetPath + DataStorage.PREFER_XML);
                    DataStorage.setData(DataStorage.BACKUP, @"0", @"1");
                }
            }
            
        }

        // Get gamepath from anywhere possible
        private void gamepathSetting()
        {
            // Getting the game path from textbox
            string gamePath = this.pathBox.Text;

            string oldPath = DataStorage.getData(DataStorage.PATH);
            if (gamePath == @"")
            {
                // If user does not enter it yet
                MessageBox.Show(@"Please paste your game path into the textbox below.");
            }
            else if (!gamePath.Contains(@"\") || !gamePath.Contains(@":"))
            {
                // A simple check for address
                MessageBox.Show(@"Please paste a valid game path below.");
            }
            else
            {
                if (oldPath != this.pathBox.Text)
                {
                    // If user has changed the path, new address will be saved
                    DataStorage.setData(DataStorage.PATH, oldPath, this.pathBox.Text);
                }
            }
        }

        private void trainingRoom_Click(object sender, EventArgs e)
        {
            gamepathSetting();
            if (DataStorage.isGamePathLegal(DataStorage.getData(DataStorage.PATH)) == true)
            {
                // Check if path is correct
                var preference = DataStorage.getData(DataStorage.PATH) + DataStorage.PREFER_XML;

                // Not quite a quick mathod, but you do the same way
                var temp = File.ReadAllText(preference);

                // Change the text for this button
                if (trainingRoom.Text == TRAINING_ENABLE)
                {
                    trainingRoom.Text = TRAINING_DISABLE;

                    if (temp.Contains(DataStorage.RANDOM_BATTLE))
                    {
                        temp = temp.Replace(DataStorage.RANDOM_BATTLE, DataStorage.TRAINING_BATTLE);
                    }
                    else if (temp.Contains(DataStorage.COOP_BATTLE))
                    {
                        temp = temp.Replace(DataStorage.COOP_BATTLE, DataStorage.TRAINING_BATTLE);
                    }
                    
                    // Ssave changes to data.txt
                    string oldTraining = DataStorage.getData(DataStorage.TRAINING);
                    DataStorage.setData(DataStorage.TRAINING, oldTraining, DataStorage.DISABLED);
                }
                else
                {
                    trainingRoom.Text = TRAINING_ENABLE;
                    temp = temp.Replace(DataStorage.TRAINING_BATTLE, DataStorage.RANDOM_BATTLE);

                    // save changes to data.txt
                    string oldTraining = DataStorage.getData(DataStorage.TRAINING);
                    DataStorage.setData(DataStorage.TRAINING, oldTraining, DataStorage.ENABLED);
                }

                // Save changes to preferences.xml
                File.WriteAllText(preference, temp);

                // Only could do this once per launch
                trainingRoom.Enabled = false;
            }
        }

        private void replayMode_Click(object sender, EventArgs e)
        {
            gamepathSetting();

            if (DataStorage.isGamePathLegal(DataStorage.getData(DataStorage.PATH)) == true)
            {
                // This is not a quick way of doing it.
                string newData = @"";

                // Make the path string
                var preference = DataStorage.getData(DataStorage.PATH) + DataStorage.PREFER_XML;

                if (replayMode.Text == REPLAY_ENABLE)
                {
                    replayMode.Text = REPLAY_DISABLE;

                    int index = 0;
                    foreach (string data in File.ReadLines(preference))
                    {
                        // Just ignore those two line
                        if (data.Contains(DataStorage.SCRIPTS))
                        {
                            index++;
                            // For a .xml file, there are 2 same texts.
                            //
                            //<root>
                            //    xxxxx
                            //    xxxxx
                            //<root>
                            //
                            if (index != 2)
                            {
                                if (newData == "")
                                {
                                    newData += data;
                                }
                                else
                                {
                                    newData += "\n" + data;
                                }
                            }
                            else
                            {
                                // I have no idea how to use xmlDocument to edit this file.
                                newData += "\n" + DataStorage.REPLAY_MODE_TEXT;
                                newData += "\n" + DataStorage.REPLAY_UPDATE_TEXT;
                                newData += "\n" + data;

                                // Change index to 0 again, to prevent running codes above
                                index = 0;
                            }
                        }
                        else
                        {
                            if (index != 2)
                            {
                                if (newData == "")
                                {
                                    newData += data;
                                }
                                else
                                {
                                    newData += "\n" + data;
                                }
                            }
                        }
                    }
                }
                else
                {
                    replayMode.Text = REPLAY_ENABLE;

                    foreach (string data in File.ReadLines(preference))
                    {
                        // Just ignore those two line
                        if (data.Contains(DataStorage.REPLAY_MODE) || data.Contains(DataStorage.REPLAY_UPDATE)) { }
                        else if (newData == @"")
                        {
                            newData += data;
                        }
                        else
                        {
                            newData += "\n" + data;
                        }
                    }
                }

                File.Delete(preference);
                File.WriteAllText(preference, newData);
                // Could only change this once per launch
                replayMode.Enabled = false;
            }
        }

        private void WOWS_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Keep updating new address
            string gamePath = this.pathBox.Text;

            string oldPath = DataStorage.getData(DataStorage.PATH);
            if (gamePath == @"") { }
            else if (!gamePath.Contains(@"\") || !gamePath.Contains(@":")) { }
            else
            {
                if (oldPath != this.pathBox.Text)
                {
                    // If user has changed the path, new address will be saved
                    DataStorage.setData(DataStorage.PATH, oldPath, this.pathBox.Text);
                }
            }
        }

        private void launchGameBtn_Click(object sender, EventArgs e)
        {
            gamepathSetting();

            if (DataStorage.isGamePathLegal(DataStorage.getData(DataStorage.PATH)) == true)
            {
                // Launch game launcher >_<
                string gamePath = DataStorage.getData(DataStorage.PATH);
                if (!File.Exists(gamePath + DataStorage.GAME_EXE))
                {
                    MessageBox.Show(ERROR_MESSAGE);
                }
                else
                {
                    Process.Start(gamePath + DataStorage.GAME_EXE);
                }
                Application.Exit();
            } 
        }

        private void uninstallGameBtn_Click(object sender, EventArgs e)
        {
            gamepathSetting();

            if (DataStorage.isGamePathLegal(DataStorage.getData(DataStorage.PATH)) == true)
            {
                // WOWS ASIA Worse Server Ever
                string gamePath = DataStorage.getData(DataStorage.PATH);
                if (!File.Exists(gamePath + DataStorage.UNINSTALL_EXE))
                {
                    MessageBox.Show(ERROR_MESSAGE);
                }
                else
                {
                    MessageBox.Show("WOWS ASIA" + "\n" + "Worst Server Ever!");
                    Process.Start(gamePath + DataStorage.UNINSTALL_EXE);
                }
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open about form when about is clicked
            aboutForm about = new aboutForm();
            about.ShowDialog();
        }

        private void openGameDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open game directory
            Process.Start(DataStorage.getData(DataStorage.PATH));
        }

        private void officialSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open official site
            Process.Start(WOWS_WEBSITE);
        }

        private void warshipsTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // WOWS Today
            Process.Start(WOWS_TODAY);
        }

        private void woWsStatsNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // WOWS stats
            Process.Start(WOWS_NUMEBR);
        }

        private void openReplayFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open replay directory if there is one
            string replayPath = DataStorage.getData(DataStorage.PATH);

            if (Directory.Exists(replayPath))
            {
                Process.Start(replayPath + REPLAYS);
            }
            else
            {
                MessageBox.Show(@"Please enable replay mode first");
            }
        }

        private void watchLastReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the path
            string replayPath = DataStorage.getData(DataStorage.PATH) + REPLAYS;
            string processName = @"WorldOfWarships";

            if (Directory.Exists(replayPath))
            {
                // If the game is running the do nothing
                if(!IsProcessOpen(processName))
                {
                    DateTime lastHigh = new DateTime(1900, 1, 1);
                    string highDir = @"";
                    foreach (string subdir in Directory.GetFiles(replayPath))
                    {
                        DirectoryInfo fi1 = new DirectoryInfo(subdir);
                        DateTime created = fi1.LastWriteTime;

                        if (!subdir.Contains(TEMP_GAME) && subdir.Contains(EXTENSION_NAME) && created > lastHigh)
                        {
                            highDir = subdir;
                            lastHigh = created;
                        }
                    }
                    Console.WriteLine(highDir);
                    Process.Start(highDir, replayPath + WOWS_GAME);
                }
                else
                {
                    MessageBox.Show(@"Please close the game first before watching your last battle.");
                }
            }
            else
            {
                MessageBox.Show(@"Please enable replay mode first");
            }
        }

        private bool IsProcessOpen(string name)
        {
            bool isOpen = false;
            foreach (Process clsProcess in Process.GetProcesses())
            {
                Console.WriteLine(clsProcess.ProcessName);
                if (clsProcess.ProcessName.Contains(name))
                {
                    isOpen = true;
                }
            }

            return isOpen;
        }

    }
}