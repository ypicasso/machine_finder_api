using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Commands.BuyLicense
{
    public class BuyLicenseCommandValidator : AppBaseValidator<BuyLicenseCommand>
    {
        public BuyLicenseCommandValidator()
        {
            RuleFor(r => r.id_licencia).Must(IsValidString).WithMessage("La licencia es requerida");
        }
    }
}
