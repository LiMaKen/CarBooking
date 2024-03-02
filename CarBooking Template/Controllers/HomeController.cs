using CarBooking_Template.Models;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CarBooking_Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync("https://localhost:7088/Account");
            var res = await data.Content.ReadAsStringAsync();

            var dataJson = JsonConvert.DeserializeObject<IEnumerable<AccountDetail>>(res);

            return View(dataJson);
        }

        private string GetUserName(List<AccountDetail> accounts)
        {
            return "";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
