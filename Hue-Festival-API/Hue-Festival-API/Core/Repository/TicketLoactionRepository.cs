using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using HueFestival_OnlineTicket.Servies.Interface;

namespace HueFestival_OnlineTicket.Servies.Repository
{
    public class TicketLoactionRepository : GenericRepository<TicketLocation>, ITicketLocationRepository
    {
        public TicketLoactionRepository(HueFestivalContext _context) : base(_context)
        {
        }
    }
}
