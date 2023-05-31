using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival_OnlineTicket.Model
{
    public class ProgrammeImage
    {
        public int Id { get; set; }
        public int ProgrammeId { get; set; }
        public string Image { get; set; }

        [ForeignKey("ProgrammeId")]
        public Programme Programme { get; set; }
    }
}

