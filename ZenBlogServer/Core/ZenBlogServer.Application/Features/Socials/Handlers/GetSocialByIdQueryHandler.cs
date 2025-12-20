using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Socials.Queries;
using ZenBlogServer.Application.Features.Socials.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Socials.Handlers;

public class GetSocialByIdQueryHandler(IRepository<Social> repository, IMapper mapper) : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResult>>
{
    public async Task<BaseResult<GetSocialByIdQueryResult>> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the social by ID
        var social = await repository.GetByIdAsync(request.Id);
        if (social == null)
        {
            return BaseResult<GetSocialByIdQueryResult>.Fail("Social not found.");
        }
        //mapping the social to the result object
        var socialResult = mapper.Map<GetSocialByIdQueryResult>(social);
        return BaseResult<GetSocialByIdQueryResult>.Success(socialResult);

    }
}