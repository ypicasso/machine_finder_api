using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Update
{
    public class UpdateCommandValidator : AppBaseValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(r => r.id_tipo_maquinaria).Must(IsValidString).WithMessage("El ID es requerido");
            RuleFor(r => r.cod_tipo_maquina).Must(IsValidString).WithMessage("El código es requerido");
            RuleFor(r => r.nom_tipo_maquina).Must(IsValidString).WithMessage("El nombre es requerido");
        }
    }
}
