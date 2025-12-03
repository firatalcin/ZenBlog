using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Categories.Result;

namespace ZenBlogServer.Application.Features.Categories.Queries;

public record GetCategoryByIdQuery(Guid Id): IRequest<BaseResult<GetCategoryByIdQueryResult>>;