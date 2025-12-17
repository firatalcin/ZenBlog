using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Messages.Result;

namespace ZenBlogServer.Application.Features.Messages.Queries;

public record GetMessagesQuery: IRequest<BaseResult<List<GetMessagesQueryResult>>>
{
}