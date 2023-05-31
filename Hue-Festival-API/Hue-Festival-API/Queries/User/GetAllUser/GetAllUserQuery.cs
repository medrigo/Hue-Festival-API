using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.User.GetAllUser
{
    public class GetAllUserQuery : IRequest<List<UserVM>>
    {
    }
}
