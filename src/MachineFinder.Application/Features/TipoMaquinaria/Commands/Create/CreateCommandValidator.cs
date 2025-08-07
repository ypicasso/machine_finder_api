using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Create
{
    public class CreateCommandValidator : AppBaseValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(r => r.cod_tipo_maquina).Must(IsValidString).WithMessage("El código es requerido");
            RuleFor(r => r.nom_tipo_maquina).Must(IsValidString).WithMessage("El nombre es requerido");
        }
    }
}
