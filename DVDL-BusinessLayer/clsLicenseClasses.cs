using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsLicenseClasses
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int MinAllowedAge { get; set; }

        public int MinValidityLength { get; set; }

        public float Fees { get; set; }


        public clsLicenseClasses() 
        {
            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            MinAllowedAge = 0;
            MinValidityLength = 0;
            Fees = 0f;
        }

        private clsLicenseClasses(int ID, string Name,string Description ,int MinAllowedAge,int MinValidityLength,float Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.MinAllowedAge = MinAllowedAge;
            this.MinValidityLength = MinValidityLength;
            this.Fees = Fees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }

        public static clsLicenseClasses Find(int ID)
        {
            string Name = string.Empty;
            string Description = string.Empty;
            int MinAllowedAge = 0;
            int MinValidityLength = 0;
            float Fees = 0f;

            bool Isfound = clsLicenseClassesData.GetLicenseClassInfoByID(ID,ref Name , ref Description, ref MinAllowedAge, ref MinValidityLength , ref Fees);

            if (Isfound)
            {
                return new clsLicenseClasses(ID, Name,Description,MinAllowedAge,MinValidityLength,Fees);
            }
            return null;
        }

        public static clsLicenseClasses Find(string Name)
        {
            int ID = -1;
            string Description = string.Empty;
            int MinAllowedAge = 0;
            int MinValidityLength = 0;
            float Fees = 0f;

            bool Isfound = clsLicenseClassesData.GetLicenseClassInfoByName( Name,ref ID, ref Description, ref MinAllowedAge, ref MinValidityLength, ref Fees);

            if (Isfound)
            {
                return new clsLicenseClasses(ID, Name, Description, MinAllowedAge, MinValidityLength, Fees);
            }
            return null;
        }
    }
}
