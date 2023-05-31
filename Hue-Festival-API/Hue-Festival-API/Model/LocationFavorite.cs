using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.Model
{
    public class LocationFavorite
    {
        [Key]
        public Guid Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
