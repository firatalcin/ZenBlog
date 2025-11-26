using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Categories.Results;

namespace ZenBlogServer.Application.Features.Blogs.Results;

public class GetBlogByIdQueryResult: BaseDto
{
    public string Title { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public GetCategoryQueryResult Category { get; set; }
    public string UserId { get; set; }
    //public GetUsersQueryResult User { get; set; }
    //public  IList<GetCommentsQueryResult> Comments { get; set; }
}