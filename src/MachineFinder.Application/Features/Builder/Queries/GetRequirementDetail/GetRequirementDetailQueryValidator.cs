using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Queries.GetRequirementDetail
{
    public class GetRequirementDetailQueryValidator : AppBaseValidator<GetRequirementDetailQuery>
    {
        public GetRequirementDetailQueryValidator()
        {
            // RuleFor(r => r.cod_GetRequirementDetail).Must(IsValidString).WithMessage("El código de GetRequirementDetail es requerido");
        }
    }
}
