using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Socials.Commands;

public record CreateSocialCommand: IRequest<BaseResult<object>>
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}