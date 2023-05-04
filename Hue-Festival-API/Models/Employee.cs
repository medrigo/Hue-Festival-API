namespace Hue_Festival_API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }

        public List<CheckIn> CheckIns { get; set; }
    }
}
