using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Socials.Commands;

public record RemoveSocialCommand(Guid Id) : IRequest<BaseResult<object>>;