using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IUserService
    {
        Task<bool> AddAsync(UserVM_Input input);
        Task<bool> DeleteAsync(int id);
        Task<bool> ChangePassword(int id, UserVM_ChangePassword input);
        Task<UserVM_ShowAndLocationFavorite> GetAllShowAndLocationFavoriveAsync(int userId);
        Task<bool> UpdateRoleAsync(UserVM_UpdateRole input);
        Task<List<UserVM>> GetAllAsync();
        Task<bool> UpdateInfoAsync(UserVM_UpdateInfo input);
        Task<User> GetByPhone(string phone);
    }
}
