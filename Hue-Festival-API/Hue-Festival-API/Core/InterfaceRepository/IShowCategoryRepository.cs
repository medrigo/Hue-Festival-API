using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface IShowCategoryRepository : IGenericRepository<ShowCategory>
    {
        Task<bool> CheckExistAsync(int id);
    }
}
