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

namespace DVLDDesltopFrontLayer
{
    public partial class Update_Test_Type : Form
    {
        private int _ApplicationTypeID = 0;
        clsDVLDBusinessTestTypes applicationType;
        public Update_Test_Type(int ID)
        {
            InitializeComponent();
            _ApplicationTypeID = ID;
        }

        private void _loadData()
        {
            applicationType = clsDVLDBusinessTestTypes.FindCTestTypeByID(_ApplicationTypeID);

            lblID.Text = applicationType.TestTypeID.ToString();
            txtTitle.Text = applicationType.TestTypeTitle.ToString();
            txtFees.Text = applicationType.Fees.ToString();
            txtDescripton.Text = applicationType.Description;
        }

        private void _UpdateData()
        {
            applicationType.TestTypeTitle = txtTitle.Text;
            applicationType.Fees = Convert.ToDecimal(txtFees.Text);
            applicationType.Description = txtDescripton.Text;
        }

        private bool _Save()
        {
            return clsDVLDBusinessTestTypes.UpdateTestType(applicationType.TestTypeID, applicationType.TestTypeTitle, applicationType.Fees ,applicationType.Description);
        }

        private void Update_Test_Type_Load(object sender, EventArgs e)
        {
            _loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _UpdateData();
            if (_Save())
            {
                MessageBox.Show("Updated Succesfully");
            }
            else
            {
                MessageBox.Show("Did not Updated Succesfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
