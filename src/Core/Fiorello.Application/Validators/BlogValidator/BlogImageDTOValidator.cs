using Fiorello.Domain.Entities;
using FluentValidation;

namespace Fiorello.Application.Validators.BlogValidator;

public class BlogImageDTOValidator : AbstractValidator<Blog>
{
    public BlogImageDTOValidator()
    {
        RuleFor(x => x.ImagePath).NotNull().NotEmpty().MaximumLength(1500);
    }
}
