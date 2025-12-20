using AutoMapper;
using ZenBlogServer.Application.Features.Socials.Commands;
using ZenBlogServer.Application.Features.Socials.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Socials.Mappings;

public class SocialMappingProfile: Profile
{
    public SocialMappingProfile()
    {
        CreateMap<Social, CreateSocialCommand>().ReverseMap();
        CreateMap<Social, GetSocialsQueryResult>().ReverseMap();
        CreateMap<Social, GetSocialByIdQueryResult>().ReverseMap();
        CreateMap<Social, UpdateSocialCommand>().ReverseMap();
    }
}