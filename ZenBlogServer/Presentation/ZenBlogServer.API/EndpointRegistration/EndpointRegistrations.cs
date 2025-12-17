using ZenBlogServer.Application.Features.Blogs.Endpoints;
using ZenBlogServer.Application.Features.Categories.Endpoints;
using ZenBlogServer.Application.Features.Comments.Endpoints;
using ZenBlogServer.Application.Features.ContactInfos.Endpoints;
using ZenBlogServer.Application.Features.Messages.Endpoints;
using ZenBlogServer.Application.Features.SubComments.Endpoints;
using ZenBlogServer.Application.Features.Users.Endpoints;

namespace ZenBlogServer.API.EndpointRegistration;

public static class EndpointRegistrations
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.RegisterCategoryEndpoints();
        app.RegisterBlogEndpoints();
        app.RegisterUserEndpoints();
        app.RegisterCommentEndpoints();
        app.RegisterContactInfoEndpoints();
        app.RegisterMessageEndpoints();
        app.RegisterSubCommentEndpoints();
        
    }
}