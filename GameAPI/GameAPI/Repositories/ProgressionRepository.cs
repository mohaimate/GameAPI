using GameAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameAPI.Repositories
{
    public class ProgressionRepository
    {
        public static Progression getProgress(int AccountID)
        {
            var query = "SELECT AccountID, [Level], Currentcoin, Alltimecoin FROM Progression WHERE AccountID = '@ID'";

            query = query.Replace("@ID", Convert.ToString(AccountID));

            SqlConnection connection = ConnectionBuilder.getConn();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader;
                Progression result = new Progression();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.AccountID = Convert.ToInt32(reader["AccountID"]);
                    result.Level = Convert.ToInt32(reader["Level"]);
                    result.Currentcoin = Convert.ToInt32(reader["Currentcoin"]);
                    result.Alltimecoin = Convert.ToInt32(reader["Alltimecoin"]);
                    Console.WriteLine(result);
                }
                command.Dispose();
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool UpdateProgress(Progression progress)
        {
            var query = "UPDATE Progression SET [Level] = '@Level'," +
                "Currentcoin = '@Currentcoin'," +
                "Alltimecoin = '@Alltimecoin' " +
                "WHERE AccountID = '"+ progress.AccountID +"'";
            SqlConnection connection = ConnectionBuilder.getConn();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@Level", System.Data.SqlDbType.Int);
                command.Parameters.Add("@Currentcoin", System.Data.SqlDbType.Int);
                command.Parameters.Add("@Alltimecoin", System.Data.SqlDbType.Int);
                command.Parameters["@Level"].Value = Convert.ToString(progress.Level);
                command.Parameters["@Currentcoin"].Value = Convert.ToString(progress.Currentcoin);
                command.Parameters["@Alltimecoin"].Value = Convert.ToString(progress.Alltimecoin);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}