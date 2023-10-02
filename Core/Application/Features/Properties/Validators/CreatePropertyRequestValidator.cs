namespace Application.Features.Properties.Validators;

using Application.Features.Properties.Commands;
using FluentValidation;

public class CreatePropertyRequestValidator: AbstractValidator<CreatePropertyRequest>
{
    public CreatePropertyRequestValidator()
    {
        RuleFor(request => request.PropertyRequest)
           .SetValidator(new NewPropertyValidator());
    }
}
