using MachineFinder.Application.Features.Documento.Commands.Create;
using MachineFinder.Application.Features.Documento.Commands.Delete;
using MachineFinder.Application.Features.Documento.Commands.Update;
using MachineFinder.Application.Features.Documento.Queries.GetList;
using MachineFinder.Application.Features.Documento.Queries.GetById;
using MachineFinder.Domain.DTO.Documento;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface IDocumentoRepository
    {
        Task<List<DocumentoItemDTO>> GetList(GetListQuery request);
        Task<DocumentoDTO?> GetById(GetByIdQuery request);
        Task<string> Create(CreateCommand request);
        Task<string> Update(UpdateCommand request);
        Task<string> Delete(DeleteCommand request);
    }
}
