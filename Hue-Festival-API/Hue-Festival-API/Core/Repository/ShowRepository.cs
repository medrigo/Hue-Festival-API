using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        public ShowRepository(HueFestivalContext _context) : base(_context)
        {

        }

        public async Task<List<Show>> GetByDate(DateTime date)
            => await context.Shows.Include(x => x.Location).Include(x => x.Programme)
                                  .Where(x => x.StartDate.Date == date.Date).ToListAsync();

        public override async Task<List<Show>> GetAllAsync()
            => await context.Shows.Include(x => x.Location).Include(x => x.Programme).Include(x => x.ShowCategory)
                                  .ToListAsync();

        public async Task<IEnumerable<dynamic>> GetCalendarList()
            => await context.Shows.GroupBy(x => x.StartDate.Date)
                                  .Select(x => new { Date = x.Key, CountShow = x.Count() })
                                  .ToListAsync();

        public async Task<Show> GetDetailsAsync(int id)
            => await context.Shows.Include(x => x.Location).Include(x => x.Programme).Include(x => x.ShowCategory)
                                  .Where(x => x.Id == id).SingleOrDefaultAsync();

        public async Task<List<Show>> GetAllShowSalesTicketAsync()
            => await context.Shows.Include(x => x.Programme).Where(x => x.Programme.Type_Inoff == 2).ToListAsync();
    }
}
