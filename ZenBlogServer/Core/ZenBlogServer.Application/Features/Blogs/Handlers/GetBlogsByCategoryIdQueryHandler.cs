using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Blogs.Results;
using ZenBlogServer.Application.Features.Categories.Queries;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Handlers;

public class GetBlogsByCategoryIdQueryHandler(IRepository<Blog> _repository,IMapper _mapper) : IRequestHandler<GetBlogsByCategoryIdQuery, BaseResult<List<GetBlogsByCategoryIdQueryResult>>>
{
    public async Task<BaseResult<List<GetBlogsByCategoryIdQueryResult>>> Handle(GetBlogsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            var query = _repository.GetQuery();
            var values = query.Where(x => x.CategoryId == request.CategoryId).ToList();
            var blogs = _mapper.Map<List<GetBlogsByCategoryIdQueryResult>>(values);
            return BaseResult<List<GetBlogsByCategoryIdQueryResult>>.Success(blogs);
        });
    }
}