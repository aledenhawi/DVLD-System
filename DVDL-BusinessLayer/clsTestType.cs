using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsTestType
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        
        public enTestType ID { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }

        public float Fees { get; set; }

        public clsTestType()
        {
            this.ID = enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0.0f;
            _Mode = enMode.AddNew;
        }

        clsTestType(enTestType ID, string Title,string Description, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }

        public static clsTestType Find(enTestType ID)
        {
            string Title = "";
            float Fees = 0.0f;
            string Description = "";

            bool Isfound = clsTestTypeData.GetTestTypeInfoByID(Convert.ToInt32(ID), ref Title,ref Description, ref Fees);

            if (Isfound)
            {
                return new clsTestType(ID, Title,Description, Fees);
            }
            return null;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        private bool _Update()
        {
            return clsTestTypeData.UpdateTestType(Convert.ToInt32(ID), Title,Description, Fees);
        }

        private bool _AddNewType()
        {
            this.ID = (enTestType) clsTestTypeData.AddNewTestType(Title,Description, Fees);
            return (this.Title != "");
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                _Mode = enMode.Update;
                return _AddNewType();
            }
            else if (_Mode == enMode.Update)
            {
                return _Update();
            }
            return false;
        }
    }
}
