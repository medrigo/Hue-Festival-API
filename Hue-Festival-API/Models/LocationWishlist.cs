namespace Hue_Festival_API.Models
{
    public class LocationWishlist
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
