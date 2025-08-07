using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.Licencia;

namespace MachineFinder.Application.Features.Licencia.Queries.GetList
{
    public class GetListQueryHandler : MediatR.IRequestHandler<GetListQuery, List<LicenciaDTO>>
    {
        protected readonly ILicenciaRepository repository;

        public GetListQueryHandler(ILicenciaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<LicenciaDTO>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetList(request);
        }
    }
}
