using DVLDdataAccessLayerSetting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace DVLDdataAccessLayer
{
    public  class clsDVLDdataAccessLocalApplication
    {

        public static int AddNewLocalDrivingApplication(int ApplicationID, int LicenseClassID)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"insert into LocalDrivingLicenseApplications  (ApplicationID,LicenseClassID) 
                               values  (@ApplicationID,@LicenseClassID);
                                 select  Scope_IDentity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);




            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ReturnID = insertedID;
                }





            }
            catch (Exception )
            {
                //Console.WriteLine("Error: " + ex.Message);
                ReturnID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ReturnID;
        }

        public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus,
                                                       DateTime LastStatusDate,decimal PaidFees,int CreatedByUserID)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"insert into Applications  (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID) 
                               values  (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
                                 select  Scope_IDentity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
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
            catch (Exception )
            {
                //Console.WriteLine("Error: " + ex.Message);
                ReturnID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ReturnID;
        }
        public static bool IsThisLicenseClassExistInThisPerson(string nationalNO, string ClassName , ref int FoundApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT ApplicationID FROM LocalDrivingLicenseApplications_View WHERE " +
                     $"           ( NationalNo = @NationalNo )  and ( ClassName = '{ClassName}' ) and ( Status in ('New','Completed') ) ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", nationalNO);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        FoundApplicationID = reader.GetInt32(reader.GetOrdinal("ApplicationID"));
                        isFound = true;
                    }
                }
                else
                {
                    FoundApplicationID = -1;
                    isFound = false;
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

            return isFound;
        }

        public static bool CancelOrUpdateApplication( int ApplicationID, byte ApplicationStatus)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"UPDATE Applications 
                 SET ApplicationStatus = @ApplicationStatus ,
                     LastStatusDate = @LastStatusDate
                 WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);




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
        public static DataTable GetAllLocalDrivingLicenseApplications_View()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"select * from LocalDrivingLicenseApplications_View join Applications on 
                                    LocalDrivingLicenseApplications_View.ApplicationID = Applications.ApplicationID 
                                    where Applications.ApplicationTypeID = 1 ";

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
            catch (Exception )
            {

            }
            finally { connection.Close(); }
            return dt;

        }

        public static DataTable GetAllLocalDrivingLicenseApplicationBy<T>(string ColumnType, T ValueType)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

          
             string  query = $"SELECT * FROM LocalDrivingLicenseApplications_View  " +
                    $"        where  {ColumnType} = @ValueType or {ColumnType} Like '' + @ValueType + '%'  ";
          


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ValueType", ValueType);



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
            catch (Exception )
            {

            }
            finally { connection.Close(); }
            return dt;

        }

        public static bool GetLocalDrivingLicenseApplications_ViewInfoByID(int ID, ref string ClassName, ref string NationalNO, 
                                           ref string FullName, ref DateTime ApplicationDate , ref int PassedTestCount , ref string Status , ref int ApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    NationalNO = (string)reader["NationalNO"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    FullName = (string)reader["FullName"];
                    PassedTestCount = (int)reader["PassedTestCount"];
                    Status = (string)reader["Status"];
                    ApplicationID = (int)reader["ApplicationID"];



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception)
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


        public static bool GetApplicationsInfoByID(int ID, ref int ApplicantPersonID , ref DateTime ApplicationDate, ref int ApplicationTypeID, 
                                                                                   ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception)
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


        public static bool IsThisLicenseClassExistCancelled(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT LocalDrivingLicenseApplicationID FROM LocalDrivingLicenseApplications_View WHERE " +
                     $"           ( LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID )  and ( Status = 'Cancelled' ) ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
               

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


        public static DataTable GetLocalApplicatinoAndLicenseInfoByApplicationPersonID(int ApplicantPersonID)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, Applications.ApplicationID, LicenseClasses.ClassName, 
                                 Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive 
                          FROM     LocalDrivingLicenseApplications  JOIN                 
                                  Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID     JOIN  
                                 Licenses ON Applications.ApplicationID = Licenses.ApplicationID                                 JOIN
                                 LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID  
                                      Where Applications.ApplicantPersonID = @ApplicantPersonID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
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
            catch (Exception)
            {

            }
            finally { connection.Close(); }
            return dt;

        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            bool IsDelted = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "Delete From LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();


                int RowEffected = command.ExecuteNonQuery();

                if (RowEffected > 0)
                {
                    IsDelted = true;
                }
                else
                { IsDelted = false; }




            }
            catch (Exception )
            {
                IsDelted = false;
            }
            finally
            {
                connection.Close();
            }

            return IsDelted;
        }

        public static bool DelteApplication(int ApplicationID)
        {
            bool IsDelted = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "Delete From LocalDrivingLicenseApplications where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();


                int RowEffected = command.ExecuteNonQuery();

                if (RowEffected > 0)
                {
                    IsDelted = true;
                }
                else
                { IsDelted = false; }




            }
            catch (Exception)
            {
                IsDelted = false;
            }
            finally
            {
                connection.Close();
            }

            return IsDelted;
        }


        public static int IsThisPersonHasanActiveLicenseForThisApplication(int ApplicantPersonID,int ApplicationTypeID)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT ApplicationID FROM Applications WHERE " +
                     $"           ( ApplicantPersonID = @ApplicantPersonID )  and ( ApplicationTypeID = @ApplicationTypeID ) ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
         
                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    ReturnID = insertedID;
                }


            }
            catch (Exception )
            {
                ReturnID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ReturnID;
        }


    }
}
