using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class HelpMenuRepository : GenericRepository<HelpMenu>, IHelpMenuRepository
    {
        public HelpMenuRepository(HueFestivalContext _context) : base(_context)
        {
        }
    }
}
