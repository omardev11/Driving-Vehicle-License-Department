using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace DVLDDesltopFrontLayer
{
    public partial class AddEditPersonInfo : Form
    {
        private int _ID = -1;
        private int _PersonID = -1;
        private string _OldImagePath = "";


        public delegate void DataBackEventHandlerForForm(int PersonID);

        public event DataBackEventHandlerForForm DataBackToUserForm;

        public AddEditPersonInfo(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

      
        private void DeleteImageFromFolder(string ImagePath)
        {
            if (File.Exists(ImagePath))
            {

                    File.Delete(ImagePath);
            }
        }
        private void TakenPersonID(int ID, string OldImagePath)
        {
            _PersonID = ID;
            _OldImagePath = OldImagePath;
        }
        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {
            
            CTRLAddEditPerson CtrladdEdit = new CTRLAddEditPerson(_ID);

            CtrladdEdit.DataBack += TakenPersonID;

            panel1.Controls.Add(CtrladdEdit);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAddeEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           DataBackToUserForm?.Invoke(_PersonID);
            this.Close();
            
        }
    }
}
