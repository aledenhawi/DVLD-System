using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsApplicationType
    {
        enum enMode { AddNew = 1, Update = 2 }

        enMode _Mode;

        public int ID { get; set; }

        public string Title { get; set; }

        public float Fees { get; set; }


        public clsApplicationType()
        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0.0f;
            _Mode = enMode.AddNew;
        }

        clsApplicationType(int ID, string Title, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }

        public static clsApplicationType Find(int ID)
        {
            string Title = "";
            float Fees = 0.0f;

            bool Isfound = clsApplicationTypeData.GetApplicationTypeInfoByID(ID, ref Title, ref Fees);

            if (Isfound)
            {
                return new clsApplicationType(ID, Title, Fees);
            }
            return null;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        private bool _Update()
        {
            return clsApplicationTypeData.UpdateApplicationType(ID, Title, Fees);
        }

        private bool _AddNewType()
        {
            this.ID = clsApplicationTypeData.AddNewApplicationType(Title, Fees);
            return (ID != -1);
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
