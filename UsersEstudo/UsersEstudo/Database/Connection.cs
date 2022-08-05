using System.Data.SqlClient;

namespace UsersStudy.Database
{
    public class Connection
    {
        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(@"Server=DESKTOP-HCO59RI\SQLEXPRESS;Database=UserEstudo;Trusted_Connection=True;");
            return connection;
        }
    }
}
