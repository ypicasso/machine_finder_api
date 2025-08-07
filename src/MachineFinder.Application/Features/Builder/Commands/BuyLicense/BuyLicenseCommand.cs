using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Builder.Commands.BuyLicense
{
    public class BuyLicenseCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        public string? id_licencia { get; set; }
    }
}
