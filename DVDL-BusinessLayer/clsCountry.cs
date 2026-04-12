using DVDL_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_BusinessLayer
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        public clsCountry() 
        {
            ID = -1;
            CountryName = string.Empty;
        }

        private clsCountry(int ID, string Name)
        {
            this.ID = ID;
            this.CountryName = Name;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public static clsCountry Find(int ID)
        {
            bool Isfound = clsCountryData.GetCountryInfoByID(ID, out string Name);

            if(Isfound) 
            {
            return new clsCountry(ID,Name);
            }
            return null;
        }

        public static clsCountry Find(string Name)
        {
            bool Isfound = clsCountryData.GetCountryInfoByName(Name, out int ID);

            if (Isfound)
            {
                return new clsCountry(ID, Name);
            }
            return null;
        }


    }
}
