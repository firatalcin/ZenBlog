using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Socials.Queries;
using ZenBlogServer.Application.Features.Socials.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Socials.Handlers;

public class GetSocialsQueryHandler(IRepository<Social> repository, IMapper mapper) : IRequestHandler<GetSocialsQuery, BaseResult<List<GetSocialsQueryResult>>>
{
    public async Task<BaseResult<List<GetSocialsQueryResult>>> Handle(GetSocialsQuery request, CancellationToken cancellationToken)
    {
        var socials = await repository.GetAllAsync();
        var socialsResult = mapper.Map<List<GetSocialsQueryResult>>(socials);
        return BaseResult<List<GetSocialsQueryResult>>.Success(socialsResult);
    }
}