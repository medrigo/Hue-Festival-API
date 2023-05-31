using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class ShowCategoryRepository : GenericRepository<ShowCategory>, IShowCategoryRepository
    {
        public ShowCategoryRepository(HueFestivalContext _context) : base(_context)
        {

        }

        public async Task<bool> CheckExistAsync(int id)
            => await context.ShowCategories.AnyAsync(x => x.Id == id);
    }
}
