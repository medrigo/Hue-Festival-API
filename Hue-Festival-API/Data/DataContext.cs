using Hue_Festival_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hue_Festival_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<TicketLocation> TicketLocations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsType> NewsTypes { get; set; }
        public DbSet<HelpMenu> HelpMenus { get; set; }
        public DbSet<Programm> Programs { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProgramWishlist> ProgramWishlists { get; set; }
        public DbSet<LocationWishlist> locationWishlists { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}
