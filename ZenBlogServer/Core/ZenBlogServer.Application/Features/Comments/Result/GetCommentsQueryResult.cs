using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Blogs.Result;

namespace ZenBlogServer.Application.Features.Comments.Result;

public class GetCommentsQueryResult : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Body { get; set; }
    public DateTime CommentDate { get; set; }
    //public virtual IList<SubComment> SubComments { get; set; }
    public Guid BlogId { get; set; }
    public GetBlogsQueryResult Blog { get; set; }
}