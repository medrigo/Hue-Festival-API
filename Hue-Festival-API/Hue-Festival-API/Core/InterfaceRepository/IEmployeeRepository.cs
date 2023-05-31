using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<bool> CheckPhoneNumberAsync(string phoneNumber);
        Task<Employee> FindByIdAsync(Guid id);
        Task<Employee> ChangePasswordAsync(Guid id, string password);
        Task<Employee> FindByPhoneAsync(string phone);
        Task<Employee> LoginAsync(string phone, string password);
    }
}
