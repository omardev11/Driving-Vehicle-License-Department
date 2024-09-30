using DVLDBusinessLayer;
using DVLDBusinessPeople;
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
using System.Windows.Forms.VisualStyles;

namespace DVLDDesltopFrontLayer.Drivers
{
    public partial class List_Drivers : Form
    {
        public List_Drivers()
        {
            InitializeComponent();
        }

        private void _RefreshDriverInformation()
        {
            DataTable dt = clsDVLDBusinessDriver.GetAllDrivers();
            DGVpeopleList.DataSource = dt;
            if (DGVpeopleList.Rows.Count > 0 )
            {
                DGVpeopleList.Columns["FullName"].Width = 200;
                DGVpeopleList.Columns["CreatedDate"].Width = 150;
                DGVpeopleList.Columns["NumberOfActiveLicenses"].Width = 200;
            }
           
            lblRecordCount.Text = dt.Rows.Count.ToString();
        }
        private void _RefreshDriverInformationBy(string ColumnName, string ValueType)
        {
            DataTable dfilter = clsDVLDBusinessDriver.GetAllDriversBy(ColumnName, ValueType);
            DGVpeopleList.DataSource = dfilter;
            lblRecordCount.Text = dfilter.Rows.Count.ToString();
        }

        private void List_Drivers_Load(object sender, EventArgs e)
        {
            _RefreshDriverInformation();
        }

        private void txtFiltiringValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshDriverInformationBy(CBFiltiringBy.Text, txtFiltiringValue.Text);
            if (CBFiltiringBy.Text == "PersonID" || CBFiltiringBy.Text == "DriverID")
            {
                txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
                txtFiltiringValue.KeyPress += txtFiltiringValue_KeyPress;

            }
            else
            {
                txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
            }

        }

        private void txtFiltiringValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConMenuShowDetail_Click(object sender, EventArgs e)
        {
            Person_Details person_Details = new Person_Details((int)DGVpeopleList.CurrentRow.Cells[1].Value);

            person_Details.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsDVLDBusinessLicense DriverINfo = clsDVLDBusinessLicense.GetLicenseInfoByDriverID((int)DGVpeopleList.CurrentRow.Cells[0].Value);

            License_History license_History = new License_History(DriverINfo._ApplicationID);

            license_History.ShowDialog();
        }
    }
}
