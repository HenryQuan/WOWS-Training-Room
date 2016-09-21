using System;
using System.Windows.Forms;
using System.IO;

namespace WOWS_Training_Room
{
    public partial class WOWS : Form
    {


        public WOWS()
        { 
            InitializeComponent();
        }

        private void trainingRoom_Click(object sender, EventArgs e)
        {
            string gamePath = DataStorage.getGamePath();

            // Test if it is working properly
            // TODO: crashes when multiclick
            string temp = File.ReadAllText(targetFile);
            Console.WriteLine(temp);

            temp.Replace("path:", "path:" + gamePath);
            Console.WriteLine(temp);

        }

        private void replayMode_Click(object sender, EventArgs e)
        {
            // Get the path of game directory

        }
    }
}
