using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsTestData
    {
        public static int AddNewTest(int TestAppointmentID ,bool TestResult, string Notes,int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Tests (TestAppointmentID ,TestResult , Notes , CreatedByUserID)
                values(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID)
                
                UPDATE  TestAppointments
                set IsLocked = 1
                Where TestAppointmentID = @TestAppointmentID;
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add for insert

            command.Parameters.Add("@TestAppointmentID",SqlDbType.Int).Value = TestAppointmentID;
            command.Parameters.Add("@TestResult", SqlDbType.Bit).Value = TestResult;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

            if (!String.IsNullOrEmpty(Notes))
                command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = Notes;
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);


            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return TestID;
        }

        public static bool GetLastTestByPersonIDAndTestTypeAndLicenseClass(int PersonID,int LicenseClassID,int TestTypeID,ref int TestID,
            ref int TestAppointmentID,ref bool TestResult,ref string Notes,ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT TOP 1 Tests.TestAppointmentID, Tests.TestID, Tests.TestResult, Tests.Notes , Tests.CreatedByUserID 
                             from LocalDrivingLicenseApplications
                             inner join 
                             TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             inner join Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                             where Applications.ApplicantPersonID = @PersonID And
                             TestAppointments.TestTypeID = @TestTypeID And 
                             LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                             ORDER BY Tests.TestID DESC";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add for insert
            command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
            command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
            command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

            try
            {
                Connection.Open();
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    TestID = Convert.ToInt32(reader["TestID"]);
                    TestResult = Convert.ToBoolean(reader["TestResult"]);
                    Notes = (reader["Notes"] != DBNull.Value) ? reader["Notes"].ToString() : null;
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                    IsFound = true;
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static bool UpdateTest(int TestID ,int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Tests 
                             set TestAppointmentID = @TestAppointmentID,
                                 TestResult = @TestResult,
                                 Notes = @Notes,
                                 CreatedByUserID = @CreatedByUserID
                             Where TestID = @TestID;";


            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.Add("@TestID", SqlDbType.Int).Value = TestID;
            command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = TestAppointmentID;
            command.Parameters.Add("@TestResult", SqlDbType.Bit).Value = TestResult;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

            // Handle optional fields
            if (string.IsNullOrEmpty(Notes))
                command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = Notes;
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

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

        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Tests WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    Notes = (Reader["Notes"] != DBNull.Value) ? Reader["Notes"].ToString() : null;
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    TestAppointmentID = Convert.ToInt32(Reader["TestAppointmentID"]);
                    TestResult = Convert.ToBoolean(Reader["TestResult"]);
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

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationsID)
        {
            byte PassedTests = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select Count(TestID) from LocalDrivingLicenseApplications
                             INNER JOIN TestAppointments
                             ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN Tests
                             ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             where TestResult = 1 AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationsID";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.Add("@LocalDrivingLicenseApplicationsID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationsID;

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                PassedTests = Convert.ToByte(result);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return PassedTests;
        }

        public static bool DeleteTest(int ID)
        {
            int RowsAffected = 0;

            string Query = @"DELETE FROM Tests 
                     WHERE TestID = @ID";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                    connection.Open();

                    try
                    {
                        RowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllTests()
        {
            DataTable TestTable = new DataTable();

            string Query = "SELECT * FROM Tests;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            { 
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            TestTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return TestTable;
        }

        public static bool IsTestExists(int ID)
        {
            string Query = "SELECT Found = 1 FROM Tests WHERE TestID = @TestID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@TestID", SqlDbType.Int).Value = ID;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        short count = Convert.ToInt16(Result);
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine(ex);
                        return false;
                    }
                }
            }
        }

    }
}

