using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Persistence.Concrete;
using ZenBlogServer.Persistence.Context;
using ZenBlogServer.Persistence.Interceptors;

namespace ZenBlogServer.Persistence.Extensions;

public static class ServiceRegistrations
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            options.AddInterceptors(new AuditDbContextInterceptor());
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }
}