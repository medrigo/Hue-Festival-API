using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class CheckInRepository : GenericRepository<CheckIn>, ICheckInRepository
    {
        public CheckInRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<List<CheckIn>> GetHistoryCheckInAsync(Guid employeeId)
        {
                return await context.CheckIns
                                    .Where(x => x.EmployeeId == employeeId)
                                    .Include(x => x.Employee)
                                    .Include(x => x.Ticket)
                                    .ThenInclude(x => x.TicketType)
                                    .ThenInclude(x => x.Show)
                                    .ThenInclude(x => x.Programme)
                                    .ToListAsync();
        }

        public async Task<List<CheckInVM_Report>> ReprotAsync(Guid employeeId)
            => await context.CheckIns.Where(x => x.EmployeeId == employeeId)
                                     .Include(x => x.Ticket)
                                     .ThenInclude(x => x.TicketType)
                                     .ThenInclude(x => x.Show)
                                     .ThenInclude(x => x.Programme)     
                                     .GroupBy(x => x.Ticket.TicketType.Show.Programme.Name)
                                     .Select(x => new CheckInVM_Report { ShowName = x.Key, CountTicket = x.Count() })
                                     .ToListAsync();     
    }
}
