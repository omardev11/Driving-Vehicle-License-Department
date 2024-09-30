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
    public partial class CTRL_international_Application_Info : UserControl
    {
        private int _LocalLicenseID = -1;
        private int _InternatinalLicenseID = -1;
        public CTRL_international_Application_Info()
        {
            InitializeComponent();
        }

        public CTRL_international_Application_Info(int LocalLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = LocalLicenseID;
            _LoadDataWhithLocalLienseID();
        }
        public CTRL_international_Application_Info(int InternatinalLicenseID,bool IsIssued)
        {
            InitializeComponent();
            _InternatinalLicenseID = InternatinalLicenseID;
            _LoadDataAfterIssued();
        }


        private void _LoadData()
        {
            clsDVLDBusinessApplicationTypes AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.NewInternationalLicense);

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();
        }
        private void _LoadDataWhithLocalLienseID()
        {
            clsDVLDBusinessApplicationTypes AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.NewInternationalLicense);

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();

            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
        }
        private void _LoadDataAfterIssued()
        {
            clsDVLDBusinessApplicationTypes AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(6);

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();

            lblLocalLicenseID.Text = _LocalLicenseID.ToString();

            int applicationID = clsDVLDBusinessInternationalLicense.GetInternationalLicenseInfoByID(_InternatinalLicenseID)._ApplicationtID;

            lblILApplicationID.Text = applicationID.ToString();
            lblILLicenseID.Text = _InternatinalLicenseID.ToString();
        }

        private void CTRL_international_Application_Info_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
