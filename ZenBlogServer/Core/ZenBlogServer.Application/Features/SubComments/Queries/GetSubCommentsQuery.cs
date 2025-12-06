using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Features.SubComments.Result;

namespace ZenBlogServer.Application.Features.SubComments.Queries;

public record GetSubCommentsQuery : IRequest<BaseResult<List<GetSubCommentsQueryResult>>>;