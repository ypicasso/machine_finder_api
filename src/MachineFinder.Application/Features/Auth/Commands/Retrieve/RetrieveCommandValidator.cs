using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Auth.Commands.Retrieve
{
    public class RetrieveCommandValidator : AppBaseValidator<RetrieveCommand>
    {
        public RetrieveCommandValidator()
        {
            // RuleFor(r => r.cod_Retrieve).Must(IsValidString).WithMessage("El código de Retrieve es requerido");
        }
    }
}
