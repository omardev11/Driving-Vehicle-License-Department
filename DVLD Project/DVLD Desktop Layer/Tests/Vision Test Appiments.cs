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
    public partial class Vision_Test_Appiments : Form
    {
        private int DLAppID = -1;
        private int _TestTypeID = -1;
        public Vision_Test_Appiments(int ID,int TestTypeID)
        {
            InitializeComponent();
            DLAppID = ID;
            _TestTypeID = TestTypeID;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void _RefreshAppoinmeViewTable()
        {

            DGTestAppoinmentView.DataSource = clsDVLDBusinessTestTypes.GetAllAppinmentsWhithThisLocalDrivingLicenseApplicantPersonByID(DLAppID,_TestTypeID);
            lblRecordCount.Text = DGTestAppoinmentView.RowCount.ToString();
        }

        private void _loadData()
        {
           
         
                switch (_TestTypeID)
            {
                case 1:
                    this.Text = "Vision Test Appoinment";
                    lblTiitle.Text = "Vision Test Appoinment";
                    break;
                case 2:
                    this.Text = "Written Test Appoinment";
                    lblTiitle.Text = "Written Test Appoinment";
                    pictureBox1.ImageLocation = "E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\Written Test 512.png";

                        break;
                case 3:
                    this.Text = "Street Test Appoinment";
                    lblTiitle.Text = "Street Test Appoinment";
                    pictureBox1.ImageLocation = "E:\\apps\\c++\\programing advice course\\C# and Database connective\\DVLDProject\\Icons\\driving-test 512.png";
                        break;
            }
            CTRL_D_L_Application cTRL_D_L_Application = new CTRL_D_L_Application(DLAppID);
            groupBox1.Controls.Add(cTRL_D_L_Application);
            _RefreshAppoinmeViewTable();
           
            
        }

        private void _AddAppoinment()
        {

            if (clsDVLDBusinessLocalApplication.IsThisLicenseClassCancelled(DLAppID))
            {
                MessageBox.Show("This Person's Application Is Cancelled You can not Make New Appoinment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (clsDVLDBusinessTestTypes.IsThisLocalDrivingLicenseApplicationHasAnActiveAppoinment(DLAppID))
                {
                    MessageBox.Show("This Person Already Have an Active Appoinment For This Test You can not Add New Appoinment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (clsDVLDBusinessTestTypes.IsPass(DLAppID, _TestTypeID))
                    {
                        MessageBox.Show("This Person Already Pass This Test Before You Can Only Retake Failed Tests", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        Sechdule_Test sechdule_Test = new Sechdule_Test(DLAppID, _TestTypeID);

                        sechdule_Test.ShowDialog();

                        _RefreshAppoinmeViewTable();

                    }

                }
            }
        }

        private void Vision_Test_Appiments_Load(object sender, EventArgs e)
        {
            _loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _AddAppoinment();   
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sechdule_Test sechdule_Test = new Sechdule_Test((int)DGTestAppoinmentView.CurrentRow.Cells[0].Value);

            sechdule_Test.ShowDialog();

            _RefreshAppoinmeViewTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Take_Test take_Test = new Take_Test((int)DGTestAppoinmentView.CurrentRow.Cells[0].Value,(DateTime)DGTestAppoinmentView.CurrentRow.Cells[1].Value);

            take_Test.ShowDialog();

            _RefreshAppoinmeViewTable();
        }
    }
}
