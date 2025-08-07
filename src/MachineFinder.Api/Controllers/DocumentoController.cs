using MachineFinder.Application.Features.Documento.Commands.Create;
using MachineFinder.Application.Features.Documento.Commands.Delete;
using MachineFinder.Application.Features.Documento.Commands.Update;
using MachineFinder.Application.Features.Documento.Queries.GetList;
using MachineFinder.Application.Features.Documento.Queries.GetById;
using MachineFinder.Domain.DTO.Documento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineFinder.Api.Controllers
{
    public class DocumentoController : AppBaseController
    {
        public DocumentoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetList")]
        public async Task<ICollection<DocumentoItemDTO>> GetList([FromQuery] GetListQuery command) => await _mediator.Send(command);

        [HttpGet("GetById")]
        public async Task<DocumentoDTO?> GetById([FromQuery] GetByIdQuery command) => await _mediator.Send(command);

        [HttpPost()]
        public async Task<string> Create([FromBody] CreateCommand command) => await _mediator.Send(command);

        [HttpPut()]
        public async Task<string> Update([FromBody] UpdateCommand command) => await _mediator.Send(command);

        [HttpDelete()]
        public async Task<string> Delete([FromQuery] DeleteCommand command) => await _mediator.Send(command);
    }
}
