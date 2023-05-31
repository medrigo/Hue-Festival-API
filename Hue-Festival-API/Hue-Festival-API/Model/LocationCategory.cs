namespace HueFestival_OnlineTicket.Model
{
    public class LocationCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public List<Location> ListLocation { get; set; }
    }
}
