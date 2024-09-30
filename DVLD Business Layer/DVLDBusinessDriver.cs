using DVLDBusinessPeople;
using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsDVLDBusinessPeople PersonInfo;

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; }

        public clsDVLDBusinessDriver()

        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;

        }

        public clsDVLDBusinessDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)

        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsDVLDBusinessPeople.Find(PersonID);

            Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            //call DataAccess Layer 
            
            this.DriverID = clsDVLDdataAccessDrivers.AddNewDriver(PersonID,DateTime.Now, CreatedByUserID);


            return (this.DriverID != -1);
        }
        private bool _UpdateDriver()
        {
            //call DataAccess Layer 

            return clsDVLDdataAccessDrivers.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDriver();

            }

            return false;
        }

        public static clsDVLDBusinessDriver FindByDriverID(int DriverID)
        {

            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDVLDdataAccessDrivers.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDVLDBusinessDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public static clsDVLDBusinessDriver FindByPersonID(int PersonID)
        {

            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDVLDdataAccessDrivers.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsDVLDBusinessDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }
        public static int AddNewDriver(int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            return clsDVLDdataAccessDrivers.AddNewDriver(PersonID, CreatedDate, CreatedByUserID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDVLDdataAccessDrivers.GetAllDrivers();
        }

        public static DataTable GetAllDriversBy<T>(string ColumnType, T ValueType)
        {
            return clsDVLDdataAccessDrivers.GetAllDriversBy(ColumnType, ValueType);
        }

        public static int IsThisPersonAdriver(int PersonID)
        {
            return clsDVLDdataAccessDrivers.IsThisPersonAdriver(PersonID);
        }

        public DataTable GetThisDriverAllLicenses()
        {
            return clsDVLDBusinessLicense.GetThisDriverAllLicenses(this.DriverID);
        }

        public DataTable GetAllInternationalLicenseForThisDriver()
        {
            return clsDVLDBusinessInternationalLicense.GetAllInternationalLicenseForThisDriver(this.DriverID);
        }



    }
}
