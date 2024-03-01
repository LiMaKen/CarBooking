using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace API_Template.Database
{
    public class General
    {
        public static MySqlConnection Connection = null;
        public static bool DatabaseConnectionCheck = false;
        public String Host { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public String Database { get; set; }
        public General()
        {
            Host = "localhost";
            Password = "";
            Username = "root";
            Database = "asp";
        }
        public static bool InitConnection()
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Console.WriteLine("[MYSQL]: Kết nối kết thúc!");
                Connection.Close();
            }
            General sql = new General();
            String sqlConnection = $"SERVER={sql.Host};DATABASE={sql.Database};UID={sql.Username};PASSWORD={sql.Password};";
            Connection = new MySqlConnection(sqlConnection) ;
            try
            {
                Connection.Open();
                DatabaseConnectionCheck = true;
                Console.WriteLine("[MYSQL]: Kết nối thành công!");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("[MYSQL]: Kết nối thất bại!");
                Console.WriteLine("[MYSQL]: " + e.ToString());
                return false;
            }
        }
    }
}
