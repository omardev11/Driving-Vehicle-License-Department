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
    public partial class Update_Aplication_Types : Form
    {
        private int _ApplicationTypeID = 0;
        clsDVLDBusinessApplicationTypes applicationType;
        public Update_Aplication_Types(int ID)
        {
            InitializeComponent();
            _ApplicationTypeID = ID;
        }

        private void _loadData()
        {
             applicationType = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(_ApplicationTypeID);

            lblID.Text = applicationType.ApplicationTypeID.ToString();
            txtTitle.Text = applicationType.ApplicationTypeName.ToString();
            txtFees.Text = applicationType.Fees.ToString();
        }

        private void _UpdateData()
        {


            applicationType.ApplicationTypeName = txtTitle.Text;
            applicationType.Fees = Convert.ToDecimal(txtFees.Text);
        }

        private bool _Save()
        {
            return clsDVLDBusinessApplicationTypes.UpdateApplicationType(applicationType.ApplicationTypeID,applicationType.ApplicationTypeName,applicationType.Fees);
        }


        private void Update_Aplication_Types_Load(object sender, EventArgs e)
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
