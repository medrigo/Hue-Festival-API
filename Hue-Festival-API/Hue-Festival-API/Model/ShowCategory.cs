namespace HueFestival_OnlineTicket.Model
{
    public class ShowCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public List<Show> ListShow { get; set; }
    }
}
