using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface ILocationFavoriteRepository : IGenericRepository<LocationFavorite>
    {
        Task<LocationFavorite> GetFavoriteAsync(Guid id);
        Task<List<LocationFavorite>> GetAllLocationFavoriteOfUserAsync(int userId);
    }
}
