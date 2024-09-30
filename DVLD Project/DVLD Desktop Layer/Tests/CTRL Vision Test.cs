using DVLDBusinessLayer;
using DVLDBusinessPeople;
using DVLDDesltopFrontLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.Controles
{
    public partial class CTRL_Vision_Test : UserControl
    {
        enum enMode { UpdateMode = 1 , AddMode = 2 };
        private enMode _Mode;

        private clsDVLDBusinessTestAppoinments _TestAppoinmentInfo;
        private clsDVLDBusinessTestTypes.enTestType _enTestTypeID = clsDVLDBusinessTestTypes.enTestType.VisionTest;

        private bool _IsFail =  false;
        private int _DLApplicationID = -1;
        private int _TestTypeID = -1;
        private int _AppoinMentID = -1;


        private int _RetakeTestApplicationID = -1;
        private decimal _ApplicationRetakeFees = 0;
        
        private bool IsFail(int DLapplicationID , int TEstTypeID)
        {
            if (clsDVLDBusinessTestTypes.IsFail(DLapplicationID, TEstTypeID))
            {
                lblTitile.Text = "Sechdule Retake Test";

                GBRetakeTest.Enabled = true;
                decimal ApplicationFees = clsDVLDBusinessTestTypes.FindCTestTypeByID(TEstTypeID).Fees;
                decimal ApplicationRetakeFees = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(7).Fees;
                lblRetakeTestFees.Text = ApplicationRetakeFees.ToString();
                lblTotalFees.Text = (ApplicationFees + ApplicationRetakeFees).ToString();
                _ApplicationRetakeFees = ApplicationRetakeFees;
                return true;

                
            }
            else
            { return false; }
        }
        public CTRL_Vision_Test()
        {
            InitializeComponent();

        }

     

        public CTRL_Vision_Test(int AppoinmentID,DateTime AppoinmentDate)
        {
            InitializeComponent();
            _AppoinMentID = AppoinmentID;
          
            GBRetakeTest.Visible = false;
                btnSave.Visible = false;
                DTAppointMentDate.Visible = false;
                lblDate.Visible = true;
           
            
            Stack<int> DlAppIdAndTestIDValues = clsDVLDBusinessTestTypes.GelLocalDrivingLicenseApplicationIDByTestAppoinmentID(_AppoinMentID);
            _TestTypeID = DlAppIdAndTestIDValues.Pop();
            _DLApplicationID = DlAppIdAndTestIDValues.Pop();
            lblDate.Text = AppoinmentDate.ToString();
            _LoadData();
        }

        public clsDVLDBusinessTestTypes.enTestType TestTypeID
        {
            get
            {
                return _enTestTypeID;
            }
            set
            {
                _enTestTypeID = value;

                switch (_enTestTypeID)
                {

                    case clsDVLDBusinessTestTypes.enTestType.VisionTest:
                        {
                            lblTestType.Text = "Vision Test";
                            PBLogo.Image = Resources.Vision_512;
                            break;
                        }

                    case clsDVLDBusinessTestTypes.enTestType.WrittenTest:
                        {
                            lblTestType.Text = "Written Test";
                            PBLogo.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsDVLDBusinessTestTypes.enTestType.StreetTest:
                        {
                            lblTestType.Text = "Street Test";
                            PBLogo.Image = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }

        public void _loadAddMode(int ID, int TesttypeID)
        {
            _DLApplicationID = ID;
            _TestTypeID = TesttypeID;
            _Mode = enMode.AddMode;
            if (IsFail(_DLApplicationID, _TestTypeID))
                _IsFail = true;
            lblTrial.Text = clsDVLDBusinessTestTypes.TotalTrialperTest(_DLApplicationID, _TestTypeID).ToString();
            _LoadData();
            DTAppointMentDate.MinDate = DateTime.Now;
        }
        public void _loadUpdateMode(int AppoinmentID)
        {
            _AppoinMentID = AppoinmentID;
            _Mode = enMode.UpdateMode;
            _TestAppoinmentInfo = clsDVLDBusinessTestAppoinments.Find(_AppoinMentID);
            if (_TestAppoinmentInfo.IsLocked)
            {
                DTAppointMentDate.Enabled = false;
                btnSave.Enabled = false;
                GBRetakeTest.Enabled = true;
                lblAppoinmentLoackedinfo.Visible = true;
            }
            Stack<int> DlAppIdAndTestIDValues = clsDVLDBusinessTestTypes.GelLocalDrivingLicenseApplicationIDByTestAppoinmentID(_AppoinMentID);
            _TestTypeID = DlAppIdAndTestIDValues.Pop();
            _DLApplicationID = DlAppIdAndTestIDValues.Pop();
            lblTrial.Text = clsDVLDBusinessTestTypes.TotalTrialperTest(_DLApplicationID, _TestTypeID).ToString();

            if (DateTime.Compare(DateTime.Now,_TestAppoinmentInfo.AppointmentDate)<0)
            {
                DTAppointMentDate.MinDate = DateTime.Now;
            }
            else
            {
                DTAppointMentDate.MinDate = _TestAppoinmentInfo.AppointmentDate;
            }
            _LoadData();

            

        }
        public void _loadTAkeTest(int AppoinmentID, DateTime AppoinmentDate)
        {
            _AppoinMentID = AppoinmentID;

            GBRetakeTest.Visible = false;
            btnSave.Visible = false;
            DTAppointMentDate.Visible = false;
            lblDate.Visible = true;


            Stack<int> DlAppIdAndTestIDValues = clsDVLDBusinessTestTypes.GelLocalDrivingLicenseApplicationIDByTestAppoinmentID(_AppoinMentID);
            _TestTypeID = DlAppIdAndTestIDValues.Pop();
            _DLApplicationID = DlAppIdAndTestIDValues.Pop();
            lblDate.Text = AppoinmentDate.ToString();
            _LoadData();
        }

        private void _LoadData()
        {
           
            clsDVLDBusinessLocalApplication localApplication = clsDVLDBusinessLocalApplication.FindLocalDrivingLicenseApplications_ViewByID(_DLApplicationID);

            lblDLAppID.Text = localApplication._D_L_ApplicatioinInfo._LocalDrivingApplicationID.ToString();
            lblLicenseClassType.Text = localApplication._D_L_ApplicatioinInfo._LicenseClassName.ToString();
            lblApplicantName.Text = localApplication._D_L_ApplicatioinInfo._FullName;
            lblFees.Text = clsDVLDBusinessTestTypes.FindCTestTypeByID(_TestTypeID).Fees.ToString();


          
        }

        private void _Save()
        {
            if (_IsFail)
            {
                string NationalNO = clsDVLDBusinessLocalApplication.FindLocalDrivingLicenseApplications_ViewByID(_DLApplicationID)._D_L_ApplicatioinInfo._NationalNo;
                int ApplicationPersonID = clsDVLDBusinessPeople.FindByNationalNO(NationalNO).PerosnID;
                _RetakeTestApplicationID = clsDVLDBusinessLocalApplication.AddNewApplication(ApplicationPersonID, DateTime.Now,
                     Global_Settings.RetakeTest,Global_Settings.StatusCompeletted, DateTime.Now,  _ApplicationRetakeFees, Global_Settings.UserID);
            }
            switch (_Mode)
            {
                case enMode.UpdateMode:
                    if (clsDVLDBusinessTestTypes.UpdateTestAppointment(_AppoinMentID, DTAppointMentDate.Value, _RetakeTestApplicationID))
                    {
                        MessageBox.Show("Test Appoinment Updated Sucesfully");
                        if (_IsFail)
                            lblRTestAppID.Text = _RetakeTestApplicationID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Test Appoinment not Updated Sucesfully");
                    }

                    break;
                case enMode.AddMode:
                    if (clsDVLDBusinessTestTypes.AddNewTestAppointment(_TestTypeID, _DLApplicationID, DTAppointMentDate.Value, Convert.ToDecimal(lblFees.Text),
                                                                                                         Global_Settings.UserID, false, _RetakeTestApplicationID))
                    {
                        MessageBox.Show("Test Appoinment Added Sucesfully");
                        if (_IsFail)
                            lblRTestAppID.Text = _RetakeTestApplicationID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Test Appoinment not Added Sucesfully");
                    }
                    break;
            }
        }
        private void CTRL_Vision_Test_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }
    }
}
