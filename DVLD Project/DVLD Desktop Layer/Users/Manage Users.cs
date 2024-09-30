using DVLDBusinessLayer;
using DVLDBusinessPeople;
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
    public partial class Manage_Users : Form
    {
        public Manage_Users()
        {
            InitializeComponent();
        }

        ~Manage_Users() 
        {
            //txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
        }

        private void _RefreshUsersInformationBy(string ColumnName, string ValueType)
        {
            DataTable dfilter = clsDVLDBusinessUsers.GetAllUsersBy(ColumnName, ValueType);
            DGVUserList.DataSource = dfilter;
            lblRecordCount.Text = dfilter.Rows.Count.ToString();
            if (dfilter.Rows.Count > 0)
            {
                DGVUserList.Columns["FullName"].Width = 200;
            }



        }
        private void _RefreshUsersList()
        {
            DGVUserList.DataSource = clsDVLDBusinessUsers.GetAllUsersForList();

            DGVUserList.Columns["FullName"].Width = 200;

            lblRecordCount.Text = DGVUserList.RowCount.ToString();  
        }

        private void _GetActiveUsersList()
        {
            DGVUserList.DataSource = clsDVLDBusinessUsers.GetAllUsersIsActive();
            
            if (DGVUserList.Rows.Count > 0)
            {
                DGVUserList.Columns["FullName"].Width = 200;
            }

            lblRecordCount.Text = DGVUserList.RowCount.ToString();
        }

        private void _GetNonActiveUsersList()
        {
            DGVUserList.DataSource = clsDVLDBusinessUsers.GetAllUsersIsNotActive();

            if (DGVUserList.Rows.Count > 0)
            {
                DGVUserList.Columns["FullName"].Width = 200;
            }

            lblRecordCount.Text = DGVUserList.RowCount.ToString();
        }

        private void Manage_Users_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Add_Edit_User User = new Add_Edit_User();

            User.ShowDialog();
            _RefreshUsersList();

        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_User User = new Update_User((int)DGVUserList.CurrentRow.Cells[0].Value);

            User.ShowDialog();
            _RefreshUsersList();

        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Edit_User User = new Add_Edit_User();

            User.ShowDialog();
            _RefreshUsersList();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Details Udetails = new User_Details((int)DGVUserList.CurrentRow.Cells[0].Value);
            Udetails.ShowDialog();
            _RefreshUsersList();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Change_Password change_ = new Change_Password((int)DGVUserList.CurrentRow.Cells[0].Value);

            change_.ShowDialog();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Delete This User","Conform Delete",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsDVLDBusinessUsers.DeleteUser((int)DGVUserList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Sucesfully");
                    _RefreshUsersList();

                }
                else
                {
                    MessageBox.Show("User did not Deleted Sucesfully");
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtFiltiringValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshUsersInformationBy(CBFiltiringBy.Text,txtFiltiringValue.Text);
            txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
            if (CBFiltiringBy.Text == "PersonID" || CBFiltiringBy.Text == "UserID")
            {
                txtFiltiringValue.KeyPress += txtFiltiringValue_KeyPress;

            }
            //else if (CBFiltiringBy.Text == "FullName")
            //{
            //    txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
            //}
        }

        private void txtFiltiringValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CBActiveYesorNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBActiveYesorNO.Text == "All")
            {
                _RefreshUsersList();
            }
            else if (CBActiveYesorNO.Text == "Yes")
            {
                _GetActiveUsersList();
            }
            else if (CBActiveYesorNO.Text == "No")
            {
                _GetNonActiveUsersList();
            }
        }

        private void CBFiltiringBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFiltiringBy.Text == "IsActive")
            {
                txtFiltiringValue.Visible = false;
                CBActiveYesorNO.Visible = true;
            }
            else
            {
                txtFiltiringValue.Visible = true;
                CBActiveYesorNO.Visible = false;
            }
        }
    }
}
