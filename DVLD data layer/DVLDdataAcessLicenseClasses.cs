using DVLDdataAccessLayerSetting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DVLDdataAccessLayer
{
    public class clsDVLDdataAcessLicenseClasses
    {
       

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT ClassName FROM LicenseClasses";

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

        public static bool GetLicenseClasseByName(string ClassName , ref int LicenseClassID , ref decimal ClassFees,ref byte DefaultValidityLength)
        {
            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM LicenseClasses where ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ClassName", ClassName);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassFees = (decimal)reader["ClassFees"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    isFound = true;

                }



               
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally { connection.Close(); }
            return isFound;
        }

        public static bool GetLicenseClasseByID(int LicenseClassID , ref string ClassName, ref decimal ClassFees, ref byte DefaultValidityLength)
        {
            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM LicenseClasses where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    ClassFees = (decimal)reader["ClassFees"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    isFound = true;

                }




            }
            catch (Exception)
            {
                isFound = false;
            }
            finally { connection.Close(); }
            return isFound;
        }




    }
}


