using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Interface;

namespace HueFestival_OnlineTicket.Core.InterfaceRepository
{
    public interface IProgrammeRepository : IGenericRepository<Programme>
    {
        Task<List<Programme>> GetAllByTypeProgramAsync(int typeProgram);
        Task<bool> CheckProgrammeExistAsync(int id);
    }
}
