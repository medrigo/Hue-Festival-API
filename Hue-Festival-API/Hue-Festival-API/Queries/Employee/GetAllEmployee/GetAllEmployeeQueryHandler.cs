using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.Employee.GetAllEmployee
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeVM>>
    {
        private readonly IEmployeeService _employeeService;
        public GetAllEmployeeQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<List<EmployeeVM>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetAllAsync();
            return employees;
        }
    }
}
