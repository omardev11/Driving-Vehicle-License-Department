using DVLDBusinessLayer;
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
using System.IO;
using DVLDDesltopFrontLayer.Properties;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDesltopFrontLayer
{
    public partial class CTRLAddEditPerson : UserControl
    {
        enum EnMode { UpdateMode = 1, AddMode = 2 }

        private EnMode _Mode = EnMode.AddMode;

        public delegate void DataBackEventHandler(int PersonID,string OldImagePath);

        public event DataBackEventHandler DataBack;

        clsDVLDBusinessPeople _Person;

        private int _ID = -1;
        private string _OldImagePath = "";
        private string _NewPictureImage = "";
     

        public CTRLAddEditPerson(int ID)
        {
            InitializeComponent();
            if (ID == -1)
                _Mode = EnMode.AddMode;
            else
                _Mode = EnMode.UpdateMode;
            _ID = ID;
        }
        private static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }
        private string _SaveImageIntoFolderAndDeleteTheOldONe(string ImagePath)
        {
            if (_Person.ImagePath != picturePerson.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        if (File.Exists(_Person.ImagePath))
                        {
                            File.Delete(_Person.ImagePath);
                        }
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }
            }

                string DestinationsFolder = @"E:\apps\c++\My Projects\DVLD project\DVLD Project\PersonsImages";

                string guide = Guid.NewGuid().ToString();

                string FileExtesnsion = Path.GetExtension(ImagePath);

                string FileName = guide + FileExtesnsion;

                string destanionPath = Path.Combine(DestinationsFolder, FileName);

                try
                {
                    File.Copy(ImagePath, destanionPath, true);
                }
                catch (IOException iox)
                {
                    MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return destanionPath;
            }

        
        private void _GetCountriesList()
        {
            DataTable dt = clsDVLDBusinessCountry.GetAllCountries();

            foreach (DataRow dr in dt.Rows)
            {
                CBcountries.Items.Add(dr["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _Person = clsDVLDBusinessPeople.Find(_ID);


            _ID = _Person.PerosnID;
           txtNationalNO.Text = _Person.NationalNO;
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtAdress.Text = _Person.Address;
            DTofBirth.Value = _Person.DateOfBirth;
            CBcountries.SelectedIndex = CBcountries.FindString(clsDVLDBusinessCountry.FindCountryByID(_Person.NationalCountryID).CountryName);
            if (_Person.Gender == "Male")
            {
                rdbMale.Checked = true;
            }
            else
            { rdbFemale.Checked = true;}
           
           

            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                {
                    picturePerson.ImageLocation = _Person.ImagePath;
                    lblRemoveImage.Visible = true;
                }
                else
                    MessageBox.Show("Could not find this image: = " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private clsDVLDBusinessPeople FillData()
        {

            //_Person.PerosnID = _ID;
           _Person.NationalNO = txtNationalNO.Text;
           _Person.FirstName = txtFirstName.Text;
           _Person.LastName = txtLastName.Text;
           _Person.Email = txtEmail.Text;
           _Person.Phone = txtPhone.Text;
           _Person.SecondName = txtSecondName.Text;
           _Person.ThirdName = txtThirdName.Text;
           _Person.Address = txtAdress.Text;
           _Person.DateOfBirth = DTofBirth.Value;
            _Person.NationalCountryID = clsDVLDBusinessCountry.GetCountryIDByName(CBcountries.Text);
            if (rdbMale.Checked)
            {
                _Person.Gender = "Male";
            }
            if (rdbFemale.Checked)
            { _Person.Gender = "Female"; }
            if (_NewPictureImage != "" && _NewPictureImage != null)
            {
                 _OldImagePath = _Person.ImagePath;

                _Person.ImagePath = _SaveImageIntoFolderAndDeleteTheOldONe(_NewPictureImage);
                picturePerson.ImageLocation = _Person.ImagePath;


                

            }

            return _Person;  
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            picturePerson.ImageLocation = @"E:\apps\c++\programing advice course\C# and Database connective\DVLDProject\Icons\Male 512.png";
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            picturePerson.ImageLocation = @"E:\apps\c++\programing advice course\C# and Database connective\DVLDProject\Icons\Female 512.png";
        }

        private void lblSetImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                picturePerson.Load(selectedFilePath);


                _NewPictureImage = picturePerson.ImageLocation;

               

            }
            lblRemoveImage.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

            if (_Mode == EnMode.AddMode)
            {
                _Person = new clsDVLDBusinessPeople();
                _Person = FillData();
               
                
            }
            if (_Mode == EnMode.UpdateMode)
            {
                _Person = FillData();
            }

            if (_Person.Save())
            {
                MessageBox.Show("Saved Succesfully");
                lblidea.Text = _Person.PerosnID.ToString();
                lblAddeEdit.Text = "Edit Perosn";
                DataBack?.Invoke(_Person.PerosnID,_OldImagePath);
            }
            else
            {
                MessageBox.Show("Saving Process Failed");

            }
            

        }

        private void CTRLAddEditPerson_Load(object sender, EventArgs e)
        {
            _GetCountriesList();
            DTofBirth.MaxDate = DateTime.Now.AddYears(-18);
            switch (_Mode)
            {
                case EnMode.UpdateMode:
                    _LoadData();
                    lblidea.Text = _Person.PerosnID.ToString();
                    lblAddeEdit.Text = "Edit Perosn";
                    
                    break;

            }
        }

        private void lblRemoveImage_Click(object sender, EventArgs e)
        {
            picturePerson.ImageLocation = null;
            lblRemoveImage.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
        }

        private void txtNationalNO_Validating(object sender, CancelEventArgs e)
        {
           

            if (clsDVLDBusinessPeople.IsPersonHasThisNationalNo(txtNationalNO.Text.ToUpper()))
            {
                e.Cancel = true;
                txtNationalNO.Focus();
                errorProvider1.SetError(txtNationalNO, "this nationlal number is used for another Person");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNO, null);
            }


        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "The Email Format Type is wrong");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, null);
            }

        }

        private void txtAdress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdress.Text))
            {
                errorProvider1.SetError(txtAdress, "The Address Can Not be Empty");
            }
            else
            {
                errorProvider1.SetError(txtAdress, null);
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
