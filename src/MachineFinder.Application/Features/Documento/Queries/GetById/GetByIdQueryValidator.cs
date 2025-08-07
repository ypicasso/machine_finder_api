using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Documento.Queries.GetById
{
    public class GetByIdQueryValidator : AppBaseValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            // Validations if is needed
            RuleFor(r => r.id).Must(IsValidString).WithMessage("El ID es requerido");
        }
    }
}
