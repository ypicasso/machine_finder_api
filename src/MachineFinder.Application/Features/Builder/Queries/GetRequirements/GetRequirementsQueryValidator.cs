using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Queries.GetRequirements
{
    public class GetRequirementsQueryValidator : AppBaseValidator<GetRequirementsQuery>
    {
        public GetRequirementsQueryValidator()
        {
            // RuleFor(r => r.cod_GetRequirements).Must(IsValidString).WithMessage("El código de GetRequirements es requerido");
        }
    }
}
