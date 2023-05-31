using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IProgrammeService
    {
        Task AddAsync(ProgrammeVM_Input input);
        Task<int> DeleteAsync(int id);
        Task<List<ProgrammeVM>> GetAllByTypeProgramAsync(int typeProgram);
        Task<ProgrammeVM_Details> GetDetailsAsync(int id);
        Task<int> UpdateAsync(int id, ProgrammeVM_Input input);
        Task<List<ProgrammeVM>> GetAllAsync();
    }
}
