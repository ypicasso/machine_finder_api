using MachineFinder.Application.Features.Common;
using MachineFinder.Domain.DTO.Documento;
using MediatR;

namespace MachineFinder.Application.Features.Documento.Queries.GetList
{
    public class GetListQuery : AppBaseCommand, IRequest<List<DocumentoItemDTO>>
    {
        // Request Properties
        public string? id_perfil { get; set; }
        public string? nom_documento { get; set; }
        public bool? ind_requerido { get; set; }
    }
}
