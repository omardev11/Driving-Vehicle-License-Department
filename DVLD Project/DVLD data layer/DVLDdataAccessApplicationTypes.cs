using DVLDdataAccessLayerSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDdataAccessLayer
{
    public class clsDVLDdataAccessApplicationTypes
    {
        public static bool GetApplicationTypeInfoByID(int ID, ref string Title, ref decimal Fees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = (decimal)reader["ApplicationFees"];



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

                if (!EventLog.SourceExists(clsDVLDAccessSetting.SourceName))
                {
                    EventLog.CreateEventSource(clsDVLDAccessSetting.SourceName, "Application");
                }
                EventLog.WriteEntry(clsDVLDAccessSetting.SourceName, ex.Message, EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsApplicationTypeExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT ApplicationTypeID FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ID);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();

                isFound = Result.HasRows;





            }
            catch (Exception ex)
            {

                if (!EventLog.SourceExists(clsDVLDAccessSetting.SourceName))
                {
                    EventLog.CreateEventSource(clsDVLDAccessSetting.SourceName, "Application");
                }
                EventLog.WriteEntry(clsDVLDAccessSetting.SourceName, ex.Message, EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int IsApplicationTypeExistByTitle(string Title)
        {
            bool isFound = false;
            int ApplicationTypeID = 0;
            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT ApplicationTypeID FROM ApplicationTypes WHERE ApplicationTypeTitle = @ApplicationTypeTitle";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);

            try
            {
                connection.Open();
                SqlDataReader Result = command.ExecuteReader();


                isFound = Result.HasRows;
               
                if (Result.Read())
                {
                    int tempApplicationTypeID;
                    if (int.TryParse(Result["ApplicationTypeID"].ToString(), out tempApplicationTypeID))
                    {
                        ApplicationTypeID = tempApplicationTypeID;
                    }
                }




            }
            catch (Exception ex)
            {

                if (!EventLog.SourceExists(clsDVLDAccessSetting.SourceName))
                {
                    EventLog.CreateEventSource(clsDVLDAccessSetting.SourceName, "Application");
                }
                EventLog.WriteEntry(clsDVLDAccessSetting.SourceName, ex.Message, EventLogEntryType.Error);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            //return isFound;
            return ApplicationTypeID;
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes";

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

                if (!EventLog.SourceExists(clsDVLDAccessSetting.SourceName))
                {
                    EventLog.CreateEventSource(clsDVLDAccessSetting.SourceName, "Application");
                }
                EventLog.WriteEntry(clsDVLDAccessSetting.SourceName, ex.Message, EventLogEntryType.Error);
            }
            finally { connection.Close(); }
            return dt;

        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeName, decimal Fees)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"UPDATE ApplicationTypes 
                 SET ApplicationTypeTitle = @ApplicationTypeTitle, 
                     ApplicationFees = @Fees
                 WHERE ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeName);
            command.Parameters.AddWithValue("@Fees", Fees);
          

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);




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
            catch (Exception ex)
            {

                if (!EventLog.SourceExists(clsDVLDAccessSetting.SourceName))
                {
                    EventLog.CreateEventSource(clsDVLDAccessSetting.SourceName, "Application");
                }
                EventLog.WriteEntry(clsDVLDAccessSetting.SourceName, ex.Message, EventLogEntryType.Error);
                IsUpdated = false;
            }
            finally
            {
                connection.Close();
            }

            return IsUpdated;
        }

    }
}
