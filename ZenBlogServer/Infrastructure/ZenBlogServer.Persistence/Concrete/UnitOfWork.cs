using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Persistence.Context;

namespace ZenBlogServer.Persistence.Concrete;

public class UnitOfWork(AppDbContext _context) : IUnitOfWork
{
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}