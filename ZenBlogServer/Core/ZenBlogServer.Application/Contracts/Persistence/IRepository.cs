using System.Linq.Expressions;
using ZenBlogServer.Domain.Entities.Common;

namespace ZenBlogServer.Application.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : BaseEntity 
{
    Task<List<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetQueryAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}