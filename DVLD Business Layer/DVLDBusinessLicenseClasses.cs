using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessLicenseClasses
    {

        public int _LicenseClassID { get; set; }

        public string _LicenseClassName { get; set; }

        public decimal _ClassFees { get; set; }
        public byte _DefaultValidityLength { get; set; }


        private clsDVLDBusinessLicenseClasses(int licenseClassID, string licenseClassName, decimal classFees, byte defaultValidityLength)
        {
            _LicenseClassID = licenseClassID;
            _LicenseClassName = licenseClassName;
            _ClassFees = classFees;
            _DefaultValidityLength = defaultValidityLength;
        }

        public clsDVLDBusinessLicenseClasses()
        {
            _LicenseClassID = -1;
            _LicenseClassName = "";
            _ClassFees = 0;
        }

        public static DataTable GetAllLicenseClassesName()
        {
            return clsDVLDdataAcessLicenseClasses.GetAllLicenseClasses();
        }

        public static clsDVLDBusinessLicenseClasses GetLicenseClassByName(string Name)
        {
            decimal ClassFees = -1;
            int LicenseClassID = -1;
            byte DefaultValidityLength = 0;
            if (clsDVLDdataAcessLicenseClasses.GetLicenseClasseByName(Name, ref LicenseClassID, ref ClassFees,ref DefaultValidityLength))
            {
               return new clsDVLDBusinessLicenseClasses(LicenseClassID,Name,ClassFees, DefaultValidityLength);
            }
            else
            {
                return null;
            }
        }

        public static clsDVLDBusinessLicenseClasses GetLicenseClassByID(int LicenseClassID)
        {
            decimal ClassFees = -1;
            string Name = "";
            byte DefaultValidityLength = 0;

            if (clsDVLDdataAcessLicenseClasses.GetLicenseClasseByID(LicenseClassID, ref Name ,ref ClassFees, ref DefaultValidityLength))
            {
                return new clsDVLDBusinessLicenseClasses(LicenseClassID, Name, ClassFees, DefaultValidityLength);
            }
            else
            {
                return null;
            }
        }

    }
}
