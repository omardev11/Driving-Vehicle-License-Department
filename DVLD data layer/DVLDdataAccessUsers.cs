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
    public class clsDVLDdataAccessUsers
    {
        public static bool GetUserInfoByID(int ID, ref string UserName, ref string Passaword, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    UserName = (string)reader["UserName"];
                    Passaword = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                   

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception )
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

        public static int AddNewUser( string UserName,  string Passaword,  int PersonID,  bool IsActive)
        {
            int ReturnID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"insert into Users  (UserName,Password,PersonID,IsActive) 
                               values  (@UserName,@Password,@PersonID,@IsActive);
                                 select  Scope_IDentity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Passaword);
            command.Parameters.AddWithValue("@IsActive", IsActive);
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
            catch (Exception ex)
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

        public static bool UpdateUser(int UserID,  string UserName,  string Passaword,  int PersonID,  bool IsActive)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"UPDATE Users 
                 SET UserName = @UserName, 
                     IsActive = @IsActive,
                     Password = @Password, 
                     PersonID = @PersonID 
                 WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Passaword);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PersonID", PersonID);
          
            command.Parameters.AddWithValue("@UserID", UserID);




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
            catch (Exception )
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

        public static bool DeleteUser(int UserID)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"Delete from  Users 
                 WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);




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
            catch (Exception )
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

        public static DataTable GetAllUsersForList()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT Users.UserID,
                                    Users.PersonID,
                                    FullName = (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName), 
                                    Users.UserName, 
                                    Users.IsActive  
                                    FROM Users join People  on Users.personID = People.PersonID";

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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = @"SELECT * FROM Users";

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

        public static bool IsUserExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT UserID FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", ID);

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

        public static DataTable GetAllUsersBy<T>(string ColumnType, T ValueType)
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "";
            if (ColumnType.ToLower() != "fullname")
            {
                 query = @"SELECT Users.UserID,
                                    Users.PersonID,
                                    FullName = (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName), 
                                    Users.UserName, 
                                    Users.IsActive  
                                    FROM Users join People  on Users.personID = People.PersonID" + "  " +
                                   $"     where Users.{ColumnType} = @ValueType or Users.{ColumnType} Like '' + @ValueType + '%'  ";
            }
            else
            {
                query = @"SELECT Users.UserID,
                                    Users.PersonID,
                                    FullName = (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName), 
                                    Users.UserName, 
                                    Users.IsActive  
                                    FROM Users join People  on Users.personID = People.PersonID" + "  " +
                                  $"     where (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) = @ValueType or " +
                                  $" (People.FirstName+People.SecondName+People.thirdName+people.LastName) Like '' + @ValueType + '%'  ";
            }
           

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



        public static DataTable GetAllUsersActive()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);


            string  query = @"SELECT Users.UserID,
                                    Users.PersonID,
                                    FullName = (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName), 
                                    Users.UserName, 
                                    Users.IsActive  
                                    FROM Users join People  on Users.personID = People.PersonID" + "  " +
                                   $"     where Users.IsActive = 1";

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

        public static DataTable GetAllUsersIsNotActive()
        {
            DataTable dt = new DataTable();



            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);


            string query = @"SELECT Users.UserID,
                                    Users.PersonID,
                                    FullName = (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName), 
                                    Users.UserName, 
                                    Users.IsActive  
                                    FROM Users join People  on Users.personID = People.PersonID" + "  " +
                                   $"     where Users.IsActive = 0";
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

        public static bool IsThisPersonUser(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

              


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

        public static bool isThisUserActive(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT UserID FROM Users WHERE UserID = @UserID and  IsActive = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;




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

        public static int FindUserByUsernameAndPassword(string UserName,string Password)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDVLDAccessSetting.ConnectionString);

            string query = "SELECT UserID FROM Users WHERE UserName = @UserName and Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }




            }
            catch (Exception )
            {
                UserID = -1;
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

    }
}
