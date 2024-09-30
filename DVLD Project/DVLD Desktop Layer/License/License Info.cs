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
    public partial class License_Info : Form
    {
        private int _ApplicationID = -1;
        private bool _IsInternationalLicenseApplication = false;
        public License_Info(int ID,bool IsInternationalLicenseApp)
        {
            InitializeComponent();
            _ApplicationID = ID;
            _IsInternationalLicenseApplication= IsInternationalLicenseApp;
        }

        private void _LoadData()
        {
            if (_IsInternationalLicenseApplication)
            {
                this.Text = "InterNational Driver Info";
                lblTopic.Text = "Driver International License Info";
                PBInternational.Visible = true;

                CTRL_International_Driver_Info cTRL_International_Driver_Info = new CTRL_International_Driver_Info(_ApplicationID);

                groupBox1.Controls.Add(cTRL_International_Driver_Info);
            }
            else
            {

                CTRL_Driver_License_Info cTRL_Driver_License_Info = new CTRL_Driver_License_Info(_ApplicationID);

                groupBox1.Controls.Add(cTRL_Driver_License_Info);

            }
           

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void License_Info_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
