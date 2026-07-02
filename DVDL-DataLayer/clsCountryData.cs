using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsCountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable CountriesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries;";
            SqlDataReader Reader = null;
            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    CountriesTable.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                clsLoger.LogError("Countries Couldn't be Gettin From the Database ", ex);
            }
            finally
            {
                Connection.Close();
            }
            return CountriesTable;
        }

        public static bool GetCountryInfoByID(int ID ,out string Name) 
        {
            bool isFound = false;
            Name = "";
            SqlDataReader Reader = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Countries WHERE CountryID = @ID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                Connection.Open();
                Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    Name = Reader["CountryName"].ToString();
                    isFound = true;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Country Couldn't be Gettin From the Database ", ex);
            }
            finally
            {
                if (Reader != null)
                    Reader.Close();
                Connection.Close();
            }
            return isFound;
        }

        public static bool GetCountryInfoByName(string Name,out int ID)
        {
            bool isFound = false;
            ID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT CountryID FROM Countries WHERE CountryName = @Name";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                Connection.Open();
                object Result = command.ExecuteScalar();

                if (Result != null)
                {
                    ID = Convert.ToInt32(Result);
                    isFound = true;
                }

            }
            catch (Exception ex)
            {
                clsLoger.LogError("Country Couldn't be Gettin From the Database ", ex);
            }
            finally
            {

                Connection.Close();
            }
            return isFound;
        }
    }
}
