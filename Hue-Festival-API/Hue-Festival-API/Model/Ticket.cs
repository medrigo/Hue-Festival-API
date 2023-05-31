using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.Model
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
