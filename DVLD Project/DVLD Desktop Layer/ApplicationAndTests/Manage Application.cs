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
    public partial class Manage_Application : Form
    {
        public Manage_Application()
        {
            InitializeComponent();
        }

        private void _RefreshApplicationTypesList()
        {
            DGVApplicationTypesList.DataSource = clsDVLDBusinessApplicationTypes.GetAllApplicationTypes();
            
            DGVApplicationTypesList.Columns["ApplicationTypeTitle"].Width = 250;
            lblRecordCount.Text = DGVApplicationTypesList.RowCount.ToString();

        }
        private void Manage_Application_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Aplication_Types update_ = new Update_Aplication_Types((int)DGVApplicationTypesList.CurrentRow.Cells[0].Value);

            update_.ShowDialog();
            _RefreshApplicationTypesList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
