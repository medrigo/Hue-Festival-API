using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<List<Ticket>> GetByUserIdAsync(int userId);
        Task<Ticket> GetByCode(string code);
        bool CheckCodeAsync(string code);
        Task<Ticket> GetById(Guid id);
    }
}
