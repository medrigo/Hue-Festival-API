using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.HelpMenu.GetAllHelpMenu
{
    public class GetAllHelpMenuQuery : IRequest<List<HelpMenuVM>>
    {
    }
}
