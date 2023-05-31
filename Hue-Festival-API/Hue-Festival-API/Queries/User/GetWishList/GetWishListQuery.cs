using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.User.GetWishList
{
    public class GetWishListQuery : IRequest<UserVM_ShowAndLocationFavorite>
    {
        public int user_id { get; set; }
        public GetWishListQuery(int user_id)
        {
            this.user_id = user_id;
        }
    }
}
