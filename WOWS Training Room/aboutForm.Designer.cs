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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutForm));
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
            resources.ApplyResources(this.HQBox, "HQBox");
            this.HQBox.Name = "HQBox";
            this.HQBox.TabStop = false;
            this.HQBox.Click += new System.EventHandler(this.HQBox_Click);
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Click += new System.EventHandler(this.titleLabel_Click);
            // 
            // someTextLabel
            // 
            resources.ApplyResources(this.someTextLabel, "someTextLabel");
            this.someTextLabel.Name = "someTextLabel";
            this.someTextLabel.Click += new System.EventHandler(this.someTextLabel_Click);
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            // 
            // uninstallBtn
            // 
            resources.ApplyResources(this.uninstallBtn, "uninstallBtn");
            this.uninstallBtn.Name = "uninstallBtn";
            this.uninstallBtn.UseVisualStyleBackColor = true;
            this.uninstallBtn.Click += new System.EventHandler(this.uninstallBtn_Click);
            // 
            // aboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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