using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.ContactInfos.Queries;
using ZenBlogServer.Application.Features.ContactInfos.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.ContactInfos.Handlers;

public class GetContactInfosQueryHandler(IRepository<ContactInfo> repository, IMapper mapper): IRequestHandler<GetContactInfosQuery, BaseResult<List<GetContactInfosQueryResult>>>
{
    public async Task<BaseResult<List<GetContactInfosQueryResult>>> Handle(GetContactInfosQuery request, CancellationToken cancellationToken)
    {
        var contactInfos = await repository.GetAllAsync();
        var result = mapper.Map<List<GetContactInfosQueryResult>>(contactInfos);
        return BaseResult<List<GetContactInfosQueryResult>>.Success(result);
            

    }
}