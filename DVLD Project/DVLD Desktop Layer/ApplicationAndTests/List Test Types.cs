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

namespace DVLDDesltopFrontLayer
{
    public partial class List_Test_Types : Form
    {
        public List_Test_Types()
        {
            InitializeComponent();
        }

        private void _RefreshTestTypesList()
        {
            DGVTestTypesList.DataSource = clsDVLDBusinessTestTypes.GetAllTestTypes();

            DGVTestTypesList.Columns["TestTypeTitle"].Width = 200;
            DGVTestTypesList.Columns["TestTypeDescription"].Width = 250;
            lblRecordCount.Text = DGVTestTypesList.RowCount.ToString();

        }


    
        private void List_Test_Types_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Test_Type test_Type = new Update_Test_Type((int)DGVTestTypesList.CurrentRow.Cells[0].Value);

            test_Type.ShowDialog();
            _RefreshTestTypesList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
