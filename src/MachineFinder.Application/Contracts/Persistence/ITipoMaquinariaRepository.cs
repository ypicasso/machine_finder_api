using MachineFinder.Application.Features.TipoMaquinaria.Commands.Create;
using MachineFinder.Application.Features.TipoMaquinaria.Commands.Delete;
using MachineFinder.Application.Features.TipoMaquinaria.Commands.Update;
using MachineFinder.Application.Features.TipoMaquinaria.Queries.GetById;
using MachineFinder.Application.Features.TipoMaquinaria.Queries.GetList;
using MachineFinder.Domain.DTO.TipoMaquinaria;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface ITipoMaquinariaRepository
    {
        Task<List<TipoMaquinariaDTO>> GetList(GetListQuery request);
        Task<TipoMaquinariaDTO?> GetById(GetByIdQuery request);
        Task<string> Create(CreateCommand request);
        Task<string> Update(UpdateCommand request);
        Task<string> Delete(DeleteCommand request);
    }
}
