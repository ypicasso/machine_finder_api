using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Delete
{
    public class DeleteCommandValidator : AppBaseValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(r => r.id_tipo_maquinaria).Must(IsValidString).WithMessage("El ID es requerido");
        }
    }
}
