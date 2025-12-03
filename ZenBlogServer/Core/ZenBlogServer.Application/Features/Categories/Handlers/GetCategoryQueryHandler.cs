using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Categories.Queries;
using ZenBlogServer.Application.Features.Categories.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Handlers;

public class GetCategoryQueryHandler(IRepository<Category> repository, IMapper _mapper) : IRequestHandler<GetCategoryQuery, BaseResult<List<GetCategoryQueryResult>>>
{
    public async Task<BaseResult<List<GetCategoryQueryResult>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync();
        var response = _mapper.Map<List<GetCategoryQueryResult>>(categories);
        
        return BaseResult<List<GetCategoryQueryResult>>.Success(response);
    }
}