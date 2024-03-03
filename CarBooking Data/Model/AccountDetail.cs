namespace Data.Model
{
    public class AccountDetail
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public AccountDetail()
        {
            username = string.Empty;
            password = string.Empty;
            name = string.Empty;
        }
    }
}
