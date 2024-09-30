namespace DVLDDesltopFrontLayer.Applications
{
    partial class Local_Driving_License_Application_Info
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
            this.ctrL_D_L_Application1 = new DVLDDesltopFrontLayer.Controles.CTRL_D_L_Application();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrL_D_L_Application1
            // 
            this.ctrL_D_L_Application1.Location = new System.Drawing.Point(12, 12);
            this.ctrL_D_L_Application1.Name = "ctrL_D_L_Application1";
            this.ctrL_D_L_Application1.Size = new System.Drawing.Size(1136, 472);
            this.ctrL_D_L_Application1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.Close_32;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(1006, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 43);
            this.button1.TabIndex = 19;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Local_Driving_License_Application_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 522);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrL_D_L_Application1);
            this.Name = "Local_Driving_License_Application_Info";
            this.Text = "Local_Driving_License_Application_Info";
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.CTRL_D_L_Application ctrL_D_L_Application1;
        private System.Windows.Forms.Button button1;
    }
}