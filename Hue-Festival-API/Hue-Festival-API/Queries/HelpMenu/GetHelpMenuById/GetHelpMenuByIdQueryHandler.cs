using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.HelpMenu.GetHelpMenuById
{
    public class GetHelpMenuByIdQueryHandler : IRequestHandler<GetHelpMenuByIdQuery, HelpMenuVM_Details>
    {
        private readonly IHelpMenuService _helpMenuService;
        public GetHelpMenuByIdQueryHandler(IHelpMenuService helpMenuService)
        {
            _helpMenuService = helpMenuService;
        }
        public async Task<HelpMenuVM_Details> Handle(GetHelpMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var helpMenu = await _helpMenuService.GetDetailsAsync(request.id);
            return helpMenu;
        }
    }
}
