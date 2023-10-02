namespace Application.Features.Properties.Validators;

using Application.Models;
using FluentValidation;

public class NewPropertyValidator: AbstractValidator<NewProperty>
{
    public NewPropertyValidator()
    {
        RuleFor(np => np.Name)
           .NotEmpty().WithMessage("Name is required")
           .MinimumLength(16).WithMessage("Name must be at least 16 characters long");
    }
}
