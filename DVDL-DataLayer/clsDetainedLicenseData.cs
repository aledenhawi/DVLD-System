using DVDL_DataLayer;
using DVDL_Driving_License_Management_WindowsForm.Global_Classes;
using System;
using System.Data;
using System.Data.SqlClient;

public class clsDetainedLicenseData
{
    public static int AddNewDetainLicense( int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID,bool IsReleased)
    {
        int DetainID = -1;

        string Query = @"INSERT INTO DetainedLicenses
                        (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                        VALUES
                        (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased);

                        SELECT SCOPE_IDENTITY();";

        using (SqlConnection Connection =
            new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                Command.Parameters.Add("@DetainDate", SqlDbType.DateTime).Value = DetainDate;
                Command.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = FineFees;
                Command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                Command.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = IsReleased;

                try
                {
                    Connection.Open();

                    object Result = Command.ExecuteScalar();

                    if (Result != null &&
                        int.TryParse(Result.ToString(), out int InsertedID))
                    {
                        DetainID = InsertedID;
                    }
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Adding New Detain License Couldn't be Done Seccussfully ", ex);
                }
            }
        }

        return DetainID;
    }
    public static bool UpdateDetainedLicense(int DetainID,int LicenseID,DateTime DetainDate,float FineFees,int CreatedByUserID)
    {
        int RowsAffected = 0;

        string Query = @"UPDATE DetainedLicenses
                     SET LicenseID = @LicenseID,
                         DetainDate = @DetainDate,
                         FineFees = @FineFees,
                         CreatedByUserID = @CreatedByUserID
                     WHERE DetainID = @DetainID;";

        using (SqlConnection Connection =
            new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;
                Command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                Command.Parameters.Add("@DetainDate", SqlDbType.DateTime).Value = DetainDate;
                Command.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = FineFees;
                Command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

                try
                {
                    Connection.Open();

                    RowsAffected = Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Updating Detain License Couldn't be Done Seccussfully ", ex);
                }
            }
        }

        return (RowsAffected > 0);
    }

    public static bool ReleaseDetainedLicense(int DetainID,int ReleasedByUserID,int ReleaseApplicationID)
    {
        int RowsAffected = 0;

        string Query = @"UPDATE DetainedLicenses
                         SET IsReleased = 1,
                             ReleaseDate = @ReleaseDate,
                             ReleasedByUserID = @ReleasedByUserID,
                             ReleaseApplicationID = @ReleaseApplicationID
                         WHERE DetainID = @DetainID;";

        using (SqlConnection Connection =
            new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;
                Command.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = DateTime.Now;
                Command.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = ReleasedByUserID;
                Command.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = ReleaseApplicationID;

                try
                {
                    Connection.Open();

                    RowsAffected = Command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Releaseing Detained License Couldn't be Done Seccussfully ", ex);
                }
            }
        }

        return (RowsAffected > 0);
    }

    public static bool GetDetainedLicenseInfoByID(int DetainID,ref int LicenseID,ref DateTime DetainDate,ref float FineFees,ref int CreatedByUserID,ref bool IsReleased
        ,ref DateTime ReleaseDate,ref int ReleasedByUserID,ref int ReleaseApplicationID)
    {
        bool IsFound = false;

        string Query = @"SELECT * 
                         FROM DetainedLicenses
                         WHERE DetainID = @DetainID";

        using (SqlConnection Connection =
            new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;

                try
                {
                    Connection.Open();

                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LicenseID = Convert.ToInt32(reader["LicenseID"]);
                            DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                            FineFees = Convert.ToSingle(reader["FineFees"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                            if (reader["ReleaseDate"] == DBNull.Value)

                                ReleaseDate = DateTime.MaxValue;
                            else
                                ReleaseDate = (DateTime)reader["ReleaseDate"];


                            if (reader["ReleasedByUserID"] == DBNull.Value)

                                ReleasedByUserID = -1;
                            else
                                ReleasedByUserID = (int)reader["ReleasedByUserID"];

                            if (reader["ReleaseApplicationID"] == DBNull.Value)

                                ReleaseApplicationID = -1;
                            else
                                ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                            IsFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Getting Detain License Couldn't be Done Seccussfully ", ex);
                }
            }
        }

        return IsFound;
    }

    public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,ref int DetainID,ref DateTime DetainDate,ref float FineFees,ref int CreatedByUserID,
        ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserID,ref int ReleaseApplicationID)
    {
        bool IsFound = false;

        string Query = @"SELECT TOP 1 *
                     FROM DetainedLicenses
                     WHERE LicenseID = @LicenseID
                     AND IsReleased = 0
                     ORDER BY DetainID DESC;";

        using (SqlConnection Connection =
            new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                try
                {
                    Connection.Open();

                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DetainID = Convert.ToInt32(reader["DetainID"]);
                            DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                            FineFees = Convert.ToSingle(reader["FineFees"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                            if (reader["ReleaseDate"] == DBNull.Value)

                                ReleaseDate = DateTime.MaxValue;
                            else
                                ReleaseDate = (DateTime)reader["ReleaseDate"];


                            if (reader["ReleasedByUserID"] == DBNull.Value)

                                ReleasedByUserID = -1;
                            else
                                ReleasedByUserID = (int)reader["ReleasedByUserID"];

                            if (reader["ReleaseApplicationID"] == DBNull.Value)

                                ReleaseApplicationID = -1;
                            else
                                ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                            IsFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Getting Detain License Couldn't be Done Seccussfully ", ex);
                }
            }
        }

        return IsFound;
    }

    public static bool IsLicenseDetained(int LicenseID)
    {
        string Query = @"SELECT 1
                         WHERE EXISTS
                         (
                            SELECT 1
                            FROM DetainedLicenses
                            WHERE LicenseID = @LicenseID
                            AND IsReleased = 0
                         )";

        using (SqlConnection Connection =
            new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                Command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                try
                {
                    Connection.Open();

                    object Result = Command.ExecuteScalar();

                    return (Result != null);
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Detain License Couldn't be Found in Database Seccussfully ", ex);
                    return false;
                }
            }
        }
    }

    public static DataTable GetAllDetainedLicenses()
    {
        DataTable dt = new DataTable();

        string Query = @"SELECT * FROM DetainedLicenses_View order by IsReleased,DetainID";

        using (SqlConnection Connection =
            new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            using (SqlCommand Command = new SqlCommand(Query, Connection))
            {
                try
                {
                    Connection.Open();

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        dt.Load(Reader);
                    }
                }
                catch (Exception ex)
                {
                    clsLoger.LogError("Detain Licenses Couldn't be Gettin Done Seccussfully ", ex);
                }
            }
        }

        return dt;
    }

}