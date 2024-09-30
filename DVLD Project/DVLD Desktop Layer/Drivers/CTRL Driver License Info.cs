using DVLDBusinessLayer;
using DVLDBusinessPeople;
using DVLDDesltopFrontLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.Controles
{
    public partial class CTRL_Driver_License_Info : UserControl
    {
        private int _ApplicationID = -1;
        public CTRL_Driver_License_Info(int ID)
        {
            InitializeComponent();
            _ApplicationID = ID;
        }
        public CTRL_Driver_License_Info()
        {
            InitializeComponent();
        }
        public void LoadLicenseInfo(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            _LoadData();
        }
        private void _LoadData()
        {
            if (_ApplicationID == -1)
            {
                return;
            }
            clsDVLDBusinessLicense LicenseInformation =  clsDVLDBusinessLicense.GetLicenseInfoByApplicationID(_ApplicationID);
            


            lblClassName.Text = LicenseInformation.LicenseClassIfo._LicenseClassName;
            lblName.Text = LicenseInformation.DriverInfo.PersonInfo.FullName;
            lblDateOfBirth.Text = LicenseInformation.DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblGendor.Text = LicenseInformation.DriverInfo.PersonInfo.Gender.ToString();
            lblNationalNO.Text = LicenseInformation.DriverInfo.PersonInfo.NationalNO.ToString();
            if (LicenseInformation.DriverInfo.PersonInfo.Gender.ToString() == "Male")
            {
                PBGendor.Image = Resources.Man_32;
                PBImage.Image = Resources.Male_512;
            }
            else
            {
                PBGendor.Image = Resources.Woman_32;
                PBImage.Image = Resources.Female_512;
               
            }
            if (LicenseInformation.DriverInfo.PersonInfo.ImagePath != "")
            {
                if (File.Exists(LicenseInformation.DriverInfo.PersonInfo.ImagePath))
                {
                    PBImage.ImageLocation = LicenseInformation.DriverInfo.PersonInfo.ImagePath;
                }
                else
                    MessageBox.Show("Could not find this image: = " + LicenseInformation.DriverInfo.PersonInfo.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          


            lblDriverID.Text = LicenseInformation._DriverID.ToString();
            lblExpirationID.Text = LicenseInformation._ExpirationDate.ToString();  
            if (LicenseInformation._IsActive)
            {
                lblIsActive.Text = "Yes ";
            }
            else
            {
                lblIsActive.Text = "NO";
            }
            if (clsDVLDBusinessDetainedLicenses.IsThisLicenseDetained(LicenseInformation._LicenseID))
            {
                lblIsDetained.Text = "Yes";
            }
            else
            {
                lblIsDetained.Text = "No";
            }
            lblIssueReason.Text = LicenseInformation.IssueReasonText;
            lblIssueDate.Text = LicenseInformation._IssueDate.ToString();
           
            lblLicenseID.Text = LicenseInformation._LicenseID.ToString();
            if (LicenseInformation._Note != "")
            {
                lblNotes.Text = LicenseInformation._Note;
            }
            else
            {
                lblNotes.Text = "No Notes";
            }
           
           


        }
        private void CTRL_Driver_License_Info_Load(object sender, EventArgs e)
        {
            if (_ApplicationID != -1)
            {
                _LoadData();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
