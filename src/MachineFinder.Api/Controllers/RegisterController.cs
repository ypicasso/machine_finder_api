using MachineFinder.Application.Features.Register.Commands.RegisterBuilder;
using MachineFinder.Application.Features.Register.Commands.RegisterOwner;
using MachineFinder.Application.Features.Register.Commands.RegisterWorker;
using MachineFinder.Application.Features.Register.Queries.GetParams;
using MachineFinder.Domain.DTO.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ScreenParams")]
        public async Task<RegisterParamsDTO> ScreenParams([FromQuery] GetParamsQuery command) => await _mediator.Send(command);

        [HttpPost("Builder")]
        public async Task<string> RegisterBuilder([FromBody] RegisterBuilderCommand command) => await _mediator.Send(command);

        [HttpPost("Owner")]
        public async Task<string> RegisterOwner([FromBody] RegisterOwnerCommand command) => await _mediator.Send(command);

        [HttpPost("Worker")]
        public async Task<string> RegisterWorker([FromBody] RegisterWorkerCommand command) => await _mediator.Send(command);
    }
}