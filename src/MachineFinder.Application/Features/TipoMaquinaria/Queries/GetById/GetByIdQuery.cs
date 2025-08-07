using MachineFinder.Domain.DTO.TipoMaquinaria;

namespace MachineFinder.Application.Features.TipoMaquinaria.Queries.GetById
{
    public class GetByIdQuery : MediatR.IRequest<TipoMaquinariaDTO>
    {
        // Request Properties
        public string? id_tipo_maquinaria { get; set; }
    }
}
