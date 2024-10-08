using DVLDdataAccessLayerSetting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLDdataAccessAllCountries
{
    public class clsDVLDdataAccessALLCountries
    {

        public static bool GetCountryInfoByID(int ID, ref int CountryID, ref string CountryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    CountryID = (int)reader["CountryID"];
                    CountryName = (string)reader["CountryName"];



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
                clsDVLDAccessSetting.LogError(ex.Message);
               
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        public static bool IsCountryExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT CountryID FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();

                isFound = Result.HasRows;





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

        public static int IsCountryExistByName(string Name)
        {
            bool isFound = false;
            int CountryID = 0;
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", Name);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();


                isFound = Result.HasRows;
               
                if (Result.Read())
                {
                    int tempCountryID;
                    if (int.TryParse(Result["CountryID"].ToString(), out tempCountryID))
                    {
                        CountryID = tempCountryID;
                    }
                }
               



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

            //return isFound;
            return CountryID;
        }



        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT CountryName FROM Countries";

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
                clsDVLDAccessSetting.LogError(ex.Message);

            }
            finally { connection.Close(); }
            return dt;

        }

        public static bool GetCountryInfoByName(string Name, ref int CountryID, ref string CountryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;



                    CountryID = (int)reader["CountryID"];
                    CountryName = (string)reader["CountryName"];



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
                clsDVLDAccessSetting.LogError(ex.Message);
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
