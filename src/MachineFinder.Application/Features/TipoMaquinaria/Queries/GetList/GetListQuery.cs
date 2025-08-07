using MachineFinder.Domain.DTO.TipoMaquinaria;

namespace MachineFinder.Application.Features.TipoMaquinaria.Queries.GetList
{
    public class GetListQuery : MediatR.IRequest<List<TipoMaquinariaDTO>>
    {
        // Request Properties
        public bool? cod_estado { get; set; }
    }
}
