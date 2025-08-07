using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Licencia.Commands.Delete
{
    public class DeleteCommandValidator : AppBaseValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(r => r.id_licencia).Must(IsValidString).WithMessage("El ID es requerido");
        }
    }
}
