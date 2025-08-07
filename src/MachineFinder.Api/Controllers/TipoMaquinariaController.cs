using MachineFinder.Application.Features.TipoMaquinaria.Commands.Create;
using MachineFinder.Application.Features.TipoMaquinaria.Commands.Delete;
using MachineFinder.Application.Features.TipoMaquinaria.Commands.Update;
using MachineFinder.Application.Features.TipoMaquinaria.Queries.GetList;
using MachineFinder.Application.Features.TipoMaquinaria.Queries.GetById;
using MachineFinder.Domain.DTO.TipoMaquinaria;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineFinder.Api.Controllers
{
    public class TipoMaquinariaController : AppBaseController
    {
        public TipoMaquinariaController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetList")]
        public async Task<ICollection<TipoMaquinariaDTO>> GetAll([FromQuery] GetListQuery command) => await _mediator.Send(command);

        [HttpGet("GetById")]
        public async Task<TipoMaquinariaDTO?> GetById([FromQuery] GetByIdQuery command) => await _mediator.Send(command);

        [HttpPost()]
        public async Task<string> Create([FromBody] CreateCommand command) => await _mediator.Send(command);

        [HttpPut()]
        public async Task<string> Update([FromBody] UpdateCommand command) => await _mediator.Send(command);

        [HttpDelete()]
        public async Task<string> Delete([FromQuery] DeleteCommand command) => await _mediator.Send(command);
    }
}
