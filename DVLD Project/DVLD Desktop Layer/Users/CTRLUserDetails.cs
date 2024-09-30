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

namespace DVLDDesltopFrontLayer.Controles
{
    public partial class CTRLUserDetails : UserControl
    {
        private int _UserID = -1;

        clsDVLDBusinessUsers _User;
        public CTRLUserDetails(int ID)
        {
            InitializeComponent();
            _UserID = ID;
        }

        private void CTRLUserDetails_Load(object sender, EventArgs e)
        {
          





            _User = clsDVLDBusinessUsers.FindUserByID(_UserID);
            CTRLPersonDetails UserDetails = new CTRLPersonDetails(_User.PersonID);
            GBpersonInfo.Controls.Add(UserDetails);
            lblUserID.Text = _UserID.ToString();
            lblUserName.Text = _User.UserName;
            if (_User.IsActive)
            {
                lblIsActive.Text = "Yes";
            }
            else
                lblIsActive.Text = "NO";
        }

     
    }
}
