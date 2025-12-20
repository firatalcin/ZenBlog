using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Socials.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Socials.Handlers;

public class CreateSocialCommandHandler(IRepository<Social> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateSocialCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
    {
          
        var social = mapper.Map<Social>(request);

        await repository.CreateAsync(social);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(social);
    }
}