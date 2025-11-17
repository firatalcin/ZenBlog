using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Categories.Commands;

public record UpdateCategoryCommand(Guid Id, string CategoryName) : IRequest<BaseResult<bool>>;
