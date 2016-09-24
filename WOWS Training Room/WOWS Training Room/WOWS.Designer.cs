namespace WOWS_Training_Room
{
    partial class WOWS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WOWS));
            this.trainingRoom = new System.Windows.Forms.Button();
            this.replayMode = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.gameDirectoryLabel = new System.Windows.Forms.Label();
            this.launchGameBtn = new System.Windows.Forms.Button();
            this.uninstallGameBtn = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trainingRoom
            // 
            resources.ApplyResources(this.trainingRoom, "trainingRoom");
            this.trainingRoom.Name = "trainingRoom";
            this.trainingRoom.UseVisualStyleBackColor = true;
            this.trainingRoom.Click += new System.EventHandler(this.trainingRoom_Click);
            // 
            // replayMode
            // 
            resources.ApplyResources(this.replayMode, "replayMode");
            this.replayMode.Name = "replayMode";
            this.replayMode.UseVisualStyleBackColor = true;
            this.replayMode.Click += new System.EventHandler(this.replayMode_Click);
            // 
            // pathBox
            // 
            resources.ApplyResources(this.pathBox, "pathBox");
            this.pathBox.Name = "pathBox";
            // 
            // gameDirectoryLabel
            // 
            resources.ApplyResources(this.gameDirectoryLabel, "gameDirectoryLabel");
            this.gameDirectoryLabel.Name = "gameDirectoryLabel";
            // 
            // launchGameBtn
            // 
            this.launchGameBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.launchGameBtn, "launchGameBtn");
            this.launchGameBtn.Name = "launchGameBtn";
            this.launchGameBtn.UseVisualStyleBackColor = true;
            this.launchGameBtn.Click += new System.EventHandler(this.launchGameBtn_Click);
            // 
            // uninstallGameBtn
            // 
            resources.ApplyResources(this.uninstallGameBtn, "uninstallGameBtn");
            this.uninstallGameBtn.Name = "uninstallGameBtn";
            this.uninstallGameBtn.UseVisualStyleBackColor = true;
            this.uninstallGameBtn.Click += new System.EventHandler(this.uninstallGameBtn_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Name = "mainMenu";
            // 
            // WOWS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uninstallGameBtn);
            this.Controls.Add(this.launchGameBtn);
            this.Controls.Add(this.gameDirectoryLabel);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.replayMode);
            this.Controls.Add(this.trainingRoom);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "WOWS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WOWS_FormClosing);
            this.Load += new System.EventHandler(this.WOWS_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button trainingRoom;
        private System.Windows.Forms.Button replayMode;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label gameDirectoryLabel;
        private System.Windows.Forms.Button launchGameBtn;
        private System.Windows.Forms.Button uninstallGameBtn;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
    }
}

