using MachineFinder.Application.Features.Cuenta.Commands.ChangePassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineFinder.Api.Controllers
{
    public class CuentaController : AppBaseController
    {
        public CuentaController(IMediator mediator) : base(mediator)
        {
            //
        }

        [HttpPost("ChangePassword")]
        public async Task<string> ChangePassword([FromBody] ChangePasswordCommand command) => await _mediator.Send(command);
    }
}
