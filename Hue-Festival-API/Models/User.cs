namespace Hue_Festival_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }

        public List<LocationWishlist> LocationWishlist { get; set; }
        public List<ProgramWishlist> ProgramWishlist { get; set; }

    }
}
