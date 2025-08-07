using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Queries.GetOwnerDetail
{
    public class GetOwnerDetailQueryValidator : AppBaseValidator<GetOwnerDetailQuery>
    {
        public GetOwnerDetailQueryValidator()
        {
            // RuleFor(r => r.cod_GetOwnerDetail).Must(IsValidString).WithMessage("El código de GetOwnerDetail es requerido");
        }
    }
}
