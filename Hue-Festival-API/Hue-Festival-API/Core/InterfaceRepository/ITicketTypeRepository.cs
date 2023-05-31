using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface ITicketTypeRepository : IGenericRepository<TicketType>
    {
        Task<List<TicketType>> GetByShowIdAsync(int showId);
        Task<TicketType> GetByIdAsync(Guid id);
    }
}
