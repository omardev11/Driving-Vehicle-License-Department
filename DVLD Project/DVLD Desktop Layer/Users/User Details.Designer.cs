namespace DVLDDesltopFrontLayer.Users
{
    partial class User_Details
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
            this.GBpersonInfo = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GBpersonInfo
            // 
            this.GBpersonInfo.Location = new System.Drawing.Point(2, 3);
            this.GBpersonInfo.Name = "GBpersonInfo";
            this.GBpersonInfo.Size = new System.Drawing.Size(1119, 569);
            this.GBpersonInfo.TabIndex = 0;
            this.GBpersonInfo.TabStop = false;
            this.GBpersonInfo.Text = "Person Info";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Location = new System.Drawing.Point(979, 578);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 43);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // User_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 643);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.GBpersonInfo);
            this.Name = "User_Details";
            this.Text = "User_Details";
            this.Load += new System.EventHandler(this.User_Details_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBpersonInfo;
        private System.Windows.Forms.Button btnClose;
    }
}