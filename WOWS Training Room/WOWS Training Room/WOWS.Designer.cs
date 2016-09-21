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
            this.trainingRoom = new System.Windows.Forms.Button();
            this.replayMode = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.gameDirectoryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trainingRoom
            // 
            this.trainingRoom.Location = new System.Drawing.Point(44, 34);
            this.trainingRoom.Name = "trainingRoom";
            this.trainingRoom.Size = new System.Drawing.Size(199, 23);
            this.trainingRoom.TabIndex = 0;
            this.trainingRoom.Text = "Enable Training Room";
            this.trainingRoom.UseVisualStyleBackColor = true;
            this.trainingRoom.Click += new System.EventHandler(this.trainingRoom_Click);
            // 
            // replayMode
            // 
            this.replayMode.Location = new System.Drawing.Point(44, 63);
            this.replayMode.Name = "replayMode";
            this.replayMode.Size = new System.Drawing.Size(199, 23);
            this.replayMode.TabIndex = 1;
            this.replayMode.Text = "Enable Replay Mode";
            this.replayMode.UseVisualStyleBackColor = true;
            this.replayMode.Click += new System.EventHandler(this.replayMode_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 109);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(262, 20);
            this.pathBox.TabIndex = 2;
            // 
            // gameDirectoryLabel
            // 
            this.gameDirectoryLabel.AutoSize = true;
            this.gameDirectoryLabel.Location = new System.Drawing.Point(12, 93);
            this.gameDirectoryLabel.Name = "gameDirectoryLabel";
            this.gameDirectoryLabel.Size = new System.Drawing.Size(78, 13);
            this.gameDirectoryLabel.TabIndex = 3;
            this.gameDirectoryLabel.Text = "Game directory";
            // 
            // WOWS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 162);
            this.Controls.Add(this.gameDirectoryLabel);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.replayMode);
            this.Controls.Add(this.trainingRoom);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WOWS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WOWS Training Room";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WOWS_FormClosing);
            this.Load += new System.EventHandler(this.WOWS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button trainingRoom;
        private System.Windows.Forms.Button replayMode;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label gameDirectoryLabel;
    }
}

