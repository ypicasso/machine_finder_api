using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Auth.Commands.Signin
{
    public class SigninCommandValidator : AppBaseValidator<SigninCommand>
    {
        public SigninCommandValidator()
        {
            // RuleFor(r => r.cod_Signin).Must(IsValidString).WithMessage("El código de Signin es requerido");
        }
    }
}
