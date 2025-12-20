using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Socials.Result;

namespace ZenBlogServer.Application.Features.Socials.Queries;

public record GetSocialsQuery: IRequest<BaseResult<List<GetSocialsQueryResult>>>
{
}