using DVLDBusinessLayer;
using DVLDBusinessPeople;
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
    public partial class CTRL_International_Driver_Info : UserControl
    {
        private int _ApplicationID = -1;
        public CTRL_International_Driver_Info(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }

        private void _LoadData()
        {
            int PersonID = clsDVLDBusinessLocalApplication.FindApplicationByID(_ApplicationID)._ApplicationsinFo._ApplicationPersonID;

            clsDVLDBusinessInternationalLicense LicenseInfo = clsDVLDBusinessInternationalLicense.GetInternationalLicenseInfoByApplicationID(_ApplicationID);
            clsDVLDBusinessPeople PersonInfo = clsDVLDBusinessPeople.Find(PersonID);


            lblName.Text = PersonInfo.FirstName + " " + PersonInfo.SecondName + " " + PersonInfo.ThirdName + " " + PersonInfo.LastName;
            lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToString();
            lblGendor.Text = PersonInfo.Gender.ToString();
            lblNationalNO.Text = PersonInfo.NationalNO.ToString();
            if (PersonInfo.Gender.ToString() == "Male")
            {
                PBGendor.ImageLocation = "E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Man 32.png";
                PBImage.ImageLocation = "E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Male 512.png";
            }
            else
            {
                PBGendor.ImageLocation = "E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Woman 32.png";
                PBImage.ImageLocation = "E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Woman 32.png";
            }
            if (PersonInfo.ImagePath != "")
            {
                PBImage.ImageLocation = PersonInfo.ImagePath;
            }



            lblDriverID.Text = LicenseInfo._DriverID.ToString();
            lblExpirationDate.Text = LicenseInfo._ExpirationDate.ToString();
            if (LicenseInfo._IsActive)
            {
                lblIsActive.Text = "Yes ";
            }
            else
            {
                lblIsActive.Text = "NO";
            }
            lblIssueDate.Text = LicenseInfo._IssueDate.ToString();

            lblLocalLicenseID.Text = LicenseInfo._InternationalLicenseID.ToString();
          
            lblLLApplicationID.Text = _ApplicationID.ToString();
            lblLocalLicenseID.Text = clsDVLDBusinessInternationalLicense.GetInternationalLicenseInfoByApplicationID(_ApplicationID)._IssuedUsingLocalLicenseID.ToString();



        }

        private void CTRL_International_Driver_Info_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
