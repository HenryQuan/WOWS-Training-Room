using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace WOWS_Training_Room
{
    public partial class aboutForm : Form
    {

        const string GITHUB = @"https://github.com/HenryQuan/WOWS-Training-Room/";
        const string ASLAIN = @"http://forum.worldofwarships.com/index.php?/topic/25508-mod05111-aslains-wows-modpack-installer-wpicture-preview-v5111-00-20-09-2016/";

        public aboutForm()
        {
            InitializeComponent();

            someTextLabel.Text = @"If more features are needed, please download and install modpack online. This program is only an alternative way to enable some hidden features. Enjoy playing World of Warships!";
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
            var reply = MessageBox.Show(@"Would you like to uninstall this program?", @"Uninstalling this program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.Yes)
            {
                MessageBox.Show(@"Thank you for using this program ^_^");
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

            // Run a cmd and have 2.5 second delay to delete itself
            var programPath = Process.GetCurrentProcess().MainModule.FileName;
            var info = new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 2500 > Nul & Del \"" + programPath + "\"");
            // The windows is hidden by the way.
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info).Dispose();

            // Close the software.
            Environment.Exit(0);
        }
    }
}
