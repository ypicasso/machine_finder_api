using MachineFinder.Application.Features.Auth.Commands.Retrieve;
using MachineFinder.Application.Features.Auth.Commands.Signin;
using MachineFinder.Domain.DTO.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace MachineFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMediator mediator;

        public AuthController(IMediator mediator, IWebHostEnvironment env)
        {
            this.mediator = mediator;
            _env = env;
        }

        [HttpGet("ping")]
        public async Task<ActionResult> Ping()
        {
            await Task.Run(() =>
            {
                // fake content
            });

            return Ok();
        }

        [HttpPost("signin")]
        public async Task<AuthDTO> Signin([FromBody] SigninCommand request) => await mediator.Send(request.SetIndicator(GetMobileIndicator()));

        [HttpPost("signout")]
        public async Task<string> Signout()
        {
            await Task.Run(() =>
            {
                var token = GetToken();

                if (!string.IsNullOrEmpty(token))
                {
                    //if (!blackListService.IsTokenBlacklisted(token))
                    //{
                    //    var handler = new JwtSecurityTokenHandler();
                    //    var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                    //    if (jwtToken != null)
                    //    {
                    //        var expiry = jwtToken.ValidTo;

                    //        blackListService.InvalidateToken(token, expiry);
                    //    }
                    //}
                }
            });

            return "Sesíón cerrada correctamente";
        }

        [HttpPost("retrieve")]
        public async Task<string> Retrieve([FromBody] RetrieveCommand request) => await mediator.Send(request);

        [HttpGet("paths")]
        public async Task<ActionResult> Paths()
        {
            var path1 = string.Empty;
            var path2 = string.Empty;

            await Task.Run(() =>
            {
                var webRootPath = _env.WebRootPath;
                var contentRootPath = _env.ContentRootPath;

                path1 = webRootPath;
                path2 = contentRootPath;
            });

            var contentInfo = new DirectoryInfo(_env.ContentRootPath);

            var uploadPath = Path.Combine(contentInfo.Parent.FullName, "files", "ipbb");

            return Ok(new
            {
                webRoot = path1,
                contentRoot = path2,
                requestPath = $"{Request.Scheme}://{Request.Host}",
                mainPath = contentInfo.Parent.FullName,
                uploadPath = uploadPath
            });
        }
        private string GetToken()
        {
            string strToken = string.Empty;

            try
            {
                StringValues value = new StringValues();

                if (HttpContext.Request.Headers.TryGetValue("Authorization", out value))
                {
                    strToken = value[0]!.Split(" ")[1];

                }
            }
            catch (Exception ex)
            {
            }

            return strToken;
        }

        private bool GetMobileIndicator()
        {
            bool indicator = false;

            try
            {
                StringValues value = new StringValues();

                if (HttpContext.Request.Headers.TryGetValue("X-MOBILE", out value))
                {
                    indicator = true;
                }
            }
            catch (Exception ex)
            {
            }

            return indicator;
        }
    }
}
