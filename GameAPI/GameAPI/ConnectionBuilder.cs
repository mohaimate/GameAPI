using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameAPI
{
    public class ConnectionBuilder
    {
        public static SqlConnection getConn()
        {
            var connectionString = "Data Source=unitygame.cywsg609ru17.us-east-2.rds.amazonaws.com;" +
            "Initial Catalog=unitygame;" +
            "User id=Mohaimate;" +
            "Password=Pass912331";

            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}