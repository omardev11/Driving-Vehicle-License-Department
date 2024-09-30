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

namespace DVLDDesltopFrontLayer.Users
{
    public partial class Update_User : Form
    {
        private int _UserID = 0;

        clsDVLDBusinessUsers _User;

        public Update_User(int ID)
        {
            InitializeComponent();
            this._UserID = ID;
            _loadData();
        }
        private void _loadData()
        {
            _User = clsDVLDBusinessUsers.FindUserByID(_UserID);


            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassaword.Text = _User.Password;
            txtPConformassword.Text = _User.Password;
            ChbIsActive.Checked = _User.IsActive;



        }

        private void _UPdateData()
        {
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassaword.Text;
            _User.IsActive = ChbIsActive.Checked;
            _User.PersonID = _User.PersonID;
        }
        private void Update_User_Load(object sender, EventArgs e)
        {
            CTRLPersonDetails personDetails = new CTRLPersonDetails(_User.PersonID);

            groupBox1.Controls.Add(personDetails);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TControl.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _UPdateData();
            if (_User.Save())
            {
                MessageBox.Show("User Updated Succesfully");
            }
            else
            {
                MessageBox.Show("User Din't Updated Succesfully");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "User Name Can not Be Empty");
            }
            else
            {

                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassaword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassaword.Text))
            {
                errorProvider1.SetError(txtPassaword, "Passaword Can not Be Empty");
            }
            else
            {

                errorProvider1.SetError(txtPassaword, "");
            }
        }

        private void txtPConformassword_Validating(object sender, CancelEventArgs e)
        {
            if ((txtPConformassword.Text != txtPassaword.Text))
            {
                errorProvider1.SetError(txtPConformassword, "Password Conformation does not match Password");
            }
            else
            {

                errorProvider1.SetError(txtPConformassword, "");
            }
        }
    }
}
