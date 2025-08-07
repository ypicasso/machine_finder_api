using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Queries.GetLicenses
{
    public class GetLicensesQueryValidator : AppBaseValidator<GetLicensesQuery>
    {
        public GetLicensesQueryValidator()
        {
            // RuleFor(r => r.cod_GetLicenses).Must(IsValidString).WithMessage("El código de GetLicenses es requerido");
        }
    }
}
