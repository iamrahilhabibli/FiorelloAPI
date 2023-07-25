using Fiorello.Application.DTOs.Slider;
using FluentValidation;

namespace Fiorello.Application.Validators.SliderValidator;

public class SliderCreateDTOValidator : AbstractValidator<SliderCreateDTO>
{
    public SliderCreateDTOValidator()
    {
        RuleFor(x => x.imagePath).NotNull().NotEmpty().MaximumLength(500);
        RuleFor(x => x.title).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(x => x.description).NotNull().NotEmpty().MaximumLength(111);
    }
}
