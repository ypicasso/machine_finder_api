using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Documento.Commands.Create
{
    public class CreateCommandValidator : AppBaseValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(r => r.id_perfil).Must(IsValidString).WithMessage("El perfil es requerido");
            RuleFor(r => r.nom_documento).Must(IsValidString).WithMessage("El nombre del documento es requerido");
        }
    }
}
