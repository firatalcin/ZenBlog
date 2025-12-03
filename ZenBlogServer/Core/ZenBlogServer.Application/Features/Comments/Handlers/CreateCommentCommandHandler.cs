using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Comments.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Comments.Handlers;

public class CreateCommentCommandHandler(IRepository<Comment> _repository,IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<CreateCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request);
        await _repository.CreateAsync(comment);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(comment);
    }
}