using MySql.Data.MySqlClient;
using System.Data;

namespace ASP.NET_MySQL.Util
{
    public class DatabaseHelper
	{

        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            //remember to close the connection at the end
            connection.Open();
            return connection;
        }
    }
}

