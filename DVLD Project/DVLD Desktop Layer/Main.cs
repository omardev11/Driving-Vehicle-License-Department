using DVLDDesltopFrontLayer.Applications;
using DVLDDesltopFrontLayer.Drivers;
using DVLDDesltopFrontLayer.License;
using DVLDDesltopFrontLayer.Users;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void _GetAllApplicationTypes()
        {

        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_People manage_People = new Manage_People();

            manage_People.ShowDialog();
        }

      

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Users users = new Manage_Users();
            users.ShowDialog();
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Details _Details = new User_Details(Global_Settings.UserID);

            _Details.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Password change_Password = new Change_Password(Global_Settings.UserID);

            change_Password.ShowDialog();   
        }


        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List_Test_Types list_Test_Types = new List_Test_Types();

            list_Test_Types.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Application manage_Application = new Manage_Application();

            manage_Application.ShowDialog();
        }

       
        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Application local_Driving = new Local_Driving_License_Application(false,false);

            local_Driving.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Local_Driving_License_Application new_Local_Driving_License_ = new New_Local_Driving_License_Application();

            new_Local_Driving_License_.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List_Drivers list_Drivers = new List_Drivers();

            list_Drivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_ = new New_International_License_Application(Global_Settings.NewInternationalLicense);

            new_International_License_.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Application local_Driving = new Local_Driving_License_Application(true,false);

            local_Driving.ShowDialog();
        }

        private void renewDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_ = new New_International_License_Application(Global_Settings.RenewDrivingLicenseService);

            new_International_License_.ShowDialog();
        }

        private void replacementForLostOrDamagedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_ = new New_International_License_Application(Global_Settings.ReplacementforaDamagedDrivingLicense);

            new_International_License_.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_ = new New_International_License_Application(Global_Settings.DetainLicenseApplicationTypeID);

            new_International_License_.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_ = new New_International_License_Application(Global_Settings.ReleaseDetainedDrivingLicsense);

            new_International_License_.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Application local_Driving = new Local_Driving_License_Application(false, true);

            local_Driving.ShowDialog();
        }

        private void releaseDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_International_License_Application new_International_License_ = new New_International_License_Application(Global_Settings.ReleaseDetainedDrivingLicsense);

            new_International_License_.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Application local_Driving = new Local_Driving_License_Application(false, false);

            local_Driving.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
