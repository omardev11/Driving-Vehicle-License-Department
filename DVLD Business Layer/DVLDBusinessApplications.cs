using DVLDBusinessLayer;
using DVLDBusinessPeople;
using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDBusinessLayer.clsDVLDBusinessLocalApplication;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public int ApplicationtID { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsDVLDBusinessApplicationTypes ApplicationTypeInfo;

        public int ApplicationPersonID { get; set; }
        public clsDVLDBusinessPeople PersonInfo;
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int CreatedUserByID { get; set; }
        public decimal PaidFees { get; set; }
        public enApplicationStatus ApplicationStatus { set; get; }


        private clsDVLDBusinessApplications(int ApplicationID, int ApplicantPersonID,
           DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID)

        {
            this.ApplicationtID = ApplicationID;
            this.ApplicationPersonID = ApplicantPersonID;
            this.PersonInfo = clsDVLDBusinessPeople.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsDVLDBusinessApplicationTypes.FindCApplicationTypeByID(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedUserByID = CreatedByUserID;
            Mode = enMode.Update;
        }
        public clsDVLDBusinessApplications()
        {
            this.ApplicationtID = -1;
            this.ApplicationPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedUserByID = -1;

            Mode = enMode.AddNew;
        }

        private bool _AddNewApplication()
        {
            //call DataAccess Layer 
            this.ApplicationtID = clsDVLDdataAccessApplications.AddNewApplication(
                this.ApplicationPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedUserByID);

            return (this.ApplicationtID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsDVLDdataAccessApplications.UpdateApplication(this.ApplicationtID, this.ApplicationPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedUserByID);

        }

        public static clsDVLDBusinessApplications FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now; int ApplicationTypeID = -1;
            byte ApplicationStatus = 1; DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0; int CreatedByUserID = -1;

            bool IsFound = clsDVLDdataAccessApplications.GetApplicationInfoByID
                                (
                                    ApplicationID, ref ApplicantPersonID,
                                    ref ApplicationDate, ref ApplicationTypeID,
                                    ref ApplicationStatus, ref LastStatusDate,
                                    ref PaidFees, ref CreatedByUserID
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsDVLDBusinessApplications(ApplicationID, ApplicantPersonID,
                                     ApplicationDate, ApplicationTypeID,
                                    (enApplicationStatus)ApplicationStatus, LastStatusDate,
                                     PaidFees, CreatedByUserID);
            else
                return null;
        }

        public bool CancelApplication()
        {
            return clsDVLDdataAccessApplications.UpdateStatus(this.ApplicationtID,2);
        }
        public bool CompelteStatus()
        {
            return clsDVLDdataAccessApplications.UpdateStatus(this.ApplicationtID,3);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;
        }


        public static bool DeleteApplication(int ApplicationID)
        {
            return clsDVLDdataAccessApplications.DelteApplication(ApplicationID);

        }
        public bool Delete()
        {
            return clsDVLDdataAccessApplications.DelteApplication(this.ApplicationtID);

        }


        public static int IsThisPersonHasanActiveLicenseForThisApplication(int ApplicationPersonID, int ApplicationTypeID)
        {
            return clsDVLDdataAccessApplications.IsThisPersonHasanActiveLicenseForThisApplication(ApplicationPersonID, ApplicationTypeID);

        }

    }
}
