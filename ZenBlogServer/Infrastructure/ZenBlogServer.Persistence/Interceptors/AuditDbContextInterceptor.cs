using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZenBlogServer.Domain.Entities.Common;

namespace ZenBlogServer.Persistence.Interceptors;

public class AuditDbContextInterceptor : SaveChangesInterceptor
{
    private static readonly Dictionary<EntityState, Action<DbContext, BaseEntity>> Behaviors = new()
    {
        {
            EntityState.Added, AddedBehavior
        },
        {
            EntityState.Modified, ModifiedBehavior
        }
    };

    private static void AddedBehavior(DbContext context, BaseEntity entity)
    {
        context.Entry(entity).Property(x => x.UpdateAt).IsModified = false;
        entity.CreateAt = DateTime.Now;
    }
    
    private static void ModifiedBehavior(DbContext context, BaseEntity entity)
    {
        context.Entry(entity).Property(x => x.CreateAt).IsModified = false;
        entity.UpdateAt = DateTime.Now;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseEntity entity)
            {
                continue;
            }
            
            if (entry.State is not EntityState.Added and not EntityState.Modified)
            {
                continue;   
            }
            
            Behaviors[entry.State](eventData.Context, entity);
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);       
    }
}