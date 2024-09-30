using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessDetainedLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int _LicenseID = -1;
        public int _DetainID = -1;
        public DateTime _DetainDate = DateTime.Now;
        public decimal _FineFees = 0;
        public int _CreatedByUserID = -1;

        public bool IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleasedByUserID { set; get; }
        public int ReleaseApplicationID { set; get; }

        public clsDVLDBusinessDetainedLicenses()

        {
            this._DetainID = -1;
            this._LicenseID = -1;
            this._DetainDate = DateTime.Now;
            this._FineFees = 0;
            this._CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MaxValue;
            this.ReleasedByUserID = 0;
            this.ReleaseApplicationID = -1;



            Mode = enMode.AddNew;

        }
        private clsDVLDBusinessDetainedLicenses(int _DetainID, int LicenseId, DateTime DetainDAte, decimal FineFees, int CreatedByUserID)
        {
            this._DetainID = _DetainID;
            _LicenseID = LicenseId;
            _CreatedByUserID = CreatedByUserID;
            _DetainDate = DetainDAte;
            _FineFees = FineFees;
        }

        public clsDVLDBusinessDetainedLicenses(int _DetainID,
          int LicenseID, DateTime DetainDate,
          decimal FineFees, int CreatedByUserID,
          bool IsReleased, DateTime ReleaseDate,
          int ReleasedByUserID, int ReleaseApplicationID)

        {
            this._DetainID = _DetainID;
            this._LicenseID = LicenseID;
            this._DetainDate = DetainDate;
            this._FineFees = FineFees;
            this._CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            Mode = enMode.Update;
        }


        private bool _AddNewDetainedLicense()
        {
            //call DataAccess Layer 

            this._DetainID = clsDVLDdataAccessDetainLicenses.AddNewDetainedLicensesApplication(
                this._LicenseID, this._DetainDate, this._FineFees, this._CreatedByUserID);

            return (this._DetainID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            //call DataAccess Layer 

            return clsDVLDdataAccessDetainLicenses.UpdateDetainedLicense(
                this._DetainID, this._LicenseID, this._DetainDate, this._FineFees, this._CreatedByUserID);
        }

        public static clsDVLDBusinessDetainedLicenses Find(int _DetainID)
        {
            int LicenseID = -1; DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            if (clsDVLDdataAccessDetainLicenses.GetDetainedLicenseInfoByID(_DetainID,
            ref LicenseID, ref DetainDate,
            ref FineFees, ref CreatedByUserID,
            ref IsReleased, ref ReleaseDate,
            ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDVLDBusinessDetainedLicenses(_DetainID,
                     LicenseID, DetainDate,
                     FineFees, CreatedByUserID,
                     IsReleased, ReleaseDate,
                     ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

        }

        public static clsDVLDBusinessDetainedLicenses FindByLicenseID(int LicenseID)
        {
            int DetainID = -1; DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            if (clsDVLDdataAccessDetainLicenses.GetDetainedLicenseInfoByLicenseID(LicenseID,
            ref DetainID, ref DetainDate,
            ref FineFees, ref CreatedByUserID,
            ref IsReleased, ref ReleaseDate,
            ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDVLDBusinessDetainedLicenses(DetainID,
                     LicenseID, DetainDate,
                     FineFees, CreatedByUserID,
                     IsReleased, ReleaseDate,
                     ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDetainedLicense();

            }

            return false;
        }

        public  bool ReleaseDetainedLicensesApplicationByDetainID(int ReleaseByUserID, int ReleaseApplicationID)
        {
            return clsDVLDdataAccessDetainLicenses.ReleaseDetainedLicenseByDetainID(this._DetainID, ReleaseByUserID, ReleaseApplicationID);
        }





        public static int AddNewDetainedLicensesApplication(int LicenseID, decimal FineFees, int CreatedByUserID)
        {
            return clsDVLDdataAccessDetainLicenses.AddNewDetainedLicensesApplication(LicenseID,DateTime.Now, FineFees, CreatedByUserID);
        }

        public static bool ReleaseDetainedLicensesApplication(int LicenseID, bool IsReleased, int ReleaseByUserID, int ReleaseApplicationID)
        {
            return clsDVLDdataAccessDetainLicenses.ReleaseDetainedLicensesApplication(LicenseID, IsReleased, ReleaseByUserID, ReleaseApplicationID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDVLDdataAccessDetainLicenses.GetAllDetainedLicenses();
        }

        public static bool IsThisLicenseDetained(int LicenseID)
        {
            return clsDVLDdataAccessDetainLicenses.IsThisLicenseDetained(LicenseID);
        }

        public static clsDVLDBusinessDetainedLicenses GetDetainLicenseInfoByLicenseID(int LicenseID)
        {
            int _DetainID = -1;
            DateTime DetainDAte = DateTime.Now;
            decimal FineFees = 0;
            int CreatedByUserID = -1;


            if (clsDVLDdataAccessDetainLicenses.GetDetainedLicenseInfoByLicenseID(LicenseID, ref _DetainID, ref DetainDAte, ref FineFees, ref CreatedByUserID))
            {
                return new clsDVLDBusinessDetainedLicenses(_DetainID, LicenseID, DetainDAte, FineFees, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllDetainDrivingLicenseApplicationBy<T>(string ColumnType, T ValueType)
        {
            return clsDVLDdataAccessDetainLicenses.GetAllDetainDrivingLicenseApplicationBy(ColumnType, ValueType);
        }

    }
}
