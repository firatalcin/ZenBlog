using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Categories.Queries;
using ZenBlogServer.Application.Features.Categories.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Handlers;

public class GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>
{
    public async Task<BaseResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id);

        if (category == null)
        {
            return BaseResult<GetCategoryByIdQueryResult>.NotFound("Category not found");
        }
        
        var response = mapper.Map<GetCategoryByIdQueryResult>(category);
        return BaseResult<GetCategoryByIdQueryResult>.Success(response);
    }
}