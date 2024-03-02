using API_Template.Database;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CarBooking_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAccount")]
        public List<AccountDetail> Get()
        {
            List<AccountDetail> accounts = new List<AccountDetail>();   
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
            return accounts;
        }
        [HttpPost(Name = "PostAccount")]
        public IActionResult InsertAccount(AccountDetail account)
        {
            try
            {
                var accountin = new AccountDetail()
                {
                    name = account.name,
                    password = account.password,
                    username = account.username,
                };
                if (Ulits.CheckAccout(account))
                {
                    MySqlCommand cmd = General.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO account(username,password,name) VALUES (@username,@password,@name)";
                    cmd.Parameters.AddWithValue("@username", account.username);
                    cmd.Parameters.AddWithValue("@password", account.password);
                    cmd.Parameters.AddWithValue("@name", account.name);
                    cmd.ExecuteNonQuery();
                    return Ok(new { Sussess = true });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
            return StatusCode(500, $"Internal Server Error");
        }

        
    }
}
