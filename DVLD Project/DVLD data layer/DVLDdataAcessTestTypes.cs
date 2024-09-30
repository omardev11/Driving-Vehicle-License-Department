using DVLDdataAccessLayerSetting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDdataAccessLayer
{
    public  class clsDVLDdataAcessTestTypes
    {
        public static bool GetTestTypeInfoByID(int ID, ref string Title, ref decimal Fees,ref string Description)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    Title = (string)reader["TestTypeTitle"];
                    Fees = (decimal)reader["TestTypeFees"];
                    Description = (string)reader["TestTypeDescription"];



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsTestTypeExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT TestTypeID FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", ID);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();

                isFound = Result.HasRows;





            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int IsTestTypeExistByTitle(string Title)
        {
            bool isFound = false;
            int TestTypeID = 0;
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT TestTypeID FROM TestTypes WHERE TestTypeTitle = @TestTypeTitle";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();


                isFound = Result.HasRows;

                if (Result.Read())
                {
                    int tempTestTypeID;
                    if (int.TryParse(Result["TestTypeID"].ToString(), out tempTestTypeID))
                    {
                        TestTypeID = tempTestTypeID;
                    }
                }




            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            //return isFound;
            return TestTypeID;
        }

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM TestTypes";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;

        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeName, decimal Fees,string Description)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"UPDATE TestTypes 
                 SET TestTypeTitle = @TestTypeTitle, 
                     TestTypeFees = @Fees,
                     TestTypeDescription = @testTypeDescription
                 WHERE TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeName);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@testTypeDescription", Description);


            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);




            try
            {
                connection.Open();
                int RowEffected = command.ExecuteNonQuery();

                if (RowEffected > 0)
                {
                    IsUpdated = true;
                }
                else
                { IsUpdated = false; }






            }
            catch (Exception)
            {
                //Console.WriteLine("Error: " + ex.Message);
                IsUpdated = false;
            }
            finally
            {
                connection.Close();
            }

            return IsUpdated;
        }

        public static DataTable GetAllAppinmentsWhithThisLocalDrivingLicenseApplicantPersonByID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT TestAppointmentID as [Appoinment ID] , AppointmentDate as [Appoinment Date] , PaidFees as [Paid Fees], isLocked as [Is Locked] FROM TestAppointments  
                                         where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;
        }

        public static bool AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, 
                                                          int CreatedUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            bool IsAdded = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"insert into TestAppointments  (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID) 
                           values  (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@Islocked,@RetakeTestApplicationID);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedUserID);
            command.Parameters.AddWithValue("@Islocked", IsLocked);
            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }





            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    IsAdded = true;
                }
                else
                { IsAdded = false; }





            }
            catch (Exception )
            {
                IsAdded = false;
            }
            finally
            {
                connection.Close();
            }

            return IsAdded;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID, DateTime AppointmentDate,int RetakeTestApplicationID)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"Update  TestAppointments  
                                     set AppointmentDate  =  @AppointmentDate ,
                                         RetakeTestApplicationID = @RetakeTestApplicationID
                                             where TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }






            try
            {
                connection.Open();
                //object Result = command.ExecuteScalar();

                //if (Result != null)
                //{
                //    IsUpdated = true;
                //}
                //else
                //{ IsUpdated = false; }

                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    IsUpdated = true;
                }
                else
                { IsUpdated = false; }





            }
            catch (Exception)
            {
                IsUpdated = false;
            }
            finally
            {
                connection.Close();
            }

            return IsUpdated;
        }

        public static Stack<int> GelLocalDrivingLicenseApplicationIDByTestAppoinmentID(int TestAppoinmentID)
        {
            bool isFound = false;
            Stack<int> TestinFo = new Stack<int>();
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT LocalDrivingLicenseApplicationID,TestTypeID FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppoinmentID);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();


                isFound = Result.HasRows;

                if (Result.Read())
                {
                    int tempTestTypeID;
                    if (int.TryParse(Result["LocalDrivingLicenseApplicationID"].ToString(), out tempTestTypeID))
                    {
                        //TestTypeID = tempTestTypeID;
                        TestinFo.Push(tempTestTypeID);
                    }
                    if (int.TryParse(Result["TestTypeID"].ToString(), out tempTestTypeID))
                    {
                        //TestTypeID = tempTestTypeID;
                        TestinFo.Push(tempTestTypeID);
                    }
                }

                


            }
            catch (Exception )
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return TestinFo;
        }




        public static bool IsThisLocalDrivingLicenseApplicationHasAnActiveAppoinment(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplicationID FROM TestAppointments   
            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and  TestAppointments.IsLocked = 0";

        

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();

                isFound = Result.HasRows;





            }
            catch (Exception )
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsThisAppoinmentLocked(int TestAppoinmentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT TestAppointmentID FROM TestAppointments   
            WHERE TestAppointmentID = @TestAppointmentID and  IsLocked = 0";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppoinmentID);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();

                isFound = Result.HasRows;





            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewTest( int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"insert into Tests  (TestAppointmentID,TestResult,Notes,CreatedByUserID) 
                               values  (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);
                                 select  Scope_IDentity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppoinmentDate", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            if (Notes == "")
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);





            try
            {
                connection.Open();
             

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ReturnID = insertedID;
                }



            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return ReturnID;
        }

        public static bool unActivatedAppointment(int TestAppoinmentID)
        {
            bool IsAdded = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"Update  TestAppointments  
                                     set IsLocked  =  1 
                                             where TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppoinmentID);




            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    IsAdded = true;
                }
                else
                { IsAdded = false; }





            }
            catch (Exception)
            {
                IsAdded = false;
            }
            finally
            {
                connection.Close();
            }

            return IsAdded;
        }

        public static bool IsFail(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);


            string query = @"select TestAppointments.TestAppointmentID from TestAppointments join Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                   where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                    and TestAppointments.TestTypeID = @TestTypeID 
                                    and Tests.TestResult = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();

                isFound = Result.HasRows;





            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPass(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);


            string query = @"select TestAppointments.TestAppointmentID from TestAppointments join Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                   where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                    and TestAppointments.TestTypeID = @TestTypeID 
                                    and Tests.TestResult = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();

                isFound = Result.HasRows;





            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int GetRetakeTestApplicationID(int TestAppoinmentID)
        {
            bool isFound = false;
            int TestinFo = -1;
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT RetakeTestApplicationID FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppoinmentID);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();


                isFound = Result.HasRows;

                if (Result.Read())
                {
                    int tempTestTypeID;
                    if (Result["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        if (int.TryParse(Result["RetakeTestApplicationID"].ToString(), out tempTestTypeID))
                        {
                            TestinFo = tempTestTypeID;
                        }
                    }
                  
                  
                }




            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return TestinFo;
        }

        public static int TotalTrialperTest(int LocalDrivingLicenseID , int TestTypeID)
        {
            int TestinFo = -1;
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "select count(Tests.TestID) from Tests join TestAppointments on TestAppointments.TestAppointmentID = Tests.TestAppointmentID " +
                "   where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestAppointments.TestTypeID = @TestTypeID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();


                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    TestinFo = insertedID;
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return TestinFo;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return PassedTestCount;



        }

    }
}
