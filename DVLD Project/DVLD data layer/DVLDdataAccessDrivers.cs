using DVLDdataAccessLayerSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDdataAccessLayer
{
    public class clsDVLDdataAccessDrivers
    {
        public static int AddNewDriver(int PersonID , DateTime CreatedDate, int CreatedByUserID)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"insert into Drivers  (PersonID,CreatedDate,CreatedByuserID) 
                               values  (@PersonID,@CreatedDate,@CreatedByuserID);
                                 select  Scope_IDentity();"
            ;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
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
                //Console.WriteLine("Error: " + ex.Message);
                ReturnID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ReturnID;
        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);
            //we dont update the createddate for the driver.
            string query = @"Update  Drivers  
                            set PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID
                                where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT * FROM Drivers_View";

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

        public static DataTable GetAllDriversBy<T>(string ColumnType, T ValueType)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);


            string query = @"select * from Drivers_View  " + 
                                  $"     where {ColumnType} = @ValueType or {ColumnType} Like '' + @ValueType + '%'  ";
            

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
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return dt;

        }

        public static int IsThisPersonAdriver(int PersonID)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"select DriverID from Drivers where PersonID = @PersonID ";
            ;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);



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
                ReturnID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ReturnID;
        }

        public static bool GetDriverInfoByDriverID(int DriverID,
                ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


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

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID,
            ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

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

    }
}
