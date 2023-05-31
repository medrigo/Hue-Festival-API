using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class ProgrammeRepository : GenericRepository<Programme>, IProgrammeRepository
    {
        public ProgrammeRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<List<Programme>> GetAllByTypeProgramAsync(int typeProgram)
            => await context.Programmes.Include(p => p.ListProgrammeImage)
                                       .Where(p => p.Type_Program == typeProgram)
                                       .ToListAsync();

        public async override Task<List<Programme>> GetAllAsync()
            => await context.Programmes.Include(p => p.ListProgrammeImage)
                                       .ToListAsync();

        public override async Task<Programme> GetByIdAsync(int id)
            => await context.Programmes.Include(p => p.ListProgrammeImage)
                                       .Include(p => p.ListShow)
                                       .ThenInclude(p => p.Location)
                                       .SingleOrDefaultAsync(p => p.Id == id);

        public async Task<bool> CheckProgrammeExistAsync(int id)
            => await context.Programmes.AnyAsync(p => p.Id == id);
    }
}
