using ZenBlogServer.Domain.Entities.Common;

namespace ZenBlogServer.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public virtual IList<Blog> Blogs { get; set; }
}