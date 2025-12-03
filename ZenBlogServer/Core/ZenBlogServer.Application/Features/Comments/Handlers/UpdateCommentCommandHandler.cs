using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Comments.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Comments.Handlers;

public class UpdateCommentCommandHandler(IRepository<Comment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request);
        _repository.Update(comment);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Comment Updated Successfully");
    }
}