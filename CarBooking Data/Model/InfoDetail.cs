namespace CarBooking_Data.Model
{
    [PetaPoco.TableName("info")]
    [PetaPoco.PrimaryKey("userid")]
    public class InfoDetail
    {
        public string username { get; set; }
        public string description { get; set; }
    }
}
