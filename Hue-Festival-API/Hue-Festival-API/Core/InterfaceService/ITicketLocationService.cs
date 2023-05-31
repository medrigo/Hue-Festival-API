using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface ITicketLocationService
    {
        Task AddASync(TicketLocationVM_Input ticketLocationVM_Input);
        Task<bool> DeleteAsync(int id);
        Task<List<TicketLocationVM>> GetAllAsync();
        Task<bool> UpdateAsync(int id, TicketLocationVM_Input input);
    }
}
