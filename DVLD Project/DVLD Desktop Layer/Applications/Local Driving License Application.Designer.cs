namespace DVLDDesltopFrontLayer.Applications
{
    partial class Local_Driving_License_Application
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
            this.DGVApplicationList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.txtFiltiringValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBFiltiringBy = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.CBFiltiringByForInternatinal = new System.Windows.Forms.ComboBox();
            this.CBDetainedLicenses = new System.Windows.Forms.ComboBox();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.PBsmallLogo = new System.Windows.Forms.PictureBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.ConMenuShowDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuSechdule = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.StreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuIssueLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuShowApplicationsDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuReleaseDetained = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.PBBiglogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVApplicationList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBsmallLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBiglogo)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVApplicationList
            // 
            this.DGVApplicationList.AllowUserToAddRows = false;
            this.DGVApplicationList.AllowUserToDeleteRows = false;
            this.DGVApplicationList.AllowUserToOrderColumns = true;
            this.DGVApplicationList.BackgroundColor = System.Drawing.Color.White;
            this.DGVApplicationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVApplicationList.ContextMenuStrip = this.contextMenuStrip1;
            this.DGVApplicationList.Location = new System.Drawing.Point(12, 272);
            this.DGVApplicationList.Name = "DGVApplicationList";
            this.DGVApplicationList.ReadOnly = true;
            this.DGVApplicationList.RowHeadersWidth = 51;
            this.DGVApplicationList.RowTemplate.Height = 24;
            this.DGVApplicationList.Size = new System.Drawing.Size(1398, 388);
            this.DGVApplicationList.TabIndex = 12;
            this.DGVApplicationList.Click += new System.EventHandler(this.DGVApplicationList_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConMenuShowDetail,
            this.ConMenuDelete,
            this.ConMenuCancel,
            this.ConMenuSechdule,
            this.ConMenuIssueLicense,
            this.ConMenuShowApplicationsDetails,
            this.ConMenuShowLicense,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.ConMenuReleaseDetained});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(342, 410);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 675);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "#Records:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordCount.Location = new System.Drawing.Point(130, 675);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(40, 22);
            this.lblRecordCount.TabIndex = 16;
            this.lblRecordCount.Text = "???";
            // 
            // txtFiltiringValue
            // 
            this.txtFiltiringValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltiringValue.Location = new System.Drawing.Point(402, 238);
            this.txtFiltiringValue.Name = "txtFiltiringValue";
            this.txtFiltiringValue.Size = new System.Drawing.Size(234, 27);
            this.txtFiltiringValue.TabIndex = 15;
            this.txtFiltiringValue.Visible = false;
            this.txtFiltiringValue.TextChanged += new System.EventHandler(this.txtFiltiringValue_TextChanged);
            this.txtFiltiringValue.VisibleChanged += new System.EventHandler(this.txtFiltiringValue_VisibleChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By";
            // 
            // CBFiltiringBy
            // 
            this.CBFiltiringBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltiringBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiltiringBy.FormattingEnabled = true;
            this.CBFiltiringBy.Items.AddRange(new object[] {
            "L.D.L.AppID",
            "NationalNO",
            "FullName",
            "Status"});
            this.CBFiltiringBy.Location = new System.Drawing.Point(120, 239);
            this.CBFiltiringBy.Name = "CBFiltiringBy";
            this.CBFiltiringBy.Size = new System.Drawing.Size(221, 26);
            this.CBFiltiringBy.TabIndex = 13;
            this.CBFiltiringBy.SelectedIndexChanged += new System.EventHandler(this.CBFiltiringBy_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(478, 156);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(434, 32);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Local Driving License Application";
            // 
            // CBFiltiringByForInternatinal
            // 
            this.CBFiltiringByForInternatinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltiringByForInternatinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFiltiringByForInternatinal.FormattingEnabled = true;
            this.CBFiltiringByForInternatinal.Items.AddRange(new object[] {
            "InternationalLicenseID",
            "ApplicationID",
            "LocalLicenseID",
            "DriverID"});
            this.CBFiltiringByForInternatinal.Location = new System.Drawing.Point(120, 237);
            this.CBFiltiringByForInternatinal.Name = "CBFiltiringByForInternatinal";
            this.CBFiltiringByForInternatinal.Size = new System.Drawing.Size(262, 26);
            this.CBFiltiringByForInternatinal.TabIndex = 21;
            this.CBFiltiringByForInternatinal.Visible = false;
            this.CBFiltiringByForInternatinal.SelectedIndexChanged += new System.EventHandler(this.CBFiltiringByForInternatinal_SelectedIndexChanged);
            // 
            // CBDetainedLicenses
            // 
            this.CBDetainedLicenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDetainedLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBDetainedLicenses.FormattingEnabled = true;
            this.CBDetainedLicenses.Items.AddRange(new object[] {
            "DetainID",
            "IsReleased",
            "NationalNo",
            "FullName",
            "ReleaseApplicationID"});
            this.CBDetainedLicenses.Location = new System.Drawing.Point(120, 238);
            this.CBDetainedLicenses.Name = "CBDetainedLicenses";
            this.CBDetainedLicenses.Size = new System.Drawing.Size(262, 26);
            this.CBDetainedLicenses.TabIndex = 23;
            this.CBDetainedLicenses.Visible = false;
            this.CBDetainedLicenses.SelectedIndexChanged += new System.EventHandler(this.CBDetainedLicenses_SelectedIndexChanged);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.Release_Detained_License_512;
            this.btnReleaseLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReleaseLicense.Location = new System.Drawing.Point(1242, 184);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(73, 82);
            this.btnReleaseLicense.TabIndex = 22;
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            this.btnReleaseLicense.Visible = false;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // PBsmallLogo
            // 
            this.PBsmallLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBsmallLogo.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Local_32;
            this.PBsmallLogo.Location = new System.Drawing.Point(744, 44);
            this.PBsmallLogo.Name = "PBsmallLogo";
            this.PBsmallLogo.Size = new System.Drawing.Size(67, 47);
            this.PBsmallLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBsmallLogo.TabIndex = 20;
            this.PBsmallLogo.TabStop = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.New_Application_64;
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.Location = new System.Drawing.Point(1321, 181);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(73, 82);
            this.btnAddPerson.TabIndex = 19;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click_1);
            // 
            // ConMenuShowDetail
            // 
            this.ConMenuShowDetail.Image = global::DVLDDesltopFrontLayer.Properties.Resources.PersonDetails_32;
            this.ConMenuShowDetail.Name = "ConMenuShowDetail";
            this.ConMenuShowDetail.Size = new System.Drawing.Size(341, 42);
            this.ConMenuShowDetail.Text = "Show Person Details";
            this.ConMenuShowDetail.Click += new System.EventHandler(this.ConMenuShowDetail_Click);
            // 
            // ConMenuDelete
            // 
            this.ConMenuDelete.Image = global::DVLDDesltopFrontLayer.Properties.Resources.AddPerson_32;
            this.ConMenuDelete.Name = "ConMenuDelete";
            this.ConMenuDelete.Size = new System.Drawing.Size(341, 42);
            this.ConMenuDelete.Text = "Delete Application";
            this.ConMenuDelete.Click += new System.EventHandler(this.ConMenuDelete_Click);
            // 
            // ConMenuCancel
            // 
            this.ConMenuCancel.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Delete_32;
            this.ConMenuCancel.Name = "ConMenuCancel";
            this.ConMenuCancel.Size = new System.Drawing.Size(341, 42);
            this.ConMenuCancel.Text = "Cancel Application";
            this.ConMenuCancel.Click += new System.EventHandler(this.deletePersonToolStripMenuItem_Click_1);
            // 
            // ConMenuSechdule
            // 
            this.ConMenuSechdule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechduleVisionTestToolStripMenuItem,
            this.WrittenTest,
            this.StreetTest});
            this.ConMenuSechdule.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Schedule_Test_512;
            this.ConMenuSechdule.Name = "ConMenuSechdule";
            this.ConMenuSechdule.Size = new System.Drawing.Size(341, 42);
            this.ConMenuSechdule.Text = "Sechdule Test";
            // 
            // sechduleVisionTestToolStripMenuItem
            // 
            this.sechduleVisionTestToolStripMenuItem.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Vision_512;
            this.sechduleVisionTestToolStripMenuItem.Name = "sechduleVisionTestToolStripMenuItem";
            this.sechduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(274, 42);
            this.sechduleVisionTestToolStripMenuItem.Text = "Sechdule Vision Test";
            this.sechduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleVisionTestToolStripMenuItem_Click);
            // 
            // WrittenTest
            // 
            this.WrittenTest.Enabled = false;
            this.WrittenTest.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Written_Test_32;
            this.WrittenTest.Name = "WrittenTest";
            this.WrittenTest.Size = new System.Drawing.Size(274, 42);
            this.WrittenTest.Text = "Sechdule Written Test";
            this.WrittenTest.Click += new System.EventHandler(this.WrittenTest_Click);
            // 
            // StreetTest
            // 
            this.StreetTest.Enabled = false;
            this.StreetTest.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Street_Test_32;
            this.StreetTest.Name = "StreetTest";
            this.StreetTest.Size = new System.Drawing.Size(274, 42);
            this.StreetTest.Text = "Sechdule Street Test";
            this.StreetTest.Click += new System.EventHandler(this.StreetTest_Click);
            // 
            // ConMenuIssueLicense
            // 
            this.ConMenuIssueLicense.Enabled = false;
            this.ConMenuIssueLicense.Image = global::DVLDDesltopFrontLayer.Properties.Resources.IssueDrivingLicense_32;
            this.ConMenuIssueLicense.Name = "ConMenuIssueLicense";
            this.ConMenuIssueLicense.Size = new System.Drawing.Size(341, 42);
            this.ConMenuIssueLicense.Text = "Issue Driving License (First time)";
            this.ConMenuIssueLicense.Click += new System.EventHandler(this.phoneCallToolStripMenuItem_Click);
            // 
            // ConMenuShowApplicationsDetails
            // 
            this.ConMenuShowApplicationsDetails.Image = global::DVLDDesltopFrontLayer.Properties.Resources.PersonDetails_32;
            this.ConMenuShowApplicationsDetails.Name = "ConMenuShowApplicationsDetails";
            this.ConMenuShowApplicationsDetails.Size = new System.Drawing.Size(341, 42);
            this.ConMenuShowApplicationsDetails.Text = "Show Applications Details";
            this.ConMenuShowApplicationsDetails.Visible = false;
            this.ConMenuShowApplicationsDetails.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ConMenuShowLicense
            // 
            this.ConMenuShowLicense.Image = global::DVLDDesltopFrontLayer.Properties.Resources.License_View_32;
            this.ConMenuShowLicense.Name = "ConMenuShowLicense";
            this.ConMenuShowLicense.Size = new System.Drawing.Size(341, 42);
            this.ConMenuShowLicense.Text = "Show License";
            this.ConMenuShowLicense.Click += new System.EventHandler(this.ConMenuShowLicense_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLDDesltopFrontLayer.Properties.Resources.PersonLicenseHistory_512;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(341, 42);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // ConMenuReleaseDetained
            // 
            this.ConMenuReleaseDetained.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Release_Detained_License_64;
            this.ConMenuReleaseDetained.Name = "ConMenuReleaseDetained";
            this.ConMenuReleaseDetained.Size = new System.Drawing.Size(341, 42);
            this.ConMenuReleaseDetained.Text = "Release Detained License";
            this.ConMenuReleaseDetained.Visible = false;
            this.ConMenuReleaseDetained.Click += new System.EventHandler(this.ConMenuReleaseDetained_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLDDesltopFrontLayer.Properties.Resources.Close_32;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(1252, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 43);
            this.button1.TabIndex = 18;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PBBiglogo
            // 
            this.PBBiglogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBBiglogo.Image = global::DVLDDesltopFrontLayer.Properties.Resources.Applications;
            this.PBBiglogo.Location = new System.Drawing.Point(578, -1);
            this.PBBiglogo.Name = "PBBiglogo";
            this.PBBiglogo.Size = new System.Drawing.Size(223, 142);
            this.PBBiglogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBBiglogo.TabIndex = 10;
            this.PBBiglogo.TabStop = false;
            // 
            // Local_Driving_License_Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 733);
            this.Controls.Add(this.CBDetainedLicenses);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.CBFiltiringByForInternatinal);
            this.Controls.Add(this.PBsmallLogo);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.DGVApplicationList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.txtFiltiringValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBFiltiringBy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.PBBiglogo);
            this.Name = "Local_Driving_License_Application";
            this.Text = "Local_Driving_License_Application";
            this.Load += new System.EventHandler(this.Local_Driving_License_Application_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVApplicationList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBsmallLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBiglogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.DataGridView DGVApplicationList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ConMenuShowDetail;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem ConMenuCancel;
        private System.Windows.Forms.ToolStripMenuItem ConMenuIssueLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.TextBox txtFiltiringValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBFiltiringBy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox PBBiglogo;
        private System.Windows.Forms.PictureBox PBsmallLogo;
        private System.Windows.Forms.ToolStripMenuItem ConMenuSechdule;
        private System.Windows.Forms.ToolStripMenuItem sechduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WrittenTest;
        private System.Windows.Forms.ToolStripMenuItem StreetTest;
        private System.Windows.Forms.ToolStripMenuItem ConMenuShowLicense;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ComboBox CBFiltiringByForInternatinal;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.ComboBox CBDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem ConMenuReleaseDetained;
        private System.Windows.Forms.ToolStripMenuItem ConMenuShowApplicationsDetails;
    }
}