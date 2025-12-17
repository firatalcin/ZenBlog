using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Messages.Queries;
using ZenBlogServer.Application.Features.Messages.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Messages.Handlers;

public class GetReadMessagesQueryHandler(IRepository<Message> repository, IMapper mapper) : IRequestHandler<GetReadMessagesQuery, BaseResult<List<GetReadMessagesQueryResult>>>
{
    public async Task<BaseResult<List<GetReadMessagesQueryResult>>> Handle(GetReadMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = await repository.GetAllAsync(x => x.IsRead == true);
        var mappedResult = mapper.Map<List<GetReadMessagesQueryResult>>(messages);
        return BaseResult<List<GetReadMessagesQueryResult>>.Success(mappedResult);
    }
}