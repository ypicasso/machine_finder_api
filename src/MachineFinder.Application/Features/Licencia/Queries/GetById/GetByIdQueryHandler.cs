using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.Licencia;

namespace MachineFinder.Application.Features.Licencia.Queries.GetById
{
    public class GetByIdQueryHandler : MediatR.IRequestHandler<GetByIdQuery, LicenciaDTO>
    {
        protected readonly ILicenciaRepository repository;

        public GetByIdQueryHandler(ILicenciaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<LicenciaDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetById(request);
        }
    }
}
