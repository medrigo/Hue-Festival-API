using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.ViewModel
{
    public class TicketLocationVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [RegularExpression("0\\d{9}", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        public string Image { get; set; }
    }

    public class TicketLocationVM_Input
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [RegularExpression("0\\d{9}", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
