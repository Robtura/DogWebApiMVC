using Oracle.ManagedDataAccess.Client;

namespace DogApiMVCProject.OracleDataProvider.OracleDBContext
{
    public class OracleDBContext
    {
        private readonly string _connectionString;

        public OracleDBContext()
        {
            _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=your_host)(PORT=your_port))(CONNECT_DATA=(SERVICE_NAME=your_service_name)));User Id=your_username;Password=your_password;";
        }

        public OracleConnection GetConnection()
        {
            return new OracleConnection(_connectionString);
        }

        public OracleCommand GetCommand(string query, OracleConnection connection)
        {
            return new OracleCommand(query, connection);
        }

        public void OpenConnection(OracleConnection connection)
        {
            connection.Open();
        }

        public void CloseConnection(OracleConnection connection)
        {
            connection.Close();
        }
    }
}


