using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsDriver
    {
        enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;
        public int DriverID { get; set; }

        public int PersonID { get; set; }

        public int CreatedByUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public clsPerson PersonInfo
        {
            get 
            {
                return clsPerson.Find(PersonID);
            }
        }

        public clsDriver() 
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUser = -1;
            CreatedDate = DateTime.Now;
            _Mode = enMode.AddNew;
        }

        private clsDriver(int DriverID,int PersonID , int CreatedByUser, DateTime CreatedDate) 
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUser = CreatedByUser;
            this.CreatedDate = CreatedDate;
            _Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUser);

            return DriverID != -1;
        }

        private bool _UpdateDriver() 
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUser);
        }

        public bool Save() 
        {
            if (_Mode == enMode.AddNew)
            {
                if(_AddNewDriver())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else
                return _UpdateDriver();
        }

        public static clsDriver Find(int DriverID) 
        {
            int PersonID = -1;
            int CreatedByUser = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByID(DriverID, ref PersonID, ref CreatedByUser, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUser, CreatedDate);
            else
                return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUser = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUser, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUser, CreatedDate);
            else
                return null;
        }

        public static DataTable GetAllDrivers() 
        {
            return clsDriverData.GetAllDrivers();
        }

        public static bool IsDriverExists(int DriverID)
        {
            return clsDriverData.IsDriverExists(DriverID);
        }

        public static bool IsDriverExistsByPersonID(int PersonID)
        {
            return clsDriverData.IsDriverExistsByPersonID(PersonID);
        }

        public static bool DeleteDriver(int DriverID) 
        {
            return clsDriverData.DeleteDriver(DriverID);
        }

        public static bool IsPersonADriver(int PersonID) 
        {
           return clsDriverData.IsDriverExistsByPersonID(PersonID);
        }

        public DataTable GetDriverLicenses() 
        {
        return clsLicense.GetDriverLicenses(this.DriverID);
        }
        // Check It later Add GetInternationalLicenses

    }
}
