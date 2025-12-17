using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Messages.Queries;
using ZenBlogServer.Application.Features.Messages.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Messages.Handlers;

public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, BaseResult<List<GetMessagesQueryResult>>>
{
    private readonly IRepository<Message> _repository;
    private readonly IMapper _mapper;
    public GetMessagesQueryHandler(IRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<BaseResult<List<GetMessagesQueryResult>>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = await _repository.GetAllAsync();
        var result = _mapper.Map<List<GetMessagesQueryResult>>(messages);
        return BaseResult<List<GetMessagesQueryResult>>.Success(result);
    }
}