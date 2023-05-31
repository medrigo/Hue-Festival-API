using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.LocationCategory.GetAllLocationCategory
{
    public class GetAllLocationCategoryQuery : IRequest<List<LocationCategoryVM>>
    {
    }
}
