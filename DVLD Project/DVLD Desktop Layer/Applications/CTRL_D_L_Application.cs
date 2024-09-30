using DVLDBusinessLayer;
using DVLDDesltopFrontLayer.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDesltopFrontLayer.Controles
{
    public partial class CTRL_D_L_Application : UserControl
    {
        private int _DLApplicationID = -1;
        private int _ApplicationID = -1;
        private int _PersonID = -1;

        public CTRL_D_L_Application(int ID)
        {
            InitializeComponent();
            _DLApplicationID = ID;
            _LoadData();
            CheckIfheHasLicense();
        }
        public CTRL_D_L_Application()
        {
            InitializeComponent();
        }

        private void CheckIfheHasLicense()
        {
             _ApplicationID = clsDVLDBusinessLocalApplication.FindLocalDrivingLicenseApplications_ViewByID(_DLApplicationID)._D_L_ApplicatioinInfo._ApplicationID;

            if (clsDVLDBusinessLicense.IsThisApplicationHasLicense(_ApplicationID))
            {
                lblShowLicenseInfo.Enabled = true;

               
            }
        }
        public void loadData(int ID)
        {
            _DLApplicationID = ID;
            _LoadData();
            CheckIfheHasLicense();

        }
        private void _loadLocalDrivingData()
        {
            clsDVLDBusinessLocalApplication localApplication = clsDVLDBusinessLocalApplication.FindLocalDrivingLicenseApplications_ViewByID(_DLApplicationID);
            
            lblDLAppID.Text = localApplication._D_L_ApplicatioinInfo._LocalDrivingApplicationID.ToString();
            lblLicenseClassType.Text = localApplication._D_L_ApplicatioinInfo._LicenseClassName.ToString();
            lblPassedTests.Text = localApplication._D_L_ApplicatioinInfo._PassedTestCount.ToString() + "/3";
            _ApplicationID = localApplication._D_L_ApplicatioinInfo._ApplicationID;
            lblStatus.Text = localApplication._D_L_ApplicatioinInfo._Status;
            lblApplicantName.Text = localApplication._D_L_ApplicatioinInfo._FullName;
        }

        private void _loadApplicationData()
        {
            clsDVLDBusinessLocalApplication localApplication = clsDVLDBusinessLocalApplication.FindApplicationByID(_ApplicationID);

            clsDVLDBusinessApplicationTypes applicationTypes = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(localApplication._ApplicationsinFo._ApplicationTypeID);


            lblApplicationID.Text = localApplication._ApplicationsinFo._ApplicationtID.ToString();
            lblApplicationDate.Text = Convert.ToDateTime(localApplication._ApplicationsinFo._ApplicationDate).Date.ToString();
            lblStatusDate.Text = Convert.ToDateTime(localApplication._ApplicationsinFo._LastStatusDate).Date.ToString();
            lblCreatedUser.Text = clsDVLDBusinessUsers.FindUserByID(localApplication._ApplicationsinFo._CreatedUserByID).UserName;
            lblTypeLicense.Text = applicationTypes.ApplicationTypeName;
            lblFees.Text = applicationTypes.Fees.ToString();
            _PersonID = localApplication._ApplicationsinFo._ApplicationPersonID;

        }

        private void _LoadData()
        {
            _loadLocalDrivingData();
            _loadApplicationData();
        }

        private void CTRL_D_L_Application_Load(object sender, EventArgs e)
        {
        }

        private void lblEditPerosn_Click(object sender, EventArgs e)
        {
            Person_Details person_ = new Person_Details(_PersonID);

            person_.ShowDialog();
        }

        private void lblShowLicenseInfo_Click(object sender, EventArgs e)
        {
            License_Info license_Info = new License_Info(_ApplicationID, false);

            license_Info.ShowDialog();
        }
    }
}
