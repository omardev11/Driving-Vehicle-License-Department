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

namespace DVLDDesltopFrontLayer.Users
{
    public partial class User_Details : Form
    {
        private int _UserID = -1;
        public User_Details(int ID)
        {
            InitializeComponent();
            _UserID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void User_Details_Load(object sender, EventArgs e)
        {
            CTRLUserDetails UserDetails = new CTRLUserDetails(_UserID);
            GBpersonInfo.Controls.Add(UserDetails);

        }
    }
}
