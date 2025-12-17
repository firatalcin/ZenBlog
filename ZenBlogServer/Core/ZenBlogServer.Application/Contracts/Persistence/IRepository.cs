using System.Linq.Expressions;
using ZenBlogServer.Domain.Entities.Common;

namespace ZenBlogServer.Application.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : BaseEntity 
{
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
    IQueryable<TEntity> GetQuery();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}