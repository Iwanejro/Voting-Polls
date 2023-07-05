using Microsoft.EntityFrameworkCore;
using VotingPolls.Contracts;
using VotingPolls.Data;

namespace VotingPolls.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public virtual async Task DeleteAsync(int id)
        {
            _context.ChangeTracker.Clear();
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }
       
        public async Task UpdateAsync(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
