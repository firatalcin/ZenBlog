using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.ContactInfos.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.ContactInfos.Handlers;

public class CreateContactInfoCommandHandler(IRepository<ContactInfo> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
    {
        var contactInfo = mapper.Map<ContactInfo>(request);
        await repository.CreateAsync(contactInfo);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(contactInfo);
    }
}