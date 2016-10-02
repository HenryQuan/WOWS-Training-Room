using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using WOWS_Training_Room.Resources;

namespace WOWS_Training_Room
{
    public partial class aboutForm : Form
    {

        const string GITHUB = @"https://github.com/HenryQuan/WOWS-Training-Room/";
        // It is a great mod... I want to do something like this one day
        const string ASLAIN = @"http://aslain.com/index.php?/topic/2020-05111-aslains-wows-modpack-installer-wpicture-preview/";

        public aboutForm()
        {
            InitializeComponent();
            someTextLabel.Text = GlobalText.MORE_FUNCTIONS + "\n" + GlobalText.ENJOY_GAME;
        }

        private void HQBox_Click(object sender, EventArgs e)
        {
            // When user clicks my avator, go to GitHub
            Process.Start(GITHUB);
        }

        private void someTextLabel_Click(object sender, EventArgs e)
        {
            // When user clicks this label, go to the forum which aslain post his amzing mods
            Process.Start(ASLAIN);
        }

        private void uninstallBtn_Click(object sender, EventArgs e)
        {
            // Double check, this can not be un-done
            var reply = MessageBox.Show(GlobalText.UNINSTALL_THIS_PROGRAM_TEXT, GlobalText.UNINSTALL_THIS_PROGRAM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                MessageBox.Show(GlobalText.THX_FOR_USING);
                selfDestruction();
            }
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private static void selfDestruction()
        {
            // Check if data folder is exist
            if(Directory.Exists(WOWS.targetPath))
            {
                // Just delete it, it is the only folder I created.
                DeleteDirectory(WOWS.targetPath);
            }

            // Run a cmd and have 3.456 second delay to delete itself
            var programPath = Process.GetCurrentProcess().MainModule.FileName;
            var info = new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 3456 > Nul & Del \"" + programPath + "\"");
            // The windows is hidden by the way.
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info).Dispose();

            // Close this program
            Application.ExitThread();
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {
            // Open Document Folder
            if (Directory.Exists(DataStorage.targetPath))
            {
                Process.Start(DataStorage.targetPath);
            }
        }
    }
}
