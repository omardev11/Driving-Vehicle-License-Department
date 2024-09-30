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
    public partial class CTRL_DamagedOrLost_License_Info : UserControl
    {
        private int _LocalLicenseID = -1;
        private int _NewLocalLicenseID = -1;
        private bool _IsLost = false;
        public CTRL_DamagedOrLost_License_Info()
        {
            InitializeComponent();
            _LoadData();

        }
        public CTRL_DamagedOrLost_License_Info(int LocalLicenseID,bool IsLost)
        {
            InitializeComponent();
            _LocalLicenseID = LocalLicenseID;
            _IsLost = IsLost;
            _LoadDataWhithLocalLienseID();
        }

        public CTRL_DamagedOrLost_License_Info(int NewLicenseID, bool IsLost,int OldLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = OldLicenseID;
            _NewLocalLicenseID = NewLicenseID;
            _IsLost = IsLost;
            _LoadDataAfterIssued();
        }

        private void _LoadData()
        {
            clsDVLDBusinessApplicationTypes AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.ReplacementforaDamagedDrivingLicense);

             lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();
        }

        private void _LoadDataWhithLocalLienseID()
        {
            clsDVLDBusinessApplicationTypes AppInfo;
            if (_IsLost)
            {
                 AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.ReplacementforaLostDrivingLicense);
            }
            else
            {
                  AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.ReplacementforaDamagedDrivingLicense);
            }

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();

            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
        }

        private void _LoadDataAfterIssued()
        {
            clsDVLDBusinessApplicationTypes AppInfo;
            if (_IsLost)
            {
                AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.ReplacementforaLostDrivingLicense);
            }
            else
            {
                AppInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.ReplacementforaDamagedDrivingLicense);
            }

            lblFees.Text = AppInfo.Fees.ToString();
            lblApplicationDate.Text = DateTime.Now.ToString();
           
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();

            lblLocalLicenseID.Text = _LocalLicenseID.ToString();

            int applicationID = clsDVLDBusinessLicense.GetLicenseInfoByID(_NewLocalLicenseID)._ApplicationID;

            lblILApplicationID.Text = applicationID.ToString();
            lblILLicenseID.Text = _NewLocalLicenseID.ToString();
        }

        private void CTRL_DamagedOrLost_License_Info_Load(object sender, EventArgs e)
        {
        }

        private void groupbox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
