using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace WOWS_Training_Room
{
    public partial class WOWS : Form
    { 
        // Constants for display texts.
        const string TRAINING_ENABLE = @"Enable Training Room";
        const string TRAINING_DISABLE = @"Disable Training Room";
        const string REPLAY_ENABLE = @"Enable Replay Mode";
        const string REPLAY_DISABLE = @"Disable Replay Mode";

        const string ERROR_MESSAGE = @"Error! Please enter the correct path.";

        public WOWS()
        {
            InitializeComponent();
        }

        private void WOWS_Load(object sender, EventArgs e)
        {
            // Setup for DataStorage
            DataStorage.setup();

            // Load saved address
            this.pathBox.Text = DataStorage.getData(DataStorage.PATH);

            int oldLaunchTime = Convert.ToInt32(DataStorage.getData(DataStorage.LAUNCH));
            int newLaunchTime = oldLaunchTime;
            if (oldLaunchTime == 0)
            {
                // During first Launch popup a message
                MessageBox.Show(@"This is the first launch of this program" + "\n" + @"Please paste your game path into the textbox below.");
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

            if (training == true)
            {
                this.trainingRoom.Text = TRAINING_DISABLE;
            }
            if (replay == true)
            {
                this.replayMode.Text = REPLAY_DISABLE;
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

            // Check if path is correct
            var preference = DataStorage.getData(DataStorage.PATH);
            if (DataStorage.isGamePathLegal(preference) == true)
            {
                preference += DataStorage.PREFER_XML;
            }

            // Not quite a quick mathod, but you do the same way
            var temp = File.ReadAllText(preference);

            // Change the text for this button
            if (trainingRoom.Text == TRAINING_ENABLE)
            {
                trainingRoom.Text = TRAINING_DISABLE;
                temp = temp.Replace(DataStorage.TRAINING_BATTLE, DataStorage.RANDOM_BATTLE);

                // Ssave changes to data.txt
                string oldTraining = DataStorage.getData(DataStorage.TRAINING);
                DataStorage.setData(DataStorage.TRAINING, oldTraining, DataStorage.DISABLED);
            }
            else
            {
                trainingRoom.Text = TRAINING_ENABLE;
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
                DataStorage.setData(DataStorage.TRAINING, oldTraining, DataStorage.ENABLED);
            }

            // Save changes to preferences.xml
            File.WriteAllText(preference, temp);

            // Only could do this once per launch
            trainingRoom.Enabled = false;
        }

        private void replayMode_Click(object sender, EventArgs e)
        {
            gamepathSetting();

            // This is not a quick way of doing it.
            string newData = @"";

            // Check if path is correct
            var preference = DataStorage.getData(DataStorage.PATH);
            if (DataStorage.isGamePathLegal(preference) == true)
            {
                preference += DataStorage.PREFER_XML;
            }

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

            // Launch game launcher >_<
            string gamePath = DataStorage.getData(DataStorage.PATH);
            if (!File.Exists(gamePath + DataStorage.GAME_EXE))
            {
                MessageBox.Show(ERROR_MESSAGE);
            } else
            {
                Process.Start(gamePath + DataStorage.GAME_EXE);
            }
            Application.Exit();
        }

        private void uninstallGameBtn_Click(object sender, EventArgs e)
        {
            gamepathSetting();

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
}