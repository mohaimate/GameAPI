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
            var query = "UPDATE Progression SET [Level] = '@Level', Currentcoin = '@Currentcoin', Alltimecoin = '@Alltimecoin' WHERE AccountID = '"+ progress.AccountID +"'";

            query = query.Replace("@Level", Convert.ToString(progress.Level))
                    .Replace("@Currentcoin", Convert.ToString(progress.Currentcoin))
                    .Replace("@Alltimecoin", Convert.ToString(progress.Alltimecoin));

            SqlConnection connection = ConnectionBuilder.getConn();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
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