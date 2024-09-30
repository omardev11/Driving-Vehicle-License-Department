using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDBusinessLayer.clsDVLDBusinessApplications;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessInternationalLicense : clsDVLDBusinessApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int _InternationalLicenseID {  get; set; }
        public int _ApplicationtID { get; set; }
        public int _DriverID { get; set; }
        clsDVLDBusinessDriver DriverInfo;
        public int _IssuedUsingLocalLicenseID { get; set; }
        public DateTime _IssueDate { get; set; }
        public DateTime _ExpirationDate { get; set; }
        public int _CreatedUserByID { get; set; }
        public bool _IsActive { get; set; }

        private clsDVLDBusinessInternationalLicense(int internatinalLicenseID ,int applicationtID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate,
                                                                                 DateTime expirationDate, int createdUserByID, bool isActive)
        {
            _InternationalLicenseID = internatinalLicenseID;
            _ApplicationtID = applicationtID;
            _DriverID = driverID;
            _IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            _IssueDate = issueDate;
            _ExpirationDate = expirationDate;
            _CreatedUserByID = createdUserByID;
            _IsActive = isActive;
        }

        public clsDVLDBusinessInternationalLicense()

        {
            //here we set the applicaiton type to New International License.
            this.ApplicationTypeID = (int)clsDVLDBusinessApplications.enApplicationType.NewInternationalLicense;

            this._InternationalLicenseID = -1;
            this._DriverID = -1;
            this._IssuedUsingLocalLicenseID = -1;
            this._IssueDate = DateTime.Now;
            this._ExpirationDate = DateTime.Now;

            this._IsActive = true;


            Mode = enMode.AddNew;

        }

        public clsDVLDBusinessInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)

        {
            //this is for the base clase
            base.ApplicationtID = ApplicationID;
            base.ApplicationPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsDVLDBusinessApplications.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedUserByID = CreatedByUserID;

            this._InternationalLicenseID = InternationalLicenseID;
            this.ApplicationtID = ApplicationID;
            this._DriverID = DriverID;
            this._IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this._IssueDate = IssueDate;
            this._ExpirationDate = ExpirationDate;
            this._IsActive = IsActive;
            this.CreatedUserByID = CreatedByUserID;

            this.DriverInfo = clsDVLDBusinessDriver.FindByDriverID(this._DriverID);

            Mode = enMode.Update;
        }


        private bool _AddNewInternationalLicense()
        {
            //call DataAccess Layer 

            this._InternationalLicenseID =
                clsDVLDdataAccessInternationalLicenses.AddNewInternatinalLicense(this.ApplicationtID, this._IssueDate, this._DriverID, this._IssuedUsingLocalLicenseID,
               this._ExpirationDate,
               this._IsActive, this.CreatedUserByID);


            return (this._InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            //call DataAccess Layer 

            return clsDVLDdataAccessInternationalLicenses.UpdateInternationalLicense( this._InternationalLicenseID,
               this.ApplicationtID, this._DriverID, this._IssuedUsingLocalLicenseID, this._IssueDate, 
               this._ExpirationDate,
               this._IsActive, this.CreatedUserByID);
        }

        public static clsDVLDBusinessInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1; int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true; int CreatedByUserID = 1;

            if (clsDVLDdataAccessInternationalLicenses.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref IssueDate, ref DriverID,
                ref IssuedUsingLocalLicenseID,
            ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                //now we find the base application
                clsDVLDBusinessApplications Application = clsDVLDBusinessApplications.FindBaseApplication(ApplicationID);


                return new clsDVLDBusinessInternationalLicense(Application.ApplicationtID,
                    Application.ApplicationPersonID,
                                     Application.ApplicationDate,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedUserByID,
                                     InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID,
                                         IssueDate, ExpirationDate, IsActive);

            }

            else
                return null;

        }


        public bool Save()
        {

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsDVLDBusinessApplications.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalLicense();

            }

            return false;
        }



        public static int AddNewInternatinalLicense(int applicationtID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate,
                                                                    int createdUserByID, bool isActive)
        {
            return clsDVLDdataAccessInternationalLicenses.AddNewInternatinalLicense(applicationtID, issueDate, driverID, issuedUsingLocalLicenseID, expirationDate,
                                                                                                 isActive, createdUserByID);
        }

        public static clsDVLDBusinessInternationalLicense GetInternationalLicenseInfoByID(int InternationalLicenseID)
        {
            int applicationtID = -1; int driverID=-1; int issuedUsingLocalLicenseID=0; DateTime issueDate=DateTime.Now; DateTime expirationDate=DateTime.Now;
            int createdUserByID = -1; bool isActive = false;

            if (clsDVLDdataAccessInternationalLicenses.GetInternationalLicenseInfoByID(InternationalLicenseID, ref applicationtID, ref issueDate, ref driverID, 
                                                   ref issuedUsingLocalLicenseID, ref expirationDate, ref isActive, ref createdUserByID))
            {
                return new clsDVLDBusinessInternationalLicense(InternationalLicenseID,applicationtID,driverID,issuedUsingLocalLicenseID,issueDate,expirationDate,createdUserByID,isActive);

            }
            else { return null; }
        }

        public static clsDVLDBusinessInternationalLicense GetInternationalLicenseInfoByApplicationID(int applicationtID)
        {
            int InternationalLicenseID = -1; int driverID = -1; int issuedUsingLocalLicenseID = 0; DateTime issueDate = DateTime.Now; DateTime expirationDate = DateTime.Now;
            int createdUserByID = -1; bool isActive = false;

            if (clsDVLDdataAccessInternationalLicenses.GetInternationalLicenseInfoByApplicationID(applicationtID, ref InternationalLicenseID, ref issueDate, ref driverID,
                                                   ref issuedUsingLocalLicenseID, ref expirationDate, ref isActive, ref createdUserByID))
            {
                return new clsDVLDBusinessInternationalLicense(InternationalLicenseID, applicationtID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, createdUserByID, isActive);

            }
            else { return null; }
        }

        public static clsDVLDBusinessInternationalLicense GetInternationalLicenseInfoByLocalLicense(int issuedUsingLocalLicenseID)
        {
            int InternatinalLicenseID = -1; int driverID = -1; int applicationtID = 0; DateTime issueDate = DateTime.Now; DateTime expirationDate = DateTime.Now;
            int createdUserByID = -1; bool isActive = false;

            if (clsDVLDdataAccessInternationalLicenses.GetInternationalLicenseInfoByLocalLicense(issuedUsingLocalLicenseID, ref InternatinalLicenseID, ref issueDate, ref driverID,
                                                   ref applicationtID, ref expirationDate, ref isActive, ref createdUserByID))
            {
                return new clsDVLDBusinessInternationalLicense(InternatinalLicenseID, applicationtID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, createdUserByID, isActive);

            }
            else { return null; }
        }


        public static bool IsThisLicenseHasAnActiveInternatinalLicense(int InternatinalLicenseID)
        {
            return clsDVLDdataAccessInternationalLicenses.IsThisLicenseHasAnActiveInternatinalLicense(InternatinalLicenseID);
        }

        public static DataTable GetInternationalLicenseInfoByApplicationPersonID(int ApplicantPersonID)
        {
            return clsDVLDdataAccessInternationalLicenses.GetInternationalLicenseInfoByApplicationPersonID(ApplicantPersonID);
        }

        public static DataTable GetAllInternationalLicenseApplications()
        {
            return clsDVLDdataAccessInternationalLicenses.GetAllInternationalLicenseApplications();
        }

        public static DataTable GetAllInternationalLicenseApplicationsBy(string ColumntType,string valuetype)
        {
            return clsDVLDdataAccessInternationalLicenses.GetAllInternationalDrivingLicenseApplicationBy(ColumntType,valuetype);
        }

        public static DataTable GetAllInternationalLicenseForThisDriver(int DriverID)
        {
            return clsDVLDdataAccessInternationalLicenses.GetAllInternationalLicenseForThisDriver(DriverID);
        }
    }
}
