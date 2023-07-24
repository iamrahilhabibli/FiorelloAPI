using Fiorello.Application.DTOs.SliderDTOs;
using FluentValidation;

namespace Fiorello.Application.Validators.SliderValidators;

public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
{
	public SliderCreateDtoValidator()
	{
		RuleFor(s => s.title).NotNull().NotEmpty().MaximumLength(50);
		RuleFor(s => s.description).NotNull().NotEmpty().MaximumLength(150);
		RuleFor(s=>s.imagePath).NotNull().NotEmpty().MaximumLength(255);
	}
}
