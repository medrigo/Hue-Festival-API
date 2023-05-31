using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;
namespace HueFestival_OnlineTicket.Queries.Employee.GetAllEmployee
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeVM>>
    {
    }
}
