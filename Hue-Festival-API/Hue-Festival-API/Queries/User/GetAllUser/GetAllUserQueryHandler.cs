using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.Service;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;
using System.Net;

namespace HueFestival_OnlineTicket.Queries.User.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserVM>>
    {
        private readonly IUserService _userService;
        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserVM>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            List<UserVM> users = await _userService.GetAllAsync();
            return users;
        }
    }
}
