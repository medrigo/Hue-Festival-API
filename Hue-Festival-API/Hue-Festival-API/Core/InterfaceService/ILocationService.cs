using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface ILocationService
    {
        Task<bool> AddAsync(LocationVM_Input locationVM_Input);
        Task<bool> DeleteAsync(int id);
        Task<LocationVM_Details> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, LocationVM_Input input);
        Task<bool> AddFavoriteAsync(int userId, int locationId);
        Task<bool> DeleteFavoriteAsync(Guid id);
    }
}
