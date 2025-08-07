using MachineFinder.Domain;
using MachineFinder.Domain.DTO.Licencia;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Transactions;

namespace MachineFinder.Infrastructure.Services
{
    public class LicenciaService
    {
        private readonly AppDBContext _context;

        public LicenciaService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<LicenciaDTO>> GetLicenses(string cod_perfil)
        {
            return await _context.Licencia
                .Where(w => w.perfil.cod_perfil == cod_perfil && w.cod_estado == true)
                .OrderBy(o => o.ind_mixto == true ? 1 : 2)
                .ThenBy(t => t.can_meses)
                .Select(s => new LicenciaDTO
                {
                    id_licencia = s.id_licencia,
                    tit_licencia = s.tit_licencia,
                    can_meses = s.can_meses,
                    mas_meses = s.mas_meses,
                    val_licencia = s.val_licencia,
                    ind_oferta = s.ind_oferta,
                    ind_mixto = s.ind_mixto
                })
                .ToListAsync();
        }

        public async Task<string> BuyLicense(string id_usuario, string cod_perfil, string id_licencia, string cod_entorno)
        {
            int tot_meses = 0;
            var ext_meses = tot_meses == 1 ? "" : "es";
            var str_expiracion = "";

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var add_mixture = cod_perfil != Constants.TipoUsuario.WORKER;

                var licencia = await _context.Licencia
                    .Where(w => w.cod_estado == true && w.id_licencia == id_licencia && w.perfil.cod_perfil == cod_perfil)
                    .Include(i => i.perfil)
                    .FirstAsync();

                if (licencia == null)
                    throw new Exception("La licencia indicada no se encuentra disponible");

                tot_meses = licencia.can_meses + (licencia.mas_meses ?? 0);

                var is_builder = cod_perfil == Constants.TipoUsuario.BUILDER;
                var roles = new List<string>() { cod_perfil };

                if (add_mixture && licencia.ind_mixto)
                {
                    roles.Add(is_builder ? Constants.TipoUsuario.OWNER : Constants.TipoUsuario.BUILDER);
                }

                foreach (var rol in roles)
                {
                    var cuenta = await _context.Cuenta.FirstOrDefaultAsync(w => w.id_usuario == id_usuario && w.perfil.cod_perfil == rol);
                    var perfil = await _context.Perfil.FirstAsync(w => w.cod_perfil == rol);

                    if (cuenta == null)
                    {
                        cuenta = new CuentaEntity
                        {
                            id_usuario = id_usuario,
                            id_perfil = perfil.id_perfil
                        };

                        await _context.Cuenta.AddAsync(cuenta);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Cuenta.Update(cuenta);

                        await _context.SaveChangesAsync();
                    }

                    var cuenta_licencia = await _context.CuentaLicencia
                        .Where(w => w.cuenta.id_usuario == id_usuario && w.cuenta.id_perfil == perfil.id_perfil)
                        .OrderByDescending(o => o.fec_expiracion)
                        .FirstOrDefaultAsync();

                    var fec_expiracion = (cuenta_licencia?.fec_expiracion ?? DateTime.Now).AddMonths(tot_meses).AddSeconds(1);

                    var nueva_licencia = new CuentaLicenciaEntity
                    {
                        id_cuenta = cuenta.id_cuenta,
                        id_licencia = licencia.id_licencia,
                        tit_licencia = licencia.tit_licencia,
                        can_meses = licencia.can_meses,
                        mas_meses = licencia.mas_meses,
                        val_licencia = licencia.val_licencia,
                        ind_oferta = licencia.ind_oferta,
                        ind_mixto = licencia.ind_mixto,
                        cod_entorno = cod_entorno,
                        cod_origen = cod_perfil,
                        fec_compra = DateTime.Now,
                        fec_expiracion = fec_expiracion
                    };

                    await _context.CuentaLicencia.AddAsync(nueva_licencia);
                    await _context.SaveChangesAsync();

                    if (roles.IndexOf(rol) == 0)
                    {
                        str_expiracion = fec_expiracion.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                }

                scope.Complete();
            }

            return $"Usted ha adquirido su licencia satisfactoriamente, la cual tiene {tot_meses} mes{ext_meses} de vigencia y expirará el {str_expiracion}.";
        }
    }
}
