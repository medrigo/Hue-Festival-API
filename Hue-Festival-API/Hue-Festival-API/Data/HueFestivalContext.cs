using HueFestival_OnlineTicket.Model;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Data
{
    public class HueFestivalContext : DbContext
    {
        public HueFestivalContext(DbContextOptions<HueFestivalContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCategory> LocationsCategories { get; set; }
        public DbSet<TicketLocation> TicketLocations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<HelpMenu> HelpMenus { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ProgrammeImage> ProgramImages { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowCategory> ShowCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShowFavorite> ShowFavorites { get; set; }
        public DbSet<LocationFavorite> LocationFavorites { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
