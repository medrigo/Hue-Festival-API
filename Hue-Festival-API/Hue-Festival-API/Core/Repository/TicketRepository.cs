using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public bool CheckCodeAsync(string code)
            => context.Tickets.Any(t => t.Code == code);

        public override async Task<List<Ticket>> GetAllAsync()
            => await context.Tickets.Include(t => t.TicketType).ThenInclude(tt => tt.Show).ThenInclude(t => t.Programme).ToListAsync();

        public async Task<Ticket> GetByCode(string code)
            => await context.Tickets.Include(t => t.TicketType).ThenInclude(t => t.Show).ThenInclude(t => t.Programme)
                                    .Where(t => t.Code.Equals(code))
                                    .SingleOrDefaultAsync();

        public async Task<Ticket> GetById(Guid id)
            => await context.Tickets.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Ticket>> GetByUserIdAsync(int userId)
            => await context.Tickets.Include(t => t.TicketType).ThenInclude(t => t.Show).ThenInclude(t => t.Programme)
                                    .Where(t => t.UserId == userId).ToListAsync();
    }
}
