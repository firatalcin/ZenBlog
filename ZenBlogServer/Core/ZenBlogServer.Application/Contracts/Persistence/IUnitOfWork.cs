namespace ZenBlogServer.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
}