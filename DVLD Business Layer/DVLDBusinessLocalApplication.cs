using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessLocalApplication 
    {
        public class StApplicationsinFo
        {
            public int _ApplicationtID { get; set; }
            public int _ApplicationTypeID { get; set; }
            public int _ApplicationPersonID { get; set; }
            public DateTime _ApplicationDate { get; set; }
            public DateTime _LastStatusDate { get; set; }
            public int _CreatedUserByID { get; set; }
            public decimal _PaidFees { get; set; }
        }
        public class StLocalDrivingAppliationView
        {
            public int _LocalDrivingApplicationID { get; set; }
            public string _LicenseClassName { get; set; }
            public string _NationalNo { get; set; }
            public string _FullName { get; set; }
            public DateTime _ApplicationDAte { get; set; }
            public int _PassedTestCount { get; set; }
            public string _Status {  get; set; }
            public int _ApplicationID { get; set; }

            public clsDVLDBusinessApplications _ApplicationInfo { get; set; }

        }


        public StApplicationsinFo _ApplicationsinFo { get; set; }
        public StLocalDrivingAppliationView _D_L_ApplicatioinInfo { get; set; }





        private clsDVLDBusinessLocalApplication(int localDrivingApplicationID, int ApplicationID, string LicensClassName, string NationalNO, string FullName,
                                                             DateTime ApplicationDAte, int PassedTestCount, string Status)
        {
            this._D_L_ApplicatioinInfo = new StLocalDrivingAppliationView
            {
                _NationalNo = NationalNO,
                _ApplicationID = ApplicationID,
                _ApplicationDAte = ApplicationDAte,
                _Status = Status,
                _LocalDrivingApplicationID = localDrivingApplicationID,
                _FullName = FullName,
                _PassedTestCount = PassedTestCount,
                _LicenseClassName = LicensClassName,

            };

          


       
          

        }
        private clsDVLDBusinessLocalApplication(int ApplicationID, int ApplicationTypeID, int ApplicantPersonID, DateTime ApplicationDAte, DateTime LastStatusDAte, 
                                                         int CreatedUserID, decimal PaidFees)
        {
            this._ApplicationsinFo = new StApplicationsinFo
            {
                _ApplicationtID = ApplicationID,
                _ApplicationTypeID = ApplicationTypeID,
                _ApplicationDate = ApplicationDAte,
                _ApplicationPersonID = ApplicantPersonID,
                _LastStatusDate = LastStatusDAte,
                _CreatedUserByID = CreatedUserID,
                _PaidFees = PaidFees
            };
          


        }

        public clsDVLDBusinessLocalApplication()
        {
           
        }

        public static int AddNewLocalDrivingLicenseApplication(int LicenseClassID ,int AppLicationID )
        {
         
                return  clsDVLDdataAccessLocalApplication.AddNewLocalDrivingApplication(AppLicationID, LicenseClassID);
        
        }

        public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicationDate,  int ApplicationTypeID, byte ApplicationStatus, 
                                                                DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int AppID;
            AppID = clsDVLDdataAccessLocalApplication.AddNewApplication(ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus,
                                                                                           LastStatusDate, PaidFees, CreatedByUserID);

            return AppID;

        }

        public static bool IsThisLicenseClassExistInThisPerson(string nationalNO,string ClassName , ref int FoundApplicationID)
        {
            return clsDVLDdataAccessLocalApplication.IsThisLicenseClassExistInThisPerson(nationalNO, ClassName,ref FoundApplicationID);
        }

        public static bool IsThisLicenseClassCancelled(int DLAppID)
        {
            return clsDVLDdataAccessLocalApplication.IsThisLicenseClassExistCancelled(DLAppID);
        }

        public static bool CancelOrUpdateApplication(int ApplicationID, byte Status)
        {
            return clsDVLDdataAccessLocalApplication.CancelOrUpdateApplication(ApplicationID,Status);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications_View()
        {
            return clsDVLDdataAccessLocalApplication.GetAllLocalDrivingLicenseApplications_View();
        }

        public static DataTable GetAllLocalDrivingLicenseApplicationBy(string columntype,string ValueType)
        {
            return clsDVLDdataAccessLocalApplication.GetAllLocalDrivingLicenseApplicationBy(columntype, ValueType);
        }

        public static DataTable GetLocalApplicatinoAndLicenseInfoByApplicationPersonID(int PersonID)
        {
            return clsDVLDdataAccessLocalApplication.GetLocalApplicatinoAndLicenseInfoByApplicationPersonID(PersonID);
        }


        public static clsDVLDBusinessLocalApplication FindLocalDrivingLicenseApplications_ViewByID(int ID)
        {
            string ClassName = "";
            string NationalNo = "";
            string FullName = "";
            DateTime ApplicationDate  = DateTime.Now;
            int PassedTestCount = 0;
            string Status = "";
            int ApplicationID = -1;

            if (clsDVLDdataAccessLocalApplication.GetLocalDrivingLicenseApplications_ViewInfoByID(ID, ref ClassName, ref NationalNo, ref FullName, ref ApplicationDate,
                                                  ref PassedTestCount, ref Status , ref ApplicationID) )
            {
                return new clsDVLDBusinessLocalApplication(ID, ApplicationID, ClassName, NationalNo, FullName , ApplicationDate , PassedTestCount , Status);

            }
            else { return null; }
        }

        public static clsDVLDBusinessLocalApplication FindApplicationByID(int ID)
        {
            int ApplicantPersonID = -1;
            decimal PaidFees = 0;
            int ApplicationTypeID = -1;
            DateTime ApplicationDate = DateTime.Now;
            DateTime LastStatusDate = DateTime.Now;
            int CreatedUserID = -1;

            if (clsDVLDdataAccessLocalApplication.GetApplicationsInfoByID(ID, ref ApplicantPersonID, ref ApplicationDate , ref ApplicationTypeID, ref LastStatusDate,
                                                  ref PaidFees,ref CreatedUserID))
            {
                return new clsDVLDBusinessLocalApplication(ID, ApplicationTypeID, ApplicantPersonID, ApplicationDate, LastStatusDate, CreatedUserID, PaidFees);

            }
            else { return null; }
        }


        public static bool DeleteLocalDrivingLicenseAndApplication(int ApplicationID)
        {
            return clsDVLDdataAccessLocalApplication.DelteApplication(ApplicationID);

        }

        public static int IsThisPersonHasanActiveLicenseForThisApplication(int ApplicationPersonID,int ApplicationTypeID)
        {
            return clsDVLDdataAccessLocalApplication.IsThisPersonHasanActiveLicenseForThisApplication(ApplicationPersonID,ApplicationTypeID);

        }


      
    }
}
