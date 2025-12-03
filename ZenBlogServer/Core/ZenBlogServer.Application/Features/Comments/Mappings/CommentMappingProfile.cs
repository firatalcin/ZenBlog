using AutoMapper;
using ZenBlogServer.Application.Features.Comments.Commands;
using ZenBlogServer.Application.Features.Comments.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Comments.Mappings;

public class CommentMappingProfile: Profile
{
    public CommentMappingProfile()
    {
        CreateMap<Comment, GetCommentsQueryResult>().ReverseMap();
        CreateMap<Comment, CreateCommentCommand>().ReverseMap();
        CreateMap<Comment, GetCommentByIdQueryResult>().ReverseMap();
        CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
    }
}