using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeVM>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<Employee> GetByIdAsync(Guid id);
        Task UpdateAsync(Employee employee);
        Task<Employee> GetByPhoneAsync(string phone);
        Task<Employee> LoginAsync(string username, string password);
        Task<bool> ChangePasswordAsync(Guid employeeId, EmployeeVM_ChangePassword password);
        Task<bool> ActivateAsync(string phone);
    }
}
