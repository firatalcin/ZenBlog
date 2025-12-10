using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.ContactInfos.Result;

namespace ZenBlogServer.Application.Features.ContactInfos.Queries;

public record GetContactInfoByIdQuery(Guid Id): IRequest<BaseResult<GetContactInfoByIdQueryResult>>
{
}