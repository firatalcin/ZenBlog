using AutoMapper;
using MediatR;
using ZenBlogServer.Application.Base;
using ZenBlogServer.Application.Contracts.Persistence;
using ZenBlogServer.Application.Features.Blogs.Result;
using ZenBlogServer.Application.Features.Categories.Queries;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Handlers;

public class GetBlogByIdQueryHandler(IRepository<Blog> repository,IMapper mapper) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
{
    public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await repository.GetByIdAsync(request.Id);
        if (value is null)
        {
            return BaseResult<GetBlogByIdQueryResult>.NotFound("Blog Not Found");
        }

        var blog = mapper.Map<GetBlogByIdQueryResult>(value);

        return BaseResult<GetBlogByIdQueryResult>.Success(blog);
    }
}