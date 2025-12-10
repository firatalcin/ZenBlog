using AutoMapper;
using ZenBlogServer.Application.Features.ContactInfos.Commands;
using ZenBlogServer.Application.Features.ContactInfos.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.ContactInfos.Mappings;

public class ContactInfoMappingProfile: Profile
{
    public ContactInfoMappingProfile()
    {
        CreateMap<ContactInfo, GetContactInfosQueryResult>().ReverseMap();
        CreateMap<ContactInfo, CreateContactInfoCommand>().ReverseMap();
        CreateMap<ContactInfo, UpdateContactInfoCommand>().ReverseMap();
    }
}