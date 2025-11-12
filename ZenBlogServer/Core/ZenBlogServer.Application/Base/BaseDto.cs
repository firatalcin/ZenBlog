namespace ZenBlogServer.Application.Base;

public abstract class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}