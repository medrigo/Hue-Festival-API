using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface IShowFavoriteRepository : IGenericRepository<ShowFavorite>
    {
        Task<ShowFavorite> GetShowFavoriteAsync(Guid id);
        Task<List<ShowFavorite>> GetAllShowFavoritesOfUserAsync(int userId);
    }
}
