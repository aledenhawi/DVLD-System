using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsTestAppointmentData
    {

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                values(@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked,@RetakeTestApplicationID)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
            command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
            command.Parameters.Add("@AppointmentDate", SqlDbType.SmallDateTime).Value = AppointmentDate;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = IsLocked;
            if (RetakeTestApplicationID == -1)
                command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = DBNull.Value;
            else
                command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = RetakeTestApplicationID;





            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestAppointmentID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Test Appointment couldn't be added seccessfully", ex);
            }
            finally
            {
                Connection.Close();
            }

            return TestAppointmentID;
        }

        public static bool GetTestAppointmentInfoByID(int ID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked,ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @ID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            try
            {
                Connection.Open();
                using (SqlDataReader Reader = command.ExecuteReader())
                {
                    if (Reader.Read())
                    {
                        TestTypeID = Convert.ToInt32(Reader["TestTypeID"]);
                        LocalDrivingLicenseApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
                        AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                        PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                        CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                        IsLocked = Convert.ToBoolean(Reader["IsLocked"]);

                        RetakeTestApplicationID = Reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : Convert.ToInt32(Reader["RetakeTestApplicationID"]);

                        isFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Test Appointment couldn't be gettin seccessfully", ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID ,int TestTypeID, ref int TestAppointmentID,ref DateTime AppointmentDate,ref float PaidFees,ref int CreatedByUserID,ref bool IsLocked,ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select Top 1 * from TestAppointments 
                             Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID And TestTypeID = @TestTypeID
                             Order By TestAppointmentID Desc;
                             ";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
            command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;

            try
            {
                Connection.Open();
                using (SqlDataReader Reader = command.ExecuteReader())
                {
                    if (Reader.Read())
                    {
                        TestAppointmentID = Convert.ToInt32(Reader["TestAppointmentID"]);
                        TestTypeID = Convert.ToInt32(Reader["TestTypeID"]);
                        AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                        PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                        CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                        IsLocked = Convert.ToBoolean(Reader["IsLocked"]);
                        RetakeTestApplicationID = Reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : Convert.ToInt32(Reader["RetakeTestApplicationID"]);

                        isFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Last Test Appointment couldn't be gettin seccessfully", ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool UpdateTestAppointment(int ID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update TestAppointments 
                             set TestTypeID = @TestTypeID,
                                 LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                 AppointmentDate = @AppointmentDate,
                                 PaidFees = @PaidFees,
                                 CreatedByUserID = @CreatedByUserID,
                                 IsLocked = @IsLocked,
                                 RetakeTestApplicationID = @RetakeTestApplicationID
                             Where TestAppointmentID = @ID;";

            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
            command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
            command.Parameters.Add("@AppointmentDate", SqlDbType.SmallDateTime).Value = AppointmentDate;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = IsLocked;

            // Handle Null Nalue
            if (RetakeTestApplicationID == -1)
                command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = DBNull.Value;
            else
                command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = RetakeTestApplicationID;



            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLoger.LogError("Test Appointment couldn't be updated seccessfully", ex);
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetApplicatonTestAppointmentsPerTestTypeID(int LocalDrivingLicenseApplicationID,int TestType)
        {
            DataTable TestAppointmentDataTable = new DataTable();

            string Query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@LocalDrivingLicenseApplicationID",SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;
                    command.Parameters.Add("@TestTypeID",SqlDbType.Int).Value=TestType;
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            TestAppointmentDataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Test Appointment couldn't be gettin seccessfully", ex);
                    }
                }
            }
            return TestAppointmentDataTable;
        }

        public static DataTable GetAllTestAppointments()
        {
            DataTable TestAppointmentDataTable = new DataTable();

            string Query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            TestAppointmentDataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsLoger.LogError("Test Appointments couldn't be gettin seccessfully", ex);
                    }
                }
            }
            return TestAppointmentDataTable;
        }

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select TestID from Tests Where TestAppointmentID = @TestAppointmentID;";


            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = TestAppointmentID;


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
                clsLoger.LogError("TestID couldn't be gettin seccessfully", ex);
            }
            finally
            {
                Connection.Close();
            }

            return TestID;
        }
    }
}
