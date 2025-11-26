using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Blogs.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Handlers;

public class UpdateBlogCommandHandler(IRepository<Blog> _repository, IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = _mapper.Map<Blog>(request);
        _repository.Update(blog);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Blog has been updated successfully");
    }
}