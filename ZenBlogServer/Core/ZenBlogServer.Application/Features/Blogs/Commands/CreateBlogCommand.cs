using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Blogs.Commands;

public class CreateBlogCommand: IRequest<BaseResult<object>>
{
    public string Title { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string UserId { get; set; }
}