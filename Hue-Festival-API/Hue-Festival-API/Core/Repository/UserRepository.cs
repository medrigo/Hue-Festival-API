using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<User> GetByIdAndPasswordAsync(int id, string password)
         => await context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Password == password);

        public async Task<User> GetByPhoneAsync(string phone)
            => await context.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phone);
    }
}
