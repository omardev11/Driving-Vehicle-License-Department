using DVLDBusinessLayer;
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

namespace DVLDDesltopFrontLayer.License
{
    public partial class License_History : Form
    {
        private int _ApplicationID = -1;
        public License_History(int ID)
        {
            InitializeComponent();
            _ApplicationID = ID;
        }

        private void _LoadData()
        {
            clsDVLDBusinessLicense LicenseInfo =  clsDVLDBusinessLicense.GetLicenseInfoByApplicationID(_ApplicationID);

          
            ctrlPersonDetails1._LoadData(LicenseInfo.DriverInfo.PersonID);

            ctrL_Driver_Licenses1.LoadDriverLicenseInfo(LicenseInfo._DriverID);
        }
        private void License_History_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
