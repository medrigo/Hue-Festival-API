using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface ICheckInService
    {
        Task<dynamic> CheckInAsync(string code, string employeeId);

        Task<List<CheckInVM_Report>> ReportAsync(Guid employeeId);

        Task<List<CheckIn>> GetHistoryCheckIn(Guid employeeId, DateTime? dateCheckIn, string? typeTicket, int? programmeId);
    }
}
