using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Messages.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Messages.Handlers;

public class RemoveMessageCommandHandler : IRequestHandler<RemoveMessageCommand, BaseResult<object>>
{
    private readonly IRepository<Message> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RemoveMessageCommandHandler(IRepository<Message> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _repository.GetByIdAsync(request.Id);
        if (message == null)
        {
            return BaseResult<object>.NotFound("Message not found");
        }
        _repository.Delete(message);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Message Deleted");
    }
}