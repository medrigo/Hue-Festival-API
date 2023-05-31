using HueFestival_OnlineTicket.ViewModel;
using MediatR;

namespace HueFestival_OnlineTicket.Queries.News.GetNewsById
{
    public class GetNewsByIdQuery : IRequest<NewsVM_Details>
    {
        public int id { get; set; }
        public GetNewsByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
