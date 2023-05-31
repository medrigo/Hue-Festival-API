using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Service.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HueFestivalContext context;

        public GenericRepository(HueFestivalContext _context)
        {
            context = _context;
        }

        public virtual async Task<List<T>> GetAllAsync()
            => await context.Set<T>().ToListAsync();

        public virtual async Task<T> GetByIdAsync(int id)
            => await context.Set<T>().FindAsync(id);

        public virtual async Task AddAsync(T entity) 
            => await context.Set<T>().AddAsync(entity);

        public virtual void Update(T entity)
            => context.Set<T>().Update(entity);

        public virtual void Delete(T entity)
            => context.Set<T>().Remove(entity);
    }
}
