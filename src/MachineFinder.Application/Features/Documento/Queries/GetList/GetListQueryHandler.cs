using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.Documento;
using MediatR;

namespace MachineFinder.Application.Features.Documento.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<DocumentoItemDTO>>
    {
        protected readonly IDocumentoRepository repository;

        public GetListQueryHandler(IDocumentoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<DocumentoItemDTO>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.GetList(request);
        }
    }
}
