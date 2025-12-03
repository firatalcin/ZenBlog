using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Blogs.Result;

namespace ZenBlogServer.Application.Features.Categories.Queries;

public record GetBlogsByCategoryIdQuery(Guid CategoryId): IRequest<BaseResult<List<GetBlogsByCategoryIdQueryResult>>>;
