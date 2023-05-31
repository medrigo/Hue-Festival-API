using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.News.GetAllNews
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<NewsVM>>
    {
        private readonly INewsService _newsService;
        public GetAllNewsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<List<NewsVM>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {

            List<NewsVM> news = await _newsService.GetAllAsync();
            return news;
        }
    }
}
