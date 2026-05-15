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
    public class clsLicenseClass
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int MinAllowedAge { get; set; }

        public int DefualtValidityLength { get; set; }

        public float Fees { get; set; }

        public clsLicenseClass() 
        {
            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            MinAllowedAge = 0;
            DefualtValidityLength = 0;
            Fees = 0f;
        }

        private clsLicenseClass(int ID, string Name,string Description ,int MinAllowedAge,int DefualtValidityLength,float Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.MinAllowedAge = MinAllowedAge;
            this.DefualtValidityLength = DefualtValidityLength;
            this.Fees = Fees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static clsLicenseClass Find(int ID)
        {
            string Name = string.Empty;
            string Description = string.Empty;
            int MinAllowedAge = 0;
            int MinValidityLength = 0;
            float Fees = 0f;

            bool Isfound = clsLicenseClassData.GetLicenseClassInfoByID(ID,ref Name , ref Description, ref MinAllowedAge, ref MinValidityLength , ref Fees);

            if (Isfound)
            {
                return new clsLicenseClass(ID, Name,Description,MinAllowedAge,MinValidityLength,Fees);
            }
            return null;
        }

        public static clsLicenseClass Find(string Name)
        {
            int ID = -1;
            string Description = string.Empty;
            int MinAllowedAge = 0;
            int MinValidityLength = 0;
            float Fees = 0f;

            bool Isfound = clsLicenseClassData.GetLicenseClassInfoByName( Name,ref ID, ref Description, ref MinAllowedAge, ref MinValidityLength, ref Fees);

            if (Isfound)
            {
                return new clsLicenseClass(ID, Name, Description, MinAllowedAge, MinValidityLength, Fees);
            }
            return null;
        }

    }
}
