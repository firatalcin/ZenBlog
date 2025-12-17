using AutoMapper;
using ZenBlogServer.Application.Features.Messages.Commands;
using ZenBlogServer.Application.Features.Messages.Result;
using ZenBlogServer.Domain.Entities;

namespace ZenBlogServer.Application.Features.Messages.Mappings;

public class MessageMappingProfile: Profile
{
    public MessageMappingProfile()
    {
        CreateMap<Message, CreateMessageCommand>().ReverseMap();
        CreateMap<Message, GetMessagesQueryResult>().ReverseMap();
        CreateMap<Message, GetMessageByIdQueryResult>().ReverseMap();
        CreateMap<Message, UpdateMessageCommand>().ReverseMap();
        CreateMap<Message, GetUnreadMessagesQueryResult>().ReverseMap();
        CreateMap<Message, GetReadMessagesQueryResult>().ReverseMap();

    }
}