using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Blogs.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Handlers;

public class CreateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateBlogCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = mapper.Map<Blog>(request);
        await repository.CreateAsync(blog);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(blog);
    }
}