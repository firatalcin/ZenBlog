using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Categories.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Handlers;

public class UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper, IUnitOfWork unitOfWork) 
    : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);
        repository.Update(category);
        var response = await unitOfWork.SaveChangesAsync();
        
        return response
            ? BaseResult<bool>.Success(response)
            : BaseResult<bool>.NotFound("Category could not be updated");
    }
}