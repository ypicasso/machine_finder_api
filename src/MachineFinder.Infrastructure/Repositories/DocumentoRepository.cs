using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Application.Features.Documento.Commands.Create;
using MachineFinder.Application.Features.Documento.Commands.Delete;
using MachineFinder.Application.Features.Documento.Commands.Update;
using MachineFinder.Application.Features.Documento.Queries.GetById;
using MachineFinder.Application.Features.Documento.Queries.GetList;
using MachineFinder.Domain;
using MachineFinder.Domain.DTO.Documento;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace MachineFinder.Infrastructure.Repositories
{
    public class DocumentoRepository : RepositoryBase, IDocumentoRepository
    {
        public DocumentoRepository(AppDBContext context, SessionStorage sessionStorage) : base(context, sessionStorage)
        {
        }

        public async Task<List<DocumentoItemDTO>> GetList(GetListQuery request)
        {
            return await _context.Documento
                .Select(s => new DocumentoItemDTO
                {
                    id_documento = s.id_documento,
                    nom_documento = s.nom_documento,
                    ind_requerido = s.ind_requerido,
                    nom_perfil = s.perfil.nom_perfil
                })
                .ToListAsync();
        }

        public async Task<DocumentoDTO?> GetById(GetByIdQuery request)
        {
            return await _context.Documento
                .Select(s => new DocumentoDTO
                {
                    id_documento = s.id_documento,
                    nom_documento = s.nom_documento,
                    ind_requerido = s.ind_requerido,
                    id_perfil = s.id_perfil,
                    nom_perfil = s.perfil.nom_perfil
                })
                .FirstOrDefaultAsync();
        }

        public async Task<string> Create(CreateCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var perfil = await _context.Perfil.FirstOrDefaultAsync(w => w.id_perfil == request.id_perfil);
                ThrowTrue(perfil == null, "Perfil no encontrado");

                var existente = await _context.Documento.FirstOrDefaultAsync(w => w.nom_documento == request.nom_documento && w.id_perfil == request.id_perfil);
                ThrowTrue(existente != null && existente.cod_estado == true, "Ya existe un documento con el mismo nombre para este perfil");

                if (existente != null)
                {
                    existente.ind_requerido = request.ind_requerido ?? false;

                    await UpdateEntityAsync(existente);
                }
                else
                {
                    existente = new DocumentoEntity
                    {
                        id_perfil = request.id_perfil!,
                        nom_documento = request.nom_documento!,
                        ind_requerido = request.ind_requerido ?? false,
                    };

                    await AddEntityAsync(existente);
                }

                scope.Complete();
            }

            return $"Documento creado satisfactoriamente";
        }

        public async Task<string> Update(UpdateCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var record = await _context.Documento.FirstOrDefaultAsync(w => w.id_documento == request.id_documento);
                ThrowTrue(record == null, "Documento no encontrado");

                var existente = await _context.Documento
                    .FirstOrDefaultAsync(w => w.nom_documento == request.nom_documento
                        && w.id_perfil == request.id_perfil
                        && w.id_documento != request.id_documento
                    );

                ThrowTrue(existente != null && existente.cod_estado == true, "Ya existe un documento con el mismo nombre para este perfil");

                record!.nom_documento = request.nom_documento!;
                record.ind_requerido = request.ind_requerido ?? false;

                await UpdateEntityAsync(record);

                scope.Complete();
            }

            return $"Documento actualizado satisfactoriamente";
        }

        public async Task<string> Delete(DeleteCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var record = await _context.Documento.FirstOrDefaultAsync(w => w.id_documento == request.id);
                ThrowTrue(record == null, "Documento no encontrado");

                await DeleteEntityAsync(record!);

                scope.Complete();
            }

            return $"Documento eliminado satisfactoriamente";
        }
    }
}
