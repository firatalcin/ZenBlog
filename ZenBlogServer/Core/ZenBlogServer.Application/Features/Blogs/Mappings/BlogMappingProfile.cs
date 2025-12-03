using AutoMapper;
using ZenBlogServer.Application.Features.Blogs.Commands;
using ZenBlogServer.Application.Features.Blogs.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Blogs.Mappings;

public class BlogMappingProfile : Profile
{
    public BlogMappingProfile()
    {
        CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
        CreateMap<Blog, GetBlogByIdQueryResult>().ReverseMap();
        CreateMap<Blog, CreateBlogCommand>().ReverseMap();
        CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
        CreateMap<Blog, GetBlogsByCategoryIdQueryResult>().ReverseMap();
    }
}