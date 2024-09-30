using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessTestTypes
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }

        public decimal Fees { get; set; }

        public string Description { get; set; }

        private clsDVLDBusinessTestTypes(int ID, string Title, decimal Fees , string Description)
        {
            this.Fees = Fees;
            this.TestTypeTitle = Title;
            this.TestTypeID = ID;
            this.Description = Description;


        }

        public static clsDVLDBusinessTestTypes FindCTestTypeByID(int ID)
        {
            string Title = "";
            decimal Fees = 0;
            string Description = "";

            if (clsDVLDdataAcessTestTypes.GetTestTypeInfoByID(ID, ref Title, ref Fees , ref Description))
            {
                return new clsDVLDBusinessTestTypes(ID, Title, Fees,Description);

            }
            else { return null; }
        }

        public static bool IsTestTypeExistsByID(int ID)
        {
            return clsDVLDdataAcessTestTypes.IsTestTypeExistByID(ID);
        }

        public static int GetTestTypeIDByName(string Name)
        {
            return clsDVLDdataAcessTestTypes.IsTestTypeExistByTitle(Name);
        }


        public static bool UpdateTestType(int ID, string TestName, decimal Fees, string Description)
        {
            return clsDVLDdataAcessTestTypes.UpdateTestType(ID, TestName, Fees , Description);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsDVLDdataAcessTestTypes.GetAllTestTypes();


        }

        public static DataTable GetAllAppinmentsWhithThisLocalDrivingLicenseApplicantPersonByID(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsDVLDdataAcessTestTypes.GetAllAppinmentsWhithThisLocalDrivingLicenseApplicantPersonByID(LocalDrivingLicenseApplicationID , TestTypeID);
        }

        public static bool AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime ApplicationDate, decimal PaidFees, 
                                                             int CreatedUserID, bool IsLocked,int RetakeTestApplicationID)
        {
           return clsDVLDdataAcessTestTypes.AddNewTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, ApplicationDate, PaidFees, CreatedUserID, 
                                                                                                 IsLocked, RetakeTestApplicationID);
        }

        public static bool UpdateTestAppointment(int TestAppoinmentID , DateTime ApplicationDate, int RetakeTestApplicationID)
        {
            return clsDVLDdataAcessTestTypes.UpdateTestAppointment(TestAppoinmentID, ApplicationDate, RetakeTestApplicationID);
        }

        public static Stack<int> GelLocalDrivingLicenseApplicationIDByTestAppoinmentID(int TestAppoinmentID)
        {
            return clsDVLDdataAcessTestTypes.GelLocalDrivingLicenseApplicationIDByTestAppoinmentID(TestAppoinmentID);
        }

        public static bool IsThisLocalDrivingLicenseApplicationHasAnActiveAppoinment(int LocalDrivingLicenseApplicationID)
        {
            return clsDVLDdataAcessTestTypes.IsThisLocalDrivingLicenseApplicationHasAnActiveAppoinment(LocalDrivingLicenseApplicationID);
        }

        public static bool IsThisAppoinmentLocked(int TestAppoinmentID)
        {
            return clsDVLDdataAcessTestTypes.IsThisAppoinmentLocked(TestAppoinmentID);
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            return clsDVLDdataAcessTestTypes.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        public static bool unActivatedAppointment(int TestAppoinmentID)
        {
            return clsDVLDdataAcessTestTypes.unActivatedAppointment(TestAppoinmentID);
        }

        public static bool IsFail(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsDVLDdataAcessTestTypes.IsFail(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsPass(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsDVLDdataAcessTestTypes.IsPass(LocalDrivingLicenseApplicationID, TestTypeID);
        }


        public static int GetRetakeTestApplicationID(int TestAppoinmentID)
        {
            return clsDVLDdataAcessTestTypes.GetRetakeTestApplicationID(TestAppoinmentID);
        }

        public static int TotalTrialperTest(int LocalDrivingLicenseApplicationID,int TestTypeId)
        {
            return clsDVLDdataAcessTestTypes.TotalTrialperTest(LocalDrivingLicenseApplicationID,TestTypeId);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsDVLDdataAcessTestTypes.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
    }
}
