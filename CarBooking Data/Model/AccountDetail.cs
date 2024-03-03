namespace Data.Model
{
    public class AccountDetail
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public AccountDetail()
        {
            userid = 0;
            username = string.Empty;
            password = string.Empty;
            name = string.Empty;
        }
    }
}
