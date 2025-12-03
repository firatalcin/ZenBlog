using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Comments.Result;

namespace ZenBlogServer.Application.Features.Comments.Queries;

public record GetCommentsQuery: IRequest<BaseResult<List<GetCommentsQueryResult>>>
{
}