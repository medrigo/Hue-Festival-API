using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface IShowRepository : IGenericRepository<Show>
    {
        Task<List<Show>> GetByDate(DateTime date);
        Task<IEnumerable<dynamic>> GetCalendarList();
        Task<Show> GetDetailsAsync(int id);
        Task<List<Show>> GetAllShowSalesTicketAsync();
    }
}
