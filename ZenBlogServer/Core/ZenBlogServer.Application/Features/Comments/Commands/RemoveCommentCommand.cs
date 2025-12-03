using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Comments.Commands;

public record RemoveCommentCommand(Guid Id) : IRequest<BaseResult<object>>;