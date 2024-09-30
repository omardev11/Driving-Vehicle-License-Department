namespace DVLDDesltopFrontLayer.License
{
    partial class License_Info
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
            this.lblTopic = new System.Windows.Forms.Label();
            this.PBInternational = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBInternational)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.ForeColor = System.Drawing.Color.Red;
            this.lblTopic.Location = new System.Drawing.Point(531, 141);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(256, 32);
            this.lblTopic.TabIndex = 1;
            this.lblTopic.Text = "Driver License Info ";
            // 
            // PBInternational
            // 
            this.PBInternational.Image = global::DVLDDesltopFrontLayer.Properties.Resources.International_32;
            this.PBInternational.Location = new System.Drawing.Point(522, 3);
            this.PBInternational.Name = "PBInternational";
            this.PBInternational.Size = new System.Drawing.Size(61, 42);
            this.PBInternational.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBInternational.TabIndex = 21;
            this.PBInternational.TabStop = false;
            this.PBInternational.Visible = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.Close_32;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Location = new System.Drawing.Point(1181, 682);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 43);
            this.button2.TabIndex = 20;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDDesltopFrontLayer.Properties.Resources.LicenseView_400;
            this.pictureBox1.Location = new System.Drawing.Point(537, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1311, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // License_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 738);
            this.Controls.Add(this.PBInternational);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTopic);
            this.Controls.Add(this.groupBox1);
            this.Name = "License_Info";
            this.Text = "License_Info";
            this.Load += new System.EventHandler(this.License_Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBInternational)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox PBInternational;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}