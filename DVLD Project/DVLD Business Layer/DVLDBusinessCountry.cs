using DVLDdataAccessAllCountries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessCountry
    {


        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public string Code { get; set; }
        public string PhoneCode { get; set; }

        public enum enMode { UpdateMode = 1, AddnewCountry = 2, DeleteMode = 3 };

        public enMode Mode = enMode.AddnewCountry;


        private clsDVLDBusinessCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
          

            Mode = enMode.UpdateMode;
        }

        public clsDVLDBusinessCountry()

        {
            this.CountryID = -1;
            this.CountryName = "";

            Mode = enMode.AddnewCountry;

        }

        public static clsDVLDBusinessCountry FindCountryByID(int ID)
        {
            int CountryID = 0;
            string CountryName = "";

            if (clsDVLDdataAccessALLCountries.GetCountryInfoByID(ID, ref CountryID, ref CountryName))
            {
                return new clsDVLDBusinessCountry(CountryID, CountryName);

            }
            else { return null; }
        }




        public static bool IsCountryExistsByID(int ID)
        {
            return clsDVLDdataAccessALLCountries.IsCountryExistByID(ID);
        }

        public static int GetCountryIDByName(string Name)
        {
            return clsDVLDdataAccessALLCountries.IsCountryExistByName(Name);
        }




        public static DataTable GetAllCountries()
        {
            return clsDVLDdataAccessALLCountries.GetAllCountries();


        }

        public static clsDVLDBusinessCountry FindCountryByName(string Name)
        {
            int CountryID = 0;
            string CountryName = "";

            if (clsDVLDdataAccessALLCountries.GetCountryInfoByName(Name, ref CountryID, ref CountryName))
            {
                return new clsDVLDBusinessCountry(CountryID, CountryName);

            }
            else { return null; }
        }





    }
}
