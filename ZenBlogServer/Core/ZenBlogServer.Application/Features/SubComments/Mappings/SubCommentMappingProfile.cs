using AutoMapper;
using ZenBlogServer.Application.Features.SubComments.Commands;
using ZenBlogServer.Application.Features.SubComments.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.SubComments.Mappings;

public class SubCommentMappingProfile: Profile
{
    public SubCommentMappingProfile()
    {
        CreateMap<SubComment, CreateSubCommentCommand>().ReverseMap();
        CreateMap<SubComment, GetSubCommentsQueryResult>().ReverseMap();
        CreateMap<SubComment, GetSubCommentByIdQueryResult>().ReverseMap();
    }
}