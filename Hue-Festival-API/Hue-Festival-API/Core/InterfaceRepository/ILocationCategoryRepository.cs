using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Servies.Interface
{
    public interface ILocationCaegoryRepository : IGenericRepository<LocationCategory>
    {
        Task<bool> CheckExistAsync(int id);
    }
}
