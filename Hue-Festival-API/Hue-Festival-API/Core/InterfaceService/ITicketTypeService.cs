using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface ITicketTypeService
    {
        Task AddAsync(TicketType ticketType);
        Task<List<TicketType>> GetByShowIdAsync(int showId);
        Task<List<TicketType>> GetAllAsync();
        Task DeleteAsync(TicketType ticketType);
        Task<TicketType> GetByIdAsync(Guid id);
        Task UpdateAsync(TicketType ticketType);
    }
}
