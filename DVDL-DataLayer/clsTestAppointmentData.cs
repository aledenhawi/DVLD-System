using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsTestAppointmentData
    {
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseID, DateTime AppoitmentDate, float PaidFees, int CreatedByUser, bool IsLocked)
        {
            int LocalDrivingLicenseApplicationsID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO LocalDrivingLicenseApplications (TestTypeID,LocalDrivingLicenseID,AppoitmentDate,PaidFees,CreatedByUser,IsLocked)
                values(@AppointmentID,@TestTypeID,@LocalDrivingLicenseID,@AppoitmentDate,@PaidFees,@CreatedByUser,@IsLocked)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
            command.Parameters.Add("@LocalDrivingLicenseID", SqlDbType.Int).Value = LocalDrivingLicenseID;
            command.Parameters.Add("@AppoitmentDate", SqlDbType.SmallDateTime).Value = AppoitmentDate;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
            command.Parameters.Add("@CreatedByUser", SqlDbType.Int).Value = CreatedByUser;
            command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = IsLocked;


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

            }
            finally
            {
                Connection.Close();
            }

            return LocalDrivingLicenseApplicationsID;
        }

        public static bool GetTestAppointmentInfoByID(int ID, ref int TestTypeID, ref int LocalDrivingLicenseID, ref DateTime AppoitmentDate, ref float PaidFees, ref int CreatedByUser, ref bool IsLocked)
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
                        LocalDrivingLicenseID = Convert.ToInt32(Reader["LocalDrivingLicenseID"]);
                        AppoitmentDate = Convert.ToDateTime(Reader["AppoitmentDate"]);
                        PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                        CreatedByUser = Convert.ToInt32(Reader["CreatedByUser"]);
                        IsLocked = Convert.ToBoolean(Reader["IsLocked"]);

                        isFound = true;
                    }
                }
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

        public static bool UpdateTestAppointment(int ID, int TestTypeID, int LocalDrivingLicenseID, DateTime AppoitmentDate, float PaidFees, int CreatedByUser, bool IsLocked)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update TestAppointments 
                             set TestTypeID = @TestTypeID,
                                 LocalDrivingLicenseID = @LocalDrivingLicenseID,
                                 AppoitmentDate = @AppoitmentDate,
                                 PaidFees = @PaidFees,
                                 CreatedByUser = @CreatedByUser,
                                 IsLocked = @IsLocked
                             Where TestAppointmentID = @ID;";

            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;
            command.Parameters.Add("@LocalDrivingLicenseID", SqlDbType.Int).Value = LocalDrivingLicenseID;
            command.Parameters.Add("@AppoitmentDate", SqlDbType.SmallDateTime).Value = AppoitmentDate;
            command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
            command.Parameters.Add("@CreatedByUser", SqlDbType.Int).Value = CreatedByUser;
            command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = IsLocked;


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

        public static bool DeleteTestAppointment(int ID)
        {
            int RowsAffected = 0;

            string Query = @"DELETE FROM TestAppointments 
                     WHERE TestAppointmentID = @ID";


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

        public static DataTable GetAllTestAppointmentsForLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID,int TestType)
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

                    }
                }
            }
            return TestAppointmentDataTable;
        }

        public static bool IsTestAppointmentExists(int ID)
        {
            string Query = "SELECT Count(TestAppointmetID) FROM TestAppointmets WHERE TestAppointmetID = @TestAppointmetID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@TestAppointmetID", SqlDbType.Int).Value = ID;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        int count = Convert.ToInt32(Result);
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
