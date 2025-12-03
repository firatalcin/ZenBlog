using ZenBlogServer.Application.Features.Blogs.Endpoints;
using ZenBlogServer.Application.Features.Categories.Endpoints;
using ZenBlogServer.Application.Features.Users.Endpoints;

namespace ZenBlogServer.API.EndpointRegistration;

public static class EndpointRegistrations
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.RegisterCategoryEndpoints();
        app.RegisterBlogEndpoints();
        app.RegisterUserEndpoints();
    }
}