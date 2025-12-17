using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Messages.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Messages.Handlers;

public class CreateMessageCommandHandler(IRepository<Message> repository,IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateMessageCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = mapper.Map<Message>(request);
        await repository.CreateAsync(message);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(message);
    }
}