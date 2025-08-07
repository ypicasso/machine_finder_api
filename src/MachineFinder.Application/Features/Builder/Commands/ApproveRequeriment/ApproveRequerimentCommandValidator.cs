using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Commands.ApproveRequeriment
{
    public class ApproveRequerimentCommandValidator : AppBaseValidator<ApproveRequerimentCommand>
    {
        public ApproveRequerimentCommandValidator()
        {
            // RuleFor(r => r.cod_ApproveRequeriment).Must(IsValidString).WithMessage("El código de ApproveRequeriment es requerido");
        }
    }
}
