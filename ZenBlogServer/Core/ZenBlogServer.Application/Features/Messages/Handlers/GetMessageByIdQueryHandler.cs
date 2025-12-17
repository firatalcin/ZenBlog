using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Messages.Queries;
using ZenBlogServer.Application.Features.Messages.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Messages.Handlers;

public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageByIdQueryResult>>
{
    private readonly IRepository<Message> _repository;
    private readonly IMapper _mapper;
    public GetMessageByIdQueryHandler(IRepository<Message> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<BaseResult<GetMessageByIdQueryResult>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var message = await _repository.GetByIdAsync(request.Id);
        if (message == null)
        {
            return BaseResult<GetMessageByIdQueryResult>.NotFound("Message not found");
        }
        var result = _mapper.Map<GetMessageByIdQueryResult>(message);
        return BaseResult<GetMessageByIdQueryResult>.Success(result);
    }
}