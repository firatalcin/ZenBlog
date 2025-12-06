using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.SubComments.Queries;
using ZenBlogServer.Application.Features.SubComments.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.SubComments.Handlers;

public class GetSubCommentsQueryHandler(IRepository<SubComment> _repository,IMapper _mapper) : IRequestHandler<GetSubCommentsQuery, BaseResult<List<GetSubCommentsQueryResult>>>
{
    public async Task<BaseResult<List<GetSubCommentsQueryResult>>> Handle(GetSubCommentsQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        var subComments = _mapper.Map<List<GetSubCommentsQueryResult>>(values);
        return BaseResult<List<GetSubCommentsQueryResult>>.Success(subComments);
    }
}