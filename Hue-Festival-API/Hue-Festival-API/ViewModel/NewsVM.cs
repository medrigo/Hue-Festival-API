using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.ViewModel
{
    public class NewsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }

    public class NewsVM_Input
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Image { get; set; }
    }

    public class NewsVM_Details
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
