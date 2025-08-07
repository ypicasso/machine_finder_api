using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.Licencia;

namespace MachineFinder.Application.Features.Builder.Queries.GetLicenses
{
    public class GetLicensesQueryHandler : MediatR.IRequestHandler<GetLicensesQuery, List<LicenciaDTO>>
    {
        protected readonly IBuilderRepository repository;

        public GetLicensesQueryHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<LicenciaDTO>> Handle(GetLicensesQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetLicenses(request);
        }
    }
}
