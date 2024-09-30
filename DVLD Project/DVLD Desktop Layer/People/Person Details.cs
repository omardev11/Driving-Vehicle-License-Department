using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDesltopFrontLayer
{
    public partial class Person_Details : Form
    {
        private int _ID = 0;
        public Person_Details(int iD)
        {
            InitializeComponent();
            _ID = iD;
        }

        private void Person_Details_Load(object sender, EventArgs e)
        {

            ctrlPersonDetails1._LoadData(_ID);



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
