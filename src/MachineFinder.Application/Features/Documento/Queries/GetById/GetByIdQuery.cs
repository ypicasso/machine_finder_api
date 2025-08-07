using MachineFinder.Application.Features.Common;
using MachineFinder.Domain.DTO.Documento;
using MediatR;

namespace MachineFinder.Application.Features.Documento.Queries.GetById
{
    public class GetByIdQuery : AppBaseCommand, IRequest<DocumentoDTO?>
    {
        public string? id { get; set; }
    }
}
