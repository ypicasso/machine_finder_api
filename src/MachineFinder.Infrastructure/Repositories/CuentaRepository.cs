using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Application.Features.Cuenta.Commands.ChangePassword;
using MachineFinder.Domain;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using MachineFinder.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace MachineFinder.Infrastructure.Repositories
{
    public class CuentaRepository : RepositoryBase, ICuentaRepository
    {
        private readonly EncryptionService _encryption;
        private readonly BaseEmailer _emailer;

        public CuentaRepository(AppDBContext context, SessionStorage? sessionStorage, EncryptionService encryption, BaseEmailer emailer) : base(context, sessionStorage)
        {
            _encryption = encryption;
            _emailer = emailer;
        }

        public async Task<string> ChangePassword(ChangePasswordCommand request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var usuario = await _context.Usuario.Where(w => w.id_usuario == ID_USUARIO).FirstOrDefaultAsync();

                ThrowTrue(usuario, "El usuario no se encuentra registrado");
                var pss_decrypt = _encryption.Decrypt(usuario!.pwd_usuario);
                ThrowTrue(pss_decrypt != request.old_password, "La contraseña actual es incorrecta");

                // Validación de 3 ultimas contraseñas
                var ultimas = await _context.Contrasenia
                    .Where(w => w.id_usuario == usuario!.id_usuario)
                    .OrderByDescending(o => o.fec_insert)
                    .Select(s => _encryption.Decrypt(s.pwd_usuario))
                    .Take(3)
                    .ToListAsync();

                ThrowTrue(ultimas.Contains(request.new_password!), "Debe ingresar una contraseña diferente a las 3 últimas usadas");

                var ind_repassword = usuario.ind_repassword;

                usuario.pwd_usuario = _encryption.Encrypt(request.new_password!);
                usuario.ind_repassword = false;

                await UpdateEntityAsync(usuario);

                var contrasenia = new ContraseniaEntity { id_usuario = usuario!.id_usuario, pwd_usuario = usuario!.pwd_usuario };

                await _context.Contrasenia.AddAsync(contrasenia);
                await _context.SaveChangesAsync();

                scope.Complete();

                // ENVÍO DE CORREO DE INFORMACIÓN DE CAMBIO DE CONTRASEÑA
                if (ind_repassword == false)
                {
                    try
                    {
                        await _emailer.SendAsync(new Domain.DTO.Common.EmailData
                        {
                            title = "Cambio de contraseña",
                            body = $"<p>Hola {usuario.nom_usuario},</p><p>Su contraseña ha sido actualizada correctamente.</p><br /><br />Si usted no ha sido quien solicito este cambió de contraseña, le recomendamos recuperar su contraseña y actualizarla por una más segura.",
                            destinies = new List<string> { usuario.usu_email! }
                        });
                    }
                    catch (Exception mex)
                    {
                    }
                }
            }

            return "Contraseña actualizada satisfactoriamente";
        }
    }
}
