using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Licencia.Commands.Create
{
    public class CreateCommandValidator : AppBaseValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(r => r.id_perfil).Must(IsValidString).WithMessage("El perfil es requerido");
            RuleFor(r => r.tit_licencia).Must(IsValidString).WithMessage("El titulo es requerido");

            RuleFor(r => r.can_meses)
                .Must(IsValidInt).WithMessage("La cantidad de meses es requerida")
                .GreaterThan(0).WithMessage("La cantidad de meses debe ser mayor a cero");

            When(r => r.mas_meses != null, () =>
            {
                RuleFor(r => r.mas_meses).GreaterThanOrEqualTo(0).WithMessage("Los meses adicionales deben ser mayor o igual a cero");
            });

            RuleFor(r => r.val_licencia)
                .Must(IsValidDecimal).WithMessage("El valor es requerido")
                .GreaterThan(0).WithMessage("El valor de la licencia debe ser mayor a cero");
        }
    }
}
