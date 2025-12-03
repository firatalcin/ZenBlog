using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Comments.Queries;
using ZenBlogServer.Application.Features.Comments.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Comments.Handlers;

public class GetCommentsQueryHandler(IRepository<Comment> _repository,IMapper _mapper) : IRequestHandler<GetCommentsQuery, BaseResult<List<GetCommentsQueryResult>>>
{
    public async Task<BaseResult<List<GetCommentsQueryResult>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        var comments = _mapper.Map<List<GetCommentsQueryResult>>(values);
        return BaseResult<List<GetCommentsQueryResult>>.Success(comments);
    }
}