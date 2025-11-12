using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Categories.Results;

namespace ZenBlogServer.Application.Features.Categories.Queries;

public class GetCategoryQuery : IRequest<BaseResult<List<GetCategoryQueryResult>>>
{
    
}