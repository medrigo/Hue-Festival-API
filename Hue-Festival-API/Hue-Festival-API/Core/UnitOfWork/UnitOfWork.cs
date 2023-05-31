using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Core.Repository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.Servies.Repository;

namespace HueFestival_OnlineTicket.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HueFestivalContext context;
        public ILocationCaegoryRepository LocationCategoryRepo { get; private set; }
        public ILocationRepository LocationRepo { get; private set; }
        public ITicketLocationRepository TicketLocationRepo { get; private set; }
        public INewsRepository NewsRepo { get; private set; }
        public IHelpMenuRepository HelpMenuRepo { get; private set; }
        public IProgrammeRepository ProgrammeRepo { get; private set; }
        public IProgrammeImageRepository ProgrammeImageRepo { get; private set; }
        public IShowCategoryRepository ShowCategoryRepo { get; private set; }
        public IShowRepository ShowRepo { get; private set; }
        public ILocationFavoriteRepository LocationFavoriteRepo { get; private set; }
        public IShowFavoriteRepository ShowFavoriteRepo { get; private set; }
        public IUserRepository UserRepo { get; private set; }
        public ITicketRepository TicketRepo { get; private set; }
        public ITicketTypeRepository TicketTypeRepo { get; private set; }
        public IEmployeeRepository EmployeeRepo { get; private set; }
        public ICheckInRepository CheckInRepo { get; private set; }

        public UnitOfWork(HueFestivalContext _context)
        {
            context = _context;
            LocationCategoryRepo = new LocationCategoryRepository(context);
            LocationRepo = new LocationRepository(context);
            TicketLocationRepo = new TicketLoactionRepository(context);
            NewsRepo = new NewsRepository(context);
            HelpMenuRepo = new HelpMenuRepository(context);
            ProgrammeRepo = new ProgrammeRepository(context);
            ProgrammeImageRepo = new ProgrammeImageRepository(context);
            ShowCategoryRepo = new ShowCategoryRepository(context);
            ShowRepo = new ShowRepository(context);
            LocationFavoriteRepo = new LocationFavoriteRepository(context);
            ShowFavoriteRepo = new ShowFavoriteRepository(context);
            UserRepo = new UserRepository(context);
            TicketRepo = new TicketRepository(context);
            TicketTypeRepo = new TicketTypeRepository(context);
            EmployeeRepo = new EmployeeRepository(context);
            CheckInRepo = new CheckInRepository(context);
        }

        public void Commit() => context.SaveChanges();

        public async Task CommitAsync() => await context.SaveChangesAsync();

        public void RollBack() => context.Dispose();

        public async Task RollBackAsync() => await context.DisposeAsync();
    }
}
