using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.HelpMenu.GetHelpMenuById
{
    public class GetHelpMenuByIdQuery : IRequest<HelpMenuVM_Details>
    {
        public int id { get; set; }
        public GetHelpMenuByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
