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
            this.trainingRoom.Location = new System.Drawing.Point(55, 33);
            this.trainingRoom.Name = "trainingRoom";
            this.trainingRoom.Size = new System.Drawing.Size(199, 23);
            this.trainingRoom.TabIndex = 0;
            this.trainingRoom.Text = "Enable Training Room";
            this.trainingRoom.UseVisualStyleBackColor = true;
            this.trainingRoom.Click += new System.EventHandler(this.trainingRoom_Click);
            // 
            // replayMode
            // 
            this.replayMode.Location = new System.Drawing.Point(55, 62);
            this.replayMode.Name = "replayMode";
            this.replayMode.Size = new System.Drawing.Size(199, 23);
            this.replayMode.TabIndex = 1;
            this.replayMode.Text = "Enable Replay Mode";
            this.replayMode.UseVisualStyleBackColor = true;
            this.replayMode.Click += new System.EventHandler(this.replayMode_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(23, 109);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(262, 20);
            this.pathBox.TabIndex = 2;
            this.pathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gameDirectoryLabel
            // 
            this.gameDirectoryLabel.AutoSize = true;
            this.gameDirectoryLabel.Location = new System.Drawing.Point(23, 93);
            this.gameDirectoryLabel.Name = "gameDirectoryLabel";
            this.gameDirectoryLabel.Size = new System.Drawing.Size(78, 13);
            this.gameDirectoryLabel.TabIndex = 3;
            this.gameDirectoryLabel.Text = "Game directory";
            // 
            // launchGameBtn
            // 
            this.launchGameBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.launchGameBtn.Location = new System.Drawing.Point(23, 135);
            this.launchGameBtn.Name = "launchGameBtn";
            this.launchGameBtn.Size = new System.Drawing.Size(110, 23);
            this.launchGameBtn.TabIndex = 4;
            this.launchGameBtn.Text = "Launch Game";
            this.launchGameBtn.UseVisualStyleBackColor = true;
            this.launchGameBtn.Click += new System.EventHandler(this.launchGameBtn_Click);
            // 
            // uninstallGameBtn
            // 
            this.uninstallGameBtn.Location = new System.Drawing.Point(175, 135);
            this.uninstallGameBtn.Name = "uninstallGameBtn";
            this.uninstallGameBtn.Size = new System.Drawing.Size(110, 23);
            this.uninstallGameBtn.TabIndex = 5;
            this.uninstallGameBtn.Text = "Uninstall Game";
            this.uninstallGameBtn.UseVisualStyleBackColor = true;
            this.uninstallGameBtn.Click += new System.EventHandler(this.uninstallGameBtn_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShowShortcutKeys = false;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(309, 24);
            this.mainMenu.TabIndex = 6;
            this.mainMenu.Text = "menuStrip1";
            // 
            // WOWS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 162);
            this.Controls.Add(this.uninstallGameBtn);
            this.Controls.Add(this.launchGameBtn);
            this.Controls.Add(this.gameDirectoryLabel);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.replayMode);
            this.Controls.Add(this.trainingRoom);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WOWS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WOWS Training Room";
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

