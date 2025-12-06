using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.SubComments.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.SubComments.Handlers;

public class UpdateSubCommentCommandHandler(IRepository<SubComment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
    {
        var subComment = await _repository.GetByIdAsync(request.Id);
        if (subComment == null)
        {
            return BaseResult<object>.Fail("SubComment not found");
        }

        subComment = _mapper.Map(request, subComment);

        _repository.Update(subComment);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("SubComment Updated");
    }
}