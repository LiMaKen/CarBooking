using API_Template.Database;
using Data.Model;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

namespace CarBooking_API
{
    public class Ulits
    {
        public static List<AccountDetail> accounts = new List<AccountDetail>();
        public static void GetAccount()
        {
            
            MySqlCommand cmd = General.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM account";
            using (var render = cmd.ExecuteReader())
            {
                while (render.Read())
                {
                    AccountDetail accountDetail = new AccountDetail();
                    accountDetail.name = render.GetString("name");
                    accountDetail.password = render.GetString("password");
                    accountDetail.username = render.GetString("username");
                    accounts.Add(accountDetail);
                }
            }
        }
        public static bool CheckAccout(AccountDetail account)
        {
            MySqlCommand cmd = General.Connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) as count FROM account WHERE username=@username";
            cmd.Parameters.AddWithValue("@username",account.username);
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
    }
}
