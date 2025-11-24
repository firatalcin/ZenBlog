using MediatR;
using ZenBlogServer.Application.Features.Blogs.Commands;
using ZenBlogServer.Application.Features.Categories.Queries;

namespace ZenBlogServer.API.Endpoints;

public static class BlogEndpoints
{
    public static void RegisterBlogEndpoints(this IEndpointRouteBuilder app)
    {
        var blogs = app.MapGroup("/blogs").WithTags("Blogs");

        blogs.MapGet(string.Empty,
            async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetBlogsQuery());

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();
        
        blogs.MapPost(string.Empty, 
            async (CreateBlogCommand command,IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
    }
}