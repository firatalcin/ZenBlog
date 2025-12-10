using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.ContactInfos.Queries;
using ZenBlogServer.Application.Features.ContactInfos.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.ContactInfos.Handlers;

public class GetContactInfoByIdQueryHandler(IRepository<ContactInfo> repository, IMapper mapper) : IRequestHandler<GetContactInfoByIdQuery, BaseResult<GetContactInfoByIdQueryResult>>
{
    public async Task<BaseResult<GetContactInfoByIdQueryResult>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var contactInfo = await repository.GetByIdAsync(request.Id);
        if (contactInfo == null)
        {
            return BaseResult<GetContactInfoByIdQueryResult>.Fail("Contact info not found");
        }
        var result = mapper.Map<GetContactInfoByIdQueryResult>(contactInfo);
        return BaseResult<GetContactInfoByIdQueryResult>.Success(result);
    }
}