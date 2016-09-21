using System;
using System.Windows.Forms;
using System.IO;

namespace WOWS_Training_Room
{
    public partial class WOWS : Form
    {
        string gamePath = @"";

        public WOWS()
        {
            InitializeComponent();
        }

        // Get gamepath from anywhere possible
        private void gamepathSetting()
        {
            // Getting the game path from textbox
            gamePath = this.pathBox.Text;
            
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
        }

        private void replayMode_Click(object sender, EventArgs e)
        {
            gamepathSetting();
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
        }

        private void WOWS_FormClosing(object sender, FormClosingEventArgs e)
        {
            gamePath = this.pathBox.Text;

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
    }
}