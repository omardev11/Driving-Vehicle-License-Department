using DVLDBusinessLayer;
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
    public partial class CTRL_Release_Detained_Info : UserControl
    {
        clsDVLDBusinessApplicationTypes Appinfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Global_Settings.ReleaseDetainedDrivingLicsense);

        private int _localLicenseID = -1;
        private bool _isReleased = false;
        public bool _isFinish = false;
        public CTRL_Release_Detained_Info()
        {
            InitializeComponent();
        }
        public CTRL_Release_Detained_Info(int localLicenseID, bool IsRelased)
        {
            InitializeComponent();
            _localLicenseID = localLicenseID;
            _isReleased = IsRelased;
            if (_isReleased)
            {
                _loadDataAndReleaseLicense();
            }
            else
            {
                _loadDataWhithLocalLicenseID();
            }
            

        }

        private void _loadData()
        {
            lblApplicationFees.Text = Appinfo.Fees.ToString();

        }

        private void _loadDataWhithLocalLicenseID()
        {
            clsDVLDBusinessDetainedLicenses DetainLicenseInfo = clsDVLDBusinessDetainedLicenses.GetDetainLicenseInfoByLicenseID(_localLicenseID);

            
            lblLocalLicenseID.Text = _localLicenseID.ToString();

            lblApplicationDate.Text = DetainLicenseInfo._DetainDate.ToString();
            lblCreatedByuserID.Text = DetainLicenseInfo._CreatedByUserID.ToString();
            lblFinefees.Text = DetainLicenseInfo._FineFees.ToString();
            lblApplicationFees.Text = Appinfo.Fees.ToString();
            lblDetainID.Text = DetainLicenseInfo._DetainID.ToString();
            lblTotalFees.Text = (DetainLicenseInfo._FineFees + Appinfo.Fees).ToString();


        }
        private void _loadDataAndReleaseLicense()
        {
         

            clsDVLDBusinessLicense LicenseInfo = clsDVLDBusinessLicense.GetLicenseInfoByID(_localLicenseID);
            int ReleaseAppID = -1;
            if (LicenseInfo.IsDetained)
            {
                if (LicenseInfo.ReleaseDetainedLicense(Global_Settings.UserID, ref ReleaseAppID))
                {
                    MessageBox.Show("Detained License Released Sucessfully", "Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _isFinish = true;

                }
                else
                {
                    MessageBox.Show("Detained License Not Released Sucessfully", "Released", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("This License Is Not Detained ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

           

            lblApplicationID.Text = ReleaseAppID.ToString();

        }



        private void CTRL_Release_Detained_Info_Load(object sender, EventArgs e)
        {

        }
    }
}
