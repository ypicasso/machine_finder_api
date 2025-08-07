using FluentValidation;
using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Commands.UploadDocuments
{
    public class UploadDocumentsCommandValidator : AppBaseValidator<UploadDocumentsCommand>
    {
        public UploadDocumentsCommandValidator()
        {
            // RuleFor(r => r.cod_UploadDocuments).Must(IsValidString).WithMessage("El código de UploadDocuments es requerido");
        }
    }
}
