using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<bool> ActivateAsync(string phone)
        {
            var employee = await unitOfWork.EmployeeRepo.FindByPhoneAsync(phone);

            if (employee == null)
                return false;

            employee.Activate = true;

            unitOfWork.EmployeeRepo.Update(employee);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task AddAsync(Employee employee)
        {
            if (await unitOfWork.EmployeeRepo.CheckPhoneNumberAsync(employee.PhoneNumber))
                throw new Exception("Số điện thoại đã tồn tại");

            await unitOfWork.EmployeeRepo.AddAsync(employee);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> ChangePasswordAsync(Guid employeeId, EmployeeVM_ChangePassword password)
        {
            var employee = await unitOfWork.EmployeeRepo.ChangePasswordAsync(employeeId, password.OldPasswod);

            if (employee == null)
                return false;

            employee.Password = password.NewPassword;

            unitOfWork.EmployeeRepo.Update(employee);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task DeleteAsync(Employee employee)
        {
            unitOfWork.EmployeeRepo.Delete(employee);
            await unitOfWork.CommitAsync();
        }

        public async Task<List<EmployeeVM>> GetAllAsync()
            => mapper.Map<List<EmployeeVM>>(await unitOfWork.EmployeeRepo.GetAllAsync());

        public async Task<Employee> GetByIdAsync(Guid id)
            => await unitOfWork.EmployeeRepo.FindByIdAsync(id);

        public async Task<Employee> GetByPhoneAsync(string phone)
            => await unitOfWork.EmployeeRepo.FindByPhoneAsync(phone);

        public async Task<Employee> LoginAsync(string username, string password)
            => await unitOfWork.EmployeeRepo.LoginAsync(username, password);

        public async Task UpdateAsync(Employee employee)
        {
            if (await unitOfWork.EmployeeRepo.CheckPhoneNumberAsync(employee.PhoneNumber))
                throw new Exception("Số điện thoại đã tồn tại");

            unitOfWork.EmployeeRepo.Update(employee);
            await unitOfWork.CommitAsync();
        }
    }
}
