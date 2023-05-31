using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<bool> AddAsync(LocationVM_Input locationVM_Input)
        {
            if(!await unitOfWork.LocationCategoryRepo.CheckExistAsync(locationVM_Input.LocationCategoryId))
                return false;

            await unitOfWork.LocationRepo.AddAsync(mapper.Map<Location>(locationVM_Input));
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> AddFavoriteAsync(int userId, int locationId)
        {
            try
            {
                await unitOfWork.LocationFavoriteRepo.AddAsync(new LocationFavorite { 
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    LocationId = locationId
                });
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var location = await unitOfWork.LocationRepo.GetByIdAsync(id);

            if (location is null)
                return false;

            unitOfWork.LocationRepo.Delete(location);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteFavoriteAsync(Guid id)
        {
            try
            {
                var locationFavorite = await unitOfWork.LocationFavoriteRepo.GetFavoriteAsync(id);

                if (locationFavorite == null)
                    return false;

                unitOfWork.LocationFavoriteRepo.Delete(locationFavorite); 
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<LocationVM_Details> GetByIdAsync(int id)
            => mapper.Map<LocationVM_Details>(await unitOfWork.LocationRepo.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(int id, LocationVM_Input input)
        {
            var location = await unitOfWork.LocationRepo.GetByIdAsync(id);

            if (location is null)
                return false;

            if (!await unitOfWork.LocationCategoryRepo.CheckExistAsync(input.LocationCategoryId))
                return false;

            location.LocationCategoryId = input.LocationCategoryId;
            location.Title = input.Title;
            location.Content = input.Content;
            location.Summary = input.Summary;
            location.Latitude = input.Latitude;
            location.Longtitude = input.Longtitude;
            location.Image = input.Image;

            unitOfWork.LocationRepo.Update(location);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}
