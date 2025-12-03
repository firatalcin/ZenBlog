using ZenBlogServer.Application.Base;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Result;

public class GetCategoryQueryResult : BaseDto
{
    public string Name { get; set; }
    //public IList<Blog> Blogs { get; set; }
}