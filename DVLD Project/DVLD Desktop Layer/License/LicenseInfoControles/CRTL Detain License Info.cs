using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.Controles
{
    public partial class CRTL_Detain_License_Info : UserControl
    {
        private int _LocalLicenseID = -1;
        public int _DetainID = -1;
        public string Finefees = "";
        private bool _isDetained = false;
        public CRTL_Detain_License_Info()
        {
            InitializeComponent();
            _loadData();
        }
        public CRTL_Detain_License_Info(int localLicenseID,bool IsDetain)
        {
            InitializeComponent();
            _LocalLicenseID = localLicenseID;
            if (IsDetain)
            {
                _LoadDataAndDetainLicense();
            }
            else
            {
                _loadDataWhithLocalLicenseID();
            }
        }


        private void _loadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();
        }
        private void _loadDataWhithLocalLicenseID()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();
            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
        }
        private void _LoadDataAndDetainLicense()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblCreatedByuserID.Text = Global_Settings.UserID.ToString();
            lblLocalLicenseID.Text = _LocalLicenseID.ToString();

            Finefees = Global_Settings.StoreFineFeesForDetainedLicenseTemparory;
            decimal FineFees;
        
            FineFees = Convert.ToDecimal(Finefees);
            _DetainID = clsDVLDBusinessDetainedLicenses.AddNewDetainedLicensesApplication(_LocalLicenseID,FineFees, Global_Settings.UserID);

        }
        private void CRTL_Detain_License_Info_Load(object sender, EventArgs e)
        {

        }

        private void txtFineFees_TextChanged(object sender, EventArgs e)
        {
            if (!_isDetained)
            {
                Global_Settings.StoreFineFeesForDetainedLicenseTemparory = txtFineFees.Text;
            }
        }
    }
}
