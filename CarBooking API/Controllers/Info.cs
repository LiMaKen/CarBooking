using API_Template.Database;
using CarBooking_Data.Model;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CarBooking_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        public static List<InfoDetail> infos = new List<InfoDetail>();
        public static InfoDetail GetInfoUser()
        {
            InfoDetail info = null;
            try
            {
                PetaPoco.Database db = new PetaPoco.Database(General.Connection);
                foreach (InfoDetail item in db.Fetch<InfoDetail>("SELECT * FROM info"))
                {
                    infos.Add(item);
                }
                Console.WriteLine(infos.FirstOrDefault().description);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return info;
        }
    }
}
