using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    internal class DatabaseConnection
    {
        public SqlConnection getConnection()
        {
            string connectionString = "Data Source=DESKTOP-MDFVLLC\\SQLEXPRESS;Initial Catalog=RailwayMS;Integrated Security=True;Encrypt=False";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
