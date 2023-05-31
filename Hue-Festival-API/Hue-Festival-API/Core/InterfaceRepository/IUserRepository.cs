using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByPhoneAsync(string phone);
        Task<User> GetByIdAndPasswordAsync(int id, string password);
    }
}
