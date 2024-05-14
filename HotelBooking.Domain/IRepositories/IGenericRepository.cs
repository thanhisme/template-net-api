using System.Linq.Expressions;

namespace HotelBooking.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? predicate = null);
        Task<(int, List<TEntity>)> GetManyWithPaginationAsync(int page, int pageSize, Expression<Func<TEntity, bool>>? predicate = null);
        Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? predicate = null);
        Task<TEntity?> GetByIdAsync(params object?[]? keyValue);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
}
