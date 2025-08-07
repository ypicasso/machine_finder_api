using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Queries.GetOwners
{
    public class GetOwnersQueryValidator : AppBaseValidator<GetOwnersQuery>
    {
        public GetOwnersQueryValidator()
        {
            // RuleFor(r => r.cod_GetOwners).Must(IsValidString).WithMessage("El código de GetOwners es requerido");
        }
    }
}
