using DVDL_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public enum GenderType : byte
        {
            Male = 1,
            Female = 0
        }

        public GenderType Gender { get; set; }
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string NationalNo { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string ImagePath { set; get; }

        public clsCountry CountryInfo;
        public int NationalityCountryID { set; get; }

        public clsPerson()
        {
            ID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Gender = GenderType.Male;
            NationalNo = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = DateTime.Now;
            ImagePath = "";
            NationalityCountryID = -1;
            _Mode = enMode.AddNew;
        }
        private clsPerson(int ID, string FirstName, string SecondName, string ThirdName, string LastName, byte Gender, string NationalNo, string Email,
            string Phone, string Address, DateTime DateOfBirth, string ImagePath, int NationalityCountryID)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = (GenderType)Gender;
            this.NationalNo = NationalNo;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            _Mode = enMode.Update;
        }

        public static clsPerson Find(int ID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int NationalityCountryID = 0;
            if (clsPersonData.GetPersonInfoByID(ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref Email, ref Phone, ref Address, ref DateOfBirth, ref ImagePath, ref NationalityCountryID, ref Gender))
            {
                return new clsPerson(ID, FirstName, SecondName, ThirdName, LastName, Gender, NationalNo, Email, Phone, Address, DateOfBirth, ImagePath, NationalityCountryID);
            }
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int NationalityCountryID = 0, ID = 0;

            if (clsPersonData.GetPersonInfoByNationalNo(ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, NationalNo, ref Email, ref Phone, ref Address, ref DateOfBirth, ref ImagePath, ref NationalityCountryID, ref Gender))
            {
                return new clsPerson(ID, FirstName, SecondName, ThirdName, LastName, Gender, NationalNo, Email, Phone, Address, DateOfBirth, ImagePath, NationalityCountryID);
            }
            else
                return null;
        }

        private bool _AddNewPerson()
        {
            this.ID = DVDL_DataAccessLayer.clsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo,
                this.Email, this.Phone, this.Address, this.DateOfBirth, this.ImagePath, this.NationalityCountryID, (byte)this.Gender);

            return (ID != 1);
        }

        private bool _Update()
        {
            return DVDL_DataAccessLayer.clsPersonData.UpdatePerson(ID, FirstName, SecondName, ThirdName, LastName, NationalNo,
                Email, Phone, Address, DateOfBirth, ImagePath, NationalityCountryID,(byte)this.Gender);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
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

        public static bool DeletePerson(int ID)
        {
            return DVDL_DataAccessLayer.clsPersonData.DeletePerson(ID);
        }

        public static DataTable GetAllPeople()
        {
            return DVDL_DataAccessLayer.clsPersonData.GetAllPeople();
        }

        public static bool IsPersonExists(string NationalNo)
        {
            return DVDL_DataAccessLayer.clsPersonData.IsPersonExists(NationalNo);
        }
        
        public static bool IsPersonExists(int ID)
        {
            return DVDL_DataAccessLayer.clsPersonData.IsPersonExists(ID);
        }

        public static short CalculateAge(DateTime DateOfBirth)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - DateOfBirth.Year;

            if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day))
            {
                age--;
            }

            return (short)age;
        }

        public short CalculateAge()
        {
            return CalculateAge(this.DateOfBirth);
        }

        public string GetFullName()
        {
            return $"{FirstName} {SecondName} {ThirdName} {LastName}".Trim();
        }
    }
}
