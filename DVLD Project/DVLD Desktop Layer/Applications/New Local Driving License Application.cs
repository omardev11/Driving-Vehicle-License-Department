using DVLDBusinessLayer;
using DVLDBusinessPeople;
using DVLDDesltopFrontLayer.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.Applications
{
    public partial class New_Local_Driving_License_Application : Form
    {
        public New_Local_Driving_License_Application()
        {
            InitializeComponent();
        }
        
        private void _GetClassNamesList()
        {
            DataTable dt = clsDVLDBusinessLicenseClasses.GetAllLicenseClassesName();

            foreach (DataRow dr in dt.Rows)
            {
                CBLicenseClass.Items.Add(dr["ClassName"]);
            }

            CBLicenseClass.SelectedIndex = 2;
        }
        private void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(1).Fees.ToString();
            lblCreatedUser.Text = Global_Settings.UserID.ToString();
            _GetClassNamesList();
        }
        private void _SaveData()
        {
            int FoundApplicationID = -1 ;
            int LicenseClassID = clsDVLDBusinessLicenseClasses.GetLicenseClassByName(CBLicenseClass.Text)._LicenseClassID;
            int PersonID = CTRLFilterUserBy._ID;
            string NationalNo = clsDVLDBusinessPeople.Find(PersonID).NationalNO;
            int LocalDrivingLicenseApplicationID = -1;
         

            if (!clsDVLDBusinessLocalApplication.IsThisLicenseClassExistInThisPerson(NationalNo, CBLicenseClass.Text ,ref FoundApplicationID))
            {
                int NewApplicationID = clsDVLDBusinessLocalApplication.AddNewApplication(PersonID, DateTime.Now, 1, 1, DateTime.Now,
                                                    Convert.ToDecimal(lblApplicationFees.Text), Convert.ToInt32(lblCreatedUser.Text));
                LocalDrivingLicenseApplicationID = clsDVLDBusinessLocalApplication.AddNewLocalDrivingLicenseApplication(LicenseClassID, NewApplicationID);
                if (LocalDrivingLicenseApplicationID != -1)
                {
                    lblDLApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();
                    MessageBox.Show("Added New Local Driving License Application Succesfully");
                }
                else
                {
                    MessageBox.Show("Did not Added New Local Driving License Application Succesfully");
                }
            }
            else
            {
                MessageBox.Show($"Choose Another License Class The Sellected Person Already Have an Active Application For The Selected Class Whith {FoundApplicationID} ID");
            }
        }
        private void New_Local_Driving_License_Application_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           _SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages[1].Enabled = true;
            tabControl1.SelectedIndex = 1;
        }

        private void New_Local_Driving_License_Application_Shown(object sender, EventArgs e)
        {
            ctrlFilterUserBy1.FilterFocus();
        }
    }
}
