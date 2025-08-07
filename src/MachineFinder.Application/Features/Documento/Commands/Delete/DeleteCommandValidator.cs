using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Documento.Commands.Delete
{
    public class DeleteCommandValidator : AppBaseValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            // RuleFor(r => r.cod_TipoDocumento).Must(IsValidString).WithMessage("El código de TipoDocumento es requerido");
            RuleFor(r => r.id).Must(IsValidString).WithMessage("El ID es requerido");
        }
    }
}
