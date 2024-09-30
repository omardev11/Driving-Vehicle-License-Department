using DVLDBusinessLayer;
using DVLDBusinessPeople;
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
    public partial class Add_Edit_User : Form
    {

      

        private int _UserID;
        private int _PersonID = 0;


        clsDVLDBusinessUsers _User;
        public Add_Edit_User()
        {
            InitializeComponent();
        }

        private void _UPdateData()
        {
            _User = new clsDVLDBusinessUsers();
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassaword.Text;
            _User.IsActive = ChbIsActive.Checked;
            _User.PersonID = _PersonID;
        }

     

       
        private void button1_Click_1(object sender, EventArgs e)
        {
             _PersonID = CTRLFilterUserBy._ID;

            if (_PersonID != -1)
            {
                if (clsDVLDBusinessUsers.IsThisPersonUser(_PersonID))
                {
                    MessageBox.Show("This Person is User");
                }
                else
                {
                    tabControl1.TabPages[1].Enabled = true;
                    tabControl1.SelectedIndex = 1;
                }

            }
            else
            {
                MessageBox.Show("You Must Choise A person Or Add New One");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _UPdateData();
            if (_User.Save())
            {
                MessageBox.Show("User Added Succesfully");
                lblUserID.Text = _User.UserID.ToString();
            }
            else
            {
                MessageBox.Show("User Din't Added Succesfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox4_Validating(object sender, CancelEventArgs e)
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

        private void Add_Edit_User_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[1].Enabled = false;

            ctrlFilterUserBy2.LoadData();
        }


    }
}
