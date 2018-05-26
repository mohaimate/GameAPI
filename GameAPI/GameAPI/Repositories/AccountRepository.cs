using GameAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GameAPI.Repositories
{
    public class AccountRepository
    {
        public static bool AddAccount(Account account)
        {
            var query = "INSERT INTO Account (Email, Password) VALUES ('@Email', '@Password')";

            query = query.Replace("@Email", account.Email)
                    .Replace("@Password", GenerateSHA256String(account.Password));

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

        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}