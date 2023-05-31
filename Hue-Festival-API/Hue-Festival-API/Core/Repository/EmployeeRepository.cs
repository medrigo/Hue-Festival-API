using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<Employee> ChangePasswordAsync(Guid id, string password)
            => await context.Employee.FirstOrDefaultAsync(x => x.Id == id && x.Password == password);

        public async Task<bool> CheckPhoneNumberAsync(string phoneNumber)
            => await context.Employee.Where(x => x.PhoneNumber == phoneNumber).AnyAsync();

        public async Task<Employee> FindByIdAsync(Guid id)
            => await context.Employee.Where(x => x.Id == id).SingleOrDefaultAsync();

        public async Task<Employee> FindByPhoneAsync(string phone)
            => await context.Employee.Where(x => x.PhoneNumber == phone).SingleOrDefaultAsync();

        public async Task<Employee> LoginAsync(string phone, string password)
            => await context.Employee.FirstOrDefaultAsync(x => x.PhoneNumber == phone && x.Password == password);
    }
}
