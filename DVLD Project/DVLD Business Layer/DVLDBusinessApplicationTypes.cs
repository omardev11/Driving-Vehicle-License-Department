using DVLDdataAccessAllCountries;
using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeName { get; set; }

        public decimal Fees { get; set; }

        private clsDVLDBusinessApplicationTypes(int ID , string Title, decimal Fees)
        {
            this.Fees = Fees;
            this.ApplicationTypeName = Title;
            this.ApplicationTypeID = ID;


        }

        public static clsDVLDBusinessApplicationTypes FindCApplicationTypeByID(int ID)
        {
            string Title = "";
            decimal Fees = 0;

            if (clsDVLDdataAccessApplicationTypes.GetApplicationTypeInfoByID(ID, ref Title, ref Fees))
            {
                return new clsDVLDBusinessApplicationTypes(ID ,Title, Fees);

            }
            else { return null; }
        }

        public static bool IsApplicationTypeExistsByID(int ID)
        {
            return clsDVLDdataAccessApplicationTypes.IsApplicationTypeExistByID(ID);
        }

        public static int GetApplicationTypeIDByName(string Name)
        {
            return clsDVLDdataAccessApplicationTypes.IsApplicationTypeExistByTitle(Name);
        }


        public static bool UpdateApplicationType(int ID, string ApplicationName , decimal Fees)
        {
            return clsDVLDdataAccessApplicationTypes.UpdateApplicationType(ID, ApplicationName , Fees);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsDVLDdataAccessApplicationTypes.GetAllApplicationTypes();


        }

    }
}
