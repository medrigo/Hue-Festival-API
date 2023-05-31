using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.News.GetNewsById
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, NewsVM_Details>
    {
        private readonly INewsService _newsService;
        public GetNewsByIdQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<NewsVM_Details> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsService.GetDetailsAsync(request.id);
            return news;
        }
    }
}
