using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsLicenseClassData
    {

        public static DataTable GetAllLicenseClasses()
        {
            DataTable LicenseClassesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM LicenseClasses;";
            SqlDataReader Reader = null;
            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    LicenseClassesTable.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                //  Console.WriteLine(ex);
            }
            finally
            {
                Connection.Close();
            }
            return LicenseClassesTable;
        }

        public static bool GetLicenseClassInfoByID(int ID, ref string Name,ref string Description, ref int MinAllowedAge ,ref int DefaultValidityLength,ref float ClassFees)
        {
            bool isFound = false;


            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @ID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@ID", ID);
            SqlDataReader Reader = null;

            try
            {
                Connection.Open();
                Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    Name = Reader["ClassName"].ToString();
                    Description = Reader["ClassDescription"].ToString();
                    MinAllowedAge = Convert.ToInt32(Reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt32(Reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(Reader["ClassFees"]);

                    isFound = true;
                }

                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                if (Reader != null)
                    Reader.Close();
                Connection.Close();
            }
            return isFound;
        }

        public static bool GetLicenseClassInfoByName(string Name, ref int ID, ref string Description, ref int MinAllowedAge, ref int DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;

            SqlDataReader Reader = null;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT ClassID FROM LicenseClasses WHERE ClassName = @Name";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                Connection.Open();
                Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    ID = Convert.ToInt32(Reader["LicenseClassID"]);
                    Name = Reader["ClassName"].ToString();
                    Description = Reader["ClassDescription"].ToString();
                    MinAllowedAge = Convert.ToInt32(Reader["MinimamAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt32(Reader["MinimumValidityLength"]);
                    ClassFees = Convert.ToSingle(Reader["ClassFees"]);
                    isFound = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (Reader != null)
                    Reader.Close();
                Connection.Close();
            }
            return isFound;
        }
    
    }
}
