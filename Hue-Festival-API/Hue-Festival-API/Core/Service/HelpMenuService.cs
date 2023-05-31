using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class HelpMenuService : IHelpMenuService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HelpMenuService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddAsync(HelpMenuVM_Input input)
        {
            await unitOfWork.HelpMenuRepo.AddAsync(mapper.Map<HelpMenu>(input));
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var helpMenu = await unitOfWork.HelpMenuRepo.GetByIdAsync(id);

            if (helpMenu == null)
                return false;

            unitOfWork.HelpMenuRepo.Delete(helpMenu);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<List<HelpMenuVM>> GetAllAsync()
            => mapper.Map<List<HelpMenuVM>>(await unitOfWork.HelpMenuRepo.GetAllAsync());

        public async Task<HelpMenuVM_Details> GetDetailsAsync(int id)
            => mapper.Map<HelpMenuVM_Details>(await unitOfWork.HelpMenuRepo.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(int id, HelpMenuVM_Input input)
        {
            var helpMenu = await unitOfWork.HelpMenuRepo.GetByIdAsync(id);
            
            if (helpMenu == null) 
                return false;
            
            helpMenu.Title = input.Title;
            helpMenu.Content = input.Content;

            unitOfWork.HelpMenuRepo.Update(helpMenu);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}
