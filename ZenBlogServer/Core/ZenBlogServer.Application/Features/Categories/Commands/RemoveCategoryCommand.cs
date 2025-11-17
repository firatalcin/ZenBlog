using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Categories.Commands;

public record RemoveCategoryCommand(Guid Id) :  IRequest<BaseResult<bool>>;
