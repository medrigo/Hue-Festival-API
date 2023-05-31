using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IShowCategoryService
    {
        Task<int> AddAsync(ShowCategoryVM_Input input);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id, ShowCategoryVM_Input input);
        Task<List<ShowCategoryVM>> GetAllAsync();
    }
}
