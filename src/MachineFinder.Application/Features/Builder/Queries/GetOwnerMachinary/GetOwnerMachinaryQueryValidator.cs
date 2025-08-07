using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Queries.GetOwnerMachinary
{
    public class GetOwnerMachinaryQueryValidator : AppBaseValidator<GetOwnerMachinaryQuery>
    {
        public GetOwnerMachinaryQueryValidator()
        {
            // RuleFor(r => r.cod_GetOwnerMachinary).Must(IsValidString).WithMessage("El código de GetOwnerMachinary es requerido");
        }
    }
}
