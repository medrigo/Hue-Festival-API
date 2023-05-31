using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.News.GetAllNews
{
    public class GetAllNewsQuery : IRequest<List<NewsVM>>
    {
    }
}
