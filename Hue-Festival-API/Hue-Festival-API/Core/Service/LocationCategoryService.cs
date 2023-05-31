using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class LocationCategoryService : ILocationCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationCategoryService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddAsync(LocationCategoryVM_Input locationCategoryVM_Input)
        {
            await unitOfWork.LocationCategoryRepo.AddAsync(mapper.Map<LocationCategory>(locationCategoryVM_Input));
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var locationCatrgory = await unitOfWork.LocationCategoryRepo.GetByIdAsync(id);

            if (locationCatrgory is null)
                return false;

            unitOfWork.LocationCategoryRepo.Delete(locationCatrgory);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<List<LocationCategoryVM>> GetAllAsync()
            => mapper.Map<List<LocationCategoryVM>>(await unitOfWork.LocationCategoryRepo.GetAllAsync());

        public async Task<LocationCategoryVM_Details> GetByIdAsync(int id)
            => mapper.Map<LocationCategoryVM_Details>(await unitOfWork.LocationCategoryRepo.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(int id, LocationCategoryVM_Input input)
        {
            var locationCategory = await unitOfWork.LocationCategoryRepo.GetByIdAsync(id);

            if (locationCategory is null) 
                return false;

            locationCategory.Title = input.Title;
            locationCategory.Image = input.Image;

            unitOfWork.LocationCategoryRepo.Update(locationCategory);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}
