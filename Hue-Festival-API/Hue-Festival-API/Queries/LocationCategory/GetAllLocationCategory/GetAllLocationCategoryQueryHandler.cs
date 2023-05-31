using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.LocationCategory.GetAllLocationCategory
{
    public class GetAllLocationCategoryQueryHandler : IRequestHandler<GetAllLocationCategoryQuery, List<LocationCategoryVM>>
    {
        private readonly ILocationCategoryService _locationCategoryService;
        public GetAllLocationCategoryQueryHandler(ILocationCategoryService locationCategoryService)
        {
            _locationCategoryService = locationCategoryService;
        }
        public async Task<List<LocationCategoryVM>> Handle(GetAllLocationCategoryQuery request, CancellationToken cancellationToken)
        {
            var locationCategory = await _locationCategoryService.GetAllAsync();
            return locationCategory;
        }
    }
}
