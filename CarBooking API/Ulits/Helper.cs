using API_Template.Database;
using CarBooking_API.Controllers;
using Data.Model;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

namespace CarBooking_API.Ulits
{
    public class Helper
    {
       
        public static bool CheckRegisterAccout(AccountDetail account)
        {
            MySqlCommand cmd = General.Connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) as count FROM account WHERE username=@username";
            cmd.Parameters.AddWithValue("@username", account.username);
            using (var render = cmd.ExecuteReader())
            {
                if (render.HasRows)
                {
                    if (render.Read())
                    {
                        int count = render.GetInt32(0);
                        return count > 0 ? false : true;
                    }
                    render.Close();
                }
            }
            return true;
        }

        internal static bool CheckLoginAccout(AccountDetail account)
        {
            foreach (var item in AccountController.accounts)
            {
                if (account != null && item != null && account.username.CompareTo(item.username) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
