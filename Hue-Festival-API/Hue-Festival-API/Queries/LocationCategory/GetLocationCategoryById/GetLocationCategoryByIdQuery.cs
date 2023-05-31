using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.LocationCategory.GetLocationCategoryById
{
    public class GetLocationCategoryByIdQuery : IRequest<LocationCategoryVM_Details>
    {
        public int id { get; set; }
        public GetLocationCategoryByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
