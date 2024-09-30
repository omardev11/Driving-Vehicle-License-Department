namespace DVLDDesltopFrontLayer.Drivers
{
    partial class List_Drivers
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVpeopleList = new System.Windows.Forms.DataGridView();
            this.CBFiltiringBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltiringValue = new System.Windows.Forms.TextBox();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConMenuShowDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpeopleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 680);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "#Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(528, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Manage Drivers";
            // 
            // DGVpeopleList
            // 
            this.DGVpeopleList.AllowUserToAddRows = false;
            this.DGVpeopleList.AllowUserToDeleteRows = false;
            this.DGVpeopleList.AllowUserToOrderColumns = true;
            this.DGVpeopleList.BackgroundColor = System.Drawing.Color.White;
            this.DGVpeopleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVpeopleList.ContextMenuStrip = this.contextMenuStrip1;
            this.DGVpeopleList.Location = new System.Drawing.Point(-4, 285);
            this.DGVpeopleList.Name = "DGVpeopleList";
            this.DGVpeopleList.ReadOnly = true;
            this.DGVpeopleList.RowHeadersWidth = 51;
            this.DGVpeopleList.RowTemplate.Height = 24;
            this.DGVpeopleList.Size = new System.Drawing.Size(1398, 381);
            this.DGVpeopleList.TabIndex = 12;
            // 
            // CBFiltiringBy
            // 
            this.CBFiltiringBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltiringBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiltiringBy.FormattingEnabled = true;
            this.CBFiltiringBy.Items.AddRange(new object[] {
            "DriverID",
            "PersonID",
            "NationalNO",
            "FullName"});
            this.CBFiltiringBy.Location = new System.Drawing.Point(109, 251);
            this.CBFiltiringBy.Name = "CBFiltiringBy";
            this.CBFiltiringBy.Size = new System.Drawing.Size(221, 28);
            this.CBFiltiringBy.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By";
            // 
            // txtFiltiringValue
            // 
            this.txtFiltiringValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltiringValue.Location = new System.Drawing.Point(360, 251);
            this.txtFiltiringValue.Name = "txtFiltiringValue";
            this.txtFiltiringValue.Size = new System.Drawing.Size(226, 27);
            this.txtFiltiringValue.TabIndex = 15;
            this.txtFiltiringValue.TextChanged += new System.EventHandler(this.txtFiltiringValue_TextChanged);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordCount.Location = new System.Drawing.Point(128, 680);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(40, 22);
            this.lblRecordCount.TabIndex = 16;
            this.lblRecordCount.Text = "???";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.Close_32;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(1251, 672);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 43);
            this.button1.TabIndex = 18;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Driver_Main;
            this.pictureBox1.Location = new System.Drawing.Point(534, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConMenuShowDetail,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(391, 76);
            // 
            // ConMenuShowDetail
            // 
            this.ConMenuShowDetail.Image = global::DVLDDesltopFrontLayer.Properties.Resources.PersonDetails_32;
            this.ConMenuShowDetail.Name = "ConMenuShowDetail";
            this.ConMenuShowDetail.Size = new System.Drawing.Size(390, 36);
            this.ConMenuShowDetail.Text = "Show Person Details";
            this.ConMenuShowDetail.Click += new System.EventHandler(this.ConMenuShowDetail_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLDDesltopFrontLayer.Properties.Resources.PersonLicenseHistory_512;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(390, 36);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // List_Drivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 745);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.txtFiltiringValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBFiltiringBy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DGVpeopleList);
            this.Controls.Add(this.label1);
            this.Name = "List_Drivers";
            this.Text = "List_Drivers";
            this.Load += new System.EventHandler(this.List_Drivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVpeopleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVpeopleList;
        private System.Windows.Forms.ComboBox CBFiltiringBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltiringValue;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ConMenuShowDetail;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}