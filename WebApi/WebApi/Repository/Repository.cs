using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebApi.Datos;
using WebApi.Models;
using WebApi.Repository.Interfaces;


namespace WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _dbContext { get; set; }
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Task<IQueryable<TEntity>> GetQueryAsync<TEntity>(Expression<Func<TEntity, bool>> predicate = null,
                                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null) where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            if (include != null)
                query = include(query);

            return Task.FromResult(query);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class =>
            await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> FindFirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, bool>> condition = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null) where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (condition != null)
                query = query.Where(condition);

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class => await _dbContext.Set<TEntity>().FindAsync(id);


        public async Task<IList<TEntity>> FindAsync<TEntity>(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (predicate == null)
                return await query.ToListAsync();

            return await query.Where(predicate).AsQueryable().ToListAsync(); // <- Se hace así porque el where devuelve IEnumerable
        }


        public async Task<IEnumerable<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class
            => await _dbContext.Set<TEntity>().Where(condition).ToListAsync();


        public async Task<bool> ExistsEntityAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class => await _dbContext.Set<TEntity>().AnyAsync(predicate);


        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
