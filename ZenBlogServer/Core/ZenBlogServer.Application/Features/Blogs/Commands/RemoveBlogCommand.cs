using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Blogs.Commands;

public record RemoveBlogCommand(Guid Id) : IRequest<BaseResult<object>>;