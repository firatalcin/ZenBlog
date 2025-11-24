using AutoMapper;
using ZenBlogServer.Application.Features.Users.Commands;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Users.Mappings;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<AppUser, CreateUserCommand>().ReverseMap();
    }
}