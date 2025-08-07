//------------------------------------------------------
using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Application.Features.TipoMaquinaria.Commands.Create;
using MachineFinder.Application.Features.TipoMaquinaria.Commands.Delete;
using MachineFinder.Application.Features.TipoMaquinaria.Commands.Update;
using MachineFinder.Application.Features.TipoMaquinaria.Queries.GetById;
using MachineFinder.Application.Features.TipoMaquinaria.Queries.GetList;
using MachineFinder.Domain;
using MachineFinder.Domain.DTO.TipoMaquinaria;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using MachineFinder.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace MachineFinder.Infrastructure.Repositories
{
    public class TipoMaquinariaRepository : RepositoryBase, ITipoMaquinariaRepository
    {
        private readonly FileProcessor _fileProcesor;

        public TipoMaquinariaRepository(AppDBContext context, SessionStorage sessionStorage, FileProcessor fileProcessor) : base(context, sessionStorage)
        {
            _fileProcesor = fileProcessor;
        }

        public async Task<List<TipoMaquinariaDTO>> GetList(GetListQuery request)
        {
            return await _context.TipoMaquinaria
                .Where(w => request.cod_estado == null || w.cod_estado == request.cod_estado)
                .Select(s => new TipoMaquinariaDTO
                {
                    // Specifying field's
                    id_tipo_maquinaria = s.id_tipo_maquinaria,
                    cod_tipo_maquina = s.cod_tipo_maquina,
                    nom_tipo_maquina = s.nom_tipo_maquina,
                    url_imagen = s.url_imagen,
                })
                .ToListAsync();
        }

        public async Task<TipoMaquinariaDTO?> GetById(GetByIdQuery request)
        {
            return await _context.TipoMaquinaria
                .Where(w => w.cod_estado == true && w.id_tipo_maquinaria == request.id_tipo_maquinaria)
                .Select(s => new TipoMaquinariaDTO
                {
                    // Specifying field's
                    id_tipo_maquinaria = s.id_tipo_maquinaria,
                    cod_tipo_maquina = s.cod_tipo_maquina,
                    nom_tipo_maquina = s.nom_tipo_maquina,
                    url_imagen = s.url_imagen,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<string> Create(CreateCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var existente = await _context.TipoMaquinaria
                    .AnyAsync(a => a.cod_tipo_maquina == request!.cod_tipo_maquina);

                ThrowTrue(existente, "Ya existe un tipo de maquinaria con el código especificado.");

                var record = new TipoMaquinariaEntity
                {
                    // Specifying field's
                    id_tipo_maquinaria = NewGuid(),
                    cod_tipo_maquina = request!.cod_tipo_maquina!,
                    nom_tipo_maquina = request!.nom_tipo_maquina!,
                    url_imagen = request!.url_imagen ?? "",
                };

                ProcesarImagen(record, request!.url_imagen);

                await AddEntityAsync(record);

                scope.Complete();
            }

            return $"Tipo de Maquinaria creada satisfactoriamente.";
        }

        public async Task<string> Update(UpdateCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var record = await _context.TipoMaquinaria.FirstOrDefaultAsync(f => f.id_tipo_maquinaria == request!.id_tipo_maquinaria);

                ThrowTrue(record == null, "No se encontró el tipo de maquinaria especificado.");

                if (request.ind_eliminado == true)
                    record!.url_imagen = "";

                record!.cod_tipo_maquina = request!.cod_tipo_maquina!;
                record!.nom_tipo_maquina = request!.nom_tipo_maquina!;

                ProcesarImagen(record, request!.url_imagen);

                await UpdateEntityAsync(record!);

                scope.Complete();
            }

            return $"Tipo de Maquinaria creada satisfactoriamente.";
        }

        private void ProcesarImagen(TipoMaquinariaEntity record, string? url_imagen)
        {
            if (url_imagen != null)
            {
                var new_url_imagen = _fileProcesor.ProcesarUrl(url_imagen, "tipmaq", "images");

                record.url_imagen = new_url_imagen;
            }
        }

        public async Task<string> Delete(DeleteCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var record = await _context.TipoMaquinaria.FirstOrDefaultAsync(f => f.id_tipo_maquinaria == request!.id_tipo_maquinaria);

                ThrowTrue(record == null, "No se encontró el tipo de maquinaria especificada.");

                await DeleteEntityAsync(record!);

                scope.Complete();
            }

            return $"Tipo de Maquinaria eliminada satisfactoriamente.";
        }
    }
}
