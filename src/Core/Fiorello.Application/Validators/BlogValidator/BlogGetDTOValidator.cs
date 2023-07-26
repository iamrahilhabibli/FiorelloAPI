﻿using Fiorello.Domain.Entities;
using FluentValidation;

namespace Fiorello.Application.Validators.BlogValidator;

public class BlogGetDTOValidator : AbstractValidator<Blog>
{
    public BlogGetDTOValidator()
    {
        RuleFor(x => x.ImagePath).NotNull().NotEmpty().MaximumLength(400);
        RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(40);
        RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(1500);
    }
}