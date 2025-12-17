using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Messages.Commands;

public record UpdateMessageCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Subject { get; init; }
    public string MessageBody { get; init; }
    public bool IsRead { get; init; } 
}