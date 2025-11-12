using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ZenBlogServer.Application.Extensions;

public static class ServiceRegistrations
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}