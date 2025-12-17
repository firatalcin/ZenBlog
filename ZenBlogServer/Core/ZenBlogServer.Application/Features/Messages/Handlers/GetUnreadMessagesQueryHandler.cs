using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Messages.Queries;
using ZenBlogServer.Application.Features.Messages.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Messages.Handlers;

public class GetUnreadMessagesQueryHandler(IRepository<Message> repository,IMapper mapper) : IRequestHandler<GetUnreadMessagesQuery, BaseResult<List<GetUnreadMessagesQueryResult>>>
{
    public async Task<BaseResult<List<GetUnreadMessagesQueryResult>>> Handle(GetUnreadMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = await repository.GetAllAsync(x => x.IsRead == false);
        var mappedResult = mapper.Map<List<GetUnreadMessagesQueryResult>>(messages);
        return BaseResult<List<GetUnreadMessagesQueryResult>>.Success(mappedResult);
    }
}