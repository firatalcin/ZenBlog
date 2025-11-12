using FluentValidation;
using ZenBlogServer.Application.Features.Categories.Commands;

namespace ZenBlogServer.Application.Features.Categories.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("CategoryName is required.");
        RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("CategoryName must be at least 3 characters");
    }
}