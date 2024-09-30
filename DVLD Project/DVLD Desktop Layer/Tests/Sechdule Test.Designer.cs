namespace DVLDDesltopFrontLayer.Tests
{
    partial class Sechdule_Test
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrL_Vision_Test1 = new DVLDDesltopFrontLayer.Controles.CTRL_Vision_Test();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Close_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(261, 877);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 41);
            this.btnSave.TabIndex = 146;
            this.btnSave.Text = "Close";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrL_Vision_Test1
            // 
            this.ctrL_Vision_Test1.Location = new System.Drawing.Point(2, 0);
            this.ctrL_Vision_Test1.Name = "ctrL_Vision_Test1";
            this.ctrL_Vision_Test1.Size = new System.Drawing.Size(650, 871);
            this.ctrL_Vision_Test1.TabIndex = 147;
            this.ctrL_Vision_Test1.TestTypeID = DVLDBusinessLayer.clsDVLDBusinessTestTypes.enTestType.VisionTest;
            // 
            // Sechdule_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 965);
            this.Controls.Add(this.ctrL_Vision_Test1);
            this.Controls.Add(this.btnSave);
            this.Name = "Sechdule_Test";
            this.Text = "Sechdule_Test";
            this.Load += new System.EventHandler(this.Sechdule_Test_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private Controles.CTRL_Vision_Test ctrL_Vision_Test1;
    }
}