using DVLDBusinessLayer;
using DVLDBusinessPeople;
using DVLDDesltopFrontLayer.Properties;
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
using System.Xml.Schema;
using System.IO;

namespace DVLDDesltopFrontLayer
{
    public partial class CTRLPersonDetails : UserControl
    {
        public CTRLPersonDetails(int iD)
        {
            InitializeComponent();
            _ID = iD;
            _LoadData(iD);
        }

        public CTRLPersonDetails()
        {
            InitializeComponent();
        }

        private int _ID = 0;

        public void _LoadData(int ID)
        {
            _ID = ID;
            if (_ID != -1)
            {
                clsDVLDBusinessPeople _Person = clsDVLDBusinessPeople.Find(_ID);


                lblidea.Text = _Person.PerosnID.ToString();
                lblNatinalNo.Text = _Person.NationalNO;
                lblName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.Phone;
                lblAddress.Text = _Person.Address;
                lblDateofbirth.Text = _Person.DateOfBirth.ToString();
                lblCountry.Text = clsDVLDBusinessCountry.FindCountryByID(_Person.NationalCountryID).CountryName;

                if (_Person.Gender == "Male")
                    PBGendor.Image = Resources.Male_512;
                else
                    PBGendor.Image = Resources.Woman_32;
           

                lblGendor.Text = _Person.Gender;

               
                if (_Person.ImagePath != "")
                {
                    if (File.Exists(_Person.ImagePath))
                    {
                        picturePersonX.ImageLocation = _Person.ImagePath;
                    }
                    else
                        MessageBox.Show("Could not find this image: = " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          

        }


        private void CTRLPersonDetails_Load(object sender, EventArgs e)
        {
        }

        private void lblEditPerosn_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo addEditPersonInfo = new AddEditPersonInfo(_ID);

            addEditPersonInfo.ShowDialog();
            _LoadData(_ID);
        }


    }
}
