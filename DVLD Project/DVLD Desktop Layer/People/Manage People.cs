using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessPeople;

namespace DVLDDesltopFrontLayer
{
    public partial class Manage_People : Form
    {
        public Manage_People()
        {
            InitializeComponent();
        }

        DataTable _dfilter = clsDVLDBusinessPeople.GetAllPeople();


        private void _RefreshPeopleInformation()
        {
            DGVpeopleList.DataSource = _dfilter;
            lblRecordCount.Text = _dfilter.Rows.Count.ToString();

        }


        private void _RefreshPeopleInformationBy(string ColumnName, string ValueType)
        {

            _dfilter.DefaultView.RowFilter = string.Format("CONVERT([{0}], 'System.String') LIKE '{1}%'", ColumnName, ValueType.Trim());
            lblRecordCount.Text = DGVpeopleList.Rows.Count.ToString();

        }

        private void Manage_People_Load(object sender, EventArgs e)
        {
            _RefreshPeopleInformation();
        }

        private void txtFiltiringValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshPeopleInformationBy(CBFiltiringBy.Text, txtFiltiringValue.Text);
            if (CBFiltiringBy.Text == "PersonID" ||  CBFiltiringBy.Text == "NationalityCountryID" ||  CBFiltiringBy.Text == "Phone")
            {
                txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
                txtFiltiringValue.KeyPress += txtFiltiringValue_KeyPress;


            }
            else
            {
                txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
              

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFiltiringValue.KeyPress -= txtFiltiringValue_KeyPress;
            this.Close();
        }

        

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DGVpeopleList.CurrentRow.Cells[0].Value;
            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo(PersonID);

            addEditPersonInfo.ShowDialog();
            _RefreshPeopleInformation();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo(-1);

            addEditPersonInfo.ShowDialog();
            _dfilter = clsDVLDBusinessPeople.GetAllPeople();
            _RefreshPeopleInformation();

           

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person_Details _Details = new Person_Details((int)DGVpeopleList.CurrentRow.Cells[0].Value);

            _Details.ShowDialog();
            _RefreshPeopleInformation();

        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want to Delete This Person","Conform Delete",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clsDVLDBusinessPeople.DeletePerson((int)DGVpeopleList.CurrentRow.Cells[0].Value);
                _dfilter = clsDVLDBusinessPeople.GetAllPeople();
                _RefreshPeopleInformation();
            }
           
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo(-1);

            addEditPersonInfo.ShowDialog();
            _dfilter = clsDVLDBusinessPeople.GetAllPeople();
            _RefreshPeopleInformation();
        }

        private void txtFiltiringValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void CBFiltiringBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFiltiringBy.Text.ToUpper() != "NONE")
            {
                txtFiltiringValue.Visible= true;
            }
            else
            {
                txtFiltiringValue.Visible= false;
            }
        }
    }
}
