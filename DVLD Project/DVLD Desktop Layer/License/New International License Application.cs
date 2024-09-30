using DVLDBusinessLayer;
using DVLDDesltopFrontLayer.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.License
{
    public partial class New_International_License_Application : Form
    {
        private bool _IsThisLicenseHasAnActiveInternatinalLicense = false;

        private int _LicenseID = -1;
        private decimal _PaidFees = 0;
        private int _ApplicantPersonID = -1;
        private int _ApplicationID = -1;

        private int _InternationalApplicantID = -1;
        private int _InternatinalLicenseID = -1;

        public int _ApplicantionTypeID = 0;

        private int _RenewNewLiceseID = -1;
        private int _RenewNewApplicationID = -1;
        public New_International_License_Application(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicantionTypeID = ApplicationTypeID;
            if (ApplicationTypeID == Global_Settings.RenewDrivingLicenseService)
            {
                lblTitle.Text = "Renew License Application";
                this.Text = "Renew Local Driving License Application";
                btnIssue.Text = "Renew";
                btnIssue.Image = Image.FromFile("E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Renew Driving License 32.png");
            }

            if (ApplicationTypeID == Global_Settings.ReplacementforaDamagedDrivingLicense)
            {
                RdbDamagedLicense.Checked = true;
                _IsDamagedOrLostApplication();
                GBDamageOrLost.Visible = true;
                GBDamageOrLost.Enabled = false;
                GBApplicationInfo.Text = "";
            }
            if (ApplicationTypeID == Global_Settings.ReplacementforaLostDrivingLicense)
            {
                rdbLostLicense.Checked = true;
                _IsDamagedOrLostApplication();
                GBDamageOrLost.Visible = true;
                GBDamageOrLost.Enabled = false;
                GBApplicationInfo.Text = "";
            }
            if (_ApplicantionTypeID == Global_Settings.DetainLicenseApplicationTypeID)
            {
                GBApplicationInfo.Text = "Detain Info";
                lblTitle.Text = "Detain License ";
                this.Text = "Detain License";
                btnIssue.Text = "Detain";
                btnIssue.Image = Image.FromFile("E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\International 32.png");
            }
            if (_ApplicantionTypeID == Global_Settings.ReleaseDetainedDrivingLicsense)
            {
                GBApplicationInfo.Text = "Detain Info";
                lblTitle.Text = "Release Detain License ";
                this.Text = "Release Detain License";
                btnIssue.Text = "Release";
                btnIssue.Image = Image.FromFile("E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Release Detained License 32.png");
            }
        }

        public New_International_License_Application(int ApplicationTypeID,int LicensID)
        {
            InitializeComponent();
            _ApplicantionTypeID = ApplicationTypeID;
         
            if (_ApplicantionTypeID == Global_Settings.ReleaseDetainedDrivingLicsense)
            {
                GBApplicationInfo.Text = "Detain Info";
                lblTitle.Text = "Release Detain License ";
                this.Text = "Release Detain License";
                btnIssue.Text = "Release";
                btnIssue.Image = Image.FromFile("E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Release Detained License 32.png");
            }
            _LicenseID = LicensID;

            _LoadDataWhithLicenseID();
            GBFilter.Enabled = false;
        }

        private void _IsDamagedOrLostApplication()
        {
            CTRL_DamagedOrLost_License_Info CTRL_DamagedOrLost_License_Info = new CTRL_DamagedOrLost_License_Info(_LicenseID, rdbLostLicense.Checked);
            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CTRL_DamagedOrLost_License_Info);
            
            if (rdbLostLicense.Checked)
            {
                lblTitle.Text = "Replacement For Lost Driving Licenses";
                this.Text = "Replacement For Lost Licenses";
                btnIssue.Text = "Issue Replacement";
                btnIssue.Image = Image.FromFile("E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Renew Driving License 32.png");
            }
            else
            {
                lblTitle.Text = "Replacement For Damaged Driving Licenses";
                this.Text = "Replacement For Damaged Licenses";
                btnIssue.Text = "Issue Replacement";
                btnIssue.Image = Image.FromFile("E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Renew Driving License 32.png");
            }
        }

        private void _LoadRenewScreenData()
        {

            CTRL_Renew_Application_Info cTRL_Renew_Application_ = new CTRL_Renew_Application_Info();

            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(cTRL_Renew_Application_);
            label7.Visible = true;
            pictureBox7.Visible = true;
            txtNote.Visible = true;

        }
        private void _LoadReplacemtOrLostScreenData()
        {

            CTRL_DamagedOrLost_License_Info CTRL_DamagedOrLost_License_Info = new CTRL_DamagedOrLost_License_Info();

            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CTRL_DamagedOrLost_License_Info);


        }
        private void _LoadDetainLicenseScreenData()
        {
            CRTL_Detain_License_Info CRTL_Detain_License_Info = new CRTL_Detain_License_Info();
            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CRTL_Detain_License_Info);
        }
        private void _LoadReleaseDetainLicenseScreenData()
        {
            CTRL_Release_Detained_Info CTRL_Release_Detained_Info = new CTRL_Release_Detained_Info();
            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CTRL_Release_Detained_Info);
        }


        

        private void _LoadData()
        {
            if (_LicenseID == -1)
            {
                CTRL_Driver_License_Info cTRL_Driver_License_Info = new CTRL_Driver_License_Info();
                GBLicenseInfo.Controls.Clear();
                GBLicenseInfo.Controls.Add(cTRL_Driver_License_Info);
            }
           

            if (_ApplicantionTypeID == Global_Settings.NewInternationalLicense)
            {
            }
            if (_ApplicantionTypeID == Global_Settings.RenewDrivingLicenseService)
            {
                _LoadRenewScreenData();
            }
            if (_ApplicantionTypeID == Global_Settings.ReplacementforaDamagedDrivingLicense || _ApplicantionTypeID == Global_Settings.ReplacementforaLostDrivingLicense)
            {
                _LoadReplacemtOrLostScreenData();
            }
            if (_ApplicantionTypeID == Global_Settings.DetainLicenseApplicationTypeID)
            {
                _LoadDetainLicenseScreenData();
            }
            if (_LicenseID == -1)
            {
                if (_ApplicantionTypeID == Global_Settings.ReleaseDetainedDrivingLicsense)
                {
                    _LoadReleaseDetainLicenseScreenData();
                }
            }
           




        }


        private void _LoadDataWhithLicenseIDByInternationalLicense()
        {
            if (_CheckIfLicenseIsActive())
            {
                clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID);
                clsDVLDBusinessLicenseClasses LicenseClassInfo = clsDVLDBusinessLicenseClasses.GetLicenseClassByID(3);

                if (LicenseInfo.LicenseClassIfo._LicenseClassID != LicenseClassInfo._LicenseClassID)
                {
                    MessageBox.Show("Selected Should be Calss 3 Select Another One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GBFilter.Enabled = false;
                    btnIssue.Enabled = false;
                    return;
                }


                CTRL_international_Application_Info cTRL_International_Application_ = new CTRL_international_Application_Info(_LicenseID);
                GBApplicationInfo.Controls.Clear();
                GBApplicationInfo.Controls.Add(cTRL_International_Application_);


            }
            else
            {
                MessageBox.Show("This License is Not Active or The License Is Expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int ApplicationID = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID)._ApplicationID;
            _ApplicantPersonID = clsDVLDBusinessLocalApplication.FindApplicationByID(ApplicationID)._ApplicationsinFo._ApplicationPersonID;

            _IsThisLicenseHasAnActiveInternatinalLicense = clsDVLDBusinessInternationalLicense.IsThisLicenseHasAnActiveInternatinalLicense(_LicenseID);
            if (_IsThisLicenseHasAnActiveInternatinalLicense)
            {
                lblShowLicenseHistory.Enabled = true;
                lblShowLicenseINfo.Enabled = true;
                int ILicenseID = clsDVLDBusinessInternationalLicense.GetInternationalLicenseInfoByLocalLicense(_LicenseID)._InternationalLicenseID;
                MessageBox.Show($"This LicenseID Already Has An Active Internationa lLicenseID whith Id Number {ILicenseID} ", "NOt Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
            }
            else
            {
                lblShowLicenseHistory.Enabled = false;
                lblShowLicenseINfo.Enabled = false;
            }
        }
        private void _LoadDataWhithLicenseIDByRenewlLicense()
        {
            int ApplicationID = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID)._ApplicationID;

           


            CTRL_Renew_Application_Info cTRL_Renew_Application_ = new CTRL_Renew_Application_Info(_LicenseID);

            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(cTRL_Renew_Application_);

            if (_CheckIfLicenseExpired())
            {

            }
            else
            {
                lblShowLicenseHistory.Enabled = true;
                btnIssue.Enabled = false;
            }
        }
        private void _LoadDataWhithLicenseIDByDamagedOrLostlLicense()
        {
           


            CTRL_DamagedOrLost_License_Info CTRL_DamagedOrLost_License_Info = new CTRL_DamagedOrLost_License_Info(_LicenseID, rdbLostLicense.Checked);
            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CTRL_DamagedOrLost_License_Info);

            if (!_CheckIfLicenseIsActive())
            {
                MessageBox.Show("This License is Not Active or The License Is Expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
            }
            else
            {
                GBDamageOrLost.Enabled = true;
                btnIssue.Enabled = true;
            }
            lblShowLicenseHistory.Enabled = true;
        }
        private void _LoadDataWhithLicenseIDByDetainedLicense()
        {

            CRTL_Detain_License_Info CRTL_Detain_License_Info = new CRTL_Detain_License_Info(_LicenseID, false);
            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CRTL_Detain_License_Info);

            if (_CheckIfLicenseIsActive())
            {
                if (clsDVLDBusinessDetainedLicenses.IsThisLicenseDetained(_LicenseID))
                {
                    MessageBox.Show("This License is Already Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnIssue.Enabled = false;
                }
               
            }
            else
            {
                MessageBox.Show("This License is Not Active or The License Is Expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
            }
            lblShowLicenseHistory.Enabled = true;
        }
        private void _LoadDataWhithLicenseIDByReleaseDetainedLicense()
        {

            

            if (_CheckIfLicenseIsActive())
            {
                if (!clsDVLDBusinessDetainedLicenses.IsThisLicenseDetained(_LicenseID))
                {
                    MessageBox.Show("This License is Not Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnIssue.Enabled = false;
                }
                else
                {
                    CTRL_Release_Detained_Info CTRL_Release_Detained_Info = new CTRL_Release_Detained_Info(_LicenseID, false);
                    GBApplicationInfo.Controls.Clear();
                    GBApplicationInfo.Controls.Add(CTRL_Release_Detained_Info);
                }

            }
            else
            {
                MessageBox.Show("This License is Not Active or The License Is Expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
            }
            lblShowLicenseHistory.Enabled = true;
        }



        private void _LoadDataWhithLicenseID()
        {
            if (_LicenseID == -1)
            {
                _LicenseID = Convert.ToInt32(txtLicenseIDSeraching.Text);
            }
            int ApplicationID = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID)._ApplicationID;
            CTRL_Driver_License_Info cTRL_Driver_License_Info = new CTRL_Driver_License_Info(ApplicationID);
            GBLicenseInfo.Controls.Clear();
            GBLicenseInfo.Controls.Add(cTRL_Driver_License_Info);

            if (_ApplicantionTypeID == Global_Settings.NewInternationalLicense)
            {
                _LoadDataWhithLicenseIDByInternationalLicense();
            }

            if (_ApplicantionTypeID == Global_Settings.RenewDrivingLicenseService)
            {
                _LoadDataWhithLicenseIDByRenewlLicense();
            }

            if (_ApplicantionTypeID == Global_Settings.ReplacementforaDamagedDrivingLicense || _ApplicantionTypeID == Global_Settings.ReplacementforaLostDrivingLicense)
            {
                _LoadDataWhithLicenseIDByDamagedOrLostlLicense();
            }
            if (_ApplicantionTypeID == Global_Settings.DetainLicenseApplicationTypeID)
            {
                _LoadDataWhithLicenseIDByDetainedLicense();
            }
            if (_ApplicantionTypeID == Global_Settings.ReleaseDetainedDrivingLicsense)
            {
                _LoadDataWhithLicenseIDByReleaseDetainedLicense();
            }


        }


        private bool _CheckIfLicenseIsActive()
        {

            clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID);
            _ApplicationID = LicenseInfo._ApplicationID;
            if (LicenseInfo._IsActive && LicenseInfo._ExpirationDate >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool _CheckIfLicenseExpired()
        {

            clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID);
            _ApplicationID = LicenseInfo._ApplicationID;
            if (LicenseInfo._ExpirationDate < DateTime.Now)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"Selected License Is Not Yet Expired it will Expire on {LicenseInfo._ExpirationDate} ", "NOt Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        private void _RenewLicense()
        {
            clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID);
            clsDVLDBusinessLicense NewLicenseInfo = LicenseInfo.RenewLicense(txtNote.Text, Global_Settings.UserID);

            if (NewLicenseInfo._LicenseID!= LicenseInfo._LicenseID)
            {
               MessageBox.Show($"License Renewd Sucesfully whith {NewLicenseInfo._LicenseID} ID Number ", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CTRL_Renew_Application_Info cTRL_Renew_Application_ = new CTRL_Renew_Application_Info(NewLicenseInfo._LicenseID, LicenseInfo._LicenseID, true);

                GBApplicationInfo.Controls.Clear();
                GBApplicationInfo.Controls.Add(cTRL_Renew_Application_);
            }
            else
            {
                MessageBox.Show($"License did not Renewd Sucesfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }
        private void _IssueInternationalLicense()
        {
            _InternationalApplicantID = clsDVLDBusinessLocalApplication.AddNewApplication(_ApplicantPersonID, DateTime.Now, _ApplicantionTypeID,
                                           Global_Settings.StatusCompeletted, DateTime.Now, _PaidFees, Global_Settings.UserID);

            if (_InternationalApplicantID != -1)
            {
                int driverID = clsDVLDBusinessDriver.IsThisPersonAdriver(_ApplicantPersonID);
                _InternatinalLicenseID = clsDVLDBusinessInternationalLicense.AddNewInternatinalLicense(_InternationalApplicantID, driverID, _LicenseID,
                                                                                   DateTime.Now, DateTime.Now.AddYears(1), Global_Settings.UserID, true);

                if (_InternatinalLicenseID != -1)
                {
                    MessageBox.Show($"International License Issued Succesfully Whith ID Number {_InternatinalLicenseID} ", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    CTRL_international_Application_Info cTRL_International_Application_ = new CTRL_international_Application_Info(_InternatinalLicenseID, true);
                    GBApplicationInfo.Controls.Clear();
                    GBApplicationInfo.Controls.Add(cTRL_International_Application_);




                    lblShowLicenseINfo.Enabled = true;
                    GBFilter.Enabled = false;
                    btnIssue.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"International License is not Issued Succesfully", "License not Issued", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show($"International License Application is not Added Succesfully", "License not Issued", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _IssueReplacementLicense()
        {
            clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID);
            clsDVLDBusinessLicense NewLicenseInfo;
            if (rdbLostLicense.Checked) 
            {
                NewLicenseInfo = LicenseInfo.Replace(clsDVLDBusinessLicense.enIssueReason.LostReplacement, Global_Settings.UserID);

            }
            else
            {
                NewLicenseInfo = LicenseInfo.Replace(clsDVLDBusinessLicense.enIssueReason.DamagedReplacement, Global_Settings.UserID);
            }

            if (NewLicenseInfo._LicenseID != LicenseInfo._LicenseID)
            {
                MessageBox.Show($"License Replaced Sucesfully whith {NewLicenseInfo._LicenseID} ID Number ", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CTRL_DamagedOrLost_License_Info CTRL_DamagedOrLost_License_Info = new CTRL_DamagedOrLost_License_Info(NewLicenseInfo._LicenseID,
                                                                                               rdbLostLicense.Checked, LicenseInfo._LicenseID);

                GBApplicationInfo.Controls.Clear();
                GBApplicationInfo.Controls.Add(CTRL_DamagedOrLost_License_Info);
            }
            else
            {
                MessageBox.Show($"License did not Replace Sucesfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            //if (clsDVLDBusinessLicense.CancelLicenseApplication(_LicenseID))
            //{
            //    clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID);
            //    int oldApplicationID = LicenseInfo._ApplicationID;
            //    int oldLicenseClassID = LicenseInfo._LicenseClassID;


            //    clsDVLDBusinessLocalApplication oldAppInfo = clsDVLDBusinessLocalApplication.FindApplicationByID(oldApplicationID);
            //    int NewApplicationID = -1;
            //    if (rdbLostLicense.Checked)
            //    {
            //         NewApplicationID = clsDVLDBusinessLocalApplication.AddNewApplication(oldAppInfo._ApplicationsinFo._ApplicationPersonID, DateTime.Now,
            //          Global_Settings.ReplacementforaLostDrivingLicense, Global_Settings.StatusCompeletted, DateTime.Now, oldAppInfo._ApplicationsinFo._PaidFees,
            //                       Global_Settings.UserID);
            //    }
            //    else
            //    {
            //         NewApplicationID = clsDVLDBusinessLocalApplication.AddNewApplication(oldAppInfo._ApplicationsinFo._ApplicationPersonID, DateTime.Now,
            //           Global_Settings.ReplacementforaDamagedDrivingLicense, Global_Settings.StatusCompeletted, DateTime.Now, oldAppInfo._ApplicationsinFo._PaidFees,
            //                        Global_Settings.UserID);
            //    }


            //    int NewLocalLicense = clsDVLDBusinessLocalApplication.AddNewLocalDrivingLicenseApplication(oldLicenseClassID, NewApplicationID);
            //    if (NewLocalLicense != -1)
            //    {
            //        DateTime expirationDate = DateTime.Now.AddYears(clsDVLDBusinessLicenseClasses.GetLicenseClassByID(LicenseInfo._LicenseClassID)._DefaultValidityLength);

            //        if (rdbLostLicense.Checked)
            //        {
            //            _RenewNewLiceseID = clsDVLDBusinessLicense.AddNewLicense(NewApplicationID, LicenseInfo._DriverID, oldLicenseClassID, DateTime.Now,
            //                                                     expirationDate, txtNote.Text, LicenseInfo._PaidFees, true, Global_Settings.IssueReasonForLost, Global_Settings.UserID);
            //        }
            //        else
            //        {
            //            _RenewNewLiceseID = clsDVLDBusinessLicense.AddNewLicense(NewApplicationID, LicenseInfo._DriverID, oldLicenseClassID, DateTime.Now,
            //                                                     expirationDate, txtNote.Text, LicenseInfo._PaidFees, true, Global_Settings.IssueReaasonForDamaged, Global_Settings.UserID);
            //        }



            //        _RenewNewApplicationID = NewApplicationID;

            //        CTRL_DamagedOrLost_License_Info CTRL_DamagedOrLost_License_Info = new CTRL_DamagedOrLost_License_Info(_RenewNewLiceseID,rdbLostLicense.Checked,_LicenseID);

            //        GBApplicationInfo.Controls.Clear();
            //        GBApplicationInfo.Controls.Add(CTRL_DamagedOrLost_License_Info);

            //        lblShowLicenseINfo.Enabled = true;
            //        GBFilter.Enabled = false;
            //        btnIssue.Enabled = false;
            //        lblShowLicenseHistory.Enabled = true;
            //        GBDamageOrLost.Enabled = false; 
            //        MessageBox.Show($"License Replacement Sucesfully whith {_RenewNewLiceseID} ID Number ", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show($"The New Application Did not Added Succesfully ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show($"old License Did not Cancel Succesfully ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void _DetainLicense()
        {




            CRTL_Detain_License_Info CRTL_Detain_LicenseInfo = new CRTL_Detain_License_Info(_LicenseID, true);
            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CRTL_Detain_LicenseInfo);

            int DetainID = CRTL_Detain_LicenseInfo._DetainID;
            if (DetainID != -1)
            {
               
               MessageBox.Show($"License Detained Succesfully Whith {DetainID} ID Number", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
               
                lblShowLicenseINfo.Enabled = true;
                GBFilter.Enabled = false;
                btnIssue.Enabled = false;
                lblShowLicenseHistory.Enabled = true;
            }
            else
            {
             
               MessageBox.Show($"License Not Detained Succesfully", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }
             
           
        }
        private void _ReleaseDetainLicense()
        {
            CTRL_Release_Detained_Info CTRL_Release_Detained_Info = new CTRL_Release_Detained_Info(_LicenseID, true);
            GBApplicationInfo.Controls.Clear();
            GBApplicationInfo.Controls.Add(CTRL_Release_Detained_Info);

            if (CTRL_Release_Detained_Info._isFinish)
            {
                lblShowLicenseINfo.Enabled = true;
                GBFilter.Enabled = false;
                btnIssue.Enabled = false;
                lblShowLicenseHistory.Enabled = true;
            }
   


        }



        private void _IssueOrRenew()
        {
            if (_ApplicantionTypeID == Global_Settings.RenewDrivingLicenseService)
            {
                _RenewLicense();
            }
            if (_ApplicantionTypeID == Global_Settings.NewInternationalLicense)
            {
                _IssueInternationalLicense();
            }
           

        }
       
       

        private void New_International_License_Application_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _LoadDataWhithLicenseID();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_ApplicantionTypeID == Global_Settings.NewInternationalLicense)
            {
                if (MessageBox.Show("Are You Sure You Want To Issue This License", "Conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _IssueOrRenew();
                }
            }
            if (_ApplicantionTypeID == Global_Settings.RenewDrivingLicenseService)
            {
                if (MessageBox.Show("Are You Sure You Want To Renew This License", "Conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _IssueOrRenew();
                }
            }
            if (_ApplicantionTypeID == Global_Settings.ReplacementforaDamagedDrivingLicense || _ApplicantionTypeID == Global_Settings.ReplacementforaLostDrivingLicense)
            {
                if (MessageBox.Show("Are You Sure You Want To Replace This License", "Conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _IssueReplacementLicense();
                }
            }
            if (_ApplicantionTypeID == Global_Settings.DetainLicenseApplicationTypeID)
            {
                if (MessageBox.Show("Are You Sure You Want To Detain This License", "Conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _DetainLicense();
                }
            }
            if (_ApplicantionTypeID == Global_Settings.ReleaseDetainedDrivingLicsense)
            {
                if (MessageBox.Show("Are You Sure You Want To Release This Detain License", "Conform", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _ReleaseDetainLicense();
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void lblShowLicenseHistory_Click_1(object sender, EventArgs e)
        {
            if (_ApplicantionTypeID == Global_Settings.NewInternationalLicense)
            {
                if (_InternationalApplicantID == -1)
                {
                    _InternationalApplicantID = clsDVLDBusinessInternationalLicense.GetInternationalLicenseInfoByLocalLicense(_LicenseID)._ApplicationtID;
                }
                License_History license_History = new License_History(_InternationalApplicantID);

                license_History.ShowDialog();
            }
            else
            {
                int ApplicationID = -1;

                if (_RenewNewLiceseID == -1)
                {
                    ApplicationID = clsDVLDBusinessLicense.GetLicenseInfoByID(_LicenseID)._ApplicationID;
                }
                else
                {
                    ApplicationID = clsDVLDBusinessLicense.GetLicenseInfoByID(_RenewNewLiceseID)._ApplicationID;
                }

                License_History license_History = new License_History(ApplicationID);

                license_History.ShowDialog();
            }
           
        }

        private void lblShowLicenseINfo_Click_1(object sender, EventArgs e)
        {

            if (_ApplicantionTypeID == Global_Settings.NewInternationalLicense)
            {
                if (_InternationalApplicantID == -1)
                {
                    _InternationalApplicantID = clsDVLDBusinessInternationalLicense.GetInternationalLicenseInfoByLocalLicense(_LicenseID)._ApplicationtID;
                }
                License_Info license_Info = new License_Info(_InternationalApplicantID, true);

                license_Info.ShowDialog();
            }
            else
            {
                License_Info license_Info = new License_Info(_RenewNewApplicationID, false);

                license_Info.ShowDialog();
            }
            if (_ApplicantionTypeID == Global_Settings.DetainLicenseApplicationTypeID || _ApplicantionTypeID == Global_Settings.ReleaseDetainedDrivingLicsense)
            {
                License_Info license_Info = new License_Info(_LicenseID, false);

                license_Info.ShowDialog();
            }
          
                
        }

        private void RdbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _IsDamagedOrLostApplication();
        }

        private void rdbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _IsDamagedOrLostApplication();
        }
    }
}
