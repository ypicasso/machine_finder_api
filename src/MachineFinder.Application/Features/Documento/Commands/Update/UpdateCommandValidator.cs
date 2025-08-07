using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Documento.Commands.Update
{
    public class UpdateCommandValidator : AppBaseValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(r => r.id_documento).Must(IsValidString).WithMessage("El ID es requerido");
            RuleFor(r => r.id_perfil).Must(IsValidString).WithMessage("El perfil es requerido");
            RuleFor(r => r.nom_documento).Must(IsValidString).WithMessage("El nombre del documento es requerido");
        }
    }
}
