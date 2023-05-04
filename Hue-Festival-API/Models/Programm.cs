using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_API.Models
{
    public class Programm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int TypeInOff { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public int LocationId { get; set; }
        public int ProgramTypeId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("ProgramTypeId")]
        public ProgramType ProgramType { get; set; }


    }
}
