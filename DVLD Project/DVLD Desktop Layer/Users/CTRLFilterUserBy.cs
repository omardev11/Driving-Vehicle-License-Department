using DVLDBusinessPeople;
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
    public partial class CTRLFilterUserBy : UserControl
    {
        public CTRLFilterUserBy()
        {
            InitializeComponent();
        }
        public static int _ID = -1;
        public void FilterFocus()
        {
            txtFiltiringValue.Focus();
        }
        public void LoadData()
        {
            CTRLPersonDetails Emptyperson = new CTRLPersonDetails();
            groupBox1.Controls.Add(Emptyperson);
        }

        private bool _GetPersonInformationByNationalNO(string ColumnType, string ValueType)
        {

            DataTable dfilter = clsDVLDBusinessPeople.GetAllPeopleBY(ColumnType,ValueType);





            bool isFound = false;
            //DataTable dfilter = clsDVLDBusinessPeople.GetAllPeopleNationalNO();
            
            foreach (DataRow row in dfilter.Rows)
            {
               if ( row[ColumnType].ToString() ==  txtFiltiringValue.Text.ToUpper() )
                {
                    isFound = true;
                    break;
                }
            }
            if ( isFound )
            {
                if (ColumnType.ToUpper() == "NationalNo".ToUpper())
                {
                    clsDVLDBusinessPeople Person = clsDVLDBusinessPeople.FindByNationalNO(txtFiltiringValue.Text);
                    _ID = Person.PerosnID;
                }
                else if (ColumnType == "PersonID")
                {
                    clsDVLDBusinessPeople Person = clsDVLDBusinessPeople.Find(Convert.ToInt32(txtFiltiringValue.Text));
                    _ID = Person.PerosnID;
                }

              
            }
            else
            {
                isFound = false;
            }

            return isFound;
        }
        private void _TakenPersonIDdata(int ID)
        {
            _ID = ID; 
        }
        
        private void txtFiltiringValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_GetPersonInformationByNationalNO(CBFiltiringBy.Text,txtFiltiringValue.Text))
            {
               
                    groupBox1.Controls.Clear();
                    CTRLPersonDetails Fullperson = new CTRLPersonDetails(_ID);
                    groupBox1.Controls.Add(Fullperson);
               
            }
            else
            {
                MessageBox.Show($"The person Whith this {CBFiltiringBy.Text} Is not Exist");
            }

        }

        private void CTRLFilterUserBy_Load(object sender, EventArgs e)
        {
            CTRLPersonDetails Emptyperson = new CTRLPersonDetails();
            groupBox1.Controls.Add(Emptyperson);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo addEdit = new AddEditPersonInfo(-1);

            addEdit.DataBackToUserForm += _TakenPersonIDdata;

            addEdit.ShowDialog();

            groupBox1.Controls.Clear();
            CTRLPersonDetails Fullperson = new CTRLPersonDetails(_ID);
            groupBox1.Controls.Add(Fullperson);

        }
    }
}
