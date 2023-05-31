using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.Model
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public bool Activate { get; set; }

        public List<CheckIn> CheckIns { get; set; }
    }
}
