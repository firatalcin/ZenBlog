using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.ContactInfos.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.ContactInfos.Handlers;

public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
    {
        // Get the contact info by ID
        var contactInfo = await repository.GetByIdAsync(request.Id);
        if (contactInfo == null)
        {
            return BaseResult<object>.Fail("Contact info not found.");
        }
        // Remove the contact info
        repository.Delete(contactInfo);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Contact Info Removed");
    }
}