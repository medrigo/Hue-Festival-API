using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.ViewModel
{
    public class LocationCategoryVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }
    }

    public class LocationCategoryVM_Input
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }
    }

    public class LocationCategoryVM_Details
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public List<LocationVM> ListLocation { get; set; }
    }
}
