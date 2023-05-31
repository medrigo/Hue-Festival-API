using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface ILocationCategoryService
    {
        Task<List<LocationCategoryVM>> GetAllAsync();
        Task<LocationCategoryVM_Details> GetByIdAsync(int id);
        Task AddAsync(LocationCategoryVM_Input input);
        Task<bool> UpdateAsync(int id, LocationCategoryVM_Input input);
        Task<bool> DeleteAsync(int id);
    }
}
