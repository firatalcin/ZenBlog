using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Messages.Commands;

public record RemoveMessageCommand(Guid Id) : IRequest<BaseResult<object>>
{
}