using DVDL_DataAccessLayer;
using DVDL_DataLayer;
using DVLD_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsUser
    {
        enum enMode { AddNew = 1, Update = 2 }

        enMode _Mode;
        public int ID { get; set; }

        public int PersonID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public string Username { get; set; }

        private string _Password;
        public string Password { get { return _Password; } set { _Password = clsUtil.ComputeHash(value); }}

        public bool IsActive { get; set; }
        
        public clsUser() 
        {
            ID = -1;
            clsPerson person = new clsPerson();
            Username = "";
            Password = "";
            IsActive = false;
            _Mode = enMode.AddNew;
        }

        private clsUser(int ID, int PersonID , string Username , string Password,bool IsActive) 
        {
            this.ID = ID;
            _Password = Password;
            this.Username = Username;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.IsActive = IsActive;
            _Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.ID = clsUserData.AddNewUser(this.PersonID, this.Username,this.Password, this.IsActive);


            return (this.ID != -1);

        }

        private bool _Update() 
        {
            return clsUserData.UpdateUser(ID, Username, Password, IsActive);
        }

        public static clsUser Find(int ID) 
        {
            string Username = null;
            string Password = null;
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByID(ID ,ref PersonID,ref Username,ref Password ,ref IsActive ))
                return new clsUser(ID, PersonID, Username, Password, IsActive);
            else
                return null;
        }

        public static clsUser Find(string Username)
        {
            int UserID = -1;
            string Password = null;
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByUsername(Username, ref UserID, ref PersonID, ref Password,ref IsActive))
                return new clsUser(UserID, PersonID, Username, Password,IsActive);
            else
                return null;
        }

        public static clsUser Find(string Username,string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserInfoByUsernameAndPassword(Username , Password, ref UserID, ref PersonID, ref IsActive))
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }

        public bool Save() 
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    if (_Update())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        public static DataTable GetAllUsers() 
        {
        return clsUserData.GetAllUsers();
        }

        public static bool Delete(int ID) 
        {
        return clsUserData.DeleteUser(ID);
        }

        public static bool IsExists(int ID) 
        {
            return clsUserData.IsUserExists(ID);
        }

        public static bool IsExists(string Username)
        {
            return clsUserData.IsUserExists(Username);
        }

        public static bool IsExistsUsingPersonID(int PersonID)
        {
            return clsUserData.IsUserExistsUsingPersonID(PersonID);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUserData.ChangePassword(this.ID,clsUtil.ComputeHash(NewPassword));
        }
    }
}
