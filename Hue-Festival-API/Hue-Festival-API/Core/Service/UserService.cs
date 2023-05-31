using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;

        public UserService(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache _cache, IConfiguration _configuration)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            cache = _cache;
            configuration = _configuration;
        }

        public async Task<bool> AddAsync(UserVM_Input input)
        {
            try
            {
                var user = mapper.Map<User>(input);

                await unitOfWork.UserRepo.AddAsync(user);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ChangePassword(int id, UserVM_ChangePassword input)
        {
            var user = await unitOfWork.UserRepo.GetByIdAndPasswordAsync(id, input.OldPassword);

            if (user == null)
                return false;

            user.Password = input.NewPassword;

            unitOfWork.UserRepo.Update(user);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await unitOfWork.UserRepo.GetByIdAsync(id);

                if (user != null)
                {
                    unitOfWork.UserRepo.Delete(user);
                    await unitOfWork.CommitAsync();

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<UserVM>> GetAllAsync()
            => mapper.Map<List<UserVM>>(await unitOfWork.UserRepo.GetAllAsync());

        public async Task<UserVM_ShowAndLocationFavorite> GetAllShowAndLocationFavoriveAsync(int userId)
        {
            var locationFavorite = await unitOfWork.LocationFavoriteRepo.GetAllLocationFavoriteOfUserAsync(userId);
            var showFavorite = await unitOfWork.ShowFavoriteRepo.GetAllShowFavoritesOfUserAsync(userId);

            return new UserVM_ShowAndLocationFavorite
            {
                ListLocationFavorite = mapper.Map<List<LocationFavoriteVM>>(locationFavorite),
                ListShowFavorite = mapper.Map<List<ShowFavoriteVM>>(showFavorite)
            };
        }

        public async Task<User> GetByPhone(string phone)
            => await unitOfWork.UserRepo.GetByPhoneAsync(phone);

        public async Task<bool> UpdateInfoAsync(UserVM_UpdateInfo input)
        {
            var user = await unitOfWork.UserRepo.GetByIdAsync(input.Id);

            if(user != null)
            {
                user.Name = input.Name;
                user.Email = input.Email;
                user.PhoneNumber = input.PhoneNumber;

                unitOfWork.UserRepo.Update(user);
                await unitOfWork.CommitAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateRoleAsync(UserVM_UpdateRole input)
        {
            var user = await unitOfWork.UserRepo.GetByIdAsync(input.UserId);

            if(user != null)
            {
                user.Role = input.Role;

                unitOfWork.UserRepo.Update(user);
                await unitOfWork.CommitAsync();

                return true;
            }

            return false;
        }
    }
}
