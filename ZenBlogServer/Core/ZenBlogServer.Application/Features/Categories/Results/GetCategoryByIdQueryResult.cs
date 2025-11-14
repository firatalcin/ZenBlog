using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Categories.Results;

public class GetCategoryByIdQueryResult : BaseDto
{
    public string Name { get; set; }
}