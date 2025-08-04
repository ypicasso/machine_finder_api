using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Application.Features.Auth.Commands.Retrieve;
using MachineFinder.Application.Features.Auth.Commands.Signin;
using MachineFinder.Application.Features.Auth.Commands.Signout;
using MachineFinder.Application.Models.Identity;
using MachineFinder.Domain.DTO.Auth;
using MachineFinder.Domain.DTO.Common;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using MachineFinder.Infrastructure.Services;
using MachineFinder.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MachineFinder.Infrastructure.Repositories
{
    public class AuthRepository : RepositoryBase<UsuarioEntity>, IAuthRepository
    {
        private readonly JwtSettings _jwtSettings;
        private readonly BaseEmailer _emailer;
        private readonly EncryptionService _encryption;
        private readonly FileProcessor _fileProcessor;

        public AuthRepository(
            AppDBContext context,
            IServiceScopeFactory factory,
            IOptions<JwtSettings> jwtSettings,
            EncryptionService encryption,
            FileProcessor fileProcessor,
            BaseEmailer emailer) : base(context, null)
        {
            _jwtSettings = jwtSettings.Value;
            _encryption = encryption;
            _emailer = emailer;
            _fileProcessor = fileProcessor;
        }

        public async Task<string> Retrieve(RetrieveCommand request)
        {
            var usuario = await _context.Usuario.Where(w => w.cod_usuario == request.cod_usuario).FirstOrDefaultAsync();

            ThrowTrue(usuario, "El usuario indicado no se encuentra registrado");

            var isEmail = false;
            var messageEmail = "";
            var messageOthers = "";

            try
            {
                if (usuario!.usu_email.IsValidEmail())
                {
                    var password = _encryption.Decrypt(usuario!.pwd_usuario);
                    var values = usuario!.usu_email!.Split('@');
                    var parte1 = "";// values[0].Substring(0, 3) + "".PadRight(values[0].Length - 3, '*');
                    var parte2 = "";// values[1];

                    var emailBody = $"""
                    Hola {usuario.nom_usuario} {usuario.ape_paterno} {usuario.ape_materno},
                    <br />
                    Te enviamos la contraseña de tu Cuenta Machine Finder <b>{password}</b>.
                    <br /><br />
                    Saludos cordiales.
                    """;

                    await _emailer.SendAsync(new EmailData
                    {
                        title = "Solicitud de contraseña",
                        body = emailBody,
                        destinies = [usuario!.usu_email!],
                    });

                    messageEmail = $"Se ha enviado la información requerida al correo {parte1}@{parte2}";
                    isEmail = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido procesar su solicitud. Intentelo en unos minutos.");
            }

            return isEmail ? messageEmail : messageOthers;
        }

        public async Task<AuthDTO> Signin(SigninCommand request)
        {
            var response = new AuthDTO();
            var usuario = await _context.Usuario.Where(w => w.usu_email == request.username)
                .Include(i => i.usuario_perfiles!).ThenInclude(t => t.perfil)
                .FirstOrDefaultAsync();

            ThrowTrue(usuario, "Las credenciales son incorrectas");

            var password = _encryption.Decrypt(usuario!.pwd_usuario);

            ThrowTrue(password != request.password, "Las credenciales son incorrectas");


            var token = GenerateToken(usuario!);
            var baseUrl = _fileProcessor.GetBaseUrl();

            response.id_usuario = usuario!.id_usuario;
            response.nom_usuario = usuario!.nom_usuario;
            response.ape_paterno = usuario.ape_paterno;
            response.ape_materno = usuario.ape_materno;

            response.tip_documento = usuario.tip_documento;
            response.num_documento = usuario.num_documento;
            response.num_telefono = usuario.num_telefono;
            response.fec_nacimiento = usuario.fec_nacimiento.ToSpanish();

            response.email = usuario!.usu_email;
            response.ind_confirmacion = usuario.ind_confirmacion;
            response.ind_repassword = usuario.ind_repassword;
            response.perfiles = usuario.usuario_perfiles?
                .Where(w => w.cod_estado == true)
                .Select(s => new AuthPerfilDTO(s.id_perfil, s.perfil?.cod_perfil!, baseUrl + s.perfil?.nom_perfil!)).ToList() ?? new List<AuthPerfilDTO>();

            if (usuario.tip_usuario == "KAMISAMA")
            {
                response.perfiles = response.perfiles ?? [];
                response.perfiles.Insert(0, new AuthPerfilDTO("ADMIN", "Administrador", baseUrl + "images/administrator.png"));
            }

            response.token = new JwtSecurityTokenHandler().WriteToken(token);

            return response;
        }

        public Task<bool> Signout(SignoutCommand request)
        {
            throw new NotImplementedException();
        }

        private JwtSecurityToken GenerateToken(UsuarioEntity usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.id_usuario!),
                new Claim(JwtRegisteredClaimNames.GivenName, $"{usuario.nom_usuario} {usuario.ape_paterno ?? ""} {usuario.ape_materno ?? ""}".Trim()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.usu_email ?? ""),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.cod_usuario ?? ""),
                //------------------------------------------------------------------------------------------------------------------------------------
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signinCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: BaseDomainModel.GetNow().AddMinutes(_jwtSettings.MinDuration),
                signingCredentials: signinCredentials
            );

            return jwtSecurityToken;
        }

        public async Task<bool> IsActiveUser(string? id)
        {
            var usuario = await _context.Usuario.Where(w => w.id_usuario == id).FirstOrDefaultAsync();

            return usuario?.cod_estado ?? false;
        }
    }
}
