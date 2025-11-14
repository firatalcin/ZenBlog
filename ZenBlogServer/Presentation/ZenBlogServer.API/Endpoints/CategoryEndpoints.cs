using MediatR;
using ZenBlogServer.Application.Features.Categories.Commands;
using ZenBlogServer.Application.Features.Categories.Queries;

namespace ZenBlogServer.API.Endpoints;

public static class CategoryEndpoints
{
    public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/Categories").WithTags("Categories");
        
        categories.MapGet("", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCategoryQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
        
        categories.MapGet("{id}", async (Guid id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCategoryByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        categories.MapPost("", async (CreateCategoryCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}