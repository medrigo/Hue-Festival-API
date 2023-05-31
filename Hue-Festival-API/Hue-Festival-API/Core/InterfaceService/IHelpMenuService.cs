using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IHelpMenuService
    {
        Task AddAsync(HelpMenuVM_Input input);
        Task<List<HelpMenuVM>> GetAllAsync();
        Task<HelpMenuVM_Details> GetDetailsAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, HelpMenuVM_Input input);
    }
}
