using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Categories.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Handlers;

public class CreateCategoryCommandHandler(IRepository<Category> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        await _repository.CreateAsync(category);
        var result =  await _unitOfWork.SaveChangesAsync();
        return result == true ? BaseResult<bool>.Success(result) : BaseResult<bool>.Fail();
    }
}