namespace Hue_Festival_API.Models
{
    public class ProgramWishlist
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public Programm Program { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
