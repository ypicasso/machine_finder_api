using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.TipoMaquinaria.Queries.GetById
{
    public class GetByIdQueryValidator : AppBaseValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(r => r.id_tipo_maquinaria).Must(IsValidString).WithMessage("El ID es requerido");
        }
    }
}
