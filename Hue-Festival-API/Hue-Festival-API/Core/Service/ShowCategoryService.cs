using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class ShowCategoryService : IShowCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShowCategoryService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<int> AddAsync(ShowCategoryVM_Input input)
        {
            try
            {
                var showCategory = mapper.Map<ShowCategory>(input);

                await unitOfWork.ShowCategoryRepo.AddAsync(showCategory);
                await unitOfWork.CommitAsync();

                return 2;
            }
            catch
            {
                return 1;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var showCategory = await unitOfWork.ShowCategoryRepo.GetByIdAsync(id);

                if (showCategory is null)
                    return 1;

                unitOfWork.ShowCategoryRepo.Delete(showCategory);
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public async Task<List<ShowCategoryVM>> GetAllAsync()
        {
            var listShowCategory = await unitOfWork.ShowCategoryRepo.GetAllAsync();

            return mapper.Map<List<ShowCategoryVM>>(listShowCategory);
        }

        public async Task<int> UpdateAsync(int id, ShowCategoryVM_Input input)
        {
            try
            {
                var showCategory = await unitOfWork.ShowCategoryRepo.GetByIdAsync(id);
                 
                if (showCategory is null)
                    return 1;

                showCategory.Name = input.Name;
                showCategory.Content = input.Content;

                unitOfWork.ShowCategoryRepo.Update(showCategory);
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }
    }
}
