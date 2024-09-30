using DVLDBusinessLayer;
using DVLDDesltopFrontLayer.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.License
{
    public partial class Issue_Driving_License_For_The_First_Time : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsDVLDbusinessNewVersionLocalApplications _LocalDrivingLicenseApplication;

        private int _DLAppID = -1;
        private int _LicenseID = -1;
        private int _ApplicationID = -1;    
        public Issue_Driving_License_For_The_First_Time(int ID)
        {
            InitializeComponent();
            _DLAppID = ID;
            _LocalDrivingLicenseApplicationID = ID;
            _LocalDrivingLicenseApplication = clsDVLDbusinessNewVersionLocalApplications.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
        }

        private void _LoadData()
        {
            if (_LocalDrivingLicenseApplication == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            if (_LocalDrivingLicenseApplication.GetPassedTestCount() < 3)
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
           
            if (clsDVLDBusinessLicense.IsThisApplicationHasLicense(_LocalDrivingLicenseApplication.ApplicationtID))
            {

                MessageBox.Show("Person already has License before ","Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }


            CTRL_D_L_Application cTRL_D_L_ = new CTRL_D_L_Application(_DLAppID);
            groupBox1.Controls.Add(cTRL_D_L_);

        }

        private void _IssueDrivingLicense()
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), Global_Settings.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
        private void Issue_Driving_License_For_The_First_Time_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _IssueDrivingLicense();
          
        }
    }
}
