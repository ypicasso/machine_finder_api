using MachineFinder.Application.Features.Licencia.Commands.Create;
using MachineFinder.Application.Features.Licencia.Commands.Delete;
using MachineFinder.Application.Features.Licencia.Commands.Update;
using MachineFinder.Application.Features.Licencia.Queries.GetList;
using MachineFinder.Application.Features.Licencia.Queries.GetById;
using MachineFinder.Domain.DTO.Licencia;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineFinder.Api.Controllers
{
    public class LicenciaController : AppBaseController
    {
        public LicenciaController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetList")]
        public async Task<ICollection<LicenciaDTO>> GetList([FromQuery] GetListQuery command) => await _mediator.Send(command);

        [HttpGet("GetById")]
        public async Task<LicenciaDTO?> GetById([FromQuery] GetByIdQuery command) => await _mediator.Send(command);

        [HttpPost()]
        public async Task<string> Create([FromBody] CreateCommand command) => await _mediator.Send(command);

        [HttpPut()]
        public async Task<string> Update([FromBody] UpdateCommand command) => await _mediator.Send(command);

        [HttpDelete()]
        public async Task<string> Delete([FromQuery] DeleteCommand command) => await _mediator.Send(command);
    }
}
