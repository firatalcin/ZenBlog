using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Comments.Result;

namespace ZenBlogServer.Application.Features.SubComments.Result;

public class GetSubCommentByIdQueryResult: BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Body { get; set; }
    public DateTime CommentDate { get; set; }
    public Guid CommentId { get; set; }
    public GetCommentsQueryResult Comment { get; set; }
}