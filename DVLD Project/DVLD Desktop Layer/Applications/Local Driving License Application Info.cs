using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer.Applications
{
    public partial class Local_Driving_License_Application_Info : Form
    {
        private int _DLApplicationsID = -1;
        public Local_Driving_License_Application_Info(int ID)
        {
            InitializeComponent();
            _DLApplicationsID = ID;
            ctrL_D_L_Application1.loadData(ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
