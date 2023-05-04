using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_API.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int TicketTypeId { get; set; }
        [ForeignKey("TicketTypeId")]
        public TicketType TicketType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }

        
    }
}
