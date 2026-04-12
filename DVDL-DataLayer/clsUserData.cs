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
    public class clsUserData
    {
        public static int AddNewUser(int PersonID,string Username , string Password , bool IsActive)
        {
            int ContactID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Users 
                values(@PersonID,@Username,@Password,@IsActive)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", Convert.ToInt16(IsActive));


            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ContactID = InsertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return ContactID;
        }

        public static bool GetUserInfoByID(int UserID ,ref int PersonID, ref string Username, ref string Password,ref bool IsActive)
        {
            bool isFound = false;

            string Query = "SELECT * FROM Users WHERE UserID = @UserID";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open(); 

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    using (SqlDataReader Reader = command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {
                            Username = Reader["Username"].ToString();
                            PersonID = Convert.ToInt32(Reader["PersonID"]);
                            Password = Reader["Password"].ToString();
                            IsActive = Convert.ToBoolean(Reader["IsActive"]);
                            isFound = true;
                        }
                    }
                }
            }

            return isFound;
        }

        public static bool GetUserInfoByUsername(string Username, ref int UserID, ref int PersonID, ref string Password,ref bool IsActive)
        {
            bool isFound = false;

            string Query = "SELECT * FROM Users WHERE Username = @Username";

            
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open(); 

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);

                    using (SqlDataReader Reader = command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {
                            UserID = Convert.ToInt32(Reader["UserID"]);
                            PersonID = Convert.ToInt32(Reader["PersonID"]);
                            Password = Reader["Password"].ToString();
                            IsActive = Convert.ToBoolean(Reader["IsActive"]);
                            isFound = true;
                        }
                    }
                }
            }

            return isFound;
        }

        public static bool GetUserInfoByUsernameAndPassword(string Username,string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            string Query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    using (SqlDataReader Reader = command.ExecuteReader())
                    {

                        if (Reader.Read())
                        {
                            UserID = Convert.ToInt32(Reader["UserID"]);
                            PersonID = Convert.ToInt32(Reader["PersonID"]);
                            IsActive = Convert.ToBoolean(Reader["IsActive"]);
                            isFound = true;
                        }
                    }
                }
            }

            return isFound;
        }

        public static bool UpdateUser(int UserID, string Username , string Password,bool IsActive)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Users 
                             set
                                 Username = @Username,
                                 Password = @Password,
                                 IsActive = @IsActive
                             Where UserID = @UserID;";


            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", Convert.ToInt16(IsActive));


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
 
        public static bool DeleteUser(int ID)
        {
            int RowsAffected = 0;

            string Query = @"DELETE FROM Users 
                     WHERE UserID = @UserID";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ID;

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
   
        public static DataTable GetAllUsers()
        {
            DataTable UsersTable = new DataTable();

            string Query = "SELECT * FROM UsersListView;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
            {
                try
                {
                    connection.Open();
                    
                    
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                     
                    
                         
                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                             UsersTable.Load(reader);
                         }
                       
                    }
                }
                catch (Exception)
                {

                }
                finally 
                {
                    connection.Close();
                }
            }

            return UsersTable;
        }

        public static bool IsUserExists(string Username)
        {
            string Query = "SELECT Found = 1 FROM Users WHERE Username = @Username";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
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

        public static bool IsUserExists(int UserID)
        {
            string Query = "SELECT Found = 1 FROM Users WHERE UserID = @UserID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
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

        public static bool IsUserExistsUsingPersonID(int PersonID)
        {
            string Query = "SELECT count(*) FROM Users WHERE PersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        int count;

                        object Result = command.ExecuteScalar();

                             count = Convert.ToInt32(Result);
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

        public static bool ChangePassword(int UserID,string Password)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Users 
                             set
                                 Password = @Password
                             Where UserID = @UserID;";


            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);


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

    }
}
