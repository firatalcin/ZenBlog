using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ZenBlogServer.Application.Extensions;

public static class ServiceRegistrations
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}