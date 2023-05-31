using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly IUnitOfWork unitOfWork;

        public TicketTypeService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task AddAsync(TicketType ticketType)
        {
            await unitOfWork.TicketTypeRepo.AddAsync(ticketType);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(TicketType ticketType)
        {
            unitOfWork.TicketTypeRepo.Delete(ticketType);
            await unitOfWork.CommitAsync();
        }

        public async Task<List<TicketType>> GetAllAsync()
            => await unitOfWork.TicketTypeRepo.GetAllAsync();

        public async Task<TicketType> GetByIdAsync(Guid id)
            => await unitOfWork.TicketTypeRepo.GetByIdAsync(id);

        public async Task<List<TicketType>> GetByShowIdAsync(int showId)
        {
            var listTicketType = await unitOfWork.TicketTypeRepo.GetByShowIdAsync(showId); 
            
            return listTicketType;
        }

        public async Task UpdateAsync(TicketType ticketType)
        {
            unitOfWork.TicketTypeRepo.Update(ticketType);
            await unitOfWork.CommitAsync();
        }
    }
}
