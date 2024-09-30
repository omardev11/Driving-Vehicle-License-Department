
using DVLDdataAccessLayer;
using DVLDdataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDVLDBusinessUsers
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public bool IsActive { get; set; }

        public int PersonID { get; set; }

        public enum enMode { UpdateMode = 1, AddnewUser = 2, DeleteMode = 3 };

        public enMode Mode = enMode.AddnewUser;

        private bool _AddNewUser()
        {
            this.UserID = clsDVLDdataAccessUsers.AddNewUser(this.UserName,this.Password,this.PersonID,this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsDVLDdataAccessUsers.UpdateUser(this.UserID, this.UserName, this.Password, this.PersonID, this.IsActive);
           
        }

        public static bool DeleteUser(int ID)
        {

            return clsDVLDdataAccessUsers.DeleteUser(ID);


        }

        public static DataTable GetAllUsersIsNotActive()
        {
            return clsDVLDdataAccessUsers.GetAllUsersIsNotActive();
        }

        public static DataTable GetAllUsersIsActive()
        {
            return clsDVLDdataAccessUsers.GetAllUsersActive();
        }

        public static DataTable GetAllUsersForList()
        {
            return clsDVLDdataAccessUsers.GetAllUsersForList();
        }


        private clsDVLDBusinessUsers(int UserID, string UserName,string Password,bool IsActive , int PersonID)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonID = PersonID;
            Mode = enMode.UpdateMode;
        }

        public clsDVLDBusinessUsers()

        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.PersonID = - 1;
            Mode = enMode.AddnewUser;

        }

        public static clsDVLDBusinessUsers FindUserByID(int ID)
        {
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            int PersonID = 0;

            if (clsDVLDdataAccessUsers.GetUserInfoByID(ID, ref UserName,ref Password,ref PersonID,  ref IsActive ))
            {
                return new clsDVLDBusinessUsers(ID ,UserName,Password,IsActive,PersonID);

            }
            else { return null; }
        }




        public static bool IsUserExistsByID(int ID)
        {
            return clsDVLDdataAccessUsers.IsUserExistByID(ID);
        }



        public static DataTable GetAllUsersBy<T>(string ColumnType, T ValueType)
        {
            return clsDVLDdataAccessUsers.GetAllUsersBy(ColumnType, ValueType);
        }

        public static DataTable GetAllUsers()
        {
            return clsDVLDdataAccessUsers.GetAllUsers();


        }

        public static bool IsThisPersonUser(int ID)
        {
            return clsDVLDdataAccessUsers.IsThisPersonUser(ID);
        }

        public static bool isThisUserActive(int UserID)
        {
            return clsDVLDdataAccessUsers.isThisUserActive(UserID);
        }
        public static int FindUserByUsernameAndPassword(string UserName , string Password)
        {
            return clsDVLDdataAccessUsers.FindUserByUsernameAndPassword(UserName, Password);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddnewUser:
                    if (_AddNewUser())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    if (_UpdateUser())
                    {
                        return true;
                    }
                    else
                    { return false; }
                case enMode.DeleteMode:

                default:
                    return false;
            }
        }
    }
}
