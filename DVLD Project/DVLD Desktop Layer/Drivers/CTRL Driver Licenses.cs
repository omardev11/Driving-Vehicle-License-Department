using DVLDBusinessLayer;
using DVLDDesltopFrontLayer.License;
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
    public partial class CTRL_Driver_Licenses : UserControl
    {
        private int _DriverID = -1;
        clsDVLDBusinessDriver DriverInfo;
        public CTRL_Driver_Licenses(int ID)
        {
            InitializeComponent();
            _DriverID = ID;

        }
        public CTRL_Driver_Licenses()
        {
            InitializeComponent();

        }

        public void LoadDriverLicenseInfo(int DriverID) 
        {
            _DriverID = DriverID;
            _LoadData();

        }
        private void _LoadData()
        {
            DriverInfo = clsDVLDBusinessDriver.FindByDriverID(_DriverID);

            if (DriverInfo == null) 
            {
                MessageBox.Show($"There Is no Driver Whith ID {_DriverID} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DGVApplicationList.DataSource = DriverInfo.GetThisDriverAllLicenses();


            if (DGVApplicationList.RowCount > 0 )
            {
                DGVApplicationList.Columns["ClassName"].Width = 200;
                DGVApplicationList.Columns["IssueDate"].Width = 150;
                DGVApplicationList.Columns["ExpirationDate"].Width = 150;
            }
            lblRecordCount.Text = DGVApplicationList.RowCount.ToString();



            DGInternationalHIstory.DataSource = DriverInfo.GetAllInternationalLicenseForThisDriver();

            if (DGInternationalHIstory.RowCount > 0 )
            {
                DGInternationalHIstory.Columns["InternationalLicenseID"].Width = 200;
                DGInternationalHIstory.Columns["IssueDate"].Width = 150;
                DGInternationalHIstory.Columns["ExpirationDate"].Width = 150;
            }
            lblInternationlaRecourdCount.Text = DGInternationalHIstory.RowCount.ToString();

        }
        private void CTRL_Driver_Licenses_Load(object sender, EventArgs e)
        {
            //_LoadData();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License_Info license_Info = new License_Info((int)DGVApplicationList.CurrentRow.Cells[1].Value, false);

            license_Info.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            License_Info license_Info = new License_Info((int)DGInternationalHIstory.CurrentRow.Cells[1].Value, true);

            license_Info.ShowDialog();
        }
    }
}
