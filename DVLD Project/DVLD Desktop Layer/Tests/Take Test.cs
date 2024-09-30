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

namespace DVLDDesltopFrontLayer.Tests
{
    public partial class Take_Test : Form
    {
        private int _AppoinmentID = -1;
        private DateTime _AppoinmentDate = DateTime.Now;

        private clsDVLDBusinessTestTypes.enTestType _enTestTypeID = clsDVLDBusinessTestTypes.enTestType.VisionTest;

        public Take_Test(int AppoinmentID,DateTime AppoinmentDate)
        {
            InitializeComponent();
            _AppoinmentID = AppoinmentID;
            _AppoinmentDate = AppoinmentDate;
        }

        private void _LoadData()
        {
            if (clsDVLDBusinessTestAppoinments.Find(_AppoinmentID).TestTypeID == clsDVLDBusinessTestTypes.enTestType.WrittenTest)
            {
                _enTestTypeID = clsDVLDBusinessTestTypes.enTestType.WrittenTest;

            }
            if (clsDVLDBusinessTestAppoinments.Find(_AppoinmentID).TestTypeID == clsDVLDBusinessTestTypes.enTestType.StreetTest)
            {
                _enTestTypeID = clsDVLDBusinessTestTypes.enTestType.StreetTest;

            }
            ctrL_Vision_Test1.TestTypeID = _enTestTypeID;
            if (!clsDVLDBusinessTestTypes.IsThisAppoinmentLocked(_AppoinmentID))
            {
                MessageBox.Show("This Test Is Locked You Can Not Make Any Changes Here","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                ctrL_Vision_Test1._loadTAkeTest(_AppoinmentID, _AppoinmentDate);

            }
          
        }
        private void _Save()
        {
            int TestID = -1;
            bool TestResult = rdbPass.Checked;

            bool IsUnActivatedTheAppoinment = clsDVLDBusinessTestTypes.unActivatedAppointment(_AppoinmentID);
            TestID = clsDVLDBusinessTestTypes.AddNewTest(_AppoinmentID, TestResult, txtNotes.Text, Global_Settings.UserID);
            if (TestID != -1 && IsUnActivatedTheAppoinment == true)
            {
                MessageBox.Show("Data Saved Succesfully","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblTestID.Text = TestID.ToString();
                rdbFail.Enabled = false;
                rdbPass.Enabled = false;
            }
            else
            {
                MessageBox.Show("Data did not Saved Succesfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void Take_Test_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Save? After That You Can not Change This Pass/Fail Result After Save","Conform",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Save();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrL_Vision_Test1_Load(object sender, EventArgs e)
        {

        }
    }
}
