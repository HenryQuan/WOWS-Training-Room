using System;
using System.Windows.Forms;
using WOWS_Training_Room.Resources;

namespace WOWS_Training_Room
{
    public partial class gamePath : Form
    {
        public gamePath()
        {
            InitializeComponent();
        }

        private void checkPathBtn_Click(object sender, EventArgs e)
        {
            if (DataStorage.isGamePathLegal(gamepathBox.Text))
            {
                // Save it and load our main program
                string oldPath = DataStorage.getData(DataStorage.PATH);

                // If user has changed the path, new address will be saved
                DataStorage.setData(DataStorage.PATH, oldPath, gamepathBox.Text);

                Close();
            } 
            else
            {
                MessageBox.Show(GlobalText.PATH_NOT_CORRECT);
            }
        }

        private void loadPathBtn_Click(object sender, EventArgs e)
        {
            // A better way of getting path if user prefers
            FolderBrowserDialog gamePathLoader = new FolderBrowserDialog();
            if (gamePathLoader.ShowDialog() == DialogResult.OK)
            {
                this.gamepathBox.Text = gamePathLoader.SelectedPath;
            }
        }

        private void gamePath_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close this program if user does not want to use it
            if (!DataStorage.isGamePathLegal(gamepathBox.Text))
            {
                Application.ExitThread();
            }
        }
    }
}
