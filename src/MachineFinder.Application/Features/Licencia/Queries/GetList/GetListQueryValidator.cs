using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Licencia.Queries.GetList
{
    public class GetListQueryValidator : AppBaseValidator<GetListQuery>
    {
        public GetListQueryValidator()
        {
            // RuleFor(r => r.cod_GetList).Must(IsValidString).WithMessage("El código de GetList es requerido");
        }
    }
}
