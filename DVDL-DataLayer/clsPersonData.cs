using DVDL_DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Security.Policy;

namespace DVDL_DataAccessLayer
{
    public class clsPersonData
    {

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo, string Email,
            string Phone, string Address, DateTime DateOfBirth, string ImagePath, int NationalityCountryID, byte Gender)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO People (NationalNo ,FirstName , SecondName , ThirdName , LastName , DateOfBirth , Gendor , Address , Phone, Email , NationalityCountryID , ImagePath)
                values(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth,@Gender, @Address, @Phone, @Email ,@NationalityCountryID,@ImagePath)
                SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Query, Connection);

            // add with value for insert

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);


            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            /////////
            ///

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }

        public static bool GetPersonInfoByID(int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string NationalNo, ref string Email,
           ref string Phone, ref string Address, ref DateTime DateOfBirth, ref string ImagePath, ref int NationalityCountryID, ref byte Gender)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM People WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"] != DBNull.Value ? Reader["ThirdName"].ToString() : "";
                    LastName = Reader["LastName"].ToString();
                    NationalNo = Reader["NationalNo"].ToString();
                    Email = Reader["Email"] != DBNull.Value ? Reader["Email"].ToString() : "";
                    Phone = Reader["Phone"].ToString();
                    Address = Reader["Address"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    ImagePath = Reader["ImagePath"] != DBNull.Value ? Reader["ImagePath"].ToString() : "";
                    Gender = Convert.ToByte(Reader["Gendor"]);
                    NationalityCountryID = Convert.ToInt32(Reader["NationalityCountryID"]);
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

        public static bool GetPersonInfoByNationalNo(ref int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, string NationalNo, ref string Email,
        ref string Phone, ref string Address, ref DateTime DateOfBirth, ref string ImagePath, ref int NationalityCountryID, ref byte Gender)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    ID = Convert.ToInt32(Reader["PersonID"]);
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"] != DBNull.Value ? Reader["ThirdName"].ToString() : "";
                    LastName = Reader["LastName"].ToString();
                    Email = Reader["Email"] != DBNull.Value ? Reader["Email"].ToString() : "";
                    Phone = Reader["Phone"].ToString();
                    Address = Reader["Address"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    ImagePath = Reader["ImagePath"] != DBNull.Value ? Reader["ImagePath"].ToString() : "";
                    NationalityCountryID = Convert.ToInt32(Reader["NationalityCountryID"]);
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

        public static bool UpdatePerson(int ID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo, string Email,
    string Phone, string Address, DateTime DateOfBirth, string ImagePath, int NationalityCountryID, byte Gender)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update People 
                             set NationalNo = @NationalNo,
                                 FirstName = @FirstName,
                                 SecondName = @SecondName,
                                 ThirdName = @ThirdName,
                                 LastName = @LastName,
                                 DateOfBirth = @DateOfBirth,
                                 Gendor = @Gender,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email,
                                 NationalityCountryID = @NationalityCountryID,
                                ImagePath = @ImagePath
                             Where PersonID = @ID;";


            SqlCommand command = new SqlCommand(Query, Connection);


            // add with value for update

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            // Handle optional fields
            if (ThirdName != "")
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

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
        
        public static bool DeletePerson(int ID)
        {
            int RowsAffected = 0;

            string Query = @"DELETE FROM People 
                     WHERE PersonID = @ID";


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

        public static DataTable GetAllPeople()
        {
            DataTable PeopleTable = new DataTable();

            string Query = "SELECT * FROM PeopleListView;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        PeopleTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return PeopleTable;
        }
   
        public static bool IsPersonExists(string NationalNo)
        {
            string Query = "SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
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

        public static bool IsPersonExists(int ID)
        {
            string Query = "SELECT Found = 1 FROM People WHERE PersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", ID);
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
        
      


    }
}
