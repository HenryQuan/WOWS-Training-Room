using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace WOWS_Training_Room
{
    public partial class WOWS : Form
    {
        const string GAME_EXE = @"\WoWSLauncher.exe";
        const string UNINSTALL_EXE = @"\unins000.exe";
        const string PREFER_XML = @"\preferences.xml";

        const string TRAINING_ENABLE = @"Enable Training Room";
        const string TRAINING_DISABLE = @"Disable Training Room";
        const string REPLAY_ENABLE = @"Enable Replay Mode";
        const string REPLAY_DISABLE = @"Disable Replay Mode";

        const string RANDOM = @"RandomBattle";
        const string COOP = @"CooperationBattle";
        const string TRAINING = @"TrainingBattle";

        const string ERROR_MESSAGE = @"Error! Please enter the correct path.";

        public WOWS()
        {
            InitializeComponent();
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

            // Get the path for preferences.xml
            string preference = DataStorage.getData(DataStorage.PATH) + PREFER_XML;

            if (!File.Exists(preference))
            {
                MessageBox.Show(ERROR_MESSAGE);
            }
            else
            {
                // Not quite a quick mathod, but you do the same way
                string temp = File.ReadAllText(preference);
                if (this.trainingRoom.Text == TRAINING_ENABLE)
                {
                    if (temp.Contains(RANDOM))
                    {
                        temp = temp.Replace(RANDOM, TRAINING);
                    }
                    else if (temp.Contains(COOP))
                    {
                        temp = temp.Replace(COOP, TRAINING);
                    }

                    else
                    {
                        // If it is training room already
                        var reply = MessageBox.Show("Do you want to enable Training Room?", "Oops >_<", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (reply == DialogResult.Yes)
                        {
                            // Then we dont have to do anything
                            this.trainingRoom.Text = TRAINING_ENABLE;
                        }
                        else
                        {
                            // If not, change it back.
                            temp = temp.Replace(TRAINING, RANDOM);
                            this.trainingRoom.Text = TRAINING_DISABLE;
                        }
                    }
                    
                    string oldTraining = DataStorage.getData(DataStorage.TRAINING);
                    DataStorage.setData(DataStorage.TRAINING, oldTraining, DataStorage.ENABLED);
                }
                else
                {
                    // Just change it back to random battle since it does not matter
                    temp = temp.Replace(TRAINING, RANDOM);
                    this.trainingRoom.Text = TRAINING_ENABLE;
                    string oldTraining = DataStorage.getData(DataStorage.TRAINING);
                    DataStorage.setData(DataStorage.TRAINING, oldTraining, DataStorage.DISABLED);
                }

                File.WriteAllText(preference, temp);
            }

            // Only could do this once per launch
            this.trainingRoom.Enabled = false;
        }

        private void replayMode_Click(object sender, EventArgs e)
        {
            gamepathSetting();

            string preference = DataStorage.getData(DataStorage.PATH) + PREFER_XML;
            if (!File.Exists(preference))
            {
                MessageBox.Show(ERROR_MESSAGE);
            }
            else
            {
                XmlDocument data = new XmlDocument();
                data.Load(preference);

            }
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
            if (!File.Exists(gamePath + GAME_EXE))
            {
                MessageBox.Show(ERROR_MESSAGE);
            } else
            {
                Process.Start(gamePath + GAME_EXE);
            }
            Application.Exit();
        }

        private void uninstallGameBtn_Click(object sender, EventArgs e)
        {
            gamepathSetting();

            // WOWS ASIA Worse Server Ever
            string gamePath = DataStorage.getData(DataStorage.PATH);
            if (!File.Exists(gamePath + UNINSTALL_EXE))
            {
                MessageBox.Show(ERROR_MESSAGE);
            }
            else
            {
                MessageBox.Show("WOWS ASIA" + "\n" + "Worst Server Ever!");
                Process.Start(gamePath + UNINSTALL_EXE);
            }
            Application.Exit();
        }
    }
}