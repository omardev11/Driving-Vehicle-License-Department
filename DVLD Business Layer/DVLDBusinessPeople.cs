using DVLDdataAccessLayer;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using DVLDdataAccessAllCountries;


namespace DVLDBusinessPeople
{
    public class clsDVLDBusinessPeople
    {

        public enum enMode { UpdateMode = 1, AddMode = 2, DeleteMode = 3 };

        public enMode Mode = enMode.AddMode;
        public int PerosnID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public string Gender { set; get; }
        public string NationalNO { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }

        public string ImagePath { set; get; }

        public int NationalCountryID { set; get; }

        public string CountryName { set; get; }

        public clsDVLDBusinessPeople()

        {
            this.PerosnID = -1;
            this.NationalNO = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.Gender = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.NationalCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddMode;

        }

        private clsDVLDBusinessPeople(int ID, string NationalNo, string FirstName, string LastName, string SecondName, string ThirdName, string Gender,
            string Email, string Phone, string Address, DateTime DateOfBirth, int NationalCountryID, string ImagePath)

        {
            this.PerosnID = ID;
            this.NationalNO = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.Gender = Gender;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.NationalCountryID = NationalCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.UpdateMode;

        }




        private bool _AddNewPerson()
        {
            this.PerosnID = clsDVLDdataAccessPeople.AddNewPerson(this.FirstName, this.LastName, this.SecondName, this.ThirdName, this.Email, this.Phone,
                     this.Address, this.Gender, this.NationalNO, this.DateOfBirth, this.NationalCountryID, this.ImagePath);
            return (this.PerosnID != -1);
        }

        private bool _UpdatePerson()
        {
            if (clsDVLDdataAccessPeople.UpdatePerson(this.PerosnID, this.FirstName, this.LastName, this.SecondName, this.ThirdName, this.Email, this.Phone,
                     this.Address, this.Gender, this.NationalNO, this.DateOfBirth, this.NationalCountryID, this.ImagePath))
            {
                return true;
            }
            else
            { return false; };
        }

        public static bool DeletePerson(int ID)
        {

            return clsDVLDdataAccessPeople.DeletePerson(ID);


        }

        public static DataTable GetAllPeople()
        {
            return clsDVLDdataAccessPeople.GetAllPeople();
        }

        public static DataTable GetAllPeopleNationalNO()
        {
            return clsDVLDdataAccessPeople.GetAllPeopleNationalNO();
        }


        public static DataTable GetAllPeopleBY<T>(string ColumnType, T ValueType)
        {
            return clsDVLDdataAccessPeople.GetAllPeopleBy(ColumnType, ValueType);
        }
        public static clsDVLDBusinessPeople Find(int ID)
        {

            string FirstName = "", LastName = "", SecondName = "", ThirdName = "", Gender = "", Email = "", Phone = "", Address = "",
                ImagePath = "", NationlaNo = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalCountryID = -1;

            if (clsDVLDdataAccessPeople.GetPersonInfoByID(ID, ref FirstName, ref LastName, ref SecondName, ref ThirdName,
                          ref Email, ref Phone, ref Address, ref Gender, ref NationlaNo, ref DateOfBirth, ref NationalCountryID, ref ImagePath))

                return new clsDVLDBusinessPeople(ID, NationlaNo, FirstName, LastName, SecondName, ThirdName, Gender,
                           Email, Phone, Address, DateOfBirth, NationalCountryID, ImagePath);
            else
                return null;

        }

        public static clsDVLDBusinessPeople FindByNationalNO(string NatinalNO)
        {
            int ID = 0;
            string FirstName = "", LastName = "", SecondName = "", ThirdName = "", Gender = "", Email = "", Phone = "", Address = "",
               ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalCountryID = -1;

            if (clsDVLDdataAccessPeople.GetPersonInfoByNationalNO(NatinalNO, ref FirstName, ref LastName, ref SecondName, ref ThirdName,
                          ref Email, ref Phone, ref Address, ref Gender, ref ID, ref DateOfBirth, ref NationalCountryID, ref ImagePath))

                return new clsDVLDBusinessPeople(ID, NatinalNO, FirstName, LastName, SecondName, ThirdName, Gender,
                           Email, Phone, Address, DateOfBirth, NationalCountryID, ImagePath);
            else
                return null;
        }

        public static bool IsPersonExists(int ID)
        {
            return clsDVLDdataAccessPeople.IsPersonExist(ID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    if (_UpdatePerson())
                    {
                        return true;
                    }
                    else
                    { return false; }
                case enMode.DeleteMode:

                default:
                    return false;
            }
        }


        public static bool IsPersonHasThisNationalNo(string NationalNO)
        {
            return clsDVLDdataAccessPeople.IsPersonHasThisNationalNo(NationalNO);
        }



      








    }
}
