using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.User.GetWishList
{
    public class GetWishListQueryHandler : IRequestHandler<GetWishListQuery, UserVM_ShowAndLocationFavorite>
    {
        private readonly IUserService _userService;
        public GetWishListQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserVM_ShowAndLocationFavorite> Handle(GetWishListQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetAllShowAndLocationFavoriveAsync(request.user_id);

            return user;
        }
    }
}
