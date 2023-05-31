using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival_OnlineTicket.Model
{
    public class Location
    {
        public int Id { get; set; }
        public int LocationCategoryId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? Content { get; set; }
        public string Image { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }

        [ForeignKey("LocationCategoryId")]
        public LocationCategory LocationCategory { get; set; }

        public List<Show> ListShow { get; set; }
    }
}
