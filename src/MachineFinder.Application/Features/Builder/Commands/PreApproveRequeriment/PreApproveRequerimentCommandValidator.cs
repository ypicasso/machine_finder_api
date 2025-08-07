using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Commands.PreApproveRequeriment
{
    public class PreApproveRequerimentCommandValidator : AppBaseValidator<PreApproveRequerimentCommand>
    {
        public PreApproveRequerimentCommandValidator()
        {
            // RuleFor(r => r.cod_PreApproveRequeriment).Must(IsValidString).WithMessage("El código de PreApproveRequeriment es requerido");
        }
    }
}
