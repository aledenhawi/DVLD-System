using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDL_DataLayer
{
    public class clsDriverData
    {
 
        public static int AddNewDriver(int PersonID , int CreatedByUserID)
        {
            int DriverID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Drivers (PersonID,CreatedByUserID,CreatedDate)
                values(@PersonID, @CreatedByUserID, @CreatedDate)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add for insert

            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    DriverID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return DriverID;
        }

        public static bool GetDriverInfoByID(int DriverID,ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Drivers WHERE DriverID = @ID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@ID",SqlDbType.Int).Value = DriverID;

            try
            {
                Connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]);
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

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

            try
            {
                Connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]);
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

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Drivers 
                             set PersonID = @PersonID,
                                 CreatedByUserID = @CreatedByUserID
                             Where DriverID = @DriverID;";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for update

            command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
            command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
            command.Parameters.Add("DriverID", SqlDbType.Int).Value = DriverID;

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

        public static bool DeleteDriver(int DriverID)
        {
            int RowsAffected = 0;

            string Query = @"DELETE FROM Drivers 
                     WHERE DriverID = @DriverID";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

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

        public static DataTable GetAllDrivers()
        {
            DataTable DriversTable = new DataTable();

            string Query = "SELECT * FROM Drivers_View;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DriversTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    //  Console.WriteLine(ex.Message);
                }
            }
            return DriversTable;
        }

        public static bool IsDriverExists(int DriverID)
        {
            string Query = "SELECT Found = 1 FROM Drivers WHERE DriverID = @DriverID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        byte count;
                        count = (Result == null)? Convert.ToByte(0) : Convert.ToByte(Result);
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

        public static bool IsDriverExistsByPersonID(int PersonID)
        {
            string Query = "SELECT Found = 1 FROM Drivers WHERE PersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        byte count;
                        count = (Result == null) ? Convert.ToByte(0) : Convert.ToByte(Result);
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
