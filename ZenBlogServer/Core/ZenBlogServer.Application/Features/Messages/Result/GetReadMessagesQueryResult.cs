using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Messages.Result;

public class GetReadMessagesQueryResult: BaseDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string MessageBody { get; set; }
    public bool IsRead { get; set; }
}