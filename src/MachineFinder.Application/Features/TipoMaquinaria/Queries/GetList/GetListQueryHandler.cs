using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.TipoMaquinaria;

namespace MachineFinder.Application.Features.TipoMaquinaria.Queries.GetList
{
    public class GetListQueryHandler : MediatR.IRequestHandler<GetListQuery, List<TipoMaquinariaDTO>>
    {
        protected readonly ITipoMaquinariaRepository repository;

        public GetListQueryHandler(ITipoMaquinariaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<TipoMaquinariaDTO>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetList(request);
        }
    }
}
