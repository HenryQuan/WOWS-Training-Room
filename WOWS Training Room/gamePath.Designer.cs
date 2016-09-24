namespace WOWS_Training_Room
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gamePath));
            this.gamepathBox = new System.Windows.Forms.TextBox();
            this.checkPathBtn = new System.Windows.Forms.Button();
            this.someLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gamepathBox
            // 
            resources.ApplyResources(this.gamepathBox, "gamepathBox");
            this.gamepathBox.Name = "gamepathBox";
            // 
            // checkPathBtn
            // 
            this.checkPathBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.checkPathBtn, "checkPathBtn");
            this.checkPathBtn.Name = "checkPathBtn";
            this.checkPathBtn.UseVisualStyleBackColor = true;
            this.checkPathBtn.Click += new System.EventHandler(this.checkPathBtn_Click);
            // 
            // someLabel
            // 
            resources.ApplyResources(this.someLabel, "someLabel");
            this.someLabel.Name = "someLabel";
            // 
            // gamePath
            // 
            this.AcceptButton = this.checkPathBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.someLabel);
            this.Controls.Add(this.checkPathBtn);
            this.Controls.Add(this.gamepathBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "gamePath";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gamepathBox;
        private System.Windows.Forms.Button checkPathBtn;
        private System.Windows.Forms.Label someLabel;
    }
}