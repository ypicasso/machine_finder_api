using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.TipoMaquinaria;

namespace MachineFinder.Application.Features.TipoMaquinaria.Queries.GetById
{
    public class GetByIdQueryHandler : MediatR.IRequestHandler<GetByIdQuery, TipoMaquinariaDTO>
    {
        protected readonly ITipoMaquinariaRepository repository;

        public GetByIdQueryHandler(ITipoMaquinariaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TipoMaquinariaDTO?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetById(request);
        }
    }
}
