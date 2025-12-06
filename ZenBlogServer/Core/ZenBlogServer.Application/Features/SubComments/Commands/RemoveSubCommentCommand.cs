using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.SubComments.Commands;

public record RemoveSubCommentCommand(Guid Id) : IRequest<BaseResult<object>>
{
}