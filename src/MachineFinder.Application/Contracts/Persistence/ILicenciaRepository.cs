using MachineFinder.Application.Features.Licencia.Commands.Create;
using MachineFinder.Application.Features.Licencia.Commands.Delete;
using MachineFinder.Application.Features.Licencia.Commands.Update;
using MachineFinder.Application.Features.Licencia.Queries.GetById;
using MachineFinder.Application.Features.Licencia.Queries.GetList;
using MachineFinder.Domain.DTO.Licencia;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface ILicenciaRepository
    {
        Task<List<LicenciaDTO>> GetList(GetListQuery request);
        Task<LicenciaDTO> GetById(GetByIdQuery request);
        Task<string> Create(CreateCommand request);
        Task<string> Update(UpdateCommand request);
        Task<string> Delete(DeleteCommand request);
    }
}
