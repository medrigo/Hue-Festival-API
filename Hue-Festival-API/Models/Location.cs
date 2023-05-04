using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_API.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string PathImage { get; set; }
        public DateTime PostDate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int LocationTypeId { get; set; }

        [ForeignKey("LocationTypeId")]
        public LocationType LocationType { get; set; }


    }   
}
