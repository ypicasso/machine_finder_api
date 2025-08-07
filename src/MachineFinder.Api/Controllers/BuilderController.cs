using MachineFinder.Application.Features.Builder.Commands.BuyLicense;
using MachineFinder.Application.Features.Builder.Queries.GetLicenses;
using MachineFinder.Domain.DTO.Licencia;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineFinder.Api.Controllers
{
    public class BuilderController : AppBaseController
    {
        public BuilderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("Licenses")]
        public async Task<List<LicenciaDTO>> GetLicenses(GetLicensesQuery command) => await _mediator.Send(command);

        [HttpGet("BuyLicense")]
        public async Task<string> BuyLicense(BuyLicenseCommand command) => await _mediator.Send(command);
    }
}
