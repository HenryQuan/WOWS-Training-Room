using System;
using System.Windows.Forms;
using System.IO;

namespace WOWS_Training_Room
{
    public partial class WOWS : Form
    {
        // Getting Username and Documents path
        string userDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string gamePath = "";

        public WOWS()
        {
            string targetPath = userDocument + @"\WOWSPreferencesEditor";
            string targetFile = targetPath + @"\data.txt";

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

            if (File.ReadAllText(targetFile) == "")
            {
                // 0 means disabled, 1 means enabled.
                string[] lines = { "Path:", "TrainingRoom:0", "ReplayMode:0" };
                File.WriteAllLines(targetFile, lines);
            }

            foreach (string line in File.ReadLines(targetFile))
            {
                if (line.Contains(@"Path:"))
                {
                    gamePath = line.Substring(5);
                    Console.WriteLine(gamePath);
                }
            }

            InitializeComponent();
        }

        // Get gamePath from saved text or from test box
        private void getGamePath()
        {
            gamePath = this.pathBox.Text;
        }

        private void trainingRoom_Click(object sender, EventArgs e)
        {
            string targetPath = userDocument + @"\WOWSPreferencesEditor";
            string targetFile = targetPath + @"\data.txt";
            getGamePath();

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
