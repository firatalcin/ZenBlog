using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Persistence.Context;

namespace ZenBlogServer.Persistence.Concrete;

public class UnitOfWork(AppDbContext _context) : IUnitOfWork
{
    public async Task<bool> SaveChangesAsync()
    {
        var result = await  _context.SaveChangesAsync() >  0;
        return result;
    }
}