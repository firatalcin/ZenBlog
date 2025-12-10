using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.ContactInfos.Commands;

public record RemoveContactInfoCommand(Guid Id) : IRequest<BaseResult<object>>
{
}