using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Blogs.Commands;

public class UpdateBlogCommand: IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string UserId { get; set; }
}