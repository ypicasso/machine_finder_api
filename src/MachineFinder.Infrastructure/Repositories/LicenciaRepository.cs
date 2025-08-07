//------------------------------------------------------
using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Application.Features.Licencia.Commands.Create;
using MachineFinder.Application.Features.Licencia.Commands.Delete;
using MachineFinder.Application.Features.Licencia.Commands.Update;
using MachineFinder.Application.Features.Licencia.Queries.GetById;
using MachineFinder.Application.Features.Licencia.Queries.GetList;
using MachineFinder.Domain;
using MachineFinder.Domain.DTO.Licencia;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace MachineFinder.Infrastructure.Repositories
{
    public class LicenciaRepository : RepositoryBase, ILicenciaRepository
    {
        public LicenciaRepository(AppDBContext context, SessionStorage sessionStorage) : base(context, sessionStorage)
        {
        }

        public async Task<List<LicenciaDTO>> GetList(GetListQuery request)
        {
            var records = await _context.Licencia
                .Select(s => new LicenciaDTO()
                {
                    // Specifying field's
                    id_licencia = s.id_licencia,
                    id_perfil = s.id_perfil,
                    tit_licencia = s.tit_licencia,
                    can_meses = s.can_meses,
                    mas_meses = s.mas_meses,
                    val_licencia = s.val_licencia,
                    ind_oferta = s.ind_oferta,
                    ind_mixto = s.ind_mixto,
                })
                .ToListAsync();

            return records;
        }

        public async Task<LicenciaDTO?> GetById(GetByIdQuery request)
        {
            var record = await _context.Licencia
                //.Where(w => w.gid_Licencia == request.id)
                .Select(s => new LicenciaDTO()
                {
                    // Specifying field's    
                })
                .FirstOrDefaultAsync();

            return record;
        }

        public async Task<string> Create(CreateCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var gid = Guid.NewGuid().ToString();

                var record = new LicenciaEntity
                {
                    // Specifying field's
                };

                await AddEntityAsync(record);

                scope.Complete();
            }

            return $"Licencia creado satisfactoriamente.";
        }

        public async Task<string> Update(UpdateCommand request)
        {
            return "Licencia actualizado satisfactoriamente";
        }

        public async Task<string> Delete(DeleteCommand request)
        {
            return "Licencia eliminado satisfactoriamente";
        }
    }
}
