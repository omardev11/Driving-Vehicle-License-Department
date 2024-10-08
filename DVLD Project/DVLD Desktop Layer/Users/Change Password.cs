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
    public partial class Change_Password : Form
    {
        private int _UserID = -1;
        private string _CrypPassaword;
        clsDVLDBusinessUsers _User;
        public Change_Password(int ID)
        {
            InitializeComponent();
            this._UserID = ID;
           _User = clsDVLDBusinessUsers.FindUserByID(this._UserID);
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            CTRLUserDetails UserDetails = new CTRLUserDetails(_UserID);
            groupBox1.Controls.Add(UserDetails);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _CrypPassaword = Global_Settings.ComputeHash(txtCurrentPassword.Text);

                       
            if (_User.Password == _CrypPassaword)
            {
                _User.Password = txtNewPassword.Text;
                if (_User.Save())
                {
                    MessageBox.Show("The  Password Updated Sucesfully");
                }
                else
                {
                    MessageBox.Show("The  Password is not Updated Sucesfully");
                }
            }
            else
            {
                MessageBox.Show("The Current Password is Wrong");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            _CrypPassaword = Global_Settings.ComputeHash(txtCurrentPassword.Text);

            if (_User.Password != _CrypPassaword)
            {
                errorProvider1.SetError(txtCurrentPassword, "Passaword is Wrong");
            }
            else
            {

                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "Passaword Can not Be Empty");
            }
            else
            {

                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConformPassword_Validating(object sender, CancelEventArgs e)
        {
            if ((txtConformPassword.Text != txtNewPassword.Text))
            {
                errorProvider1.SetError(txtConformPassword, "Password Conformation does not match Password");
            }
            else
            {

                errorProvider1.SetError(txtConformPassword, "");
            }
        }

      
    }
}
