using AutoMapper;
using ZenBlogServer.Application.Features.Categories.Commands;
using ZenBlogServer.Application.Features.Categories.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Categories.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
        CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
    }
}