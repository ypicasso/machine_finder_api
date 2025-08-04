using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Auth.Commands.Signout
{
    public class SignoutCommandValidator : AppBaseValidator<SignoutCommand>
    {
        public SignoutCommandValidator()
        {
            // RuleFor(r => r.cod_Signout).Must(IsValidString).WithMessage("El código de Signout es requerido");
        }
    }
}
