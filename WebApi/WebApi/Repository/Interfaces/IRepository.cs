using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace WebApi.Repository.Interfaces
{
    public interface IRepository
    {
        Task CreateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
        public Task<IQueryable<TEntity>> GetQueryAsync<TEntity>(Expression<Func<TEntity, bool>> predicate = null,
                                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        Task<TEntity> FindFirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
                                              Expression<Func<TEntity, bool>> condition = null,
                                              Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null) where TEntity : class;

        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<IList<TEntity>> FindAsync<TEntity>(Func<TEntity, bool> predicate, params
                                                Expression<Func<TEntity, object>>[] includes) where TEntity : class;
        Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class;
        Task<bool> ExistsEntityAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
