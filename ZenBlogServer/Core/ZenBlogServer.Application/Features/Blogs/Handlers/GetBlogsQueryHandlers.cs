using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Blogs.Result;
using ZenBlogServer.Application.Features.Categories.Queries;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Handlers;

public class GetBlogsQueryHandlers(IRepository<Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogsQuery, BaseResult<List<GetBlogsQueryResult>>>
{
    public async Task<BaseResult<List<GetBlogsQueryResult>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        var blogs = _mapper.Map<List<GetBlogsQueryResult>>(values);
        return BaseResult<List<GetBlogsQueryResult>>.Success(blogs);
    }
}