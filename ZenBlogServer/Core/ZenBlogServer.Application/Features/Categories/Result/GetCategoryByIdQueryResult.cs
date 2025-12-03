using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Categories.Result;

public class GetCategoryByIdQueryResult : BaseDto
{
    public string Name { get; set; }
}