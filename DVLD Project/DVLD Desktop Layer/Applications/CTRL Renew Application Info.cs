using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.Controles
{
    public partial class CTRL_Renew_Application_Info : UserControl
    {
        private int _LocalLicenseID = -1;
        private int _NewLocalLicenseID = -1;  
        
        public CTRL_Renew_Application_Info()
        {
            InitializeComponent();
        }
        public CTRL_Renew_Application_Info(int LocalLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = LocalLicenseID;
            _LoadDataWhithLocalLicense();
        }
        public CTRL_Renew_Application_Info(int NewLocalLicenseID ,int OldLicenseID, bool IsRenewed)
        {
            InitializeComponent();
            _NewLocalLicenseID = NewLocalLicenseID;
            _LocalLicenseID = OldLicenseID;
            _LoadDataAfterIssued();
        }
       
        private void _LoadData()
        {
            clsDVLDBusinessApplicationTypes AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.RenewDrivingLicenseService);

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();

        }
        private void _LoadDataWhithLocalLicense()
        {
            clsDVLDBusinessApplicationTypes AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.RenewDrivingLicenseService);

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();

            clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_LocalLicenseID);

            clsDVLDBusinessLicenseClasses LicenseClassInfo = clsDVLDBusinessLicenseClasses.GetLicenseClassByID(LicenseInfo._LicenseClassID);

            decimal ApplicatonFees = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.NewLocalDrivingLicenseService).Fees;
            lblLicenseFees.Text = ApplicatonFees.ToString();


            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(LicenseClassInfo._DefaultValidityLength).ToString();
            lblTotalFees.Text = (AppInfo.Fees + ApplicatonFees).ToString();


        }
        private void _LoadDataAfterIssued()
        {
            clsDVLDBusinessApplicationTypes AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.RenewDrivingLicenseService);

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();

            clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_NewLocalLicenseID);

            clsDVLDBusinessLicenseClasses LicenseClassInfo = clsDVLDBusinessLicenseClasses.GetLicenseClassByID(LicenseInfo._LicenseClassID);

            decimal ApplicatonFees = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.NewLocalDrivingLicenseService).Fees;

            lblLicenseFees.Text = ApplicatonFees.ToString();
            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(LicenseClassInfo._DefaultValidityLength).ToString();
            lblTotalFees.Text = (AppInfo.Fees + ApplicatonFees).ToString();

            int applicationID = clsDVLDBusinessLicense.GetLicenseInfoByID(_NewLocalLicenseID)._ApplicationID;

            lblILApplicationID.Text = applicationID.ToString();
            lblILLicenseID.Text = _NewLocalLicenseID.ToString();


        }




        private void CTRL_Renew_Application_Info_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
