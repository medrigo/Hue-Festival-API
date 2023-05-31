using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class TicketLocationService : ITicketLocationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TicketLocationService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddASync(TicketLocationVM_Input ticketLocationVM_Input)
        {
            await unitOfWork.TicketLocationRepo.AddAsync(mapper.Map<TicketLocation>(ticketLocationVM_Input));
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticketLocation = await unitOfWork.TicketLocationRepo.GetByIdAsync(id);

            if(ticketLocation is null)
                return false;

            unitOfWork.TicketLocationRepo.Delete(ticketLocation);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<List<TicketLocationVM>> GetAllAsync()
            => mapper.Map<List<TicketLocationVM>>(await unitOfWork.TicketLocationRepo.GetAllAsync());

        public async Task<bool> UpdateAsync(int id, TicketLocationVM_Input input)
        {
            var ticketLocation = await unitOfWork.TicketLocationRepo.GetByIdAsync(id); 

            if(ticketLocation is null) 
                return false;

            ticketLocation.Name = input.Name;
            ticketLocation.PhoneNumber = input.PhoneNumber;
            ticketLocation.Address = input.Address;
            ticketLocation.Image = input.Image;

            unitOfWork.TicketLocationRepo.Update(ticketLocation);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}
