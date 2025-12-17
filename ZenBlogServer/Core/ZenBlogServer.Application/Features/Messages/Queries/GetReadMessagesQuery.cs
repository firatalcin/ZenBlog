using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.Messages.Result;

namespace ZenBlogServer.Application.Features.Messages.Queries;

public record GetReadMessagesQuery: IRequest<BaseResult<List<GetReadMessagesQueryResult>>>;