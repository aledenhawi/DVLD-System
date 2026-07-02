using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsApplicationData
    {
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            int ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Applications (ApplicantPersonID ,ApplicationDate , ApplicationTypeID , ApplicationStatus , LastStatusDate ,PaidFees, CreatedByUserID)
                values(@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate,@PaidFees,@CreatedByUserID)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
            command.Parameters.Add("@ApplicationDate", SqlDbType.SmallDateTime).Value = ApplicationDate;
            command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
            command.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
            command.Parameters.Add("@LastStatusDate", SqlDbType.SmallDateTime).Value = LastStatusDate;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;


            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ApplicationID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Application Couldn't be Added to the Database ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;
        }

        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
            ref int ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@ID", SqlDbType.Int).Value = ApplicationID;


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicantPersonID = Convert.ToInt32(Reader["ApplicantPersonID"]);
                    ApplicationDate = Convert.ToDateTime(Reader["ApplicationDate"]);
                    ApplicationTypeID = Convert.ToInt32(Reader["ApplicationTypeID"]);
                    ApplicationStatus = Convert.ToInt32(Reader["ApplicationStatus"]);
                    LastStatusDate = Convert.ToDateTime(Reader["LastStatusDate"]);
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    isFound = true;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Application Couldn't be get from the database ",ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            int ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Applications 
                             set ApplicantPersonID = @ApplicantPersonID,
                                 ApplicationDate = @ApplicationDate,
                                 ApplicationTypeID = @ApplicationTypeID,
                                 ApplicationStatus = @ApplicationStatus,
                                 LastStatusDate = @LastStatusDate,
                                 PaidFees = @PaidFees,
                                 CreatedByUserID = @CreatedByUserID
                             Where ApplicationID = @ApplicationID;";


            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
            command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;
            command.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = ApplicationDate;
            command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
            command.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
            command.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = LastStatusDate;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;

            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Application Couldn't be Update in the database ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            int RowsAffected = 0;

            string Query = @"DELETE FROM Applications 
                     WHERE ApplicationID = @ApplicationID";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                    try
                    {

                        connection.Open();
                        RowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex )
                    {
                        clsLoger.LogError("Application Couldn't be Deleted From the Database ", ex);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static bool UpdateStatus(int ApplicationID,short NewStatus)
        {
            int RowsAffected = 0;
            string Query = @"UPDATE Applications 
                     SET ApplicationStatus = @NewStatus, LastStatusDate = GETDATE() 
                     WHERE ApplicationID = @ApplicationID;";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    cmd.Parameters.Add("@NewStatus",SqlDbType.Int).Value = NewStatus;

                    try
                    {
                        connection.Open();
                        RowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Application Status Couldn't be updated in Database ", ex);
                    }
                }
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllApplications()
        {
            DataTable ApplicationsTable = new DataTable();

            string Query = @"SELECT * FROM Applications
                             Order By ApplicationDate Desc;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ApplicationsTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Applications Couldn't be get From the Database ", ex);
                }
            }
            return ApplicationsTable;
        }

        public static bool DoesPersonHasActiveApplication(int ApplicantPersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationID(ApplicantPersonID, ApplicationTypeID) != -1);
        }

        public static bool DoesPersonHasActiveApplicationForLicenseClass(int ApplicantPersonID,int ApplicationTypeID, int LicenseClassID)
        {
            return (GetActiveApplicationIDForLicenseClass(ApplicantPersonID,ApplicationTypeID, LicenseClassID) != -1);
        }

        public static bool IsApplicationExists(int ApplicationID)
        {
            string Query = "SELECT Count(*) FROM Applications WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError( "Finding the application didn't go well", ex);
                        return false;
                    }
                }
            }
        }

        public static int GetActiveApplicationID(int ApplicantPersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select ApplicationID from Applications
                             where ApplicantPersonID = @ApplicantPersonID And ApplicationTypeID = @ApplicationTypeID And ApplicationStatus = 1;";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
            command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = ApplicantPersonID;

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ActiveApplicationID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Active Application Couldn't be Get From the Database ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return ActiveApplicationID;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;


            string Query = @"SELECT LocalDrivingLicenseApplications.ApplicationID FROM LocalDrivingLicenseApplications
                             INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                             WHERE ApplicantPersonID = @PersonID AND
                             ApplicationTypeID = @ApplicationTypeID AND
                             LicenseClassID = @LicenseClassID And 
                             ApplicationStatus = 1;
                             ";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                    command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;
                    command.Parameters.Add("@ApplicationTypeID",SqlDbType.Int).Value = ApplicationTypeID;
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            ActiveApplicationID = InsertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Active ApplicationID Couldn't be Deleted From the Database ", ex);
                    }
                }
            }
            return ActiveApplicationID;
        }

    }
}

