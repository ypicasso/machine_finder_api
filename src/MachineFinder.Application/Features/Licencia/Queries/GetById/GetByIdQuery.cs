using MachineFinder.Domain.DTO.Licencia;

namespace MachineFinder.Application.Features.Licencia.Queries.GetById
{
    public class GetByIdQuery : MediatR.IRequest<LicenciaDTO>
    {
        // Request Properties
        public string? id { get; set; }
    }
}
