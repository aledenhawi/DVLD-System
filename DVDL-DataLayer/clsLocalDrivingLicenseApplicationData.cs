using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_DataLayer
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationsID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                values(@ApplicationID,@LicenseClassID)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    LocalDrivingLicenseApplicationsID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Local Driving License Application Couldn't be Added Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return LocalDrivingLicenseApplicationsID;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByID(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            try
            {
                Connection.Open();
                using (SqlDataReader Reader = command.ExecuteReader())
                {
                    if (Reader.Read())
                    {
                        ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                        LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
                        isFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Local Driving License Application Info Couldn't be Gettin Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicatoinID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

            try
            {
                Connection.Open();
                using (SqlDataReader Reader = command.ExecuteReader())
                {
                    if (Reader.Read())
                    {
                        LocalDrivingLicenseApplicatoinID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
                        LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
                        isFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Local Driving License Application Info Couldn't be gettin Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int ID, int LicenseClassID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update LocalDrivingLicenseApplications
                             set LicenseClassID = @LicenseClassID
                             Where LocalDrivingLicenseApplicationID = @ID;";


            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Updating Local Driving License Application Couldn't be Done Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {
            int RowsAffected = 0;

            string Query = @"DELETE FROM LocalDrivingLicenseApplications 
                     WHERE LocalDrivingLicenseApplicationID = @ID";


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
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Local Driving License Application Couldn't be Deleted Seccussfully ", ex);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable LocalDrivingLicenseApplicationsTable = new DataTable();

            string Query = @"SELECT * FROM LocalDrivingLicenseApplications_View
                             Order By ApplicationDate Desc;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        LocalDrivingLicenseApplicationsTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Local Driving License Applications Couldn't be Gettin Seccussfully ", ex);
                }
            }
            return LocalDrivingLicenseApplicationsTable;
        }

        public static bool IsLocalDrivingLicenseApplicationExists(int ID)
        {
            string Query = "SELECT Count(LocalDrivingLicenseApplicationID) FROM LocalDrivingLicenseApplication WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = ID;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        int count = Convert.ToInt32(Result);
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Local Driving License Application Couldn't be Found in Database Seccussfully ", ex);
                        return false;
                    }
                }
            }
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsPassed = false;

            string Query = @"SELECT TOP 1 TestResult
                             FROM LocalDrivingLicenseApplications
                             INNER JOIN TestAppointments
                               ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN Tests
                               ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND TestTypeID = @TestTypeID
                             ORDER BY Tests.TestID DESC;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                    command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null) 
                            IsPassed = Convert.ToBoolean(Result);
                        return IsPassed;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Checking Pass Test Type is not Done Seccessfully ", ex);
                        return false;
                    }
                }
            }
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Attended = false;

            string Query = @"SELECT top 1 TestResult from LocalDrivingLicenseApplications
                             INNER JOIN TestAppointments
                             ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN Tests
                             ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID
                             Order by TestAppointments.TestAppointmentID desc;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                    command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        Attended = (Result != null);
                        return Attended;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Does attend the test did not checked seccessfully", ex);
                        return false;
                    }
                }
            }
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;
            string Query = @"Select count(*) as TotalTrialsPerTest from LocalDrivingLicenseApplications
                             INNER JOIN TestAppointments
                             ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             INNER JOIN Tests
                             ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             where TestTypeID = @TestTypeID AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                    command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null) 
                            TotalTrialsPerTest = Convert.ToByte(Result);

                        return TotalTrialsPerTest;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Total Trials Per Test is not Getting Seccessfully", ex);
                        return TotalTrialsPerTest;
                    }
                }
            }
        }

        public static bool IsThereAnActiveSchduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsThereAnActiveScheduledTest = false;
            string Query = @"Select top 1 Found = 1 from LocalDrivingLicenseApplications
                             INNER JOIN TestAppointments
                             ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             where TestTypeID = @TestTypeID AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND IsLocked = 0
                             Order By TestAppointments.TestAppointmentID desc;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                    command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null)
                            IsThereAnActiveScheduledTest = Convert.ToBoolean(Result);
                        return IsThereAnActiveScheduledTest;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Active Scheduled Test Couldn't be Found in Database ", ex);
                        return IsThereAnActiveScheduledTest;
                    }
                }
            }
        }


    }
}
