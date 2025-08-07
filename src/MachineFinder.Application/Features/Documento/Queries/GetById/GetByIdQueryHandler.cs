using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.Documento;
using MediatR;

namespace MachineFinder.Application.Features.Documento.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, DocumentoDTO?>
    {
        protected readonly IDocumentoRepository repository;

        public GetByIdQueryHandler(IDocumentoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DocumentoDTO?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.GetById(request);
        }
    }
}
