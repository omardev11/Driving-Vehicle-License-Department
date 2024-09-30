using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DVLDBusinessLayer.clsDVLDBusinessLocalApplication;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public clsDVLDBusinessDriver DriverInfo;
        public int _LicenseID { get; set; }
        public int _ApplicationID { get; set; }
        public int _DriverID { get; set; }
        public DateTime _IssueDate { get; set; }
        public DateTime _ExpirationDate { get; set; }
        public int _CreatedUserByID { get; set; }
        public decimal _PaidFees { get; set; }
        public int _LicenseClassID { get; set; }
        public clsDVLDBusinessLicenseClasses LicenseClassIfo;

        public bool _IsActive { get; set; }
        public byte _IssueReason { get; set; }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public clsDVLDBusinessDetainedLicenses DetainedInfo { set; get; }
        public bool IsDetained
        {
            get { return true /*clsDetainedLicense.IsLicenseDetained(this.LicenseID)*/; }
        }
        public string _Note { get; set; }


        public clsDVLDBusinessLicense()

        {
            this._LicenseID = -1;
            this._ApplicationID = -1;
            this._DriverID = -1;
            this._LicenseClassID = -1;
            this._IssueDate = DateTime.Now;
            this._ExpirationDate = DateTime.Now;
            this._Note = "";
            this._PaidFees = 0;
            this._IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this._CreatedUserByID = -1;

            Mode = enMode.AddNew;

        }


        private clsDVLDBusinessLicense(int LicenseID , int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes,
                                                 decimal PaidFees, bool Isactive,/* byte IssueReason*/ enIssueReason IssueReason1, int CreatedByUserID)
        {

            _LicenseID = LicenseID;
            _ApplicationID = ApplicationID;
            _DriverID = DriverID;
            _IssueDate = IssueDate;
            _ExpirationDate = ExpirationDate;
            _CreatedUserByID = CreatedByUserID;
            _PaidFees = PaidFees;
            _LicenseClassID = LicenseClassID;
            _IsActive = Isactive;
            IssueReason = IssueReason1;
            _Note = Notes;


            this.DriverInfo = clsDVLDBusinessDriver.FindByDriverID(this._DriverID);
            this.LicenseClassIfo = clsDVLDBusinessLicenseClasses.GetLicenseClassByID(this._LicenseClassID);
            this.DetainedInfo = clsDVLDBusinessDetainedLicenses.GetDetainLicenseInfoByLicenseID(this._LicenseID);

        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this._LicenseID = clsDVLDdataAccessLicenses.AddNewLicense(this._ApplicationID, this._DriverID, this._LicenseClassID,
               this._IssueDate, this._ExpirationDate, this._Note, this._PaidFees,
               this._IsActive, (byte)this.IssueReason, this._CreatedUserByID);


            return (this._LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsDVLDdataAccessLicenses.UpdateLicense(this._LicenseID,this._ApplicationID, this._DriverID, this._LicenseClassID,
               this._IssueDate, this._ExpirationDate, this._Note, this._PaidFees,
               this._IsActive, (byte)this.IssueReason, this._CreatedUserByID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }



        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDVLDBusinessDetainedLicenses detainedLicense = new clsDVLDBusinessDetainedLicenses();
            detainedLicense._LicenseID = this._LicenseID;
            detainedLicense._DetainDate = DateTime.Now;
            detainedLicense._FineFees = Convert.ToDecimal(FineFees);
            detainedLicense._CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {

                return -1;
            }

            return detainedLicense._DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            clsDVLDBusinessApplications Application = new clsDVLDBusinessApplications();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsDVLDBusinessApplications.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsDVLDBusinessApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID((int)clsDVLDBusinessApplications.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            Application.CreatedUserByID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationtID;


            return this.DetainedInfo.ReleaseDetainedLicensesApplicationByDetainID(ReleasedByUserID, Application.ApplicationtID);

        }

        public clsDVLDBusinessLicense RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsDVLDBusinessApplications Application = new clsDVLDBusinessApplications();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsDVLDBusinessApplications.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsDVLDBusinessApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID((int)clsDVLDBusinessApplications.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedUserByID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }
            
            clsDVLDBusinessLicense NewLicense = new clsDVLDBusinessLicense();

            NewLicense._ApplicationID = Application.ApplicationtID;
            NewLicense._DriverID = this._DriverID;
            NewLicense._LicenseClassID = this._LicenseClassID;
            NewLicense._IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassIfo._DefaultValidityLength;

            NewLicense._ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense._Note = Notes;
            NewLicense._PaidFees = this.LicenseClassIfo._ClassFees;
            NewLicense._IsActive = true;
            NewLicense.IssueReason = clsDVLDBusinessLicense.enIssueReason.Renew;
            NewLicense._CreatedUserByID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsDVLDBusinessLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsDVLDBusinessApplications Application = new clsDVLDBusinessApplications();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsDVLDBusinessApplications.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsDVLDBusinessApplications.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsDVLDBusinessApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(Application.ApplicationTypeID).Fees;
            Application.CreatedUserByID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsDVLDBusinessLicense NewLicense = new clsDVLDBusinessLicense();

          

            NewLicense._ApplicationID = Application.ApplicationtID;
            NewLicense._DriverID = this._DriverID;
            NewLicense._LicenseClassID = this._LicenseClassID;
            NewLicense._IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassIfo._DefaultValidityLength;

            NewLicense._ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense._Note = this._Note;
            NewLicense._PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense._IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense._CreatedUserByID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }






        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes,
                                                 decimal PaidFees, bool Isactive, byte IssueReason, int CreatedByUserID)
        {
            return clsDVLDdataAccessLicenses.AddNewLicense(ApplicationID, DriverID,LicenseClassID,IssueDate,ExpirationDate,Notes,PaidFees,Isactive,IssueReason,CreatedByUserID);
        }

        public static clsDVLDBusinessLicense GetLicenseInfoByID(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClassID = -1; DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";  decimal PaidFees = 0; bool Isactive = false; byte IssueReason = 1; int CreatedByUserID = -1;


            if (clsDVLDdataAccessLicenses.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                      ref Notes, ref PaidFees, ref Isactive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsDVLDBusinessLicense(LicenseID,ApplicationID,DriverID,LicenseClassID,IssueDate,ExpirationDate, Notes,PaidFees,Isactive,(enIssueReason)IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static clsDVLDBusinessLicense GetLicenseInfoByApplicationID(int ApplicationID)
        {
            int LicenseID = -1; int DriverID = -1; int LicenseClassID = -1; DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = ""; decimal PaidFees = 0; bool Isactive = false; byte IssueReason = 1; int CreatedByUserID = -1;


            if (clsDVLDdataAccessLicenses.GetLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                      ref Notes, ref PaidFees, ref Isactive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsDVLDBusinessLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, Isactive,(enIssueReason)IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static clsDVLDBusinessLicense GetLicenseInfoByDriverID(int DriverID)
        {
            int LicenseID = -1; int ApplicationID = -1; int LicenseClassID = -1; DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = ""; decimal PaidFees = 0; bool Isactive = false; byte IssueReason = 1; int CreatedByUserID = -1;


            if (clsDVLDdataAccessLicenses.GetLicenseInfoByDriverID(DriverID, ref LicenseID, ref ApplicationID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                      ref Notes, ref PaidFees, ref Isactive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsDVLDBusinessLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, Isactive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static bool IsThisApplicationHasLicense(int ApplicationID)
        {
            return clsDVLDdataAccessLicenses.IsThisApplicationHasLicense(ApplicationID);
        }

        public static bool CancelLicenseApplication(int LicenseID)
        {
            return clsDVLDdataAccessLicenses.CancelLicenseApplication(LicenseID);
        }
        public  bool DeactivateCurrentLicense()
        {
            return clsDVLDdataAccessLicenses.CancelLicenseApplication(this._LicenseID);
        }
        
        public static DataTable GetThisDriverAllLicenses(int driverID)
        {
            return clsDVLDdataAccessLicenses.GetThisDriverAllLicenses(driverID);
        }


    }




}
