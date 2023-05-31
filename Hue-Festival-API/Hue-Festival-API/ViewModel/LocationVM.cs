using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.ViewModel
{
    public class LocationVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
    }

    public class LocationVM_Input
    {
        [Required]
        public int LocationCategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        public string? Content { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Longtitude { get; set; }

        [Required]
        public string Latitude { get; set; }
    }

    public class LocationVM_Details
    {
        public int Id { get; set; }
        public string LocationCategory { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? Content { get; set; }
        public string Image { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
    }
}
