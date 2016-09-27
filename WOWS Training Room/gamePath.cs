using System;
using System.Windows.Forms;

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
                MessageBox.Show(@"This path is not correct.");
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
    }
}
