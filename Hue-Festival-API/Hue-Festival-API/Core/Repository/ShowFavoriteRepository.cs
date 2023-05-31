using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class ShowFavoriteRepository : GenericRepository<ShowFavorite>, IShowFavoriteRepository
    {
        public ShowFavoriteRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<List<ShowFavorite>> GetAllShowFavoritesOfUserAsync(int userId)
            => await context.ShowFavorites.Include(f => f.Show).ThenInclude(f => f.Programme).ThenInclude(f=> f.ListProgrammeImage)
                                          .Where(f => f.UserId == userId)
                                          .ToListAsync();

        public async Task<ShowFavorite> GetShowFavoriteAsync(Guid id)
            => await context.ShowFavorites.SingleOrDefaultAsync(x => x.Id == id);
    }
}
