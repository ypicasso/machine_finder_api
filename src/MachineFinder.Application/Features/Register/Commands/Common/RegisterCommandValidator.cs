using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Register.Commands.Common
{
    public class RegisterCommandValidator : AppBaseValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.nom_usuario).Must(IsValidString).WithMessage("El nombre es requerido");
            RuleFor(r => r.ape_paterno).Must(IsValidString).WithMessage("El apellido paterno es requerido");
            RuleFor(r => r.fec_nacimiento).Must(IsValidDateRequired).WithMessage(string.Format(ERR_FECHA, "de nacimiento"));
            RuleFor(r => r.tip_documento).Must(IsValidString).WithMessage("El tipo de documento es requerido");
            RuleFor(r => r.num_documento).Must(IsValidString).WithMessage("El número de documento es requerido");
            RuleFor(r => r.usu_email).Must(IsValidEmail).WithMessage("El email no tiene el formato requerido");

            When(r => !string.IsNullOrEmpty(r.num_telefono), () =>
            {
                RuleFor(r => r.num_telefono).Matches(@"^9\d{8}$").WithMessage("El número de teléfono debe comenzar con 9 y tener 9 dígitos");
            });

            RuleFor(r => r.pwd_usuario).Must(IsValidString).WithMessage("La contraseña es requerida");

            When(r => !string.IsNullOrEmpty(r.pwd_usuario), () =>
            {
                RuleFor(r => r.pwd_usuario!)
                    .MinimumLength(8).WithMessage("La contraseña debe tener mínimo 8 caracteres")
                    .Matches(@"[a-z]").WithMessage("La contraseña debe contar con mínimo una minúscula")
                    .Matches(@"[A-Z]").WithMessage("La contraseña debe contar con mínimo una mayúscula")
                    .Matches(@"\d").WithMessage("La contraseña debe contar con mínimo un número")
                    .Matches(@"[!@#$%^&*(),.?""':;{}|<>]").WithMessage("La contraseña debe contar con mínimo un caracter especial")
                ;
            });
        }
    }
}
