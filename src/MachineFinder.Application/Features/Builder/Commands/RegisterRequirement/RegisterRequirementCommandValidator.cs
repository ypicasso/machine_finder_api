using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Commands.RegisterRequirement
{
    public class RegisterRequirementCommandValidator : AppBaseValidator<RegisterRequirementCommand>
    {
        public RegisterRequirementCommandValidator()
        {
            // RuleFor(r => r.cod_RegisterRequirement).Must(IsValidString).WithMessage("El código de RegisterRequirement es requerido");
        }
    }
}
