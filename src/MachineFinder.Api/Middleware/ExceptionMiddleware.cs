using MachineFinder.Api.Errors;
using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Application.Exceptions;
using MachineFinder.Application.Models.Identity;
using MachineFinder.Domain;
using MachineFinder.Domain.DTO.Auth;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace MachineFinder.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly string _key;

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly SessionStorage _sessionStorage;

        private const string SESSION_MESSAGE = "Su sesión ha expirado, por favor vuelva a iniciar sesión";

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IOptions<JwtSettings> settings,

            IServiceScopeFactory scopeFactory,
            SessionStorage sessionStorage
        )
        {
            _key = settings.Value.Key;

            _next = next;
            _logger = logger;

            _scopeFactory = scopeFactory;
            _sessionStorage = sessionStorage;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var authHeader = context.Request.Headers[Constants.HEADER_AUTHORIZATION].FirstOrDefault();

                if (!string.IsNullOrEmpty(authHeader))
                {
                    string token = authHeader;

                    if (authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        // Remove "Bearer " prefix
                        token = authHeader.Substring("Bearer ".Length).Trim();
                    }

                    await attachUserToContext(context, token!);
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";

                var innerEx = ex.InnerException;
                var errorMessage = ex.Message;
                var codigo = (int)HttpStatusCode.InternalServerError;
                var errores = new List<string>();

                switch (ex)
                {
                    case NotFoundException nfe:
                        codigo = (int)HttpStatusCode.NotFound;
                        break;

                    case ValidationException vex:
                        codigo = (int)HttpStatusCode.BadRequest;
                        errores = vex.Errors.Select(s => s.Key ?? "").ToList();
                        break;

                    case BadRequestException brx:
                        codigo = (int)HttpStatusCode.BadRequest;
                        break;

                    case SecurityTokenSignatureKeyNotFoundException:
                    case SecurityTokenExpiredException:
                        codigo = (int)HttpStatusCode.Unauthorized;
                        errorMessage = SESSION_MESSAGE;
                        break;
                    case FluentValidation.ValidationException fve:
                        codigo = (int)HttpStatusCode.BadRequest;
                        errorMessage = string.Join(Environment.NewLine, fve.Errors.Select(s => $"-{s.ErrorMessage}.").ToList());
                        errores = fve.Errors.Select(s => s.ErrorMessage).ToList();
                        break;
                    default:
                        break;
                }

                while (innerEx != null)
                {
                    _logger.LogError(innerEx, innerEx.Message);

                    errorMessage += " " + innerEx.Message;
                    innerEx = innerEx.InnerException;
                }

                var resultado = JsonConvert.SerializeObject(new CodeErrorException(codigo, errorMessage, ex.StackTrace) { errors = errores });

                context.Response.StatusCode = codigo;

                await context.Response.WriteAsync(resultado);
            }
        }

        private async Task attachUserToContext(HttpContext context, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.FromDays(1)

            }, out SecurityToken validatedToken);

            var jwtTokenClaims = ((JwtSecurityToken)validatedToken).Claims;

            var userID = jwtTokenClaims.First(x => x.Type == JwtRegisteredClaimNames.NameId).Value;
            var userCode = jwtTokenClaims.First(x => x.Type == JwtRegisteredClaimNames.UniqueName).Value;
            var userName = jwtTokenClaims.First(x => x.Type == JwtRegisteredClaimNames.GivenName).Value;
            var userEmail = jwtTokenClaims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;

            using (var scope = _scopeFactory.CreateScope())
            {
                var authService = scope.ServiceProvider.GetService<IAuthRepository>();
                var userSession = await authService!.IsActiveUser(userID);

                if (!userSession)
                {
                    throw new SecurityTokenExpiredException();
                }

                var sessionData = new UserContainerDTO()
                {
                    IdUsuario = userID,
                    CodUsuario = userCode,
                    NomUsuario = userName,
                    EmaUsuario = userEmail,

                    CodEntorno = GetHeaderValue(context, Constants.HEADER_COD_ENTORNO).value ?? "",
                    CodPerfil = GetHeaderValue(context, Constants.HEADER_COD_PERFIL).value ?? "",
                    EsMobile = GetHeaderValue(context, Constants.HEADER_IS_MOBILE).found,
                };

                _sessionStorage.SetUser(sessionData);
            }

            context.Items[Constants.ID_USUARIO] = userID;
            context.Items[Constants.COD_USUARIO] = userCode;
            context.Items[Constants.NOM_USUARIO] = userName;
            context.Items[Constants.EMA_USUARIO] = userEmail;
        }

        private (bool found, string? value) GetHeaderValue(HttpContext context, string key)
        {
            string? mValue = null;
            bool mFound = false;

            if (context.Request.Headers.TryGetValue(key, out StringValues value))
            {
                mFound = true;
                mValue = value.ToString();
            }

            return (mFound, mValue);
        }
    }
}
