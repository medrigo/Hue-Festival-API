using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class ShowService : IShowService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShowService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<List<ShowVM_SalesTicket>> GetListShowSalesTicketAsync()
            => mapper.Map<List<ShowVM_SalesTicket>>(await unitOfWork.ShowRepo.GetAllShowSalesTicketAsync());

        public async Task<int> AddAsync(ShowVM_Input input)
        {
            try
            {
                var programme = await unitOfWork.ProgrammeRepo.CheckProgrammeExistAsync(input.ProgramId);
                var Location = await unitOfWork.LocationRepo.CheckExistAsync(input.LocationId);
                var showCategory = await unitOfWork.ShowCategoryRepo.CheckExistAsync(input.ShowCategoryId);

                if(!programme && !Location && !showCategory) 
                {
                    return 1;
                }

                await unitOfWork.ShowRepo.AddAsync(mapper.Map<Show>(input));
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var show = await unitOfWork.ShowRepo.GetByIdAsync(id);

                if (show == null)
                    return 1;

                unitOfWork.ShowRepo.Delete(show);
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            { 
                return 2; 
            }
        }

        public async Task<IEnumerable<dynamic>> GetCalendarList()
            => await unitOfWork.ShowRepo.GetCalendarList();

        public async Task<List<ShowVM>> GetByDate(DateTime date)
            => mapper.Map<List<ShowVM>>(await unitOfWork.ShowRepo.GetByDate(date));

        public async Task<int> UpdateAsync(int id, ShowVM_Input input)
        {
            try
            {
                var show = await unitOfWork.ShowRepo.GetByIdAsync(id);

                if (show == null)
                    return 1;

                show.ProgramId = input.ProgramId;
                show.StartDate = input.StartDate;
                show.EndDate = input.EndDate;
                show.LocationId = input.LocationId;
                show.ShowCategoryId = input.ShowCategoryId;

                unitOfWork.ShowRepo.Update(show);
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public async Task<ShowVM_Details> GetDetailsAsync(int id)
            => mapper.Map<ShowVM_Details>(await unitOfWork.ShowRepo.GetDetailsAsync(id));

        public async Task<List<ShowVM>> GetAllAsync()
            => mapper.Map<List<ShowVM>>(await unitOfWork.ShowRepo.GetAllAsync());

        public async Task<bool> AddFavoriteAsync(int userId, int showId)
        {
            try
            {
                await unitOfWork.ShowFavoriteRepo.AddAsync(new ShowFavorite {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    ShowId = showId
                });
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false; 
            }
        }

        public async Task<bool> DeleteFavoriteAsync(Guid id)
        {
            try
            {
                var showFavorite = await unitOfWork.ShowFavoriteRepo.GetShowFavoriteAsync(id);

                if (showFavorite == null)
                    return false;

                unitOfWork.ShowFavoriteRepo.Delete(showFavorite);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
