using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface ICheckInRepository : IGenericRepository<CheckIn>
    {
        Task<List<CheckIn>> GetHistoryCheckInAsync(Guid employeeId);
        Task<List<CheckInVM_Report>> ReprotAsync(Guid employeeId);
    }
}
