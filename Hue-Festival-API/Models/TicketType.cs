using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_API.Models
{
    public class TicketType
    {
        public int Id { get; set; }
        public string TicketName { get; set; }
        public Double price { get; set; }
        public int Quantity { get; set; }
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public Programm Program { get; set; }


    }
}
