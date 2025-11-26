using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Blogs.Results;

namespace ZenBlogServer.Application.Features.Categories.Queries;

public record GetBlogsByCategoryIdQuery(Guid CategoryId): IRequest<BaseResult<List<GetBlogsByCategoryIdQueryResult>>>;
