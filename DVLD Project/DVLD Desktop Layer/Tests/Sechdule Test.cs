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

namespace DVLDDesltopFrontLayer.Tests
{
    public partial class Sechdule_Test : Form
    {
        private clsDVLDBusinessTestTypes.enTestType _enTestTypeID = clsDVLDBusinessTestTypes.enTestType.VisionTest;

        enum enMode { UpdateMode = 1, AddMode = 2 };
        private enMode _Mode;
        private int _DLApplicationID = -1;
        private int _TestTypeID = -1;
        private int _AppoinMentID = -1;
        public Sechdule_Test(int ID, int TesttypeID)
        {
            InitializeComponent();
            _DLApplicationID = ID;
            _TestTypeID = TesttypeID;
            _Mode = enMode.AddMode;
        }

        public Sechdule_Test(int AppoinmentID)
        {
            InitializeComponent();
            _AppoinMentID = AppoinmentID;
            _Mode = enMode.UpdateMode;
        }

        private void _LoadData1()
        {
            if (_TestTypeID == 2)
            {
                _enTestTypeID = clsDVLDBusinessTestTypes.enTestType.WrittenTest;

            }
            if (_TestTypeID == 3)
            {
                _enTestTypeID = clsDVLDBusinessTestTypes.enTestType.StreetTest;

            }
            ctrL_Vision_Test1.TestTypeID = _enTestTypeID;
            switch (_Mode)
            {
                case enMode.UpdateMode:
                    ctrL_Vision_Test1._loadUpdateMode(_AppoinMentID);
                    break;
                case enMode.AddMode:
                    ctrL_Vision_Test1._loadAddMode(_DLApplicationID, _TestTypeID);
                    break;
            }
        }

        private void Sechdule_Test_Load(object sender, EventArgs e)
        {
            _LoadData1();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
