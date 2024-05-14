using HotelBooking.Domain.IRepositories;
using HotelBooking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBooking.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public GenericRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync();
            }

            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity?> GetByIdAsync(params object?[]? keyValue)
        {
            return await _context.Set<TEntity>().FindAsync(keyValue);
        }

        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return await _context.Set<TEntity>().ToListAsync();
            }

            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<(int, List<TEntity>)> GetManyWithPaginationAsync(int page, int pageSize, Expression<Func<TEntity, bool>>? predicate = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            int totalRecord = await query.CountAsync();
            var recordsInPage = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();

            return (totalRecord, recordsInPage);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() => _context.Set<TEntity>().Any(predicate));
        }
    }
}
