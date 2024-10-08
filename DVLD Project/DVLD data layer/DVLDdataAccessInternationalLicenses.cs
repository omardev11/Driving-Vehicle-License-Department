using DVLDdataAccessLayerSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDdataAccessLayer
{
    public class clsDVLDdataAccessInternationalLicenses
    {
        public static int AddNewInternatinalLicense(int ApplicationID, DateTime IssueDate, int DriverID, int IssuedUsingLocalLicenseID,
                                                      DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"     Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID;

           insert into InternationalLicenses  (ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID) 
                               values  (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
                                 select  Scope_IDentity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
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
            catch (Exception ex)
            {
                clsDVLDAccessSetting.LogError(ex.Message);
                ReturnID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ReturnID;
        }

        public static bool UpdateInternationalLicense(
           int InternationalLicenseID, int ApplicationID,
          int DriverID, int IssuedUsingLocalLicenseID,
          DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"UPDATE InternationalLicenses
                           SET 
                              ApplicationID=@ApplicationID,
                              DriverID = @DriverID,
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              IsActive = @IsActive,
                              CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                                clsDVLDAccessSetting.LogError(ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool GetInternationalLicenseInfoByID(int ID, ref int ApplicationID, ref DateTime IssueDate,ref int DriverID,ref int IssuedUsingLocalLicenseID,
                                                    ref  DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];



                }
                else
                {
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                clsDVLDAccessSetting.LogError(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetInternationalLicenseInfoByApplicationID(int ID, ref int InternationalLicenseID, ref DateTime IssueDate, ref int DriverID, ref int IssuedUsingLocalLicenseID,
                                                   ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];



                }
                else
                {
                    isFound = false;
                }

                reader.Close();


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

        public static bool GetInternationalLicenseInfoByLocalLicense(int ID, ref int InternationalLicenseID, ref DateTime IssueDate, ref int DriverID, ref int ApplicationID,
                                                   ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ApplicationID = (int)reader["ApplicationID"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];



                }
                else
                {
                    isFound = false;
                }

                reader.Close();


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


        public static bool IsThisLicenseHasAnActiveInternatinalLicense(int LocalLicense)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT InternationalLicenseID FROM InternationalLicenses WHERE  IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID and IsActive = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicense);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        isFound = true;
                    }
                }
                else
                {
                    isFound = false;
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

            return isFound;
        }

        public static DataTable GetInternationalLicenseInfoByApplicationPersonID(int ApplicantPersonID)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"select InternationalLicenses.InternationalLicenseID,InternationalLicenses.ApplicationID,
                                    InternationalLicenses.IssuedUsingLocalLicenseID as LocalLicenseID ,
                                    InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate , InternationalLicenses.IsActive
                            from InternationalLicenses join Applications 
                                     on InternationalLicenses.ApplicationID = Applications.ApplicationID  
		                   where Applications.ApplicantPersonID = @ApplicantPersonID and Applications.ApplicationTypeID = 6";



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

        public static DataTable GetAllInternationalLicenseApplications()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"select InternationalLicenses.InternationalLicenseID,InternationalLicenses.ApplicationID,InternationalLicenses.DriverID,
                                    InternationalLicenses.IssuedUsingLocalLicenseID as LocalLicenseID ,
                                    InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate , InternationalLicenses.IsActive
                            from InternationalLicenses";



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
            catch (Exception)
            {

            }
            finally { connection.Close(); }
            return dt;

        }

        public static DataTable GetAllInternationalDrivingLicenseApplicationBy<T>(string ColumnType, T ValueType)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);


            string query = @"select InternationalLicenses.InternationalLicenseID,InternationalLicenses.ApplicationID,InternationalLicenses.DriverID,
                                    InternationalLicenses.IssuedUsingLocalLicenseID as LocalLicenseID ,
                                    InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate , InternationalLicenses.IsActive
                            from InternationalLicenses" +
                               $"  where {ColumnType} = @ValueType or {ColumnType} like  '' + @ValueType + '%' ";



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
            catch (Exception)
            {

            }
            finally { connection.Close(); }
            return dt;

        }

        public static DataTable GetAllInternationalLicenseForThisDriver(int DriverID)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"									  SELECT     
                           InternationalLicenses.InternationalLicenseID,
                           ApplicationID,
		                   InternationalLicenses.DriverID, InternationalLicenses.IssueDate, 
		                   InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive
                           FROM InternationalLicenses 
                            where DriverID= @DriverID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
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


    }
}
