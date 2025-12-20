using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Socials.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Socials.Handlers;

public class RemoveSocialCommandHandler(IRepository<Social> repository, IUnitOfWork unitOfWork) : IRequestHandler<RemoveSocialCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveSocialCommand request, CancellationToken cancellationToken)
    {
        //remove the social by ID
        var social = await repository.GetByIdAsync(request.Id);
        if (social == null)
        {
            return BaseResult<object>.Fail("Social not found.");
        }
        repository.Delete(social);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Social Removed");
    }
}