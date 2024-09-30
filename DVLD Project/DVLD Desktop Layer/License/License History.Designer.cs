namespace DVLDDesltopFrontLayer.License
{
    partial class License_History
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrL_Driver_Licenses1 = new DVLDDesltopFrontLayer.Controles.CTRL_Driver_Licenses();
            this.ctrlPersonDetails1 = new DVLDDesltopFrontLayer.CTRLPersonDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(526, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 32);
            this.label1.TabIndex = 24;
            this.label1.Text = "License History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDDesltopFrontLayer.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(7, 169);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 284);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.Close_32;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Location = new System.Drawing.Point(1232, 781);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 43);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrL_Driver_Licenses1
            // 
            this.ctrL_Driver_Licenses1.Location = new System.Drawing.Point(7, 487);
            this.ctrL_Driver_Licenses1.Name = "ctrL_Driver_Licenses1";
            this.ctrL_Driver_Licenses1.Size = new System.Drawing.Size(1367, 288);
            this.ctrL_Driver_Licenses1.TabIndex = 25;
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(279, 60);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(1095, 436);
            this.ctrlPersonDetails1.TabIndex = 26;
            // 
            // License_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 855);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Controls.Add(this.ctrL_Driver_Licenses1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Name = "License_History";
            this.Text = "License_History";
            this.Load += new System.EventHandler(this.License_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Controles.CTRL_Driver_Licenses ctrL_Driver_Licenses1;
        private CTRLPersonDetails ctrlPersonDetails1;
    }
}