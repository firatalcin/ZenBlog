using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.SubComments.Queries;
using ZenBlogServer.Application.Features.SubComments.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.SubComments.Handlers;

public class GetSubCommentByIdQueryHandler(IRepository<SubComment> _repository, IMapper _mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
{
    public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        if (value is null)
        {
            return BaseResult<GetSubCommentByIdQueryResult>.NotFound("SubComment Not Found");
        }

        var subComment = _mapper.Map<GetSubCommentByIdQueryResult>(value);
        return BaseResult<GetSubCommentByIdQueryResult>.Success(subComment);
    }
}