using System.ComponentModel.DataAnnotations;

namespace HueFestival_OnlineTicket.Model
{
    public class ShowFavorite
    {
        [Key]
        public Guid Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
