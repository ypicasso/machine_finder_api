using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Licencia.Queries.GetById
{
    public class GetByIdQueryValidator : AppBaseValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(r => r.id).Must(IsValidString).WithMessage("El ID es requerido");
        }
    }
}
