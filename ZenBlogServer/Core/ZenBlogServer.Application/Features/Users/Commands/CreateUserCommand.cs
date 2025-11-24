using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Users.Commands;

public class CreateUserCommand : IRequest<BaseResult<object>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}