using MediatR;
using ZenBlogServer.Application.Features.Categories.Queries;

namespace ZenBlogServer.API.Endpoints;

public static class CategoryEndpoints
{
    public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/Categories").WithTags("Categories");
        categories.MapGet("", async (IMediator _mediator) =>
        {
            var response = await _mediator.Send(new GetCategoryQuery());

            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}