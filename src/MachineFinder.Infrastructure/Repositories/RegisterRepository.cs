using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Application.Features.Register.Commands.Common;
using MachineFinder.Application.Features.Register.Commands.RegisterBuilder;
using MachineFinder.Application.Features.Register.Commands.RegisterOwner;
using MachineFinder.Application.Features.Register.Commands.RegisterWorker;
using MachineFinder.Application.Features.Register.Queries.GetParams;
using MachineFinder.Domain;
using MachineFinder.Domain.DTO.Common;
using MachineFinder.Domain.DTO.Register;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using MachineFinder.Infrastructure.Services;
using MachineFinder.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace MachineFinder.Infrastructure.Repositories
{
    public class RegisterRepository : RepositoryBase, IRegisterRepository
    {
        private readonly FileProcessor _fileProcessor;
        private readonly EncryptionService _encryptionService;

        public RegisterRepository(
            AppDBContext context,
            SessionStorage? sessionStorage,
            FileProcessor fileProcessor,
            EncryptionService encryptionService
            ) : base(context, sessionStorage)
        {
            _fileProcessor = fileProcessor;
            _encryptionService = encryptionService;
        }

        public async Task<RegisterParamsDTO> GetParams(GetParamsQuery request)
        {
            var response = new RegisterParamsDTO();

            response.tipos_documentos = await _context.Catalogo.Where(w => w.cod_estado == true && w.cod_tabla == Constants.Tablas.TIPDOC)
                .OrderBy(o => o.nom_campo)
                .Select(s => new CodeTextDTO
                {
                    code = s.cod_campo,
                    text = s.nom_campo
                })
                .ToListAsync();

            response.tipos_usuarios = await _context.Catalogo.Where(w => w.cod_estado == true && w.cod_tabla == Constants.Tablas.TIPUSU)
                .OrderBy(o => o.nom_campo)
                .Select(s => new CodeTextDTO
                {
                    code = s.cod_campo,
                    text = s.nom_campo
                })
                .ToListAsync();

            foreach (var item in response.tipos_usuarios)
            {
                item.childs = await _context.Catalogo
                    .Where(w => w.cod_estado == true && w.cod_tabla == Constants.Tablas.DOCS && w.ext_campo == item.code)
                    .OrderBy(o => o.nom_campo)
                    .Select(s => new CodeTextDTO
                    {
                        code = s.cod_campo,
                        text = s.nom_campo,
                    })
                    .ToListAsync();
            }

            return response;
        }

        public async Task<string> RegisterBuilder(RegisterBuilderCommand request) => await RegisterUser(request, Constants.TipoUsuario.BUILDER);

        public async Task<string> RegisterOwner(RegisterOwnerCommand request) => await RegisterUser(request, Constants.TipoUsuario.OWNER);

        public async Task<string> RegisterWorker(RegisterWorkerCommand request) => await RegisterUser(request, Constants.TipoUsuario.WORKER);


        private async Task<string> RegisterUser(RegisterCommand request, string tipusu)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var usuario = await _context.Usuario.FirstOrDefaultAsync(w => w.usu_email == request.usu_email);

                ThrowTrue(usuario != null, "La cuenta de correo ya se encuentra registrada. Por favor inicie sesión y asignese el perfil deseado.");

                #region Usuario...

                var usuarios = await _context.Cuenta.Where(w => w.perfil.cod_perfil == tipusu)
                    .Select(s => Convert.ToInt32(s.usuario.cod_usuario.Replace(tipusu + "-", "")))
                    .ToListAsync();

                var maxTipusu = usuarios.Count > 0 ? usuarios.Max() : 0;

                var password = _encryptionService.Encrypt(request!.pwd_usuario!);

                var record = new UsuarioEntity
                {
                    id_usuario = NewGuid(),
                    cod_usuario = $"{tipusu}-{maxTipusu + 1}",
                    nom_usuario = request!.nom_usuario!,
                    ape_paterno = request!.ape_paterno!,
                    ape_materno = request!.ape_materno,
                    fec_nacimiento = request!.fec_nacimiento.ToDate(),
                    tip_documento = request!.tip_documento ?? "",
                    num_documento = request!.num_documento ?? "",
                    usu_email = request!.usu_email,
                    num_telefono = request!.num_telefono,
                    pwd_usuario = password,
                    fec_cese = null,
                    obs_cese = null,
                    tip_usuario = tipusu,
                    ind_confirmacion = false,
                    fec_confirmacion = null,
                    ind_repassword = true,
                    fec_repassword = null
                };

                await _context.Usuario.AddAsync(record);
                await _context.SaveChangesAsync();

                #endregion

                #region Histórico de contraseñas...

                var contrasenia = new ContraseniaEntity
                {
                    id_usuario = record.id_usuario,
                    pwd_usuario = password,
                };

                await _context.Contrasenia.AddAsync(contrasenia);
                await _context.SaveChangesAsync();

                #endregion

                #region (Cuenta) Usuario/Perfil...

                var perfil = await _context.Perfil.FirstOrDefaultAsync(w => w.cod_perfil == tipusu);

                var cuenta = new CuentaEntity
                {
                    id_cuenta = NewGuid(),
                    id_usuario = record!.id_usuario,
                    id_perfil = perfil!.id_perfil,
                };

                await _context.Cuenta.AddAsync(cuenta);
                await _context.SaveChangesAsync();

                #endregion

                #region Documentos...

                if (request.documentos != null && request.documentos.Count > 0)
                {
                    foreach (var doc in request.documentos)
                    {
                        var new_url_documento = _fileProcessor.ProcesarUrl(doc.url_documento!, "usuarios", record.cod_usuario, tipusu);
                        var doc_info = new FileInfo(new_url_documento);

                        var documento = new CuentaDocumentoEntity
                        {
                            id_cuenta_documento = NewGuid(),
                            id_cuenta = cuenta!.id_cuenta,
                            cod_documento = doc.cod_documento!,
                            nom_documento = doc_info.Name,
                            ext_documento = Path.GetExtension(doc_info.Name),
                            url_documento = new_url_documento,
                            ind_registro = true,
                            cod_entorno = COD_ENTORNO!,
                        };

                        await _context.CuentaDocumento.AddAsync(documento);
                        await _context.SaveChangesAsync();
                    }
                }
                #endregion

                #region Envío de correo de credenciales y activación de cuenta...

                //TODO: Implementar el envío de correo electrónico con las credenciales y un enlace para activar la cuenta.

                #endregion

                scope.Complete();
            }

            return "Su usuario ha sido registrado correctamente. Por favor revide su bandeja de entrada para activar su cuenta";
        }
    }
}
