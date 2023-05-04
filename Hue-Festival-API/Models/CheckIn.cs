namespace Hue_Festival_API.Models
{
    public class CheckIn
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
