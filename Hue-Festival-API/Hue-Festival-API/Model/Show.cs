using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival_OnlineTicket.Model
{
    public class Show
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public int ShowCategoryId { get; set; }

        [ForeignKey("ProgramId")]
        public Programme Programme { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("ShowCategoryId")]
        public ShowCategory ShowCategory { get; set; }
    }
}
