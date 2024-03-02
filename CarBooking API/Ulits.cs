using API_Template.Database;
using Data.Model;
using MySql.Data.MySqlClient;

namespace CarBooking_API
{
    public class Ulits
    {
        public static bool CheckAccout(AccountDetail account)
        {
            MySqlCommand cmd = General.Connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM account WHERE username=@username";
            cmd.Parameters.AddWithValue("@username", account.username);
            using (var render = cmd.ExecuteReader())
            {
                if (render.HasRows)
                {
                    int count = render.GetInt32(0);
                    return count > 0 ? false : true;
                }
            }
            return true;
        }
    }
}
