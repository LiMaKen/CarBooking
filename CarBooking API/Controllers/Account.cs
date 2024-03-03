using API_Template.Database;
using CarBooking_API.Ulits;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Mysqlx.Notice;

namespace CarBooking_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public static List<AccountDetail> accounts = new List<AccountDetail>();

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAccount")]
        public List<AccountDetail> Get()
        {
            return accounts;
        }
        [HttpPost(Name = "PostLoginAccount")]
        public AccountDetail LoginAccount(AccountDetail account)
        {
            try
            {
                if (!Helper.CheckLoginAccout(account)) return null;
                else
                {
                    var acc = GetAccout(account);
                    if (acc != null) return acc;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        private AccountDetail GetAccout(AccountDetail account)
        {
            foreach (var item in accounts)
            {
                if (item != null && account != null && account.username == item.username && account.password == item.password)
                {
                    return item;
                }
            }
            return null;
        }

        [HttpPost(Name = "PostRegisterAccount")]
        public IActionResult RegisterAccount(AccountDetail account)
        {
            try
            {
                if (!Helper.CheckRegisterAccout(account)) return Ok(new { Info = "Tài khoản đã tồn tại!" });
                else
                {
                    MySqlCommand cmd = General.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO account(username,password,name) VALUES (@username,@password,@name)";
                    cmd.Parameters.AddWithValue("@username", account.username);
                    cmd.Parameters.AddWithValue("@password", account.password);
                    cmd.Parameters.AddWithValue("@name", account.name);
                    cmd.ExecuteNonQuery();
                    accounts.Add(account);
                    return Ok(new { Sussess = true });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }
       
        public static void GetAllAccount()
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

    }
}
