using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsInternationalLicenseData
    {
        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate,ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;

            try
            {
                Connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(Reader["IssuedUsingLocalLicenseID"]);
                    IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    isFound = true;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("International License Couldn't be Gettin Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllDriverInternationalLicenses(int DriverID)
        {
            DataTable DriversLicensesTable = new DataTable();

            string Query = @"SELECT
                           InternationalLicenses.InternationalLicenseID,
                           InternationalLicenses.ApplicationID, InternationalLicenses.IssuedUsingLocalLicenseID,
                           InternationalLicenses.IssueDate, 
		                   InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive
                           FROM InternationalLicenses
                           Where DriverID = @DriverID
                           Order By IsActive Desc, ExpirationDate Desc";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DriversLicensesTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("International License Couldn't be Getting Seccussfully ", ex);
                    }
                }
            }
            return DriversLicensesTable;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable DriversLicensesTable = new DataTable();

            string Query = @"SELECT
                           InternationalLicenses.InternationalLicenseID,
                           InternationalLicenses.ApplicationID, 
                           InternationalLicenses.DriverID,
                           InternationalLicenses.IssuedUsingLocalLicenseID,
                           InternationalLicenses.IssueDate, 
		                   InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive
                           FROM InternationalLicenses
                           Order By IsActive Desc, ExpirationDate Desc";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DriversLicensesTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("International Licenses Couldn't be Getting Seccussfully ", ex);
                    }
                }
            }
            return DriversLicensesTable;
        }

        public static int AddNewInternationalLicensesApplication(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                             
                               Update InternationalLicenses
                               set IsActive = 0 
                               where DriverID = @DriverID;

                             INSERT INTO InternationalLicenses
                                 (ApplicationID,
                                  DriverID,IssuedUsingLocalLicenseID,IssueDate,
                                  ExpirationDate,IsActive,CreatedByUserID)
                values(@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add for insert
            command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
            command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
            command.Parameters.Add("@IssuedUsingLocalLicenseId", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
            command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
            command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;


            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    InternationalLicenseID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("International License Couldn't be Added Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return InternationalLicenseID;
        }

        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update InternationalLicenses 
                             set ApplicationID = @ApplicationID,
                                 DriverID = @DriverID,
                                 IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                                 IssueDate = @IssueDate,
                                 ExpirationDate = @ExpirationDate,
                                 IsActive = @IsActive,
                                 CreatedByUserID = @CreatedByUserID
                             Where InternationalLicenseID = @InternationalLicenseID;";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for update

            command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;
            command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
            command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
            command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
            command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
            command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("International License Couldn't be Updated Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static int GetActiveInternationalLicenseIDForDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            string Query = @"SELECT InternationalLicenseID FROM InternationalLicenses
                             WHERE DriverID = @DriverID AND IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            InternationalLicenseID = InsertedID;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Active International LicenseID Couldn't be gettin Seccussfully ", ex);
                    }
                    return InternationalLicenseID;
                }
            }

        }

    }
}
