using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Categories.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Handlers;

public class RemoveCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        repository.Delete(entity);
        var response = await unitOfWork.SaveChangesAsync();
        
        return response 
            ? BaseResult<bool>.Success(response) 
            : BaseResult<bool>.NotFound("Fail deleted");
    }
}