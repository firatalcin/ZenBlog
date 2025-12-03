using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Blogs.Result;

namespace ZenBlogServer.Application.Features.Categories.Queries;

public record GetBlogsQuery : IRequest<BaseResult<List<GetBlogsQueryResult>>>
{
    
}