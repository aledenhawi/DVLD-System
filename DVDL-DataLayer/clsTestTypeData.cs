using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsTestTypeData
    {

        public static DataTable GetAllTestTypes()
        {
            DataTable TestTypesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM TestTypes ORDER BY TestTypeID;";
            SqlDataReader Reader = null;
            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    TestTypesTable.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return TestTypesTable;
        }

        public static bool GetTestTypeInfoByID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    TestTypeTitle = Reader["TestTypeTitle"].ToString();
                    TestTypeDescription = Reader["TestTypeDescription"].ToString();
                    TestTypeFees = Convert.ToSingle(Reader["TestTypeFees"]);
                    isFound = true;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription ,float TestTypeFees)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update TestTypes 
                             set TestTypeFees = @TestTypeFees,
                                 TestTypeTitle = @TestTypeTitle,
                                 TestTypeDescription = @TestTypeDescription
                             Where TestTypeID = @TestTypeID;";


            SqlCommand command = new SqlCommand(Query, Connection);


            //
            //
            // with value for update

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static int AddNewTestType(string TestTypeTitle,string TestTypeDescription, float TestTypeFees)
        {
            int TypeID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO TestTypes 
                values(@ApplicationTypeTitle,TestTypeDescription,@ApplicationFees)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TypeID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return TypeID;

        }
    }
}
