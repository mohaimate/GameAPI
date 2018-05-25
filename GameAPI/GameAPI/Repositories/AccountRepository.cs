using GameAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameAPI.Repositories
{
    public class AccountRepository
    {
        public static bool AddAccount(Account account)
        {
            var query = "INSERT INTO Account (Email, Password) VALUES ('@Email', '@Password')";

            query = query.Replace("@Email", account.Email)
                    .Replace("@Password", account.Password);

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

        public static int Login(Account account)
        {
            var query = "SELECT AccountID FROM Account WHERE Email = '@Email' AND Password = '@Password'";

            query = query.Replace("@Email", account.Email)
                    .Replace("@Password", account.Password);

            SqlConnection connection = ConnectionBuilder.getConn();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader;
                int result = 0;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = Convert.ToInt32(reader["AccountID"]);
                    Console.WriteLine(result);
                }
                command.Dispose();
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}