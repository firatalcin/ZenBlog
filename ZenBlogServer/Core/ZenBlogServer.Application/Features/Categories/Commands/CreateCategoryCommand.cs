using MediatR;
using ZenBlogServer.Application.Base;

namespace ZenBlogServer.Application.Features.Categories.Commands;

public record CreateCategoryCommand(string CategoryName) :  IRequest<BaseResult<object>>;