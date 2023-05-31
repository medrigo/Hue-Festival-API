namespace HueFestival_OnlineTicket.ViewModel
{
    public class TicketTypeVM
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public class TicketTypeVM_Input
    {
        public int ShowId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
