using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Comments.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Comments.Handlers;

public class RemoveCommentCommandHandler(IRepository<Comment> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetByIdAsync(request.Id);
        if (comment is null)
        {
            return BaseResult<object>.NotFound("Comment Not Found");
        }
        _repository.Delete(comment);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Comment Deleted");
    }
}