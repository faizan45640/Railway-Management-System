using System.Data.SqlClient;

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
