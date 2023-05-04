using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_API.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PathImage { get; set; }
        public DateTime PostDate { get; set; } 
        public DateTime ChangeDate { get; set; } 
        public bool IsNew { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int NewsTypeId { get; set; }

        [ForeignKey("NewsTypeId")]
        public NewsType NewsType { get; set; }

    }
}
