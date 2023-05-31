using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.ViewModel
{
    public class HelpMenuVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class HelpMenuVM_Input
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public class HelpMenuVM_Details
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
