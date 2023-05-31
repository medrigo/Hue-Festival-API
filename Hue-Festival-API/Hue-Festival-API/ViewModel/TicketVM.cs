namespace HueFestival_OnlineTicket.ViewModel
{
    public class TicketVM_Buy
    {
        public Guid TicketTypeId { get; set; }
        public int Quantity { get; set; }
    }

    public class TicketVM
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int ShowId { get; set; }
        public string ShowName { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }
}
