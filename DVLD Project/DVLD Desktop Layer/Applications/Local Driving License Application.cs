using DVLDBusinessLayer;
using DVLDDesltopFrontLayer.Controles;
using DVLDDesltopFrontLayer.License;
using DVLDDesltopFrontLayer.Properties;
using DVLDDesltopFrontLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.Applications
{
    public partial class Local_Driving_License_Application : Form
    {
        private bool _isInternationalApplications = false;
        private bool _IsDetainedApplications = false;

        public Local_Driving_License_Application(bool IsInternatinalApplicatins, bool IsDetainedApplications)
        {
            InitializeComponent();
            _isInternationalApplications = IsInternatinalApplicatins;
            _IsDetainedApplications = IsDetainedApplications;
        }
        private void _RefreshApplicationList()
        {

            DGVApplicationList.DataSource = clsDVLDBusinessLocalApplication.GetAllLocalDrivingLicenseApplications_View();
            if (DGVApplicationList.RowCount > 0)
            {
                DGVApplicationList.Columns["FullName"].Width = 200;
                DGVApplicationList.Columns["ClassName"].Width = 200;
            }

            lblRecordCount.Text = DGVApplicationList.RowCount.ToString();


        }
        private void _RefreshIntterNatinalApplicationList()
        {
            DGVApplicationList.DataSource = clsDVLDBusinessInternationalLicense.GetAllInternationalLicenseApplications();
            if (DGVApplicationList.RowCount > 0)
            {
                DGVApplicationList.Columns["InternationalLicenseID"].Width = 200;
                DGVApplicationList.Columns["IssueDate"].Width = 150;
                DGVApplicationList.Columns["ExpirationDate"].Width = 150;
            }


            lblRecordCount.Text = DGVApplicationList.RowCount.ToString();




        }

        private void _RefreshDetainLicenseApplicationList()
        {
            DGVApplicationList.DataSource = clsDVLDBusinessDetainedLicenses.GetAllDetainedLicenses();
            if (DGVApplicationList.RowCount > 0)
            {
                DGVApplicationList.Columns["FullName"].Width = 200;
                //DGVApplicationList.Columns["ClassName"].Width = 200;
            }

            lblRecordCount.Text = DGVApplicationList.RowCount.ToString();


        }


        private void _RefreshApplicationListBy(string Columntype, string valuetype)
        {

            DGVApplicationList.DataSource = clsDVLDBusinessLocalApplication.GetAllLocalDrivingLicenseApplicationBy(Columntype, valuetype);
            if (DGVApplicationList.RowCount > 0)
            {
                DGVApplicationList.Columns["FullName"].Width = 200;
                DGVApplicationList.Columns["ClassName"].Width = 200;
            }

            lblRecordCount.Text = DGVApplicationList.RowCount.ToString();

        }
        private void _RefreshInternationalApplicationListBy(string Columntype, string valuetype)
        {

            DGVApplicationList.DataSource = clsDVLDBusinessInternationalLicense.GetAllInternationalLicenseApplicationsBy(Columntype, valuetype);
            if (DGVApplicationList.RowCount > 0)
            {
                DGVApplicationList.Columns["InternationalLicenseID"].Width = 200;
                DGVApplicationList.Columns["IssueDate"].Width = 150;
                DGVApplicationList.Columns["ExpirationDate"].Width = 150;
            }

            lblRecordCount.Text = DGVApplicationList.RowCount.ToString();

        }

        private void _RefreshDetainLicenseApplicationListBy<T>(string Columntype, T valuetype)
        {

            DGVApplicationList.DataSource = clsDVLDBusinessDetainedLicenses.GetAllDetainDrivingLicenseApplicationBy(Columntype, valuetype);
            if (DGVApplicationList.RowCount > 0)
            {
                DGVApplicationList.Columns["FullName"].Width = 200;
                //DGVApplicationList.Columns["ClassName"].Width = 200;
            }

            lblRecordCount.Text = DGVApplicationList.RowCount.ToString();

        }


        private void Local_Driving_License_Application_Load(object sender, EventArgs e)
        {
           
            if (_IsDetainedApplications)
            {
                _RefreshDetainLicenseApplicationList();
                CBFiltiringBy.Visible = false;
                CBFiltiringByForInternatinal.Visible = false;
                CBDetainedLicenses.Visible = true;

                ConMenuDelete.Visible = false;
                ConMenuCancel.Visible = false;
                ConMenuSechdule.Visible = false;
                ConMenuIssueLicense.Visible = false;

                ConMenuShowLicense.Visible = true;

                PBsmallLogo.Visible = false;

                PBBiglogo.Image = Resources.Detain_512;


                lblTitle.Text = "List Detained Licenses";
                this.Text = "List Detained Licenses";

                btnReleaseLicense.Visible = true;

                btnAddPerson.BackgroundImage = null;
                btnAddPerson.Image = Resources.Detain_64;
                
            }
            else
            {
                if (_isInternationalApplications)
                {
                    _RefreshIntterNatinalApplicationList();
                    CBFiltiringBy.Visible = false;
                    CBFiltiringByForInternatinal.Visible = true;

                    ConMenuDelete.Visible = false;
                    ConMenuCancel.Visible = false;
                    ConMenuSechdule.Visible = false;
                    ConMenuIssueLicense.Visible = false;

                    ConMenuShowLicense.Visible = true;

                    PBsmallLogo.Image = Resources.International_32;

                    lblTitle.Text = "International License Application";
                    this.Text = "List International License Applications";
                }
                else 
                {
                    CBFiltiringBy.Visible = true;
                    CBFiltiringByForInternatinal.Visible = false;

                    ConMenuDelete.Visible = true;
                    ConMenuCancel.Visible = true;
                    ConMenuSechdule.Visible = true;

                    _RefreshApplicationList();
                    ConMenuShowApplicationsDetails.Visible = true;
                }
            }
        }

        private void btnAddPerson_Click_1(object sender, EventArgs e)
        {
           
            if (_IsDetainedApplications)
            {
                New_International_License_Application new_International_License_Application = new New_International_License_Application(Global_Settings.DetainLicenseApplicationTypeID);

                new_International_License_Application.ShowDialog();
                _RefreshDetainLicenseApplicationList();
            }
            else
            {
                if (_isInternationalApplications)
                {
                    New_International_License_Application new_International_License_Application = new New_International_License_Application(Global_Settings.NewInternationalLicense);

                    new_International_License_Application.ShowDialog();

                    _RefreshIntterNatinalApplicationList();
                }
                else 
                {
                    New_Local_Driving_License_Application new_Local_Driving_License_ = new New_Local_Driving_License_Application();

                    new_Local_Driving_License_.ShowDialog();

                    _RefreshApplicationList();
                }
            }

        }

        private void txtFiltiringValue_TextChanged(object sender, EventArgs e)
        {
           
            if (_IsDetainedApplications)
            {
                _RefreshDetainLicenseApplicationListBy(CBDetainedLicenses.Text, txtFiltiringValue.Text);
            }
            else
            {
                if (_isInternationalApplications)
                {
                    if (CBFiltiringByForInternatinal.Text == "LocalLicenseID")
                    {
                        _RefreshInternationalApplicationListBy("IssuedUsingLocalLicenseID", txtFiltiringValue.Text);
                    }
                    else
                    {
                        _RefreshInternationalApplicationListBy(CBFiltiringByForInternatinal.Text, txtFiltiringValue.Text);
                    }
                }
                else if (!_isInternationalApplications)
                {
                    if (CBFiltiringBy.Text == "L.D.L.AppID")
                    {
                        _RefreshApplicationListBy("LocalDrivingLicenseApplicationID", txtFiltiringValue.Text);
                    }
                    else
                    {
                        _RefreshApplicationListBy(CBFiltiringBy.Text, txtFiltiringValue.Text);
                    }
                }

            }
        }

        private void CBFiltiringBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltiringValue.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deletePersonToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Cancel this Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDVLDBusinessLocalApplication.CancelOrUpdateApplication((int)DGVApplicationList.CurrentRow.Cells[7].Value, 2))
                {
                    MessageBox.Show("Application Canceled Sucesfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Application did not Canceled Sucesfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _RefreshApplicationList();
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vision_Test_Appiments vision_Test_Appiments = new Vision_Test_Appiments((int)DGVApplicationList.CurrentRow.Cells[0].Value, 1);

            vision_Test_Appiments.ShowDialog();

            _RefreshApplicationList();
        }


        private void WrittenTest_Click(object sender, EventArgs e)
        {

            Vision_Test_Appiments vision_Test_Appiments = new Vision_Test_Appiments((int)DGVApplicationList.CurrentRow.Cells[0].Value, 2);

            vision_Test_Appiments.ShowDialog();
            _RefreshApplicationList();
        }

        private void StreetTest_Click(object sender, EventArgs e)
        {
            Vision_Test_Appiments vision_Test_Appiments = new Vision_Test_Appiments((int)DGVApplicationList.CurrentRow.Cells[0].Value, 3);

            vision_Test_Appiments.ShowDialog();
            _RefreshApplicationList();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DlappID = (int)DGVApplicationList.CurrentRow.Cells[0].Value;
            Issue_Driving_License_For_The_First_Time issue_Driving_License_For_The_First_Time = new Issue_Driving_License_For_The_First_Time(DlappID);

            issue_Driving_License_For_The_First_Time.ShowDialog();
            _RefreshApplicationList();
        }

        private void DGVApplicationList_Click(object sender, EventArgs e)
        {
          
            if (_IsDetainedApplications)
            {
                ConMenuReleaseDetained.Visible = true;
                ConMenuReleaseDetained.Enabled = false;
                if (clsDVLDBusinessDetainedLicenses.IsThisLicenseDetained((int)DGVApplicationList.CurrentRow.Cells[1].Value))
                {
                    ConMenuReleaseDetained.Enabled = true;
                }
                else
                {
                    ConMenuReleaseDetained.Enabled = false;
                }

            }
            else
            {
                if (_isInternationalApplications)
                {
                    return;
                }
                else
                {
                    bool isHasLicense = clsDVLDBusinessLicense.IsThisApplicationHasLicense((int)DGVApplicationList.CurrentRow.Cells[7].Value);
                    if (isHasLicense)
                    {
                        ConMenuDelete.Enabled = false;
                        ConMenuCancel.Enabled = false;
                        ConMenuSechdule.Enabled = false;
                        ConMenuIssueLicense.Enabled = false;
                        ConMenuShowLicense.Enabled = true;
                    }
                    else
                    {
                        ConMenuDelete.Enabled = true;
                        ConMenuCancel.Enabled = true;
                        ConMenuSechdule.Enabled = true;
                        ConMenuShowLicense.Enabled = false;
                    }



                    int passedTestCount = (int)DGVApplicationList.CurrentRow.Cells[5].Value;
                    if (passedTestCount == 1)
                    {
                        sechduleVisionTestToolStripMenuItem.Enabled = false;
                        WrittenTest.Enabled = true;
                        StreetTest.Enabled = false;
                        ConMenuIssueLicense.Enabled = false;
                    }
                    else if (passedTestCount == 2)
                    {
                        sechduleVisionTestToolStripMenuItem.Enabled = false;
                        WrittenTest.Enabled = false;
                        StreetTest.Enabled = true;
                        ConMenuIssueLicense.Enabled = false;
                    }
                    else if (passedTestCount == 3 && !isHasLicense)
                    {

                        ConMenuSechdule.Enabled = false;
                        ConMenuIssueLicense.Enabled = true;
                    }
                    else if (passedTestCount == 3 && isHasLicense)
                    {
                        ConMenuSechdule.Enabled = false;
                        ConMenuIssueLicense.Enabled = false;
                    }
                    else
                    {
                        sechduleVisionTestToolStripMenuItem.Enabled = true;
                        ConMenuIssueLicense.Enabled = false;
                    }
                }

            }

        }

        private void ConMenuShowLicense_Click(object sender, EventArgs e)
        {
            if (_IsDetainedApplications)
            {
                int ApplicationID = clsDVLDBusinessLicense.GetLicenseInfoByID((int)DGVApplicationList.CurrentRow.Cells[1].Value)._ApplicationID;

                License_Info license_Info = new License_Info(ApplicationID, false);

                license_Info.ShowDialog();
            }
            else
            {
                if (_isInternationalApplications)
                {
                    License_Info license_Info = new License_Info((int)DGVApplicationList.CurrentRow.Cells[1].Value, true);

                    license_Info.ShowDialog();
                }
                else if (!_isInternationalApplications)
                {
                    License_Info license_Info = new License_Info((int)DGVApplicationList.CurrentRow.Cells[7].Value, false);

                    license_Info.ShowDialog();
                }
            }
           



        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_IsDetainedApplications)
            {
                int ApplicationID = clsDVLDBusinessLicense.GetLicenseInfoByID((int)DGVApplicationList.CurrentRow.Cells[1].Value)._ApplicationID;

                License_History license_History = new License_History(ApplicationID);

                license_History.ShowDialog();
            }
            else
            {
                if (_isInternationalApplications)
                {
                    License_History license_History = new License_History((int)DGVApplicationList.CurrentRow.Cells[1].Value);

                    license_History.ShowDialog();
                }
                else
                {
                    License_History license_History = new License_History((int)DGVApplicationList.CurrentRow.Cells[7].Value);

                    license_History.ShowDialog();
                }
            }
         
           
        }

        private void ConMenuDelete_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)DGVApplicationList.CurrentRow.Cells[7].Value;
            if (MessageBox.Show("Are You Sure You Want To Delete this Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDVLDBusinessLocalApplication.DeleteLocalDrivingLicenseAndApplication(ApplicationID))
                {
                    MessageBox.Show("Application Deleted Sucesfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Application did not Deleted Sucesfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _RefreshApplicationList();
        }

        private void CBFiltiringByForInternatinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltiringValue.Visible = true;
        }

        private void ConMenuShowDetail_Click(object sender, EventArgs e)
        {
          

            if (_IsDetainedApplications)
            {
                int PerssonID = clsDVLDBusinessLocalApplication.FindApplicationByID((int)DGVApplicationList.CurrentRow.Cells[8].Value)._ApplicationsinFo._ApplicationPersonID;
                Person_Details person_Details = new Person_Details(PerssonID);

                person_Details.ShowDialog();
            }
            else
            {
                if (_isInternationalApplications)
                {
                    int PerssonID = clsDVLDBusinessLocalApplication.FindApplicationByID((int)DGVApplicationList.CurrentRow.Cells[1].Value)._ApplicationsinFo._ApplicationPersonID;
                    Person_Details person_Details = new Person_Details(PerssonID);

                    person_Details.ShowDialog();

                }
                else if (!_isInternationalApplications)
                {
                    int PerssonID = clsDVLDBusinessLocalApplication.FindApplicationByID((int)DGVApplicationList.CurrentRow.Cells[7].Value)._ApplicationsinFo._ApplicationPersonID;
                    Person_Details person_Details = new Person_Details(PerssonID);

                    person_Details.ShowDialog();
                }
            }
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_Application = new New_International_License_Application(Global_Settings.ReleaseDetainedDrivingLicsense);

            new_International_License_Application.ShowDialog();
            _RefreshDetainLicenseApplicationList();
        }

        private void ConMenuReleaseDetained_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_Application = new New_International_License_Application(Global_Settings.ReleaseDetainedDrivingLicsense,
                                                                                                               (int)DGVApplicationList.CurrentRow.Cells[1].Value);

            new_International_License_Application.ShowDialog();
            _RefreshDetainLicenseApplicationList();
        }

        private void CBDetainedLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltiringValue.Visible = true;
            
        }

        private void txtFiltiringValue_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Application_Info Info = new Local_Driving_License_Application_Info((int)DGVApplicationList.CurrentRow.Cells[0].Value);

            Info.ShowDialog();


        }
    }
}
