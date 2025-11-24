using AutoMapper;
using ZenBlogServer.Application.Features.Blogs.Results;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Mappings;

public class BlogMappingProfile : Profile
{
    public BlogMappingProfile()
    {
        CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
    }
}