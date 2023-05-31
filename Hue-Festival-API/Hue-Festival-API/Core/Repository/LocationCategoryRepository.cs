using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using HueFestival_OnlineTicket.Servies.Interface;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Servies.Repository
{
    public class LocationCategoryRepository : GenericRepository<LocationCategory>, ILocationCaegoryRepository
    {
        public LocationCategoryRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<bool> CheckExistAsync(int id)
            => await context.LocationsCategories.AnyAsync(lc => lc.Id == id);

        public override async Task<LocationCategory> GetByIdAsync(int id)
            => await context.LocationsCategories.Include(lc => lc.ListLocation).SingleOrDefaultAsync(lc => lc.Id == id);
    }
}
