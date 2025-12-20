using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Socials.Commands;

public record UpdateSocialCommand(Guid Id, string Title, string Url, string Icon) : IRequest<BaseResult<object>>;