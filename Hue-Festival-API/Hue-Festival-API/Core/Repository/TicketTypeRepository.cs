using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class TicketTypeRepository : GenericRepository<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<TicketType> GetByIdAsync(Guid id)
            => await context.TicketTypes.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<TicketType>> GetByShowIdAsync(int showId)
            => await context.TicketTypes.Where(x => x.ShowId == showId).ToListAsync();
    }
}
