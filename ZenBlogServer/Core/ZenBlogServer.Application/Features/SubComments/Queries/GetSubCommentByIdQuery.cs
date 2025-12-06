using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.SubComments.Result;

namespace ZenBlogServer.Application.Features.SubComments.Queries;

public record GetSubCommentByIdQuery(Guid Id) : IRequest<BaseResult<GetSubCommentByIdQueryResult>>
{
}