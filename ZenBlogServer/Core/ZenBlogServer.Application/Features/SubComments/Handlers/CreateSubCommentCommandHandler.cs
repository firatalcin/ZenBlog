using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.SubComments.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.SubComments.Handlers;

public class CreateSubCommentCommandHandler(IRepository<SubComment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
    {
        var subComment = _mapper.Map<SubComment>(request);
        await _repository.CreateAsync(subComment);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(subComment);
    }
}