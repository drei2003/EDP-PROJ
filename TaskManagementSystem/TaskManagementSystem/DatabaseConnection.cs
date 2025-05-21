using MySql.Data.MySqlClient;

namespace TaskManagementSystem
{
    public class DatabaseConnection
    {
        private string connectionString = "server=localhost;port=3306;database=informationsystemdb;uid=myappuser;pwd=myPasswordEDP@12345;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
