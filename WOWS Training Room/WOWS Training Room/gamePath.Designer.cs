﻿namespace WOWS_Training_Room
{
    partial class gamePath
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
            this.gamepathBox = new System.Windows.Forms.TextBox();
            this.checkPathBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gamepathBox
            // 
            this.gamepathBox.Location = new System.Drawing.Point(11, 12);
            this.gamepathBox.Name = "gamepathBox";
            this.gamepathBox.Size = new System.Drawing.Size(264, 20);
            this.gamepathBox.TabIndex = 0;
            // 
            // checkPathBtn
            // 
            this.checkPathBtn.Location = new System.Drawing.Point(106, 38);
            this.checkPathBtn.Name = "checkPathBtn";
            this.checkPathBtn.Size = new System.Drawing.Size(75, 23);
            this.checkPathBtn.TabIndex = 1;
            this.checkPathBtn.Text = "Check";
            this.checkPathBtn.UseVisualStyleBackColor = true;
            this.checkPathBtn.Click += new System.EventHandler(this.checkPathBtn_Click);
            // 
            // gamePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 65);
            this.ControlBox = false;
            this.Controls.Add(this.checkPathBtn);
            this.Controls.Add(this.gamepathBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "gamePath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please paste your game path in the texbox below";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gamepathBox;
        private System.Windows.Forms.Button checkPathBtn;
    }
}