using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Socials.Result;

namespace ZenBlogServer.Application.Features.Socials.Queries;

public record GetSocialByIdQuery(Guid Id) : IRequest<BaseResult<GetSocialByIdQueryResult>>
{
}