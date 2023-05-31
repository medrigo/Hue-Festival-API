using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.HelpMenu.GetAllHelpMenu
{
    public class GetAllHelpMenuQueryHandler : IRequestHandler<GetAllHelpMenuQuery, List<HelpMenuVM>>
    {
        private readonly IHelpMenuService _helpMenuService;
        public GetAllHelpMenuQueryHandler(IHelpMenuService helpMenuService)
        {
            _helpMenuService = helpMenuService;
        }
        public async Task<List<HelpMenuVM>> Handle(GetAllHelpMenuQuery request, CancellationToken cancellationToken)
        {
            List<HelpMenuVM> helpmenus = await _helpMenuService.GetAllAsync();
            return helpmenus;
        }
    }
}
