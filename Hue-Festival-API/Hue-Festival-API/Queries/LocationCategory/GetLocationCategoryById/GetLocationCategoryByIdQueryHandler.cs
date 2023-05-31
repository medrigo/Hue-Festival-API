using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.LocationCategory.GetLocationCategoryById
{
    public class GetLocationCategoryByIdQueryHandler : IRequestHandler<GetLocationCategoryByIdQuery, LocationCategoryVM_Details>
    {
        private readonly ILocationCategoryService _locationCategoryService;
        public GetLocationCategoryByIdQueryHandler(ILocationCategoryService locationCategoryService)
        {
            _locationCategoryService  = locationCategoryService;
        }
        public async Task<LocationCategoryVM_Details> Handle(GetLocationCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var locationCategory = await _locationCategoryService.GetByIdAsync(request.id);
            return locationCategory;
        }
    }
}
