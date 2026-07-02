using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_DataLayer
{
    public class clsLicenseData
    {

        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref string Notes, ref float PaidFees, ref bool IsActive, ref short IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

            try
            {
                Connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    LicenseClass = Convert.ToInt32(Reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
                    // null value handeling
                    Notes = (Reader["Notes"] != DBNull.Value) ? Reader["Notes"].ToString() : null;
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    IssueReason = Convert.ToInt16(Reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    isFound = true;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("License Info Couldn't be Gettin Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllDriverLicenses(int DriverID)
        {
            DataTable DriversLicensesTable = new DataTable();

            string Query = @"SELECT
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID = @DriverID
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
                        clsLoger.LogError("Driver Licenses Info Couldn't be Gettin Seccussfully ", ex);
                    }
                }
            }
            return DriversLicensesTable;
        }

        public static DataTable GetAllLicenses()
        {
            DataTable DriversLicensesTable = new DataTable();

            string Query = @"SELECT * FROM Licenses;";


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
                        clsLoger.LogError("Licenses Info Couldn't be Gettin Seccussfully ", ex);
                    }
                }
            }
            return DriversLicensesTable;
        }
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, short IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Licenses (ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
                values(@ApplicationID, @DriverID, @LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add for insert
            command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
            command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
            command.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = LicenseClass;
            command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
            command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
            command.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = IssueReason;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

            // Handle Null value

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
                    LicenseID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("License Info Couldn't be Added Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, short IssueReason, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Licenses 
                             set ApplicationID = @ApplicationID,
                                 DriverID = @DriverID,
                                 LicenseClass = @LicenseClass,
                                 IssueDate = @IssueDate,
                                 ExpirationDate = @ExpirationDate,
                                 Notes = @Notes,
                                 PaidFees = @PaidFees,
                                 IsActive = @IsActive,
                                 IssueReason = @IssueReason,
                                 CreatedByUserID = @CreatedByUserID
                             Where LicenseID = @LicenseID;";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for update

            command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
            command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
            command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
            command.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = LicenseClass;
            command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = IssueDate;
            command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
            command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
            command.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = IssueReason;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

            // Handle Null value

            if (Notes != null)
                command.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = IsActive;
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);


            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("License Info Couldn't be Updated Seccussfully ", ex);
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static int GetActiveLicenseIDForPersonID(int PersonID,int LicenseClass) 
        {
            int LicenseID = -1;

            string Query = @"SELECT LicenseID FROM Licenses 
                             INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
                             WHERE PersonID = @PersonID AND LicenseClass = @LicenseClass AND IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                    command.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = LicenseClass;

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                            LicenseID = InsertedID;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Active LicenseID Couldn't be Gettin Seccussfully ", ex);
                    }
                    return LicenseID;
                }
            }

        }

        public static bool DeactivateLicense(int LicenseID)
        {
            string Query = @"Update Licenses set IsActive = 0 where LicenseID = @LicenseID;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                    try
                    {
                        connection.Open();
                        int RowsAffected = command.ExecuteNonQuery();
                        return RowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("License Couldn't be Deactivated Seccussfully ", ex);
                        return false;
                    }
                }
            }
        }
    }
}
