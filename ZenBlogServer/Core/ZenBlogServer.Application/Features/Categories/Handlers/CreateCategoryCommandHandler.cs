using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Categories.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Handlers;

public class CreateCategoryCommandHandler(IRepository<Category> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateCategoryCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        await _repository.CreateAsync(category);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(category);
    }
}