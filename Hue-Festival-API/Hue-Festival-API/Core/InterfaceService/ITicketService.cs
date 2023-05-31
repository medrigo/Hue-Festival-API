using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface ITicketService
    {
        Task<int> BuyTicketAsync(TicketVM_Buy ticket, int userId);
        Task<List<Ticket>> GetAllAsync();
        Task<List<Ticket>> GetByUserId(int userId);
        Task<Ticket> GetByIdAsync(Guid ticketId);
    }
}
