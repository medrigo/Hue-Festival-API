using AutoMapper;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Servies.Repository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<bool> CheckExistAsync(int id)
            => await context.Locations.AnyAsync(x => x.Id == id);

        public override async Task<Location> GetByIdAsync(int id)
            => await context.Locations.Include(l => l.LocationCategory).SingleOrDefaultAsync(l => l.Id == id);
    }
}
