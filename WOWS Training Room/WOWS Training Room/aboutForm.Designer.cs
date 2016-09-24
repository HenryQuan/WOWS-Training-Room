namespace WOWS_Training_Room
{
    partial class aboutForm
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
            this.HQBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.someTextLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.uninstallBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HQBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HQBox
            // 
            this.HQBox.Image = global::WOWS_Training_Room.Properties.Resources.HenryQuan;
            this.HQBox.Location = new System.Drawing.Point(15, 12);
            this.HQBox.Name = "HQBox";
            this.HQBox.Size = new System.Drawing.Size(65, 65);
            this.HQBox.TabIndex = 0;
            this.HQBox.TabStop = false;
            this.HQBox.Click += new System.EventHandler(this.HQBox_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(94, 21);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(203, 24);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "WOWS Training Room";
            // 
            // someTextLabel
            // 
            this.someTextLabel.Location = new System.Drawing.Point(12, 84);
            this.someTextLabel.Name = "someTextLabel";
            this.someTextLabel.Size = new System.Drawing.Size(285, 73);
            this.someTextLabel.TabIndex = 2;
            this.someTextLabel.Text = "balala";
            this.someTextLabel.Click += new System.EventHandler(this.someTextLabel_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(158, 54);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(59, 13);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "version 1.0";
            // 
            // uninstallBtn
            // 
            this.uninstallBtn.Location = new System.Drawing.Point(222, 127);
            this.uninstallBtn.Name = "uninstallBtn";
            this.uninstallBtn.Size = new System.Drawing.Size(75, 23);
            this.uninstallBtn.TabIndex = 4;
            this.uninstallBtn.Text = "Uninstall";
            this.uninstallBtn.UseVisualStyleBackColor = true;
            this.uninstallBtn.Click += new System.EventHandler(this.uninstallBtn_Click);
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 162);
            this.Controls.Add(this.uninstallBtn);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.someTextLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.HQBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "aboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.HQBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox HQBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label someTextLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button uninstallBtn;
    }
}