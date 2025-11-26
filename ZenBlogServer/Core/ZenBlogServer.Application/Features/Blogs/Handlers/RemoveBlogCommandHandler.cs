using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Blogs.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Handlers;

public class RemoveBlogCommandHandler(IRepository<Blog> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<RemoveBlogCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.Id);
        if (blog == null)
        {
            return BaseResult<object>.NotFound("Blog Not Found");
        }

        _repository.Delete(blog);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Blog has been deleted successfully");
    }
}