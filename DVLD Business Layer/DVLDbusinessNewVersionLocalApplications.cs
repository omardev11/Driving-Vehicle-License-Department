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
    public class clsDVLDbusinessNewVersionLocalApplications : clsDVLDBusinessApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }
        public clsDVLDBusinessLicenseClasses LicenseClassInfo;
       
        public clsDVLDbusinessNewVersionLocalApplications()

        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;


            Mode = enMode.AddNew;

        }

        private clsDVLDbusinessNewVersionLocalApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
           DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationtID = ApplicationID;
            this.ApplicationPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedUserByID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsDVLDBusinessLicenseClasses.GetLicenseClassByID(LicenseClassID);
            Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            this.LocalDrivingLicenseApplicationID = clsDVLDdataAcesNewVersionLocalApplications.AddNewLocalDrivingLicenseApplication
                (
                this.ApplicationtID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            return clsDVLDdataAcesNewVersionLocalApplications.UpdateLocalDrivingLicenseApplication
                (
                this.LocalDrivingLicenseApplicationID, this.ApplicationtID, this.LicenseClassID);

        }

        public static clsDVLDbusinessNewVersionLocalApplications FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            // 
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsDVLDdataAcesNewVersionLocalApplications.GetLocalDrivingLicenseApplicationInfoByID
                (LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsDVLDBusinessApplications Application = clsDVLDBusinessApplications.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsDVLDbusinessNewVersionLocalApplications(
                    LocalDrivingLicenseApplicationID, Application.ApplicationtID,
                    Application.ApplicationPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedUserByID, LicenseClassID);
            }
            else
                return null;


        }

        public static clsDVLDbusinessNewVersionLocalApplications FindByApplicationID(int ApplicationID)
        {
            // 
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsDVLDdataAcesNewVersionLocalApplications.GetLocalDrivingLicenseApplicationInfoByApplicationID
                (ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsDVLDBusinessApplications Application = clsDVLDBusinessApplications.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsDVLDbusinessNewVersionLocalApplications(
                    LocalDrivingLicenseApplicationID, Application.ApplicationtID,
                    Application.ApplicationPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedUserByID, LicenseClassID);
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


            //After we save the main application now we save the sub application.
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

            }

            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsDVLDdataAcesNewVersionLocalApplications.GetAllLocalDrivingLicenseApplications();
        }

        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            IsLocalDrivingApplicationDeleted = clsDVLDdataAcesNewVersionLocalApplications.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;
            //Then we delete the base Application
            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;

        }

        public static bool IsThisLicenseClassExistInThisPerson(string nationalNO, string ClassName, ref int FoundApplicationID)
        {
            return clsDVLDdataAcesNewVersionLocalApplications.IsThisLicenseClassExistInThisPerson(nationalNO, ClassName, ref FoundApplicationID);
        }

        public static bool IsThisLicenseClassExistCancelled(int LocalDrivingLicenseApplicationID)
        {
            return clsDVLDdataAcesNewVersionLocalApplications.IsThisLicenseClassExistCancelled(LocalDrivingLicenseApplicationID);
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;
            clsDVLDBusinessDriver Driver = clsDVLDBusinessDriver.FindByPersonID(this.ApplicationPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDVLDBusinessDriver();

                Driver.PersonID = this.ApplicationPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsDVLDBusinessLicense License = new clsDVLDBusinessLicense();
            License._ApplicationID = this.ApplicationtID;
            License._DriverID = DriverID;
            License._LicenseClassID = this.LicenseClassID;
            License._IssueDate = DateTime.Now;
            License._ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo._DefaultValidityLength);
            License._Note = Notes;
            License._PaidFees = this.LicenseClassInfo._ClassFees;
            License._IsActive = true;
            License.IssueReason = clsDVLDBusinessLicense.enIssueReason.FirstTime;
            License._CreatedUserByID = CreatedByUserID;

            if (License.Save())
            {
                this.CompelteStatus();
                return License._LicenseID;
            }

            else
                return -1;
        }

        public byte GetPassedTestCount()
        {
            return clsDVLDdataAcessTestTypes.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsDVLDdataAcessTestTypes.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

      


    }
}
